using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Library_Management_System.DAO
{
    public class DatabaseAccess
    {
        public static void ExecuteNonquery(string sql)
        {
            string str = System.Configuration.ConfigurationManager.AppSettings["myconn"];
            SqlConnection myconnection = new SqlConnection(str);
            SqlCommand command = new SqlCommand(sql, myconnection);
            myconnection.Open();
            command.ExecuteNonQuery();
            myconnection.Close();

        }

        public static DataTable ExecuteQuery(string sql)
        {
            string str = System.Configuration.ConfigurationManager.AppSettings["myconn"];
            SqlConnection myconnection = new SqlConnection(str);
            SqlCommand command = new SqlCommand(sql, myconnection);
            myconnection.Open();
            SqlDataAdapter d = new SqlDataAdapter(command);
            DataTable t = new DataTable  ();
            d.Fill(t);
            myconnection.Close();
            return t;
        }

        public static DataSet ExecuteQuery1(string sql)
        {
            string str = System.Configuration.ConfigurationManager.AppSettings["myconn"];
            SqlConnection myconnection = new SqlConnection(str);
            SqlCommand command = new SqlCommand(sql, myconnection);
            myconnection.Open();
            SqlDataAdapter d = new SqlDataAdapter(command);
            DataSet t = new DataSet();
            d.Fill(t);
            myconnection.Close();
            return t;
        }

       
    }
}
