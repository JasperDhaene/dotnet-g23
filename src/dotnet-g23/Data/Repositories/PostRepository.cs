using dotnet_g23.Models.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace dotnet_g23.Data.Repositories
{
    public class PostRepository : IPostRepository {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<Post> _posts;

        public PostRepository(ApplicationDbContext context) {
            _context = context;
            _posts = _context.Posts;
        }

        public IEnumerable<Post> GetAll() {
            throw new NotImplementedException();
        }

        public Post GetBy(int postId) {
            throw new NotImplementedException();
        }

        public Post GetByGroup(Group group) {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetByOrganization(Organization organization) {
            throw new NotImplementedException();
        }

        public void SaveChanges() {
            throw new NotImplementedException();
        }
    }
}
