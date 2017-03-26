using System.ComponentModel.DataAnnotations;

namespace dotnet_g23.Models.Domain
{
    public class Motivation
    {
        #region Properties

        public int MotivationId { get; private set; }
        public Group Group { get; set; }
        public int GroupForeignKey { get; private set; }

        [Required(ErrorMessage = "motivatie is vereist")]
        [MinLength(100, ErrorMessage = "motivatie moet langer dan 100 karakters zijn")]
        [MaxLength(250, ErrorMessage = "motivate mag niet langer dan 250 karakters zijn")]
        public string MotivationText { get; set; }

        public bool Approved { get; set; }

        [Required(ErrorMessage = "naam van organizatie is vereist")]
        public string OrganizationName { get; set; }

        [Required(ErrorMessage = "adres van organizatie is vereist")]
        public string OrganizationAddress { get; set; }

        [Required(ErrorMessage = "website van organizatie is vereist")]
        public string OrganizationWebsite { get; set; }

        [Required(ErrorMessage = "email van organizatie is vereist")]
        [DataType(DataType.EmailAddress, ErrorMessage = "email van organizatie moet een geldig emailadres zijn")]
        public string OrganizationEmail { get; set; }

        public string OrganizationContactTitle { get; set; }
        public string OrganizationContactFirstName { get; set; }
        public string OrganizationContactName { get; set; }
        public string OrganizationContactEmail { get; set; }

        #endregion

        #region Constructors

        public Motivation()
        {
        }

        public Motivation(string motivationText) : this()
        {
            MotivationText = motivationText;
            Approved = false;
        }

        #endregion
    }
}