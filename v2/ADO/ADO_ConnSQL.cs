using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace v2.ADO
{
    public static class ADO_ConnSQL
    {
        public static string fct_GetConnectionStringSQLServer()
        {
            string v_ConnectionString = @"Data Source = localhost\SQLEXPRESS;Initial Catalog = YN2SC_2;Integrated Security=True";
            return v_ConnectionString;
        }

        public static SqlConnection fct_ConnectionAccess()
        {
            string v_ConnectionString = fct_GetConnectionStringSQLServer();
            SqlConnection v_Connection = fct_GetSqlConnection(v_ConnectionString);
            return v_Connection;
        }

        public static SqlConnection fct_GetSqlConnection(String p_connectionstring)
        {
            SqlConnection v_Connection = new SqlConnection(p_connectionstring);
            Boolean v_ConnectionStateOpen = fct_OpenSqlConnection(v_Connection);
            if (v_ConnectionStateOpen)
            {
                return v_Connection;
            }
            else
            {
                return null;
            }
        }

        private static Boolean fct_OpenSqlConnection(SqlConnection p_Connection)
        {
            p_Connection.Open();
            if (p_Connection.State == ConnectionState.Closed)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static SqlCommand fct_CommandAccess()
        {
            SqlConnection v_Connection = fct_ConnectionAccess();
            SqlCommand v_Command = fct_GetCommandSQL(v_Connection);
            return v_Command;
        }

        public static SqlDataReader fct_GetSqlDataReader(SqlCommand p_Command)
        {
            SqlDataReader v_DataReader = p_Command.ExecuteReader();
            return v_DataReader;
        }

        public static void prc_DataReaderClose(SqlDataReader p_DataReader, SqlCommand p_Command)
        {
            bool v_Ok = false;
            p_DataReader.Close();
            if (p_DataReader.IsClosed)
            {
                if (p_Command.Connection.State == ConnectionState.Open)
                {
                    p_Command.Connection.Close();
                    if (p_Command.Connection.State == ConnectionState.Closed)
                        v_Ok = true;
                }
                else
                {
                    v_Ok = false;
                }
            }
        }

        public static SqlCommand fct_GetCommandSQL(SqlConnection p_Connection)
        {
            SqlCommand v_Command = new SqlCommand();
            v_Command = p_Connection.CreateCommand();
            v_Command.Connection = p_Connection;
            return v_Command;
        }
    }
}