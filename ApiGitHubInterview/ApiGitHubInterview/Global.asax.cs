using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.SessionState;

namespace ApiGitHubInterview
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            // Initialize session state settings here
            SessionStateBehavior behavior = SessionStateBehavior.Default; // or SessionStateBehavior.Default or SessionStateBehavior.ReadOnly

            HttpContext.Current.SetSessionStateBehavior(behavior);
        }
    }
}
