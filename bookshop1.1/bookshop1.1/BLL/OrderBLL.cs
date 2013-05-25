using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using bookShop.DAL;
using bookShop.DAL.DataAcess;

namespace bookShop.BLL
{
    public class OrderBLL
    {
        private OrderDAL order = new OrderDAL();
        private CartBook cartBook;

        public DataTable checkAllOrderByCustomerID(int customerID)
        {
            order.setCustomerID(customerID);
            return order.selectOrderInfoByCustomerID();
        }

        public DataTable checkUnReceiveOrder()
        {
            return order.checkAllOrderUnReceive();
        }

        public DataTable checkAllOrderBySellerID(int sellerID)
        {
            order.setSellerID(sellerID);
            return order.selectOrderInfoBySellerID();
        }

        public DataTable checkUnsendOrder()
        {
            return order.checkAllOrderUnSend();
        }

        //顾客对指定订单收货
        public int setOrderReceived(int formID, string state)
        {
            //如果状态为已发货，则允许收货
            if (state.Equals("1") == true)
            {

                return order.setOrderReceived(formID);
            }
            else
            {
                return 0;
            }
        }

        //商家对指定订单发货
        public int setOrderSend(int formID, string state)
        {
            if (state.Equals("0") == true)
            {
                //如果状态为未发货，则允许发货
                return order.setOrderSend(formID);
            }
            else
            {
                return 0;
            }
        }



        //根据不同的卖家生成不同订单
        //customerID: 顾客的ID
        //cartBook: 顾客的购物车信息
        public int generateOrder(int customerID)
        {
            cartBook = new CartBook(customerID);
            DataView dataview = cartBook.getCartBookTable().DefaultView;

            try
            {
                if (dataview.Table.Rows.Count > 0)
                {
                    //根据买家ID对购物车信息排序
                    dataview.Sort = "seller_id DESC";
                    DataTable tableTemp = dataview.ToTable();

                    int i = 0;
                    int index = i;
                    int temp = Convert.ToInt32(tableTemp.Rows[i]["seller_id"]);

                    //遍历表，寻找相同seller_id的数据
                    for (i = 0; i < dataview.Table.Rows.Count - 1; i++)
                    {
                        int id = Convert.ToInt32(tableTemp.Rows[i + 1]["seller_id"]);
                        if (id != temp)
                        {
                            int n = i - index + 1;
                            Book[] book = new Book[n];

                            for (int j = 0; index <= i; index++, j++)
                            {
                                book[j] = new Book();
                                book[j].bookTitle = tableTemp.Rows[index]["book_title"].ToString();
                                book[j].bookID = Convert.ToInt32(tableTemp.Rows[index]["book_id"]);
                                book[j].sellerID = Convert.ToInt32(tableTemp.Rows[index]["seller_id"]);
                                book[j].bookPrice = (float)Convert.ToDouble(tableTemp.Rows[index]["book_price"]);
                                book[j].bookAmount = Convert.ToInt32(tableTemp.Rows[index]["cart_amount"]);
                            }
                           
                            //插入订单
                            order.generateOrder(customerID, book[0].sellerID, book);
                        }
                    }

                    Book[] b = new Book[i - index + 1];

                    for (int j = 0; index <= i; index++, j++)
                    {
                        b[j] = new Book();
                        b[j].bookID = Convert.ToInt32(tableTemp.Rows[index]["book_id"]);
                        b[j].bookTitle = tableTemp.Rows[index]["book_title"].ToString();
                        b[j].sellerID = Convert.ToInt32(tableTemp.Rows[index]["seller_id"]);
                        b[j].bookPrice = (float)Convert.ToDouble(tableTemp.Rows[index]["book_price"]);
                        b[j].bookAmount = Convert.ToInt32(tableTemp.Rows[index]["cart_amount"]);
                    }

                    //提交最后一份订单
                    order.generateOrder(customerID, b[0].sellerID, b);

                    
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return 0;
            }

        }

        
    }
}