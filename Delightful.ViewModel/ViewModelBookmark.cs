using Delightful.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.UI;
using AppDelightful.Validations;


namespace Delightful.ViewModel
{

    public class ViewModelBookmark : IValidatableObject
    {
        private Bookmark _bkm;

        public Bookmark Bookmark_inside
        {
            get { return _bkm; }
        }

        public ViewModelBookmark(Bookmark bkm)
        {
            _bkm = bkm;
        }

        public ViewModelBookmark()
        {
            _bkm = new Bookmark();
        }

        public int Id
        {
            get { return _bkm.Id; }
            set { _bkm.Id = value; }
        }

        [Required(ErrorMessageResourceType = typeof(Delightful.Res.ErrorsMessages),
                  ErrorMessageResourceName = "RequiredField")]
        //[Required]
        public string Title
        {
            get { return _bkm.Title; }
            set { _bkm.Title = value; }
        }

        //[Required]
        [Required(ErrorMessageResourceType = typeof(Delightful.Res.ErrorsMessages), ErrorMessageResourceName = "RequiredField")]
        //[Remote("VerifUniqueUrl", "Validation")]
        public string Url
        {
            get { return _bkm.Url; }
            set { _bkm.Url = value; }
        }


        [MaxWordsAttribute(5, ErrorMessageResourceName = "TooManyWordsField", ErrorMessageResourceType = typeof(Delightful.Res.ErrorsMessages))]
        [StringLength(maximumLength: 50, ErrorMessageResourceType = typeof(Delightful.Res.ErrorsMessages), ErrorMessageResourceName = "TooLongField")]

        public string Description
        {
            get { return _bkm.Description; }
            set { _bkm.Description = value; }
        }


        public List<Keyword> Keywords
        {
            get { return _bkm.Keywords.ToList(); }
            set { _bkm.Keywords = value; }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //Vérif :mot clef en double
            if (Keywords.Select(x => x.Word).Distinct().Count() != Keywords.Count)
            {
                yield return new ValidationResult("At least two keywords are the same ones");
            }

        }
    }

}