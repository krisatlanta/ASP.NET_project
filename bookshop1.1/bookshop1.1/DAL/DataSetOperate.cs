using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace bookShop.DAL
{
    public class DataSetOperate
    {
        // 建立DataTable表间的关系
        // ds: 需要建立关系的DataSet
        // primaryTableName: 主键表名称
        // foreignTableName: 外键表名称
        // primaryColumnName: 主键列名称
        // foreignColumnName: 外键列名称
        public void newRelation(DataSet ds, string primaryTableName, string foreignTableName, 
                             string primaryColumnName, string foreignColumnName)
        {
            DataTable primaryTable = ds.Tables[primaryTableName];
            DataTable foreignTable = ds.Tables[foreignTableName];

            ds.Relations.Add(primaryTableName + foreignTableName, primaryTable.Columns[primaryColumnName], 
                          foreignTable.Columns[foreignColumnName]);
        }

        // 在向外建表DataTabe中增加列
        // ds: 建立好关系的DataSet
        // primaryTableName: 主键表名称
        // foreignTableName: 外键表名称
        // addColumnName: 主键表中列名称
        // newColumnName: 外键表中新增列名称
        public void addColumn(DataSet ds, string primaryTableName, string foreignTableName, 
                            string addColumnName, string newColumnName)
        {
            DataTable primaryTable = ds.Tables[primaryTableName];
            DataTable foreignTable = ds.Tables[foreignTableName];
            DataColumn newColumn = new DataColumn(newColumnName, ds.Tables[primaryTableName].Columns[addColumnName].DataType);
            ds.Tables[foreignTableName].Columns.Add(newColumn);

            int rowCount = ds.Tables[foreignTableName].Rows.Count;

            for (int i = 0; i < rowCount; i++)
            {
                DataRow parentCustomerDR = foreignTable.Rows[i].GetParentRow(primaryTableName + foreignTableName);
                foreignTable.Rows[i][newColumnName] = parentCustomerDR[addColumnName];
            }
        }

    }
}