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

        public async Task InitializeData() {
            _context.Database.EnsureDeleted();
            if (_context.Database.EnsureCreated()) {

                Organization org1 = new Organization("HoGent", "Gent", "hogent.be");
                Organization org2 = new Organization("Howest", "Kortrijk", "howest.be");
                Organization org3 = new Organization("Organization", "Gent", "organization.be");
                Organization org4 = new Organization("HoGent", "Aalst", "hogent.be");

                _context.Organizations.Add(org1);
                _context.Organizations.Add(org2);
                _context.Organizations.Add(org3);
                _context.Organizations.Add(org4);

                GUser preben = new GUser("preben.leroy@hogent.be");
                GUser preben2 = new GUser("preben2.leroy@hogent.be", new Participant(org1));
                GUser tuur = new GUser("tuur.lievens@organization.be", new Participant(org3));
                GUser florian = new GUser("florian.dejonckheere@hogent.be", new Lector());
                GUser jasper = new GUser("jasper.dhaene@organization.be", new Lector());

                _context.GUsers.Add(preben);
                _context.GUsers.Add(preben2);
                _context.GUsers.Add(tuur);
                _context.GUsers.Add(florian);
                _context.GUsers.Add(jasper);

                ApplicationUser user1 = new ApplicationUser { UserName = preben.Email, Email = preben.Email };
                await _userManager.CreateAsync(user1, "P@ssword1");
                await _userManager.AddClaimAsync(user1, new Claim(ClaimTypes.Role, "participant"));

                ApplicationUser user1a = new ApplicationUser { UserName = preben2.Email, Email = preben2.Email };
                await _userManager.CreateAsync(user1a, "P@ssword1");
                await _userManager.AddClaimAsync(user1a, new Claim(ClaimTypes.Role, "participant"));

                ApplicationUser user2 = new ApplicationUser { UserName = tuur.Email, Email = tuur.Email };
                await _userManager.CreateAsync(user2, "P@ssword2");
                await _userManager.AddClaimAsync(user2, new Claim(ClaimTypes.Role, "participant"));

                ApplicationUser user3 = new ApplicationUser { UserName = florian.Email, Email = florian.Email };
                await _userManager.CreateAsync(user3, "P@ssword3");
                await _userManager.AddClaimAsync(user3, new Claim(ClaimTypes.Role, "lector"));

                ApplicationUser user4 = new ApplicationUser { UserName = jasper.Email, Email = jasper.Email };
                await _userManager.CreateAsync(user4, "P@ssword4");
                await _userManager.AddClaimAsync(user4, new Claim(ClaimTypes.Role, "lector"));

                string eMailAddress = "admin@giveaday.be";
                ApplicationUser user = new ApplicationUser { UserName = eMailAddress, Email = eMailAddress };
                await _userManager.CreateAsync(user, "P@ssword5");
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "admin"));

                Group openGroup1 = new Group("openGroup1", false);
                Group openGroup2 = new Group("openGroup2", false);
                Group openGroup3 = new Group("openGroup3", false);
                Group openGroup4 = new Group("openGroup4", false);

                Group closedGroup1 = new Group("closedGroup1", true);
                Group closedGroup2 = new Group("closedGroup2", true);
                Group closedGroup3 = new Group("closedGroup3", true);
                Group closedGroup4 = new Group("closedGroup4", true);

                //openGroup2.Participants.Add(tuur.UserState as Participant);
                //(tuur.UserState as Participant).Group = openGroup2;
                //openGroup2.Participants.Add(new GUser("persoon1@organization.be", new Participant(org3)).UserState as Participant);
                //openGroup2.Participants.Add(new GUser("persoon2@organization.be", new Participant(org3)).UserState as Participant);

                org3.CreateGroup((tuur.UserState as Participant), "openGroup2");
                openGroup2.Register(tuur.UserState as Participant);

                Motivation mot1 = new Motivation("Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec qu");


                Motivation mot2 = new Motivation("Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec qu");

                openGroup1.Motivation = mot1;
                openGroup3.Motivation = mot2;
                openGroup4.Motivation = mot1;

                closedGroup2.Motivation = mot1;
                closedGroup3.Motivation = mot2;
                closedGroup4.Motivation = mot1;

                _context.SaveChanges();
            }
        }
    }
}
