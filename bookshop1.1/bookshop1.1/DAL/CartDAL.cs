using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace bookShop.DAL.DataAcess
{
    public class CartDAL
    {
        private GetConn conn = new GetConn();
        private DataTable cartTable = new DataTable();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private SqlCommandBuilder cmdBuilder;

        //将数据表转换为CartItem数组输出
        public CartItem[] dataTableToCartItem()
        {
            int counts = cartTable.Rows.Count;
            CartItem[] cartItem = new CartItem[counts];

            for (int i = 0; i < counts; i++)
            {
                cartItem[i].bookID = Convert.ToInt32(cartTable.Rows[i]["book_id"]);
                cartItem[i].customerID = Convert.ToInt32(cartTable.Rows[i]["customer_id"]);
                cartItem[i].bookAmount = Convert.ToInt32(cartTable.Rows[i]["cart_amount"]);
            }

            return cartItem;
        }

        //查询指定顾客的购物车信息，并返回Datatable
        public DataTable getCartByCustomerID(int customerID)
        {
            try
            {
                SqlCommand comm = new SqlCommand("sp_Get_Cart", conn.Connection);
                comm.CommandType = CommandType.StoredProcedure;

                comm.Parameters.Add("@customerID", SqlDbType.Int, 11);
                comm.Parameters["@customerID"].Value = customerID;
                comm.Parameters["@customerID"].Direction = System.Data.ParameterDirection.Input;

                adapter.SelectCommand = comm;
                cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Fill(cartTable);

                return cartTable;
                
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

        //向购物车添加一项
        //customerID：指定顾客的ID
        //bookID：向购物车添加的图书的ID
        //amount：添加的书本的数量
        public int addBookToCart(int customerID, int bookID, int amount)
        {
            try
            {
                conn.Connection.Open();

                SqlCommand comm = new SqlCommand("sp_Insert_Cart", conn.Connection);
                comm.CommandType = CommandType.StoredProcedure;

                comm.Parameters.Add("@userID", SqlDbType.Int, 11);
                comm.Parameters["@userID"].Value = customerID;
                comm.Parameters["@userID"].Direction = System.Data.ParameterDirection.Input;

                comm.Parameters.Add("@bookID", SqlDbType.Int, 11);
                comm.Parameters["@bookID"].Value = bookID;
                comm.Parameters["@bookID"].Direction = System.Data.ParameterDirection.Input;

                comm.Parameters.Add("@amount", SqlDbType.Int, 11);
                comm.Parameters["@amount"].Value = amount;
                comm.Parameters["@amount"].Direction = System.Data.ParameterDirection.Input;

                int result = comm.ExecuteNonQuery();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return -1;
            }
            finally
            {
                conn.Connection.Close();
            }
        }

        //清空指定顾客的购物车
        public int clearCart(int customerID)
        {
            try
            {
                conn.Connection.Open();

                SqlCommand comm = new SqlCommand("sp_Clear_Cart", conn.Connection);
                comm.CommandType = CommandType.StoredProcedure;

                comm.Parameters.Add("@userID", SqlDbType.Int, 11);
                comm.Parameters["@userID"].Value = customerID;
                comm.Parameters["@userID"].Direction = System.Data.ParameterDirection.Input;

                int result = comm.ExecuteNonQuery();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return -1;
            }
            finally
            {
                conn.Connection.Close();
            }
        }

        //删除购物车的某一书本
        public int removeBook(int customerID, int bookID)
        {
            try
            {
                conn.Connection.Open();

                SqlCommand comm = new SqlCommand("sp_Delete_Cart_Item", conn.Connection);
                comm.CommandType = CommandType.StoredProcedure;

                comm.Parameters.Add("@customerID", SqlDbType.Int, 11);
                comm.Parameters["@customerID"].Value = customerID;
                comm.Parameters["@customerID"].Direction = System.Data.ParameterDirection.Input;

                comm.Parameters.Add("@bookID", SqlDbType.Int, 11);
                comm.Parameters["@bookID"].Value = bookID;
                comm.Parameters["@bookID"].Direction = System.Data.ParameterDirection.Input;

                int result = comm.ExecuteNonQuery();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return -1;
            }
            finally
            {
                conn.Connection.Close();
            }
        }

        //修改购物车指定图书的数量
        //customerID：指定顾客的ID
        //bookID：要修改的图书ID
        //amount：要修改的书本的数量
        public int changeAmount(int customerID,int bookID, int newAmount)
        {
            try
            {
                conn.Connection.Open();

                SqlCommand comm = new SqlCommand("update cart set cart_amount = @amount "
                    +"where customer_id = @customerID and book_id = @bookID", conn.Connection);

                comm.Parameters.Add("@amount", SqlDbType.Int, 11);
                comm.Parameters["@amount"].Value = newAmount;
                comm.Parameters["@amount"].Direction = System.Data.ParameterDirection.Input;

                comm.Parameters.Add("@customerID", SqlDbType.Int, 11);
                comm.Parameters["@customerID"].Value = customerID;
                comm.Parameters["@customerID"].Direction = System.Data.ParameterDirection.Input;

                comm.Parameters.Add("@bookID", SqlDbType.Int, 11);
                comm.Parameters["@bookID"].Value = bookID;
                comm.Parameters["@bookID"].Direction = System.Data.ParameterDirection.Input;

                int result = comm.ExecuteNonQuery();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                cartTable.RejectChanges();
                return 0;
            }
            finally
            {
                conn.Connection.Close();
            }
        }

    }
}