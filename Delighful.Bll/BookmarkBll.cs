using Delightful.Dal;
using Delightful.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using Delightful.IRepository;

namespace Delightful.Bll
{
    public class BookmarkBll
    {

        private IBookmarkRepository BookmarkRepo { get;  set;}
        BusinessLocator b;
        public BookmarkBll(BusinessLocator p_BusinessLocator)
        {
            BookmarkRepo = p_BusinessLocator.ServiceLocator.BookmarkRepository;
            b = p_BusinessLocator;
        }

        public List<Bookmark> GetAllBookmarks()
        {
            //DbContextDelightful context = new DbContextDelightful();

            //return context.Bookmarks.ToList();

            return BookmarkRepo.SelectAllBookmarks();
        }

        public  Task<List<Bookmark>> GetAllBookmarksAsync()
        {
            //DbContextDelightful context = new DbContextDelightful();

            //return  context.Bookmarks.ToListAsync();
            //juste pour faire un test pour oir combien de fois le dbcontext est instancié
            //var repokw = b.ServiceLocator.KeywordRepository;
            //repokw.SelectKeywordsByCriteria("Libération");
            
            return BookmarkRepo.SelectAllBookmarksAsync();
        }

        public List<Bookmark> GetBookmarksByCriteria(Func<Bookmark, bool> predicat)
        {
            //DbContextDelightful context = new DbContextDelightful();
            //return context.Bookmarks.Where(predicat).ToList();

            return BookmarkRepo.SelectBookmarksByCriteria(predicat);
        }

        public Task<List<Bookmark>> GetBookmarksByCriteriaAsync(Expression<Func<Bookmark, bool>> predicat)
        {
            //DbContextDelightful context = new DbContextDelightful();
            //return context.Bookmarks.Where(predicat).ToListAsync();

            return BookmarkRepo.SelectBookmarksByCriteriaAsync(predicat);
        }

        public List<Bookmark> GetBookmarksByKeywords(string[] list_selected_Keywords)
        {
            //DbContextDelightful context = new DbContextDelightful();

            var query = BookmarkRepo.SelectBookmarksByCriteria(x => list_selected_Keywords.All(y => x.Keywords.Select(z => z.Word).Contains(y)));
            return query.ToList();

        }

        public Task<List<Bookmark>> GetBookmarksByKeywordsAsync(string[] list_selected_Keywords)
        {
            //DbContextDelightful context = new DbContextDelightful();

            //var query = context.Bookmarks.Where(x => list_selected_Keywords.All(y => x.Keywords.Select(z => z.Word).Contains(y)));
            //return query.ToListAsync();
            return BookmarkRepo.SelectBookmarksByCriteriaAsync(x => list_selected_Keywords.All(y => x.Keywords.Select(z => z.Word).Contains(y)));

        }

        public void AddBookmark(Bookmark bkm)
        {
            try
            {
                DbContextDelightful context = new DbContextDelightful();

                context.Bookmarks.Add(bkm);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw e;
            }

        }

        public Task<int> AddBookmarkAsync(Bookmark bkm)
        {
            try
            {
                //DbContextDelightful context = new DbContextDelightful();

                //context.Bookmarks.Add(bkm);
                //return context.SaveChangesAsync();
                return BookmarkRepo.InsertBookmarkAsync(bkm);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw e;
            }

        }


        public void DeleteBookmark(int id)
        {
            try
            {
                BookmarkRepo.DeleteBookmark(id);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw e;
            }
        }

        public void UpdateBookmark(Bookmark bkm)
        {
            try
            {
                BookmarkRepo.UpdateBookmark(bkm);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw e;
            }
        }

        
    }
}
