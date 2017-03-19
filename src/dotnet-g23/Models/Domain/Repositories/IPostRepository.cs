using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain.Repositories
{
    public interface IPostRepository
    {
        Post GetBy(int postId);
        Post GetByGroup(Group group);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetByOrganization(Organization organization);
        void SaveChanges();
    }
}
