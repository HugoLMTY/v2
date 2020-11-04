using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using v2.Models;

namespace v2.ADO
{
    public class ADO_User
    {
        public static List<Cls_User> fct_getUserList(SqlDataReader p_dataReader)
        {
            List<Cls_User> v_listUser = new List<Cls_User>();
            while (p_dataReader.Read())
            {
                Cls_User v_User = new Cls_User();
                v_User.ID_User = Convert.ToInt32(p_dataReader["ID_User"]);
                v_User.Name_User = Convert.ToString(p_dataReader["Name_User"]);
                v_User.Firstname_User = Convert.ToString(p_dataReader["Firstname_User"]);
                v_User.Type_user = Convert.ToString(p_dataReader["Type_user"]);
                v_User.Mail_User = Convert.ToString(p_dataReader["Mail_User"]);
                v_User.Age_User = Convert.ToInt32(p_dataReader["Age_User"]);
                v_User.Adress_User = Convert.ToString(p_dataReader["Adress_User"]);
                v_User.Tel_User = Convert.ToInt32(p_dataReader["Tel_User"]);
                v_User.Pword_User = Convert.ToString(p_dataReader["Pword_User"]);
                v_listUser.Add(v_User);
            }
            return v_listUser;
        }

        public static Boolean fct_CheckListUser(List<Cls_User> p_ListUser)
        {
            Boolean v_CheckOk;
            if (p_ListUser.Count > 0)
            {
                v_CheckOk = true;
                //Gestion d'erreur à ajouter
            }
            else
            {
                v_CheckOk = false;
            }
            return v_CheckOk;
        }

        public static Boolean fct_CheckUser(Cls_User p_ObjUser)
        {
            Boolean v_CheckOk;
            if (p_ObjUser != null)
            {
                if (p_ObjUser.ID_User > 0)
                {
                    v_CheckOk = true;
                    //Gestion d'erreur à ajouter
                }
                else
                {
                    v_CheckOk = false;
                }
            }
            else
            {
                v_CheckOk = false;
            }
            return v_CheckOk;
        }

        public static Cls_User fct_GetByIdUser(SqlDataReader p_DataReader)
        {
            Cls_User v_ObjUser = new Cls_User();
            while (p_DataReader.Read())
            {
                v_ObjUser.ID_User = Convert.ToInt32(p_DataReader["ID_user"]);
                v_ObjUser.Name_User = Convert.ToString(p_DataReader["Name_User"]);
                v_ObjUser.Firstname_User = Convert.ToString(p_DataReader["Firstname_User"]);
                v_ObjUser.Mail_User = Convert.ToString(p_DataReader["Mail_User"]);
                v_ObjUser.Age_User = Convert.ToInt32(p_DataReader["Age_User"]);
                v_ObjUser.Adress_User= Convert.ToString(p_DataReader["Adress_User"]);
                v_ObjUser.Tel_User= Convert.ToInt32(p_DataReader["Tel_User"]);
                v_ObjUser.Pword_User= Convert.ToString(p_DataReader["Pword_User"]);
            }

            return v_ObjUser;
        }
    }
}