using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Agenda.Site
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        
            List<Entity.Example> lstExample = new List<Entity.Example>();
            for (int i = 1; i < 11; i++)
            {
                lstExample.Add
                (
                    new Entity.Example 
                    { 
                        id = i,
                        value = string.Concat("example", i.ToString()) 
                    }
                );
            }
            Application["lstExample"] = lstExample;


        }
    }
}