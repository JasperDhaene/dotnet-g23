using dotnet_g23.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Tests.Data
{
    public class DummyApplicationDbContext
    {
        private readonly GADUser _userVolunteer;
        private readonly GADUser _userParticipant;
        private readonly GADUser _userLector;

        private readonly ICollection<GADUser> _users;

        private readonly Group _openGroup;
        private readonly Group _closedGroup;

        private readonly ICollection<Group> _groups;

        private readonly GADOrganization _gbOrganization;
        private readonly GADOrganization _organization;

        private readonly ICollection<GADOrganization> _organizations;

        public DummyApplicationDbContext()
        {
            _users = new List<GADUser>();
            _userVolunteer = new GADUser("volunteer@hogent.be", new Volunteer());
            _userParticipant = new GADUser("participant@hogent.be", new Participant());
            _userLector = new GADUser("lector@hogent.be", new Lector());

            _users.Add(_userVolunteer);
            _users.Add(_userParticipant);
            _users.Add(_userLector);

            _groups = new List<Group>();
            _openGroup = new Group("OpenGroup", false);
            _closedGroup = new Group("ClosedGroup");

            _groups.Add(_openGroup);
            _groups.Add(_closedGroup);

            _organizations = new List<GADOrganization>();
            _gbOrganization = new GADOrganization("GBOrg", "Gent", new GBOrganization());
            _organization = new GADOrganization("Org", "Gent", new Organization());

            _organizations.Add(_gbOrganization);
            _organizations.Add(_organization);
        }

        public IEnumerable<GADOrganization> Organizations => _organizations;

        public IEnumerable<GADUser> Users => _users;

        public IEnumerable<Group> Groups => _groups;
    }
}
