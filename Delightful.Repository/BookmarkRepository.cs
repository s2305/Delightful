using Delightful.Dal;
using Delightful.IRepository;
using Delightful.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.Practices.Unity;

namespace Delightful.Repository
{
    public class BookmarkRepository : IBookmarkRepository
    {
        [Dependency]
        public DbContextDelightful context { get; set; }

        public List<Bookmark> SelectAllBookmarks()
        {
            //DbContextDelightful context = new DbContextDelightful();
            return context.Bookmarks.ToList();
        }

        public Task<List<Bookmark>> SelectAllBookmarksAsync()
        {
            //DbContextDelightful context = new DbContextDelightful();
            return context.Bookmarks.ToListAsync();
        }

        public List<Bookmark> SelectBookmarksByCriteria(Func<Bookmark, bool> predicat)
        {
            //DbContextDelightful context = new DbContextDelightful();
            return context.Bookmarks.Where(predicat).ToList();
        }

        public Task<List<Bookmark>> SelectBookmarksByCriteriaAsync(Expression<Func<Bookmark, bool>> predicat)
        {
            //DbContextDelightful context = new DbContextDelightful();
            return context.Bookmarks.Where(predicat).ToListAsync();
        }

        public List<Bookmark> SelectBookmarksByKeywords(string[] list_selected_Keywords)
        {
            //DbContextDelightful context = new DbContextDelightful();

            var query = context.Bookmarks.Where(x => list_selected_Keywords.All(y => x.Keywords.Select(z => z.Word).Contains(y)));
            return query.ToList();
        }

        public Task<List<Bookmark>> SelectBookmarksByKeywordsAsync(string[] list_selected_Keywords)
        {
            //DbContextDelightful context = new DbContextDelightful();

            var query = context.Bookmarks.Where(x => list_selected_Keywords.All(y => x.Keywords.Select(z => z.Word).Contains(y)));
            return query.ToListAsync();
        }

        public void InsertBookmark(Bookmark bkm)
        {
            try
            {
                //  DbContextDelightful context = new DbContextDelightful();

                context.Bookmarks.Add(bkm);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw e;
            }

        }

        public Task<int> InsertBookmarkAsync(Bookmark bkm)
        {
            try
            {
                //DbContextDelightful context = new DbContextDelightful();

                context.Bookmarks.Add(bkm);
                return context.SaveChangesAsync();
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

               var bkm = context.Bookmarks.Where(x => x.Id == id).First();

               var keywords = bkm.Keywords.ToList();
               
              context.Entry(keywords[0]).State = EntityState.Deleted;
              context.Entry(keywords[1]).State = EntityState.Deleted;
              context.Entry(keywords[2]).State = EntityState.Deleted;
                   
               context.SaveChanges();
               
               context.Entry(bkm).State = EntityState.Deleted;
               
               context.SaveChanges();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw e;
            }
           
        }

        public async Task DeleteBookmarkAsync(int id)
        {
            try
            {

                var bkm = await context.Bookmarks.Where(x => x.Id == id).FirstAsync();

                var keywords = bkm.Keywords.ToList();

                context.Entry(keywords[0]).State = EntityState.Deleted;
                context.Entry(keywords[1]).State = EntityState.Deleted;
                context.Entry(keywords[2]).State = EntityState.Deleted;

                await context.SaveChangesAsync();

                context.Entry(bkm).State = EntityState.Deleted;

                await context.SaveChangesAsync();
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
                context.Entry(bkm).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw e;
            }
        }
    }
}
