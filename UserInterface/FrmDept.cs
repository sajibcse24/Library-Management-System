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
    public partial class FrmDept : Form
    {
        Dept add = new Dept();
        DataTable dt = new DataTable();
        public FrmDept()
        {
            InitializeComponent();
        }
        private void ResetValue()
        {
            
            txtDept.Text = "";
            txtDname.Text = "";
            txtAccession.Text = "";
        }

        private void RefreshObject()
        {
            
            add.Dept_id =txtDept.Text;
            add.Dept_name = txtDname.Text;
       

        }

        private void save()
        {
            if (txtDname.Text == "")
            {

                MessageBox.Show("Please enter department name.");
                txtDname.Focus();
                return;
            }

            try
            {

               

                    RefreshObject();
                    add.Insert();
                    MessageBox.Show("Deprtment saved successfully.", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetValue();
                    txtDname.Focus();


               
                   
                  

                }

            
            catch (Exception)
            {

                  MessageBox.Show("Department already exist.", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  txtDname.Text = "";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            save();
        }

        private void update()
        {
           


            if (txtDname.Text == "")
            {

                MessageBox.Show("Please enter department name.");
                txtDname.Focus();
                return;
            }


            RefreshObject();
            // if (MessageBox.Show("Do you really want to Save Company Name?" + "  < " + add.Roll + ">  " + " ? ", "Confirm Save Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                // return;
            }

            try
            {

                add.UpdateDept();
                MessageBox.Show("Depatment updated successfully.", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
                dataGridView1.DataSource = null;
                ResetValue();
                txtDname.Focus();

            }
            catch (Exception)
            {
                MessageBox.Show("Department already exist", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void DeptDetails()
        {
            if (lbuname.Text == "Admin")
            {
                try
                {
                    if (this.dataGridView1.SelectedRows.Count > 0)
                    {
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = true;

                        DataGridViewRow dr = dataGridView1.SelectedRows[0];

                        txtDept.Text = dr.Cells[1].Value.ToString();
                        txtDname.Text = dr.Cells[0].Value.ToString();

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Library Management");
                }
            }

            else
              {
                try
                {
                    if (this.dataGridView1.SelectedRows.Count > 0)
                    {
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = false;

                        DataGridViewRow dr = dataGridView1.SelectedRows[0];

                        txtDept.Text = dr.Cells[1].Value.ToString();
                        txtDname.Text = dr.Cells[0].Value.ToString();

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Library Management");
                }
            }
            
        }

        private void FrmDept_Load(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.AutoPopDelay = 5000;
            // t.ReshowDelay = 500;
            t.ShowAlways = true;
            t.SetToolTip(this.btnSave, "Save (Enter)");
            t.SetToolTip(this.btnUpdate, "Update (Ctrl+U)");
            t.SetToolTip(this.btnDelete, "Delete (Ctrl+D)");
            
            t.SetToolTip(this.btnCancel, "Cancel (ESC)");

            this.Owner.Enabled = false;
        }

        private void FrmDept_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Enabled = true;
        }

        private void txtDname_TextChanged(object sender, EventArgs e)
        {

        }

        public void searchDept()
        {


            DataSet ds = add.DeptName(txtAccession.Text);
            try
            {

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {

                    DataView dw = new DataView(ds.Tables[0]);
                    dataGridView1.DataSource = dw;

                }

            }
            catch (Exception)
            {

                MessageBox.Show("No Department is found ", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void txtAccession_TextChanged(object sender, EventArgs e)
        {
            searchDept();
            if(txtAccession.Text=="")
            {
                dataGridView1.DataSource = null;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DeptDetails();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            update();
        }

        private void deletecd()
        {

            if (txtDname.Text == "")
            {

                MessageBox.Show("Please enter department name.");
                txtDname.Focus();
                return;
            }

            try
            {
                RefreshObject();
                // book.DeleteCD();
                if (MessageBox.Show("Are you sure you want to delete department?", "Delete Department", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;

                }
                add.DeptDel();
                MessageBox.Show("Department  deleted successfully.", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);


                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
                dataGridView1.DataSource = null;
                ResetValue();
                txtDname.Focus();
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            deletecd();
        }

        private void txtDname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)8 || e.KeyChar == 32)
            {
                e.Handled = false;
            }
        }

        private void txtAccession_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)8 || e.KeyChar == 32)
            {
                e.Handled = false;
            }
        }

        private void lbuname_Click(object sender, EventArgs e)
        {

        }

        private void FrmDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.U))
            {
                update();
            }
            if (e.KeyData == (Keys.Control | Keys.D))
            {
                deletecd();
            }
        }
    }
}
