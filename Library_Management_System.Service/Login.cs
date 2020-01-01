using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Library_Management_System.DAO;
using System.Configuration;
using System.Data.SqlClient;

namespace Library_Management_System.Service
{
   public  class Login
    {
        public Login()
        {
            Uname = String.Empty;
            Pass = String.Empty;

        }

        private string uname;

        public string Uname
        {
            get { return uname; }
            set { uname = value; }
        }
        private string pass;

        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }
        private string utype;

        public string Utype
        {
            get { return utype; }
            set { utype = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public DataTable LoadAccount(string utype, string uname, string pass)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * from login where utype='" + utype + "' and uname='" + uname + "' and pass='" + pass+ "'";
            dt = DatabaseAccess.ExecuteQuery(sql);
            return dt;

        }

        public void Insert()
        {
            string sql = "INSERT INTO [login](uname,pass,utype,email)VALUES ('" + this.Uname + "','" + this.Pass + "','" + this.Utype + "','" + this.Email + "')";
            DatabaseAccess.ExecuteNonquery(sql);
        }

        public DataTable LoadPass(string uname)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * from login where email='" + uname + "' ";
            dt = DatabaseAccess.ExecuteQuery(sql);
            return dt;

        }

        public DataTable LoadPass1(string uname)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * from login where uname='" + uname + "' ";
            dt = DatabaseAccess.ExecuteQuery(sql);
            return dt;

        }

        public DataTable Account(string email,string uname, string pass)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * from login where email='" + email + "'and uname='" + uname + "' and pass='" + pass + "' ";
            dt = DatabaseAccess.ExecuteQuery(sql);
            return dt;

        }

        public void updateaccount()          // update student
        {

            string Query = "UPDATE [login] SET utype='" + this.Utype + "',uname='" + this.Uname + "',pass='" + this.Pass + "' where email='" + this.Email + "' ";
            DatabaseAccess.ExecuteNonquery(Query);


          
        }

    }
}
