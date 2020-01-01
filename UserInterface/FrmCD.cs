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
    public partial class FrmCD : Form
    {
        Book add = new Book();
        Issue issue = new Issue();
        Book book = new Book();
        Dept d = new Dept();
        DataTable dt = new DataTable();
        public FrmCD()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void save()
        {
          //  add.Cd = txtCD.Text;
          //  add.Accession = txtAccession.Text;
            DataTable dt = new DataTable();
           // DataTable dt = new DataTable();
            try
            {
                
                dt = add.CheckCD(txtAccession.Text);
                int k = dt.Rows.Count;
            
               
                if (k==0)
                {

                   
                    RefreshObject();
                    book.InsertCD();
                    MessageBox.Show("Information saved successfully.", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    book.UpdateExistCD();
                    this.Hide();
                    this.Owner.Close();
                    FrmCD1 f = new FrmCD1();

                    f.Show();
                    f.searchAll();
                    f.dataGridView1.ClearSelection();



                }
                else
                {
                    add.Accession = txtAccession.Text;
                    MessageBox.Show("CD of accession no"+ "   <" + add.Accession + ">" +  "  already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetValue();
                    txtAccession.Text = "";
                    txtAccession.Text = "";
                    txtAccession.Focus();

                }
            
            }
            catch (Exception )
            {
                
                 MessageBox.Show("CD already exist.","error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 ResetValue();
                
                 
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtAccession.Text == "")
            {

                MessageBox.Show("Please enter Aceesion no.");
                txtAccession.Focus();
                return;
            }

            if (txtCD.Text == "")
            {

                MessageBox.Show("Please enter CD Aceesion no.");
                txtCD.Focus();
                return;
            }
            save();
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

        public void searchDept()
        {
            try
            {

                dt = d.LoadDept();
                int j = dt.Rows.Count;
                if (j != 0)
                {
                    for (int i = 0; i < j; i++)
                        cmDept.Items.Add(dt.Rows[i]["name"].ToString());

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


        private void FrmCD_Load(object sender, EventArgs e)
        {

            ToolTip t = new ToolTip();
            t.AutoPopDelay = 5000;
            // t.ReshowDelay = 500;
            t.ShowAlways = true;
            t.SetToolTip(this.btnSave, "Save (Ctrl+S)");
            t.SetToolTip(this.btnUpdate, "Update (Ctrl+U)");
            t.SetToolTip(this.btnDelete, "Delete (Ctrl+D)");
          
            t.SetToolTip(this.btnCancel, "Cancel (ESC)");
            searchDept();
            searchSup();
            mycount();
            this.Owner.Enabled = false;
        }

        private void FrmCD_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Enabled = true;
        }

        private void txtAccession_TextChanged(object sender, EventArgs e)
        {
            if (txtAccession.Text == "")
            {
                ResetValue();
                txtCD.Enabled = false;
            }
            loadinfo();
        }

        private void RefreshObject()
        {
            book.Cde = lbcd.Text;
            book.Date = dateTimePicker1.Text;
            book.Accession = txtAccession.Text;
            book.Cd = txtCD.Text;
            book.Call = txtCall.Text;
            book.Title = txtTitle.Text;
            book.Author = txtAuthor.Text;
            book.Vol = txtVol.Text;
            book.Edition = cmEdition.Text;
            book.Imprint = txtImprint.Text;
            book.Isbn = txtISBN.Text;
            book.Supplier = cmSupplier.Text;
            book.Price = txtPrice.Text;
            book.Acopy = label4.Text;
            book.Dept = cmDept.Text;
            book.Item = lblBook.Text;
            book.Mno = lbtMno.Text;
            book.Mnth = lbMonth.Text;
            book.Yr = lbYear.Text;
            book.Del = lbld.Text;

        }

        private void ResetValue()
        {
            txtCD.Text = "";
           // txtAccession.Text = "";
            txtCall.Text = "";
            txtTitle.Text = "";
            txtAuthor.Text = "";
            txtVol.Text = "";
            cmEdition.Text = "";
            txtPrice.Text ="";
            txtCopy.Text = "";
            txtImprint.Text = "";
            txtISBN.Text = "";
            cmSupplier.Text = "";
            cmDept.Text = "";
            txtAccession.Focus();
            txtCD.Enabled = false;
            txtA.Text = "";
            txtT.Text = "";
            txtC.Text = "";
            dataGridView1.DataSource = null;
                  
        }

        private void loadinfo()
        {
            dt = add.CD(txtAccession.Text);
            int k = dt.Rows.Count;
            if(k !=0)
            {
                for (int i = 0; i < k; i++)
                {
                    
                    txtCall.Text = dt.Rows[i]["cno"].ToString();
                    txtTitle.Text = dt.Rows[i]["title"].ToString();
                    txtAuthor.Text = dt.Rows[i]["author"].ToString();
                    txtVol.Text = dt.Rows[i]["vol"].ToString();
                    cmEdition.Text = dt.Rows[i]["edition"].ToString();
                    txtPrice.Text = dt.Rows[i]["price"].ToString();
                    txtCopy.Text = dt.Rows[i]["copy"].ToString();
                    txtImprint.Text = dt.Rows[i]["imprint"].ToString();
                    txtISBN.Text = dt.Rows[i]["isbn"].ToString();
                    cmSupplier.Text = dt.Rows[i]["sup"].ToString();
                    cmDept.Text = dt.Rows[i]["dept"].ToString();
                  
                }
               
                txtCD.Enabled = true;
               // txtCD.Focus();
            }
            else
            {
                txtCD.Enabled = false;
               // MessageBox.Show("Book is not found.Please try with a new accession no.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValue();
            }
        }

        public void searchtitle()
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

        private void txtAccession_Leave(object sender, EventArgs e)
        {
            
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

            if (e.KeyChar == (char)13)
            {
                loadinfo();
               
            
            }
        }

        public void searchauthor()
        {

            try
            {
                if (txtA.Text != "" && txtT.Text != "")
                {
                    DataSet ds = add.updateCDA(txtT.Text, txtA.Text);
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        DataView dw = new DataView(ds.Tables[0]);
                        dataGridView1.DataSource = dw;

                    }

                }
            }
            catch (Exception)
            {
                 MessageBox.Show("No CD found ", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }

        }

        private void txtT_TextChanged(object sender, EventArgs e)
        {
            searchtitle();
            searchauthor();
            if (txtT.Text == "")
            {
                dataGridView1.DataSource = null;
                ResetValue();
            }
        }

        private void txtA_TextChanged(object sender, EventArgs e)
        {
            searchauthor();
            if (txtA.Text == "")
            {
                ResetValue();
                dataGridView1.DataSource = null;
            }
        }

        public void searchaccess()
        {

           
            DataSet ds = add.updateCDACC(txtC.Text);
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

               MessageBox.Show("No CD found ", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }


        private void txtC_TextChanged(object sender, EventArgs e)
        {
            searchaccess();
            if (txtC.Text == "")
            {
                ResetValue();
                dataGridView1.DataSource = null;
            }
        }

        private void enabletext()
        {
            dateTimePicker1.Enabled = true;
            txtCD.Enabled = true;
            txtAccession.Enabled = false;
            txtAccession.Text = "";
            txtTitle.Enabled = true;
            txtAuthor.Enabled = true; 
            cmEdition.Enabled = true;
            txtCall.Enabled = true;
            txtVol.Enabled = true;

            txtImprint.Enabled = true;
            txtISBN.Enabled = true;
            cmSupplier.Enabled = true;
            txtPrice.Enabled = true;

            cmDept.Enabled =true;
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;
           // btnDelete.Enabled = true;
        }

        private void disabletext()
        {
            dateTimePicker1.Enabled = false;
            txtCD.Enabled = false;
            txtAccession.Enabled = true;
            txtAccession.Focus();
            txtTitle.Enabled = false;
            txtAuthor.Enabled = false;
            cmEdition.Enabled = false;
            txtCall.Enabled = false;
            txtVol.Enabled = false;

            txtImprint.Enabled = false;
            txtISBN.Enabled = false;
            cmSupplier.Enabled = false;
            txtPrice.Enabled = false;

            cmDept.Enabled = false;
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (lbuname.Text == "Admin")
            {
                try
                {
                    if (this.dataGridView1.SelectedRows.Count > 0)
                    {

                        enabletext();
                        txtCD.Enabled = false;
                        btnSave.Enabled = true;
                        btnDelete.Enabled = true;
                        DataGridViewRow dr = dataGridView1.SelectedRows[0];
                        dateTimePicker1.Text = dr.Cells[0].Value.ToString();
                        txtCD.Text = dr.Cells[1].Value.ToString();

                        txtTitle.Text = dr.Cells[2].Value.ToString();
                        txtAuthor.Text = dr.Cells[3].Value.ToString();
                        cmEdition.Text = dr.Cells[4].Value.ToString();
                        txtCall.Text = dr.Cells[5].Value.ToString();
                        txtVol.Text = dr.Cells[6].Value.ToString();

                        txtImprint.Text = dr.Cells[7].Value.ToString();
                        txtISBN.Text = dr.Cells[8].Value.ToString();
                        cmSupplier.Text = dr.Cells[9].Value.ToString();
                        txtPrice.Text = dr.Cells[10].Value.ToString();

                        cmDept.Text = dr.Cells[11].Value.ToString();
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

                        enabletext();
                        txtCD.Enabled = false;
                        btnSave.Enabled = true;
                        DataGridViewRow dr = dataGridView1.SelectedRows[0];
                        dateTimePicker1.Text = dr.Cells[0].Value.ToString();
                        txtCD.Text = dr.Cells[1].Value.ToString();

                        txtTitle.Text = dr.Cells[2].Value.ToString();
                        txtAuthor.Text = dr.Cells[3].Value.ToString();
                        cmEdition.Text = dr.Cells[4].Value.ToString();
                        txtCall.Text = dr.Cells[5].Value.ToString();
                        txtVol.Text = dr.Cells[6].Value.ToString();

                        txtImprint.Text = dr.Cells[7].Value.ToString();
                        txtISBN.Text = dr.Cells[8].Value.ToString();
                        cmSupplier.Text = dr.Cells[9].Value.ToString();
                        txtPrice.Text = dr.Cells[10].Value.ToString();

                        cmDept.Text = dr.Cells[11].Value.ToString();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
                }

        private void updatebutton()
        {
            try
            {

                RefreshObject();
                book.UpdateCD();


                MessageBox.Show("Information updated successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtAccession.Focus();
                this.Hide();
                this.Owner.Close();
                FrmCD1 f = new FrmCD1();

                f.Show();
                f.searchAll();
                f.dataGridView1.ClearSelection();

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void deletecd()
        {
            try
            {
                RefreshObject();
               // book.DeleteCD();
                if (MessageBox.Show("Are you sure you want to delete CD?", "Delete CD", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;

                }
                book.CDDel();
                MessageBox.Show("Information deleted successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                disabletext();
                txtAccession.Text = "";
                ResetValue();
                allcd();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void allcd()
        {
            try
            {
                DataSet ds = book.searchallcd();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
            updatebutton();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count < 1)
            {
                MessageBox.Show("Please select accession no to delete", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            deletecd();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            mycount();
        }

        private void txtT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)8 || e.KeyChar == 32 || e.KeyChar == '+' || e.KeyChar == '#')
            {
                e.Handled = false;
            }
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
            if (e.KeyChar == '.' || e.KeyChar == '-')
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

        private void txtCD_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCall_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)8 || e.KeyChar == '.')
            {
                e.Handled = false;
            }
            if (e.KeyChar == (char)13)
            {

                txtTitle.Focus();

            }
        }

        private void txtTitle_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)8 || e.KeyChar == 32 || e.KeyChar == '+' || e.KeyChar == '#')
            {
                e.Handled = false;
            }
            {
                e.Handled = false;
            }
            if (e.KeyChar == (char)13)
            {

                txtAuthor.Focus();

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
            if (e.KeyChar == '.' || e.KeyChar == '-' || e.KeyChar=='&')
            {
                e.Handled = false;
            }
            if (e.KeyChar == (char)13)
            {

                txtVol.Focus();

            }

        }

        private void txtVol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;

            }

            if (e.KeyChar == (char)13)
            {

                txtPrice.Focus();

            }
        }

        private void cmEdition_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmSupplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmDept_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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

                txtImprint.Focus();

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

        private void txtImprint_KeyPress(object sender, KeyPressEventArgs e)
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
            if (e.KeyChar == (char)13)
            {

                txtISBN.Focus();

            }
        }

        private void txtISBN_KeyPress(object sender, KeyPressEventArgs e)
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
            if (e.KeyChar == (char)13)
            {

                txtCopy.Focus();

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

        private void FrmCD_KeyDown(object sender, KeyEventArgs e)
        {
           

            if (e.KeyData == (Keys.Control | Keys.S))
            {
                if (txtAccession.Text == "")
                {

                    MessageBox.Show("Please enter Aceesion no.");
                    txtAccession.Focus();
                    return;
                }

                if (txtCD.Text == "")
                {

                    MessageBox.Show("Please enter CD Aceesion no.");
                    txtCD.Focus();
                    return;
                }
                save();
            }
            if (e.KeyData == (Keys.Control | Keys.U))
            {
                if (this.dataGridView1.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Please select accession no to update", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                updatebutton();
            }
            if (e.KeyData == (Keys.Control | Keys.D))
            {
                if (this.dataGridView1.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Please select accession no to delete", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                deletecd();
            }
        }
        }
    }

