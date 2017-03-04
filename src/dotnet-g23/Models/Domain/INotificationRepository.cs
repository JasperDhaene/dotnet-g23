using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public interface INotificationRepository
    {
        Notification GetBy(int notificationId);
        IEnumerable<Notification> GetByUser(GUser user);
		IEnumerable<Notification> GetAll();
        void SaveChanges();
    }
}
