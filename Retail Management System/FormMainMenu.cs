using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Retail_Management_System.InputBox;
using static Retail_Management_System.Connection;

namespace Retail_Management_System
{
    public partial class FormMainMenu : Form
    {
        private bool confirmation = true;

        public FormMainMenu()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(MainMenu_FormClosing);
        }

        private void FormMainMenu_Load(object sender, EventArgs e)
        {
            LoginPage();
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && confirmation)
            {
                dynamic result = MessageBox.Show("Do You Want To Exit?", "Exit", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    Application.Exit();

                if (result == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void ButtonLogout_Click(object sender, EventArgs e)
        {
            LoginPage();
        }

        private void LoginPage()
        {
            using (FormStoreLogin StoreLogin = new FormStoreLogin())
            {
                this.Hide();
                StoreLogin.ShowDialog(this);

                if (StoreLogin.DialogResult == DialogResult.OK)
                {
                    labelStoreName.Text = Store.Name;
                    if (Store.Type == 'A')
                        btnItem.Visible = true;
                    else
                        btnItem.Visible = false;
                    this.Show();
                }
                else
                {
                    confirmation = false;
                    this.Close();
                }
            }
        }

        private void Cashier_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormCashier Cashier = new FormCashier();
            Cashier.FormClosed += new FormClosedEventHandler(Closed_FormClosed);
            Cashier.Show();
        }

        private void ButtonFinance_Click(object sender, EventArgs e)
        {
            InputBoxValidation validation = delegate (String val)
            {
                if (val == "")
                    return "Please enter the password! ";
                if (val == GetStorePassword())
                    return "";
                return "Incorrect Password! Please Try Again.";
            };

            if (InputBox.Password("Request Store Password", "Please enter the STORE password: ", validation) == DialogResult.OK)
            {
                this.Hide();
                FormFinance Finance = new FormFinance();
                Finance.FormClosed += new FormClosedEventHandler(Closed_FormClosed);
                Finance.Show();
            }
        }

        private void ButtonStock_Click(object sender, EventArgs e)
        {
            InputBoxValidation validation = delegate (String val)
            {
                if (val == "")
                    return "Please enter the password! ";
                if (val == GetStorePassword())
                    return "";
                return "Incorrect Password! Please Try Again.";
            };

            if (InputBox.Password("Request Store Password", "Please enter the STORE password: ", validation) == DialogResult.OK)
            {
                this.Hide();
                FormStock Stock = new FormStock();
                Stock.FormClosed += new FormClosedEventHandler(Closed_FormClosed);
                Stock.Show();
            }
        }

        private void ButtonManage_Click(object sender, EventArgs e)
        {
            InputBoxValidation validation = delegate (String val)
            {
                if (val == "")
                    return "Please enter the password! ";
                if (val == GetStorePassword())
                    return "";
                return "Incorrect Password! Please Try Again.";
            };

            if (InputBox.Password("Request Store Password", "Please enter the STORE password: ", validation) == DialogResult.OK)
            {
                this.Hide();
                FormManage Manage = new FormManage();
                Manage.FormClosed += new FormClosedEventHandler(Closed_FormClosed);
                Manage.Show();
            }
        }

        private void BtnItem_Click(object sender, EventArgs e)
        {
            InputBoxValidation validation = delegate (String val)
            {
                if (val == "")
                    return "Please enter the password! ";
                if (CheckAdminPassword(val) == "1")
                    return "";
                return "Incorrect Password! Please Try Again.";
            };

            if (InputBox.Password("Request Admin Password", "Please enter the ADMIN password: ", validation) == DialogResult.OK)
            {
                this.Hide();
                FormItem Item = new FormItem();
                Item.FormClosed += new FormClosedEventHandler(Closed_FormClosed);
                Item.Show();
            }
        }

        private void Closed_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
