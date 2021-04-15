using System;
using System.Drawing;

namespace Retail_Management_System
{
    partial class FormCashier
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
            this.listboxPurchaseDetails = new System.Windows.Forms.ListBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.listboxMemberDetails = new System.Windows.Forms.ListBox();
            this.buttonSearchMember = new System.Windows.Forms.Button();
            this.txtMember = new System.Windows.Forms.TextBox();
            this.buttonNewMember = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonPay = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelTotalPrice = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.labelHeaderPurchaseDetails = new System.Windows.Forms.Label();
            this.numericUpDownDelete = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelete)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // listboxPurchaseDetails
            // 
            this.listboxPurchaseDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listboxPurchaseDetails.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listboxPurchaseDetails.FormattingEnabled = true;
            this.listboxPurchaseDetails.ItemHeight = 18;
            this.listboxPurchaseDetails.Location = new System.Drawing.Point(3, 28);
            this.listboxPurchaseDetails.Name = "listboxPurchaseDetails";
            this.listboxPurchaseDetails.Size = new System.Drawing.Size(648, 367);
            this.listboxPurchaseDetails.TabIndex = 0;
            this.listboxPurchaseDetails.SelectedIndexChanged += new System.EventHandler(this.ListboxPurchaseDetails_SelectedIndexChanged);
            // 
            // buttonClear
            // 
            this.buttonClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClear.Location = new System.Drawing.Point(3, 13);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(99, 60);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.Text = "Clear Screen";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // listboxMemberDetails
            // 
            this.listboxMemberDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listboxMemberDetails.FormattingEnabled = true;
            this.listboxMemberDetails.ItemHeight = 16;
            this.listboxMemberDetails.Location = new System.Drawing.Point(3, 10);
            this.listboxMemberDetails.Margin = new System.Windows.Forms.Padding(3, 10, 3, 25);
            this.listboxMemberDetails.Name = "listboxMemberDetails";
            this.listboxMemberDetails.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listboxMemberDetails.Size = new System.Drawing.Size(654, 26);
            this.listboxMemberDetails.TabIndex = 2;
            // 
            // buttonSearchMember
            // 
            this.buttonSearchMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSearchMember.Location = new System.Drawing.Point(286, 3);
            this.buttonSearchMember.Name = "buttonSearchMember";
            this.buttonSearchMember.Size = new System.Drawing.Size(80, 49);
            this.buttonSearchMember.TabIndex = 1;
            this.buttonSearchMember.Text = "Search";
            this.buttonSearchMember.UseVisualStyleBackColor = true;
            this.buttonSearchMember.Click += new System.EventHandler(this.ButtonSearchMember_Click);
            // 
            // txtMember
            // 
            this.txtMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMember.Location = new System.Drawing.Point(3, 27);
            this.txtMember.Name = "txtMember";
            this.txtMember.Size = new System.Drawing.Size(271, 22);
            this.txtMember.TabIndex = 3;
            // 
            // buttonNewMember
            // 
            this.buttonNewMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNewMember.Location = new System.Drawing.Point(372, 3);
            this.buttonNewMember.Name = "buttonNewMember";
            this.buttonNewMember.Size = new System.Drawing.Size(61, 49);
            this.buttonNewMember.TabIndex = 1;
            this.buttonNewMember.Text = "New";
            this.buttonNewMember.UseVisualStyleBackColor = true;
            this.buttonNewMember.Click += new System.EventHandler(this.ButtonNewMember_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter member ID / name :";
            // 
            // buttonPay
            // 
            this.buttonPay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPay.Location = new System.Drawing.Point(318, 13);
            this.buttonPay.Name = "buttonPay";
            this.buttonPay.Size = new System.Drawing.Size(101, 60);
            this.buttonPay.TabIndex = 1;
            this.buttonPay.Text = "Payment";
            this.buttonPay.UseVisualStyleBackColor = true;
            this.buttonPay.Click += new System.EventHandler(this.ButtonPay_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDelete.Location = new System.Drawing.Point(3, 3);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(93, 29);
            this.buttonDelete.TabIndex = 8;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // labelTotalPrice
            // 
            this.labelTotalPrice.BackColor = System.Drawing.Color.White;
            this.labelTotalPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTotalPrice.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelTotalPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalPrice.Location = new System.Drawing.Point(431, 0);
            this.labelTotalPrice.Name = "labelTotalPrice";
            this.labelTotalPrice.Size = new System.Drawing.Size(214, 82);
            this.labelTotalPrice.TabIndex = 9;
            this.labelTotalPrice.Text = "RM 0.00";
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(663, 64);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(436, 486);
            this.tabControl1.TabIndex = 10;
            // 
            // labelHeaderPurchaseDetails
            // 
            this.labelHeaderPurchaseDetails.BackColor = System.Drawing.Color.White;
            this.labelHeaderPurchaseDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelHeaderPurchaseDetails.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelHeaderPurchaseDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHeaderPurchaseDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeaderPurchaseDetails.Location = new System.Drawing.Point(3, 0);
            this.labelHeaderPurchaseDetails.Name = "labelHeaderPurchaseDetails";
            this.labelHeaderPurchaseDetails.Size = new System.Drawing.Size(648, 25);
            this.labelHeaderPurchaseDetails.TabIndex = 11;
            this.labelHeaderPurchaseDetails.Text = "listboxPurchaseTitle";
            // 
            // numericUpDownDelete
            // 
            this.numericUpDownDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownDelete.Location = new System.Drawing.Point(3, 38);
            this.numericUpDownDelete.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDelete.Name = "numericUpDownDelete";
            this.numericUpDownDelete.Size = new System.Drawing.Size(93, 22);
            this.numericUpDownDelete.TabIndex = 12;
            this.numericUpDownDelete.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.91453F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.08547F));
            this.tableLayoutPanel1.Controls.Add(this.listboxMemberDetails, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.21157F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.78843F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1102, 553);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.89104F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.85472F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.01211F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonSearchMember, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonNewMember, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(663, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(436, 55);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtMember, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(277, 49);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.labelHeaderPurchaseDetails, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.listboxPurchaseDetails, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 64);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.360825F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.1134F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.73196F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(654, 486);
            this.tableLayoutPanel4.TabIndex = 11;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.17375F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.82625F));
            this.tableLayoutPanel5.Controls.Add(this.labelTotalPrice, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 401);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(648, 82);
            this.tableLayoutPanel5.TabIndex = 12;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 4;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.Controls.Add(this.buttonPay, 3, 1);
            this.tableLayoutPanel6.Controls.Add(this.buttonClear, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 1, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.66666F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(422, 76);
            this.tableLayoutPanel6.TabIndex = 10;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Controls.Add(this.buttonDelete, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.numericUpDownDelete, 0, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(108, 13);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.25926F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.74074F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(99, 60);
            this.tableLayoutPanel7.TabIndex = 2;
            // 
            // FormCashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 553);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "FormCashier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cashier";
            this.Shown += new System.EventHandler(this.FormCashier_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelete)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listboxPurchaseDetails;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.ListBox listboxMemberDetails;
        private System.Windows.Forms.Button buttonSearchMember;
        private System.Windows.Forms.TextBox txtMember;
        private System.Windows.Forms.Button buttonNewMember;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonPay;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelTotalPrice;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label labelHeaderPurchaseDetails;
        private System.Windows.Forms.NumericUpDown numericUpDownDelete;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
    }
}