using System.ComponentModel.DataAnnotations;

namespace Identity.API.Models.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        public string Email { get; set; }
    }
}
