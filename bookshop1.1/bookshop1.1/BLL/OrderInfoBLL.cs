using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using bookShop.DAL;
using bookShop.DAL.DataAcess;

namespace bookShop.BLL
{
    public class OrderInfoBLL
    {
        private DataTable dt = new DataTable();
        private OrderInfoDAL orderInfo = new OrderInfoDAL();

        public OrderInfoBLL()
        {

        }

        public OrderInfoBLL(int formID)
        {          
            dt = orderInfo.getInfoByFormID(formID);
        }

        public DataTable getDataTable()
        {
            return dt;
        }

        public DataTable getOrderInfoByFormID(int formID)
        {
            dt = orderInfo.getInfoByFormID(formID);
            return dt;
        }

        //计算订单价钱
        public double computeTotalCost()
        {
            OrderItem[] orderItem = orderInfo.dataTableToOrderItem();

            double cost = 0.0;
            for (int i = 0; i < orderItem.Length; i++)
            {
                cost += (double)orderItem[i].singlePrice * (double)orderItem[i].orderamount;
            }

            return cost;
        }
    }
}