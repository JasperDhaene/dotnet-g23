using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace dotnet_g23.Models.Domain
{
    public class Action
    {
        #region Attribute
        private String _description;
        #endregion

        #region Properties
        public int ActionId { get; private set; }
        [Required(ErrorMessage = "titel van actie is vereist")]
        public String Title { get; set; }
        [Required(ErrorMessage = "beschrijving van actie is vereist")]
        public String Description { get; set; }

        public DateTime? Date { get;  private set; }

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
