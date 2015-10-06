using Delightful.Bll;
using Delightful.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AppDelightful.Controllers
{
    public class KeywordController : Controller
    {
        private BusinessLocator _businessLocator { get; set; }

        public KeywordController(BusinessLocator p_businessLocator)
        {
            _businessLocator = ((BusinessLocator)System.Web.HttpContext.Current.Items["BusinessLocator"]);
        }

        //
        // GET: /Keyword/

        public async Task<ActionResult> Search(string term)
        {
            var listKW = await _businessLocator.KeywordBll.GetBookmarksByCriteriaAsync(term);

            
            return Json(listKW.Select(x => new { label = x.Word }).Distinct(), JsonRequestBehavior.AllowGet);
        }
    }
}