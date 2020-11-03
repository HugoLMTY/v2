using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using v2.Models;
using System.Data.Sql;
using System.Data.SqlClient;

namespace v2.Requests
{
    public class Req_User
    {
        public static string getListUser(SqlCommand p_Command)
        {
            p_Command.CommandText = "SELECT * from T_User";
            return p_Command.CommandText;
        }

        public static string getCheckUser(SqlCommand p_Command, Cls_User p_ObjUser)
        {
            p_Command.CommandText = "SELECT * FROM T_User where mail_user =' " + p_ObjUser.Mail_User + "' and pword_user = '" + p_ObjUser.Pword_User + "'";
            return p_Command.CommandText;
        }
    }
}