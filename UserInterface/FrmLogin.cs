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
    public partial class FrmLogin : Form
    {
        Login add = new Login();
        DataTable dt = new DataTable();
        public FrmLogin()
        {
            InitializeComponent();
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
            if (e.KeyChar == '.' || e.KeyChar == '_' )
            {
                e.Handled = false;
            }
            if (e.KeyChar == (char)13)
            {

                txtPword.Focus(); ;

            }
        }

        private void txtPword_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmUtype_KeyPress(object sender, KeyPressEventArgs e)
        {


            e.Handled = true;
           
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void login()
        {

            try
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

            dt = add.LoadAccount(cmUtype.Text,txtUname.Text,txtPword.Text);
           int  j = dt.Rows.Count;

            if (j !=0)
            {

                this.Hide();
                FrmMain f = new FrmMain();
                f.Show();
                f.lbuname.Text = cmUtype.Text;
                f.lblProfile.Text = txtUname.Text;
                f.lvTupe.Text = cmUtype.Text;
                if (cmUtype.Text == "Admin")
                {
                    f.registrationToolStripMenuItem.Enabled = true;
                }
                else
                {
                    f.registrationToolStripMenuItem.Enabled = false;
                }
                
             }
           
                    else
                    {
                      MessageBox.Show("Login Unsuccessful !\nSorry ! Your Username or Password is incorrect.\n" + "Please enter an valid Username and Password.", "Library Mnagement", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
                        txtUname.Focus();
                        txtUname.Text = "";
                        txtPword.Text = "";

                    }
                








            }

            catch (Exception)
            {
                MessageBox.Show("Login Unsuccessful !\nSorry ! Your Username or Password is incorrect.\n" + "Please enter an valid Username and Password.", "Library Mnagement", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            login();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
           // this.Owner.Hide();
            ToolTip t = new ToolTip();
            t.AutoPopDelay = 5000;
            // t.ReshowDelay = 500;
            t.ShowAlways = true;
            t.SetToolTip(this.btnOK, "Login (Ctrl+L)");


            t.SetToolTip(this.btnCancel, "Cancel (ESC)");
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
           // this.Owner.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FrmChangeAccount f = new FrmChangeAccount();
           // f.Owner = this;
            f.Show();
            f.txtEmail.Focus();

        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.L))
            {
                login();
            }
        }

        private void cmUtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUname.Focus();
        }
    }
}
