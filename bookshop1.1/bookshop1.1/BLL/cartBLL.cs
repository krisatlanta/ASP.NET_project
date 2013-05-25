using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using bookShop.DAL;
using bookShop.DAL.DataAcess;

namespace bookShop.BLL
{
    public class cartBLL
    {
        private CartBook cartBook;

        public cartBLL()
        {
           
        }

        public cartBLL(int customer_id)
        {
            cartBook = new CartBook(customer_id);
        }

        public void setCartBook(int customer_id)
        {
            cartBook = new CartBook(customer_id);
        }

        //返回购物车信息
        public DataTable showCartInfo()
        {
            if (cartBook != null)
            {
                return cartBook.getCartBookTable();
            }
            else
            {
                return null;
            }
        }

        //清空购物车
        public int clearCart(int customerID)
        {      
            if (cartBook == null)
            {
                cartBook = new CartBook(customerID);
            }

             return cartBook.getCart().clearCart(customerID);           
        }

        //添加图书到购物车
        public int addBookToCart(Book book, int customerID, int amount)
        {
            if (book.bookAmount >= amount && amount > 0 )
            {
                CartBookItem[] item;
                if (cartBook == null)
                {
                    cartBook = new CartBook(customerID);
                }

                item = cartBook.CartBookTableToCartBookItem();
                for (int i = 0; i < item.Length; i++)
                {
                    if (item[i].bookID == book.bookID)
                    {
                        return 0;
                    }
                }

                return cartBook.addBookToCart(customerID, book.bookID, amount);
            }
            else
            {
                return 0;
            }
        }

        //删除购物车某一项
        public int removeBook(int customerID,int bookID)
        {
            if (cartBook == null)
            {
                cartBook = new CartBook();
            }
            return cartBook.removeBook(customerID, bookID);
        }

        //更改购物车数量
        public int changeAmount(int customerID,int bookID, int newAmount)
        {
            CartBookItem[] item;
            if (cartBook == null)
            {
                cartBook = new CartBook(customerID);
            }

            //提取购物车信息
            item = cartBook.CartBookTableToCartBookItem();

            int i = 0;
            for (; i < item.Length; i++)
            {
                if (item[i].bookID == bookID)
                {
                    break;
                }
            }

            if (newAmount <= item[i].bookAmount && newAmount > 0)
            {
                return cartBook.changeAmount(customerID, bookID, newAmount);      
            }
            else
            {
                return 0;
            }

        }

        //计算购物车总价
        public double computeTotalCost()
        {
            double cost = 0.0;
            CartBookItem[] item = cartBook.CartBookTableToCartBookItem();
            for (int i = 0; i < item.Length; i++)
            {
                cost += item[i].bookPrice * item[i].cartAmount;
            }

            return cost;

        }
 
    }
}