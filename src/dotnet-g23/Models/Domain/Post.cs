using System;

namespace dotnet_g23.Models.Domain {
    public class Post {

        #region Properties
        public int PostId { get;private set; }
        public Label Label { get; private set; }
        public String Announcement { get; set; }
        public Byte[] Logo { get; set; }
        public Motivation Motivation { get; set; }
        public Group Group { get; private set; }
        public int GroupForeignKey { get; private set; }
        public Organization Organization { get; set; }
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
