﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library_Management_System.Service;

namespace Library_Management_System.UserInterface
{
    public partial class FrmIssue : Form
    {
        Issue add = new Issue();
        Book add1 = new Book();
        Student d = new Student();
        DataTable dt = new DataTable();
        public FrmIssue()
        {
            InitializeComponent();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void RefreshObject()
        {

            add.Accession =txtAcess.Text;
            add.Title = txtTitle.Text;
            add.Author = txtAuhor.Text;
            add.Lcard = txtCard.Text;
            add.Issue_date = dateTimePicker1.Text;
            add.Return_date =dateTimePicker2.Text;
            add.Icopy = label5.Text;


        }

        private void save()
        {
          


           

            


           

            RefreshObject();
            // if (MessageBox.Show("Do you really want to Save Company Name?" + "  < " + add.Roll + ">  " + " ? ", "Confirm Save Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                // return;
            }

            try
            {

                add.Insert();
                MessageBox.Show("Book issued successfully.", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                add.UpdateCopy();
                txtCard.Enabled = false;
                searchtitle();
                searchtitlerefresh();
                btnIssue.Enabled = false;
               txtAcess.Focus();
              // dataGridView1.DataSource = null;
                //loadcatinfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Can't Save.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void searchtitle()
        {

            string id = Convert.ToString(txtAccession.Text);
            DataSet ds = add1.searchnonissue(id);
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

        public void searchtitlerefresh()
        {

            string id = Convert.ToString(txtAccession.Text);
            DataSet ds = add1.searchnonissuerefresh(id);
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


         private void BookDetails()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    txtCard.Enabled = true;
                    txtCard.Text = "";
                    txtCard.Focus();
                    btnIssue.Enabled = true;
                    DataGridViewRow dr = dataGridView1.SelectedRows[0];

                    txtAcess.Text = dr.Cells[0].Value.ToString();
                    txtTitle.Text = dr.Cells[1].Value.ToString();
                    txtAuhor.Text = dr.Cells[2].Value.ToString();
                }
                else
                {
                    btnIssue.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error message");
            }
            }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (txtCard.Text == "")
            {

                MessageBox.Show("Please enter member library card no.");
                txtCard.Focus();
                return;
            }
            if (txtCard.Text != "")
            {
                searchCard();
            }
            
        }

        private void Title()
        {
            DataTable dt = new DataTable();
       
            string id = Convert.ToString(txtAcess.Text);
      
         
            add.Accession = id;
          
            dt = add.BookTitle(id);
            int j = dt.Rows.Count;

            if (j != 0)
            {
                try
                {
                    for (int i = 0; i < j;i++ )
                    {
                        txtTitle.Text = dt.Rows[i]["title"].ToString();
                        txtAuhor.Text = dt.Rows[i]["author"].ToString();
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Book is not found.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtAcess_TextChanged(object sender, EventArgs e)
        {
          //  Title();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtAccession_TextChanged(object sender, EventArgs e)
        {
            searchtitle();
            if (txtAccession.Text == "")
            {
               // dataGridView1.DataSource = null;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BookDetails();
            
        }

        private void txtAccession_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void FrmIssue_Load(object sender, EventArgs e)

        {
            ToolTip t = new ToolTip();
            t.AutoPopDelay = 5000;
            // t.ReshowDelay = 500;
            t.ShowAlways = true;
            t.SetToolTip(this.btnIssue, "Issue (Enter)");


            t.SetToolTip(this.btnCancel, "Cancel (ESC)");
            this.Owner.Enabled = false;
            searchtitlerefresh();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           // BookDetails();
        }

        private void FrmIssue_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Enabled = true;
        }

        public void searchCard()
        {
            try
            {

                dt = d.LoadCard(txtCard.Text);
                int j = dt.Rows.Count;
                if (j != 0)
                {
                    save();

                }
                else
                {
                    MessageBox.Show("You are not a member of the library.\n" + "You are not allowed to issue any book/CD.", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCard.Focus();
                    txtCard.Text = "";
                    // MessageBox.Show("No book found ", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCard_Leave(object sender, EventArgs e)
        {
           
        }

        private void txtCard_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
