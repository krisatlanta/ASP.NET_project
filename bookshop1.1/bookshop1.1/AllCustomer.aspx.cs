using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bookShop.DAL;

namespace bookshop1._1.Admin
{
    public partial class AllCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null)
                Response.Redirect(Server.MapPath("Login.aspx"));
            //判断是否为管理员
            int role = Convert.ToInt32(Session["role"]);
            System.Diagnostics.Debug.WriteLine("我是角色" + role);
            if (role!=3)
            {
                Response.Redirect(Server.MapPath("Error.aspx"));
            }
            customerAccess ca  = new customerAccess();

            GridView1.DataSource = ca.SelectCustomerAll();
            GridView1.DataBind();
        }
    }
}