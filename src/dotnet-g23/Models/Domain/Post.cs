using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace dotnet_g23.Models.Domain {
    public class Post {

        #region Properties
        public int PostId { get; set; }
        public Label Label { get; set; }
        public String Announcement { get; set; }
        public Byte[] Logo { get; set; }
        public Motivation Motivation { get; set; }
        #endregion

        #region Constructors
        public Post() {

        }

        public Post(string announcement, byte[] logo) : this() {
            Announcement = announcement;
            Logo = logo; 
        }
        #endregion
    }
}
