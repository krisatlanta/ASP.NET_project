using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bookShop.BLL;

namespace bookshop1._1
{
    public partial class search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string key = TextBox1.Text;
            bookBLL bl = new bookBLL();
            if (RadioButton1.Checked) 
            GridView1.DataSource = bl.searchBook(1, key);
            else
                if(RadioButton2.Checked)
                    GridView1.DataSource = bl.searchBook(2, key);
                else
                    if(RadioButton3.Checked)
                        GridView1.DataSource = bl.searchBook(3, key);
                    else
                        if(RadioButton4.Checked)
                            GridView1.DataSource = bl.searchBook(4, key);
            GridView1.DataBind();

        }
    }
}