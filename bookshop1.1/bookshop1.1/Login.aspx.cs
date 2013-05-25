using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bookShop.BLL;
using bookShop.DAL;

namespace bookshop1._1
{
    public partial class Login : System.Web.UI.Page
    {
        string info;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie oldcookie = Request.Cookies["preferences"];
            if (oldcookie != null)
            {
                Session["userid"] = oldcookie["userid"];
                Session["role"] = oldcookie["role"];
                Session["username"] = oldcookie["username"];
                Response.Redirect("~/Default.aspx");
            }
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {

            userBLL ubll = new userBLL();
            string username = UserName.Text.Trim(), password = Password.Text.Trim();
            System.Diagnostics.Debug.WriteLine("我是账户名" + username);

            HttpCookie oldcookie = Request.Cookies["preferences"];
            if (oldcookie == null)
            {

                //测试登录功能


                int[] result = ubll.login(username, password);
                if (result[0] >= 1)
                {
                    info = "登陆成功";
                    HttpCookie cookie = new HttpCookie("Preferences");

                    cookie["username"] = username;

                    cookie["userid"] = result[0].ToString();
                    cookie["role"] = result[1].ToString();
                    Session["userid"] = result[0].ToString();
                    Session["role"] = result[1].ToString();
                    Session["username"] = username;
                    Response.Cookies.Add(cookie);
                    //cookie有效1个月
                    cookie.Expires = DateTime.Now.AddMonths(1);
                    //重定向到主页
                    Response.Redirect("~/Default.aspx");
                }
                else
                    if (result[0] == -1)
                    { info = "密码错误"; Label1.Text = info; UpdatePanel1.Update(); }
                    else
                    { info = "账号不存在"; Label1.Text = info; UpdatePanel1.Update(); }

                System.Diagnostics.Debug.WriteLine(info);
            }

        }

        protected void UserName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Password_TextChanged(object sender, EventArgs e)
        {

        }

    }
}