using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.State;
using Microsoft.AspNetCore.Identity;

namespace dotnet_g23.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DataInitializer(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            // Drop it like it's hot
            _context.Database.EnsureDeleted();

            // Build it like you're on the North Pole
            _context.Database.EnsureCreated();

            /**
             * Organizations
             * 
             * */
            var hogentGent = new Organization("HoGent", "Gent", "hogent.be");
            var hogentAalst = new Organization("HoGent", "Aalst", "hogent.be");
            var howestKortrijk = new Organization("HoWest", "Kortrijk", "howest.be");
            var howestBrugge = new Organization("HoWest", "Brugge", "howest.be");
            var ugent = new Organization("UGent", "Gent", "ugent.be");

            _context.Organizations.Add(hogentGent);
            _context.Organizations.Add(hogentAalst);
            _context.Organizations.Add(howestKortrijk);
            _context.Organizations.Add(howestBrugge);
            _context.Organizations.Add(ugent);

            /**
             * Users
             * 
             * */
            var volunteerHogent = new GUser("volunteer@hogent.be");
            await CreateAppUser(volunteerHogent);
            var volunteerHowest = new GUser("volunteer@howest.be");
            await CreateAppUser(volunteerHowest);
            var volunteerUgent = new GUser("volunteer@ugent.be");
            await CreateAppUser(volunteerUgent);

            _context.GUsers.Add(volunteerHogent);
            _context.GUsers.Add(volunteerHowest);
            _context.GUsers.Add(volunteerUgent);

            var participantHogent = new GUser("participant@hogent.be");
            var participantHowest = new GUser("participant@howest.be");
            var participantUgent = new GUser("participant@ugent.be");

            _context.GUsers.Add(participantHogent);
            _context.GUsers.Add(participantHowest);
            _context.GUsers.Add(participantUgent);

            var lectorHogent = new GUser("lector@hogent.be", new Lector());
            await CreateAppUser(lectorHogent);
            var lectorHowest = new GUser("lector@howest.be", new Lector());
            await CreateAppUser(lectorHowest);
            var lectorUgent = new GUser("lector@ugent.be", new Lector());
            await CreateAppUser(lectorUgent);

            _context.GUsers.Add(lectorHogent);
            _context.GUsers.Add(lectorHowest);
            _context.GUsers.Add(lectorUgent);

            hogentGent.Register(participantHogent);
            howestBrugge.Register(participantHowest);
            ugent.Register(participantUgent);

            var ownerHogent = new GUser("owner@hogent.be");
            var ownerHogentSubmitted = new GUser("owner_submitted@hogent.be");
            var ownerHogentApproved = new GUser("owner_approved@hogent.be");
            var ownerHogentGranted = new GUser("owner_granted@hogent.be");
            var ownerHogentAnnounced = new GUser("owner_announced@hogent.be");

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

            //register participants after link with GB organization
            await CreateAppUser(participantHogent);
            await CreateAppUser(participantHowest);
            await CreateAppUser(participantUgent);

            await CreateAppUser(ownerHogent);
            await CreateAppUser(ownerHogentSubmitted);
            await CreateAppUser(ownerHogentApproved);
            await CreateAppUser(ownerHogentGranted);
            await CreateAppUser(ownerHogentAnnounced);

            /**
             * Groups
             * 
             * */
            var hogentGroup = hogentGent.CreateGroup(ownerHogent.UserState as Participant, "HoGent Groep 1", false);
            var hogentGroupSubmitted = hogentGent.CreateGroup(ownerHogentSubmitted.UserState as Participant,
                "HoGent Groep 2", false);
            var hogentGroupApproved = hogentGent.CreateGroup(ownerHogentApproved.UserState as Participant,
                "HoGent Groep 3", false);
            var hogentGroupGranted = hogentGent.CreateGroup(ownerHogentGranted.UserState as Participant,
                "HoGent Groep 4", false);
            var hogentGroupAnnounced = hogentGent.CreateGroup(ownerHogentAnnounced.UserState as Participant,
                "HoGent Groep 5", false);

            _context.Groups.Add(hogentGroup);
            _context.Groups.Add(hogentGroupSubmitted);
            _context.Groups.Add(hogentGroupApproved);
            _context.Groups.Add(hogentGroupGranted);
            _context.Groups.Add(hogentGroupAnnounced);

            /**
             * Motivations
             * 
             * */

            var motivationSubmitted = CreateMotivation(hogentGroupSubmitted, false);
            var motivationApproved = CreateMotivation(hogentGroupApproved, true);
            var motivationGranted = CreateMotivation(hogentGroupGranted, true);
            var motivationAnnounced = CreateMotivation(hogentGroupAnnounced, true);

            _context.Motivations.Add(motivationSubmitted);
            _context.Motivations.Add(motivationApproved);
            _context.Motivations.Add(motivationGranted);
            _context.Motivations.Add(motivationAnnounced);

            /**
             * Companies
             * 
             * */
            var c1 = new Company("OCMW Brugge WZC Van Zuylen",
                "Woon en zorgcentrum geef een thuis aan 127 bewoners",
                "Geralaan 50, 8310 St. Kruis, Brugge",
                "https://www.ocmw-brugge.be/",
                "ocmw.brugge@outlook.com", File.ReadAllBytes("wwwroot/logo_ocmwbrugge.png"));
            var c2 = new Company("Vonk Vzw",
                "Vrijwilligerswerk met ‘net dat ietsje meer’ Vonk! vzw is de vrijwilligerswerking van vzw Kompas." +
                "Kompas biedt aan mensen met een beperking ondersteuning binnen 3 domeinen: wonen, arbeidszorg en activiteiten. " +
                " We luisteren graag naar jouw interesses en bekijken samen binnen welke deelwerking je aan de slag gaat.",
                "Beekstraat 1, 9030 Mariakerke",
                "http://www.vonkvzw.be/",
                "vonkvzw@outlook.com", File.ReadAllBytes("wwwroot/logo_vonk.png"));
            var c3 = new Company("CM Oppas Aan Huis Antwerpen",
                "CM ondersteunt mensen die thuis een langdurige zieke, een hulpbehoevende bejaarde of een persoon met een handicap verzorgen in heel Vlaanderen.",
                "Molenbergstraat 2, 2000 Antwerpen",
                "http://www.cm.be",
                "cm.antwerpen@outlook.com", File.ReadAllBytes("wwwroot/logo_cm.png"));
            var c4 = new Company("Le Crayon Taalkampen Vzw",
                "“Le Crayon” is een landelijk erkende jeugdvereniging, die reeds jaren taalkampen organiseert in combinatie met recreatieve, culturele en/of actieve activiteiten.",
                "Nieuwenhuyse 86, 8520 Kuurne",
                "http://www.lecrayon.be",
                "lecrayon@outlook.com", File.ReadAllBytes("wwwroot/logo_crayon.jpg"));
            var c5 = new Company("Dansschool EMOTION Gent",
                "We hebben lessen voor kleuters vanaf 3 jaar tot 65+ in Gent. Voor elk wat wils, als je van dansen en plezier houdt, ben je bij ons aan het goede adres.",
                "Nederwijk 158, 9400 Ninove",
                "http://www.dansschoolemotion.be/",
                "emotion@outlook.com", File.ReadAllBytes("wwwroot/logo_emotion.png"));

            _context.Companies.Add(c1);
            _context.Companies.Add(c2);
            _context.Companies.Add(c3);
            _context.Companies.Add(c4);
            _context.Companies.Add(c5);

            /**
             * Contacts
             * 
             * */
            var c1Ceo = new Contact("Mr.", "John", "Doe", "CEO", "goedbezig-g23@outlook.com", c1);
            var c1Cfo = new Contact("Mr.", "James", "Doe", "CFO", "goedbezig-g23@outlook.com", c1);
            var c1Cto = new Contact("Mrs.", "Jane", "Doe", "CTO", "goedbezig-g23@outlook.com", c1);

            c1.Contacts.Add(c1Ceo);
            c1.Contacts.Add(c1Cfo);
            c1.Contacts.Add(c1Cto);

            _context.Contacts.Add(c1Ceo);
            _context.Contacts.Add(c1Cfo);
            _context.Contacts.Add(c1Cto);

            var c2Ceo = new Contact("Mr.", "John", "Doe", "CEO", "goedbezig-g23@outlook.com", c2);
            var c2Cfo = new Contact("Mr.", "James", "Doe", "CFO", "goedbezig-g23@outlook.com", c2);
            var c2Cto = new Contact("Mrs.", "Jane", "Doe", "CTO", "goedbezig-g23@outlook.com", c2);

            c2.Contacts.Add(c2Ceo);
            c2.Contacts.Add(c2Cfo);
            c2.Contacts.Add(c2Cto);

            _context.Contacts.Add(c2Ceo);
            _context.Contacts.Add(c2Cfo);
            _context.Contacts.Add(c2Cto);

            var c3Ceo = new Contact("Mr.", "John", "Doe", "CEO", "goedbezig-g23@outlook.com", c3);
            var c3Cfo = new Contact("Mr.", "James", "Doe", "CFO", "goedbezig-g23@outlook.com", c3);
            var c3Cto = new Contact("Mrs.", "Jane", "Doe", "CTO", "goedbezig-g23@outlook.com", c3);

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

            hogentGroupGranted.Grant(c2);
            _context.Labels.Add(hogentGroupGranted.Label);

            hogentGroupAnnounced.Grant(c3);
            _context.Labels.Add(hogentGroupAnnounced.Label);

            /**
             * Posts
             * 
             * */

            var p3 =
                hogentGroupAnnounced.Announce(
                    "Dit Goed Bezig-label wordt toegekend aan de CM Antwerpen vanwege een voortdurende inzet en maatschappelijke verantwoordelijkheid.");

            _context.Posts.Add(p3);


            /**
             * Actions
             * 
             * */

            var a1 = new Action(hogentGroupGranted, "Koekjes bakken",
                "Koekjes bakken op grootmoeders wijze. Verkopen aan familie en vrienden en van deur tot deur in de omgeving");
            _context.Actions.Add(a1);

            var a2 = new Action(hogentGroupAnnounced, "Koekjes bakken",
                "Koekjes bakken op grootmoeders wijze. Verkopen aan familie en vrienden en van deur tot deur in de omgeving");
            _context.Actions.Add(a2);

            _context.SaveChanges();
        }

        private async Task CreateAppUser(GUser user)
        {
            var appUser = new ApplicationUser {UserName = user.Email, Email = user.Email};
            await _userManager.CreateAsync(appUser, "P@ssword1");
            await
                _userManager.AddClaimAsync(appUser,
                    new Claim(ClaimTypes.Role,
                        user.UserState is Lector
                            ? "lector"
                            : (user.UserState is Participant ? "participant" : "volunteer")));
        }

        private Motivation CreateMotivation(Group group, bool approved = false)
        {
            var m =
                new Motivation(
                    "Deze organisatie helpt enorm veel mensen. We zijn enorm blij met al het werk dat ze leveren en willen hun hiermee een hart onder de riem steken.");
            group.Motivation = m;
            m.Approved = approved;
            if (approved)
                group.Context.CurrentState = new ApprovedState();
            else
                group.Context.CurrentState = new SubmittedState();

            m.OrganizationName = "OCMW Brugge WZC Van Zuylen";
            m.OrganizationAddress = "Geralaan 50, 8310 St. Kruis, Brugge";
            m.OrganizationWebsite = "https://www.ocmw-brugge.be/";
            m.OrganizationEmail = "ocmw.brugge@outlook.com";

            return m;
        }
    }
}