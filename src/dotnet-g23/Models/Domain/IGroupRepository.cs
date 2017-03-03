using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public interface IGroupRepository
    {
        Group GetBy(int groupId);
        Group GetByName(String groupName);
		IEnumerable<Group> GetByOrganization(Organization organization);
		IEnumerable<Group> GetAll();
        void SaveChanges();
    }
}
