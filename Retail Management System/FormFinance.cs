using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Retail_Management_System.Connection;

namespace Retail_Management_System
{
    public partial class FormFinance : Form
    {
        private String Format;
        private String Start;
        private String End;

        public FormFinance()
        {
            InitializeComponent();
        }

        private void FormFinances_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Daily";
            dtpStart.Value = DateTime.Today;
            dtpEnd.Value = DateTime.Today.AddDays(1);
            dtpEnd.MinDate = dtpStart.Value.AddDays(1);

            try
            {
                Format = "yyyy";
                Start = GetFirstSaleDate();
                End = DateTime.Today.ToString("MM/dd/yyyy");
                chart(Format, Start, End, "Overall", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There are no sales yet in this store.");
                this.Close();
            }
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            bool sort = true;
            DateTime startTime = dtpStart.Value;
            if (rBtnRange.Checked)
            {
                Start = startTime.ToString("MM/dd/yyyy");
                End = dtpEnd.Value.ToString("MM/dd/yyyy") + " 23:59:59";
                if (comboBox1.SelectedIndex == 0)
                    Format = "dd/MM/yy";
                else if (comboBox1.SelectedIndex == 1)
                    Format = "MMM yyyy";
                else if (comboBox1.SelectedIndex == 2)
                {
                    Format = "yyyy";
                }
            }
            else
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    Format = "hh:mm tt";
                    Start = startTime.ToString("MM/dd/yyyy");
                    End = Start + " 23:59:59";
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    DateTime thisMonth = new DateTime(startTime.Year, startTime.Month, 1);

                    Format = "dd MMM";
                    Start = thisMonth.ToString("MM/dd/yyyy");
                    End = thisMonth.AddMonths(1).AddDays(-1).ToString("MM/dd/yyyy") + " 23:59:59";
                    sort = false;
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    DateTime thisYear = new DateTime(startTime.Year, 1, 1);

                    Format = "MMM yyyy";
                    Start = thisYear.ToString("MM/dd/yyyy");
                    End = thisYear.AddYears(1).AddDays(-1).ToString("MM/dd/yyyy") + " 23:59:59";
                }
            }
            chart(Format, Start, End, comboBox1.SelectedItem.ToString(), sort);
        }

        private void BtnOverall_Click(object sender, EventArgs e)
        {
            Format = "yyyy";
            Start = GetFirstSaleDate();
            End = DateTime.Today.ToString("MM/dd/yyyy") + " 23:59:59";

            chart(Format, Start, End, "Overall", true);
        }

        private void BtnToday_Click(object sender, EventArgs e)
        {
            Format = "hh:mm tt";
            Start = DateTime.Today.ToString("MM/dd/yyyy");
            End = Start + " 23:59:59";

            chart(Format, Start, End, "Today", true);
        }

        private void BtnYesterday_Click(object sender, EventArgs e)
        {
            Format = "hh:mm tt";
            Start = DateTime.Today.AddDays(-1).ToString("MM/dd/yyyy");
            End = Start + " 23:59:59";
            chart(Format, Start, End, "Yesterday", true);
        }

        private void BtnWeek_Click(object sender, EventArgs e)
        {
            Format = "ddd";
            Start = DateTime.Today.AddDays(-7).ToString("MM/dd/yyyy");
            End = DateTime.Today.AddDays(-1).ToString("MM/dd/yyyy") + " 23:59:59";

            chart(Format, Start, End, "Last Week", false);
        }

        private void BtnMonth_Click(object sender, EventArgs e)
        {
            DateTime thisMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            Format = "dd MMM";
            Start = thisMonth.AddMonths(-1).ToString("MM/dd/yyyy");
            End = thisMonth.AddDays(-1).ToString("MM/dd/yyyy") + " 23:59:59";

            chart(Format, Start, End, "Last Month", false);
        }

        private void RBtnRange_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnRange.Checked)
                dtpEnd.Visible = true;
            else
                dtpEnd.Visible = false;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                customizeDateTimePicker("dd-MMM-yyyy dddd", false);
                dtpEnd.MinDate = dtpStart.Value.AddDays(1);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                customizeDateTimePicker("MMMM yyyy", true);
                dtpEnd.MinDate = dtpStart.Value.AddMonths(1);
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                customizeDateTimePicker("yyyy", true);
                dtpEnd.MinDate = dtpStart.Value.AddYears(1);
            }
        }

        private void chart(String Format, String Start, String End, String title, bool sort)
        {
            chartA.ChartAreas[0].AxisX.Interval = 1;
            chartA.Series["Series1"].XValueMember = "time";
            chartA.Series["Series1"].YValueMembers = "profit";
            chartA.DataSource = sort ? SelectTimeProfit(Format, Start, End, " order by cast(format([SALE].[SaleDate], '" + Format + "') as datetime)") : SelectTimeProfit(Format, Start, End, "");
            chartA.Titles[0].Text = title + " Profit";

            chartB.ChartAreas[0].AxisX.Interval = 1;
            chartB.Series["Series1"].XValueMember = "item";
            chartB.Series["Series1"].YValueMembers = "sold";
            chartB.DataSource = SelectSoldItem(Start, End);
            chartB.Titles[0].Text = title + " Sales";
        }

        private void customizeDateTimePicker(String format, bool showUpDown)
        {
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.CustomFormat = format;
            dtpStart.ShowUpDown = showUpDown;
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.CustomFormat = format;
            dtpEnd.ShowUpDown = showUpDown;
        }

        private void DtpStart_ValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                dtpEnd.MinDate = dtpStart.Value.AddDays(1);
            else if (comboBox1.SelectedIndex == 1)
                dtpEnd.MinDate = dtpStart.Value.AddMonths(1);
            else if (comboBox1.SelectedIndex == 2)
                dtpEnd.MinDate = dtpStart.Value.AddYears(1);
        }
    }
}
