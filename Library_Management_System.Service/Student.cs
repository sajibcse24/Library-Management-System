using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Library_Management_System.DAO;

namespace Library_Management_System.Service
{
   public  class Student
    {
       public Student() { }
       private string name;

       public string Name
       {
           get { return name; }
           set { name = value; }
       }
       private string roll;

       public string Roll
       {
           get { return roll; }
           set { roll = value; }
       }
       private string dept;

       public string Dept
       {
           get { return dept; }
           set { dept = value; }
       }
       private string batch;

       public string Batch
       {
           get { return batch; }
           set { batch = value; }
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
           string sql = "INSERT INTO [member](name,roll,dept,batch,email,cno,maddress,paddress,photo,utype,join_date)VALUES ('" + this.Name + "','" + this.Roll + "','" + this.Dept + "','" + this.Batch + "','" + this.Email + "','" + this.Lcard + "','" + this.Mailaddress + "','" + this.Paddress + "','" + this.Image + "' ,'" + this.Utype + "','" + this.Join_of_date + "')";
           DatabaseAccess.ExecuteNonquery(sql);
       }

       public DataTable Checkinfo(string uname, string card)               //delete 
       {

           DataTable dt = new DataTable();
           string sql = "select * FROM [member] WHERE dept='" + this.Dept + "' and cno='" + this.Lcard + "' ";
           dt = DatabaseAccess.ExecuteQuery(sql);
           return dt;
       }

       public DataTable studentinfo(string id)               //delete 
       {

           DataTable dt = new DataTable();
           string sql = "select * FROM [member] WHERE roll='" + this.Roll + "'  ";
           dt = DatabaseAccess.ExecuteQuery(sql);
           return dt;
       }

       public DataTable MemberDetails(string id)               //delete 
       {

           DataTable dt = new DataTable();
           string sql = "select * FROM [member] WHERE cno='" + this.Lcard + "'   ";
           dt = DatabaseAccess.ExecuteQuery(sql);
           return dt;
       }

       public DataSet info(string id)
       {
           DataSet ds = new DataSet();
           // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
           string sql = "select distinct cno as[Libray Card No],utype as[Member Type],name as[Name],dept as[Department],roll as[Roll No],batch as [Batch],email as[Email],maddress as[Mailing Address], paddress as[Permanent Address],join_date as[Date Of Join]from[member] where cno like '" + id + "%'  order by cno";//utype,name,roll,dept,batch,email,maddress,paddress

           ds = DatabaseAccess.ExecuteQuery1(sql);
           return ds;
       }

       public DataSet infoname(string id)
       {
           DataSet ds = new DataSet();
           // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
           string sql = "select cno as[Libray Card No],utype as[Member Type],name as[Name],dept as[Department],join_date as[Date Of Join], email as[Email],maddress as[Mailing Address], paddress as[Permanent Address] from[member] where name like'" + id + "%' and utype='Teacher' order by name";
           ds = DatabaseAccess.ExecuteQuery1(sql);
           return ds;
       }

       public DataSet einfo(string id)
       {
           DataSet ds = new DataSet();
           // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
           string sql = "select distinct cno as[Libray Card No],utype as[Member Type],name as[Name],dept as[Department],roll as[Roll No],batch as [Batch],email as[Email],maddress as[Mailing Address], paddress as[Permanent Address],join_date as[Date Of Join]from[member] where cno like '" + id + "%'  order by cno";//utype,name,roll,dept,batch,email,maddress,paddress

           ds = DatabaseAccess.ExecuteQuery1(sql);
           return ds;
       }

       public DataSet einfoname(string id)
       {
           DataSet ds = new DataSet();
           // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
           string sql = "select cno as[Libray Card No],utype as[Member Type],name as[Name],join_date as[Date Of Join], email as[Email],maddress as[Mailing Address], paddress as[Permanent Address] from[member] where name like'" + id + "%' and utype='Employee' order by name";
           ds = DatabaseAccess.ExecuteQuery1(sql);
           return ds;
       }

       public DataSet searchAll()
       {
           DataSet ds = new DataSet();
           // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
           string sql = "select  cno as[Libray Card No],utype as[Member Type],name as[Name],dept as[Department],roll as[Roll No],batch as [Batch],email as[Email],maddress as[Mailing Address], paddress as[Permanent Address],join_date as[Date Of Join] from[member] order by cno";//utype,name,roll,dept,batch,email,maddress,paddress

           ds = DatabaseAccess.ExecuteQuery1(sql);
           return ds;
       }

      

       public DataSet infosname(string id)
       {
           DataSet ds = new DataSet();
           // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
           string sql = "select  cno as[Libray Card No],utype as[Member Type],name as[Name],dept as[Department],roll as[Roll No],batch as [Batch],email as[Email],maddress as[Mailing Address], paddress as[Permanent Address],join_date as[Date Of Join] from[member] where name like '" + id + "%' or roll like '" + id + "%' or cno like '" + id + "%'  ";//utype,name,roll,dept,batch,email,maddress,paddress

           ds = DatabaseAccess.ExecuteQuery1(sql);
           return ds;
       }

