using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bookShop.BLL;

namespace bookshop1._1
{
    public partial class BookList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int typeid = int.Parse(Request.QueryString["typeid"].ToString());
            if (typeid < 0 || typeid > 11)
                Response.Redirect("~Error/aspx");
            bookBLL bl = new bookBLL();
            GridView1.DataSource = bl.getAllBooksAType(typeid);
            GridView1.DataBind();
            string leibie = "类别:";
            string type = "";
            switch (typeid)
            {
                case 1: type = leibie+"文学"; break;
                case 2: type = leibie + "少儿"; break;
                case 3: type = leibie + "管理"; break;
                case 4: type = leibie + "励志与成功"; break;
                case 5: type = leibie + "人文社科"; break;
                case 6: type = leibie + "生活"; break;
                case 7: type = leibie + "艺术"; break;
                case 8: type = leibie + "科技"; break;
                case 9: type = leibie + "计算机与互联网"; break;
                case 10: type = leibie + "教育"; break;
                case 11: type = leibie + "期刊"; break;
            }
            bookType.Text = type;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}