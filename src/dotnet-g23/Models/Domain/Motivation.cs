using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain {
    public class Motivation {
        #region Properties
        public int MotivationId { get; private set; }
        public Group Group { get; private set; }
        public int GroupForeignKey { get; private set; }

        [Required(ErrorMessage = "motivatie is vereist")]
        [MinLength(100)]
        [MaxLength(250)]
        public String MotivationText { get; set; }
        public Boolean Approved { get; set; }

        [Required(ErrorMessage = "naam van organizatie is vereist")]
        public String OrganizationName { get; set; }
        
        [Required(ErrorMessage = "adres van organizatie is vereist")]
        public String OrganizationAddress { get; set; }

        [Required(ErrorMessage = "website van organizatie is vereist")]
        [DataType(DataType.Url)]
        public String OrganizationWebsite { get; set; }

        [Required(ErrorMessage = "email van organizatie is vereist")]
        [DataType(DataType.EmailAddress)]
        public String OrganizationEmail { get; set; }

        public String OrganizationContactTitle { get; set; }
        public String OrganizationContactFirstName { get; set; }
        public String OrganizationContactName { get; set; }
        public String OrganizationContactEmail { get; set; }
        #endregion

        #region Constructors
        public Motivation()
        {
        }

        public Motivation(String motivationText) : this()
        {
            MotivationText = motivationText;
            Approved = false;
        }
        #endregion
    }
}