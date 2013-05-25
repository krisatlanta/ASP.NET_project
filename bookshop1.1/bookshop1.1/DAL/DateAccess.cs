using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace bookShop.DAL
{
    //账号表
    public class userAccess
    {
        GetConn conn = new GetConn();
        public userAccess()
        {
           
        }
      
        //返回一个账号项根据账户名
        public User SelectUserByName(string name)
        {
            DataTable dt = new DataTable();
            User u = new User();
            try
            {
                
                    conn.Connection.Open();

                    SqlCommand comm = new SqlCommand("dbo.sp_Select_User_By_Name", conn.Connection);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@userName", SqlDbType.Char, 20);
                comm.Parameters["@userName"].Value = name;
                comm.Parameters["@userName"].Direction = System.Data.ParameterDirection.Input;
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                adapter.Fill(dt);
                int count = dt.Rows.Count;
                if (count == 0)
                    return null;
                u.userID = (int)dt.Rows[0]["user_id"];
                u.userName = dt.Rows[0]["user_name"].ToString();
                u.password = dt.Rows[0]["password"].ToString();
                u.role = (int)dt.Rows[0]["role"];
                
                
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.ToString());
            }
            finally
            {

                
                    conn.Connection.Close();
            }
            return u;
        }

        //修改密码
        public int updatePsw(int id, string newPsw)
        {
            int counts = 0;
            try
            {
                
                    conn.Connection.Open();
                    SqlCommand comm = new SqlCommand("dbo.sp_Reset_Psw", conn.Connection);
                comm.CommandType = CommandType.StoredProcedure;

                comm.Parameters.Add("@userID", SqlDbType.Int, 255);
                comm.Parameters["@userID"].Value = id;
                comm.Parameters["@userID"].Direction = System.Data.ParameterDirection.Input;
                comm.Parameters.Add("@newpsw", SqlDbType.Char,20);
                comm.Parameters["@newpsw"].Value = id;
                comm.Parameters["@newpsw"].Direction = System.Data.ParameterDirection.Input;
                counts = comm.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
               
                    conn.Connection.Close();
            }
            return counts;
        }
    }


    //顾客信息表
    public class customerAccess
    {
        GetConn conn = new GetConn();
        public customerAccess()
        {
            
        }
        

        //插入新的顾客(这里也涉及了对user表的操作)
        public int insertCustomer(string userName,string password,string name,
            string phone,string email,string address)
        {

            SqlCommand comm = new SqlCommand("dbo.sp_Insert_Customer", conn.Connection);
             int counts=0;
             try
             {
                 
                  conn.Connection.Open();
                 comm.CommandType = CommandType.StoredProcedure;
                 comm.Parameters.Add("@user_name", SqlDbType.Char, 20);
                 comm.Parameters["@user_name"].Value = userName;
                 comm.Parameters["@user_name"].Direction = System.Data.ParameterDirection.Input;
                 comm.Parameters.Add("@password", SqlDbType.Char, 20);
                 comm.Parameters["@password"].Value = password;
                 comm.Parameters["@password"].Direction = System.Data.ParameterDirection.Input;
                 comm.Parameters.Add("@Name", SqlDbType.Char, 20);
                 comm.Parameters["@Name"].Value = name;
                 comm.Parameters["@Name"].Direction = System.Data.ParameterDirection.Input;
                 comm.Parameters.Add("@Phone", SqlDbType.Char, 13);
                 comm.Parameters["@Phone"].Value = phone;
                 comm.Parameters["@Phone"].Direction = System.Data.ParameterDirection.Input;
                 comm.Parameters.Add("Email", SqlDbType.VarChar, 50);
                 comm.Parameters["Email"].Value = email;
                 comm.Parameters["Email"].Direction = System.Data.ParameterDirection.Input;
                 comm.Parameters.Add("@Address", SqlDbType.VarChar, 255);
                 comm.Parameters["@Address"].Value = address;
                 comm.Parameters["@Address"].Direction = System.Data.ParameterDirection.Input;
                 counts = comm.ExecuteNonQuery();
             }
             catch (SqlException ex)
             {

                 Console.WriteLine(ex.ToString());
             }
             finally
             {
                 
                     conn.Connection.Close();
                 
             }
             return counts;
        }

        //取出所有顾客信息到Datatable
        public DataTable SelectCustomerAll()
        {
            DataTable dt = new DataTable();
            try
             {
            
                conn.Connection.Open();

                SqlCommand comm = new SqlCommand("Select_All_Customer", conn.Connection);
            comm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(comm);
            adapter.Fill(dt);
                 }
             catch (SqlException ex)
             {

                 Console.WriteLine(ex.ToString());
             }
             finally
             {
           
                conn.Connection.Close();
            }
            return dt;
        }

        //返回一个顾客信息
        public Customer SelectComstomerById(int id)
        {
            Customer c = new Customer();
            DataTable dt = new DataTable();
            try
             {
            
                conn.Connection.Open();

                SqlCommand comm = new SqlCommand("dbo.sp_Select_Seller_By_Id", conn.Connection);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("@customer_id", SqlDbType.Int, 4);
            comm.Parameters["@customer_id"].Value = id;
            comm.Parameters["@customer_id"].Direction = System.Data.ParameterDirection.Input;
            SqlDataAdapter adapter = new SqlDataAdapter(comm);
            adapter.Fill(dt);
            c.Id= (int)dt.Rows[0]["customer_id"];
            c.name = dt.Rows[0]["customer_name"].ToString();
            c.phone = dt.Rows[0]["customer_phone"].ToString();
            c.email = dt.Rows[0]["customer_email"].ToString();
            c.address = dt.Rows[0]["customer_address"].ToString();
              }
             catch (SqlException ex)
             {

                 Console.WriteLine(ex.ToString());
             }
             finally
             {

            
                conn.Connection.Close();
            }
            return c;
        }

        //修改一个顾客信息
        public int updateCustomer(int customerID,string name,string phone,
                                                              string address,string email)
        {
            int counts=0;
            try
            {
                
                    conn.Connection.Open();
                    SqlCommand comm = new SqlCommand("dbo.sp_Update_Customer", conn.Connection);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@customerID", SqlDbType.Int,4);
                comm.Parameters["@customerID"].Value = customerID;
                comm.Parameters["@customerID"].Direction = System.Data.ParameterDirection.Input;
                comm.Parameters.Add("@customerName", SqlDbType.Char, 20);
                comm.Parameters["@customerName"].Value = name;
                comm.Parameters["@customerName"].Direction = System.Data.ParameterDirection.Input;
                comm.Parameters.Add("@customerPhone", SqlDbType.Char, 13);
                comm.Parameters["@customerPhone"].Value = phone;
                comm.Parameters["@customerPhone"].Direction = System.Data.ParameterDirection.Input;
                comm.Parameters.Add("@customerEmail", SqlDbType.VarChar, 50);
                comm.Parameters["@customerEmail"].Value = email;
                comm.Parameters["@customerEmail"].Direction = System.Data.ParameterDirection.Input;
                comm.Parameters.Add("@customerAddress", SqlDbType.VarChar, 255);
                comm.Parameters["@customerAddress"].Value = address;
                comm.Parameters["@customerAddress"].Direction = System.Data.ParameterDirection.Input;
                counts = comm.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
               
                    conn.Connection.Close();
            }
            return counts;
        }

        
    }

    //商家信息表
    public class sellerAccess
    {
        GetConn conn = new GetConn();
        public sellerAccess()
        {
            
        }
        

        //插入新的商家
        public int insertSeller(string userName, string password, string name,
            string phone, string email, string address)
        {

            SqlCommand comm = new SqlCommand("dbo.sp_Insert_Seller",conn.Connection);
            int counts = 0;
            try
            {
                
                    conn.Connection.Open();
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@user_name", SqlDbType.Char, 20);
                comm.Parameters["@user_name"].Value = userName;
                comm.Parameters["@user_name"].Direction = System.Data.ParameterDirection.Input;
                comm.Parameters.Add("@password", SqlDbType.Char, 20);
                comm.Parameters["@password"].Value = password;
                comm.Parameters["@password"].Direction = System.Data.ParameterDirection.Input;
                comm.Parameters.Add("@Name", SqlDbType.Char, 20);
                comm.Parameters["@Name"].Value = name;
                comm.Parameters["@Name"].Direction = System.Data.ParameterDirection.Input;
                comm.Parameters.Add("@Phone", SqlDbType.Char, 13);
                comm.Parameters["@Phone"].Value = phone;
                comm.Parameters["@Phone"].Direction = System.Data.ParameterDirection.Input;
                comm.Parameters.Add("Email", SqlDbType.VarChar, 50);
                comm.Parameters["Email"].Value = email;
                comm.Parameters["Email"].Direction = System.Data.ParameterDirection.Input;
                comm.Parameters.Add("@Address", SqlDbType.VarChar, 255);
                comm.Parameters["@Address"].Value = address;
                comm.Parameters["@Address"].Direction = System.Data.ParameterDirection.Input;
                counts = comm.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.ToString());
            }
            finally
            {
                
                    conn.Connection.Close();

            }
            return counts;
        }

        //取出所有商家信息到Datatable
        public DataTable SelectSellerAll()
        {
            DataTable dt = new DataTable();
            try
            {
                
                    conn.Connection.Open();

                    SqlCommand comm = new SqlCommand("dbo.sp_Select_All_Seller", conn.Connection);
                comm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                adapter.Fill(dt);
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.ToString());
            }
            finally
            {
                
                    conn.Connection.Close();
            }
            return dt;
        }


        //返回一个商家信息
        public Seller SelectSellerById(int id)
        {
            Seller s = new Seller();
            DataTable dt = new DataTable();
            try
            {
                if (conn.Connection.State == ConnectionState.Closed)
                    conn.Connection.Open();

                SqlCommand comm = new SqlCommand("dbo.sp_Select_Seller_By_Id", conn.Connection);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@seller_id", SqlDbType.Int, 4);
                comm.Parameters["@seller_id"].Value = id;
                comm.Parameters["@seller_id"].Direction = System.Data.ParameterDirection.Input;
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                adapter.Fill(dt);
                s.Id = (int)dt.Rows[0]["seller_id"];
                s.name = dt.Rows[0]["seller_name"].ToString();
                s.phone = dt.Rows[0]["seller_phone"].ToString();
                s.email = dt.Rows[0]["seller_email"].ToString();
                s.address = dt.Rows[0]["seller_address"].ToString();
                s.isValid = (bool)dt.Rows[0]["seller_isValid"];
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.ToString());
            }
            finally
            {

                if (conn.Connection.State == ConnectionState.Open)
                    conn.Connection.Close();
            }
            return s;
        }

        //修改一个商家信息
        public int updateSeller(int sellerID, string name, string phone,
                                                              string address, string email)
        {
            int counts = 0;
            try
            {
                
                    conn.Connection.Open();
                    SqlCommand comm = new SqlCommand("dbo.sp_Update_Seller", conn.Connection);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@sellerID", SqlDbType.Int, 4);
                comm.Parameters["@sellerID"].Value = sellerID;
                comm.Parameters["@sellerID"].Direction = System.Data.ParameterDirection.Input;
                comm.Parameters.Add("@sellerName", SqlDbType.Char, 20);
                comm.Parameters["@sellerName"].Value = name;
                comm.Parameters["@sellerName"].Direction = System.Data.ParameterDirection.Input;
                comm.Parameters.Add("@sellerPhone", SqlDbType.Char, 13);
                comm.Parameters["@sellerPhone"].Value = phone;
                comm.Parameters["@sellerPhone"].Direction = System.Data.ParameterDirection.Input;
                comm.Parameters.Add("@sellerEmail", SqlDbType.VarChar, 50);
                comm.Parameters["@sellerEmail"].Value = email;
                comm.Parameters["@sellerEmail"].Direction = System.Data.ParameterDirection.Input;
                comm.Parameters.Add("@sellerAddress", SqlDbType.VarChar, 255);
                comm.Parameters["@sellerAddress"].Value = address;
                comm.Parameters["@sellerAddress"].Direction = System.Data.ParameterDirection.Input;
                counts = comm.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                
                    conn.Connection.Close();
            }
            return counts;
        }

        //验证一个商家
        public int validateSeller(int sellerID)
        {
            int counts = 0;
            try
            {
                
                    conn.Connection.Open();
                    SqlCommand comm = new SqlCommand("dbo.sp_Set_Seller_Valid", conn.Connection);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@sellerID", SqlDbType.Int, 4);
                comm.Parameters["@sellerID"].Value = sellerID;
                comm.Parameters["@sellerID"].Direction = System.Data.ParameterDirection.Input;
                counts = comm.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {

                conn.Connection.Close();
            }
            return counts;
        }

    }

}