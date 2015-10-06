using Delightful.ViewModel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Delightful.Model
{
    public class Bookmark
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Url { get; set; }
        public virtual string Description { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        //propriété de navigation
        public virtual List<Keyword> Keywords { get; set; }

        public Bookmark()
        {
            Keywords = new List<Keyword>();
        }
    }
}