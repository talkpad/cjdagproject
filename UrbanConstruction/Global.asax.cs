using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;

namespace UrbanConstruction
{
    public class Global : System.Web.HttpApplication, IContainerAccessor
    {

        private static WindsorContainer container;
        protected void Application_Start(object sender, EventArgs e)
        {
            container = new WindsorContainer(new XmlInterpreter("Component.config"));
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(Server.MapPath("~/log4net.xml")));
        }
        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
        #region IContainerAccessor 成员

        public IWindsorContainer Container
        {
            get { return container; }
        }

        #endregion
    }
}