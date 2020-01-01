using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using Library_Management_System.Service;

namespace Library_Management_System.UserInterface
{
    public partial class FrmChangeAccount : Form
    {
        DataTable dt = new DataTable();
        Login add = new Login();
        public FrmChangeAccount()
        {
            InitializeComponent();
        }

        private void txtPword_TextChanged(object sender, EventArgs e)
        {
            getAccount();
        }

        private void cmUtype_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtUname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }



            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            if (e.KeyChar == '.' || e.KeyChar == '_')
            {
                e.Handled = false;
            }

            if (e.KeyChar == (char)13)
            {

                txtPword.Focus(); ;

            }
        }

        private void txtNu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }



            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            if (e.KeyChar == '.' || e.KeyChar == '_')
            {
                e.Handled = false;
            }
            if (e.KeyChar == (char)13)
            {

                txtNp.Focus(); ;

            }
        }

        private void txtNp_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtNp_KeyPress(object sender, KeyPressEventArgs e)
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

                txtCp.Focus(); ;

            }
        }

        private void txtCp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }



            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            if (e.KeyChar == '.' || e.KeyChar == '_' || e.KeyChar == '@')
            {
                e.Handled = false;
            }
            if (e.KeyChar == (char)13)
            {

                txtUname.Focus(); ;

            }
        }

        public void getunameadmin()
        {


            // Login log = new Login();

            DataTable dt = new DataTable();




            try
            {
                dt = add.LoadPass(txtEmail.Text);
                int j = dt.Rows.Count;

                if (j !=0)
                {

                    txtUname.Enabled = true;
                    txtUname.Focus();

                }
                else
                {
                    txtUname.Enabled = false;
                    txtNu.Enabled = false;
                    txtPword.Enabled = false;
                    txtNp.Enabled = false;
                    txtCp.Enabled = false;

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Username is not available.\n"+"You are not permitted to change account", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void getpass()
        {


            // Login log = new Login();

            DataTable dt = new DataTable();




            try
            {
                dt = add.LoadPass1(txtUname.Text);
                int j = dt.Rows.Count;

                if (j != 0)
                {

                    txtPword.Enabled = true;
                    txtPword.Focus();

                }
                else
                {
                    
                    txtNu.Enabled = false;
                    txtPword.Enabled = false;
                    txtNp.Enabled = false;
                    txtCp.Enabled = false;

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Username is not available.\n" + "You are not permitted to change account", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void getAccount()
        {


            // Login log = new Login();

            DataTable dt = new DataTable();




            try
            {
                dt = add.Account(txtEmail.Text,txtUname.Text,txtPword.Text);
                int j = dt.Rows.Count;

                if (j != 0)
                {

                    btnOK.Enabled = true;

                }
                else
                {

                    btnOK.Enabled = false;

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Your account is not available.\n" + "You are not permitted to change account", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
           // getunameadmin();
            getAccount();
        }

        private void txtUname_TextChanged(object sender, EventArgs e)
        {
           // getpass();
            getAccount();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void RefreshObject()
        {
            add.Utype = cmUtype.Text;
            add.Uname =txtNu.Text;
            add.Pass = txtNp.Text;
            add.Email = txtEmail.Text;


        }

        public void save()
        {
            try
            {
                RefreshObject();
                add.updateaccount();
                MessageBox.Show("Account changed successfully.", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUname.Text = "";
                txtPword.Text = "";
                txtNp.Text = "";
                txtNu.Text = "";
                txtCp.Text = "";
                txtEmail.Text = "";
                cmUtype.Text = "------- Select User Type -------";
                txtEmail.Focus();
                checkBox1.Checked = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Error,can't change", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Text = "";
                txtEmail.Focus();
            }


        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cmUtype.Text == "------- Select User Type -------")
            {
                MessageBox.Show("Please select user type", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmUtype.Focus();
                return;
            }


            if (txtUname.Text == "")
            {
                MessageBox.Show("Please enter user name", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUname.Focus();
                return;
            }

            if (txtPword.Text == "")
            {
                MessageBox.Show("Please enter password", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPword.Focus();
                return;
            }

            if (txtNu.Text == "")
            {
                MessageBox.Show("Please new user name", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUname.Focus();
                return;
            }

            if (txtNp.Text == "")
            {
                MessageBox.Show("Please enter new password", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPword.Focus();
                return;
            }

            if (txtCp.Text == "")
            {
                MessageBox.Show("Please enter new password agin", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPword.Focus();
                return;
            }

            if (txtNp.Text != txtCp.Text)
            {
                MessageBox.Show("Password is not matched.\n" + "Try Again.", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCp.Focus();
                txtCp.Text = "";
                checkBox1.Checked = false;
                return;
            }
            else
            {
                checkBox1.Checked = true;
            }
            save();
        }

        private void txtCp_Leave(object sender, EventArgs e)
        {
            
        }

        private void FrmChangeAccount_Load(object sender, EventArgs e)
        {

            ToolTip t = new ToolTip();
            t.AutoPopDelay = 5000;
            // t.ReshowDelay = 500;
            t.ShowAlways = true;
            t.SetToolTip(this.btnOK, "Change Account (Enter)");


            t.SetToolTip(this.btnCancel, "Cancel (ESC)");
            this.Owner.Enabled = false;
        }

        private void FrmChangeAccount_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void FrmChangeAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Enabled = true;
        }

        private void FrmChangeAccount_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void FrmChangeAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.C))
            {
                if (cmUtype.Text == "------- Select User Type -------")
                {
                    MessageBox.Show("Please select user type", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmUtype.Focus();
                    return;
                }


                if (txtUname.Text == "")
                {
                    MessageBox.Show("Please enter user name", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUname.Focus();
                    return;
                }

                if (txtPword.Text == "")
                {
                    MessageBox.Show("Please enter password", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPword.Focus();
                    return;
                }

                if (txtNu.Text == "")
                {
                    MessageBox.Show("Please new user name", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUname.Focus();
                    return;
                }

                if (txtNp.Text == "")
                {
                    MessageBox.Show("Please enter new password", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPword.Focus();
                    return;
                }

                if (txtCp.Text == "")
                {
                    MessageBox.Show("Please enter new password agin", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPword.Focus();
                    return;
                }

                if (txtNp.Text != txtCp.Text)
                {
                    MessageBox.Show("Password is not matched.\n" + "Try Again.", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCp.Focus();
                    txtCp.Text = "";
                    checkBox1.Checked = false;
                    return;
                }
                else
                {
                    checkBox1.Checked = true;
                }
                save();
            }
        }

        private void txtPword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                txtNu.Focus(); ;

            }
        }

        private void cmUtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEmail.Focus();
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (txtEmail.Text.Length > 0)
            {
                if (!rEMail.IsMatch(txtEmail.Text))
                {
                    MessageBox.Show("Enter email in correct format.", "Library Managemennt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    e.Cancel = true;
                    txtEmail.Text = "";
                  
                }
            }
        }
    }
}
