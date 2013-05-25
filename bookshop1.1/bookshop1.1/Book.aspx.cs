using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bookShop.BLL;
using bookShop.DAL.DataAcess;
using bookShop.DAL;


namespace bookshop1._1
{
    public partial class Book : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"].ToString());
            BookDAL bd = new BookDAL();
            bookShop.DAL.Book thisBook = bd.selectBookByID(id);
            if (thisBook == null)
                Response.Redirect("~/Error.aspx");
            else
            {
                bookNameLabel.Text = thisBook.bookTitle;
                tool t = new tool();
                string formatPrice = t.priceFormat(thisBook.bookPrice.ToString());
                priceLabel.Text = formatPrice;
                amountLabel.Text = thisBook.bookAmount.ToString();
                pubLabel.Text = thisBook.bookPublisher;
                isbnLabel.Text = thisBook.bookIsbn;
                string type = "" ;
                   switch(thisBook.typeListId)
                    {
                       case 1:type = "文学";break;
                       case 2:type = "少儿";break;
                       case 3:type = "管理";break;
                       case 4:type = "励志与成功";break;
                       case 5:type = "人文社科";break;
                       case 6:type = "生活";break;
                       case 7:type = "艺术";break;
                       case 8:type = "科技";break;
                       case 9:type = "计算机与互联网";break;
                       case 10:type = "教育";break;
                       case 11:type = "期刊";break;                    
                    }
                   Label1.Text = type;
                   infoLiteral.Text = thisBook.bookInfo;
                //提示下架，隐藏加入购物车按钮
                   if (!thisBook.isvalid)
                   { Label2.Visible = true; Button1.Visible = false; }
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(Request.QueryString["id"].ToString());
            bookShop.DAL.Book b = new bookShop.DAL.Book();
            b.bookID = ID;
            b.bookAmount = int.Parse(amountLabel.Text);
            cartBLL cb = new cartBLL();
            cb.addBookToCart(b, Convert.ToInt32(Session["userid"]), 1);

        }
    }
}