using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.Kestrel.Internal.Http;

namespace dotnet_g23.Models.Domain
{
    public class Notification
    {
        #region Properties
        public int NotificationId { get; set; }
        public GUser User { get; private set; }
        public Group Group { get; private set; }
        public String Message { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateRead { get; private set; }
        public Boolean IsRead { get; private set; }
        #endregion

        #region Constructors
        public Notification(Group fromGroup, GUser toUser, String message)
        {
            Group = fromGroup;
            User = toUser;
            Message = message;
            DateCreated = DateTime.Now;
            IsRead = false;
        }
        #endregion

        #region Methods

        public void Read()
        {
            DateRead = DateTime.Now;
            IsRead = true;
        }
        #endregion
    }
}
