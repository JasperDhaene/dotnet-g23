using dotnet_g23.Models.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace dotnet_g23.Data.Repositories {
    public class PostRepository : IPostRepository {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<Post> _posts;

        public PostRepository(ApplicationDbContext context) {
            _context = context;
            _posts = _context.Posts;
        }

        public IEnumerable<Post> GetAll()
        {
            return _posts
                .Include(po => po.Label).ThenInclude(l => l.Group).ThenInclude(l => l.Organization)
                .Include(po => po.Label).ThenInclude(l => l.Company)
                .ToList();
        }

        public Post GetBy(int postId) {
            return _posts
                .Include(po => po.Label).ThenInclude(l => l.Group).ThenInclude(l => l.Organization)
                .Include(po => po.Label).ThenInclude(l => l.Company)
                .SingleOrDefault(po => po.PostId == postId);
        }

        public Post GetByGroup(Group group) {
            return _posts
                .Include(po => po.Label).ThenInclude(l => l.Group).ThenInclude(l => l.Organization)
                .Include(po => po.Label).ThenInclude(l => l.Company)
                .SingleOrDefault(po => po.Label.Group == group);
        }

        public IEnumerable<Post> GetByOrganization(Organization organization) {
            return _posts
               .Include(po => po.Label).ThenInclude(l => l.Group).ThenInclude(l => l.Organization)
               .Include(po => po.Label).ThenInclude(l => l.Company)
               .Where(po => po.Label.Group.Organization == organization);
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }
    }
}
