using System.ComponentModel.DataAnnotations;

namespace dotnet_g23.Models.ViewModels.AccountViewModels
{
    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        public string Code { get; set; }

        public string ReturnUrl { get; set; }

        [Display(Name = "Onthou dit browser?")]
        public bool RememberBrowser { get; set; }

        [Display(Name = "Onthou mij?")]
        public bool RememberMe { get; set; }
    }
}