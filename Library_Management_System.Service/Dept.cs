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
  public class Dept
    {
      public Dept() { }
      private string dept_id;

      public string Dept_id
      {
          get { return dept_id; }
          set { dept_id = value; }
      }


      private string dept_name;

      public string Dept_name
      {
          get { return dept_name; }
          set { dept_name = value; }
      }
      private string sup_id;

      public string Sup_id
      {
          get { return sup_id; }
          set { sup_id = value; }
      }
      private string sup_name;

      public string Sup_name
      {
          get { return sup_name; }
          set { sup_name = value; }
      }

      public void Insert()
      {
          string sql = "INSERT INTO [dept](name)VALUES ('" + this.Dept_name + "')";
          DatabaseAccess.ExecuteNonquery(sql);
      }

      public void InsertSup()
      {
          string sql = "INSERT INTO [sup](name)VALUES ('" + this.Sup_name + "')";
          DatabaseAccess.ExecuteNonquery(sql);
      }

      public DataSet DeptName(string id)
      {
          DataSet ds = new DataSet();
          // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
          string sql = "select name as[Deprtment Name],id as[Department ID]from [dept] where name like'" + id + "%'  order by name";
          ds = DatabaseAccess.ExecuteQuery1(sql);
          return ds;
      }

      public DataSet SubName(string id)
      {
          DataSet ds = new DataSet();
          // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
          string sql = "select name as[Supplier Name],id as[Supplier ID]from [sup] where name like'" + id + "%'  order by name";
          ds = DatabaseAccess.ExecuteQuery1(sql);
          return ds;
      }

      public DataTable LoadDept()
      {
          DataTable ds = new DataTable();
          // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
          string sql = "select name from [dept] order by name";
          ds = DatabaseAccess.ExecuteQuery(sql);
          return ds;
      }

      public DataTable LoadSup()
      {
          DataTable ds = new DataTable();
          // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
          string sql = "select name from [sup] order by name";
          ds = DatabaseAccess.ExecuteQuery(sql);
          return ds;
      }

      public void UpdateDept()
      {
          string sql = "UPDATE [dept] SET name='" + this.Dept_name + "' where id='" + this.Dept_id + "'";
          DatabaseAccess.ExecuteNonquery(sql);

      }

      public void UpdateSup()
      {
          string sql = "UPDATE [sup] SET name='" + this.Sup_name + "' where id='" + this.Sup_id + "'";
          DatabaseAccess.ExecuteNonquery(sql);

      }

      public void DeptDel()
      {
          string sql = "DELETE [dept]  where id='" + this.Dept_id + "'";
          DatabaseAccess.ExecuteNonquery(sql);

      }

      public void SupDel()
      {
          string sql = "DELETE [sup]  where id='" + this.Sup_id + "'";
          DatabaseAccess.ExecuteNonquery(sql);

      }


    }
}
