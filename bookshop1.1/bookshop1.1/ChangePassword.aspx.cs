using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bookShop.BLL;

namespace bookshop1._1
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["username"]==null)
                Response.Redirect("~/Login.aspx");
                
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string oldpsw = TextBox1.Text.Trim();
            string newpsw = TextBox2.Text.Trim();
            userBLL ubll = new userBLL();
            string username = Session["username"].ToString().Trim();
            int result = ubll.login(username, oldpsw)[0];
            if (result >= 1)
            {
                int userID = Convert.ToInt32(Session["userid"]);
                if (ubll.changePsw(userID, newpsw) >=1)
                { Label4.Text = "修改成功"; UpdatePanel1.Update(); }
            }
            else
            {
                Label4.Text = "旧密码错误"; 
                UpdatePanel1.Update(); 
            }

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}