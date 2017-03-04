using System.ComponentModel.DataAnnotations;

namespace dotnet_g23.Models.ViewModels.ManageViewModels
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Telefoonnummer")]
        public string PhoneNumber { get; set; }
    }
}