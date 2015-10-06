using Delightful.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Delightful.Dto
{
    [DataContract]
    public class BookmarkDtoUpdate
    {
        private Bookmark _bkm;

        public BookmarkDtoUpdate()
        {
            _bkm = new Bookmark();
        }

        public BookmarkDtoUpdate(Bookmark bkm)
        {
            _bkm = bkm;
        }

        [DataMember]
        [Required]
        public int Id
        {
            get { return _bkm.Id; }
            set { _bkm.Id = value; }
        }

        [DataMember]
        [Required]
        public string Title
        {
            get { return _bkm.Title; }
            set { _bkm.Title = value; }
        }

        [DataMember]
        [Required]
        public string Url
        {
            get { return _bkm.Url; }
            set { _bkm.Url = value; }
        }
        
        [DataMember]
        [Required]
        [StringLength(100)] //validation : la longueur du champ ne doit pas dépasser 100
        public string Description
        {
            get { return _bkm.Description; }
            set { _bkm.Description = value; }
        }

        [DataMember]
        public List<Keyword> Keywords
        {
            get { return _bkm.Keywords ; }
            set { _bkm.Keywords = value; }
        }

        
    }
}
