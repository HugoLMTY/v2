using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using v2.Models;

namespace v2.ADO
{
    public class ADO_Basket
    {
        public static List<Cls_Basket> fct_getBasketList(SqlDataReader p_dataReader)
        {
            List<Cls_Basket> v_listBasket = new List<Cls_Basket>();
            while (p_dataReader.Read())
            {
                Cls_Basket v_Basket = new Cls_Basket();
                v_Basket.ID_Basket = Convert.ToInt32(p_dataReader["ID_Basket"]);
                v_Basket.Qty_Basket = Convert.ToInt32(p_dataReader["Qty_Basket"]);
                v_Basket.ID_User = Convert.ToInt32(p_dataReader["ID_User"]);
                v_Basket.Status_Basket = Convert.ToString(p_dataReader["Status_Basket"]);
                v_listBasket.Add(v_Basket);
            }
            return v_listBasket;
        }
    }
}