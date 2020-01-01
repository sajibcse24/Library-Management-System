using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Library_Management_System.DAO;

namespace Library_Management_System.Service
{
  public   class Teacher
    {
      public Teacher() { }
      private string name;

      public string Name
      {
          get { return name; }
          set { name = value; }
      }
      

   
      private string dept;

      public string Dept
      {
          get { return dept; }
          set { dept = value; }
      }
  

      private string email;

      public string Email
      {
          get { return email; }
          set { email = value; }
      }
      private string lcard;

      public string Lcard
      {
          get { return lcard; }
          set { lcard = value; }
      }
      private string mailaddress;

      public string Mailaddress
      {
          get { return mailaddress; }
          set { mailaddress = value; }
      }
      private string paddress;

      public string Paddress
      {
          get { return paddress; }
          set { paddress = value; }
      }
      private string image;

      public string Image
      {
          get { return image; }
          set { image = value; }
      }
      private string utype;

      public string Utype
      {
          get { return utype; }
          set { utype = value; }
      }
      private string join_of_date;

      public string Join_of_date
      {
          get { return join_of_date; }
          set { join_of_date = value; }
      }

      public void Insert()
      {
          string sql = "INSERT INTO [member](name,dept,email,cno,maddress,paddress,photo,utype,join_date)VALUES ('" + this.Name + "','" + this.Dept + "','" + this.Email + "','" + this.Lcard + "','" + this.Mailaddress + "','" + this.Paddress + "','" + this.Image + "' ,'" + this.Utype + "','" + this.Join_of_date + "')";
          DatabaseAccess.ExecuteNonquery(sql);
      }

      public DataTable Checkinfo(string name,string card)               //delete 
      {

          DataTable dt = new DataTable();
          string sql = "select * FROM [teacher] WHERE cno='" + this.Lcard + "' and utype='" + this.Utype + "' ";
          dt = DatabaseAccess.ExecuteQuery(sql);
          return dt;
      }


    }
}
