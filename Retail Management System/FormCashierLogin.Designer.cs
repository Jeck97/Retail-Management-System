namespace Retail_Management_System
{
    partial class FormCashierLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCashierID = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCashierPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(234, 153);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonLogin.Size = new System.Drawing.Size(116, 44);
            this.buttonLogin.TabIndex = 5;
            this.buttonLogin.TabStop = false;
            this.buttonLogin.Text = "LOGIN";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "ID / Name";
            // 
            // cmbCashierID
            // 
            this.cmbCashierID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCashierID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCashierID.FormattingEnabled = true;
            this.cmbCashierID.Location = new System.Drawing.Point(163, 52);
            this.cmbCashierID.Name = "cmbCashierID";
            this.cmbCashierID.Size = new System.Drawing.Size(342, 24);
            this.cmbCashierID.Sorted = true;
            this.cmbCashierID.TabIndex = 0;
            this.cmbCashierID.Text = "Please select your ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Password";
            // 
            // txtCashierPassword
            // 
            this.txtCashierPassword.Location = new System.Drawing.Point(163, 93);
            this.txtCashierPassword.Name = "txtCashierPassword";
            this.txtCashierPassword.Size = new System.Drawing.Size(342, 22);
            this.txtCashierPassword.TabIndex = 1;
            this.txtCashierPassword.UseSystemPasswordChar = true;
            // 
            // FormCashierLogin
            // 
            this.AcceptButton = this.buttonLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 253);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCashierID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCashierPassword);
            this.Controls.Add(this.buttonLogin);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "FormCashierLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cashier Login";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormCashierLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCashierID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCashierPassword;
    }
}