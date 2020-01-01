using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Library_Management_System.Service;

namespace Library_Management_System
{
    public partial class FrmUpdateBook : Form
    {
        Student add = new Student();
        Issue add1 = new Issue();
        public FrmUpdateBook()
        {
            InitializeComponent();
        }

        private void txTitle_TextChanged(object sender, EventArgs e)
        {

        }

        public void searchaccess()
        {

            if (label1.Text == "Teacher")
            {

                DataSet ds = add.info(textBox1.Text);

                try
                {
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
            else
            {
                DataSet ds = add.infos(textBox1.Text);

                try
                {
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

           
        }

        public void searchtype()
        {


            DataTable dt = add.type(textBox1.Text);
            int j=dt.Rows.Count;
            try
            {
                if (j!=0)
                {
                    for (int i = 0; i < j;i++ )
                    {

                        label1.Text = dt.Rows[i]["utype"].ToString();
                    }

                }
                else
                {
                    label1.Text = "";
                    // MessageBox.Show("No book found ", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            searchtype();
           
             searchaccess();
           
        }

        private void MemberDetails()
        {
            try
            {
            if (this.dataGridView1.SelectedRows.Count > 0)
               
                    {
                        DataGridViewRow dr = dataGridView1.SelectedRows[0];

                        textBox2.Text = dr.Cells[0].Value.ToString();
                       


                    }
                }
                catch (Exception ex)
                {
                     MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  
                }
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MemberDetails();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
             try
          {
            DataSet ds = new DataSet();
            ds = add1.MemberDetails(textBox2.Text);
         
              if (ds != null && ds.Tables[0].Rows.Count > 0)
                  for (int i = 0; i < ds.Tables[0].Rows.Count ;i++ )
                  {
                      groupBox5.Visible = true;
                      groupBox6.Visible = false;
                       DataView dw = new DataView(ds.Tables[0]);
                       dataGridView2.DataSource = dw;
                    
                  }
              else
              {
                  groupBox5.Visible = false;
                  groupBox6.Visible = true;
                  label2.Text = "No book was issued to you.";
                  // MessageBox.Show("No book found ", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);

              }
	}
	catch (Exception)
	{
		
		throw;
	}
        }
    }
}
