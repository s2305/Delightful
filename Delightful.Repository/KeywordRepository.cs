using Delightful.Dal;
using Delightful.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.Practices.Unity;


namespace Delightful.Repository
{
    public class KeywordRepository : IKeywordRepository
    {
        [Dependency]
        public DbContextDelightful context { get; set; }


        public List<Model.Keyword> SelectKeywordsByCriteria(string term)
        {
            //DbContextDelightful context = new DbContextDelightful();
            return context.Keywords.Where(x => x.Word.StartsWith(term)).ToList();
        }

        public Task<List<Model.Keyword>> SelectKeywordsByCriteriaAsync(string term)
        {
            //DbContextDelightful context = new DbContextDelightful();
            return context.Keywords.Where(x => x.Word.StartsWith(term)).ToListAsync();

        }
    }
}
