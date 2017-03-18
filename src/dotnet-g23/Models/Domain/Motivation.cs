using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain {
    public class Motivation {
        #region Properties
        public int MotivationId { get; private set; }
        public Group Group { get; private set; }
        public int GroupForeignKey { get; private set; }

        public String MotivationText { get; set; }
        public Boolean Approved { get; set; }
        public String OrganizationName { get; set; }
        public String OrganizationAddress { get; set; }
        public String OrganizationWebsite { get; set; }
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