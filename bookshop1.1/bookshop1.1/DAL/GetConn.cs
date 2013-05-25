using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace bookShop.DAL
{
    public class GetConn
    {
        private static SqlConnection conn = null;

        public SqlConnection Connection
        {
            get
            {
                if (conn == null)
                {
                    string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    conn = new SqlConnection(conString);
                }

                return conn;
            }
        }

        public SqlConnection Conn { get; set; }
    }

}