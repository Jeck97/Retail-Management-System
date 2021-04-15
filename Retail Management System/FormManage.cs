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
using static Retail_Management_System.InputBox;

namespace Retail_Management_System
{
    public partial class FormManage : Form
    {
        public FormManage()
        {
            InitializeComponent();
        }

        private void FormManage_Load(object sender, EventArgs e)
        {
            reset();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                String EmployeeID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                try
                {
                    String value = "";
                    if (InputBox.Show("Update", "Please enter the " + comboBox1.SelectedItem, ref value) == DialogResult.OK)
                    {
                        UpdateEmployee(comboBox1.SelectedItem.ToString(), value, EmployeeID);
                        MessageBox.Show(comboBox1.SelectedItem + " of " + EmployeeID + " had been updated successfully!");
                        reset();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Invalid input! ", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            InputBoxValidation validation = delegate (String val)
            {
                if (val == "")
                    return "Name cannot be empty.";
                return "";
            };

            String value = "";
            if (InputBox.Show("Add New Employee", "Please enter the employee's name: ", ref value, validation) == DialogResult.OK)
            {
                int tailID = int.Parse(CountEmployee()) + 1;
                String ID = Store.ID + tailID.ToString(new String('0', 2));
                AddEmployee(ID, value);
                MessageBox.Show(value + " had been added successfully!\nThe ID number is " + ID);
                reset();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                String name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                if(MessageBox.Show("Are you sure to delete "+name+" pemenantly? ", "Delete Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteEmployee(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    MessageBox.Show(name + " had been deleted successfully!");
                    reset();
                }
            }
        }

        private void reset()
        {
            comboBox1.Text = "Name";
            comboBox1.SelectedIndex = 0;
            dataGridView1.DataSource = SelectAllEmployee();
        }
    }
}
