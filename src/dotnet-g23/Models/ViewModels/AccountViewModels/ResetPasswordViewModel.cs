using System.ComponentModel.DataAnnotations;

namespace dotnet_g23.Models.ViewModels.AccountViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "De {0} moet minstens {2} en maximaal {1} karakters lang zijn.",
             MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Paswoord en bevestig paswoord komen niet overeen.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}