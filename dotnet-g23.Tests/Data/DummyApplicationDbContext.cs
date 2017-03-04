using dotnet_g23.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Tests.Data {
    public class DummyApplicationDbContext {
        public GUser Preben { get; set; }
        public GUser Tuur { get; set; }
        public GUser Jasper { get; set; }
        public GUser Florian { get; set; }
        public ICollection<GUser> GUsers { get; set; }
        public ICollection<Organization> Organizations { get; set; }
        public Motivation Motivation { get; set; }

        private readonly ICollection<Group> _groups;

        public DummyApplicationDbContext() {
            Organization org1 = new Organization("HoGent", "Gent");
            Organization org2 = new Organization("Howest", "Kortrijk");
            Organization org3 = new Organization("Organization", "Gent");

            Organizations.Add(org1);
            Organizations.Add(org2);
            Organizations.Add(org3);

            Preben = new GUser("preben.leroy@hogent.be", new Participant(org1));
            Tuur = new GUser("tuur.lievens@organization.be", new Participant(org3));
            Florian = new GUser("florian.dejonckheere@hogent.be", new Lector());
            Jasper = new GUser("jasper.dhaene@organization.be", new Lector());

            GUsers.Add(Preben);
            GUsers.Add(Tuur);
            GUsers.Add(Florian);
            GUsers.Add(Jasper);

            _groups = new List<Group>();
            Group _openGroup = new Group("OpenGroup", false);
            Group _closedGroup = new Group("ClosedGroup");

            _groups.Add(_closedGroup);
            _groups.Add(_openGroup);

            String text1 = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed " +
                "doeiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enimad minim veniam";
            Motivation = new Motivation(text1);
        }
        public ICollection<Group> Groups => _groups;
    }
}

