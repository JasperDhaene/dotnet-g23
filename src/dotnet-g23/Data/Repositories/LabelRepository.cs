using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Models;
using dotnet_g23.Models.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace dotnet_g23.Data.Repositories
{
    public class LabelRepository : ILabelRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Label> _labels;

        public LabelRepository(ApplicationDbContext context)
        {
            _context = context;
            _labels = context.Labels;
        }

        public Label GetByGroup(int id)
        {
            return _labels
                .Include(l => l.Group)
                .Include(l => l.Company)
                .SingleOrDefault(l => l.Group.GroupId == id);
        }
    }
}
