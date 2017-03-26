using System.Collections.Generic;

namespace dotnet_g23.Models.Domain.Repositories
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetByOrganization(Organization organization);
        void Add(Post post);
        void SaveChanges();
    }
}