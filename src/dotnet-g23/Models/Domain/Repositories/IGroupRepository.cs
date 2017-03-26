using System.Collections.Generic;

namespace dotnet_g23.Models.Domain.Repositories
{
    public interface IGroupRepository
    {
        Group GetBy(int groupId);
        IEnumerable<Group> GetByOrganization(Organization organization);
        IEnumerable<Group> GetAll();
        void SaveChanges();
    }
}