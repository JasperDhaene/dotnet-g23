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

        public ICollection<GUser> GUsers { get; set; }
        public GUser VolunteerHoGent { get; set; }
        public GUser ParticipantHogent { get; set; }
        public GUser OwnerHogent { get; set; }
        public GUser OwnerHogentSubmitted { get; set; }
        public GUser OwnerHogentApproved { get; set; }
        public GUser OwnerHogentGranted { get; set; }
        public GUser OwnerHogentAnnounced { get; set; }

        /**
         * List of participants
         * 
         * */

        public ICollection<Participant> Participants { get; set; }

        /**
         * Organization properties
         * 
         * */

        public ICollection<Organization> Organizations { get; set; }
        public Organization HogentGent { get; set; }
        public Organization HogentAalst { get; set; }
        public Organization HowestKortrijk { get; set; }
        public Organization HowestBrugge { get; set; }
        public Organization Ugent { get; set; }

        /**
         * Group properties
         * 
         * */

        public ICollection<Group> Groups { get; set; }
        public Group HogentGroup { get; set; }
        public Group HogentGroupSubmitted { get; set; }
        public Group HogentGroupApproved { get; set; }
        public Group HogentGroupGranted { get; set; }
        public Group HogentGroupAnnounced { get; set; }

        /**
         * Motivation properties
         * 
         * */

        public ICollection<Motivation> Motivations { get; set; }
        public Motivation MotivationSubmitted { get; set; }
        public Motivation MotivationApproved { get; set; }
        public Motivation MotivationGranted { get; set; }
        public Motivation MotivationAnnounced { get; set; }

        /**
         * Company properties
         * 
         * */

        public ICollection<Company> Companies { get; set; }
        public Company Company1 { get; set; }
        public Company Company2 { get; set; }
        public Company Company3 { get; set; }

        /**
         * Contact properties
         * 
         * */

        public ICollection<Contact> Contacts { get; set; }
        public Contact Contact1CEO { get; set; }
        public Contact Contact1CFO { get; set; }
        public Contact Contact1CTO { get; set; }
        public Contact Contact2CEO { get; set; }
        public Contact Contact2CFO { get; set; }
        public Contact Contact2CTO { get; set; }
        public Contact Contact3CEO { get; set; }
        public Contact Contact3CFO { get; set; }
        public Contact Contact3CTO { get; set; }

        /**
         * Label properties
         * 
         * */

        public ICollection<Label> Labels { get; set; }
        public Label Label2 { get; set; }
        public Label Label3 { get; set; }

        /**
         * Post properties
         * 
         * */

        public ICollection<Post> Posts { get; set; }
        public Post Post3 { get; set; }

        /**
         * Action properties
         * 
         * */

        public ICollection<dotnet_g23.Models.Domain.Action> Actions { get; set; }
        public dotnet_g23.Models.Domain.Action Action1 { get; set; }
        public dotnet_g23.Models.Domain.Action Action2 { get; set; }

        public DummyApplicationDbContext() {

            /**
             * Organizations
             * 
             * */

            Organizations = new List<Organization>();

            HogentGent = new Organization("HoGent", "Gent", "hogent.be");
            HogentAalst = new Organization("HoGent", "Aalst", "hogent.be");
            HowestKortrijk = new Organization("Howest", "Kortrijk", "howest.be");
            HowestBrugge = new Organization("Howest", "Brugge", "howest.be");
            Ugent = new Organization("UGent", "Gent", "ugent.be");

            Organizations.Add(HogentGent);
            Organizations.Add(HogentAalst);
            Organizations.Add(HowestKortrijk);
            Organizations.Add(HowestBrugge);
            Organizations.Add(Ugent);

            /**
             * Users
             * 
             * */

            GUsers = new List<GUser>();

            VolunteerHoGent = new GUser("volunteer@hogent.be");
            ParticipantHogent = new GUser("participant@hogent.be");
            OwnerHogent = new GUser("owner@hogent.be");
            OwnerHogentSubmitted = new GUser("owner_submitted@hogent.be");
            OwnerHogentApproved = new GUser("owner_approved@hogent.be");
            OwnerHogentGranted = new GUser("owner_granted@hogent.be");
            OwnerHogentAnnounced = new GUser("owner_announced@hogent.be");

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

            Participants = new List<Participant>();
            Participants.Add(ParticipantHogent.UserState as Participant);
            Participants.Add(OwnerHogent.UserState as Participant);
            Participants.Add(OwnerHogentSubmitted.UserState as Participant);
            Participants.Add(OwnerHogentApproved.UserState as Participant);
            Participants.Add(OwnerHogentGranted.UserState as Participant);
            Participants.Add(OwnerHogentAnnounced.UserState as Participant);

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

            Motivations = new List<Motivation>();

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

            Companies = new List<Company>();

            Company1 = new Company("Company 1", "This is company 1", "Address of company 1", "http://www.company1.com", "hello@company1.com", new byte[] {0x20, 0x20, 0x20});
            Company2 = new Company("Company 2", "This is company 2", "Address of company 2", "http://www.company2.com", "hello@company2.com", new byte[] { 0x20, 0x20, 0x20 });
            Company3 = new Company("Company 3", "This is company 3", "Address of company 3", "http://www.company3.com", "hello@company3.com", new byte[] { 0x20, 0x20, 0x20 });

            Companies.Add(Company1);
            Companies.Add(Company2);
            Companies.Add(Company3);

            /**
             * Contacts
             * 
             * */

            Contacts = new List<Contact>();

            Contact1CEO = new Contact("Mr.", "John", "Doe", "CEO", "john.doe@company1.com", Company1);
            Contact1CFO = new Contact("Mr.", "James", "Doe", "CFO", "james.doe@company1.com", Company1);
            Contact1CTO = new Contact("Mrs.", "Jane", "Doe", "CTO", "jane.doe@company1.com", Company1);

            Company1.Contacts.Add(Contact1CEO);
            Company1.Contacts.Add(Contact1CFO);
            Company1.Contacts.Add(Contact1CTO);

            Contacts.Add(Contact1CEO);
            Contacts.Add(Contact1CFO);
            Contacts.Add(Contact1CTO);

            Contact2CEO = new Contact("Mr.", "John", "Doe", "CEO", "john.doe@company2.com", Company2);
            Contact2CFO = new Contact("Mr.", "James", "Doe", "CFO", "james.doe@company2.com", Company2);
            Contact2CTO = new Contact("Mrs.", "Jane", "Doe", "CTO", "jane.doe@company2.com", Company2);

            Company2.Contacts.Add(Contact2CEO);
            Company2.Contacts.Add(Contact2CFO);
            Company2.Contacts.Add(Contact2CTO);

            Contacts.Add(Contact2CEO);
            Contacts.Add(Contact2CFO);
            Contacts.Add(Contact2CTO);

            Contact3CEO = new Contact("Mr.", "John", "Doe", "CEO", "john.doe@company3.com", Company3);
            Contact3CFO = new Contact("Mr.", "James", "Doe", "CFO", "james.doe@company3.com", Company3);
            Contact3CTO = new Contact("Mrs.", "Jane", "Doe", "CTO", "jane.doe@company3.com", Company3);

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

            Labels = new List<Label>();

            HogentGroupGranted.Grant(Company2);
            HogentGroupAnnounced.Grant(Company3);

            Labels.Add(HogentGroupGranted.Label);
            Labels.Add(HogentGroupAnnounced.Label);

            /**
             * Posts
             * 
             * */

            Posts = new List<Post>();

            Post3 = HogentGroupAnnounced.Announce("Dit Goed Bezig-label wordt toegekend aan Company 3 vanwege een voortdurende inzet en maatschappelijke verantwoordelijkheid.");

            Posts.Add(Post3);

            /**
             * Actions
             * 
             * */

            Actions = new List<dotnet_g23.Models.Domain.Action>();

            Action1 = new dotnet_g23.Models.Domain.Action(HogentGroupGranted, "Action1", "Dit is een actie tvv Goed Bezig!");
            Action2 = new dotnet_g23.Models.Domain.Action(HogentGroupAnnounced, "Action2", "Dit is een actie tvv Goed Bezig!");

            Actions.Add(Action1);
            Actions.Add(Action2);
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

