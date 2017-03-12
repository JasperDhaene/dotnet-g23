using dotnet_g23.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace dotnet_g23.Data {
    public class DataInitializer {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DataInitializer(ApplicationDbContext context, UserManager<ApplicationUser> userManager) {
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

            GUser ownerHogent1 = new GUser("owner1@hogent.be"); await CreateAppUser(ownerHogent1);
            GUser ownerHogent2 = new GUser("owner2@hogent.be"); await CreateAppUser(ownerHogent2);

            _context.GUsers.Add(ownerHogent1);
            _context.GUsers.Add(ownerHogent2);

            hogentGent.Register(ownerHogent1);
            hogentGent.Register(ownerHogent2);

            /**
             * Groups
             * 
             * */
            Group hogentGroup1 = hogentGent.CreateGroup(ownerHogent1.UserState as Participant, "HoGent Groep 1");
            Group hogentGroup2 = hogentGent.CreateGroup(ownerHogent2.UserState as Participant, "HoGent Groep 2");




            _context.SaveChanges();
        }

        private async Task CreateAppUser(GUser user)
        {
            ApplicationUser appUser = new ApplicationUser { UserName = user.Email, Email = user.Email };
            await _userManager.CreateAsync(appUser, "P@ssword1");
            await _userManager.AddClaimAsync(appUser, new Claim(ClaimTypes.Role, user.UserState is Lector ? "lector" : "participant"));
        }
    }
}

