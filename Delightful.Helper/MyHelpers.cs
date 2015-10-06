using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Delightful.Helper
{
    public static class MyHelpers
    {
        public static MvcHtmlString CustomTruncate(this HtmlHelper x, MvcHtmlString s, int nbr)
        {
            var chaine = WebUtility.HtmlDecode(s.ToString());
            if (chaine.Length > nbr)
            {
                return MvcHtmlString.Create(  String.Format("{0}...", chaine.Substring(0,nbr)));
            }
            else
            {
                return s;
            }

            
         }
    }
}