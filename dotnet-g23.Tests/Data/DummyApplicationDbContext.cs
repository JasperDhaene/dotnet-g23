using dotnet_g23.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Tests.Data {
    public class DummyApplicationDbContext {
        public GUser Preben { get; set; }
        public GUser Preben2 { get; set; }
        public GUser Test { get; set; }
        public GUser Tuur { get; set; }
        public GUser Jasper { get; set; }
        public GUser Florian { get; set; }
        public ICollection<GUser> GUsers { get; set; }
        public ICollection<Organization> Organizations { get; set; }
        public ICollection<Organization> OrgsHogent { get; set; }
        public ICollection<Organization> OrgsHowest { get; set; }
        public ICollection<Organization> OrgsOrganization { get; set; }
        public Motivation Motivation { get; set; }
        public Organization org1 { get; set; }
        public Organization org2 { get; set; }
        public Organization org3 { get; set; }

        private readonly ICollection<Group> _groups;

        public DummyApplicationDbContext() {
            org1 = new Organization("HoGent", "Gent", "hogent.be");
            org2 = new Organization("Howest", "Kortrijk", "howest.be");
            org3 = new Organization("Organization", "Gent", "organization.be");

            Organizations = new List<Organization>();

            Organizations.Add(org1);
            Organizations.Add(org2);
            Organizations.Add(org3);

            OrgsHogent = new List<Organization>();
            OrgsHowest = new List<Organization>();
            OrgsOrganization = new List<Organization>();

            OrgsHogent.Add(org1);
            OrgsHowest.Add(org2);
            OrgsOrganization.Add(org3);

            Preben = new GUser("preben.leroy@hogent.be");
            Preben2 = new GUser("preben2.leroy@hogent.be", new Participant(org1));
            Test = new GUser("test.test@hogent.be", new Participant(org1));
            Tuur = new GUser("tuur.lievens@organization.be", new Participant(org3));
            Florian = new GUser("florian.dejonckheere@hogent.be", new Lector());
            Jasper = new GUser("jasper.dhaene@organization.be", new Lector());

            GUsers = new List<GUser>();

            GUsers.Add(Preben);
            GUsers.Add(Preben2);
            GUsers.Add(Tuur);
            GUsers.Add(Florian);
            GUsers.Add(Jasper);

            _groups = new List<Group>();
            Group _openGroup = new Group("OpenGroup", false);
            Group _closedGroup = new Group("ClosedGroup");

            _openGroup.Participants.Add(Preben2.UserState as Participant);

            _groups.Add(_closedGroup);
            _groups.Add(_openGroup);

            String text1 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. "
                    + "Aliquam at quam at eros volutpat elementum. Fusce suscipit mi sed sapien malesuada, quis consectetur arcu ullamcorper. ";
            Motivation = new Motivation(text1);
        }
        public ICollection<Group> Groups => _groups;
    }
}