       public DataSet infosnameAll()
       {
           DataSet ds = new DataSet();
           // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
           string sql = "select  cno as[Libray Card No],utype as[Member Type],name as[Name],dept as[Department],roll as[Roll No],batch as [Batch],email as[Email],maddress as[Mailing Address], paddress as[Permanent Address],join_date as[Date Of Join] from[member]   ";//utype,name,roll,dept,batch,email,maddress,paddress

           ds = DatabaseAccess.ExecuteQuery1(sql);
           return ds;
       }

       public DataSet rinfos(string id)
       {
           DataSet ds = new DataSet();
           // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
           string sql = "select distinct cno as[Libray Card No],utype as[Member Type],name as[Name],dept as[Department],roll as[Roll No],batch as [Batch],email as[Email],maddress as[Mailing Address], paddress as[Permanent Address],join_date as[Date Of Join] from[member] where roll like '" + id + "%'  order by roll";//utype,name,roll,dept,batch,email,maddress,paddress

           ds = DatabaseAccess.ExecuteQuery1(sql);
           return ds;
       }

      

       public DataTable type(string id)
       {
           DataTable ds = new DataTable();
           // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
           string sql = "select * from[member] where cno ='" + id + "'";
           ds = DatabaseAccess.ExecuteQuery(sql);
           return ds;
       }

       public DataSet infos(string id)
       {
           DataSet ds = new DataSet();
           // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
           string sql = "select distinct cno as[Libray Card No],utype as[Member Type],name as[Name],dept as[Department],roll as[Roll No],batch as[Batch],email as[Email],maddress as[Mailing Address], paddress as[Permanent Address],join_date as[Date Of Join] from[member] where cno like '" + id + "%' and utype='Student' order by cno";//utype,name,roll,dept,batch,email,maddress,paddress

           ds = DatabaseAccess.ExecuteQuery1(sql);
           return ds;
       }

       public void UpdateMember()
       {
           string sql = "UPDATE [member] SET utype='"+this.Utype+"',dept='" + this.Dept + "',name='" + this.Name + "',roll='" + this.Roll + "',batch='" + this.Batch + "',email='" + this.Email + "',maddress='" + this.Mailaddress + "',paddress='" + this.Paddress + "',join_date='" + this.Join_of_date + "' where cno='" + this.Lcard + "' ";
           DatabaseAccess.ExecuteNonquery(sql);
       }

       public DataSet searchallmember()
       {
           DataSet ds = new DataSet();
           // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
           string sql = "select cno as[Library Card No],utype as[Member Type],name as[Name],dept as [Department],roll as[Roll], batch as[Batch],email as[Email],maddress as[Mailing Addrress], paddress as[Permanent Addrress], join_date as[Date Of Join] from[member]  order by cno";
           ds = DatabaseAccess.ExecuteQuery1(sql);
           return ds;
       }

       public DataTable LoadCard(string id)
       {
           DataTable ds = new DataTable();
           // string sql = "select date1, title as[Book Title ], author as[Author],cno as[Call No], vol as[Volume], edition as[Edition], imprint as[Imprint], isbn as[ISBN], sup as[Supplier], price as[Price], dept as[Department] from [book] where title like '" + id + "%' and  author like '" + writer + "%'   group by date1,title,cno,author,vol,edition,imprint,isbn,sup,price,dept ";
           string sql = "select cno from [member] where cno='"+id+"'";
           ds = DatabaseAccess.ExecuteQuery(sql);
           return ds;
       }

       public void DeleteMember()
       {
           string sql = "DELETE [member] where cno='" + this.Lcard + "'";
           DatabaseAccess.ExecuteNonquery(sql);
       }

       public DataTable ReportMember(string y1)               //delete 
       {

           DataTable dt = new DataTable();
           string sql = "select count(cno)as total from member where dept='" + y1 + "' group by dept  ";
           //string sql = "select item,count(distinct title) as title,count(ano)as total_copy,count(icopy)as total_issue ,count(dcopy) as damage,sum(price)as cost from book group by item ";
           dt = DatabaseAccess.ExecuteQuery(sql);
           return dt;
       }

       public DataTable ReportMemberAll()               //delete 
       {

           DataTable dt = new DataTable();
           string sql = "select dept,count(cno)as total from member group by dept  ";
           //string sql = "select item,count(distinct title) as title,count(ano)as total_copy,count(icopy)as total_issue ,count(dcopy) as damage,sum(price)as cost from book group by item ";
           dt = DatabaseAccess.ExecuteQuery(sql);
           return dt;
       }

    }
}
