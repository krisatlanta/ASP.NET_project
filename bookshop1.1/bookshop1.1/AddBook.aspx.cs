using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bookShop.BLL;
using bookShop.DAL.DataAcess;
using System.IO;

namespace bookshop1._1.Seller
{
    public partial class AddBook : System.Web.UI.Page
    {
        BookDAL db = new BookDAL();
        string filePath;
        string maxid ;
        string thefilePath;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //控制访问权限,非商家用户不能访问
            if (Convert.ToInt32(Session["role"]) != 2)
                Response.Redirect(Server.MapPath("Login.aspx"));

        }

        protected void bookshopsrc_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string imgurl = thefilePath;
            string title = booknameLable.Text;
            float price = int.Parse(TextBox6.Text) + int.Parse(TextBox7.Text)/(float)100;
            string author = authorLable.Text;
            string publisher = publisherLable.Text;
            string isbn = isbnLabel.Text;
            string info = TextBox5.Text;
            bool shelf = RadioButton1.Checked;
            int typeid = int.Parse(DropDownList1.SelectedValue);
            int amount = int.Parse(TextBox8.Text);
            bookBLL bb = new bookBLL();
            int sellerID = Convert.ToInt32(Session["userid"]);
            int result = bb.insertBook(sellerID, typeid, title, author, publisher, isbn, info, price, amount,
                shelf, imgurl);
            if (result == 1)
                Response.Redirect("~/Seller/Booklist.aspx?id=" + sellerID.ToString());
            else
            {
                lblMessage.Text = "添加书本失败";
                UpdatePanel1.Update(); 
            }
        }

        //文件上传按钮click事件
        protected void Button2_Click(object sender, EventArgs e)
        {
            
            
   

        if (FileUpload1.HasFile)
        {
            //判断文件是否小于10Mb
            if (FileUpload1.PostedFile.ContentLength < 4194204)
            {
                try
                {
                    
                    
                    //上传文件并指定上传目录的路径
                   
                    /*注意->这里为什么不是:FileUpload1.PostedFile.FileName
                    * 而是:FileUpload1.FileName?
                    * 前者是获得客户端完整限定(客户端完整路径)名称
                    * 后者FileUpload1.FileName只获得文件名.
                    */

                    //当然上传语句也可以这样写(貌似废话):
                    //FileUpload1.SaveAs(@"D:\"+FileUpload1.FileName);

                    maxid = (db.selectMaxID() + 1).ToString();
                    filePath = Server.MapPath("~/Files/") + Session["userid"].ToString()+"/"+maxid
                                    + FileUpload1.FileName;
                    if(File.Exists(filePath))
                        File.Delete(filePath);
                    FileUpload1.PostedFile.SaveAs(filePath); 
                     Image1.ImageUrl = filePath; 

                    lblMessage.Text = "上传成功";
                    thefilePath = filePath;
                    UpdatePanel1.Update(); 
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "出现异常,无法上传!";
                    //lblMessage.Text += ex.Message;
                }

            }
            else
            {
                lblMessage.Text = "上传文件不能大于4MB!";
            }
        }
        else
        {
            lblMessage.Text = "尚未选择文件!";
        }
    }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        } 
        }
    
}