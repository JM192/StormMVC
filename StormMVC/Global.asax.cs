using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace StormMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            var Username = Session["AUTHUsername"] as string;
            var Sessroles = Session["AUTHRoles"] as string;
            if (string.IsNullOrEmpty(Username))
            {
                return;
            }
            GenericIdentity i = new GenericIdentity(Username, "myCustomType");

            string[] roles = Sessroles.Split(',');
            GenericPrincipal p = new GenericPrincipal(i, roles);
            HttpContext.Current.User = p;
        }
    }
}
