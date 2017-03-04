using System.ComponentModel.DataAnnotations;

namespace dotnet_g23.Models.ViewModels.ManageViewModels
{
    public class VerifyPhoneNumberViewModel
    {
        [Required]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Telefoonnummer")]
        public string PhoneNumber { get; set; }
    }
}