using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace bookShop.DAL.DataAcess
{
    public class BookDAL
    {
        private GetConn conn = new GetConn();
        private DataTable bookTable = new DataTable();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private SqlCommandBuilder cmdBuilder ;
        

        //将数据表输出为Book数组
        public Book[] DataTableToBook()
        {
            int counts = bookTable.Rows.Count;
            Book[] book = new Book[counts];

            for (int i = 0; i < counts; i++)
            {
                book[i] = new Book();
                book[i].bookID = Convert.ToInt32(bookTable.Rows[i]["book_id"]); 
                book[i].bookTitle = bookTable.Rows[i]["book_title"].ToString();
                book[i].sellerID = Convert.ToInt32(bookTable.Rows[i]["seller_id"]);
                book[i].typeListId = Convert.ToInt32(bookTable.Rows[i]["type_list_id"]);
                book[i].bookAuthor = bookTable.Rows[i]["book_author"].ToString();
                book[i].bookPublisher = bookTable.Rows[i]["book_publisher"].ToString();
                book[i].bookIsbn = bookTable.Rows[i]["book_isbn"].ToString();
                book[i].bookInfo = bookTable.Rows[i]["book_info"].ToString();
                book[i].bookPrice = (float)Convert.ToDouble(bookTable.Rows[i]["book_price"]);
                book[i].bookTime = Convert.ToDateTime(bookTable.Rows[i]["book_time"]);
                book[i].bookAmount = Convert.ToInt32(bookTable.Rows[i]["book_amount"]);
                book[i].isvalid = Convert.ToBoolean(bookTable.Rows[i]["book_isvalid"]);
                book[i].bookImage = bookTable.Rows[i]["book_image"].ToString();
            }

            return book;

        }

        //找出书表最大id号
        public int selectMaxID()
        {
            int maxid = 0;
            try
            {
                
                
                SqlCommand comm = new SqlCommand("select max(book_id) from dbo.book as maxid", conn.Connection);

                conn.Connection.Open();
                SqlDataReader dr = comm.ExecuteReader(CommandBehavior.SingleResult);
                dr.Read();
                maxid = dr.GetInt32(0);
                dr.Close();

                if (maxid > 0)
                {
                    return maxid;
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
            finally
            {
                conn.Connection.Close();
            }
        }

        //根据书本编号查找书本信息，并返回Book类型
        public Book selectBookByID(int bookID)
        {
            try
            {
                bookTable.Clear();
                SqlCommand comm = new SqlCommand("select * from dbo.book where book_id =@bookID", conn.Connection);

                comm.Parameters.Add("@bookID", SqlDbType.Int, 11);
                comm.Parameters["@bookID"].Value = bookID;
                comm.Parameters["@bookID"].Direction = System.Data.ParameterDirection.Input;
               
                adapter.SelectCommand = comm;
                cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Fill(bookTable);

                Book[] book = DataTableToBook();

                if (book.Length > 0)
                {
                    return book[0];
                }
                else
                {
                    return null;
                }
                             
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

        //根据书名查找书本信息，并返回DataTable类型
        public DataTable selectBooksByTitle(string title)
        {
            try
            {
                bookTable.Clear();
                SqlCommand comm = new SqlCommand("dbo.sp_Search_Book_By_Name", conn.Connection);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@title", SqlDbType.VarChar, 50);
                comm.Parameters["@title"].Value = title;
                comm.Parameters["@title"].Direction = System.Data.ParameterDirection.Input;

                adapter.SelectCommand = comm;
                cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Fill(bookTable);

                return bookTable;

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

        //根据作者查找书本信息，并返回DataTable类型
        public DataTable selectBooksByAuthor(string author)
        {
            try
            {
                bookTable.Clear();

                SqlCommand comm = new SqlCommand("dbo.sp_Search_Book_By_Author", conn.Connection);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@author", SqlDbType.VarChar, 50);
                comm.Parameters["@author"].Value = author;
                comm.Parameters["@author"].Direction = System.Data.ParameterDirection.Input;

                adapter.SelectCommand = comm;
                cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Fill(bookTable);

                return bookTable;

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

        //根据出版社查找书本信息，并返回DataTable类型
        public DataTable selectBooksByPublisher(string publisher)
        {
            try
            {
                bookTable.Clear();

                SqlCommand comm = new SqlCommand("sp_Search_Book_By_Publisher", conn.Connection);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@publisher", SqlDbType.VarChar, 50);
                comm.Parameters["@publisher"].Value = publisher;
                comm.Parameters["@publisher"].Direction = System.Data.ParameterDirection.Input;

                adapter.SelectCommand = comm;
                cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Fill(bookTable);

                return bookTable;

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

        //根据ISBN查找书本信息，并返回DataTable类型
        public DataTable selectBooksByISBN(string isbn)
        {
            try
            {
                bookTable.Clear();

                SqlCommand comm = new SqlCommand("dbo.sp_Search_Book_By_ISBN", conn.Connection);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@isbn", SqlDbType.VarChar, 17);
                comm.Parameters["@isbn"].Value = isbn;
                comm.Parameters["@isbn"].Direction = System.Data.ParameterDirection.Input;

                adapter.SelectCommand = comm;
                cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Fill(bookTable);

                return bookTable;

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

        //根据类别查找书本信息，并返回DataTable类型
        public DataTable selectBooksByType(int type)
        {
            try
            {
                bookTable.Clear();

                SqlCommand comm = new SqlCommand("dbo.sp_Get_Books_By_Type", conn.Connection);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@type", SqlDbType.Int);
                comm.Parameters["@type"].Value = type;
                comm.Parameters["@type"].Direction = System.Data.ParameterDirection.Input;

                adapter.SelectCommand = comm;
                cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Fill(bookTable);

                return bookTable;

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

        //查询商家的书本，并返回DataTable类型
        public DataTable selectBooksBySellerID(int sellerID)
        {
            try
            {
                bookTable.Clear();

                SqlCommand comm = new SqlCommand("select * from dbo.book where seller_id = @sellerID", conn.Connection);

                comm.Parameters.Add("@sellerID", SqlDbType.Int);
                comm.Parameters["@sellerID"].Value = sellerID;
                comm.Parameters["@sellerID"].Direction = System.Data.ParameterDirection.Input;
               
                adapter.SelectCommand = comm;  
                cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Fill(bookTable);

                return bookTable;

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

        //查询购物车中的图书信息
        public DataTable getBookInfoInCart(int customerID)
        {
            try
            {
                SqlCommand comm = new SqlCommand("select * from dbo.book where book_id in (select book_id from cart where customer_id = @customer_id)", conn.Connection);

                comm.Parameters.Add("@customer_id", SqlDbType.Int, 11);
                comm.Parameters["@customer_id"].Value = customerID;
                comm.Parameters["@customer_id"].Direction = System.Data.ParameterDirection.Input;

                adapter.SelectCommand = comm;
                cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Fill(bookTable);

                return bookTable;

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

        //按时间查找前N本图书的信息，并返回DataTable类型
        public DataTable selectBooksOfTopN(int n)
        {
            try
            {
                bookTable.Clear();

                SqlCommand comm = new SqlCommand("dbo.sp_Get_New", conn.Connection);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@n", SqlDbType.Int);
                comm.Parameters["@n"].Value = n;
                comm.Parameters["@n"].Direction = System.Data.ParameterDirection.Input;

                adapter.SelectCommand = comm;
                cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Fill(bookTable);

                return bookTable;

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

        //下架一本书
        public int offSelfABook(int bookID)
        {
            try
            {
                conn.Connection.Open();


                SqlCommand comm = new SqlCommand("dbo.sp_Off_Shelf", conn.Connection);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@bookID", SqlDbType.Int);
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

        //上架一本书
        public int onSelfABook(int bookID)
        {
            try
            {
                conn.Connection.Open();

                DataTable dt = new DataTable();

                SqlCommand comm = new SqlCommand("dbo.sp_On_Shelf", conn.Connection);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@bookID", SqlDbType.Int);
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

        //插入一本书
        //book: 要插入图书的信息
        public int insertBook(Book book)
        {
            SqlCommand comm = new SqlCommand("dbo.sp_Insert_Book", conn.Connection);
            int result=0;
            try
            {
                conn.Connection.Open();

                comm.CommandType = CommandType.StoredProcedure;

                comm.Parameters.Add("@sellerID", SqlDbType.Int);
                comm.Parameters["@sellerID"].Value = book.sellerID;
                comm.Parameters["@sellerID"].Direction = System.Data.ParameterDirection.Input;

                comm.Parameters.Add("@typelistID", SqlDbType.Int);
                comm.Parameters["@typelistID"].Value = book.typeListId;
                comm.Parameters["@typelistID"].Direction = System.Data.ParameterDirection.Input;

                comm.Parameters.Add("@title", SqlDbType.Char,50);
                comm.Parameters["@title"].Value = book.bookTitle;
                comm.Parameters["@title"].Direction = System.Data.ParameterDirection.Input;

                comm.Parameters.Add("@author", SqlDbType.Char,50);
                comm.Parameters["@author"].Value = book.bookAuthor;
                comm.Parameters["@author"].Direction = System.Data.ParameterDirection.Input;

                comm.Parameters.Add("@publisher", SqlDbType.Char, 50);
                comm.Parameters["@publisher"].Value = book.bookPublisher;
                comm.Parameters["@publisher"].Direction = System.Data.ParameterDirection.Input;

                comm.Parameters.Add("@isbn", SqlDbType.Char, 17);
                comm.Parameters["@isbn"].Value = book.bookIsbn;
                comm.Parameters["@isbn"].Direction = System.Data.ParameterDirection.Input;

                comm.Parameters.Add("@bookInfo", SqlDbType.Text);
                comm.Parameters["@bookInfo"].Value = book.bookInfo;
                comm.Parameters["@bookInfo"].Direction = System.Data.ParameterDirection.Input;

                comm.Parameters.Add("@price", SqlDbType.Money);
                comm.Parameters["@price"].Value = book.bookPrice;
                comm.Parameters["@price"].Direction = System.Data.ParameterDirection.Input;

                comm.Parameters.Add("@amount", SqlDbType.Int);
                comm.Parameters["@amount"].Value = book.bookAmount;
                comm.Parameters["@amount"].Direction = System.Data.ParameterDirection.Input;

                comm.Parameters.Add("@isvalid", SqlDbType.Bit);
                comm.Parameters["@isvalid"].Value = book.isvalid;
                comm.Parameters["@isvalid"].Direction = System.Data.ParameterDirection.Input;

                comm.Parameters.Add("@imagePath", SqlDbType.Char,100);
                comm.Parameters["@imagePath"].Value = book.bookImage;
                comm.Parameters["@imagePath"].Direction = System.Data.ParameterDirection.Input;

                result = comm.ExecuteNonQuery();
                

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
               
            }
            finally
            {
                conn.Connection.Close();
            }
            return result;
        }

        //修改图书信息
        //bookID:
        //book: 要修改的内容
        public int modifyBook(Book book)
        {
            try
            {
                conn.Connection.Open();


                SqlCommand comm = new SqlCommand("dbo.sp_Update_Book", conn.Connection);
                comm.CommandType = CommandType.StoredProcedure;

                comm.Parameters.Add("@bookID", SqlDbType.Int);
                comm.Parameters["@bookID"].Value = book.bookID;
                comm.Parameters["@bookID"].Direction = System.Data.ParameterDirection.Input;

                comm.Parameters.Add("@typelistID", SqlDbType.Int);
                comm.Parameters["@typelistID"].Value = book.typeListId;
                comm.Parameters["@typelistID"].Direction = System.Data.ParameterDirection.Input;

                comm.Parameters.Add("@title", SqlDbType.Char, 50);
                comm.Parameters["@title"].Value = book.bookTitle;
                comm.Parameters["@title"].Direction = System.Data.ParameterDirection.Input;

                comm.Parameters.Add("@author", SqlDbType.Char, 50);
                comm.Parameters["@author"].Value = book.bookAuthor;
                comm.Parameters["@author"].Direction = System.Data.ParameterDirection.Input;

                comm.Parameters.Add("@publisher", SqlDbType.Char, 50);
                comm.Parameters["@publisher"].Value = book.bookPublisher;
                comm.Parameters["@publisher"].Direction = System.Data.ParameterDirection.Input;

                comm.Parameters.Add("@isbn", SqlDbType.Char, 17);
                comm.Parameters["@isbn"].Value = book.bookIsbn;
                comm.Parameters["@isbn"].Direction = System.Data.ParameterDirection.Input;

                comm.Parameters.Add("@bookInfo", SqlDbType.Text);
                comm.Parameters["@bookInfo"].Value = book.bookInfo;
                comm.Parameters["@bookInfo"].Direction = System.Data.ParameterDirection.Input;

                comm.Parameters.Add("@price", SqlDbType.Money);
                comm.Parameters["@price"].Value = book.bookPrice;
                comm.Parameters["@price"].Direction = System.Data.ParameterDirection.Input;

                comm.Parameters.Add("@amount", SqlDbType.Int);
                comm.Parameters["@amount"].Value = book.bookAmount;
                comm.Parameters["@amount"].Direction = System.Data.ParameterDirection.Input;

                comm.Parameters.Add("@imagePath", SqlDbType.Char, 100);
                comm.Parameters["@imagePath"].Value = book.bookImage;
                comm.Parameters["@imagePath"].Direction = System.Data.ParameterDirection.Input;

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
    }
}