namespace dotnet_g23.Models.Domain
{
    public class Label
    {
        #region Properties
        public int LabelId { get; private set; }
        public Group Group { get; private set; }
        public int GroupForeignKey { get; private set; }
        public Company Company { get; private set; }
        public int CompanyForeignKey { get; private set; }
        public Post Post { get; set; }
        #endregion

        #region Constructors

        public Label()
        {
        }
        public Label(Group group, Company company) : this()
        {
            Group = group;
            Company = company;
        }
        #endregion
    }
}
