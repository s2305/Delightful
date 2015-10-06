
using Delightful.Bll;
using Delightful.Dto;
using Delightful.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace AppDelighful.Controllers
{
    public class WebBookmarksController : ApiController
    {

        private BusinessLocator _businessLocator;

        public WebBookmarksController()
        {
            _businessLocator = ((BusinessLocator)System.Web.HttpContext.Current.Items["BusinessLocator"]);
        }

        // GET: api/WebBookmarks
        public IEnumerable<BookmarkDto> Get()
        {
            List<BookmarkDto> listBkmDto = new List<BookmarkDto>();
            foreach (var bkm in _businessLocator.BookmarkBll.GetAllBookmarks())
            {
                listBkmDto.Add(new BookmarkDto(bkm));
            }
            return listBkmDto;
        }

        // GET: api/WebBookmarks/5
        [Authorize]
        public BookmarkDto Get(int id)
        {
            Bookmark bkm = _businessLocator.BookmarkBll.GetBookmarksByCriteria(x => x.Id == id).FirstOrDefault();
            if (bkm != null)
            {
                BookmarkDto bkmDto = new BookmarkDto(bkm);
                return bkmDto;
            }
            return null;
        }

        // POST: api/WebBookmarks
        [Authorize(Roles = "admin")]
        public IHttpActionResult Post([FromBody]BookmarkDtoInsert bkmDto)
        {
            if (ModelState.IsValid)
            {
                Bookmark bkm = new Bookmark();

                bkm.Id = bkmDto.Id;
                bkm.Description = bkmDto.Description;
                bkm.Title = bkmDto.Title;
                bkm.Url = bkmDto.Url;
                bkm.UserId = User.Identity.GetUserId();
                bkm.Keywords = bkmDto.Keywords;

                _businessLocator.BookmarkBll.AddBookmark(bkm);
                //return new HttpResponseMessage(HttpStatusCode.OK);
                return Ok();
            }
            else
            {
                //return new HttpResponseMessage(HttpStatusCode.BadRequest);
                return BadRequest(ModelState);
            }
        }

        // PUT: api/WebBookmarks/5
        //public HttpResponseMessage Put([FromBody]BookmarkDtoUpdate bkmDto)
        [Authorize(Roles = "admin")]
        public IHttpActionResult Put([FromBody]BookmarkDtoUpdate bkmDto)
        {
            if (ModelState.IsValid)
            {
                Bookmark bkm = new Bookmark();

                bkm.Id = bkmDto.Id;
                bkm.Description = bkmDto.Description;
                bkm.Title = bkmDto.Title;
                bkm.Url = bkmDto.Url;
                bkm.UserId = User.Identity.GetUserId();
                bkm.Keywords = bkmDto.Keywords;

                _businessLocator.BookmarkBll.UpdateBookmark(bkm);

                //return new HttpResponseMessage(HttpStatusCode.OK);
                return Ok();
            }
            else
            {
                //return new HttpResponseMessage(HttpStatusCode.BadRequest);
                return BadRequest(ModelState);

            }
        }

        // DELETE: api/WebBookmarks/5
        public void Delete(int id)
        {
            _businessLocator.BookmarkBll.DeleteBookmark(id);
        }
    }
}
