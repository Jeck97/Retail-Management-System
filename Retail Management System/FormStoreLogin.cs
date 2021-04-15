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
    public partial class FormStoreLogin : Form
    {
        public FormStoreLogin()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (Connection.CheckStoreNameAndPassword(txtStoreName.Text, txtStorePassword.Text) == "1")
            {
                new Store(txtStoreName.Text);
                this.DialogResult = DialogResult.OK;
            }
            else if (txtStoreName.Text == "Please enter your store name" || String.IsNullOrEmpty(txtStoreName.Text))
                Alert("Please enter the store name! ", true, true, true, false);
            else if (CheckExistOfStoreName(txtStoreName.Text) == "0")
                Alert("Store name doesn't exist! Please Try Again. ", true, true, true, false);
            else if (String.IsNullOrEmpty(txtStorePassword.Text))
                Alert("Please enter your password! ", false, true, false, true);
            else
                Alert("Wrong Password! Please Try Again.", false, true, false, true);
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            if (CountAllStore() != "0")
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
                    using (FormStoreRegister StoreRegister = new FormStoreRegister())
                    {
                        StoreRegister.ShowDialog(this);
                    }
                }
            }
            else
            {
                using (FormStoreRegister StoreRegister = new FormStoreRegister())
                {
                    StoreRegister.ShowDialog(this);
                }
            }

        }

        private void Alert(String Alert, bool NameClear, bool PassClear, bool NameFocus, bool PassFocus)
        {
            MessageBox.Show(Alert);

            if(NameClear)
                txtStoreName.Text = "Please enter your store name";
            if (PassClear)
                txtStorePassword.Clear();
            if (NameFocus)
            {
                txtStoreName.SelectAll();
                txtStoreName.Focus();
            }
            if (PassFocus)
            {
                txtStorePassword.SelectAll();
                txtStorePassword.Focus();
            }
        }
    }
}
