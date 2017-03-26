using System;
using System.ComponentModel.DataAnnotations;

namespace dotnet_g23.Models.Domain
{
    public class Action
    {
        #region Properties

        public int ActionId { get; private set; }

        [Required(ErrorMessage = "titel van actie is vereist")]
        public string Title { get; set; }

        [Required(ErrorMessage = "beschrijving van actie is vereist")]
        public string Description { get; set; }

        public DateTime? Date { get; private set; }

        public Group Group { get; private set; }

        #endregion

        #region Constructors

        public Action()
        {
        }

        public Action(Group group, string title, string description) : this()
        {
            Group = group;
            Title = title;
            Description = description;
            Date = null;
        }

        public Action(Group group, string title, string description, DateTime? date) : this(group, title, description)
        {
            Date = date;
        }

        #endregion
    }
}