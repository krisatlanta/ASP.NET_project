using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bookShop.BLL;

namespace bookShop.UI
{
    public partial class customerOrder : System.Web.UI.Page
    {
        
        OrderBLL order = new OrderBLL();
        OrderInfoBLL orderInfo = new OrderInfoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            int role = Convert.ToInt32(Session["role"]);
            if (role != 1)
            {
                Response.Redirect("~/Error.aspx");
            }
            if (!Page.IsPostBack)
            {
                GridView1.Visible = true;
                GridView2.Visible = false;
                GridView3.Visible = false;
                bind();
            }
        }

        public void bind()
        {
            int customerID = Convert.ToInt32(Session["userid"]);
            customerID = 7;
            GridView1.DataSource = order.checkAllOrderByCustomerID(customerID);
            GridView1.DataBind();
            GridView2.DataSource = order.checkUnReceiveOrder();
            GridView2.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView1.Visible = true;
            GridView2.Visible = false;
            GridView3.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            GridView2.Visible = true;
            GridView1.Visible = false;
            GridView3.Visible = false;
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "receiveOrder")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView2.Rows[index];
                string formID = row.Cells[0].Text.ToString();
                string state = row.Cells[3].Text.ToString();

                order.setOrderReceived(Convert.ToInt32(formID), state);

                GridView3.Visible = false;

                bind();
            }
            else if (e.CommandName == "detail")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView2.Rows[index];
                string formID = row.Cells[0].Text.ToString();

                orderInfo = new OrderInfoBLL(Convert.ToInt32(formID));
                GridView3.DataSource = orderInfo.getDataTable();
                GridView3.DataBind();

                GridView3.Visible = true;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "detail")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                string formID = row.Cells[0].Text.ToString();

                orderInfo = new OrderInfoBLL(Convert.ToInt32(formID));
                GridView3.DataSource = orderInfo.getDataTable();
                GridView3.DataBind();

                GridView3.Visible = true;
            }
        }
    }
}