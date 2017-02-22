using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using dotnet_g23.Models.Domain;

namespace dotnet_g23.Data.Repositories
{
    public class GADUserRepository : IGADUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<GADUser> _gadUsers;

        public GADUserRepository(ApplicationDbContext context)
        {
            _context = context;
            _gadUsers = context.GADUsers;
        }

        public IEnumerable<GADUser> GetAll()
        {
            //Cannot open database "DotNetG23" requested by the login. The login failed.
            //Login failed for user 'Jasper-PC\Jasper'.
            return _gadUsers.Include(u => u.UserRole).ToList();
        }

        public GADUser GetBy(int userId)
        {
            return _gadUsers.Include(u => u.UserRole)
                            .SingleOrDefault(u => u.UserId == userId);
        }

        public GADUser GetByEmail(string userEmail)
        {
            return _gadUsers.Include(u => u.UserRole)
                            .SingleOrDefault(u => u.Email == userEmail);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
