using FirstApi.DTOs.Entities;
using FirstApi.Models;
using FirstApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FirstApi.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {

        private readonly ITokenService _tokenService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;

        public AuthController(ITokenService tokenService, UserManager<ApplicationUser> userManager, 
                              RoleManager<IdentityRole> roleManager, IConfiguration config) {
            
            _tokenService = tokenService;
            _userManager = userManager;
            _roleManager = roleManager;
            _config = config;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model) {

            var user = await _userManager.FindByNameAsync(model.Username!);

            if (user is not null && await _userManager.CheckPasswordAsync(user, model.Password!)) {

                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim> {
                    new Claim(ClaimTypes.Name, user.UserName!),
                    new Claim(ClaimTypes.Email, user.Email!),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var userRole in userRoles) {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = _tokenService.GenerateAccessToken(authClaims, _config);

                var refreshToken = _tokenService.GenerateRefreshToken();

                _ = int.TryParse(_config["JWT:RefreshTokenValidityInMinutes"], out int refreshTokenValidityInMinutes);

                user.RefreshToken = refreshToken;

                user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(refreshTokenValidityInMinutes);

                await _userManager.UpdateAsync(user);

                return Ok(new {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    RefreshToken  = refreshToken,
                    Expiration = token.ValidTo
                });
            }

            return Unauthorized();

        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model) {

            var userExists = await _userManager.FindByNameAsync(model.Username!);

            if (userExists != null) {

                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Already Exists" });
            
            }

            ApplicationUser user = new() {

                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(user, model.Password!);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Creation Failed" });
            }

            return Ok(new Response { Status = "Success", Message = "User created Sucessfully" });

        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenModel tokenModel) {

            if (tokenModel == null) {
                return BadRequest("Invalid Client Request");
            }

            string? accessToken = tokenModel.AccessToken ?? throw new ArgumentNullException(nameof(tokenModel));
            string? refreshToken = tokenModel.RefreshToken ?? throw new ArgumentNullException(nameof(refreshToken));

            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken!, _config);

            if (principal == null) {
                return BadRequest("Invalid Access Token/Refresh Token");
            }

            string username = principal.Identity.Name;

            var user = await _userManager.FindByNameAsync(username!);

            if (user == null || user.RefreshToken != refreshToken
                             || user.RefreshTokenExpiryTime <= DateTime.Now) {
                return BadRequest("Invalid Access Token/Refresh Token");
            }

            var newAccessToken = _tokenService.GenerateAccessToken(principal.Claims.ToList(), _config);

            var newRefreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _userManager.UpdateAsync(user);

            return new ObjectResult(new {
                accessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                refreshToken = newRefreshToken
            });

        }

        [Authorize]
        [HttpPost]
        [Route("revoke/{username}")]
        public async Task<IActionResult> Revoke(string username) {

            var user = await _userManager.FindByNameAsync(username);

            if (user == null) {
                return BadRequest("Invalid Username");
            }
            
            
            user.RefreshToken = null;

            await _userManager.UpdateAsync(user);

            return NoContent();


        }
        

    }
}
