using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public interface IUserRepository
    {
        User GetBy(int userId);
        User GetByEmail(String userEmail);
        IEnumerable<User> GetAll();
        void SaveChanges();
    }
}
