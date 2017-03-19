using System;

namespace dotnet_g23.Models.Domain {
    public class Post {

        #region Properties
        public int PostId { get; set; }
        public Label Label { get; set; }
        public String Announcement { get; set; }
        public Byte[] Logo { get; set; }
        public Motivation Motivation { get; set; }
        public Group Group { get; set; }
        public int GroupForeignKey { get; set; }
        public Organization Organization { get; set; }
        public int OrganizationForeignKey { get; set; }
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
