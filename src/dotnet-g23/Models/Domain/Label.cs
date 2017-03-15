using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Models.Domain;

namespace dotnet_g23.Models
{
    public class Label
    {
        #region Properties
        public int LabelId { get; private set; }
        public Group Group { get; private set; }
        public int GroupForeignKey { get; private set; }
        public Company Company { get; private set; }
        public int CompanyForeignKey { get; private set; }
        #endregion

        #region Constructors

        public Label()
        {
        }
        public Label(Group group, Company company)
        {
            Group = group;
            Company = company;
        }
        #endregion
    }
}
