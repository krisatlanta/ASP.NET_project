/****************
 * Entity.cs
 * 用于保存实体类
 * 
 * 2013/5/4
 * ***************/
using System;

namespace bookShop.DAL
{
    //用户类，对应登陆表
    //role,1对应顾客，2对应商家,0对应管理员
    public class User
    {
        public int userID;
        public string userName;
        public string password;
        public int role;
    }
    //顾客信息类_对应customer表
    public class Customer
    {
        public int Id;
        public String name;
        public String phone;
        public String address;
        public String email;
        
    }
    //商家信息类，对应seller表
    public class Seller
    {
        public int Id;
        public String name;
        public String phone;
        public String address;
        public String email;
        public bool isValid;

    }


    //书本信息类_对应book表
    public class Book
    {
        public int bookID;
        public int sellerID;
        public int typeListId;
        public String bookTitle;
        public String bookAuthor;
        public String bookPublisher;
        public String bookIsbn;
        public String bookInfo;
        public float bookPrice;
        //图片地址
        public string bookImage;
        public int bookAmount;
        public DateTime bookTime;
        public bool isvalid;
    }

    //订单信息上的一项
    public class OrderItem
    {
        public int orderID;
        public int orderFormID;
        public int bookid;
        public int orderamount;
        public float singlePrice;
    }

    //订单
    public class Order
    {
        public int orderID;
        public int sellerID;
        public int  customerID;
        public DateTime formTime;
        public char orderState;
        
    }

    public class CartItem
    {
        public int customerID;
        public int bookID;
        public int bookAmount;
    }

}