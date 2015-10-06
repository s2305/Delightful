using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1;
using System.Web;
using AppDelightful;
using Delightful.Bll;
using AppDelightful.Controllers;
using Delightful.ViewModel;
using System.IO;
using System.Threading.Tasks;
using Delightful.Model;
using Moq;

namespace WebApplication1.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public async Task Index()
        {


            HttpContext.Current = new HttpContext(
                                                    new HttpRequest("", "http://tempuri.org", ""),
                                                    new HttpResponse(new StringWriter())
            );


            UnityConfig.RegisterComponents();

            System.Web.HttpContext.Current.Items["BusinessLocator"] = new BusinessLocator(UnityConfig.UnityContainer);


            BookmarkController ctrl = new BookmarkController();

            ViewResult vr = await ctrl.Index() as ViewResult;

            //on verifie que le nombre de bookmarks retourné est 6
            Assert.IsTrue(((ViewModelBookmarks)vr.Model).ListBkm.Count == 6);

        }


        [TestMethod()]
        public async Task SearchBookmarksByKeywords()
        {
            HttpContext.Current = new HttpContext(
                                        new HttpRequest("", "http://tempuri.org", ""),
                                        new HttpResponse(new StringWriter())
            );


            UnityConfig.RegisterComponents();

            System.Web.HttpContext.Current.Items["BusinessLocator"] = new BusinessLocator(UnityConfig.UnityContainer);

            BookmarkController ctrl = new BookmarkController();
            FormCollection fc = new FormCollection();
            fc["hf_keywords_selected"] = "journal|gauche";
            PartialViewResult vr = await ctrl.SearchBookmarksByKeywords(fc) as PartialViewResult;

            //on verifie que le nombre de bookmarks retourné est 1
            //Assert.IsTrue( (IEnumerable<ViewModelBookmark>)vr.Model).Count() == 1);

            //on verifie bien qu'il s'agit du journal Liberation
            Assert.IsTrue(((List<ViewModelBookmark>)vr.Model)[0].Url.Contains("liberation"));
        }

        [TestMethod]
        public async Task Create()
        {

            HttpContext.Current = new HttpContext(
                                        new HttpRequest("", "http://tempuri.org", ""),
                                        new HttpResponse(new StringWriter())
            );


            UnityConfig.RegisterComponents();

            System.Web.HttpContext.Current.Items["BusinessLocator"] = new BusinessLocator(UnityConfig.UnityContainer);


            BookmarkController ctrl = new BookmarkController();

            var mock = new Mock<ControllerContext>();
            mock.SetupGet(x => x.HttpContext.User.Identity.Name).Returns("SOMEUSER");
            mock.SetupGet(x => x.HttpContext.Request.IsAuthenticated).Returns(true);
            ctrl.ControllerContext = mock.Object;


            Bookmark bkm = new Bookmark();
            bkm.Id = 7;
            bkm.Description = "Pour acheter des produits d'occasion pas loin de chez soi";
            bkm.Title = "Site d'achat en ligne";
            bkm.Url = "http://www.leboncoin.fr/";
            Keyword kw1 = new Keyword() { Id = 19, Bookmark = bkm, BookmarkId = bkm.Id, Word = "ecommerce" };
            Keyword kw2 = new Keyword() { Id = 20, Bookmark = bkm, BookmarkId = bkm.Id, Word = "coin" };
            Keyword kw3 = new Keyword() { Id = 21, Bookmark = bkm, BookmarkId = bkm.Id, Word = "occasion" };

            bkm.Keywords.Add(kw1);

            bkm.Keywords.Add(kw2);

            bkm.Keywords.Add(kw3);

            await ctrl.Create(new ViewModelBookmark(bkm));

            //on verifie que le nombre de bookmarks retourné est 7
            ViewResult vr = await ctrl.Index() as ViewResult;

            Assert.IsTrue(((ViewModelBookmarks)vr.Model).ListBkm.Count == 7);

        }





    }
}
