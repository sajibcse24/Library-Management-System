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
    public class Book
    {
        public Book()
        { }
        private string date;

        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        private string accession;

        public string Accession
        {
            get { return accession; }
            set { accession = value; }
        }
        private string call;

        public string Call
        {
            get { return call; }
            set { call = value; }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string author;

        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        private string edition;

        public string Edition
        {
            get { return edition; }
            set { edition = value; }
        }
        private string vol;

        public string Vol
        {
            get { return vol; }
            set { vol = value; }
        }
        private string imprint;

        public string Imprint
        {
            get { return imprint; }
            set { imprint = value; }
        }
        private string supplier;

        public string Supplier
        {
            get { return supplier; }
            set { supplier = value; }
        }
        private string isbn;

        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }
        private string price;

        public string Price
        {
            get { return price; }
            set { price = value; }
        }
        private string copy;

        public string Copy
        {
            get { return copy; }
            set { copy = value; }
        }
        private string dept;

        public string Dept
        {
            get { return dept; }
            set { dept = value; }
        }

        private string acopy;

        public string Acopy
        {
            get { return acopy; }
            set { acopy = value; }
        }

        private string cd;

        public string Cd
        {
            get { return cd; }
            set { cd = value; }
        }

        private string item;

        public string Item
        {
            get { return item; }
            set { item = value; }
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
        private string del;

        public string Del
        {
            get { return del; }
            set { del = value; }
        }

        private string cde;

        public string Cde
        {
            get { return cde; }
            set { cde = value; }
        }
      

        public void Insert()
        {
            string sql = "INSERT INTO [book](item,date1,cno,title,author,vol,edition,imprint,isbn,sup,price,copy,acopy,dept,mno,m,y)VALUES ('" + this.Item + "','" + this.Date + "','" + this.Call + "','" + this.Title + "','" + this.Author + "','" + this.Vol + "','" + this.Edition + "','" + this.Imprint + "','" + this.Isbn + "','" + this.Supplier + "','" + this.Price + "','" + this.Copy + "','" + this.Acopy + "','" + this.Dept + "','" + this.Mno + "','" + this.Mnth + "','" + this.Yr + "')";
            DatabaseAccess.ExecuteNonquery(sql);
        }

        public void InsertJ()
        {
            string sql = "INSERT INTO [journal](item,date1,title,author,imprint,sup,price,copy,acopy,mno,m,y,cno)VALUES ('" + this.Item + "','" + this.Date + "','" + this.Title + "','" + this.Author + "','" + this.Imprint + "','" + this.Supplier + "','" + this.Price + "','" + this.Copy + "','" + this.Acopy + "','" + this.Mno + "','" + this.Mnth + "','" + this.Yr + "','"+this.Call+"')";
            DatabaseAccess.ExecuteNonquery(sql);
        }

        public void InsertM()
        {
            string sql = "INSERT INTO [magazine](item,date1,title,author,imprint,sup,price,copy,acopy,mno,m,y)VALUES ('" + this.Item + "','" + this.Date + "','" + this.Title + "','" + this.Author + "','" + this.Imprint + "','" + this.Supplier + "','" + this.Price + "','" + this.Copy + "','" + this.Acopy + "','" + this.Mno + "','" + this.Mnth + "','" + this.Yr + "','" + this.Call + "')";
            DatabaseAccess.ExecuteNonquery(sql);
        }
        public void InsertR()
        {
            string sql = "INSERT INTO [report](item,date1,title,author,imprint,sup,price,copy,acopy,mno,m,y)VALUES ('" + this.Item + "','" + this.Date + "','" + this.Title + "','" + this.Author + "','" + this.Imprint + "','" + this.Supplier + "','" + this.Price + "','" + this.Copy + "','" + this.Acopy + "','" + this.Mno + "','" + this.Mnth + "','" + this.Yr + "','" + this.Call + "')";
            DatabaseAccess.ExecuteNonquery(sql);
        }

        public void InsertCD()
        {
            string sql = "INSERT INTO [cd](item,date1,ano,cdn,cno,title,author,vol,edition,imprint,isbn,sup,price,copy,acopy,dept,mno,m,y)VALUES ('" + this.Item + "','" + this.Date + "','" + this.Accession + "','" + this.Cd + "','" + this.Call + "','" + this.Title + "','" + this.Author + "','" + this.Vol + "','" + this.Edition + "','" + this.Imprint + "','" + this.Isbn + "','" + this.Supplier + "','" + this.Price + "','" + this.Copy + "','" + this.Acopy + "','" + this.Dept + "','" + this.Mno + "','" + this.Mnth + "','" + this.Yr + "')";
            DatabaseAccess.ExecuteNonquery(sql);
        }


        public void Update()
        {
            string sql = "UPDATE [book] SET cno='" + this.Call + "',title='" + this.Title + "',author='" + this.Author + "',vol='" + this.Vol + "',edition='" + this.Edition + "',imprint='" + this.Imprint + "',isbn='" + this.Isbn + "',sup='" + this.Supplier + "',price='" + this.Price + "',copy='" + this.Copy + "',dept='" + this.Dept + "' where ano='" + this.Accession + "' ";
            DatabaseAccess.ExecuteNonquery(sql);
        }

        public void UpdateJ()
        {
            string sql = "UPDATE [journal] SET cno='" + this.Call + "',title='" + this.Title + "',author='" + this.Author + "',imprint='" + this.Imprint + "',sup='" + this.Supplier + "',price='" + this.Price + "' where ano='" + this.Accession + "' ";
            DatabaseAccess.ExecuteNonquery(sql);
        }

        public void UpdateM()
        {
            string sql = "UPDATE [magazine] SET cno='" + this.Call + "',title='" + this.Title + "',author='" + this.Author + "',imprint='" + this.Imprint + "',sup='" + this.Supplier + "',price='" + this.Price + "' where ano='" + this.Accession + "' ";
            DatabaseAccess.ExecuteNonquery(sql);
        }

        public void UpdateR()
        {
            string sql = "UPDATE [report] SET cno='" + this.Call + "',title='" + this.Title + "',author='" + this.Author + "',imprint='" + this.Imprint + "',sup='" + this.Supplier + "',price='" + this.Price + "' where ano='" + this.Accession + "' ";
            DatabaseAccess.ExecuteNonquery(sql);
        }

        public void UpdateCD()
        {
            string sql = "UPDATE [cd] SET cno='" + this.Call + "',title='" + this.Title + "',author='" + this.Author + "',vol='" + this.Vol + "',edition='" + this.Edition + "',imprint='" + this.Imprint + "',isbn='" + this.Isbn + "',sup='" + this.Supplier + "',price='" + this.Price + "',copy='" + this.Copy + "',dept='" + this.Dept + "' where cdn='" + this.Cd + "' ";
            DatabaseAccess.ExecuteNonquery(sql);
        }
        public DataTable Checkinfo()               //delete 
        {

            DataTable dt = new DataTable();

            string sql = "select ano FROM [book] ";
            dt = DatabaseAccess.ExecuteQuery(sql);
            return dt;
        }

        public DataTable CheckinfoJournal()               //delete 
        {

            DataTable dt = new DataTable();

            string sql = "select ano FROM [journal] ";
            dt = DatabaseAccess.ExecuteQuery(sql);
            return dt;
        }

        public DataTable CheckinfoMagazine()               //delete 
        {

            DataTable dt = new DataTable();

            string sql = "select ano FROM [magazine] ";
            dt = DatabaseAccess.ExecuteQuery(sql);
            return dt;
        }

        public DataTable CheckinfoReport()               //delete 
        {

            DataTable dt = new DataTable();

            string sql = "select ano FROM [report] ";
            dt = DatabaseAccess.ExecuteQuery(sql);
            return dt;
        }

        public DataTable AnnualReport(string y1,string y2)               //delete 
        {

            DataTable dt = new DataTable();
            string sql = "select distinct item ,count(distinct title)as title,count(ano)as total_copy,count(icopy)as total_issue,count(dcopy)as damage,sum(price)as cost from book where date1 between '" + y1 + "' and '" + y2 + "' group by item union select distinct item ,count(distinct title)as title,count(cdn)as total_copy,count(icopy)as total_issue,count(dcopy)as damage,sum(price)as cost from cd where date1 between '" + y1 + "' and '" + y2 + "' group by item union select distinct item ,count(distinct title)as title,count(ano)as total_copy,count(icopy)as total_issue,count(dcopy)as damage,sum(price)as cost from journal where date1 between '" + y1 + "' and '" + y2 + "' group by item union select distinct item ,count(distinct title)as title,count(ano)as total_copy,count(icopy)as total_issue,count(dcopy)as damage,sum(price)as cost from magazine where date1 between '" + y1 + "' and '" + y2 + "' group by item union select distinct item ,count(distinct title)as title,count(ano)as total_copy,count(icopy)as total_issue,count(dcopy)as damage,sum(price)as cost from report where date1 between '" + y1 + "' and '" + y2 + "' group by item";
            //string sql = "select item,count(distinct title) as title,count(ano)as total_copy,count(icopy)as total_issue ,count(dcopy) as damage,sum(price)as cost from book group by item ";
            dt = DatabaseAccess.ExecuteQuery(sql);
            return dt;
        }

     


        public DataTable AnnualReportMonth(string y1, string y2)               //delete 
        {

            DataTable dt = new DataTable();
            string sql = "select distinct item ,count(distinct title)as title,count(ano)as total_copy,count(icopy)as total_issue,count(dcopy)as damage,sum(price)as cost from book where m='" + y1 + "' and y='" + y2 + "' group by item union select distinct item ,count(distinct title)as title,count(cdn)as total_copy,count(icopy)as total_issue,count(dcopy)as damage,sum(price)as cost from cd where m='" + y1 + "' and y='" + y2 + "' group by item union select distinct item ,count(distinct title)as title,count(ano)as total_copy,count(icopy)as total_issue,count(dcopy)as damage,sum(price)as cost from journal where m= '" + y1 + "' and y='"+y2+"'  group by item union select distinct item ,count(distinct title)as title,count(ano)as total_copy,count(icopy)as total_issue,count(dcopy)as damage,sum(price)as cost from magazine where m= '" + y1 + "' and y= '" + y2 + "' group by item union select distinct item ,count(distinct title)as title,count(ano)as total_copy,count(icopy)as total_issue,count(dcopy)as damage,sum(price)as cost from report where m= '" + y1 + "' and y='" + y2 + "' group by item";
            //string sql = "select item,count(distinct title) as title,count(ano)as total_copy,count(icopy)as total_issue ,count(dcopy) as damage,sum(price)as cost from book group by item ";
            dt = DatabaseAccess.ExecuteQuery(sql);
            return dt;
        }

        public DataTable AnnualReportDept(string y1)               //delete 
        {

            DataTable dt = new DataTable();
            string sql = "select distinct item ,count(distinct title)as title,count(ano)as total_copy,count(icopy)as total_issue,count(dcopy)as damage,sum(price)as cost from book where dept='" + y1 + "'  group by item union select distinct item ,count(distinct title)as title,count(cdn)as total_copy,count(icopy)as total_issue,count(dcopy)as damage,sum(price)as cost from cd where dept='" + y1 + "'  group by item ";
            //string sql = "select item,count(distinct title) as title,count(ano)as total_copy,count(icopy)as total_issue ,count(dcopy) as damage,sum(price)as cost from book group by item ";
            dt = DatabaseAccess.ExecuteQuery(sql);
            return dt;
        }


        public DataTable CheckCD(string id)               //delete 
        {

            DataTable dt = new DataTable();
            string sql = "select * FROM [cd] where ano='" + id + "' ";
            dt = DatabaseAccess.ExecuteQuery(sql);
            return dt;
        }

     
        public  DataSet searchtitle1(string id)
        {
            DataSet ds = new DataSet();
           // string sql = "select   title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price],count(*) as [Avilable Copy], dept as[Department] from [book] where title like '" + id + "%' and icopy is null  group by cno,title,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select  title as[Book Title ],author as[Author],count(*)as[Total Copy],count(acopy)as [Available Copy],count(icopy)as[Issued Copy] from [book] where (title like '" + id + "%' or author like '"+id+"%' ) and dcopy is null  group by author,title";
           ds = DatabaseAccess.ExecuteQuery1(sql);
           return ds;
        }

        public DataSet searchBookAll()
        {
            DataSet ds = new DataSet();
            // string sql = "select   title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price],count(*) as [Avilable Copy], dept as[Department] from [book] where title like '" + id + "%' and icopy is null  group by cno,title,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select  title as[Book Title ],author as[Author],count(*)as[Total Copy],count(acopy)as [Available Copy],count(icopy)as[Issued Copy] from [book] where dcopy is null  group by author,title";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }
        public void UpdateExistCD()
        {
            string sql = "UPDATE [book] SET cd='" + this.Cde + "' where ano='" + this.Accession + "'";
            DatabaseAccess.ExecuteNonquery(sql);

        }


        public DataTable  CD(string id)
        {
            DataTable dt = new DataTable();
            string sql = "select book.cno,book.title,book.author,book.vol,book.edition,book.price,book.copy,book.imprint,book.isbn,book.sup,book.dept from [book]  where book.ano='" + id + "' and cd is null ";
            dt = DatabaseAccess.ExecuteQuery(sql);
            return dt;
        }

        public DataSet searchtitle1update(string id)
        {
            DataSet ds = new DataSet();
            // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select  date1 as[Date Of Entry],ano as[Accession No],title as[Book Title],author as[Author], edition as[Edition],cno as[Call No],vol as[Volume], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from[book] where (ano like'" + id + "%' or title like'" + id + "%' or author like'" + id + "%') and dcopy is null order by ano,title,author";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet searchtitle1updateAll()
        {
            DataSet ds = new DataSet();
            // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select  date1 as[Date Of Entry],ano as[Accession No],title as[Book Title],author as[Author], edition as[Edition],cno as[Call No],vol as[Volume], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from[book]  where dcopy is null order by ano";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet searchtitleJ(string id)
        {
            DataSet ds = new DataSet();
            // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select  date1 as[Date Of Entry],ano as[Accession No],title as[Title],author as[Author],  imprint as[Imprint],  sup as[Supplier], price as[Price] from[journal] where title like'" + id + "%' and dcopy is null order by title";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet searchtitleR(string id)
        {
            DataSet ds = new DataSet();
            // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select  date1 as[Date Of Entry], as[Accession No],title as[Title],author as[Author],  imprint as[Imprint],  sup as[Supplier], price as[Price] from[report] where title like'" + id + "%' and dcopy is null order by title";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }
        public DataSet searchtitleM(string id)
        {
            DataSet ds = new DataSet();
            // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select  date1 as[Date Of Entry],ano as[Accession No],title as[Title],author as[Author],  imprint as[Imprint],  sup as[Supplier], price as[Price] from[magazine] where title like'" + id + "%' and dcopy is null order by title";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet searchtitleJA(string id)
        {
            DataSet ds = new DataSet();
            // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select  date1 as[Date Of Entry],ano as[Accession No],title as[Title],author as[Author],  imprint as[Imprint],  sup as[Supplier], price as[Price], from[journal] where ano like'" + id + "%' and dcopy is null order by ano";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }
        public DataSet searchtitleMA(string id)
        {
            DataSet ds = new DataSet();
            // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select  date1 as[Date Of Entry],ano as[Accession No],title as[Title],author as[Author],  imprint as[Imprint],  sup as[Supplier], price as[Price] from[magazine] where ano like'" + id + "%' and dcopy is null order by ano";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet searchtitleRA(string id)
        {
            DataSet ds = new DataSet();
            // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select  date1 as[Date Of Entry],ano as[Accession No],title as[Title],author as[Author],  imprint as[Imprint],  sup as[Supplier], price as[Price] from[report] where ano like'" + id + "%' and dcopy is null order by ano";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet CDT(string id)
        {
            DataSet ds = new DataSet();
            // string sql = "select   title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price],count(*) as [Avilable Copy], dept as[Department] from [book] where title like '" + id + "%' and icopy is null  group by cno,title,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select  title as[CD Title ],author as[Author],count(*)as[Total Copy],count(acopy)as [Available Copy],count(icopy)as[Issued Copy] from [cd] where (title like '" + id + "%'  or author like '"+id+"%') and dcopy is null   group by author,title";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet CDTAll()
        {
            DataSet ds = new DataSet();
            // string sql = "select   title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price],count(*) as [Avilable Copy], dept as[Department] from [book] where title like '" + id + "%' and icopy is null  group by cno,title,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select  title as[CD Title ],author as[Author],count(*)as[Total Copy],count(acopy)as [Available Copy],count(icopy)as[Issued Copy] from [cd] where dcopy is null   group by author,title";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet updateCDT(string id)
        {
            DataSet ds = new DataSet();
            // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select  date1 as[Date Of Entry],cdn as[Accession No],title as[CD Title],author as[Author], edition as[Edition],cno as[Call No],vol as[Volume], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from[cd] where (title like'" + id + "%' or author like'" + id + "%' or cdn like'" + id + "%') and dcopy is null order by cdn";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet updateCDAll()
        {
            DataSet ds = new DataSet();
            // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select  date1 as[Date Of Entry],cdn as[Accession No],title as[CD Title],author as[Author], edition as[Edition],cno as[Call No],vol as[Volume], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from[cd] where dcopy is null order by cdn";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet CDA(string id, string writer)
        {
            DataSet ds = new DataSet();
            // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select distinct date1 as[Date Of Entry],title as[Book Title],author as[Author], edition as[Edition],count(*) as [Total Copy],count(acopy) as [Available Copy],count(icopy) as [Issued Copy],cno as[Call No],vol as[Volume], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from[cd] where title like'" + id + "%' and author like'" + writer + "%' and dcopy is null group by date1,title,author,edition,cno,vol,imprint,isbn,sup,price,dept";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }



        public DataSet searchtitleauthor(string id, string writer)
        {
            DataSet ds = new DataSet();
            // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select distinct date1 as[Date Of Entry],title as[Book Title],author as[Author], edition as[Edition],count(*) as [Total Copy],count(acopy) as [Available Copy],count(icopy) as [Issued Copy],cno as[Call No],vol as[Volume], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from[book] where title like'" + id + "%' and author like'" + writer + "%' group by date1,title,author,edition,cno,vol,imprint,isbn,sup,price,dept";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet searchtitleauthorupdate(string id, string writer)
        {
            DataSet ds = new DataSet();
            // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select date1 as[Date Of Entry],ano as[Accession No],title as[Book Title],author as[Author], edition as[Edition],cno as[Call No],vol as[Volume], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from[book] where title like'" + id + "%' and author like'" + writer + "%' and dcopy is null group by date1,ano,title,author,edition,cno,vol,imprint,isbn,sup,price,dept";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet searchtitleauthorupdateJ(string id, string writer)
        {
            DataSet ds = new DataSet();
            // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select date1 as[Date Of Entry],ano as[Accession No],title as[Journal Title],author as[Author], cno as[Call No],imprint as[Imprint], sup as[Supplier], price as[Price]  from[journal] where title like'" + id + "%' and author like'" + writer + "%' and dcopy is null order by title,author";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet searchtitleauthorupdateM(string id, string writer)
        {
            DataSet ds = new DataSet();
            // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select date1 as[Date Of Entry],ano as[Accession No],title as[Magazine Title],author as[Author], cno as[Call No],imprint as[Imprint], sup as[Supplier], price as[Price]  from[magazine] where title like'" + id + "%' and author like'" + writer + "%' and dcopy is null order by title,author";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet searchtitleauthorupdateR(string id, string writer)
        {
            DataSet ds = new DataSet();
            // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select date1 as[Date Of Entry],ano as[Accession No],title as[Report Title],author as[Author], cno as[Call No],imprint as[Imprint], sup as[Supplier], price as[Price]  from[report] where title like'" + id + "%' and author like'" + writer + "%' and dcopy is null order by title,author";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet updateCDA(string id, string writer)
        {
            DataSet ds = new DataSet();
            // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select date1 as[Date Of Entry],cdn as[Accession No],title as[Book Title],author as[Author], edition as[Edition],cno as[Call No],vol as[Volume], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from[cd] where title like'" + id + "%' and author like'" + writer + "%' and dcopy is null group by date1,cdn,title,author,edition,cno,vol,imprint,isbn,sup,price,dept";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet searchnonissue(string id)
        {
            DataSet ds = new DataSet();
            // string sql = "select   title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price],count(*) as [Avilable Copy], dept as[Department] from [book] where title like '" + id + "%' and icopy is null  group by cno,title,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select ano as [Accession No],title as[Book Title],author as[Author] from [book] where ano like '" + id + "%'  and acopy ='a' and dcopy is null ";

            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet searchnonissueCD(string id)
        {
            DataSet ds = new DataSet();
            // string sql = "select   title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price],count(*) as [Avilable Copy], dept as[Department] from [book] where title like '" + id + "%' and icopy is null  group by cno,title,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select cdn as [Accession No],title as[CD Title],author as[Author] from [cd] where cdn like '" + id + "%'  and acopy ='a' and dcopy is null ";

            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet searchallcd()
        {
            DataSet ds = new DataSet();
            // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select date1 as[Date Of Entry],cdn as[Accession No],title as[Book Title],author as[Author], edition as[Edition],cno as[Call No],vol as[Volume], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from[cd] where dcopy is null order by cdn";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet searchallbook()
        {
            DataSet ds = new DataSet();
            // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select date1 as[Date Of Entry],ano as[Accession No],title as[Book Title],author as[Author], edition as[Edition],cno as[Call No],vol as[Volume], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from[book] where dcopy is null order by ano";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet searchnonissuerefresh(string id)
        {
            DataSet ds = new DataSet();
            // string sql = "select   title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price],count(*) as [Avilable Copy], dept as[Department] from [book] where title like '" + id + "%' and icopy is null  group by cno,title,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select ano as [Accession No],title as[Book Title],author as[Author] from [book] where  acopy ='a' ";

            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet searchnonissuerefreshCD(string id)
        {
            DataSet ds = new DataSet();
            // string sql = "select   title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price],count(*) as [Avilable Copy], dept as[Department] from [book] where title like '" + id + "%' and icopy is null  group by cno,title,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select cdn as [Accession No],title as[CD Title],author as[Author] from [cd] where  acopy ='a' ";

            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public void DeleteBook()
        {
            string sql = "DELETE [book] where ano='" + this.Accession + "'";
            DatabaseAccess.ExecuteNonquery(sql);
        }
        public void DeleteCD()
        {
            string sql = "DELETE [cd] where cdn='" + this.Cd + "'";
            DatabaseAccess.ExecuteNonquery(sql);
        }
        public DataSet searchano(string id)
        {
            DataSet ds = new DataSet();
            // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select date1 as[Date Of Entry],ano as[Accession No],title as[Book Title],author as[Author], edition as[Edition],cno as[Call No],vol as[Volume], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department]  from [book] where ano like'" + id + "%' and dcopy is null order by ano";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet searchanoJ(string id)
        {
            DataSet ds = new DataSet();
            // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select date1 as[Date Of Entry],ano as[Accession No],title as[Journal Title],author as[Author],cno as[Call No], imprint as[Imprint], sup as[Supplier], price as[Price] from [journal] where ano like'" + id + "%' and dcopy is null order by ano";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet searchanoJT(string id)
        {
            DataSet ds = new DataSet();
            // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select date1 as[Date Of Entry],ano as[Accession No],title as[Journal Title],author as[Author],cno as[Call No], imprint as[Imprint], sup as[Supplier], price as[Price] from[journal] where title like'" + id + "%' and dcopy is null order by title";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet searchanoMT(string id)
        {
            DataSet ds = new DataSet();
            // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select date1 as[Date Of Entry],ano as[Accession No],title as[Magazine Title],author as[Author],cno as[Call No], imprint as[Imprint], sup as[Supplier], price as[Price] from[magazine] where title like'" + id + "%' and dcopy is null order by title";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet searchanoRT(string id)
        {
            DataSet ds = new DataSet();
            // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select date1 as[Date Of Entry],ano as[Accession No],title as[Report Title],author as[Author],cno as[Call No], imprint as[Imprint], sup as[Supplier], price as[Price] from[report] where title like'" + id + "%' and dcopy is null order by title";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet searchanoM(string id)
        {
            DataSet ds = new DataSet();
            // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select date1 as[Date Of Entry],ano as[Accession No],title as[Magazine Title],author as[Author],cno as[Call No], imprint as[Imprint], sup as[Supplier], price as[Price] from[magazine] where ano like'" + id + "%' and dcopy is null order by ano";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet searchanoR(string id)
        {
            DataSet ds = new DataSet();
            // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select date1 as[Date Of Entry],ano as[Accession No],title as[Report Title],author as[Author],cno as[Call No], imprint as[Imprint], sup as[Supplier], price as[Price] from[report] where ano like'" + id + "%' and dcopy is null order by ano";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet updateCDACC(string id)
        {
            DataSet ds = new DataSet();
            // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select date1 as[Date Of Entry],cdn as[Accession No],title as[Book Title],author as[Author], edition as[Edition],cno as[Call No],vol as[Volume], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from[cd] where cdn like'" + id + "%' and dcopy is null  group by date1,cdn,title,author,edition,cno,vol,imprint,isbn,sup,price,dept";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public DataSet CDACC(string id)
        {
            DataSet ds = new DataSet();
            // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
            string sql = "select date1 as[Date Of Entry],cdn as[Accession No],title as[Book Title],author as[Author], edition as[Edition],cno as[Call No],vol as[Volume], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from[cd] where cdn like'" + id + "%'  group by date1,cdn,title,author,edition,cno,vol,imprint,isbn,sup,price,dept";
            ds = DatabaseAccess.ExecuteQuery1(sql);
            return ds;
        }

        public void CDDel()
        {
            string sql = "UPDATE [cd] SET dcopy='" + this.Del + "'  where cdn='" + this.Cd + "'";
            DatabaseAccess.ExecuteNonquery(sql);

        }

        public void BookDEL()
        {
            string sql = "UPDATE [book] SET dcopy='" + this.Del + "'  where ano='" + this.Accession + "'";
            DatabaseAccess.ExecuteNonquery(sql);

        }

        public void JDEL()
        {
            string sql = "UPDATE [journal] SET dcopy='" + this.Del + "'  where ano='" + this.Accession + "'";
            DatabaseAccess.ExecuteNonquery(sql);

        }

        public void MDEL()
        {
            string sql = "UPDATE [magazine] SET dcopy='" + this.Del + "'  where ano='" + this.Accession + "'";
            DatabaseAccess.ExecuteNonquery(sql);

        }

        public void RDEL()
        {
            string sql = "UPDATE [report] SET dcopy='" + this.Del + "'  where ano='" + this.Accession + "'";
            DatabaseAccess.ExecuteNonquery(sql);

        }

       
    }
}
