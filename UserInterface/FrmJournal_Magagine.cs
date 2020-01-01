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
    public partial class FrmJournal_Magagine : Form
    {
        Book book = new Book();
        Book add = new Book();
        Dept d = new Dept();
        DataTable dt = new DataTable();
        public FrmJournal_Magagine()
        {
            InitializeComponent();
        }

        private void RefreshObject()
        {
            book.Date = dateTimePicker1.Text;
            book.Accession = txtAccession.Text;
            book.Call = txtCall.Text;
            book.Title = txtTitle.Text;
            book.Author = txtAuthor.Text;

            book.Item = cmType.Text;
            book.Imprint = txtImprint.Text;
         
            book.Supplier = cmSupplier.Text;
            book.Price = txtPrice.Text;
            book.Acopy = label14.Text;
        
       
            book.Mno = lbtMno.Text;
            book.Mnth = lbMonth.Text;
            book.Yr = lbYear.Text;
            book.Del = lbld.Text;

        }

        private void saveJ()
        {
            /*if (txtName.Text == "")
            {

                MessageBox.Show("Please enter student name.");
                txtName.Focus();
                return;
            }
            if (cmClass.Text == "----- SELECT -----")
            {

                MessageBox.Show("Please select class.");
                cmClass.Focus();
                return;
            }


            if (cmGroup.Text == "----- SELECT -----")
            {

                MessageBox.Show("Please select group.");
                cmGroup.Focus();
                return;


            }

            /* if (txtMob.Text == "")
              {

                  MessageBox.Show("Please enter mobile.");
                  txtName.Focus();
                  return;
              } */




            RefreshObject();
            // if (MessageBox.Show("Do you really want to Save Company Name?" + "  < " + add.Roll + ">  " + " ? ", "Confirm Save Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                // return;
            }

            double copy = Convert.ToDouble(txtCopy.Text);


            try
            {

                for (int i = 0; i < copy; i++)
                {
                    book.Copy = "1";
                    book.InsertJ();



                }
                MessageBox.Show("Journal saved successfully.", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                button1.Enabled = true;
                txtAccession.Focus();
                ResetValue();
                txtImprint.Enabled = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                // LoadAccession();
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void saveM()
        {
            /*if (txtName.Text == "")
            {

                MessageBox.Show("Please enter student name.");
                txtName.Focus();
                return;
            }
            if (cmClass.Text == "----- SELECT -----")
            {

                MessageBox.Show("Please select class.");
                cmClass.Focus();
                return;
            }


            if (cmGroup.Text == "----- SELECT -----")
            {

                MessageBox.Show("Please select group.");
                cmGroup.Focus();
                return;


            }

            /* if (txtMob.Text == "")
              {

                  MessageBox.Show("Please enter mobile.");
                  txtName.Focus();
                  return;
              } */




            RefreshObject();
            // if (MessageBox.Show("Do you really want to Save Company Name?" + "  < " + add.Roll + ">  " + " ? ", "Confirm Save Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                // return;
            }

            double copy = Convert.ToDouble(txtCopy.Text);


            try
            {

                for (int i = 0; i < copy; i++)
                {
                    book.Copy = "1";
                    book.InsertM();



                }
                MessageBox.Show("Magazine saved successfully.", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                button1.Enabled = true;
                ResetValue();
                txtAccession.Focus();
                txtImprint.Enabled = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                // LoadAccession();
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void saveR()
        {
            /*if (txtName.Text == "")
            {

                MessageBox.Show("Please enter student name.");
                txtName.Focus();
                return;
            }
            if (cmClass.Text == "----- SELECT -----")
            {

                MessageBox.Show("Please select class.");
                cmClass.Focus();
                return;
            }


            if (cmGroup.Text == "----- SELECT -----")
            {

                MessageBox.Show("Please select group.");
                cmGroup.Focus();
                return;


            }

            /* if (txtMob.Text == "")
              {

                  MessageBox.Show("Please enter mobile.");
                  txtName.Focus();
                  return;
              } */




            RefreshObject();
            // if (MessageBox.Show("Do you really want to Save Company Name?" + "  < " + add.Roll + ">  " + " ? ", "Confirm Save Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                // return;
            }

            double copy = Convert.ToDouble(txtCopy.Text);


            try
            {

                for (int i = 0; i < copy; i++)
                {
                    book.Copy = "1";
                    book.InsertR();



                }
                MessageBox.Show("Report saved successfully.", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                button1.Enabled = true;
                txtAccession.Focus();
                ResetValue();
                txtImprint.Enabled = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                // LoadAccession();
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void updateJ()
        {
           
            try
            {

                RefreshObject();
                book.UpdateJ();


                MessageBox.Show("Journal updated successfully.", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtAccession.Focus();
                //allcd();
                ResetValue();
                dateTimePicker1.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void updateM()
        {
            try
            {

                RefreshObject();
                book.UpdateM();


                MessageBox.Show("Magazine updated successfully.", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtAccession.Focus();
                //allcd();
                ResetValue();
                dateTimePicker1.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void updateR()
        {
            try
            {

                RefreshObject();
                book.UpdateR();


                MessageBox.Show("Report updated successfully.", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtAccession.Focus();
                //allcd();
                ResetValue();
                dateTimePicker1.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoadAccessionJ()
        {
            DataTable dt = new DataTable();

            dt = book.CheckinfoJournal();
            int j = dt.Rows.Count;

            if (j != 0)
            {
                for (int i = 0; i < j; i++)
                {
                    string a = dt.Rows[i]["ano"].ToString();
                    double b = Convert.ToDouble(a);
                    double sum = b + 1;
                    txtAccession.Text = sum.ToString();
                }


            }
            else
            {
                txtAccession.Text = "1";
            }
            btnSave.Enabled = true;
            button1.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

        }

        private void LoadAccessionM()
        {
            DataTable dt = new DataTable();

            dt = book.CheckinfoMagazine();
            int j = dt.Rows.Count;

            if (j != 0)
            {
                for (int i = 0; i < j; i++)
                {
                    string a = dt.Rows[i]["ano"].ToString();
                    double b = Convert.ToDouble(a);
                    double sum = b + 1;
                    txtAccession.Text = sum.ToString();
                }


            }
            else
            {
                txtAccession.Text = "1";
            }
            btnSave.Enabled = true;
            button1.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

        }

        private void LoadAccessionR()
        {
            DataTable dt = new DataTable();

            dt = book.CheckinfoReport();
            int j = dt.Rows.Count;

            if (j != 0)
            {
                for (int i = 0; i < j; i++)
                {
                    string a = dt.Rows[i]["ano"].ToString();
                    double b = Convert.ToDouble(a);
                    double sum = b + 1;
                    txtAccession.Text = sum.ToString();
                }


            }
            else
            {
                txtAccession.Text = "1";
            }
            btnSave.Enabled = true;
            button1.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

        }
        private void mycount()
        {
            string a = dateTimePicker1.Text;
            DateTime dt = Convert.ToDateTime(a);
            int day = dt.Day;
            int month = dt.Month;
            lbtMno.Text = month.ToString();
            DateTime d = new DateTime(1, month, 1);
            lbMonth.Text = d.ToString("MMMM");
            int year = dt.Year;
            // m.Text = month.ToString();
            lbYear.Text = year.ToString();
        }

        public void searchtitle()
        {





            try
            {
                string id = Convert.ToString(txtT.Text);
                DataSet ds = add.searchtitleJ(id);
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


            txtCall.Text = "";
            txtTitle.Text = "";
            txtAuthor.Text = "";
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        
            txtPrice.Text = "";
            txtCopy.Text = "";
            txtImprint.Text = "";
         
            cmSupplier.Text = "SELECT";
            
            txtCall.Focus();

            txtA.Text = "";
            txtT.Text = "";
            txtC.Text = "";
            dataGridView1.DataSource = null;

        }

        private void allcd()
        {
            try
            {
                DataSet ds = book.searchallbook();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataView dw = new DataView(ds.Tables[0]);
                    dataGridView1.DataSource = dw;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        public void searchauthorJ()
        {




            try
            {
                if (txtA.Text != "" && txtT.Text != "")
                {
                    DataSet ds = add.searchtitleauthorupdateJ(txtT.Text, txtA.Text);
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

        public void searchauthorM()
        {




            try
            {
                if (txtA.Text != "" && txtT.Text != "")
                {
                    DataSet ds = add.searchtitleauthorupdateM(txtT.Text, txtA.Text);
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

        public void searchauthorR()
        {




            try
            {
                if (txtA.Text != "" && txtT.Text != "")
                {
                    DataSet ds = add.searchtitleauthorupdateR(txtT.Text, txtA.Text);
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

        public void searchaccessJ()
        {
            try
            {

                DataSet ds = add.searchanoJ(txtC.Text);

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

        public void searchaccessM()
        {
            try
            {

                DataSet ds = add.searchanoM(txtC.Text);

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

        public void searchaccessR()
        {
            try
            {

                DataSet ds = add.searchanoR(txtC.Text);

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

        public void searchaccessJT()
        {
            try
            {

                DataSet ds = add.searchanoJT(txtT.Text);

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

        public void searchaccessMT()
        {
            try
            {

                DataSet ds = add.searchanoMT(txtT.Text);

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

        public void searchaccessRT()
        {
            try
            {

                DataSet ds = add.searchanoRT(txtT.Text);

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
        public void searchSup()
        {
            try
            {

                dt = d.LoadSup();
                int j = dt.Rows.Count;
                if (j != 0)
                {
                    for (int i = 0; i < j; i++)
                        cmSupplier.Items.Add(dt.Rows[i]["name"].ToString());

                }
                else
                {

                    // MessageBox.Show("No book found ", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
             

        private void FrmJournal_Magagine_Load(object sender, EventArgs e)
        {

            ToolTip t = new ToolTip();
            t.AutoPopDelay = 5000;
            // t.ReshowDelay = 500;
            t.ShowAlways = true;
            t.SetToolTip(this.btnSave, "Save (Ctrl+S)");
            t.SetToolTip(this.btnUpdate, "Update (Ctrl+U)");
            t.SetToolTip(this.btnDelete, "Delete (Ctrl+D)");
            t.SetToolTip(this.button1, "New (Ctrl+N)");
            t.SetToolTip(this.btnCancel, "Cancel (ESC)");
            mycount();
            searchSup();
            this.Owner.Enabled = false;
        }

        private void FrmJournal_Magagine_FormClosing(object sender, FormClosingEventArgs e)
        {
          
            this.Owner.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cmType.Text=="SELECT")
            {
                MessageBox.Show("Please select type.");
                cmType.Focus();
                return;
            }
            if (cmType.Text == "Journal")
            {
                LoadAccessionJ();
            }

            if (cmType.Text == "Magazine")
            {
                LoadAccessionM();
            }

            if (cmType.Text == "Report")
            {
                LoadAccessionR();
            }
            radioButton1.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            txtCopy.Enabled = true;
            label11.Visible = true;
            txtCopy.Visible = true;
            groupBox4.Text = "Details";
            ResetValue();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (cmType.Text == "SELECT")
            {

                MessageBox.Show("Please select type.");
                cmType.Focus();
                return;
            }
            if (txtCall.Text == "")
            {

                MessageBox.Show("Please enter call no.");
                txtCall.Focus();
                return;
            }
            if (txtTitle.Text == "")
            {

                MessageBox.Show("Please enter title name");
                txtTitle.Focus();
                return;
            }

            if (txtAuthor.Text == "")
            {

                MessageBox.Show("Please enter author name");
                txtAuthor.Focus();
                return;
            }


            if (radioButton2.Checked == true)
            {

                if (txtImprint.Text == "")
                {

                    MessageBox.Show("Please enter Imprint.");
                    txtImprint.Focus();
                    return;
                }
            }

            if (radioButton3.Checked == true)
            {

                if (txtImprint.Text == "")
                {

                    MessageBox.Show("Please enter ISBN.");
                    txtImprint.Focus();
                    return;
                }
            }


            if (cmSupplier.Text == "SELECT")
            {

                MessageBox.Show("Select Supplier Name.");
                cmSupplier.Focus();
                return;
            }

            if (txtPrice.Text == "")
            {

                MessageBox.Show("Please enter price.");
                txtPrice.Focus();
                return;
            }

            if (txtCopy.Text == "")
            {

                MessageBox.Show("Please enter copy no.");
                txtCopy.Focus();
                return;
            }

          

            if (cmType.Text == "Journal")
            {
                saveJ();
            }

            if (cmType.Text == "Magazine")
            {
                saveM();
            }

            if (cmType.Text == "Report")
            {
                saveR();
            }
         
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <1)
            {
                MessageBox.Show("Please select accession no to update", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (radioButton5.Checked == true)
            {
                updateJ();
            }

            if (radioButton4.Checked == true)
            {
                updateM();
            }

            if (radioButton1.Checked == true)
            {
                updateR();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count < 1)
            {
                MessageBox.Show("Please select accession no to delete", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (radioButton5.Checked == true)
            {
                deleteJ();
            }

            if (radioButton4.Checked == true)
            {
                deleteM();
            }

            if (radioButton1.Checked == true)
            {
                deleteR();
            }

        }

        private void txtT_TextChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                searchaccessJT();
                searchauthorJ();
            }

            if (radioButton4.Checked == true)
            {
                searchaccessMT();
                searchauthorM();
            }

            if (radioButton1.Checked == true)
            {
                searchaccessRT();
                searchauthorR();
            }

            if (txtT.Text == "")
            {
                dataGridView1.DataSource = null;
                ResetValue();
            }
        }

        private void txtA_TextChanged(object sender, EventArgs e)
        {

            if (radioButton5.Checked == true)
            {
                searchauthorJ();
            }

            if (radioButton4.Checked == true)
            {
                searchauthorM();
            }

            if (radioButton1.Checked == true)
            {
                searchauthorR();
            }

            if (txtA.Text == "")
            {
                dataGridView1.DataSource = null;
                ResetValue();
            }
        }

        private void txtC_TextChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                searchaccessJ();
            }

            if (radioButton4.Checked == true)
            {
                searchaccessM();
            }

            if (radioButton1.Checked == true)
            {
                searchaccessR();
            }

            if(txtC.Text=="")
            {
                dataGridView1.DataSource = null;
                ResetValue();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (lbuname.Text == "Admin")
            {
                try
                {
                    if (this.dataGridView1.SelectedRows.Count > 0)
                    {
                        label11.Visible = false;
                        txtCopy.Visible = false;
                        dateTimePicker1.Enabled = true;
                        btnSave.Enabled = false;
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = true;
                        button1.Enabled = true;
                        DataGridViewRow dr = dataGridView1.SelectedRows[0];
                        dateTimePicker1.Text = dr.Cells[0].Value.ToString();


                        txtAccession.Text = dr.Cells[1].Value.ToString();

                        txtTitle.Text = dr.Cells[2].Value.ToString();
                        txtAuthor.Text = dr.Cells[3].Value.ToString();
                        txtCall.Text = dr.Cells[4].Value.ToString();

                        txtImprint.Text = dr.Cells[5].Value.ToString();

                        cmSupplier.Text = dr.Cells[6].Value.ToString();
                        txtPrice.Text = dr.Cells[7].Value.ToString();

                    }
                    else
                    {
                       
                        label11.Visible = true;
                        txtCopy.Visible = true;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    if (this.dataGridView1.SelectedRows.Count > 0)
                    {
                        label11.Visible = false;
                        txtCopy.Visible = false;
                        dateTimePicker1.Enabled = true;
                        btnSave.Enabled = false;
                        btnUpdate.Enabled = true;
                       // btnDelete.Enabled = true;
                        button1.Enabled = true;
                        DataGridViewRow dr = dataGridView1.SelectedRows[0];
                        dateTimePicker1.Text = dr.Cells[0].Value.ToString();


                        txtAccession.Text = dr.Cells[1].Value.ToString();

                        txtTitle.Text = dr.Cells[2].Value.ToString();
                        txtAuthor.Text = dr.Cells[3].Value.ToString();
                        txtCall.Text = dr.Cells[4].Value.ToString();

                        txtImprint.Text = dr.Cells[5].Value.ToString();

                        cmSupplier.Text = dr.Cells[6].Value.ToString();
                        txtPrice.Text = dr.Cells[7].Value.ToString();

                    }
                    else
                    {
                        label11.Visible = true;
                        txtCopy.Visible = true;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmType_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            mycount();
        }

        private void cmSupplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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

        private void txtCall_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)8 || e.KeyChar=='.')
            {
                e.Handled = false;
            }
            if (e.KeyChar == (char)13)
            {

                txtTitle.Focus(); ;

            }
        }

        private void txtCopy_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            Exception X = new Exception();

            TextBox T = (TextBox)sender;

            try
            {
                if (T.Text != "-")
                {
                    double x = double.Parse(T.Text);

                    if (T.Text.Contains(','))
                        throw X;
                }
            }
            catch (Exception)
            {
                try
                {
                    int CursorIndex = T.SelectionStart - 1;
                    T.Text = T.Text.Remove(CursorIndex, 1);

                    //Align Cursor to same index
                    T.SelectionStart = CursorIndex;
                    T.SelectionLength = 0;
                }
                catch (Exception) { }

            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            if (e.KeyChar == (char)13)
            {

                txtCopy.Focus(); ;

            }

            string senderText = (sender as TextBox).Text;
            string senderName = (sender as TextBox).Name;
            string[] splitByDecimal = senderText.Split('.');
            int cursorPosition = (sender as TextBox).SelectionStart;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }


            if (e.KeyChar == '.'
                && senderText.IndexOf('.') > -1)
            {
                e.Handled = true;
            }


            if (!char.IsControl(e.KeyChar)
                && senderText.IndexOf('.') < cursorPosition
                && splitByDecimal.Length > 1
                && splitByDecimal[1].Length == 3)
            {
                e.Handled = true;



            }
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            string g = txtPrice.Text;
            if (g != "")
            {
                double b = Convert.ToDouble(g);
                txtPrice.Text = String.Format("{0:0.00}", b);
            }
        }

        private void txtTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)8 || e.KeyChar==32)
            {
                e.Handled = false;
            }
            if (e.KeyChar == (char)13)
            {

                txtAuthor.Focus(); ;

            }
        }

        private void txtAuthor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)8 || e.KeyChar == 32)
            {
                e.Handled = false;
            }
            if (e.KeyChar == '.' || e.KeyChar == '-' || e.KeyChar == '&')
            {
                e.Handled = false;
            }
        }

        private void lbMonth_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtImprint_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtImprint_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (radioButton2.Checked == true)
            {

                if (!char.IsLetterOrDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == (char)8 || e.KeyChar == 32)
                {
                    e.Handled = false;
                }
                if (e.KeyChar == '-' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '&')
                {
                    e.Handled = false;
                }
            }
            if(radioButton3.Checked==true)
            {
         
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }

            if (e.KeyChar == '-')
            {
                e.Handled = false;
            }
           
            }
            if (e.KeyChar == (char)13)
            {

                txtPrice.Focus(); ;

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                txtImprint.Enabled = true;
                txtImprint.Text = "";
                txtImprint.Focus();
            }
         
        }

        private void deleteJ()
        {
            try
            {
                RefreshObject();
                // book.DeleteBook();
                if (MessageBox.Show("Are you sure you want to delete journal?", "Delete Journal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;

                }
                book.JDEL();
                MessageBox.Show("Journal deleted successfully.", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValue();
                // allcd();
                dateTimePicker1.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void deleteM()
        {
            try
            {
                RefreshObject();
                // book.DeleteBook();
                if (MessageBox.Show("Are you sure you want to delete magazine?", "Delete Magazine", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;

                }
                book.MDEL();
                MessageBox.Show("Magazine deleted successfully.", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValue();
                // allcd();
                dateTimePicker1.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteR()
        {
            try
            {
                RefreshObject();
                // book.DeleteBook();
                if (MessageBox.Show("Are you sure you want to delete report?", "Delete Report", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;

                }
                book.RDEL();
                MessageBox.Show("Report deleted successfully.", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValue();
                // allcd();
                dateTimePicker1.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                txtImprint.Enabled = true;
                txtImprint.Text = "";
                txtImprint.Focus();
            }
        }

        private void txtT_KeyPress(object sender, KeyPressEventArgs e)
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

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            groupBox4.Text = "Journal Details";
            dataGridView1.DataSource = null;
            ResetValue();
            txtC.Text = "";
            txtA.Text = "";
            txtT.Text = "";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            groupBox4.Text = "Magazine Details";
            dataGridView1.DataSource = null;
            ResetValue();
            txtC.Text = "";
            txtA.Text = "";
            txtT.Text = "";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox4.Text = "Report Details";
            dataGridView1.DataSource = null;
            ResetValue();
            txtC.Text = "";
            txtA.Text = "";
            txtT.Text = "";
        }

        private void txtA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)8 || e.KeyChar == 32)
            {
                e.Handled = false;
            }
            if (e.KeyChar == '.' || e.KeyChar == '-' || e.KeyChar == '&')
            {
                e.Handled = false;
            }
        }

        private void txtC_KeyPress(object sender, KeyPressEventArgs e)
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

        private void FrmJournal_Magagine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                if (cmType.Text == "SELECT")
                {
                    MessageBox.Show("Please select type.");
                    cmType.Focus();
                    return;
                }
                if (cmType.Text == "Journal")
                {
                    LoadAccessionJ();
                }

                if (cmType.Text == "Magazine")
                {
                    LoadAccessionM();
                }

                if (cmType.Text == "Report")
                {
                    LoadAccessionR();
                }
                radioButton1.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                txtCopy.Enabled = true;
                label11.Visible = true;
                txtCopy.Visible = true;
                groupBox4.Text = "Details";
                ResetValue();
            }

            if (e.KeyData == (Keys.Control | Keys.S))
            {
                if (cmType.Text == "SELECT")
                {

                    MessageBox.Show("Please select type.");
                    cmType.Focus();
                    return;
                }
                if (txtCall.Text == "")
                {

                    MessageBox.Show("Please enter call no.");
                    txtCall.Focus();
                    return;
                }
                if (txtTitle.Text == "")
                {

                    MessageBox.Show("Please enter title name");
                    txtTitle.Focus();
                    return;
                }

                if (txtAuthor.Text == "")
                {

                    MessageBox.Show("Please enter author name");
                    txtAuthor.Focus();
                    return;
                }


                if (radioButton2.Checked == true)
                {

                    if (txtImprint.Text == "")
                    {

                        MessageBox.Show("Please enter Imprint.");
                        txtImprint.Focus();
                        return;
                    }
                }

                if (radioButton3.Checked == true)
                {

                    if (txtImprint.Text == "")
                    {

                        MessageBox.Show("Please enter ISBN.");
                        txtImprint.Focus();
                        return;
                    }
                }


                if (cmSupplier.Text == "SELECT")
                {

                    MessageBox.Show("Select Supplier Name.");
                    cmSupplier.Focus();
                    return;
                }

                if (txtPrice.Text == "")
                {

                    MessageBox.Show("Please enter price.");
                    txtPrice.Focus();
                    return;
                }

                if (txtCopy.Text == "")
                {

                    MessageBox.Show("Please enter copy no.");
                    txtCopy.Focus();
                    return;
                }



                if (cmType.Text == "Journal")
                {
                    saveJ();
                }

                if (cmType.Text == "Magazine")
                {
                    saveM();
                }

                if (cmType.Text == "Report")
                {
                    saveR();
                }
            }
            if (e.KeyData == (Keys.Control | Keys.U))
            {
                if (this.dataGridView1.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Please select accession no to update", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (radioButton5.Checked == true)
                {
                    updateJ();
                }

                if (radioButton4.Checked == true)
                {
                    updateM();
                }

                if (radioButton1.Checked == true)
                {
                    updateR();
                }
            }
            if (e.KeyData == (Keys.Control | Keys.D))
            {
                if (this.dataGridView1.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Please select accession no to delete", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (radioButton5.Checked == true)
                {
                    deleteJ();
                }

                if (radioButton4.Checked == true)
                {
                    deleteM();
                }

                if (radioButton1.Checked == true)
                {
                    deleteR();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
