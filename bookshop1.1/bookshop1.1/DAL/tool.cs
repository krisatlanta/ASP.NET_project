using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace bookShop.DAL
{
    class tool
    {
        //处理格式带有后缀多余0的价格或者添加0
        public string priceFormat(string price)
        {
            string result = price;
            char l=price[0];
            //小数点位置
            int iter = 1;
            if (price.Contains("."))
            {
                while (l != '.')
                {
                    l = price[iter];
                    iter++;
                }


                if (iter < price.Length - 1)
                { iter += 3; result.Remove(iter); }
                else
                    if (iter == price.Length - 1)
                        result += "0";
            }
            else
            {
                result += ".00";
                
            }
            return result;
            

        }

        
        
    }

    

}