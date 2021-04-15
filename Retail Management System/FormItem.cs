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
    public partial class FormItem : Form
    {
        public FormItem()
        {
            InitializeComponent();
        }

        private void FormItem_Load(object sender, EventArgs e)
        {
            reset();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                String ItemID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                try
                {
                    String value = "";
                    if (InputBox.Show("Update", "Please enter the " + comboBox1.SelectedItem, ref value) == DialogResult.OK)
                    {
                        UpdateItem(comboBox1.SelectedItem.ToString(), value, ItemID);
                        MessageBox.Show(comboBox1.SelectedItem + " of " + ItemID + " had been updated successfully!");
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
            InputBoxValidation valName = delegate (String val)
            {
                if (val == "")
                    return "Item name cannot be empty.";
                if (CheckExistOfItemName(val) != "0")
                    return "Item name exist.";
                return "";
            };
            InputBoxValidation valType = delegate (String val)
            {
                if (val == "")
                    return "Item type cannot be empty.";
                return "";
            };
            InputBoxValidation valCost = delegate (String val)
            {
                if (val == "")
                    return "Cost cannot be empty.";
                if (!double.TryParse(val, out double num))
                    return "Please enter a number.";
                if (num < 0)
                    return "Please enter a positive cost.";
                if (num != Math.Round(num, 2) && num != Math.Round(num, 1) && num != Math.Round(num, 0))
                    return "Please enter the cost with maximum 2 decimal places.";
                return "";
            };

            String[] promptText = new String[] { "Please enter the name: ", "Please enter the type: ", "Please enter the cost (RM): " };
            String[] value = new String[3];
            InputBoxValidation[] validation = new InputBoxValidation[] { valName, valType, valCost};

            if (InputBox.Show("Add New Item", promptText, ref value, validation, "New item has been added successfully.", 3) == DialogResult.OK)
            {
                String ID = (SelectAllItem().Rows.Count + 1).ToString(new String('0', 4));
                AddItem(ID, value[0], value[1], value[2]);
                reset();
            }

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                String name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                if (MessageBox.Show("Are you sure to delete " + name + " pemenantly? ", "Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteItem(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    MessageBox.Show(name + " had been deleted successfully!");
                    reset();
                }
            }
        }

        private void reset()
        {
            comboBox1.Text = "Name";
            comboBox1.SelectedIndex = 0;
            dataGridView1.DataSource = SelectAllItem();
        }
    }
}
