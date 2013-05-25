using bookShop.DAL;

using System.Web;

namespace bookShop.BLL
{
    class userBLL
    {
        public userBLL()
        {
        }

        //验证账号密码,已测
        //result[0]返回数字UserID(大于1整数）：登 陆成功 -1：密码错误 -2:账号不存在
        //result[1]登陆成功返回用户角色
        public int[] login(string name ,string psw)
        {
            int[] result = { 0, 0 };
            customerAccess ca = new customerAccess();
            userAccess ua = new userAccess();
            User u = ua.SelectUserByName(name);
            //System.Diagnostics.Debug.WriteLine("我是输入密码" + psw);
            //System.Diagnostics.Debug.WriteLine("我是密码"+u.password);
            //移除空字符；
            string password= u.password.Trim();
            if (u == null)
            { result[0] = -2; return result; }
            if (!psw.Equals(password))
            { result[0] = -1; return result; }
            result[0] = u.userID;
            result[1] = u.role;



            return result;
            
        }

        //修改密码,已测
        public int changePsw(int userID, string password)
        {
            int result;
            userAccess ua = new userAccess();
            result = ua.updatePsw(userID, password);
            return result;
        }


        //注册为商家,已测
        //注册失败返回0，成功返回1
        public int registerAsSeller(string userName, string password, string name,
            string phone, string email, string address)
        {
            int result;
            sellerAccess sa = new sellerAccess();
           result =  sa.insertSeller(userName, password,name,
            phone,email, address);
           return result;
        }
        

        //注册为顾客,已测
        //注册失败返回0，成功返回1
        public int registerAsCustonmer(string userName, string password, string name,
            string phone, string email, string address)
        {
            int result;
            customerAccess ca = new customerAccess();
            result = ca.insertCustomer(userName, password, name,
             phone, email, address);
            return result;
        }

        //验证一个商家,已测
        //验证成功返回1，失败返回0
        public int setSellerValid(int sellerID)
        {
             int result;
            sellerAccess sa = new sellerAccess();
            result = sa.validateSeller(sellerID);
            return result;

        }


        

        //修改顾客信息,已测
        //修改成功返回1，失败返回0
        public int updateCustomer(int customerID, string name, string phone,
                                                              string address, string email)
        {
            customerAccess ca = new customerAccess();
            int result;
            result = ca.updateCustomer(customerID, name, phone,
                                                            address, email);
            return result;
        }

        //修改商家信息,已测
        //修改成功返回1，失败返回0
        public int updateSeller(int sellerID, string name, string phone,
                                                             string address, string email)
        {
            sellerAccess sa = new sellerAccess();
            int result = sa.updateSeller(sellerID, name, phone,
                                                            address, email);
            return result;
        }


    }
}