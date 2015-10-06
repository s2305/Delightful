using Delightful.Fake.Dal;
using Delightful.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Delightful.Fake.Repository
{
    public class KeywordFakeRepository:IKeywordRepository
    {
        public List<Model.Keyword> SelectKeywordsByCriteria(string term)
        {
            return BookmarkFakeDal.ListBkm.SelectMany(y=>y.Keywords).Where(x => x.Word.StartsWith(term)).ToList();
        }


        public Task<List<Model.Keyword>> SelectKeywordsByCriteriaAsync(string term)
        {
            //return BookmarkFakeDal.ListBkm.SelectMany(y => y.Keywords).Where(x => x.Word.StartsWith(term)).ToList();
            return Task.Run(new Func<List<Model.Keyword>>(() => { return BookmarkFakeDal.ListBkm.SelectMany(y => y.Keywords).Where(x => x.Word.StartsWith(term)).ToList(); }));
        }
    }
}
