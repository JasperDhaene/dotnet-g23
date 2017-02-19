using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public interface IGADUserRepository
    {
        GADUser GetBy(int userId);
        GADUser GetByEmail(String userEmail);
        IEnumerable<GADUser> GetAll();
        void SaveChanges();
    }
}
