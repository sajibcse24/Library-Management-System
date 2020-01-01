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

namespace Library_Management_System.UserInterface
{
    public partial class FrmCD1 : Form
    {

        Book add = new Book();
        Issue issue = new Issue();
        Book book = new Book();
        Dept d = new Dept();
        DataTable dt = new DataTable();
        public FrmCD1()
        {
            InitializeComponent();
        }

        private void deletecd()
        {
            try
            {
                book.Cd = textBox1.Text; 
                book.Del = lbld.Text;

                // book.DeleteCD();
                if (MessageBox.Show("Are you sure you want to delete CD?", "Delete CD", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;

                }
                book.CDDel();
                MessageBox.Show("Information deleted successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                searchAll();
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
                MessageBox.Show("Please select accession no to delete CD?", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView1.ClearSelection();
                return;
                
               
                
            }
            deletecd();
        }

        private void txtT_TextChanged(object sender, EventArgs e)
        {
            search();
            dataGridView1.ClearSelection();
        }

        public void search()
        {

            string id = Convert.ToString(txtT.Text);

            try
            {
                DataSet ds = add.updateCDT(id);
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
                // throw;
                MessageBox.Show("No CD found ", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void searchAll()
        {

           

            try
            {
                DataSet ds = add.updateCDAll();
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
                // throw;
              //  MessageBox.Show("No CD found ", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txtT_Click(object sender, EventArgs e)
        {
            txtT.Text = "";
        }

        private void txtT_Leave(object sender, EventArgs e)
        {
            txtT.Text = "Search CD By Title/Author/Aceession No";
        }

        private void FrmCD1_Load(object sender, EventArgs e)
        {

            searchAll();
            dataGridView1.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmCD f = new FrmCD();
            f.Owner = this;
            f.Show();
        }

        private void enabletext()
        {
           
           
            // btnDelete.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count < 1)
            {
                MessageBox.Show("Please select accession no to update", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView1.ClearSelection();
                return;
            }
            FrmCD f = new FrmCD();
            f.Owner = this;
            f.Show();
           

            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    f.txtCD.Enabled = false;
                    f.dateTimePicker1.Enabled = true;
                   
                    f.txtAccession.Enabled = false;
                 
                    f.txtTitle.Enabled = true;
                    f.txtAuthor.Enabled = true;
                    f.cmEdition.Enabled = true;
                    f.txtCall.Enabled = true;
                    f.txtVol.Enabled = true;

                    f.txtImprint.Enabled = true;
                    f.txtISBN.Enabled = true;
                    f.cmSupplier.Enabled = true;
                    f.txtPrice.Enabled = true;

                    f.cmDept.Enabled = true;
                    DataGridViewRow dr = dataGridView1.SelectedRows[0];
                    f.dateTimePicker1.Text = dr.Cells[0].Value.ToString();
                    f.txtCD.Text = dr.Cells[1].Value.ToString();

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

        private void lbld_Click(object sender, EventArgs e)
        {

        }

        private void bookToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmBook1 add = new FrmBook1();
            add.Owner = this;

            add.Show();
            // add.txtCall.Focus();

            add.dataGridView1.ClearSelection();
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

        private void libraryMembershipInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMember1 add = new FrmMember1();
            add.Owner = this;
            add.Show();
            add.lbuname.Text = lbuname.Text;
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

        private void issuedBookListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIssuedBook add = new FrmIssuedBook();
            add.Owner = this;
            add.Show();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSearchBook add = new FrmSearchBook();
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

        private void btnReg_Click(object sender, EventArgs e)
        {
            FrmReg f = new FrmReg();
            f.Owner = this;
            f.Show();
        }

        private void btnAccount_Click(object sender, EventArgs e)
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin f = new FrmLogin();

            f.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close this system?", "Library Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;

            }
            this.Close();
        }

        private void cDToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
