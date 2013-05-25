using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bookShop.BLL;
using bookShop.DAL;
using System.IO;

namespace bookshop1._1
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("Preferences");
            if (cookie != null)
                Response.Redirect("~/Default.aspx");
        }

        protected void CreateUserButton_Click(object sender, EventArgs e)
        {
            userBLL ubll = new userBLL();
            string username = UserName.Text.Trim();
            string password = Password.Text.Trim();
            string name = Name.Text;
            string phone = Phone.Text;
            string email = Email.Text;
            string address = Address.Text;
            bool isCustomer = customerRadio.Checked;
            if (isCustomer)
            {
                if (ubll.registerAsCustonmer(username, password, name, phone, email, address) == 1)
                {
                    HttpCookie cookie = new HttpCookie("Preferences");
                    
                    cookie["username"] = username;
                    userAccess ua = new userAccess();
                    User u = ua.SelectUserByName(username);
                    cookie["userid"] = u.userID.ToString();
                    cookie["role"] = u.role.ToString();
                    Session["userid"] = u.userID.ToString();
                    Session["role"] = u.role.ToString();
                    Session["username"] = username;
                    Response.Cookies.Add(cookie);
                    //cookie有效1个月
                    cookie.Expires = DateTime.Now.AddMonths(1);
                    //重定向到主页
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    Label1.Text = "注册失败，请尝试使用另一个用户名注册";
                    UpdatePanel1.Update();
                }
            }
            else
            {
                if (ubll.registerAsSeller(username, password, name, phone, email, address) == 1)
                {
                    HttpCookie cookie = new HttpCookie("Preferences");

                    cookie["username"] = username;
                    userAccess ua = new userAccess();
                    User u = ua.SelectUserByName(username);
                    cookie["userid"] = u.userID.ToString();
                    cookie["role"] = u.role.ToString();
                    Session["userid"] = u.userID.ToString();
                    Session["role"] = u.role.ToString();
                    Session["username"] = username;
                    Response.Cookies.Add(cookie);
                    //cookie有效1个月
                    cookie.Expires = DateTime.Now.AddMonths(1);

                    Directory.CreateDirectory(Server.MapPath("~/File/" + u.userID.ToString()));
                    //重定向到主页
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    Label1.Text = "注册失败，请尝试使用另一个用户名注册";
                    UpdatePanel1.Update();
                }
               
            }

        }


    }
}