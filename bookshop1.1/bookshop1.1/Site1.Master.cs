using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace bookshop1._1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(File.Exists(Server.MapPath("notice.txt")))
            Label2.Text = File.OpenText(Server.MapPath("notice.txt")).ReadToEnd();
            else
            {
                Response.Redirect(Server.MapPath("Error.aspx"));
            }
        }

        protected void NavigationMenu_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

    }
}