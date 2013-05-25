using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace bookshop1._1.Admin
{
    public partial class changeNotice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int role = Convert.ToInt32(Session["role"]);
            if (role != 3)
            {
                Response.Redirect("~/Error.aspx");
            }
            if (File.Exists(Server.MapPath("notice.txt")))
                TextBox1.Text = File.OpenText(Server.MapPath("notice.txt")).ReadToEnd();
            else
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(Server.MapPath("notice.txt")))
            {
                string FileRead = TextBox1.Text;
                using (StreamWriter sw = new StreamWriter(Server.MapPath("notice.txt")))
                {
                    sw.Write(FileRead);
                }
            }
        
           
        }
    }
}