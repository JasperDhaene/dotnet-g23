using System;

namespace dotnet_g23.Models.Domain {
    public class Post {

        #region Properties
        public int PostId { get; private set; }

        public String Announcement { get; set; }
        public Byte[] Logo { get; set; }
        public Label Label { get; private set; }
        public int LabelForeignKey { get; private set; }
        #endregion

        #region Constructors
        public Post()
        {
        }

        public Post(String announcement, Byte[] logo) : this()
        {
            Announcement = announcement;
            Logo = logo; 
        }
        #endregion
    }
}
