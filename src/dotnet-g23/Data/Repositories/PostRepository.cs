﻿using System.Collections.Generic;
using System.Linq;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace dotnet_g23.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Post> _posts;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
            _posts = _context.Posts;
        }

        public IEnumerable<Post> GetByOrganization(Organization organization)
        {
            return _posts
                .Include(po => po.Label).ThenInclude(l => l.Group).ThenInclude(l => l.Organization)
                .Include(po => po.Label).ThenInclude(l => l.Group).ThenInclude(l => l.Motivation)
                .Include(po => po.Label).ThenInclude(l => l.Company)
                .Where(po => po.Label.Group.Organization == organization);
        }

        public void Add(Post post)
        {
            _context.Posts.Add(post);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}