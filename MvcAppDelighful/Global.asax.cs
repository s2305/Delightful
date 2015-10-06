using AppDelighful;
using AppDelightful;
using Delightful.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AppDelightful.ViewModel
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();           
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            /* -> on instancie une seule fois par requête le BusinessLocator
             * il s'agit d'un objet référençant une seule instance de chaque objet métier
             *                                        et une seule instance du dbcontext  */
            if (!System.Web.HttpContext.Current.Items.Contains("BusinessLocator"))
            {
                System.Web.HttpContext.Current.Items["BusinessLocator"] = new BusinessLocator(UnityConfig.UnityContainer);
            }

        }

    }
}
