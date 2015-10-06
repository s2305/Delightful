using Delightful.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Delightful.Dto
{
    [DataContract]
    public class BookmarkDto
    {
        private Bookmark _bkm;

        public BookmarkDto()
        {
            _bkm = new Bookmark();
        }

        public BookmarkDto(Bookmark bkm)
        {
            _bkm = bkm;
        }

        [DataMember]
        public int Id
        {
            get { return _bkm.Id; }
            set { _bkm.Id = value; }
        }

        [DataMember]
        public string Title
        {
            get { return _bkm.Title; }
            set { _bkm.Title = value; }
        }

        [DataMember]
        public string Url
        {
            get { return _bkm.Url; }
            set { _bkm.Url = value; }
        }
        
        [DataMember]
        public string Description
        {
            get { return _bkm.Description; }
            set { _bkm.Description = value; }
        }

        
        public List<Keyword> Keywords
        {
            get { return _bkm.Keywords.ToList() ; }
            set { _bkm.Keywords = value; }
        }

        
    }
}
