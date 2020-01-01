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
    public partial class FrmBook : Form
    {
        DataTable dt = new DataTable();
        Book book = new Book();
        Book add = new Book();
        Dept d = new Dept();
        public FrmBook()
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
            book.Vol = txtVol.Text;
            book.Edition = cmEdition.Text;
            book.Imprint = txtImprint.Text;
            book.Isbn = txtISBN.Text;
            book.Supplier = cmSupplier.Text;
            book.Price = txtPrice.Text;
            book.Acopy = label14.Text;
            book.Dept = cmDept.Text;
            book.Item = lblBook.Text;
            book.Mno = lbtMno.Text;
            book.Mnth = lbMonth.Text;
            book.Yr = lbYear.Text;
            book.Del = lbld.Text;

        }

        private void save()
        {
            if (txtCall.Text == "")
            {

                MessageBox.Show("Please enter call no.");
                txtCall.Focus();
                return;
            }
            if (txtTitle.Text == "")
            {

                MessageBox.Show("Please enter book title name");
                txtTitle.Focus();
                return;
            }

            if (txtAuthor.Text == "")
            {

                MessageBox.Show("Please enter author name");
                txtAuthor.Focus();
                return;
            }


         //   if (txtVol.Text == "")
            {

               // MessageBox.Show("Please volume no.");
              //  txtVol.Focus();
              //  return;


            }

            if (cmEdition.Text == "SELECT")
            {

                MessageBox.Show("Please select edition.");
                cmEdition.Focus();
                return;
            }

            if (txtImprint.Text== "")
              {

                  MessageBox.Show("Please enter Imprint.");
                  txtImprint.Focus();
                  return;
              }

            if (txtISBN.Text == "")
            {

                MessageBox.Show("Please enter ISBN.");
                txtISBN.Focus();
                return;
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

            if (cmDept.Text == "SELECT")
            {

                MessageBox.Show("Please select department.");
                cmDept.Focus();
                return;
            }

            

            





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
                    book.Insert();



                }
                MessageBox.Show("Information saved successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                button1.Enabled = true;
                this.Hide();
                this.Owner.Close();
                FrmBook1 f = new FrmBook1();
                
                f.Show();
                f.searchtitleAll();
                f.dataGridView1.ClearSelection();
              
                
               
              
              
                // LoadAccession();
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void updatebutton()
        {
            try
            {

                RefreshObject();
                book.Update();


                MessageBox.Show("Information updated successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                this.Owner.Close();
                FrmBook1 f = new FrmBook1();

                f.Show();
                f.searchtitleAll();
                f.dataGridView1.ClearSelection();
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
          
            updatebutton();
        }

        public void LoadAccession()
        {
            DataTable dt = new DataTable();

            dt = book.Checkinfo();
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

        public void searchDept()
        {
            try
            {

                 dt = d.LoadDept();
                int j = dt.Rows.Count;
                if (j!= 0 )
                {
                    for (int i = 0; i < j;i++ )
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

        private void FrmBook_Load(object sender, EventArgs e)
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

          //  LoadAccession();
            searchDept();
            searchSup();
            mycount();
          //  this.Owner.Enabled = false;

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



        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            mycount();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSearchBook add = new FrmSearchBook();
            add.Owner = new FrmMain();
            add.Show();
            add.label1.Text = "u";
            add.groupBox3.Visible = true;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
        private void ResetValue()
        {

           
            txtCall.Text = "";
            txtTitle.Text = "";
            txtAuthor.Text = "";
            txtVol.Text = "";
            cmEdition.Text = "SELECT";
            txtPrice.Text = "";
            txtCopy.Text = "";
            txtImprint.Text = "";
            txtISBN.Text = "";
            cmSupplier.Text = "SELECT";
            cmDept.Text = "SELECT";
            txtAccession.Focus();
        
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count < 1)
            {
                MessageBox.Show("Please select accession no to delete", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            deletebook();
        }
        private void deletebook()
        {
            try
            {
                RefreshObject();
                // book.DeleteBook();
                if (MessageBox.Show("Are you sure you want to delete book?", "Delete book", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;

                }
                book.BookDEL();
                MessageBox.Show("Information deleted successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
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



        private void button1_Click(object sender, EventArgs e)
        {
            LoadAccession();
            txtCall.Focus();
            txtCopy.Enabled = true;
            label11.Visible = true;
            txtCopy.Visible = true;
            ResetValue();

        }

        private void txtCall_Leave(object sender, EventArgs e)
        {
            if (txtCall.Text == "")
            {

                // MessageBox.Show("Please enter call number.");
                // txtCall.Focus();
                // return;
            }
          //  txtCall.BackColor = Color.White;

        }

        private void txtTitle_Leave(object sender, EventArgs e)
        {

           // txtTitle.BackColor = Color.Maroon;
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
          //  txtCall.BackColor = Color.DarkKhaki;
        }

        private void txtCall_Click(object sender, EventArgs e)
        {

            // txtCall.BackColor = Color.DarkKhaki;
           // cmDept.BackColor = Color.White;
           // cmSupplier.BackColor = Color.White;
           // cmEdition.BackColor = Color.White;
        }

        private void txtTitle_Click(object sender, EventArgs e)
        {
            // txtTitle.BackColor = Color.DarkKhaki;
           // cmDept.BackColor = Color.White;
           // cmSupplier.BackColor = Color.White;
           // cmEdition.BackColor = Color.White;
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
           

            if (e.KeyChar == (char)13)
            {

                txtAuthor.Focus();
               // txtAuthor.BackColor = Color.DarkKhaki;
            }
           // txtTitle.BackColor = Color.DarkKhaki;
        }

        private void txtAuthor_Click(object sender, EventArgs e)
        {
            // txtAuthor.BackColor = Color.DarkKhaki;
           // cmDept.BackColor = Color.White;
           // cmSupplier.BackColor = Color.White;
           // cmEdition.BackColor = Color.White;
        }

        private void txtAuthor_Layout(object sender, LayoutEventArgs e)
        {


        }

        private void txtAuthor_Leave(object sender, EventArgs e)
        {
           // txtAuthor.BackColor = Color.White;
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
            if (e.KeyChar == '.' || e.KeyChar == '-')
            {
                e.Handled = false;
            }

            if (e.KeyChar == (char)13)
            {

                txtVol.Focus();
              //  txtVol.BackColor = Color.DarkKhaki;
            }
        }

        private void txtVol_Click(object sender, EventArgs e)
        {
            // txtVol.BackColor = Color.DarkKhaki;
           // cmDept.BackColor = Color.White;
          //  cmSupplier.BackColor = Color.White;
          //  cmEdition.BackColor = Color.White;
        }

        private void txtVol_Leave(object sender, EventArgs e)
        {
           // txtVol.BackColor = Color.White;
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

                txtImprint.Focus();
            }
        }

        private void cmEdition_SelectedIndexChanged(object sender, EventArgs e)
        {
           // txtImprint.Focus();
          //  cmEdition.BackColor = Color.White;
          //  txtImprint.BackColor = Color.DarkKhaki;
          //  cmDept.BackColor = Color.White;
        }

        private void txtImprint_Leave(object sender, EventArgs e)
        {
           // txtImprint.BackColor = Color.White;
        }

        private void txtImprint_Click(object sender, EventArgs e)
        {
            // txtImprint.BackColor = Color.DarkKhaki;
           // cmDept.BackColor = Color.White;
          //  cmSupplier.BackColor = Color.White;
          //  cmEdition.BackColor = Color.White;
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
               // txtISBN.BackColor = Color.DarkKhaki;
            }
        }

        private void txtISBN_Click(object sender, EventArgs e)
        {
           
        }

        private void txtISBN_Leave(object sender, EventArgs e)
        {
           // txtISBN.BackColor = Color.White;
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

            if(e.KeyChar=='-')
            {
                e.Handled=false;
            }

            if (e.KeyChar == (char)13)
            {

                txtPrice.Focus();
               // cmSupplier.Focus();
               // cmSupplier.BackColor = Color.DarkKhaki;
            }
        }

        private void cmSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void txtPrice_Click(object sender, EventArgs e)
        {
            //txtPrice.BackColor = Color.DarkKhaki;
            //cmDept.BackColor = Color.White;
           // cmSupplier.BackColor = Color.White;
           // cmEdition.BackColor = Color.White;
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            //txtPrice.BackColor = Color.White;
           

            string g = txtPrice.Text;
            if (g != "")
            {
                double b = Convert.ToDouble(g);
                txtPrice.Text = String.Format("{0:0.00}", b);
            }
        }

        private void txtPrice_Enter(object sender, EventArgs e)
        {

        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            
           // txtPrice.BackColor = Color.DarkKhaki;

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

                txtCopy.Focus();
               // txtCopy.BackColor = Color.DarkKhaki;
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

       

        private void txtCopy_Click(object sender, EventArgs e)
        {
            //txtCopy.BackColor = Color.DarkKhaki;
           // cmDept.BackColor = Color.White;
           // cmSupplier.BackColor = Color.White;
          //  cmEdition.BackColor = Color.White;
        }

        private void txtCopy_Leave(object sender, EventArgs e)
        {
           // txtCopy.BackColor = Color.White;
            if (txtCopy.Text != "")
            {
                double a = Convert.ToInt32(txtCopy.Text);
                if (a == 0)
                {
                    MessageBox.Show("Enter atleast one copy.");
                    txtCopy.Text = "";
                    txtCopy.Focus();
                }
            }
        }

        private void txtCopy_KeyPress(object sender, KeyPressEventArgs e)
        {
           // txtCopy.BackColor = Color.DarkKhaki;
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

               // cmDept.Focus();
               // cmDept.BackColor = Color.DarkKhaki;
            }
        }

        private void cmDept_SelectedIndexChanged(object sender, EventArgs e)
        {
           // cmDept.BackColor = Color.DarkKhaki;

        }

        private void txtCall_MouseHover(object sender, EventArgs e)
        {
           // txtCall.BackColor = Color.LightSlateGray;
        }

        private void txtAuthor_MouseHover(object sender, EventArgs e)
        {
           // txtAuthor.BackColor = Color.LightSlateGray;
        }

        private void cmSupplier_MouseHover(object sender, EventArgs e)
        {
           // cmSupplier.BackColor = Color.LightSlateGray;
        }

        private void txtCall_MouseLeave(object sender, EventArgs e)
        {
           // txtCall.BackColor = Color.White;
        }

        private void txtTitle_MouseHover(object sender, EventArgs e)
        {
          //  txtTitle.BackColor = Color.LightSlateGray;
        }

        private void txtTitle_MouseLeave(object sender, EventArgs e)
        {
           // txtTitle.BackColor = Color.White;
        }

        private void txtAuthor_MouseLeave(object sender, EventArgs e)
        {
           // txtAuthor.BackColor = Color.White;
        }

        private void txtVol_MouseHover(object sender, EventArgs e)
        {
           // txtVol.BackColor = Color.LightSlateGray;
        }

        private void txtVol_MouseLeave(object sender, EventArgs e)
        {
            //txtVol.BackColor = Color.White;
        }

        private void txtImprint_MouseHover(object sender, EventArgs e)
        {
           // txtImprint.BackColor = Color.LightSlateGray;
        }

        private void txtImprint_MouseLeave(object sender, EventArgs e)
        {
           // txtImprint.BackColor = Color.White;
        }

        private void txtISBN_MouseLeave(object sender, EventArgs e)
        {
           // txtISBN.BackColor = Color.White;
        }

        private void txtISBN_MouseHover(object sender, EventArgs e)
        {
           // txtISBN.BackColor = Color.LightSlateGray;
        }

        private void txtPrice_MouseHover(object sender, EventArgs e)
        {
           // txtPrice.BackColor = Color.LightSlateGray;
        }

        private void txtPrice_MouseLeave(object sender, EventArgs e)
        {
           // txtPrice.BackColor = Color.White;
        }

        private void txtCopy_MouseHover(object sender, EventArgs e)
        {
            //txtCopy.BackColor = Color.LightSlateGray;
        }

        private void txtCopy_MouseLeave(object sender, EventArgs e)
        {
           // txtCopy.BackColor = Color.White;
        }

        private void cmEdition_MouseHover(object sender, EventArgs e)
        {
           // cmEdition.BackColor = Color.LightSlateGray;
        }

        private void cmEdition_MouseLeave(object sender, EventArgs e)
        {

           // cmEdition.BackColor = Color.White;
        }

        private void cmSupplier_MouseLeave(object sender, EventArgs e)
        {

           // cmSupplier.BackColor = Color.White;
        }

        private void cmDept_MouseHover(object sender, EventArgs e)
        {

          //  cmDept.BackColor = Color.LightSlateGray;
        }

        private void cmDept_MouseLeave(object sender, EventArgs e)
        {
           // cmDept.BackColor = Color.White;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.ForeColor = Color.OrangeRed;

            button1.Width = 100;


        }

        private void button1_Leave(object sender, EventArgs e)
        {


        }

        private void btnSave_MouseHover(object sender, EventArgs e)
        {
            btnSave.ForeColor = Color.OrangeRed;
            btnSave.Width = 100;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.ForeColor = Color.Maroon;
            btnSave.Width = 82;
        }

        private void btnUpdate_MouseHover(object sender, EventArgs e)
        {
            btnUpdate.ForeColor = Color.OrangeRed;
            btnUpdate.Width = 100;
        }

        private void btnUpdate_MouseLeave(object sender, EventArgs e)
        {
            btnUpdate.ForeColor = Color.Maroon;
            btnUpdate.Width = 82;
        }

        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            btnDelete.ForeColor = Color.OrangeRed;
            btnDelete.Width = 100;
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.ForeColor = Color.Maroon;
            btnDelete.Width = 82;
        }

        private void btnGet_MouseHover(object sender, EventArgs e)
        {
            btnGet.ForeColor = Color.OrangeRed;
            btnGet.Width = 100;
        }

        private void btnGet_MouseLeave(object sender, EventArgs e)
        {
            btnGet.ForeColor = Color.Maroon;
            btnGet.Width = 82;
        }

        private void btnCancel_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void btnCancel_MouseHover(object sender, EventArgs e)
        {
            btnCancel.ForeColor = Color.OrangeRed;
            btnCancel.Width = 100;
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.ForeColor = Color.Maroon;
            btnCancel.Width = 82;


        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Maroon;
            button1.Width = 82;



        }

        private void FrmBook_FormClosing(object sender, FormClosingEventArgs e)
        {
          

           // this.Owner.Enabled = true;
         

        }

        private void FrmBook_Activated(object sender, EventArgs e)
        {

        }

        private void FrmBook_Deactivate(object sender, EventArgs e)
        {

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

        public void searchaccess()
        {
            try
            {

                DataSet ds = add.searchano(txtAccession.Text);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
                    {
                        txtCall .Text  = ds.Tables[0].Rows[i]["cno"].ToString();
                        txtTitle.Text = ds.Tables[0].Rows[i]["title"].ToString();
                        txtAuthor .Text  = ds.Tables[0].Rows[i]["author"].ToString();
                        txtVol.Text = ds.Tables[0].Rows[i]["vol"].ToString();
                        cmEdition.Text = ds.Tables[0].Rows[i]["edition"].ToString();
                        txtImprint.Text = ds.Tables[0].Rows[i]["imprint"].ToString();
                        txtISBN.Text = ds.Tables[0].Rows[i]["isbn"].ToString();
                        cmSupplier.Text = ds.Tables[0].Rows[i]["sup"].ToString();
                        txtPrice.Text = ds.Tables[0].Rows[i]["price"].ToString();
                       // txtCopy.Text = ds.Tables[0].Rows[i]["copy"].ToString();
                        cmDept.Text = ds.Tables[0].Rows[i]["dept"].ToString();

                    }
                       

                }
                else
                {
                    txtCall.Text = "";
                    txtTitle.Text ="";
                    txtAuthor.Text = "";
                    txtVol.Text = "";
                    cmEdition.Text = "";
                    txtImprint.Text = "";
                    txtISBN.Text = "";
                    cmSupplier.Text = "";
                    txtPrice.Text = "";
                    // txtCopy.Text = ds.Tables[0].Rows[i]["copy"].ToString();
                    cmDept.Text = "";
                    // MessageBox.Show("No book found ", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtA_TextChanged(object sender, EventArgs e)
        {
            if (txtA.Text == "")
            {
                dataGridView1.DataSource = null;
                ResetValue();
            }
            searchauthor();

        }

        private void txtC_TextChanged(object sender, EventArgs e)
        {
           
            searchaccess();
            if (txtC.Text == "")
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
                        cmEdition.Text = dr.Cells[4].Value.ToString();
                        txtCall.Text = dr.Cells[5].Value.ToString();
                        txtVol.Text = dr.Cells[6].Value.ToString();

                        txtImprint.Text = dr.Cells[7].Value.ToString();
                        txtISBN.Text = dr.Cells[8].Value.ToString();
                        cmSupplier.Text = dr.Cells[9].Value.ToString();
                        txtPrice.Text = dr.Cells[10].Value.ToString();

                        cmDept.Text = dr.Cells[11].Value.ToString();
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
                      //  btnDelete.Enabled = true;
                        button1.Enabled = true;
                        DataGridViewRow dr = dataGridView1.SelectedRows[0];
                        dateTimePicker1.Text = dr.Cells[0].Value.ToString();
                        txtAccession.Text = dr.Cells[1].Value.ToString();

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

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void txtCopy_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void FrmBook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                LoadAccession();
                txtCall.Focus();
                txtCopy.Enabled = true;
                label11.Visible = true;
                txtCopy.Visible = true;
                ResetValue();
            }

            if (e.KeyData == (Keys.Control | Keys.S))
            {
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
            deletebook();
            }
        }

        private void txtAccession_TextChanged(object sender, EventArgs e)
        {
          //  searchaccess();
        }

        private void btnSave_ParentChanged(object sender, EventArgs e)
        {
    
        }
    }
}

