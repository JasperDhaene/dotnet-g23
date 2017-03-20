using dotnet_g23.Models;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Tests.Data {
    public class DummyApplicationDbContext {
        /**
         * GUser properties
         * 
         * */

        public GUser VolunteerHoGent { get; set; }
        public GUser ParticipantHogent { get; set; }
        public GUser OwnerHogent { get; set; }
        public GUser OwnerHogentSubmitted { get; set; }
        public GUser OwnerHogentApproved { get; set; }
        public GUser OwnerHogentGranted { get; set; }
        public GUser OwnerHogentAnnounced { get; set; }
        public ICollection<GUser> GUsers { get; set; }

        /**
         * Organization properties
         * 
         * */

        public Organization HogentGent { get; set; }
        public Organization HogentAalst { get; set; }
        public Organization HowestKortrijk { get; set; }
        public Organization HowestBrugge { get; set; }
        public Organization Ugent { get; set; }
        public ICollection<Organization> Organizations { get; set; }

        /**
         * Group properties
         * 
         * */

        public Group HogentGroup { get; set; }
        public Group HogentGroupSubmitted { get; set; }
        public Group HogentGroupApproved { get; set; }
        public Group HogentGroupGranted { get; set; }
        public Group HogentGroupAnnounced { get; set; }
        public ICollection<Group> Groups { get; set; }

        /**
         * Motivation properties
         * 
         * */

        public Motivation MotivationSubmitted { get; set; }
        public Motivation MotivationApproved { get; set; }
        public Motivation MotivationGranted { get; set; }
        public Motivation MotivationAnnounced { get; set; }
        public ICollection<Motivation> Motivations { get; set; }

        /**
         * Company properties
         * 
         * */

        public Company Company1 { get; set; }
        public Company Company2 { get; set; }
        public Company Company3 { get; set; }
        public ICollection<Company> Companies { get; set; }

        /**
         * Contact properties
         * 
         * */

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

        /**
         * Label properties
         * 
         * */

        public Label Label2 { get; set; }
        public Label Label3 { get; set; }
        public ICollection<Label> Labels { get; set; }

        public DummyApplicationDbContext() {

            /**
             * Organizations
             * 
             * */

            HogentGent = new Organization("HoGent", "Gent", "hogent.be");
            HogentAalst = new Organization("HoGent", "Aalst", "hogent.be");
            HowestKortrijk = new Organization("Howest", "Kortrijk", "howest.be");
            HowestBrugge = new Organization("Howest", "Brugge", "howest.be");
            Ugent = new Organization("UGent", "Gent", "ugent.be");

            Organizations = new List<Organization>();

            Organizations.Add(HogentGent);
            Organizations.Add(HogentAalst);
            Organizations.Add(HowestKortrijk);
            Organizations.Add(HowestBrugge);
            Organizations.Add(Ugent);

            /**
             * Users
             * 
             * */

            VolunteerHoGent = new GUser("volunteer@hogent.be");
            ParticipantHogent = new GUser("participant@hogent.be");
            OwnerHogent = new GUser("owner@hogent.be");
            OwnerHogentSubmitted = new GUser("owner_submitted@hogent.be");
            OwnerHogentApproved = new GUser("owner_approved@hogent.be");
            OwnerHogentGranted = new GUser("owner_granted@hogent.be");
            OwnerHogentAnnounced = new GUser("owner_announced@hogent.be");

            GUsers = new List<GUser>();

            GUsers.Add(VolunteerHoGent);
            GUsers.Add(ParticipantHogent);
            GUsers.Add(OwnerHogent);
            GUsers.Add(OwnerHogentSubmitted);
            GUsers.Add(OwnerHogentApproved);
            GUsers.Add(OwnerHogentGranted);
            GUsers.Add(OwnerHogentAnnounced);

            HogentGent.Register(ParticipantHogent);
            HogentGent.Register(OwnerHogent);
            HogentGent.Register(OwnerHogentSubmitted);
            HogentGent.Register(OwnerHogentApproved);
            HogentGent.Register(OwnerHogentGranted);
            HogentGent.Register(OwnerHogentAnnounced);

            /**
             * Groups
             * 
             * */

            Groups = new List<Group>();
            HogentGroup = HogentGent.CreateGroup(OwnerHogent.UserState as Participant, "HoGent Groep 1", false);
            HogentGroupSubmitted = HogentGent.CreateGroup(OwnerHogentSubmitted.UserState as Participant, "HoGent Groep 2", false);
            HogentGroupApproved = HogentGent.CreateGroup(OwnerHogentApproved.UserState as Participant, "HoGent Groep 3", false);
            HogentGroupGranted = HogentGent.CreateGroup(OwnerHogentGranted.UserState as Participant, "HoGent Groep 4", false);
            HogentGroupAnnounced = HogentGent.CreateGroup(OwnerHogentAnnounced.UserState as Participant, "HoGent Groep 5", false);

            Groups.Add(HogentGroup);
            Groups.Add(HogentGroupSubmitted);
            Groups.Add(HogentGroupApproved);
            Groups.Add(HogentGroupGranted);
            Groups.Add(HogentGroupAnnounced);

            /**
             * Motivations
             * 
             * */

            MotivationSubmitted = CreateMotivation(HogentGroupSubmitted, false);
            MotivationApproved = CreateMotivation(HogentGroupApproved, true);
            MotivationGranted = CreateMotivation(HogentGroupGranted, true);
            MotivationAnnounced = CreateMotivation(HogentGroupAnnounced, true);

            Motivations.Add(MotivationSubmitted);
            Motivations.Add(MotivationApproved);
            Motivations.Add(MotivationGranted);
            Motivations.Add(MotivationAnnounced);

            /**
             * Companies
             * 
             * */

            Company1 = new Company("Company 1", "This is company 1", "Address of company 1", "http://www.company1.com", "hello@company1.com");
            Company2 = new Company("Company 2", "This is company 2", "Address of company 2", "http://www.company2.com", "hello@company2.com");
            Company3 = new Company("Company 3", "This is company 3", "Address of company 3", "http://www.company3.com", "hello@company3.com");

            Companies.Add(Company1);
            Companies.Add(Company2);
            Companies.Add(Company3);

            /**
             * Contacts
             * 
             * */

            Contact1CEO = new Contact("Mr.", "John", "Doe", "CEO", "john.doe@company1.com", c1);
            Contact1CFO = new Contact("Mr.", "James", "Doe", "CFO", "james.doe@company1.com", c1);
            Contact1CTO = new Contact("Mrs.", "Jane", "Doe", "CTO", "jane.doe@company1.com", c1);

            Company1.Contacts.Add(Contact1CEO);
            Company1.Contacts.Add(Contact1CFO);
            Company1.Contacts.Add(Contact1CTO);

            Contacts.Add(Contact1CEO);
            Contacts.Add(Contact1CFO);
            Contacts.Add(Contact1CTO);

            Contact2CEO = new Contact("Mr.", "John", "Doe", "CEO", "john.doe@company2.com", c1);
            Contact2CFO = new Contact("Mr.", "James", "Doe", "CFO", "james.doe@company2.com", c1);
            Contact2CTO = new Contact("Mrs.", "Jane", "Doe", "CTO", "jane.doe@company2.com", c1);

            Company2.Contacts.Add(Contact2CEO);
            Company2.Contacts.Add(Contact2CFO);
            Company2.Contacts.Add(Contact2CTO);

            Contacts.Add(Contact2CEO);
            Contacts.Add(Contact2CFO);
            Contacts.Add(Contact2CTO);

            Contact3CEO = new Contact("Mr.", "John", "Doe", "CEO", "john.doe@company3.com", c1);
            Contact3CFO = new Contact("Mr.", "James", "Doe", "CFO", "james.doe@company3.com", c1);
            Contact3CTO = new Contact("Mrs.", "Jane", "Doe", "CTO", "jane.doe@company3.com", c1);

            Company3.Contacts.Add(Contact3CEO);
            Company3.Contacts.Add(Contact3CFO);
            Company3.Contacts.Add(Contact3CTO);

            Contacts.Add(Contact3CEO);
            Contacts.Add(Contact3CFO);
            Contacts.Add(Contact3CTO);

            /**
             * Labels
             * 
             * */

            Label2 = new Label(HogentGroupGranted, Company2);
            HogentGroupGranted.Context.CurrentState = new GrantedState();

            Label3 = new Label(HogentGroupAnnounced, Company2);
            HogentGroupAnnounced.Context.CurrentState = new AnnouncedState();

            Labels.Add(Label2);
            Labels.Add(Label3);
        }

        private Motivation CreateMotivation(Group group, Boolean approved = false) {
            Motivation m = new Motivation("Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed doeiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enimad minim veniam, qu");
            group.Motivation = m;
            m.Approved = approved;
            if (approved)
                group.Context.CurrentState = new ApprovedState();
            else
                group.Context.CurrentState = new SubmittedState();

            m.OrganizationName = "Organization Name";
            m.OrganizationAddress = "Organization Address";
            m.OrganizationWebsite = "http://www.myorganization.com";
            m.OrganizationEmail = "about@myorganization.com";

            return m;
        }
    }
}

