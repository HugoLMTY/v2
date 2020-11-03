using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using v2.Models;

namespace v2.ADO
{
    public class ADO_Imgproduct
    {
        public static List<Cls_Imgproduct> fct_getUserList(SqlDataReader p_dataReader)
        {
            List<Cls_Imgproduct> v_listImgproduct = new List<Cls_Imgproduct>();
            while (p_dataReader.Read())
            {
                Cls_Imgproduct v_Imgproduct = new Cls_Imgproduct();
                v_Imgproduct.ID_Imgproduct = Convert.ToInt32(p_dataReader["ID_Imgproduct"]);
                v_Imgproduct.Path_Imgproduct = Convert.ToInt32(p_dataReader["Path_Imgproduct"]);
                v_Imgproduct.Name_Imgproduct = Convert.ToInt32(p_dataReader["Name_Imgproduct"]);
                v_listImgproduct.Add(v_Imgproduct);
            }
            return v_listImgproduct;
        }
    }
}