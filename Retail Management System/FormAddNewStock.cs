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
    public partial class FormAddNewStock : Form
    {
        public List<object> AddedItem { get; private set; }

        public FormAddNewStock()
        {
            InitializeComponent();
        }

        private void FormAddNewStock_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = SelectItemNotInStock();
        }

        private void FormAddNewStock_Shown(object sender, System.EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No item can be added.");
                this.Close();
            }
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            AddedItem = new List<object>();
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                AddedItem.Add(dataGridView1.CurrentRow.Cells[i].Value);
            this.DialogResult = DialogResult.OK;
        }

    }
}
