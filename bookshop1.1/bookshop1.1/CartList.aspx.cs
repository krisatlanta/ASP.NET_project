using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bookShop.BLL;

namespace bookShop.UI
{
    public partial class CartList : System.Web.UI.Page
    {
        OrderBLL order = new OrderBLL();
        cartBLL cart = new cartBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            //int role = Convert.ToInt32(Session["role"]);
            //if (role != 1)
            //{
            //    Response.Redirect("~/Error.aspx");
            //}
            if (!Page.IsPostBack)
            {
                bind();
            }
        }

        //数据绑定
        public void bind()
        {
            int customerID = Convert.ToInt32(Session["userid"]);

            cart = new cartBLL(customerID);
            GridView1.DataSource = cart.showCartInfo();
            GridView1.DataBind();
        }

        //更新数据时
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            bind();
        }
        
        //取消更新
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            bind();
        }

        //更新数据到数据库
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string num = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text.ToString().Trim();
            string id = GridView1.Rows[e.RowIndex].Cells[0].Text;
            int customerID = Convert.ToInt32(Session["userid"]);

            if (num.Equals("") == false)
            {
                int amount = Convert.ToInt32(num);
                int bookID = Convert.ToInt32(id);

                cart.changeAmount(customerID, bookID, amount);
            }

            GridView1.EditIndex = -1;
            bind();
        }

        //删除购物车的图书
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int customerID = Convert.ToInt32(Session["userid"]);
            string id = GridView1.Rows[e.RowIndex].Cells[0].Text;
            int bookID = Convert.ToInt32(id);
            cart.removeBook(customerID, bookID);
            GridView1.EditIndex = -1;
            bind();
        }

        //提交订单
        protected void Button1_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(Session["userid"]);
            order.generateOrder(customerID);
            bind();
        }

        //计算总价钱
        public double computeTotalCost()
        {
            return cart.computeTotalCost();
        }
    }
}