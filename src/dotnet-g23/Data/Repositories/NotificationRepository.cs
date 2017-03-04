using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using dotnet_g23.Models.Domain;

namespace dotnet_g23.Data.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Notification> _notifications;

        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;
            _notifications = context.Notifications;
        }

        public Notification GetBy(int notificationId)
        {
            return _notifications
                .Include(n => n.User)
                .Include(n => n.Group)
                .SingleOrDefault(n => n.NotificationId == notificationId);
        }

        public IEnumerable<Notification> GetByUser(GUser user)
        {
            return _notifications
                .Include(n => n.User)
                .Include(n => n.Group)
                .Where(n => n.User.UserId == user.UserId);
        }

        public IEnumerable<Notification> GetAll()
        {
            return _notifications
                .ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
