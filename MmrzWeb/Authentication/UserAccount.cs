using System.ComponentModel.DataAnnotations;

namespace MmrzWeb.Authentication
{
    public class UserAccount
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please Enter User Name")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
