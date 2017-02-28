using System.ComponentModel.DataAnnotations;

namespace dotnet_g23.Models.ViewModels.ManageViewModels
{
    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Het {0} moet minstens {2} en maximaal {1} karakters lang zijn.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nieuw paswoord")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bevestig nieuw wachtwoord")]
        [Compare("NewPassword", ErrorMessage = "Het nieuwe en bevestig wachtwoord komen niet overeen.")]
        public string ConfirmPassword { get; set; }
    }
}