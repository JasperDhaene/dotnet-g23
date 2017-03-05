using System;
using System.Collections.Generic;

namespace dotnet_g23.Models.Domain.Repositories
{
    public interface IUserRepository
    {
        GUser GetBy(int userId);
        GUser GetByEmail(String userEmail);
        IEnumerable<GUser> GetAll();
        void SaveChanges();
    }
}
