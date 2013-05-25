using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bookshop1._1
{
    public partial class loginView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["preferences"];
            if (cookie == null)
            {
                HyperLink1.Text = "请登录";
                HyperLink1.NavigateUrl = "~/Login.aspx";
            }
            else
            {
                HyperLink1.Text = cookie["username"].ToString() ;
                HyperLink2.Visible = false;
            }
        }

        //将cookie置为无效
        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["preferences"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}