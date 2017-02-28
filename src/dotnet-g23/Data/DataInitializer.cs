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
                //await InitializeUsers();
                Organization org1 = new Organization("HoGent", "Gent");
                Organization org2 = new Organization("Howest", "Kortrijk");
                Organization org3 = new Organization("Organization", "Gent");

                _context.Organizations.Add(org1);
                _context.Organizations.Add(org2);
                _context.Organizations.Add(org3);

                GUser preben = new GUser("preben.leroy@hogent.be", new Participant(org1));
                GUser tuur = new GUser("tuur.lievens@organization.be", new Participant(org3));
                GUser florian = new GUser("florian.dejonckheere@hogent.be", new Lector());
                GUser jasper = new GUser("jasper.dhaene@organization.be", new Lector());

                _context.User.Add(preben);
                _context.User.Add(tuur);
                _context.User.Add(florian);
                _context.User.Add(jasper);

                ApplicationUser user1 = new ApplicationUser { UserName = preben.Email, Email = preben.Email };
                await _userManager.CreateAsync(user1, "P@ssword1");
                //await _userManager.AddClaimAsync(user1, new Claim(ClaimTypes.Role, "participant"));

                ApplicationUser user2 = new ApplicationUser { UserName = tuur.Email, Email = tuur.Email };
                await _userManager.CreateAsync(user2, "P@ssword2");
                //await _userManager.AddClaimAsync(user2, new Claim(ClaimTypes.Role, "participant"));

                ApplicationUser user3 = new ApplicationUser { UserName = florian.Email, Email = florian.Email };
                await _userManager.CreateAsync(user3, "P@ssword3");
                //await _userManager.AddClaimAsync(user3, new Claim(ClaimTypes.Role, "lector"));

                ApplicationUser user4 = new ApplicationUser { UserName = jasper.Email, Email = jasper.Email };
                await _userManager.CreateAsync(user4, "P@ssword4");
                //await _userManager.AddClaimAsync(user4, new Claim(ClaimTypes.Role, "lector"));

                string eMailAddress = "admin@giveaday.be";
                ApplicationUser user = new ApplicationUser { UserName = eMailAddress, Email = eMailAddress };
                await _userManager.CreateAsync(user, "P@ssword5");
                //await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "admin"));

                _context.SaveChanges();
            }
        }
    }
}

