using System.ComponentModel.DataAnnotations;

namespace SecondApi.DTOs.Entities {
    public class TokenModel {

        [Required(ErrorMessage = "Access Token is Required")]
        public string? AccessToken { get; set; }

        [Required(ErrorMessage = "Access Token is Required")]
        public string? RefreshToken { get; set; }

    }
}
