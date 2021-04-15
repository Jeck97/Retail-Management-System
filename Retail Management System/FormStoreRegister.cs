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
    public partial class FormStoreRegister : Form
    {
        public String RegisteredName { get; private set; }

        public FormStoreRegister()
        {
            InitializeComponent();
        }

        private void FormStoreRegister_Load(object sender, EventArgs e)
        {
      
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            if (CountAllStore() == "0")
            {
                Connection.InsertNewStore("001", txtStoreName.Text, txtStorePassword.Text, 'A');
                RegisteredName = txtStoreName.Text;

                MessageBox.Show("Register Successful! You are ADMIN now");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (Connection.CheckExistOfStoreName(txtStoreName.Text).ToString() == "1")
            {
                MessageBox.Show("Store name existed! Please change another store name.");
                txtStoreName.Clear();
                txtStorePasswordRetype.Clear();
                txtStorePassword.Clear();
                txtStoreName.Focus();
            }
            else
            {
                String newID = (int.Parse(Connection.SelectLastStoreID()) + 1).ToString(new String('0', Connection.SelectLastStoreID().Length));
                Connection.InsertNewStore(newID, txtStoreName.Text, txtStorePassword.Text, 'N');
                RegisteredName = txtStoreName.Text;

                MessageBox.Show("Register Successful! ");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void TxtStoreName_TextChanged(object sender, EventArgs e)
        {
            buttonRegisterEnabled();
        }

        private void TxtStorePassword_TextChanged(object sender, EventArgs e)
        {
            checkBox1Enabled();
            buttonRegisterEnabled();
        }

        private void TxtStorePasswordRetype_TextChanged(object sender, EventArgs e)
        {
            checkBox1Enabled();
            buttonRegisterEnabled();
        }

        private void buttonRegisterEnabled()
        {
            if (!String.IsNullOrWhiteSpace(txtStoreName.Text) && checkBox1.Checked == true)
                buttonRegister.Enabled = true;
            else
                buttonRegister.Enabled = false;
        }

        private void checkBox1Enabled()
        {
            if (!String.IsNullOrWhiteSpace(txtStorePassword.Text) && txtStorePasswordRetype.Text == txtStorePassword.Text)
                checkBox1.Checked = true;
            else
                checkBox1.Checked = false;
        }
    }
}
