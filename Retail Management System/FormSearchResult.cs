using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retail_Management_System
{
    public partial class FormSearchResult : Form
    {
        String SearchMemberDetails = "{0,-15}{1,-30}{2,-15}{3,5}{4, 30}";
        DataTable MemberData;

        public String SelectedResult { get; private set; }

        public FormSearchResult(DataTable dt)
        {
            InitializeComponent();
            MemberData = dt;
        }

        private void FormSearchResult_Load(object sender, EventArgs e)
        {
            foreach(DataRow row in MemberData.Rows)
                listBoxSearchResult.Items.Add(String.Format(SearchMemberDetails, row[0], row[1], row[2], row[3], row[4]));
        }

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            if (listBoxSearchResult.SelectedIndex == -1)
                MessageBox.Show("Please select a member first! ");
            else
            {
                this.DialogResult = DialogResult.OK;
                this.SelectedResult = listBoxSearchResult.SelectedItem.ToString().Substring(0, 65);
            }
        }
    }
}
