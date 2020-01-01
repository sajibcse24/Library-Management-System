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
using Library_Management_System.Report;

namespace Library_Management_System.UserInterface
{
    public partial class AnnualReport : Form
    {
        Book book = new Book();
        DataTable dt = new DataTable();
        public AnnualReport()
        {
            InitializeComponent();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
        
        }

        private void AnnualReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Enabled = true;
        }

        private void AnnualReport_Load(object sender, EventArgs e)
        {
            this.Owner.Enabled = false;
            ToolTip t = new ToolTip();
            t.AutoPopDelay = 5000;
            // t.ReshowDelay = 500;
            t.ShowAlways = true;
            t.SetToolTip(this.btnPrint, "Press Enter to Print");
            t.SetToolTip(this.btnCancel, "Cancel (ESC)");
           
         
           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
           
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true)
            {
                txtFinal.Text = "";
                cmYear.Text = "   SELECT";
                cmMonth.Text = "   SELECT";
                comboBox1.Text = "   SELECT";
                comboBox2.Text = "   SELECT";
                btnPrint.Enabled = true;
                checkBox2.Checked = false;
                groupBox2.Text = "From";
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
            }
            if (checkBox1.Checked == false)
            {
                txtFinal.Text = "";
                cmYear.Text = "   SELECT";
                cmMonth.Text = "   SELECT";
                comboBox1.Text = "   SELECT";
                comboBox2.Text = "   SELECT";
               // btnPrint.Enabled = false;
               // checkBox2.Checked = true;
                groupBox2.Text = "From";
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                cmYear.Text = "   SELECT";
                cmMonth.Text = "   SELECT";
                comboBox1.Text = "   SELECT";
                comboBox2.Text = "   SELECT";
                txtFinal.Text = "";
                btnPrint.Enabled = true;
                checkBox1.Checked = false;
                groupBox2.Text = "Searh By Month";
                groupBox2.Enabled = true;
                groupBox3.Enabled = false;
            }

