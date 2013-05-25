using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace bookShop.DAL.DataAcess
{
    //用来存储购物车信息的结构
    public struct CartBookItem
    {
        public int bookID;
        public int customerID;
        public int sellerID;
        public string bookTitle;
        public int cartAmount;  //购物车购买的数量
        public int bookAmount;  //图书库存
        public double bookPrice;
    }

    
    public class CartBook
    {
        private CartDAL cart = new CartDAL();
        private BookDAL book = new BookDAL(); 
        private GetConn conn = new GetConn();
        private DataSet dataset = new DataSet();
        private DataTable cartTable = new DataTable();
        private DataTable bookTable = new DataTable();

        private DataSetOperate dataSetOprerate = new DataSetOperate();

        public CartBook()
        {

        }

        //重载构造函数,为图书表和购物表建立关系
        public CartBook(int customerID)
        {
            //获取用户ID为customerID的购物车表和对应的图书信息
            makeRelation(customerID);

            //创建一个购物车图书信息表
            makeCartBookTable();

        }

        //获取用户ID为customerID的购物车表和对应的图书信息
        private void makeRelation(int customerID)
        {
            cartTable = cart.getCartByCustomerID(customerID);
            bookTable = book.getBookInfoInCart(customerID);

            cartTable.TableName = "cart";
            bookTable.TableName = "book";

            dataset.Tables.Add(cartTable);
            dataset.Tables.Add(bookTable);

            dataSetOprerate.newRelation(dataset, "book", "cart", "book_id", "book_id");
        }

        //创建一个购物车图书信息表，命名为cartBook
        private  void makeCartBookTable()
        {
            DataTable cartBookTable = new DataTable();
            cartBookTable = cartTable.Clone();
            cartBookTable = cartTable.Copy();

            cartBookTable.TableName = "cartBook";
            dataset.Tables.Add(cartBookTable);

            dataSetOprerate.newRelation(dataset, "book", "cartBook", "book_id", "book_id");

            //向cartBook表插入book_title,book_price,book_amount,seller_id四列
            dataSetOprerate.addColumn(dataset, "book", "cartBook", "book_title", "book_title");
            dataSetOprerate.addColumn(dataset, "book", "cartBook", "book_price", "book_price");
            dataSetOprerate.addColumn(dataset, "book", "cartBook", "seller_id", "seller_id");
            dataSetOprerate.addColumn(dataset, "book", "cartBook", "book_amount", "book_amount");
        }

        //返回购物车图书信息表
        public DataTable getCartBookTable()
        {
            return dataset.Tables["cartBook"];
        }

        public CartBookItem[] CartBookTableToCartBookItem()
        {
            int counts = dataset.Tables["cartBook"].Rows.Count;
            CartBookItem[] item = new CartBookItem[counts];

            for (int i = 0; i < counts; i++)
            {
                item[i].customerID = Convert.ToInt32(dataset.Tables["cartBook"].Rows[i]["customer_id"]);
                item[i].bookID = Convert.ToInt32(dataset.Tables["cartBook"].Rows[i]["book_id"]);
                item[i].bookTitle = dataset.Tables["cartBook"].Rows[i]["book_title"].ToString();
                item[i].sellerID = Convert.ToInt32(dataset.Tables["cartBook"].Rows[i]["seller_id"]);
                item[i].bookPrice = Convert.ToDouble(dataset.Tables["cartBook"].Rows[i]["book_price"]);
                item[i].bookAmount = Convert.ToInt32(dataset.Tables["cartBook"].Rows[i]["book_amount"]);
                item[i].cartAmount = Convert.ToInt32(dataset.Tables["cartBook"].Rows[i]["cart_amount"]);
            }

            return item;
        }

        public int removeBook(int customerID, int bookID)
        {
            try
            {
                int rst = cart.removeBook(customerID, bookID);

                    return rst;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return -1;
            }

        }

        public int clearCart(int customerID)
        {
            try
            {
                int rst = cart.clearCart(customerID);             
                return rst;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return -1;
            }
            
        }
        public int addBookToCart(int customerID, int bookID, int amount)
        {
            return cart.addBookToCart(customerID, bookID, amount);
        }

        public int changeAmount(int customerID,int bookID, int newAmount)
        {
            try
            {
                int rst = cart.changeAmount(customerID, bookID, newAmount);
                return rst;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return -1;
            }
        }

        public CartDAL getCart()
        {
            return cart;
        }


    }
}