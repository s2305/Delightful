using Delightful.Bll;
using Delightful.Dal;
using Delightful.IRepository;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delightful.Bll
{
    public class ServiceLocator
    {

         [Dependency]
        public IBookmarkRepository BookmarkRepository { get; set; }

         [Dependency]
        public IKeywordRepository KeywordRepository { get; set; }


    }
}


