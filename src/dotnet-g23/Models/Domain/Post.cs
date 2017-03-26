namespace dotnet_g23.Models.Domain
{
    public class Post
    {
        #region Properties

        public int PostId { get; private set; }

        public string Announcement { get; set; }
        public Label Label { get; set; }
        public int LabelForeignKey { get; private set; }

        #endregion

        #region Constructors

        public Post()
        {
        }

        public Post(string announcement) : this()
        {
            Announcement = announcement;
        }

        #endregion
    }
}