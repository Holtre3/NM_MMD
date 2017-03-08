using NM_MMD.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NM_MMD
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Application["dataFilePath"] = HttpContext.Current.Server.MapPath("~/App_Data/NM_MMD.xml");
        }
        protected void Session_Start()
        {
            Session["Dispensaries"] = InitializeSeedData.GetAllDispensaries();
        }
    }
}
