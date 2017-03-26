using System;
using System.Collections.Generic;

namespace dotnet_g23.Models.Domain.Repositories
{
    public interface IUserRepository
    {
        GUser GetByEmail(String userEmail);
        void SaveChanges();
    }
}