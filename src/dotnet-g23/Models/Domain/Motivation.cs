using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public class Motivation
    {
        #region Fields
        private String _motivation;
        #endregion

        #region Properties
        public int MotivationId { get; private set; }
        public Group Group { get; private set; }
        public int GroupForeignKey { get; private set; }

        public String MotivationText
        {
            get { return _motivation;  }
            set
            {
                if (value.Length < 100 || value.Length > 250)
                    throw new ArgumentException("Motivatie moet tussen 100 en 250 karakters lang zijn");

                _motivation = value;
            }
        }
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

        public Motivation(String motivationText)
        {
            MotivationText = motivationText;
            Approved = false;
        }
        #endregion
    }
}
