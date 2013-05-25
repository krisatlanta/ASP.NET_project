using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bookshop1._1.Admin
{
    public partial class AllSeller : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null)
                Response.Redirect(Server.MapPath("Login.aspx"));
            int role = Convert.ToInt32(Session["role"]);
            if (role != 3)
            {
                Response.Redirect(Server.MapPath("Error.aspx"));
            }

        }
    }
}