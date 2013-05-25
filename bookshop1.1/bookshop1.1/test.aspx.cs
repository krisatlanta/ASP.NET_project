using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bookShop.DAL.DataAcess;

namespace bookshop1._1
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BookDAL bd = new BookDAL();
            int max = bd.selectMaxID();
            System.Diagnostics.Debug.WriteLine("我是最大的ID" + max);
        }
    }
}