            if (checkBox2.Checked == false)
            {
                txtFinal.Text = "";
                cmYear.Text = "   SELECT";
                cmMonth.Text = "   SELECT";
                comboBox1.Text = "   SELECT";
                comboBox2.Text = "   SELECT";
               // btnPrint.Enabled = false;
               // checkBox1.Checked = true;
                groupBox2.Text = "From";
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrintReportYear()
        {
            try
            {
                
                    if (txtFinal.Text != "" && txtM2.Text != "")
                    {
                        string a = txtFinal.Text;
                        string b = txtM2.Text;
                        DateTime d1 = Convert.ToDateTime(a);
                        DateTime d2 = Convert.ToDateTime(b);

                        // string b = dt1.ToString();
                        lbFM.Text = d1.ToString();
                        lbM2.Text = d2.ToString();
                        yearreport();
                    


                }

                    else
                    {
                        MessageBox.Show("Informtion are not available", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void PrintReportMonth()
        {
           
                
                   
                    
                        monthreport();
                    


                
            
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (cmMonth.Text == "   SELECT")
                {
                    MessageBox.Show("Please select month", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmMonth.Focus();
                    return;
                }

                if (cmYear.Text == "   SELECT")
                {
                    MessageBox.Show("Please select year", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmYear.Focus();
                    return;
                }
                if (comboBox2.Text == "   SELECT")
                {
                    MessageBox.Show("Please select month", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmMonth.Focus();
                    return;
                }

                if (comboBox1.Text == "   SELECT")
                {
                    MessageBox.Show("Please select year", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmYear.Focus();
                    return;
                }
                PrintReportYear();
            }
            if (checkBox2.Checked == true)
            {
                if (cmMonth.Text == "   SELECT")
                {
                    MessageBox.Show("Please select month", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmMonth.Focus();
                    return;
                }

                if (cmYear.Text == "   SELECT")
                {
                    MessageBox.Show("Please select year", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmYear.Focus();
                    return;
                }
                PrintReportMonth();
            }
        }
       

        private void yearreport()
        {
             DataSetLibrary ds = new DataSetLibrary();

                CrystalReportAnnual rpt = new CrystalReportAnnual();

                FrmReportViewer rptViewer = new FrmReportViewer();




                double sum = 0;
                try
                {
                    dt = book.AnnualReport(lbFM.Text, lbM2.Text);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dataRow in dt.Rows)
                        {
                            DataSetLibrary.DataTableAnnualReportRow row = ds.DataTableAnnualReport.NewDataTableAnnualReportRow();
                            row.ITEM = dataRow["item"].ToString();

                            row.TOTAL_TITLE = dataRow["title"].ToString();

                            row.TOTAL_COPY = dataRow["total_copy"].ToString();
                            row.TOTAL_ISSUE = dataRow["total_issue"].ToString();
                            row.TOTAL_DAMAGE = dataRow["damage"].ToString();
                            row.TOTAL_COST = dataRow["cost"].ToString();
                            sum +=Convert.ToDouble( dataRow["cost"].ToString());
                            row.DataColumn12 = sum.ToString();
                            string m = cmMonth.Text;
                            string y = cmYear.Text;
                            string y1 = comboBox1.Text;
                            string y2 = comboBox2.Text;
                            row.DataColumn7 = m.ToString() + ", " + y.ToString() + "  -  " + y2.ToString() + ", " + y1.ToString();
                            //string y = cmYear.Text;
                          //  row.DataColumn8 = y.ToString();
                          
                          row.DataColumn9 ="Annual Report";
                           
                           // row.DataColumn10 = y1.ToString();
                           
                          



                            //  row.DataColumn16 = dataRow["serial"].ToString();
                            //  row.DataColumn17 = "Outdoor-Patients' Visting Bill Report";


                            ds.DataTableAnnualReport.AddDataTableAnnualReportRow(row);
                        }

                        rptViewer.ShowReport(rpt, ds);

                    }
                    else
                    {
                        MessageBox.Show("Informtion are not available", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void monthreport()
        {
            DataSetLibrary ds = new DataSetLibrary();

            CrystalReportAnnual rpt = new CrystalReportAnnual();

            FrmReportViewer rptViewer = new FrmReportViewer();





            try
            {
                dt = book.AnnualReportMonth(cmMonth.Text,cmYear.Text);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        DataSetLibrary.DataTableAnnualReportRow row = ds.DataTableAnnualReport.NewDataTableAnnualReportRow();
                        row.ITEM = dataRow["item"].ToString();

                        row.TOTAL_TITLE = dataRow["title"].ToString();

                        row.TOTAL_COPY = dataRow["total_copy"].ToString();
                        row.TOTAL_ISSUE = dataRow["total_issue"].ToString();
                        row.TOTAL_DAMAGE = dataRow["damage"].ToString();
                        row.TOTAL_COST = dataRow["cost"].ToString();
                        string m = cmMonth.Text;
                        string y = cmYear.Text;

                        row.DataColumn8 = m.ToString() +" - " + y.ToString() ;
                        row.DataColumn9 = "Monthly Report";
                        //string y = cmYear.Text;
                        //  row.DataColumn8 = y.ToString();

                        //  row.DataColumn9 = y2.ToString()+"," + y1.ToString();

                        // row.DataColumn10 = y1.ToString();





                        //  row.DataColumn16 = dataRow["serial"].ToString();
                        //  row.DataColumn17 = "Outdoor-Patients' Visting Bill Report";


                        ds.DataTableAnnualReport.AddDataTableAnnualReportRow(row);
                    }

                    rptViewer.ShowReport(rpt, ds);

                }

                else
                {
                    MessageBox.Show("Informtion are not available", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Informtion are not available", "Library Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            //month();
           // txtAccession.Text = lbMonth.Text;
            if (cmMonth.Text != "   SELECT" && cmYear.Text != "   SELECT")
            {
                txtFinal.Text = cmMonth.Text + "/" + "01/" + cmYear.Text;
            }
        }

       

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
              
            if (comboBox1.Text != "   SELECT" && comboBox2.Text != "   SELECT")
            {
                if (comboBox2.Text == "January" || comboBox2.Text == "March" || comboBox2.Text == "May" || comboBox2.Text == "July" || comboBox2.Text == "August" || comboBox2.Text == "October" ||comboBox2.Text == "December")
                {
                    txtM2.Text = comboBox2.Text + "/" + "31/" + comboBox1.Text;
                }
            }

            if (comboBox1.Text != "   SELECT" && comboBox2.Text != "   SELECT")
            {
                if (comboBox2.Text =="June" ||comboBox2.Text=="April" ||comboBox2.Text =="September" || comboBox2.Text =="November")
                {

                    txtM2.Text = comboBox2.Text + "/" + "30/" + comboBox1.Text;
                }
            }

            if (comboBox1.Text != "   SELECT" && comboBox2.Text != "   SELECT")
            {
                if (comboBox2.Text == "February")
                {
                    txtM2.Text = comboBox2.Text + "/" + "28/" + comboBox1.Text;
                }
            }

            if (comboBox1.Text != "   SELECT" && comboBox2.Text != "   SELECT")
            {
                if (comboBox1.Text == "2016" || comboBox1.Text == "2020" || comboBox1.Text == "2024" || comboBox1.Text == "2028" || comboBox1.Text == "2032")
                {
                    if (comboBox2.Text == "February")
                    {
                        txtM2.Text = comboBox2.Text + "/" + "29/" + comboBox1.Text;
                    }
                }
            }
        }

        private void cmYear_SelectedIndexChanged(object sender, EventArgs e)
        {
           // textBox1.Text = cmYear.Text;
            if (cmMonth.Text != "   SELECT" && cmYear.Text != "   SELECT")
            {
                txtFinal.Text = cmMonth.Text + "/" + "01/" + cmYear.Text;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "   SELECT" && comboBox2.Text != "   SELECT")
            {
                if (comboBox2.Text == "January" || comboBox2.Text == "March" || comboBox2.Text == "May" || comboBox2.Text == "July" || comboBox2.Text == "August" || comboBox2.Text == "October" || comboBox2.Text == "December")
                {
                    txtM2.Text = comboBox2.Text + "/" + "31/" + comboBox1.Text;
                }
            }

            if (comboBox1.Text != "   SELECT" && comboBox2.Text != "   SELECT")
            {
                if (comboBox2.Text == "June" || comboBox2.Text == "April" || comboBox2.Text == "September" || comboBox2.Text == "November")
                {

                    txtM2.Text = comboBox2.Text + "/" + "30/" + comboBox1.Text;
                }
            }

            if (comboBox1.Text != "   SELECT" && comboBox2.Text != "   SELECT")
            {
                if (comboBox2.Text == "February")
                {
                    txtM2.Text = comboBox2.Text + "/" + "28/" + comboBox1.Text;
                }
            }

            if (comboBox1.Text != "   SELECT" && comboBox2.Text != "   SELECT")
            {
                if (comboBox1.Text == "2016" || comboBox1.Text == "2020" || comboBox1.Text == "2024" || comboBox1.Text == "2028" || comboBox1.Text == "2032")
                {
                    if (comboBox2.Text == "February")
                    {
                        txtM2.Text = comboBox2.Text + "/" + "29/" + comboBox1.Text;
                    }
                }
            }
        }

        private void cmMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void AnnualReport_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (checkBox1.Checked == true)
                {
                    PrintReportYear();
                }
                if (checkBox2.Checked == true)
                {
                    PrintReportMonth();
                }
            }
        }
    }
}
