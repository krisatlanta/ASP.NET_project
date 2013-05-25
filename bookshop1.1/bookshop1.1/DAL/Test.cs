using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace bookShop.DAL
{
    public class Test
    {
        GetConn conn = new GetConn();

        public void test()
        {       
            try
            {
                DataTable dt = new DataTable();
                conn.Connection.Open();

                SqlCommand comm = new SqlCommand("select * from user_login", conn.Connection);
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);

                //将结果存储在DataTable中
                adapter.Fill(dt);

                //对DataTable任意修改
                //....code...
                //dt.Rows[0].Delete();

                //缺少这个就会更新失败
                adapter.UpdateCommand = cmdBuilder.GetUpdateCommand();

                //更新数据库
                adapter.Update(dt);

                dt.AcceptChanges();
            }
            finally
            {
                if (conn.Connection.State == ConnectionState.Open)
                    conn.Connection.Close();
            }
        }

    }


}