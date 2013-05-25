using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace bookShop.DAL.DataAcess
{
    public class OrderInfoDAL
    {
        private GetConn conn = new GetConn();
        private DataTable orderInfoTable = new DataTable();

        public OrderInfoDAL()
        {

        }

        public OrderInfoDAL(int formID)
        {
            getInfoByFormID(formID);
        }

        public DataTable getDataTable()
        {
            return orderInfoTable;
        }

        public OrderItem[] dataTableToOrderItem()
        {
            if (orderInfoTable != null)
            {
                OrderItem[] orderItem = new OrderItem[orderInfoTable.Rows.Count];
                for (int i = 0; i < orderInfoTable.Rows.Count; i++)
                {
                    orderItem[i] = new OrderItem();
                    orderItem[i].bookid = Convert.ToInt32(orderInfoTable.Rows[i][0]);
                    orderItem[i].orderamount = Convert.ToInt32(orderInfoTable.Rows[i][2]);
                    orderItem[i].singlePrice = (float)Convert.ToDouble(orderInfoTable.Rows[i][3]);
                }
                return orderItem;
            }
            else
                return null;
        }

        public DataTable getInfoByFormID(int formID)
        {
            try
            {
                orderInfoTable.Clear();
                conn.Connection.Open();

                SqlCommand comm = new SqlCommand("select book.book_id,book_title,book_amount,"
                    + "order_single_price from book,order_info,order_amount where book.book_id = order_info.book_id "
                    + "and order_form_id = @formID", conn.Connection);
                comm.Parameters.Add("@formID", SqlDbType.Int, 11);
                comm.Parameters["@formID"].Value = formID;
                comm.Parameters["@formID"].Direction = System.Data.ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                adapter.Fill(orderInfoTable);

                return orderInfoTable;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
            finally
            {
                conn.Connection.Close();
            }
        }

        public void insertToOrderInfo(int formID, int bookID, int amount, double price, SqlTransaction myTrans, SqlConnection con)
        {    
            SqlCommand comm = new SqlCommand("sp_Insert_OrderInfo",con);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@orderFormID", SqlDbType.Int, 11);
            comm.Parameters["@orderFormID"].Value = formID;
            comm.Parameters["@orderFormID"].Direction = System.Data.ParameterDirection.Input;

            comm.Parameters.Add("@bookID", SqlDbType.Int, 11);
            comm.Parameters["@bookID"].Value = bookID;
            comm.Parameters["@bookID"].Direction = System.Data.ParameterDirection.Input;

            comm.Parameters.Add("@amount", SqlDbType.Int, 11);
            comm.Parameters["@amount"].Value = amount;
            comm.Parameters["@amount"].Direction = System.Data.ParameterDirection.Input;

            comm.Parameters.Add("@price", SqlDbType.Money);
            comm.Parameters["@price"].Value = price;
            comm.Parameters["@price"].Direction = System.Data.ParameterDirection.Input;

            comm.Transaction = myTrans;
            comm.ExecuteNonQuery();

            SqlCommand comm2 = new SqlCommand("update book set book_amount = book_amount - @amount"
                          +" where book_id = @bookID",con);

            comm2.Parameters.Add("@bookID", SqlDbType.Int, 11);
            comm2.Parameters["@bookID"].Value = bookID;
            comm2.Parameters["@bookID"].Direction = System.Data.ParameterDirection.Input;

            comm2.Parameters.Add("@amount", SqlDbType.Int, 11);
            comm2.Parameters["@amount"].Value = amount;
            comm2.Parameters["@amount"].Direction = System.Data.ParameterDirection.Input;

            comm2.Transaction = myTrans;
            comm2.ExecuteNonQuery();
        }

    }
}