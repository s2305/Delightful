using Delightful.Bll;
using Delightful.Model;
using Delightful.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Delightful.IRepository;
using Microsoft.AspNet.SignalR;
using AppDelighful.Controllers;

namespace AppDelightful.Controllers
{
    public class BookmarkController : Controller
    {
        //private IBookmarkRepository _iBookmarkRepository;

        //public BookmarkController(IBookmarkRepository iBookmarkRepository)
        //{
        //    _iBookmarkRepository = iBookmarkRepository;
        //}

        private BusinessLocator _businessLocator;

        public BookmarkController()
        {
              _businessLocator = ((BusinessLocator)System.Web.HttpContext.Current.Items["BusinessLocator"]);
        }

        //
        // GET: /Bookmark/
        public async Task<ActionResult> Index()
        {

            //BookmarkBll bookmarkBll = new BookmarkBll(_iBookmarkRepository);
            BookmarkBll bookmarkBll = _businessLocator.BookmarkBll;
            
            List<Bookmark> listBkms = await bookmarkBll.GetAllBookmarksAsync();
            
            ViewModelBookmarks vm = new ViewModelBookmarks(listBkms);
            
            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> SearchBookmarksByKeywords(FormCollection collection)
        {

            string[] list_selected_Keywords = collection["hf_Keywords_selected"].Split('|');

            return PartialView("PVListBookmarks",
                              new ViewModelBookmarks(await _businessLocator.BookmarkBll.GetBookmarksByKeywordsAsync(list_selected_Keywords)).ListBkm);

        }

        //
        // GET: /Bookmark/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Bookmark/Create
         [System.Web.Mvc.Authorize(Roles="admin")]
        public ActionResult Create()
        {
            return View();
        }



        //
        // POST: /Bookmark/Create
        [HttpPost]
        [System.Web.Mvc.Authorize(Roles = "admin")]
        public async Task<ActionResult> Create(ViewModelBookmark vmBookmark)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    vmBookmark.Bookmark_inside.UserId = User.Identity.GetUserId();
                    await _businessLocator.BookmarkBll.AddBookmarkAsync(vmBookmark.Bookmark_inside);
                    
                    var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();

                    context.Clients.All.refreshJS();
                    
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(vmBookmark);
                }
            }
            catch
            {
                return View(vmBookmark);
            }
        }

        public async Task<ActionResult> Obtain5LastBookmarks()
        {
            Thread.Sleep(1000); //permet de ralentir l'execution de la méthode afin de voir l'appel asynchrone et l'image du chargement s'afficher
            return PartialView("PVListBookmarks",
                new ViewModelBookmarks(await _businessLocator.BookmarkBll.GetAllBookmarksAsync()).ListBkm.OrderByDescending(x => x.Id).Take(5));
        }

   
        //
        // GET: /Bookmark/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Bookmark/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Bookmark/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Bookmark/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
