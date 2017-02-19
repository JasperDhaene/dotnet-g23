using System;
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
            throw new NotImplementedException();
        }

        public GADUser GetBy(int userId)
        {
            throw new NotImplementedException();
        }

        public GADUser GetByEmail(string userEmail)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
