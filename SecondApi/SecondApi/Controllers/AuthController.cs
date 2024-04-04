using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecondApi.DTOs.Entities;
using SecondApi.Models;
using SecondApi.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SecondApi.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _config;

        public AuthController(UserManager<ApplicationUser> userManager, ITokenService tokenService,
                              IConfiguration config, RoleManager<IdentityRole> roleManager) {
            _userManager = userManager;
            _config = config;
            _tokenService = tokenService;
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model) {

            var user = await _userManager.FindByNameAsync( model.Username! );

            if ( user is not null && await _userManager.CheckPasswordAsync(user, model.Password!)) {
                
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim> {
                    new Claim(ClaimTypes.Name, user.UserName!),
                    new Claim(ClaimTypes.Email, user.Email!),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var role in userRoles) {
                    var userrole = new Claim(ClaimTypes.Role, role);
                    authClaims.Add(userrole);
                }

                var accessToken = _tokenService.GenerateAccessToken(authClaims, _config);

                var refreshToken = _tokenService.GenerateRefreshToken();

                user.RefreshToken = refreshToken;

                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(_config.GetSection("JWT").GetValue<int>("RefreshTokenExpiryInMinutes"));

                await _userManager.UpdateAsync(user);

                return Ok(new {
                    Token = new JwtSecurityTokenHandler().WriteToken(accessToken),
                    RefreshToken = refreshToken,
                    Expiration = accessToken.ValidTo
                });
            }

            return Unauthorized( new Response { Status = "Error", Message = "Login Error"} );

        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterModel model) {

            var userExists = await _userManager.FindByNameAsync(model.Username!);
            if ( userExists != null) {
                return BadRequest(new Response { Status = "Error", Message = "User already exists" });
            }

            ApplicationUser applicationUser = new ApplicationUser {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(applicationUser, model.Password!);

            if (!result.Succeeded) {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User register failed" });
            }

            return Ok(new Response { Status = "Success", Message = "User created successfully" });

        }


        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken(TokenModel model) {

            if (model == null) {
                return BadRequest(new Response { Status = "Error", Message = "Token is required" });
            }

            string? accessToken = model.AccessToken;
            string? refreshToken = model.RefreshToken;

            var principal = _tokenService.GetClaimsPrincipalFromExpiredToken(accessToken!, _config);

            if (principal == null) {
                return BadRequest(new Response { Status = "Error", Message = "AccesToken/RefreshToken Invalid" });
            }

            var username = principal.Identity!.Name;

            var user = await _userManager.FindByNameAsync(username!);

            if (user == null || user.RefreshToken != refreshToken
                             || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return BadRequest(new Response { Status = "Error", Message = "AccessToken/RefreshToken Invalid" });
            }

          
            var newAccessToken = _tokenService.GenerateAccessToken(principal.Claims.ToList(), _config);

            var newRefreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(_config.GetSection("JWT").GetValue<int>("RefreshTokenExpiryInMinutes"));
            await _userManager.UpdateAsync(user);

            return Ok( new {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = newRefreshToken
            });

        }

        [HttpPost]
        [Route("revoke/{username}")]
        public async Task<IActionResult> Revoke(string username) {

            var user = await _userManager.FindByNameAsync(username);

            if ( user == null) {
                return BadRequest(new Response { Status = "Error", Message = "User not found" });
            }

            user.RefreshToken = null;

            return NoContent();
        }

        [HttpPost]
        [Route("create-role")]
        public async Task<IActionResult> CreateRole(string roleName) {

            var roleExists = await _roleManager.FindByNameAsync(roleName);
            
            if ( roleExists != null) {
                return BadRequest(new Response { Status = "Error", Message = "Role Name already exists" });
            }


            var role = new IdentityRole(roleName);

            var result = await _roleManager.CreateAsync(role);

            if ( result.Succeeded) {
                return Ok(new Response { Status = "Success", Message = "Role created successfully" });
            }else {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Issue while attempting create role" });
            }
        }

        [HttpPost]
        [Route("user-to-role")]
        public async Task<IActionResult> AddUserToRole(string roleName, string userName) {

            var role = await _roleManager.FindByNameAsync(roleName);
            var user = await _userManager.FindByNameAsync(userName);

            if ( ( role == null ) || (user == null)  ) { 
                return BadRequest( new Response { Status = "Error", Message = "Role/User does not exist"});
            }

            var result = await _userManager.AddToRoleAsync(user, roleName);

            if ( !result.Succeeded ) {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Issue while attempting add user to role" });
            }

            return Ok(new Response { Status = "Success", Message = "User added to role successfully" });

        }

    }
}
