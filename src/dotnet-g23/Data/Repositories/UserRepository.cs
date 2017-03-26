using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;

namespace dotnet_g23.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<GUser> _users;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
            _users = context.GUsers;
        }

        public GUser GetByEmail(string userEmail)
        {
            return _users
                .Include(u => u.UserState)
                .SingleOrDefault(u => u.Email == userEmail);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}