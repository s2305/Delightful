using Delightful.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Delightful.IRepository
{
    public interface IBookmarkRepository
    {
        List<Bookmark> SelectAllBookmarks();
        Task<List<Bookmark>> SelectAllBookmarksAsync();

        List<Bookmark> SelectBookmarksByCriteria(Func<Bookmark, bool> predicat);
        Task<List<Bookmark>> SelectBookmarksByCriteriaAsync(Expression<Func<Bookmark, bool>> predicat);
        
        List<Bookmark> SelectBookmarksByKeywords(string[] list_selected_Keywords);
        Task<List<Bookmark>> SelectBookmarksByKeywordsAsync(string[] list_selected_Keywords);
        
        void InsertBookmark(Bookmark bkm);
        Task<int> InsertBookmarkAsync(Bookmark bkm);

        void DeleteBookmark(int id);
        Task DeleteBookmarkAsync(int id);

        void UpdateBookmark(Bookmark bkm);
    }
}
