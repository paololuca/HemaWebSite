using InternalWebSiteStats.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InternalWebSiteStats
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Console.WriteLine("AuthenticationType:" + User.Identity.AuthenticationType);
            Console.WriteLine("IsAuthenticated:" + User.Identity.IsAuthenticated);
            Console.WriteLine("Name:" + User.Identity.Name);

        }
    }
}