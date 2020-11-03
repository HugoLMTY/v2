using v2.ADO;
using v2.Models;
using v2.Requests;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace v2.Job
{
    public static class Job_User
    {
        public static List<Cls_User> fct_GetListUser()
        {
            List<Cls_User> v_ObjUser = new List<Cls_User>();
            SqlCommand v_Command = ADO_ConnSQL.fct_CommandAccess();
            if (v_Command != null)
            {
                v_Command.CommandText = Req_User.getListUser(v_Command);
                SqlDataReader v_DataReader = ADO_ConnSQL.fct_GetSqlDataReader(v_Command);
                v_ObjUser = ADO_User.fct_getUserList(v_DataReader);
                Boolean v_CheckOk = ADO_User.fct_CheckListUser(v_ObjUser);
                ADO_ConnSQL.prc_DataReaderClose(v_DataReader, v_Command);
                if (v_CheckOk) { return v_ObjUser; } else { return null; };
            }
            return null;
        }


        public static Cls_User fct_CheckConnectionUser(Cls_User p_ObjUser)
        {
            Cls_User v_ObjUser = new Cls_User();
            SqlCommand v_Command = ADO_ConnSQL.fct_CommandAccess();
            if (v_Command != null)
            {
                v_Command.CommandText = Req_User.getCheckUser(v_Command, p_ObjUser);
                SqlDataReader v_DataReader = ADO_ConnSQL.fct_GetSqlDataReader(v_Command);
                v_ObjUser = ADO_User.fct_GetByIdUser(v_DataReader);
                Boolean v_CheckOk = ADO_User.fct_CheckUser(v_ObjUser);
                ADO_ConnSQL.prc_DataReaderClose(v_DataReader, v_Command);
                if (v_CheckOk) { return v_ObjUser; } else { return null; };
            }
            return v_ObjUser;
        }
    }
}