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
    public partial class FormCashierLogin : Form
    {
        public String CashierID { get; private set; }

        public FormCashierLogin()
        {
            InitializeComponent();
        }

        private void FormCashierLogin_Load(object sender, EventArgs e)
        {
            DataTable Cashier = SelectAllCashier();
            foreach (DataRow row in Cashier.Rows)
                foreach (var Item in row.ItemArray)
                    cmbCashierID.Items.Add(Item.ToString());
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (CheckCashierLogin(cmbCashierID.Text, txtCashierPassword.Text) == "1" || CheckAdminLogin(cmbCashierID.Text, txtCashierPassword.Text) == "1" || ((cmbCashierID.Text == Store.ID || cmbCashierID.Text == Store.Name) && txtCashierPassword.Text == GetStorePassword()))
            {
                this.Hide();
                this.CashierID = cmbCashierID.Text;
            }
            else if (cmbCashierID.Text == "Please select your ID" || String.IsNullOrEmpty(cmbCashierID.Text))
            {
                MessageBox.Show("Please enter the ID! ");
                cmbCashierID.Text = "Please select your ID";
                txtCashierPassword.Clear();
                cmbCashierID.Focus();
            }
            else if (Connection.CheckExistOfCashier(cmbCashierID.Text) == "0")
            {
                MessageBox.Show("ID doesn't exist! Please Try Again.");
                cmbCashierID.Text = "Please select your ID";
                txtCashierPassword.Clear();
                cmbCashierID.Focus();
            }
            else if (String.IsNullOrEmpty(txtCashierPassword.Text))
            {
                MessageBox.Show("Please enter your password! ");
                txtCashierPassword.Focus();
            }
            else
            {
                MessageBox.Show("Wrong Password! Please Try Again. ");
                txtCashierPassword.Clear();
                txtCashierPassword.Focus();
            }
        }
    }
}
