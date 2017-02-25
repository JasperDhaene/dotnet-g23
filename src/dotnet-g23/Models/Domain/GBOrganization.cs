using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public class GBOrganization : Organization
    {
        #region Properties
        public ICollection<Group> Groups { get; set; }
        public ICollection<Participant> Participants { get; set; }
        public Organization Organization { get; set; }
        #endregion

        #region Constructors
        public GBOrganization(String name, String location): base(name, location)
        {
        }
        #endregion

        #region Methods
        public void CreateGroup(string name)
		{
			Groups.Add(new Group(name));
		}
		#endregion
	}
}
