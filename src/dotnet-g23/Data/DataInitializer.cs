using dotnet_g23.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using dotnet_g23.Models;
using dotnet_g23.Models.Domain.State;
using Action = dotnet_g23.Models.Domain.Action;

namespace dotnet_g23.Data {
    public class DataInitializer {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DataInitializer(ApplicationDbContext context, UserManager<ApplicationUser> userManager) {
            _context = context;
            _userManager = userManager;
        }

        public async Task InitializeData() {
            // Drop it like it's hot
            _context.Database.EnsureDeleted();

            // Build it like you're on the North Pole
            _context.Database.EnsureCreated();

            /**
             * Organizations
             * 
             * */
            Organization hogentGent = new Organization("HoGent", "Gent", "hogent.be");
            Organization hogentAalst = new Organization("HoGent", "Aalst", "hogent.be");
            Organization howestKortrijk = new Organization("HoWest", "Kortrijk", "howest.be");
            Organization howestBrugge = new Organization("HoWest", "Brugge", "howest.be");
            Organization ugent = new Organization("UGent", "Gent", "ugent.be");

            _context.Organizations.Add(hogentGent);
            _context.Organizations.Add(hogentAalst);
            _context.Organizations.Add(howestKortrijk);
            _context.Organizations.Add(howestBrugge);
            _context.Organizations.Add(ugent);

            /**
             * Users
             * 
             * */
            GUser volunteerHogent = new GUser("volunteer@hogent.be"); await CreateAppUser(volunteerHogent);
            GUser volunteerHowest = new GUser("volunteer@howest.be"); await CreateAppUser(volunteerHowest);
            GUser volunteerUgent = new GUser("volunteer@ugent.be"); await CreateAppUser(volunteerUgent);

            _context.GUsers.Add(volunteerHogent);
            _context.GUsers.Add(volunteerHowest);
            _context.GUsers.Add(volunteerUgent);

            GUser participantHogent = new GUser("participant@hogent.be"); await CreateAppUser(participantHogent);
            GUser participantHowest = new GUser("participant@howest.be"); await CreateAppUser(participantHowest);
            GUser participantUgent = new GUser("participant@ugent.be"); await CreateAppUser(participantUgent);

            _context.GUsers.Add(participantHogent);
            _context.GUsers.Add(participantHowest);
            _context.GUsers.Add(participantUgent);

            GUser lectorHogent = new GUser("lector@hogent.be", new Lector()); await CreateAppUser(lectorHogent);
            GUser lectorHowest = new GUser("lector@howest.be", new Lector()); await CreateAppUser(lectorHowest);
            GUser lectorUgent = new GUser("lector@ugent.be", new Lector()); await CreateAppUser(lectorUgent);

            _context.GUsers.Add(lectorHogent);
            _context.GUsers.Add(lectorHowest);
            _context.GUsers.Add(lectorUgent);

            hogentGent.Register(participantHogent);
            howestBrugge.Register(participantHowest);
            ugent.Register(participantUgent);

            GUser ownerHogent = new GUser("owner@hogent.be"); await CreateAppUser(ownerHogent);
            GUser ownerHogentSubmitted = new GUser("owner_submitted@hogent.be"); await CreateAppUser(ownerHogentSubmitted);
            GUser ownerHogentApproved = new GUser("owner_approved@hogent.be"); await CreateAppUser(ownerHogentApproved);
            GUser ownerHogentGranted = new GUser("owner_granted@hogent.be"); await CreateAppUser(ownerHogentGranted);
            GUser ownerHogentAnnounced = new GUser("owner_announced@hogent.be"); await CreateAppUser(ownerHogentAnnounced);

            _context.GUsers.Add(ownerHogent);
            _context.GUsers.Add(ownerHogentSubmitted);
            _context.GUsers.Add(ownerHogentApproved);
            _context.GUsers.Add(ownerHogentGranted);
            _context.GUsers.Add(ownerHogentAnnounced);

            hogentGent.Register(ownerHogent);
            hogentGent.Register(ownerHogentSubmitted);
            hogentGent.Register(ownerHogentApproved);
            hogentGent.Register(ownerHogentGranted);
            hogentGent.Register(ownerHogentAnnounced);

            /**
             * Groups
             * 
             * */
            Group hogentGroup = hogentGent.CreateGroup(ownerHogent.UserState as Participant, "HoGent Groep 1", false);
            Group hogentGroupSubmitted = hogentGent.CreateGroup(ownerHogentSubmitted.UserState as Participant, "HoGent Groep 2", false);
            Group hogentGroupApproved = hogentGent.CreateGroup(ownerHogentApproved.UserState as Participant, "HoGent Groep 3", false);
            Group hogentGroupGranted = hogentGent.CreateGroup(ownerHogentGranted.UserState as Participant, "HoGent Groep 4", false);
            Group hogentGroupAnnounced = hogentGent.CreateGroup(ownerHogentAnnounced.UserState as Participant, "HoGent Groep 5", false);

            _context.Groups.Add(hogentGroup);
            _context.Groups.Add(hogentGroupSubmitted);
            _context.Groups.Add(hogentGroupApproved);
            _context.Groups.Add(hogentGroupGranted);
            _context.Groups.Add(hogentGroupAnnounced);

            /**
             * Motivations
             * 
             * */

            Motivation motivationSubmitted = CreateMotivation(hogentGroupSubmitted, false);
            Motivation motivationApproved = CreateMotivation(hogentGroupApproved, true);
            Motivation motivationGranted = CreateMotivation(hogentGroupGranted, true);
            Motivation motivationAnnounced = CreateMotivation(hogentGroupAnnounced, true);

            _context.Motivations.Add(motivationSubmitted);
            _context.Motivations.Add(motivationApproved);
            _context.Motivations.Add(motivationGranted);
            _context.Motivations.Add(motivationAnnounced);
            
            /**
             * Companies
             * 
             * */
            Company c1 = new Company("Company 1", "This is company 1", "Address of company 1", "http://www.company1.com", "hello@company1.com");
            Company c2 = new Company("Company 2", "This is company 2", "Address of company 2", "http://www.company2.com", "hello@company2.com");
            Company c3 = new Company("Company 3", "This is company 3", "Address of company 3", "http://www.company3.com", "hello@company3.com");
            Company c4 = new Company("Company 4", "This is company 4", "Address of company 4", "http://www.company4.com", "hello@company4.com");
            Company c5 = new Company("Company 5", "This is company 5", "Address of company 5", "http://www.company5.com", "hello@company5.com");

            _context.Companies.Add(c1);
            _context.Companies.Add(c2);
            _context.Companies.Add(c3);
            _context.Companies.Add(c4);
            _context.Companies.Add(c5);

            /**
             * Contacts
             * 
             * */
            Contact c1Ceo = new Contact("Mr.", "John", "Doe", "CEO", "john.doe@company1.com", c1);
            Contact c1Cfo = new Contact("Mr.", "James", "Doe", "CFO", "james.doe@company1.com", c1);
            Contact c1Cto = new Contact("Mrs.", "Jane", "Doe", "CTO", "jane.doe@company1.com", c1);

            c1.Contacts.Add(c1Ceo);
            c1.Contacts.Add(c1Cfo);
            c1.Contacts.Add(c1Cto);

            _context.Contacts.Add(c1Ceo);
            _context.Contacts.Add(c1Cfo);
            _context.Contacts.Add(c1Cto);

            Contact c2Ceo = new Contact("Mr.", "John", "Doe", "CEO", "john.doe@company2.com", c2);
            Contact c2Cfo = new Contact("Mr.", "James", "Doe", "CFO", "james.doe@company2.com", c2);
            Contact c2Cto = new Contact("Mrs.", "Jane", "Doe", "CTO", "jane.doe@company2.com", c2);

            c2.Contacts.Add(c2Ceo);
            c2.Contacts.Add(c2Cfo);
            c2.Contacts.Add(c2Cto);

            _context.Contacts.Add(c2Ceo);
            _context.Contacts.Add(c2Cfo);
            _context.Contacts.Add(c2Cto);

            Contact c3Ceo = new Contact("Mr.", "John", "Doe", "CEO", "john.doe@company3.com", c3);
            Contact c3Cfo = new Contact("Mr.", "James", "Doe", "CFO", "james.doe@company3.com", c3);
            Contact c3Cto = new Contact("Mrs.", "Jane", "Doe", "CTO", "jane.doe@company3.com", c3);

            c3.Contacts.Add(c3Ceo);
            c3.Contacts.Add(c3Cfo);
            c3.Contacts.Add(c3Cto);

            _context.Contacts.Add(c3Ceo);
            _context.Contacts.Add(c3Cfo);
            _context.Contacts.Add(c3Cto);

            /**
             * Labels
             * 
             * */

            Label l2 = new Label(hogentGroupGranted, c2);
            hogentGroupGranted.Context.CurrentState = new GrantedState();
            _context.Labels.Add(l2);

            Label l3 = new Label(hogentGroupAnnounced, c3);
            hogentGroupAnnounced.Context.CurrentState = new AnnouncedState();
            _context.Labels.Add(l3);


            /**
             * Actions
             * 
             * */

            Action a1 = new Action(hogentGroupGranted, "Koekjes bakken","Koekjes bakken op grootmoeders wijze (kopen in den Aldi dus) en dan deur aan deur verkopen met veel winst");
            _context.Actions.Add(a1);

            Action a2 = new Action(hogentGroupAnnounced, "Koekjes bakken","Koekjes bakken op grootmoeders wijze (kopen in den Aldi dus) en dan deur aan deur verkopen met veel winst");
            _context.Actions.Add(a2);

            _context.SaveChanges();
        }

        private async Task CreateAppUser(GUser user) {
            ApplicationUser appUser = new ApplicationUser { UserName = user.Email, Email = user.Email };
            await _userManager.CreateAsync(appUser, "P@ssword1");
            await _userManager.AddClaimAsync(appUser, new Claim(ClaimTypes.Role, user.UserState is Lector ? "lector" : "participant"));
        }

        private Motivation CreateMotivation(Group group, Boolean approved = false)
        {
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
