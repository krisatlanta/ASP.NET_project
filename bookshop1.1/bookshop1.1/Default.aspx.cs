using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bookShop.BLL;

namespace bookshop1._1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie oldcookie = Request.Cookies["preferences"];
            if (oldcookie != null)
            {
                Session["userid"] = oldcookie["userid"];
                Session["role"] = oldcookie["role"];
                Session["username"] = oldcookie["username"];
            }
            bookBLL bl  = new bookBLL();

            GridView1.DataSource = bl.getNewBooks(10);
            GridView1.DataBind();

            int role = Convert.ToInt32(Session["role"]);
            //System.Diagnostics.Debug.WriteLine("我是角色" + role);
            if (role == 1)
                customerManager1.Visible = true;
            else
                if (role == 2)
                    SellerManager1.Visible = true;
                else
                    if (role == 3)
                        AdminManager1.Visible = true;

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        

        
    }
}