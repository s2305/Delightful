using Delightful.Bll;
using Delightful.Dal;
using Delightful.IRepository;
using Microsoft.Practices.Unity;
//using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delightful.Bll
{
    public class BusinessLocator
    {
        private UnityContainer _unityContainer;
        
        public BusinessLocator(UnityContainer p_unityContainer)
        {
            _unityContainer = p_unityContainer;
        }

        private DbContextDelightful _dbContextDelightful;

        public DbContext DbContext
        {
            get
            {
                if (_dbContextDelightful == null)
                { _dbContextDelightful = new DbContextDelightful(); }
                return _dbContextDelightful;
            }

        }

        private BookmarkBll _bookmarkBll;

        public BookmarkBll BookmarkBll
        {
            get
            {
                if (_bookmarkBll == null)
                {
                    _bookmarkBll = new BookmarkBll(this);
                }
                return _bookmarkBll;
            }

        }
        

        private KeywordBll _keywordBll;

        public KeywordBll KeywordBll
        {
            get
            {
                if (_keywordBll == null)
                {
                    _keywordBll = new KeywordBll(this);
                }
                return _keywordBll;
            }

        }

        private ServiceLocator _serviceLocator;

        public ServiceLocator ServiceLocator
        {
            get
            {
                if (_serviceLocator == null)
                {
                    _serviceLocator =  _unityContainer.Resolve<ServiceLocator>();
                }
                return _serviceLocator;
            }

        }

 


    }
}
