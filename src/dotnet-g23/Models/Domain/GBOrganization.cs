﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public class GBOrganization : OrganizationRole
    {
        #region Properties
        public ICollection<Group> Groups { get; set; }
        public ICollection<Participant> Participants { get; set; }
		#endregion

		#region Methods
		public void CreateGroup(string name)
		{
			Group group = new Group(name);
			Groups.Add(group);
		}
		#endregion
	}
}
