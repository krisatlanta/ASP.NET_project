using System.Data;
using bookShop.DAL;
using bookShop.DAL.DataAcess;

namespace bookShop.BLL
{
    class bookBLL
    {
        public bookBLL()
        {
        }


        //商家插入一本书，已测
        //返回1插入成功，否则失败
        public int insertBook(int sellerID,int typeID,string title,string author,
                                                    string publisher,string isbn,string info,
                                                    float price,int amount,bool valid,string imgpath)
        {
            int result = 0;
            BookDAL bd = new BookDAL();
            Book b = new Book();
            b.sellerID = sellerID;
            b.typeListId = typeID;

            b.bookTitle = title;
            b.bookAuthor = author;
            b.bookAmount = amount;
            b.bookPublisher = publisher;
            b.bookIsbn = isbn;
            b.bookInfo = info;
            b.bookPrice = price;
            b.isvalid = valid;
            b.bookImage = imgpath;
            result = bd.insertBook(b);

            return result;
        }
        //商家修改书本信息，已测
        //返回1修改成功，否则失败
        public int updateBook(int bookID, int typeID, string title, string author,
                                                    string publisher, string isbn, string info,
                                                    float price, int amount, string imgpath)
        {
            int result = 0;
            BookDAL bd = new BookDAL();
            Book b = new Book();
            b.bookID = bookID;
            b.typeListId = typeID;
            b.bookTitle = title;
            b.bookAuthor = author;
            b.bookPublisher = publisher;
            b.bookIsbn = isbn;
            b.bookInfo = info;
            b.bookPrice = price;
            b.bookAmount = amount;
            b.bookImage = imgpath;
            result = bd.modifyBook(b);

            return result;
        }

        //上架一本书，已测
        //成功返回1
        public int onShelfBook(int bookID)
        {
            int result = 0;
            BookDAL ba = new BookDAL();
            result = ba.onSelfABook(bookID);
            return result;
        }

        //下架一本书，已测
        //成功返回1
        public int offShelfBook(int bookID)
        {
            int result = 0;
            BookDAL ba = new BookDAL();
            result = ba.offSelfABook(bookID);
            return result;
        }

        //按要求搜索书,返回DateTable，已测
        //输入搜索类型和搜索关键字
        //搜索类型：1书名搜索，2作者搜索，3出版社搜索，4ISBN搜索
        public DataTable searchBook(int searchType, string key)
        {
            BookDAL ba = new BookDAL();
            if (searchType == 1)
            {
                return ba.selectBooksByTitle(key);
            }
            else
                if (searchType == 2)
                {
                    return ba.selectBooksByAuthor(key);
                }
                else
                    if (searchType == 3)
                    {
                        return ba.selectBooksByPublisher(key);
                    }
                    else
                        if (searchType == 4)
                        {
                            return ba.selectBooksByISBN(key);
                        }
                        else
                            return null;
        }

        //查看一个商家的所有书,已测
        public DataTable getSellerAllBooks(int sellerID)
        {
            BookDAL ba = new BookDAL();
            return ba.selectBooksBySellerID(sellerID);
        }
        //查看所有某个分类的书,已测
        public DataTable getAllBooksAType(int typeID)
        {
            BookDAL ba = new BookDAL();
            return  ba.selectBooksByType(typeID);
        }

        //查看最新N本书，已测
        public DataTable getNewBooks(int n)
        {
            BookDAL ba = new BookDAL();
            return ba.selectBooksOfTopN(n);
        }
        
        


    };
    

}