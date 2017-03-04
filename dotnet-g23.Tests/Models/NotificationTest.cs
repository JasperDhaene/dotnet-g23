using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Models.Domain;
using Xunit;

namespace dotnet_g23.Tests.Models
{
    public class NotificationTest
    {
        [Fact]
        public void NewNotificationIsUnread()
        {
            Notification notification = new Notification(null, null, null);
            Assert.False(notification.IsRead);
        }

        [Fact]
        public void ReadNotificationIsRead()
        {
            Notification notification = new Notification(null, null, null);
            notification.Read();
            Assert.True(notification.IsRead);
        }
    }
}
