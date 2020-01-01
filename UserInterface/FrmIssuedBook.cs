using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using Library_Management_System.Service;

namespace Library_Management_System.UserInterface
{
    public partial class FrmIssuedBook : Form
    {
        Student add = new Student();
        Issue add1 = new Issue();
        public FrmIssuedBook()
        {
            InitializeComponent();
        }

        private void  IssuedBookList()
        {
            string str = System.Configuration.ConfigurationManager.AppSettings["myconn"];
            SqlConnection myconnection = new SqlConnection(str);
            string Query = "select ano as [Accession No],title as[Book Title],author as[Author],card as[Member ID],issued as[Date of Issue],returnd as[Date of Return] from [issue] order by returnd ";
            SqlDataAdapter myDA = new SqlDataAdapter(Query, str);
            DataSet myDataSet = new DataSet();
            myDA.Fill(myDataSet, "issue");

            dataGridView1.DataSource = myDataSet.Tables["issue"].DefaultView;
        }

        private void IssuedCDList()
        {
            string str = System.Configuration.ConfigurationManager.AppSettings["myconn"];
            SqlConnection myconnection = new SqlConnection(str);
            string Query = "select cdn as [Accession No],title as[CD Title],author as[Author],card as[Member ID],issued as[Date of Issue],returnd as[Date of Return] from [cdissue] order by returnd ";
            SqlDataAdapter myDA = new SqlDataAdapter(Query, str);
            DataSet myDataSet = new DataSet();
            myDA.Fill(myDataSet, "cdissue");

            dataGridView1.DataSource = myDataSet.Tables["cdissue"].DefaultView;
        }


        private void FrmIssuedBook_Load(object sender, EventArgs e)
        {
            this.Owner.Enabled = false;
            
           
        }

        private void MemberDetails()
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];

                textBox1.Text = dr.Cells[3].Value.ToString();
                DataTable dt = new DataTable();
                string id = Convert.ToString(textBox1.Text);
                add.Lcard = id;
                dt = add.MemberDetails(id);
                int j = dt.Rows.Count;
                 try
                    {
                if (j != 0)
                {
                    groupBox1.Visible = true;
                        for (int i = 0; i < j; i++)
                        {
                          // MessageBox.Show("Name :" + "  < " + dt.Rows[i]["name"].ToString() + ">  " + " ? ", "Confirm Save Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                         //  MessageBox.Show("Name :" + "  < " + dt.Rows[i]["name"].ToString() + "> ");
                           label1.Text = dt.Rows[i]["roll"].ToString();
                           label2.Text = dt.Rows[i]["name"].ToString();
                           label3.Text = dt.Rows[i]["dept"].ToString();
                           label4.Text = dt.Rows[i]["email"].ToString();
                        }
                }
                    else
                    
                    {
                        groupBox1.Visible =false;
                   // label1.Text="";
                   // label2.Text = "";
                  
                    }



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Member is not found.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                

            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           // MemberDetails();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MemberDetails();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void searchaccess()
        {

            
            DataSet ds =add1.searchissue(txtAccession.Text);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
         
                DataView dw = new DataView(ds.Tables[0]);
                dataGridView1.DataSource = dw;

            }
            else
            {
                
               // MessageBox.Show("No book found ", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }




        }

        public void searchaccesscd()
        {


            DataSet ds = add1.searchissucd(txtAccession.Text);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {

                DataView dw = new DataView(ds.Tables[0]);
                dataGridView1.DataSource = dw;

            }
            else
            {

                // MessageBox.Show("No book found ", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }




        }


        public void searchcard()
        {


            DataSet ds = add1.searchissuecard(textBox2.Text);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {

                DataView dw = new DataView(ds.Tables[0]);
                dataGridView1.DataSource = dw;

            }
            else
            {

                // MessageBox.Show("No book found ", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }




        }

        public void searchcardcd()
        {


            DataSet ds = add1.searchissuecard(textBox2.Text);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {

                DataView dw = new DataView(ds.Tables[0]);
                dataGridView1.DataSource = dw;

            }
            else
            {

                // MessageBox.Show("No book found ", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }




        }

        private void txtAccession_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                searchaccess();
            }
            if (radioButton2.Checked == true)
            {
                searchaccesscd();
            }
            if (txtAccession.Text == "")
            {
                dataGridView1.DataSource = null;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmIssuedBook_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Enabled = true;
        }

        private void txtAccession_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                searchcard();
            }

            if (radioButton2.Checked == true)
            {
                searchcardcd();
            }
             if(textBox2.Text=="")
             {
                 dataGridView1.DataSource=null;
             }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox4.Text = "Book Details";
            txtAccession.Text = "";
            textBox2.Text = "";
            if(radioButton1.Checked==true)
            {
            IssuedBookList();
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox4.Text = "CD Details";
            txtAccession.Text = "";
            textBox2.Text = "";
            if (radioButton2.Checked == true)
            {
                IssuedCDList();
            }
        }
    }
}
