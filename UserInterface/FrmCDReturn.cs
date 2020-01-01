using System;
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
    public partial class FrmCDReturn : Form
    {
        Issue add = new Issue();
        public FrmCDReturn()
        {
            InitializeComponent();
        }

        private void RefreshObject()
        {

            add.Return_date = dateTimePicker1.Text;
            add.Lcard = txtCard.Text;
            add.Fine = txtFine.Text;
            add.Payment = txtPayment.Text;
            add.Icopy = label5.Text;
            add.Mno = lbtMno.Text;
            add.Mnth = lbMonth.Text;
            add.Yr = lbYear.Text;


        }

        private void save()
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


            if (txtAcess.Text == "")
            {

                MessageBox.Show("Please enter CD Aceesion no.");
                txtAcess.Focus();
                return;
            }

            RefreshObject();
            // if (MessageBox.Show("Do you really want to Save Company Name?" + "  < " + add.Roll + ">  " + " ? ", "Confirm Save Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                // return;
            }

            try
            {
                if (txtFine.Text != "")
                {
                    add.InsertFine();
                }
                MessageBox.Show("CD returned successfully.", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                add.UpdateReturnCD();
                add.DeleteIssueCD();
                btnIssue.Enabled = false;
                txtAcess.Focus();
                txtAcess.Text="";
                txtTitle.Text = "";
                txtAuhor.Text = "";
                txtCard.Text = "";
                txtIssue.Text = "";
                txtReturn.Text = "";
                textBox2.Text = "";
                txtFine.Text = "";
                txtPayment.Text = "";
                //loadcatinfo();
            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            mycount();
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

        private void FrmCDReturn_Load(object sender, EventArgs e)
        {


            ToolTip t = new ToolTip();
            t.AutoPopDelay = 5000;
            // t.ReshowDelay = 500;
            t.ShowAlways = true;
            t.SetToolTip(this.btnIssue, "Return (Enter)");


            t.SetToolTip(this.btnCancel, "Cancel (ESC)");
            this.Owner.Enabled = false;
            mycount();
        }

        private void Title()
        {
            DataTable dt = new DataTable();

            string id = Convert.ToString(txtAcess.Text);


            add.Cd = id;

            dt = add.BookTitleCD(id);
            int j = dt.Rows.Count;

            if (j != 0)
            {
                try
                {
                    btnIssue.Enabled = true;
                    for (int i = 0; i < j; i++)
                    {
                        txtTitle.Text = dt.Rows[i]["title"].ToString();
                        txtAuhor.Text = dt.Rows[i]["author"].ToString();
                        txtCard.Text = dt.Rows[i]["card"].ToString();
                        txtIssue.Text = dt.Rows[i]["issued"].ToString();
                        txtReturn.Text = dt.Rows[i]["returnd"].ToString();

                    }

                  



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Book is not found.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




            }
            else
            {
                txtTitle.Text = "";
                txtAuhor.Text = "";
                txtCard.Text = "";
                txtIssue.Text = "";
                txtReturn.Text = "";
                textBox2.Text = "";
                txtFine.Text = "";
                txtPayment.Text = "";
                btnIssue.Enabled = false;
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (txtFine.Text != "")
            {
                if (txtPayment.Text == "")
                {
                    MessageBox.Show("Please enter payment.");
                    txtPayment.Focus();
                    return;
                }
            }
            save();
        }

        private void txtAcess_TextChanged(object sender, EventArgs e)
        {
            Title();

            if (txtAcess.Text == "")
            {
                txtTitle.Text = "";
                txtAuhor.Text = "";
                txtCard.Text = "";
                txtIssue.Text = "";
                txtReturn.Text = "";
                textBox2.Text = "";
                txtFine.Text = "";
                txtPayment.Text = "";
                btnIssue.Enabled = false;
               
            }
        }

        public void duration()
        {
            string a = dateTimePicker1.Text;
            string b = txtReturn.Text;

            DateTime dis = Convert.ToDateTime(a);
            DateTime admit = Convert.ToDateTime(b);

            int ddischarge = dis.Day;
            int mdischarge = dis.Month;
            int ydischarge = dis.Year;

            int dadmit = admit.Day;
            int madmit = admit.Month;
            int yadmit = admit.Year;

            if (mdischarge == madmit && ydischarge == yadmit && ddischarge == dadmit)
            {
                textBox2.Text = "";
            }

            if (mdischarge > madmit || ydischarge > yadmit || (mdischarge == madmit && ydischarge == yadmit && ddischarge > dadmit))
            {

                if (ydischarge == yadmit)
                {
                    int y1 = dis.DayOfYear;
                    int y2 = admit.DayOfYear;

                    int sub = Math.Abs(y1 - y2);
                    textBox2.Text = sub.ToString();





                }
                else
                {
                    if (madmit == 1 || madmit == 3 || madmit == 5 || madmit == 7 || madmit == 8 || madmit == 10 || madmit == 12)
                    {
                        if (ddischarge < dadmit)
                        {
                            ddischarge = ddischarge + 30;
                            int diffday = Math.Abs(ddischarge - dadmit);
                            madmit = madmit + 1;


                            if (mdischarge < madmit)
                            {

                                mdischarge = mdischarge + 12;
                                int diffmonth = Math.Abs(mdischarge - madmit);
                                int mtd = diffmonth * 30;
                                yadmit = yadmit + 1;
                                int diffyear = Math.Abs(ydischarge - yadmit);
                                int ytd = diffyear * 365;



                                int sum = diffday + mtd + ytd + 1;
                                textBox2.Text = sum.ToString();



                            }
                            else
                            {
                                int diffmonth = Math.Abs(mdischarge - madmit);
                                int mtd = diffmonth * 30;

                                int diffyear = Math.Abs(ydischarge - yadmit);
                                int ytd = diffyear * 365;


                                int sum = diffday + mtd + ytd + 1;
                                textBox2.Text = sum.ToString();
                            }

                        }



                        else
                        {
                            int diffday = Math.Abs(ddischarge - dadmit);


                            if (mdischarge < madmit)
                            {
                                mdischarge = mdischarge + 12;
                                int diffmonth = Math.Abs(mdischarge - madmit);
                                int mtd = diffmonth * 30;

                                yadmit = yadmit + 1;
                                int diffyear = Math.Abs(ydischarge - yadmit);
                                int ytd = diffyear * 365;


                                int sum = diffday + mtd + ytd + 1;
                                textBox2.Text = sum.ToString();
                            }



                            else
                            {
                                int diffmonth = Math.Abs(mdischarge - madmit);
                                int mtd = diffmonth * 30;

                                int diffyear = Math.Abs(ydischarge - yadmit);
                                int ytd = diffyear * 365;


                                int sum = diffday + mtd + ytd + 1;
                                textBox2.Text = sum.ToString();


                            }

                        }



                    }


                 // if (madmit == 2 || madmit == 4 || madmit == 6 || madmit == 9 || madmit == 11 )
                    else
                    {
                        if (ddischarge < dadmit)
                        {
                            ddischarge = ddischarge + 30;
                            int diffday = Math.Abs(ddischarge - dadmit);
                            madmit = madmit + 1;


                            if (mdischarge < madmit)
                            {

                                mdischarge = mdischarge + 12;
                                int diffmonth = Math.Abs(mdischarge - madmit);
                                int mtd = diffmonth * 30;
                                yadmit = yadmit + 1;
                                int diffyear = Math.Abs(ydischarge - yadmit);
                                int ytd = diffyear * 365;



                                int sum = diffday + mtd + ytd;
                                textBox2.Text = sum.ToString();



                            }
                            else
                            {
                                int diffmonth = Math.Abs(mdischarge - madmit);
                                int mtd = diffmonth * 30;

                                int diffyear = Math.Abs(ydischarge - yadmit);
                                int ytd = diffyear * 365;


                                int sum = diffday + mtd + ytd;
                                textBox2.Text = sum.ToString();
                            }

                        }



                        else
                        {
                            int diffday = Math.Abs(ddischarge - dadmit);


                            if (mdischarge < madmit)
                            {
                                mdischarge = mdischarge + 12;
                                int diffmonth = Math.Abs(mdischarge - madmit);
                                int mtd = diffmonth * 30;

                                yadmit = yadmit + 1;
                                int diffyear = Math.Abs(ydischarge - yadmit);
                                int ytd = diffyear * 365;


                                int sum = diffday + mtd + ytd;
                                textBox2.Text = sum.ToString();
                            }



                            else
                            {
                                int diffmonth = Math.Abs(mdischarge - madmit);
                                int mtd = diffmonth * 30;

                                int diffyear = Math.Abs(ydischarge - yadmit);
                                int ytd = diffyear * 365;


                                int sum = diffday + mtd + ytd;
                                textBox2.Text = sum.ToString();




                            }

                        }


                    }

                }


            }



        }

        private void txtReturn_TextChanged(object sender, EventArgs e)
        {
            if (txtReturn.Text != "")
            {
                duration();
            }
        }

        private void fine()
        {
            int fine, day;
            if (textBox2.Text == "")
            {
                txtFine.Text = "";
            }
            if (textBox2.Text != "")
            {
                day = Convert.ToInt32(textBox2.Text);
                if (day >= 1 && day <= 15)
                {
                    fine = day * 1;
                    txtFine.Text = fine.ToString();
                }
                else if (day >= 16 && day <= 45)
                {

                    fine = day * 2;
                    txtFine.Text = fine.ToString();

                }
                else
                {
                    fine = day * 5;
                    txtFine.Text = fine.ToString();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            fine();
        }

        private void FrmCDReturn_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Enabled = true;
        }

        private void txtFine_TextChanged(object sender, EventArgs e)
        {
            if (txtFine.Text != "")
            {
                txtPayment.Enabled = true;
            }
            else
            {
                txtPayment.Enabled = false;
            }
        }

        private void lbMonth_Click(object sender, EventArgs e)
        {

        }

        private void txtPayment_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPayment_TextChanged(object sender, EventArgs e)
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

            if (e.KeyChar == (char)8)
            {
                e.Handled = true;

            }
        }

        private void txtPayment_Leave(object sender, EventArgs e)
        {
            string g = txtPayment.Text;
          
            if (g != "")
            {
                double b = Convert.ToDouble(g);
                txtPayment.Text = String.Format("{0:0.00}", b);
            }
        }

        private void txtAcess_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCard_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
