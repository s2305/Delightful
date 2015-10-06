using Delightful.Fake.Dal;
using Delightful.IRepository;
using Delightful.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Delightful.Fake.Repository
{
    public class BookmarkFakeRepository : IBookmarkRepository
    {
        public List<Bookmark> SelectAllBookmarks()
        {
            return BookmarkFakeDal.ListBkm;
        }

        public Task<List<Bookmark>> SelectAllBookmarksAsync()
        {
            return Task.Run( ()=>  BookmarkFakeDal.ListBkm);
        }

        
        public List<Bookmark> SelectBookmarksByCriteria(Func<Bookmark, bool> predicat)
        {
            return BookmarkFakeDal.ListBkm.Where(predicat).ToList();
        }

        public Task<List<Bookmark>> SelectBookmarksByCriteriaAsync(Expression<Func<Bookmark, bool>> predicat)
        {

            return Task.Run(()=>BookmarkFakeDal.ListBkm.Where(predicat.Compile()).ToList());
        }

        public List<Bookmark> SelectBookmarksByKeywords(string[] list_selected_Keywords)
        {
          
            var query = BookmarkFakeDal.ListBkm.Where(x => list_selected_Keywords.All(y => x.Keywords.Select(z => z.Word).Contains(y)));
            return query.ToList();
        }

        public Task<List<Bookmark>> SelectBookmarksByKeywordsAsync(string[] list_selected_Keywords)
        {
            var query = BookmarkFakeDal.ListBkm.Where(x => list_selected_Keywords.All(y => x.Keywords.Select(z => z.Word).Contains(y)));
            return Task.Run(() => query.ToList());
        }

        public void InsertBookmark(Bookmark bkm)
        {
            try
            {

                BookmarkFakeDal.ListBkm.Add(bkm);
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

                return Task.Run(() => { BookmarkFakeDal.ListBkm.Add(bkm); return bkm.Id; });
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw e;
            }
        }

        public void DeleteBookmark(int id)
        {
            var bkm=  BookmarkFakeDal.ListBkm.Where(x=>x.Id == id).FirstOrDefault();
            BookmarkFakeDal.ListBkm.Remove(bkm);

        }

        public async Task DeleteBookmarkAsync(int id)
        {
            var bkm = BookmarkFakeDal.ListBkm.Where(x => x.Id == id).FirstOrDefault();
            BookmarkFakeDal.ListBkm.Remove(bkm);
        }

        public void UpdateBookmark(Bookmark bkm)
        {
            var bkmFound = BookmarkFakeDal.ListBkm.Where(x => x.Id == bkm.Id).FirstOrDefault();
            
            //la modification se fait par référence
            bkmFound.Description = bkm.Description;
            
            for (int i = 0; i < bkm.Keywords.Count; i++)
            {
                bkmFound.Keywords[i].Word = bkm.Keywords[i].Word; 
            }

            bkmFound.Title = bkm.Title;
            bkmFound.Url = bkm.Url;
            
        }

        
    }
}
