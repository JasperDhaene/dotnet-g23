//using dotnet_g23.Models.Domain;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace dotnet_g23.Tests.Data
//{
//    public class DummyApplicationDbContext
//    {
//        private readonly User _userParticipant;
//        private readonly User _userLector;

//        private readonly ICollection<User> _users;

//        private readonly Group _openGroup;
//        private readonly Group _closedGroup;

//        private readonly ICollection<Group> _groups;

//        private readonly Organization _gbOrganization;
//        private readonly Organization _organization;

//        private readonly ICollection<Organization> _organizations;

//        public DummyApplicationDbContext()
//        {
//            _users = new List<User>();
//            _userParticipant = new User("participant@hogent.be", new Participant(null));
//            _userLector = new User("lector@hogent.be", new Lector());

//            _users.Add(_userParticipant);
//            _users.Add(_userLector);

//            _groups = new List<Group>();
//            _openGroup = new Group("OpenGroup", false);
//            _closedGroup = new Group("ClosedGroup");

//            _groups.Add(_openGroup);
//            _groups.Add(_closedGroup);

//            _organizations = new List<Organization>();
//            _gbOrganization = new Organization("GBOrg", "Gent");
//            _organization = new Organization("Org", "Gent");

//            _organizations.Add(_gbOrganization);
//            _organizations.Add(_organization);
//        }

//        public IEnumerable<Organization> Organizations => _organizations;

//        public IEnumerable<User> Users => _users;

//        public IEnumerable<Group> Groups => _groups;
//    }
//}
