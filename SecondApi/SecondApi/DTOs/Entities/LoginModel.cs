using System.ComponentModel.DataAnnotations;

namespace SecondApi.DTOs.Entities {
    public class LoginModel {

        [Required(ErrorMessage = "Username is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }



    }
}
