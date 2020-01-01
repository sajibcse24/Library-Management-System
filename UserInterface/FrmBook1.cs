using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library_Management_System.Service;
using Library_Management_System.UserInterface;

namespace Library_Management_System
{
    public partial class FrmBook1 : Form
    {
        DataTable dt = new DataTable();
        Book book = new Book();
        Book add = new Book();
        Dept d = new Dept();
        public FrmBook1()
        {
            InitializeComponent();
        }

        private void txtT_Click(object sender, EventArgs e)
        {
            txtT.Text = "";
        }

        public void searchtitle()
        {





            try
            {
                string id = Convert.ToString(txtT.Text);
                DataSet ds = add.searchtitle1update(id);
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
            catch (Exception)
            {
                throw;
                // MessageBox.Show("No book found ", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }

        private void ResetValue()
        {



            txtA.Text = "";
            txtT.Text = "";
            txtC.Text = "";
            dataGridView1.DataSource = null;

        }

        public void searchauthor()
        {




            try
            {
                if (txtA.Text != "" && txtT.Text != "")
                {
                    DataSet ds = add.searchtitleauthorupdate(txtT.Text, txtA.Text);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }


        private void txtT_TextChanged(object sender, EventArgs e)
        {
            searchtitle();
           // searchauthor();
            dataGridView1.ClearSelection();
            if (txtT.Text == "")
            {
               // dataGridView1.DataSource = null;
               // ResetValue();
            }
        }

      
         public void searchtitleAll()
        {





            try
            {
                string id = Convert.ToString(txtT.Text);
                DataSet ds = add.searchtitle1updateAll();
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
            catch (Exception)
            {
                throw;
                // MessageBox.Show("No book found ", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

         private void FrmBook1_Load(object sender, EventArgs e)
         {
             searchtitleAll();
             dataGridView1.ClearSelection();
         }

         private void btnAdd_Click(object sender, EventArgs e)
         {
             FrmBook f = new FrmBook();
             f.Owner = this;
             f.Show();
          
             f.LoadAccession();
         }

         private void btnSave_Click(object sender, EventArgs e)
         {
             FrmReg f = new FrmReg();
             f.Owner = this;
             f.Show();
         }

         private void button4_Click(object sender, EventArgs e)
         {
             if (MessageBox.Show("Are you sure you want to close this system?", "Library Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
             {
                 return;

             }
             this.Close();
         }


       


            

        

       private void btnUpdate_Click(object sender, EventArgs e)
         {
             if (this.dataGridView1.SelectedRows.Count < 1)
             {
                 MessageBox.Show("Please select accession no to update", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 dataGridView1.ClearSelection();
                 return;
             }
             FrmBook f = new FrmBook();
             f.Owner = this;
             f.Show();
            // f.txtAccession.Text = textBox1.Text;
             try
             {
                 if (this.dataGridView1.SelectedRows.Count > 0)
                 {
                     f.txtAccession.Enabled = false;
                     DataGridViewRow dr = dataGridView1.SelectedRows[0];
                     f.dateTimePicker1.Text = dr.Cells[0].Value.ToString();
                     f.txtAccession.Text = dr.Cells[1].Value.ToString();

                     f.txtTitle.Text = dr.Cells[2].Value.ToString();
                     f.txtAuthor.Text = dr.Cells[3].Value.ToString();

                     f.cmEdition.Text = dr.Cells[4].Value.ToString();
                     f.txtCall.Text = dr.Cells[5].Value.ToString();
                     f.txtVol.Text = dr.Cells[6].Value.ToString();
                     f.txtImprint.Text = dr.Cells[7].Value.ToString();
                     f.txtISBN.Text = dr.Cells[8].Value.ToString();
                     f.cmSupplier.Text = dr.Cells[9].Value.ToString();
                     f.txtPrice.Text = dr.Cells[10].Value.ToString();
                     // txtCopy.Text = ds.Tables[0].Rows[i]["copy"].ToString();
                     f.cmDept.Text = dr.Cells[11].Value.ToString();


                     f.txtCopy.Enabled = false;
                     f.btnUpdate.Enabled = true;

                     f.btnSave.Enabled = false;
                 }
             }
             catch (Exception)
             {
                 
                 throw;
             }

         }

         private void txtA_TextChanged(object sender, EventArgs e)
         {
             if (txtA.Text == "")
             {
               //  dataGridView1.DataSource = null;
               //  ResetValue();
             }
             searchauthor();
             dataGridView1.ClearSelection();
         }

         public void searchaccess()
         {
             try
             {

                 DataSet ds = add.searchano(txtC.Text);

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
             catch (Exception ex)
             {

                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
         }

         private void txtC_TextChanged(object sender, EventArgs e)
         {
             searchaccess();
             if (txtC.Text == "")
             {
                // dataGridView1.DataSource = null;
                // ResetValue();
             }
             dataGridView1.ClearSelection();
         }

         private void txtA_Click(object sender, EventArgs e)
         {
             txtA.Text = "";
         }

         private void txtC_Click(object sender, EventArgs e)
         {
             txtC.Text = "";
         }

         private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {
            
         
    }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {

                    DataGridViewRow dr = dataGridView1.SelectedRows[0];

                    textBox1.Text = dr.Cells[1].Value.ToString();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deletebook()
        {
            try
            {
                book.Accession = textBox1.Text;
                book.Del = lbld.Text;

                // book.DeleteBook();
                if (MessageBox.Show("Are you sure you want to delete book?", "Delete book", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;

                }
                book.BookDEL();
                MessageBox.Show("Information deleted successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                searchtitleAll();
                dataGridView1.ClearSelection();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count < 1)
            {
                MessageBox.Show("Please select accession no to delete book?", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView1.ClearSelection(); 
                return;
            }
            deletebook();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad.exe");
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void wordpadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Wordpad.exe");
        }

        private void mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("TaskMgr.exe");
        }

        private void mSWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Winword.exe");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmChangeAccount f = new FrmChangeAccount();
            f.Owner = this;
            f.Show();
            f.txtEmail.Focus();
            if (lbuname.Text == "User")
            {
                f.cmUtype.Enabled = false;
                f.cmUtype.Text = "User";
                f.txtEmail.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin f = new FrmLogin();

            f.Show();
        }

        private void annualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnnualReport add = new AnnualReport();
            add.Owner = this;
            add.Show();
        }

        private void departmentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmReportDept add = new FrmReportDept();
            add.Owner = this;
            add.Show();
        }

        private void memberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReportMember add = new FrmReportMember();
            add.Owner = this;
            add.Show();

        }

        private void fineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReportFine add = new FrmReportFine();
            add.Owner = this;
            add.Show();
        }

        private void departmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDept add = new FrmDept();
            add.Owner = this;
            add.Show();
            add.txtDname.Focus();
            add.lbuname.Text = lbuname.Text;
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSup f = new FrmSup();
            f.Owner = this;
            f.Show();
            f.lbuname.Text = lbuname.Text;
            f.txtSup.Focus();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSearchBook add = new FrmSearchBook();
            add.Owner = this;
            add.Show();
        }

        private void issuedBookListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIssuedBook add = new FrmIssuedBook();
            add.Owner = this;
            add.Show();
        }

        private void issueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIssue add = new FrmIssue();
            add.Owner = this;
            add.Show();
            add.txtAccession.Focus();
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReturn add = new FrmReturn();
            add.Owner = this;
            add.Show();
        }

        private void issueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmCDIssue add = new FrmCDIssue();
            add.Owner = this;
            add.Show();
            add.txtAccession.Focus();
        }

        private void retutrnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCDReturn add = new FrmCDReturn();
            add.Owner = this;
            add.Show();
        }

        private void libraryMembershipInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMember1 add = new FrmMember1();
            add.Owner = this;
            add.Show();
            add.lbuname.Text = lbuname.Text;
        }

        private void cDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmCD1 add = new FrmCD1();
            add.Owner = this;
            add.Show();
            dataGridView1.ClearSelection();
            add.lbuname.Text = lbuname.Text;
          
        }

        private void journalMagagineReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmJournal_Magagine j = new FrmJournal_Magagine();
            j.Owner = this;
            j.Show();
            j.txtCall.Focus();
            j.lbuname.Text = lbuname.Text;
        }

        private void FrmBook1_FormClosing(object sender, FormClosingEventArgs e)
        {
           // FrmMain f = new FrmMain();
           // f.Show();
        }

        private void bookToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void bookInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtT_Leave(object sender, EventArgs e)
        {
            txtT.Text = "Search Book By Title/Author/Accession No";
        }
        }
}
