using Delightful.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delightful.IRepository
{
    public interface IKeywordRepository
    {
        List<Keyword> SelectKeywordsByCriteria(string term);

        Task<List<Keyword>> SelectKeywordsByCriteriaAsync(string term);

    }
}


