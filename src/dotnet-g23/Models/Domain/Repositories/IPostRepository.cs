using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain.Repositories
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetByOrganization(Organization organization);
        void Add(Post post);
        void SaveChanges();
    }
}
