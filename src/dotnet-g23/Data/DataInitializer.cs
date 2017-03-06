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
                Organization org2 = new Organization("Howest", "Kortrijk","howest.be");
                Organization org3 = new Organization("Organization", "Gent","organization.be");
                Organization org4 = new Organization("HoGent", "Aalst", "hogent.be");

                _context.Organizations.Add(org1);
                _context.Organizations.Add(org2);
                _context.Organizations.Add(org3);
                _context.Organizations.Add(org4);

                GUser preben = new GUser("preben.leroy@hogent.be");
                GUser tuur = new GUser("tuur.lievens@organization.be", new Participant(org3));
                GUser florian = new GUser("florian.dejonckheere@hogent.be", new Lector());
                GUser jasper = new GUser("jasper.dhaene@organization.be", new Lector());

                _context.GUsers.Add(preben);
                _context.GUsers.Add(tuur);
                _context.GUsers.Add(florian);
                _context.GUsers.Add(jasper);

                Group openGroup1 = new Group("openGroup1", false);
                Group openGroup2 = new Group("openGroup2", false);
                Group openGroup3 = new Group("openGroup3", false);
                Group openGroup4 = new Group("openGroup4", false);

                Group closedGroup1 = new Group("closedGroup1");
                Group closedGroup2 = new Group("closedGroup2");
                Group closedGroup3 = new Group("closedGroup3");
                Group closedGroup4 = new Group("closedGroup4");

                openGroup2.Participants.Add(tuur.UserState as Participant);
                openGroup2.Participants.Add(new GUser("persoon1@organization.be", new Participant(org3)).UserState as Participant);
                openGroup2.Participants.Add(new GUser("persoon2@organization.be", new Participant(org3)).UserState as Participant);

                Motivation mot1 = new Motivation("Lorem ipsum dolor sit amet, consectetur adipiscing elit. "
                    + "Aliquam at quam at eros volutpat elementum. Fusce suscipit mi sed sapien malesuada, quis consectetur arcu ullamcorper. "
                    + "Pellentesque eleifend sapien at turpis pulvinar, quis finibus mi sodales. Ut porttitor pharetra ante. Pellentesque eu arcu est. "
                    + "Mauris finibus porta tellus et posuere. Nam feugiat vitae enim at sagittis. Duis sodales varius ipsum vitae maximus. "
                    + "Nullam est purus, tempor in nisl aliquet, congue aliquam neque. Vestibulum sit amet neque non nunc eleifend feugiat. "
                    + "Nullam sed eleifend libero. Aliquam vitae ornare lorem. Mauris pellentesque lacus a arcu pulvinar, quis laoreet massa maximus. Praesent vestibulum elit.");


                Motivation mot2 = new Motivation("Lorem ipsum dolor sit amet, consectetur adipiscing elit. "
                    + "Aliquam at quam at eros volutpat elementum. Fusce suscipit mi sed sapien malesuada, quis consectetur arcu ullamcorper. "
                    + "Pellentesque eleifend sapien at turpis pulvinar, quis finibus mi sodales. Ut porttitor pharetra ante. Pellentesque eu arcu est. "
                    + "Mauris finibus porta tellus et posuere. Nam feugiat vitae enim at sagittis. Duis sodales varius ipsum vitae maximus. "
                    + "Nullam est purus, tempor in nisl aliquet, congue aliquam neque. Vestibulum sit amet neque non nunc eleifend feugiat. "
                    + "Nullam sed eleifend libero. Aliquam vitae ornare lorem. Mauris pellentesque lacus a arcu pulvinar, quis laoreet massa maximus. Praesent vestibulum elit.");

                mot1.Approved = false;

                mot2.Approved = true;

                openGroup1.Motivation = mot1;
                openGroup3.Motivation = mot2;
                openGroup4.Motivation = mot1;

                closedGroup2.Motivation = mot1;
                closedGroup3.Motivation = mot2;
                closedGroup4.Motivation = mot1;

                _context.Groups.Add(openGroup1);
                _context.Groups.Add(openGroup2);
                _context.Groups.Add(openGroup3);
                _context.Groups.Add(openGroup4);

                _context.Groups.Add(closedGroup1);
                _context.Groups.Add(closedGroup2);
                _context.Groups.Add(closedGroup3);
                _context.Groups.Add(closedGroup4);

                _context.Motivations.Add(mot1);
                _context.Motivations.Add(mot2);

                ApplicationUser user1 = new ApplicationUser { UserName = preben.Email, Email = preben.Email };
                await _userManager.CreateAsync(user1, "P@ssword1");
                await _userManager.AddClaimAsync(user1, new Claim(ClaimTypes.Role, "participant"));

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

                _context.SaveChanges();
            }
        }
    }
}

