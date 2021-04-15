using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static Retail_Management_System.InputBox;
using static Retail_Management_System.Connection;

namespace Retail_Management_System
{
    public partial class FormStock : Form
    {
        private object beforeEdit;

        private bool CellValueChange;

        private bool focus = true;

        private int column;

        private int row;

        private DataTable ItemTable = new DataTable();

        private List<UpdatedItem> updatedItems = new List<UpdatedItem>();

        public FormStock()
        {
            InitializeComponent();
        }

        private void FormStock_Load(object sender, EventArgs e)
        {
            GenerateItemTable();
        }

        private void checked_CheckedChanged(object sender, EventArgs e)
        {
            if (ItemTable.Rows.Count != 0)
            {
                CheckBox checkBox = sender as CheckBox;
                int index = int.Parse(checkBox.Name.Substring(2));
                if (checkBox.Checked == true)
                {
                    dataGridView1.Columns[index].Visible = true;
                    if (index == column)
                    {
                        focus = true;
                        dataGridView1.CurrentCell = dataGridView1.Rows[row].Cells[column];
                    }
                }
                else
                {
                    if (focus)
                    {
                        column = dataGridView1.CurrentCell.ColumnIndex;
                        row = dataGridView1.CurrentCell.RowIndex;
                    }
                    dataGridView1.Columns[index].Visible = false;
                    if (index == column)
                        focus = false;
                }
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            GenerateItemTable();
            updatedItems.Clear();
            txtSearch.Clear();
        }

        private void BtnAddQuantity_Click(object sender, EventArgs e)
        {
            if (ItemTable.Rows.Count != 0)
            {
                if (updatedItems.Count != 0)
                    MessageBox.Show("Please update the edited items first! ");
                else if (focus)
                {
                    String ItemID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    String ItemName = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    int Qty = int.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());

                    InputBoxValidation validation = delegate (String val)
                    {
                        if (val == "")
                            return "Quantity cannot be empty.";
                        if (!int.TryParse(val, out int num))
                            return "Please enter a number.";
                        if (num <= 0)
                            return "Please enter a positive number.";
                        return "";
                    };

                    String value = "Please enter a quantity want to add";
                    if (InputBox.Show("Add Stock Quantity", ItemName + ": " + Qty + " pcs", ref value, validation) == DialogResult.OK)
                    {
                        int AddedQty = int.Parse(value) + Qty;
                        UpdateStockQuantity(ItemID, AddedQty);
                        MessageBox.Show("Quantity of " + ItemName + " has added successfully! \n\t\t" + Qty + " -> " + AddedQty);
                        GenerateItemTable();
                    }
                }
                else
                    MessageBox.Show("Please select an item first! ");
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show("Please enter the Item ID / Name ! ");
                return;
            }

            CellValueChange = false;
            ItemTable.Clear();
            ItemTable = ItemTable(txtSearch.Text);
            dataGridView1.DataSource = ItemTable.Copy();
            for (int i = 0; i < checkboxs.Count; i++)
                if (checkboxs[i].Checked == false)
                    dataGridView1.Columns[i].Visible = false;
            CellValueChange = true;

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Item not found! ");
                GenerateItemTable();
            }
            txtSearch.SelectAll();
            txtSearch.Focus();
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.SelectAll();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (updatedItems.Count != 0) 
            {
                dataGridView1.EndEdit();
                foreach (UpdatedItem item in updatedItems)
                    UpdateStockDetails(item.ID, item.Price, item.Quantity, item.Discount, true);
                MessageBox.Show("Updated Successfully! ");
                updatedItems.Clear();
                GenerateItemTable();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (updatedItems.Count != 0)
            {
                MessageBox.Show("Please update the edited items first! ");
                btnUpdate.Focus();
            }
            else
            {
                using (FormAddNewStock AddNewStock = new FormAddNewStock())
                {
                    AddNewStock.ShowDialog(this);
                    if (AddNewStock.DialogResult == DialogResult.OK)
                    {
                        int visible;
                        String ItemID = AddNewStock.AddedItem[0].ToString();
                        String ItemName = AddNewStock.AddedItem[1].ToString();
                        String ItemType = AddNewStock.AddedItem[2].ToString();
                        double ItemCost = double.Parse(AddNewStock.AddedItem[3].ToString());

                        DataRow newRow = ItemTable.NewRow();
                        for (int i = 0; i < AddNewStock.AddedItem.Count; i++)
                            newRow[i] = AddNewStock.AddedItem[i];
                        newRow[ItemTable.Columns.Count - 2] = 0;
                        newRow[ItemTable.Columns.Count - 1] = GetItemSoldQuantity(ItemID);

                        ItemTable.Rows.Add(newRow);
                        dataGridView1.DataSource = ItemTable.Copy();

                        for (visible = 0; visible < checkboxs.Count; visible++)
                            if (checkboxs[visible].Checked == true)
                                break;

                        dataGridView1.ClearSelection();
                        dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[visible];
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;

                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;

                        InputBoxValidation valPrice = delegate (String val)
                        {
                            if (val == "")
                                return "Price cannot be empty.";
                            if (!double.TryParse(val, out double num))
                                return "Please enter a number.";
                            if (num <= 0)
                                return "Please enter a positive price.";
                            if (num != Math.Round(num, 2) && num != Math.Round(num, 1) && num != Math.Round(num, 0))
                                return "Please enter the price with maximum 2 decimal places.";
                            if (num < ItemCost)
                                return "Price must greater or equal than its cost. ";
                            return "";
                        };
                        InputBoxValidation valQty = delegate (String val)
                        {
                            if (val == "")
                                return "Quantity cannot be empty.";
                            if (!int.TryParse(val, out int num))
                                return "Please enter a number.";
                            if (num <= 0)
                                return "Quantity must more than 0.";
                            return "";
                        };

                        String[] promptText = new String[] { "Please enter the price (RM): ", "Please enter the quantity: " };
                        String[] value = new String[] { ItemCost.ToString("#.##"), "1" };
                        InputBoxValidation[] validation = new InputBoxValidation[] { valPrice, valQty };

                        if (InputBox.Show("Add New Item", promptText, ref value, validation, ItemName + " has been added.", 2) == DialogResult.OK)
                        {
                            double ItemPrice = double.Parse(value[0]);
                            int ItemQty = int.Parse(value[1]);

                            ItemTable.Rows[ItemTable.Rows.Count - 1][4] = ItemPrice;
                            ItemTable.Rows[ItemTable.Rows.Count - 1][5] = ItemQty;

                            dataGridView1.DataSource = ItemTable.Copy();

                            dataGridView1.ClearSelection();
                            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[visible];
                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;

                            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;

                            if (CheckExistOfStock(ItemID) == "0")
                                InsertNewStock(ItemID, ItemPrice, ItemQty);
                            else
                                UpdateStockDetails(ItemID, ItemPrice, ItemQty, 0, true);
                        }
                        else
                        {
                            ItemTable.Rows.RemoveAt(ItemTable.Rows.Count - 1);
                            dataGridView1.DataSource = ItemTable.Copy();
                        }
                    }
                }
            }

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (ItemTable.Rows.Count != 0)
            {
                if (updatedItems.Count != 0)
                    MessageBox.Show("Please update the edited items first! ");
                else if (focus)
                {
                    String ItemID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    String ItemName = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    String ItemQty = dataGridView1.CurrentRow.Cells[5].Value.ToString();

                    if (MessageBox.Show(ItemName + ": " + ItemQty + " pcs\nDo you sure want to delete?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DeleteStock(ItemID);
                        GenerateItemTable();
                        MessageBox.Show(ItemName + " has been deleted.");
                    }
                }
                else
                    MessageBox.Show("Please select an item first! ");
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            beforeEdit = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (CellValueChange)
            {
                String value = dataGridView1.CurrentRow.Cells[e.ColumnIndex].Value.ToString();

                if (!double.TryParse(value, out double num) || double.Parse(value) < 0 || (e.ColumnIndex == 4 && num < double.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString())) || (e.ColumnIndex == 6 && num > 100))
                    dataGridView1.CurrentCell.Value = beforeEdit;
                else
                {
                    String ItemID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    double ItemPrice = Math.Round(double.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString()), 2, MidpointRounding.AwayFromZero);
                    int ItemQty = int.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());
                    double ItemDisc = double.Parse(dataGridView1.CurrentRow.Cells[6].Value.ToString());

                    for (int i = 0; i < updatedItems.Count; i++)
                    {
                        if (updatedItems[i].ID == ItemID)
                        {
                            updatedItems[i] = new UpdatedItem(ItemID, ItemPrice, ItemQty, ItemDisc);
                            return;
                        }
                    }
                    updatedItems.Add(new UpdatedItem(ItemID, ItemPrice, ItemQty, ItemDisc));
                }
            }
        }

        private void DataGridView1_CellEnter(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            focus = true;
        }

        private void GenerateItemTable()
        {
            CellValueChange = false;

            ItemTable.Clear();
            ItemTable = ItemTable();
            dataGridView1.DataSource = ItemTable.Copy();
            for (int i = 0; i < checkboxs.Count; i++)
                if (checkboxs[i].Checked == false)
                    dataGridView1.Columns[i].Visible = false;

            CellValueChange = true;
        }
    }
}
