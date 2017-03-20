using dotnet_g23.Models;
using dotnet_g23.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Tests.Data {
    public class DummyApplicationDbContext {
        public GUser VolunteerHoGent { get; set; }
        public GUser ParticipantHogent { get; set; }
        public GUser OwnerHogent { get; set; }
        public GUser OwnerHogentSubmitted { get; set; }
        public GUser OwnerHogentApproved { get; set; }
        public GUser ownerHogentGranted { get; set; }
        public GUser ownerHogentAnnounced { get; set; }
        public ICollection<GUser> GUsers { get; set; }
        public Organization HogentGent { get; set; }
        public Organization HogentAalst { get; set; }
        public Organization HowestKortrijk { get; set; }
        public Organization HowestBrugge { get; set; }
        public Organization Ugent { get; set; }
        public ICollection<Organization> Organizations { get; set; }
        public Group HogentGroup { get; set; }
        public Group HogentGroupSubmitted { get; set; }
        public Group HogentGroupApproved { get; set; }
        public Group HogentGroupGranted { get; set; }
        public Group HogentGroupAnnounced { get; set; }
        public ICollection<Group> Groups { get; set; }
        public Motivation MotivationSubmitted { get; set; }
        public Motivation MotivationApproved { get; set; }
        public Motivation MotivationGranted { get; set; }
        public Motivation MotivationAnnounced { get; set; }
        public ICollection<Motivation> Motivations { get; set; }
        public Company Company1 { get; set; }
        public Company Company2 { get; set; }
        public Company Company3 { get; set; }
        public ICollection<Company> Companies { get; set; }
        public Contact Contact1CEO { get; set; }
        public Contact Contact1CFO { get; set; }
        public Contact Contact1CTO { get; set; }
        public Contact Contact2CEO { get; set; }
        public Contact Contact2CFO { get; set; }
        public Contact Contact2CTO { get; set; }
        public Contact Contact3CEO { get; set; }
        public Contact Contact3CFO { get; set; }
        public Contact Contact3CTO { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public Label Label2 { get; set; }
        public Label Label3 { get; set; }
        public ICollection<Label> Labels { get; set; }

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

            _openGroup.Register(Tuur.UserState as Participant);

            String text1 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. "
                    + "Aliquam at quam at eros volutpat elementum. Fusce suscipit mi sed sapien malesuada, quis consectetur arcu ullamcorper. ";
            Motivation = new Motivation(text1);

            _openGroup.Motivation = Motivation;

            _groups.Add(_closedGroup);
            _groups.Add(_openGroup);

        }
        public ICollection<Group> Groups => _groups;
    }
}

