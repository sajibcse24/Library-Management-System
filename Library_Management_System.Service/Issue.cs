using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Library_Management_System.DAO;

namespace Library_Management_System.Service
{
  public class Issue
    {
      public Issue() { }
      private string accession;

      public string Accession
      {
          get { return accession; }
          set { accession = value; }
      }
      private string title;

      public string Title
      {
          get { return title; }
          set { title = value; }
      }
      private string lcard;

      public string Lcard
      {
          get { return lcard; }
          set { lcard = value; }
      }
      private string issue_date;

      public string Issue_date
      {
          get { return issue_date; }
          set { issue_date = value; }
      }
      private string return_date;

      public string Return_date
      {
          get { return return_date; }
          set { return_date = value; }
      }
      private string icopy;

      public string Icopy
      {
          get { return icopy; }
          set { icopy = value; }
      }
      private string author;

      public string Author
      {
          get { return author; }
          set { author = value; }
      }

      private string fine;

      public string Fine
      {
          get { return fine; }
          set { fine = value; }
      }

      private string payment;

      public string Payment
      {
          get { return payment; }
          set { payment = value; }
      }

      private string cd;

      public string Cd
      {
          get { return cd; }
          set { cd = value; }
      }

      private string mnth;

      public string Mnth
      {
          get { return mnth; }
          set { mnth = value; }
      }
      private string yr;

      public string Yr
      {
          get { return yr; }
          set { yr = value; }
      }
      private string mno;

      public string Mno
      {
          get { return mno; }
          set { mno = value; }
      }
     

      public void Insert()
      {
          string sql = "INSERT INTO [issue](ano,title,author,card,issued,returnd)VALUES ('" + this.Accession + "','" + this.Title + "','" + this.Author+ "','" + this.Lcard + "','" + this.Issue_date + "','" + this.Return_date + "')";
          DatabaseAccess.ExecuteNonquery(sql);
      }

      public void InsertCD()
      {
          string sql = "INSERT INTO [cdissue](cdn,title,author,card,issued,returnd)VALUES ('" + this.Cd + "','" + this.Title + "','" + this.Author + "','" + this.Lcard + "','" + this.Issue_date + "','" + this.Return_date + "')";
          DatabaseAccess.ExecuteNonquery(sql);
      }

      public void InsertFine()
      {


          string sql = "INSERT INTO [fine](date,cno,fine,payment,mno,m,y)VALUES ('" + this.Return_date + "','" + this.Lcard + "','" + this.Fine + "','" + this.Payment + "' ,'" + this.Mno + "','" + this.Mnth + "','" + this.Yr + "')";
          DatabaseAccess.ExecuteNonquery(sql);
          
        
      }

      public DataTable BookTitle(string id)               //delete 
      {

          try
          {
              DataTable dt = new DataTable();
              string sql = "select * FROM [issue] WHERE ano='" + this.Accession + "'  ";
              dt = DatabaseAccess.ExecuteQuery(sql);
              return dt;
          }
          catch (Exception)
          {
              throw;
          }
      }

      public DataTable BookTitleCD(string id)               //delete 
      {

          try
          {
              DataTable dt = new DataTable();
              string sql = "select * FROM [cdissue] WHERE cdn='" + this.Cd + "'  ";
              dt = DatabaseAccess.ExecuteQuery(sql);
              return dt;
          }
          catch (Exception)
          {
              throw;
          }
      }

      public void UpdateCopy()
      {
          string sql = "UPDATE [book] SET icopy='" + this.Icopy + "',acopy=NULL  where ano='" + this.Accession + "'" ;
          DatabaseAccess.ExecuteNonquery(sql);
     
      }

      public void UpdateCopyCD()
      {
          string sql = "UPDATE [cd] SET icopy='" + this.Icopy + "',acopy=NULL  where cdn='" + this.Cd + "'";
          DatabaseAccess.ExecuteNonquery(sql);

      }

     
    

      public void UpdateReturn()
      {
          string sql = "UPDATE [book] SET icopy=NULL,acopy='a'  where ano='" + this.Accession + "'";
          DatabaseAccess.ExecuteNonquery(sql);
      }

      public void UpdateReturnCD()
      {
          string sql = "UPDATE [cd] SET icopy=NULL,acopy='a'  where cdn='" + this.Cd + "'";
          DatabaseAccess.ExecuteNonquery(sql);
      }

      public DataSet searchissue(string id)
      {
          DataSet ds = new DataSet();
          // string sql = "select   title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price],count(*) as [Avilable Copy], dept as[Department] from [book] where title like '" + id + "%' and icopy is null  group by cno,title,author,vol,edition,imprint,isbn,sup,price,dept ";
          string sql = "select ano as [Accession No],title as[Book Title],author as[Author],card as[Member ID],issued as[Date of Issue],returnd as[Date of Return] from [issue] where ano like '" + id + "%' order by ano ";
          
          ds = DatabaseAccess.ExecuteQuery1(sql);
          return ds;
      }

