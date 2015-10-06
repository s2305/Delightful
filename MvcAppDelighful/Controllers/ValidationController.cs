using Delightful.Bll;
using Delightful.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace AppDelightful.Controllers
{
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class ValidationController : Controller
    {
        //IBookmarkRepository _iBookmarkRepository;

        //public ValidationController(IBookmarkRepository iBookmarkRepository)
        //{
        //    _iBookmarkRepository = iBookmarkRepository;
        //}

        private BusinessLocator _businessLocator { get; set; }

        public ValidationController(BusinessLocator p_businessLocator)
        {
            _businessLocator = ((BusinessLocator)System.Web.HttpContext.Current.Items["BusinessLocator"]);
        }
        
        //
        // GET: /Validation/

        public JsonResult VerifContentDescription(string description)
        {
            if (description.Contains("java")
                || description.Contains("jvm")
                || description.Contains("struts"))
            {
                return Json("Java, JVM, Struts sont des mots interdits", JsonRequestBehavior.AllowGet);
                //return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true);
            }
        }

        public JsonResult VerifUniqueUrl(string url)
        {
            if (_businessLocator.BookmarkBll.GetBookmarksByCriteria(x => x.Url == url).Count() > 0)
            {
                return Json("Url déjà enregistrée", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

    }

}