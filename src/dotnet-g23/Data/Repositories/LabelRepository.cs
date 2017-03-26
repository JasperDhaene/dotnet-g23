using System.Linq;
using dotnet_g23.Models.Domain;
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
                .Include(l => l.Post)
                .SingleOrDefault(l => l.Group.GroupId == id);
        }
    }
}