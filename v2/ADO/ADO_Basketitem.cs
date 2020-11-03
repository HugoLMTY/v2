using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using v2.Models;

namespace v2.ADO
{
    public class ADO_Basketitem
    {
        public static List<Cls_Basketitem> fct_getUserList(SqlDataReader p_dataReader)
        {
            List<Cls_Basketitem> v_listBasketitem = new List<Cls_Basketitem>();
            while (p_dataReader.Read())
            {
                Cls_Basketitem v_Basketitem = new Cls_Basketitem();
                v_Basketitem.ID_Basketitem = Convert.ToInt32(p_dataReader["ID_Basketitem"]);
                v_Basketitem.ID_Basket = Convert.ToInt32(p_dataReader["ID_Basket"]);
                v_Basketitem.ID_Product = Convert.ToInt32(p_dataReader["ID_Product"]);
                v_Basketitem.Qty_Product = Convert.ToInt32(p_dataReader["Qty_Product"]);
                v_Basketitem.Price_Product = Convert.ToInt32(p_dataReader["Price_Product"]);
                v_listBasketitem.Add(v_Basketitem);
            }
            return v_listBasketitem;
        }
    }
}