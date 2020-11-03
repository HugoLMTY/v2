using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using v2.Models;

namespace v2.ADO
{
    public class ADO_Order
    {
        public static List<Cls_Order> fct_getUserList(SqlDataReader p_dataReader)
        {
            List<Cls_Order> v_listOrder = new List<Cls_Order>();
            while (p_dataReader.Read())
            {
                Cls_Order v_Order = new Cls_Order();
                v_Order.Request_Order= Convert.ToString(p_dataReader["ID_Order"]);
                v_Order.Comment_Order = Convert.ToString(p_dataReader["Path_Order"]);
                v_Order.Filepath_Order = Convert.ToString(p_dataReader["Name_Order"]);
                v_Order.Status_Order = Convert.ToString(p_dataReader["Name_Order"]);
                v_listOrder.Add(v_Order);
            }
            return v_listOrder;
        }
    }
}