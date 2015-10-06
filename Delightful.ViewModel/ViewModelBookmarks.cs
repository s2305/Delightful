using Delightful.Model;
using Delightful.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Delightful.ViewModel
{
    public class ViewModelBookmarks
    {
        private List<ViewModelBookmark> _ListBkm = new List<ViewModelBookmark>();

        public List<ViewModelBookmark> ListBkm
        {
            get { return _ListBkm; }
        }

        public ViewModelBookmarks(IEnumerable<Bookmark> p_listbkm)
        {
            foreach (Bookmark bkm in p_listbkm)
            {
                ViewModelBookmark VMbkm = new ViewModelBookmark(bkm);
                _ListBkm.Add(VMbkm);
            }

        }

        //on pourra rajouter des choses ici par la suite

    }
}