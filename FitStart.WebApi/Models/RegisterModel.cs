using System.ComponentModel.DataAnnotations;

namespace FitStart.WebApi.Models
{
    public class RegisterModel
    {
        [Required]
        public string Email { get; set; }


        [Required]
        public string Login { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


        [Required]
        public int Role { get; set; }
    }
}
