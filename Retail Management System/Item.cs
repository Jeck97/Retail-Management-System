using System;
using System.Data;
using System.Windows.Forms;
using static Retail_Management_System.Connection;

namespace Retail_Management_System
{
    public class Item
    {
        public String ID { get; private set; }
        public String Name { get; private set; }
        public String Type { get; private set; }
        public double Cost { get; private set; }
        public double Price { get; private set; }
        public int Quantity { get; private set; }
        public double Discount { get; private set; }
        public int Sold { get; private set; }

        public Label lblName { get; private set; }
        public Label lblQty { get; private set; }
        public NumericUpDown numeric { get; private set; }
        public Button button { get; private set; }

        public Item(String ItemID, String CombinedIndex)
        {
            DataRow data = GetItemDetail(ItemID).Rows[0];

            this.ID = ItemID;
            this.Name = data[0].ToString();
            this.Type = data[1].ToString();
            this.Cost = double.Parse(data[2].ToString());
            this.Price = double.Parse(data[3].ToString());
            this.Quantity = int.Parse(data[4].ToString());
            this.Discount = double.Parse(data[5].ToString());
            this.Sold = int.TryParse(GetItemSoldQuantity(ItemID), out int num) ? num : 0;

            this.lblName = InitializeLabel(new Label(), this.Name, this.Price.ToString("0.00"));
            this.lblQty = InitializeLabel(new Label(), this.Quantity.ToString());
            this.numeric = InitializeNumericUpDown(new NumericUpDown(), this.Name, this.Quantity);
            this.button = InitializeButton(new Button(), CombinedIndex, this.Quantity);
        }

        private Label InitializeLabel(Label label, String Name, String Info)
        {
            label.Dock = DockStyle.Fill;
            label.Name = Name;
            label.Text = Name + "\nRM " + Info;

            return label;
        }

        private Label InitializeLabel(Label label, String Quantity)
        {
            label.Dock = DockStyle.Fill;
            label.Name = Quantity;
            label.Text = Quantity;

            return label;
        }

        private NumericUpDown InitializeNumericUpDown(NumericUpDown numericUpDown, String Name, int Quantity)
        {
            numericUpDown.Dock = DockStyle.Fill;
            numericUpDown.Name = Name;
            numericUpDown.Maximum = Quantity == 0 ? 0 : Quantity;
            numericUpDown.Minimum = Quantity == 0 ? 0 : 1;
            numericUpDown.Value = Quantity == 0 ? 0 : 1;
            numericUpDown.Enabled = true;
            numericUpDown.Visible = true;

            return numericUpDown;
        }

        private Button InitializeButton(Button button, String CombinedIndex, int Quantity)
        {
            button.Dock = DockStyle.Fill;
            button.Enabled = Quantity == 0 ? false : true;
            button.Name = CombinedIndex;
            button.UseVisualStyleBackColor = true;
            button.Visible = true;
            button.Text = "Add";

            return button;
        }

        public void Reset()
        {
            this.lblQty.Text = this.Quantity.ToString();

            this.numeric.Maximum = this.Quantity == 0 ? 0 : this.Quantity;
            this.numeric.Minimum = this.Quantity == 0 ? 0 : 1;
            this.numeric.Value = this.Quantity == 0 ? 0 : 1;

            this.button.Enabled = this.Quantity == 0 ? false : true;
        }

        public void DeduteQuantity()
        {
            this.Quantity = int.Parse(this.lblQty.Text);
        }
    }
}
