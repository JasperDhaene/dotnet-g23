﻿using System.Collections.Generic;

namespace dotnet_g23.Models.Domain.Repositories
{
    public interface IOrganizationRepository
    {
        Organization GetBy(int organizationId);
        IEnumerable<Organization> GetAll();
        void SaveChanges();
        IEnumerable<Organization> GetByKeyword(string query);
    }
}