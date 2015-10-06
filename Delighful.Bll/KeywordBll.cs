using Delightful.Dal;
using Delightful.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Delightful.IRepository;

namespace Delightful.Bll
{
    public class KeywordBll
    {
        private IKeywordRepository KeywordRepo { get;  set;}

        public KeywordBll(BusinessLocator p_businessLocator)
        {
            KeywordRepo = p_businessLocator.ServiceLocator.KeywordRepository;
        }
        
        public List<Keyword> GetBookmarksByCriteria(string term)
        {
            //DbContextDelightful context = new DbContextDelightful();
            //return context.Keywords.Where(x => x.Word.StartsWith(term)).ToList();
            return KeywordRepo.SelectKeywordsByCriteria(term);
        }

        public Task<List<Keyword>> GetBookmarksByCriteriaAsync(string term)
        {
            //DbContextDelightful context = new DbContextDelightful();
            //return await context.Keywords.Where(x=>x.Word.StartsWith(term)).ToListAsync();
            return KeywordRepo.SelectKeywordsByCriteriaAsync(term);
        }
    }
}
