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

        public IEnumerable<Post> GetAll() {
            return _posts
                .Include(po => po.Group)
                .Include(po => po.Label)
                .Include(po => po.Motivation)
                .Include(po => po.Organization);
        }

        public Post GetBy(int postId) {
            return _posts
                .Include(po => po.Group)
                .Include(po => po.Label)
                .Include(po => po.Motivation)
                .Include(po => po.Organization)
                .SingleOrDefault(po => po.PostId == postId);
        }

        public Post GetByGroup(Group group) {
            return _posts
               .Include(po => po.Group)
               .Include(po => po.Label)
               .Include(po => po.Motivation)
               .Include(po => po.Organization)
               .SingleOrDefault(po => po.Group == group);
        }

        public IEnumerable<Post> GetByOrganization(Organization organization) {
            return _posts
               .Include(po => po.Group)
               .Include(po => po.Label)
               .Include(po => po.Motivation)
               .Include(po => po.Organization)
               .Where(po => po.Organization != null && po.Organization == organization);
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }
    }
}
