using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace bookShop.DAL.DataAcess
{
    public class OrderDAL
    {
        private GetConn conn = new GetConn();
        private SqlTransaction myTrans = null;
        private DataTable orderTable;
        private int customerID = new int();
        private int sellerID = new int();

        public OrderDAL()
        {
            customerID = -1;
            sellerID = -1;
        }

        public OrderDAL(int id)
        {
            customerID = id;
            sellerID = id;
        }

        public void setCustomerID(int id){
            customerID = id;
        }

        public void setSellerID(int id)
        {
            sellerID = id;
        }

        public DataTable getOrderTable()
        {
            return orderTable;
        }

        //查找指定顾客的所有订单信息
        public DataTable selectOrderInfoByCustomerID()
        {
            if (customerID == -1)
            {
                return null;
            }

            try
            {
                orderTable = new DataTable();

                SqlCommand comm = new SqlCommand("select order_form_id,customer_name,"
                    + "seller_name,customer_address,order_form_time,order_form_state "
                    + "from order_form,customer,seller "
                    + "where order_form.seller_id = seller.seller_id "
                    + "and order_form.customer_id = customer.customer_id "
                    + "and order_form.customer_id = @customerID", conn.Connection);

                comm.Parameters.Add("@customerID", SqlDbType.Int, 11);
                comm.Parameters["@customerID"].Value = customerID;
                comm.Parameters["@customerID"].Direction = System.Data.ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                adapter.Fill(orderTable);

                return orderTable;

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

        //查找指定商家的所有订单信息
        public DataTable selectOrderInfoBySellerID()
        {
            if (sellerID == -1)
            {
                return null;
            }

            try
            {
                orderTable = new DataTable();

                SqlCommand comm = new SqlCommand("select order_form_id,customer_name,"
                    + "seller_name,customer_address,order_form_time,order_form_state "
                    + "from order_form,customer,seller "
                    + "where order_form.seller_id = seller.seller_id "
                    + "and order_form.customer_id = customer.customer_id "
                    + "and order_form.seller_id = @sellerID", conn.Connection);

                comm.Parameters.Add("@sellerID", SqlDbType.Int, 11);
                comm.Parameters["@sellerID"].Value = sellerID;
                comm.Parameters["@sellerID"].Direction = System.Data.ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                adapter.Fill(orderTable);

                return orderTable;

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

        //查看所有未收货订单列表
        public DataTable checkAllOrderUnReceive()
        {
            try
            {
                if (orderTable == null)
                {
                    return null;
                }

                DataView dataview = new DataView();
                dataview = orderTable.DefaultView;
                dataview.RowFilter = "order_form_state != '2'";

                return dataview.Table;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        //查看所有未发货订单列表
        public DataTable checkAllOrderUnSend()
        {
            try
            {
                if (orderTable == null)
                {
                    return null;
                }

                DataView dataview = new DataView();
                dataview = orderTable.DefaultView;
                dataview.RowFilter = "order_form_state = '0'";

                return dataview.Table;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        ////查看指定顾客所有订单列表
        //public DataTable checkAllOrderByCustomerID(int customerID)
        //{
        //    try
        //    {
        //        orderTable.Clear();

        //        SqlCommand comm = new SqlCommand("sp_cGet_All_Order", conn.Connection);
        //        comm.CommandType = CommandType.StoredProcedure;
        //        comm.Parameters.Add("@customerID", SqlDbType.Int, 11);
        //        comm.Parameters["@customerID"].Value = customerID;
        //        comm.Parameters["@customerID"].Direction = System.Data.ParameterDirection.Input;

        //        SqlDataAdapter adapter = new SqlDataAdapter(comm);
        //        adapter.Fill(orderTable);

        //        return orderTable;

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.ToString());
        //        return null;
        //    }
        //    finally
        //    {
        //        conn.Connection.Close();
        //    }
        //}

        ////查看顾客未收货订单列表
        //public DataTable checkUnReceiveOrderByCustomerID(int customerID)
        //{
        //    try
        //    {
        //        orderTable.Clear();

        //        SqlCommand comm = new SqlCommand("sp_sCheck_Order_UnReceive", conn.Connection);
        //        comm.CommandType = CommandType.StoredProcedure;
        //        comm.Parameters.Add("@customer", SqlDbType.Int, 11);
        //        comm.Parameters["@customer"].Value = customerID;
        //        comm.Parameters["@customer"].Direction = System.Data.ParameterDirection.Input;

        //        SqlDataAdapter adapter = new SqlDataAdapter(comm);
        //        adapter.Fill(orderTable);

        //        return orderTable;

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.ToString());
        //        return null;
        //    }
        //    finally
        //    {
        //        conn.Connection.Close();
        //    }
        //}

        ////查看指定商家所有订单列表
        //public DataTable checkAllOrderBySellerID(int sellerID)
        //{
        //    try
        //    {
        //        orderTable.Clear();

        //        SqlCommand comm = new SqlCommand("sp_sGet_All_Order", conn.Connection);
        //        comm.CommandType = CommandType.StoredProcedure;
        //        comm.Parameters.Add("@sellerID", SqlDbType.Int, 11);
        //        comm.Parameters["@sellerID"].Value = sellerID;
        //        comm.Parameters["@sellerID"].Direction = System.Data.ParameterDirection.Input;

        //        SqlDataAdapter adapter = new SqlDataAdapter(comm);
        //        adapter.Fill(orderTable);

        //        return orderTable;

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.ToString());
        //        return null;
        //    }
        //    finally
        //    {
        //        conn.Connection.Close();
        //    }
        //}

        ////查看指定商家所有未发货订单列表
        //public DataTable checkUnsendOrderBySellerID(int sellerID)
        //{
        //    try
        //    {
        //        orderTable.Clear();

        //        SqlCommand comm = new SqlCommand("sp_sCheck_Order_Unsend", conn.Connection);
        //        comm.CommandType = CommandType.StoredProcedure;
        //        comm.Parameters.Add("@sellerID", SqlDbType.Int, 11);
        //        comm.Parameters["@sellerID"].Value = sellerID;
        //        comm.Parameters["@sellerID"].Direction = System.Data.ParameterDirection.Input;

        //        SqlDataAdapter adapter = new SqlDataAdapter(comm);
        //        adapter.Fill(orderTable);

        //        return orderTable;

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.ToString());
        //        return null;
        //    }
        //    finally
        //    {
        //        conn.Connection.Close();
        //    }
        //}

        //将订单状态改为发货

        public int setOrderSend(int formID)
        {
            try
            {
                SqlCommand comm = new SqlCommand("sp_Set_Order_Sent", conn.Connection);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@formID", SqlDbType.Int, 11);
                comm.Parameters["@formID"].Value = formID;
                comm.Parameters["@formID"].Direction = System.Data.ParameterDirection.Input;
                
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

        public string getFormStateByFormID(int formID)
        {
            try
            {
                if (orderTable == null)
                {
                    return null;
                }

                DataView dataview = new DataView();
                dataview = orderTable.DefaultView;
                dataview.RowFilter = "order_form_id = " + formID.ToString();

                return dataview.Table.Rows[0]["order_form_state"].ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        //将订单状态改为收货
        public int setOrderReceived(int formID)
        {
            try
            {
                SqlCommand comm = new SqlCommand("sp_Set_Order_Received", conn.Connection);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@formID", SqlDbType.Int, 11);
                comm.Parameters["@formID"].Value = formID;
                comm.Parameters["@formID"].Direction = System.Data.ParameterDirection.Input;

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

        private int insertOrder(int customerID, int sellerID, SqlTransaction myTrans, SqlConnection con)
        {
            SqlCommand comm = new SqlCommand("sp_Insert_OrderForm",con);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@customerID", SqlDbType.Int, 11);
            comm.Parameters["@customerID"].Value = customerID;
            comm.Parameters["@customerID"].Direction = System.Data.ParameterDirection.Input;

            comm.Parameters.Add("@sellerID", SqlDbType.Int, 11);
            comm.Parameters["@sellerID"].Value = sellerID;
            comm.Parameters["@sellerID"].Direction = System.Data.ParameterDirection.Input;

            SqlParameter rst = comm.Parameters.Add("@identity", SqlDbType.Int, 11);
            comm.Parameters["@identity"].Direction = System.Data.ParameterDirection.ReturnValue;

            comm.Transaction = myTrans;
            comm.ExecuteNonQuery();

            int identity = (int)rst.Value;
            return identity;      
        }
        
        //生成订单
        public int generateOrder(int customerID, int sellerID, Book[] book)
        {
            try
            {
                conn.Connection.Open();
                SqlTransaction myTrans = conn.Connection.BeginTransaction();

                int formID = insertOrder(customerID, sellerID, myTrans, conn.Connection);

                OrderInfoDAL orderInfo = new OrderInfoDAL();

                for (int i = 0; i < book.Length; i++)
                {
                    orderInfo.insertToOrderInfo(formID, book[i].bookID, book[i].bookAmount, book[i].bookPrice, myTrans,conn.Connection);
                }

                for (int i = 0; i < book.Length; i++)
                {
                    SqlCommand comm = new SqlCommand("sp_Delete_Cart_Item", conn.Connection);
                    comm.CommandType = CommandType.StoredProcedure;

                    comm.Parameters.Add("@customerID", SqlDbType.Int, 11);
                    comm.Parameters["@customerID"].Value = customerID;
                    comm.Parameters["@customerID"].Direction = System.Data.ParameterDirection.Input;

                    comm.Parameters.Add("@bookID", SqlDbType.Int, 11);
                    comm.Parameters["@bookID"].Value = book[i].bookID;
                    comm.Parameters["@bookID"].Direction = System.Data.ParameterDirection.Input;

                    comm.Transaction = myTrans;
                    comm.ExecuteNonQuery();
                }

                myTrans.Commit();
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                if (myTrans != null)
                    myTrans.Rollback();
                return 0;
            }
            finally
            {
                conn.Connection.Close();
            }
        }

    }
}