      public DataSet searchissucd(string id)
      {
          DataSet ds = new DataSet();
          // string sql = "select   title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price],count(*) as [Avilable Copy], dept as[Department] from [book] where title like '" + id + "%' and icopy is null  group by cno,title,author,vol,edition,imprint,isbn,sup,price,dept ";
          string sql = "select cdn as [Accession No],title as[CD Title],author as[Author],card as[Member ID],issued as[Date of Issue],returnd as[Date of Return] from [cdissue] where cdn like '" + id + "%' order by cdn ";

          ds = DatabaseAccess.ExecuteQuery1(sql);
          return ds;
      }

      public DataSet searchissuecard(string id)
      {
          DataSet ds = new DataSet();
          // string sql = "select   title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price],count(*) as [Avilable Copy], dept as[Department] from [book] where title like '" + id + "%' and icopy is null  group by cno,title,author,vol,edition,imprint,isbn,sup,price,dept ";
          string sql = "select cdn as [Accession No],title as[CD Title],author as[Author],card as[Member ID],issued as[Date of Issue],returnd as[Date of Return] from [cdissue] where card like '" + id + "%' order by card ";

          ds = DatabaseAccess.ExecuteQuery1(sql);
          return ds;
      }

      public DataSet searchissuecardcd(string id)
      {
          DataSet ds = new DataSet();
          // string sql = "select   title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price],count(*) as [Avilable Copy], dept as[Department] from [book] where title like '" + id + "%' and icopy is null  group by cno,title,author,vol,edition,imprint,isbn,sup,price,dept ";
          string sql = "select cdn as [Accession No],title as[CD Title],author as[Author],card as[Member ID],issued as[Date of Issue],returnd as[Date of Return] from [cdissue] where card like '" + id + "%' order by card ";

          ds = DatabaseAccess.ExecuteQuery1(sql);
          return ds;
      }

      public void DeleteIssue()
      {
          string sql = "DELETE [issue] where ano='" + this.Accession + "'";
          DatabaseAccess.ExecuteNonquery(sql);
      }

      public void DeleteIssueCD()
      {
          string sql = "DELETE [cdissue] where cdn='" + this.Cd + "'";
          DatabaseAccess.ExecuteNonquery(sql);
      }

      public DataSet MemberDetails(string id)               //delete 
      {

          DataSet ds = new DataSet();
          string sql = "select ano as[Accession No],title as [Book Title],author as[Author],issued as[Date Of Issue],returnd as[Date Of Return] FROM [issue] WHERE card='" + id + "'   ";
          ds = DatabaseAccess.ExecuteQuery1(sql);
          return ds;
      }

      public DataTable ReportD(string y1)               //delete 
      {

          DataTable dt = new DataTable();
          string sql = "select date,sum(fine)as total from fine where date='" + y1 + "' group by date  ";
          //string sql = "select item,count(distinct title) as title,count(ano)as total_copy,count(icopy)as total_issue ,count(dcopy) as damage,sum(price)as cost from book group by item ";
          dt = DatabaseAccess.ExecuteQuery(sql);
          return dt;
      }

      public DataTable ReportP(string y1,string y2)               //delete 
      {

          DataTable dt = new DataTable();
          string sql = "select date,sum(fine)as total from fine where date between '" + y1 + "' and '"+ y2+ "' group by date  ";
          //string sql = "select item,count(distinct title) as title,count(ano)as total_copy,count(icopy)as total_issue ,count(dcopy) as damage,sum(price)as cost from book group by item ";
          dt = DatabaseAccess.ExecuteQuery(sql);
          return dt;
      }

      public DataTable ReportM(string y1, string y2)               //delete 
      {

          DataTable dt = new DataTable();
          string sql = "select date,sum(fine)as total from fine where m= '" + y1 + "' and y='" + y2 + "' group by date  ";
          //string sql = "select item,count(distinct title) as title,count(ano)as total_copy,count(icopy)as total_issue ,count(dcopy) as damage,sum(price)as cost from book group by item ";
          dt = DatabaseAccess.ExecuteQuery(sql);
          return dt;
      }

      public DataTable ReportY(string y1, string y2)               //delete 
      {

          DataTable dt = new DataTable();
          string sql = "select m,sum(fine)as total from fine where date between '" + y1 + "' and '" + y2 + "' group by m,mno  ";
          //string sql = "select item,count(distinct title) as title,count(ano)as total_copy,count(icopy)as total_issue ,count(dcopy) as damage,sum(price)as cost from book group by item ";
          dt = DatabaseAccess.ExecuteQuery(sql);
          return dt;
      }
     
    }
}
