using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Retail_Management_System
{
    public partial class FormMemberRegister : Form
    {
        public FormMemberRegister()
        {
            InitializeComponent();
        }

        private void ButtonEnter_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMemberID.Text))
            {
                MessageBox.Show("Please enter member ID! ");
                txtMemberID.Focus();
            }
            else if (txtMemberID.Text.Length != 10 || txtMemberID.Text.Substring(0, 1) != "B" || int.TryParse(txtMemberID.Text.Substring(1, 9), out int result) == false)
            {
                MessageBox.Show("Invalid member ID! Please try again. ");
                txtMemberID.Clear();
                txtMemberID.Focus();
            }
            else if (Connection.CheckExistOfMemberID(txtMemberID.Text) == "1")
            {
                MessageBox.Show("Member ID exist! Please try again. ");
                txtMemberID.Clear();
                txtMemberID.Focus();
            }

            else if (String.IsNullOrEmpty(txtMemberName.Text))
            {
                MessageBox.Show("Please enter member name! ");
                txtMemberName.Focus();
            }
            else if (Regex.IsMatch(txtMemberName.Text, @"^[a-zA-Z ]+$") == false)
            {
                MessageBox.Show("Invalid member name! Please try again. ");
                txtMemberName.Clear();
                txtMemberName.Focus();
            }
            else if (Connection.CheckExistOfMemberName(txtMemberName.Text) == "1")
            {
                MessageBox.Show("Member name exist! Please try again. ");
                txtMemberName.Clear();
                txtMemberName.Focus();
            }

            else if (String.IsNullOrEmpty(txtMemberPhoneNumber.Text))
            {
                MessageBox.Show("Please enter member phone number! ");
                txtMemberPhoneNumber.Focus();
            }
            else if (txtMemberPhoneNumber.Text.All(Char.IsDigit) == false || (txtMemberPhoneNumber.Text.Length != 10 && txtMemberPhoneNumber.Text.Length != 11))
            {
                MessageBox.Show("Invalid member phone number! Please try again. ");
                txtMemberPhoneNumber.Clear();
                txtMemberPhoneNumber.Focus();
            }
            else if (Connection.CheckExistOfMemberPhoneNumber(txtMemberPhoneNumber.Text) == "1")
            {
                MessageBox.Show("Member phone number exist! Please try again. ");
                txtMemberPhoneNumber.Clear();
                txtMemberPhoneNumber.Focus();
            }

            else
            {
                Connection.InsertMemberData(txtMemberID.Text, txtMemberName.Text, txtMemberPhoneNumber.Text);
                MessageBox.Show("Member " + txtMemberID.Text + " had registered successfully! ");
                this.Close();
            }
        }
    }
}
