using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using static Retail_Management_System.Connection;

namespace Retail_Management_System
{
    public partial class FormCashier : Form
    {
        //String format
        private static int[] length = { 6, 19, 15, 8, 14 };
        private String PurchaseDetails = "{0,-" + length[0] + "}{1,-" + length[1] + "}{2," + length[2] + "}{3," + length[3] + "}{4," + length[4] + "}";
        private List<int> startIndex = new List<int>();
        //

        private List<List<Item>> Item = new List<List<Item>>();

        private List<List<int>> ItemIndex = new List<List<int>>();

        private double TotalPrice;

        private String CashierID;

        private List<List<String>> receipts = new List<List<string>>();

        public FormCashier()
        {
            InitializeComponent();
            String format = "{0,-10}{1,-46}{2,-14}{3,-5}{4,15}";
            labelHeaderPurchaseDetails.Text = String.Format(format, "ID", "Name", "Price", "Qty", "Total(RM)");

            int tempIndex = 0;
            for (int i = 0; i < length.Length; i++) 
            {
                startIndex.Add(tempIndex);
                tempIndex += length[i];
            }
        }

        private void FormCashier_Shown(object sender, EventArgs e)
        {
            using (FormCashierLogin CashierLogin = new FormCashierLogin())
            {
                CashierLogin.FormClosed += new FormClosedEventHandler(CashierLogin_FormClosed);
                CashierLogin.ShowDialog();
                this.CashierID = CashierLogin.CashierID;
            }

            TotalPrice = 0;
            DataTable ItemType = SelectAllItemTypeInStock();

            for (int i = 0; i < ItemType.Rows.Count; i++)
            {
                DataTable CurrentItemsID = SelectItemIDByType(ItemType.Rows[i][0].ToString());
                int NumberOfCurrentItems = CurrentItemsID.Rows.Count;

                TabPage tempTP = InitializeTabPage(new TabPage(), ItemType.Rows[i][0].ToString());
                TableLayoutPanel tempTLP = InitializeTableLayoutPanel(new TableLayoutPanel(), tempTP, NumberOfCurrentItems);

                Item.Add(new List<Item>());

                for (int j = 0; j < NumberOfCurrentItems; j++)
                {
                    Item[i].Add(new Item(CurrentItemsID.Rows[j][0].ToString(), String.Format("{0,5}{1,5}", i, j)));
                    Item[i][j].button.Click += new System.EventHandler(this.ButtonAdd_Click);

                    tempTLP.Controls.Add(Item[i][j].lblName, 0, j);
                    tempTLP.Controls.Add(Item[i][j].lblQty, 1, j);
                    tempTLP.Controls.Add(Item[i][j].numeric, 2, j);
                    tempTLP.Controls.Add(Item[i][j].button, 3, j);
                }
            }
        }

        private void CashierLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void ButtonSearchMember_Click(object sender, EventArgs e)
        {
            if (CountSearchMember(txtMember.Text) == "0")
            {
                MessageBox.Show("Member not found! ");
                txtMember.Focus();
            }
            else
            {
                using (FormSearchResult SearchResult = new FormSearchResult(SelectSearchMember(txtMember.Text)))
                {
                    SearchResult.ShowDialog(this);
                    if (SearchResult.DialogResult == DialogResult.OK)
                    {
                        txtMember.Clear();
                        listboxMemberDetails.Items.Clear();
                        listboxMemberDetails.Items.Add(SearchResult.SelectedResult);
                    }
                }
            }
        }

        private void ButtonNewMember_Click(object sender, EventArgs e)
        {
            using (FormMemberRegister MemberRegister = new FormMemberRegister())
                MemberRegister.ShowDialog(this);
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            listboxMemberDetails.Items.Clear();
            listboxPurchaseDetails.Items.Clear();
            txtMember.Clear();
            TotalPrice = 0;
            labelTotalPrice.Text = "RM 0.00";

            for (int i = 0; i < Item.Count; i++)
            {
                tabControl1.TabPages[i].Controls.Clear();
                TableLayoutPanel tempTLP = InitializeTableLayoutPanel(new TableLayoutPanel(), tabControl1.TabPages[i], Item[i].Count);

                for (int j = 0; j < Item[i].Count; j++)
                {
                    Item[i][j].Reset();
                    tempTLP.Controls.Add(Item[i][j].lblName, 0, j);
                    tempTLP.Controls.Add(Item[i][j].lblQty, 1, j);
                    tempTLP.Controls.Add(Item[i][j].numeric, 2, j);
                    tempTLP.Controls.Add(Item[i][j].button, 3, j);
                }
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (listboxPurchaseDetails.SelectedIndex != -1)
            {
                int QtyDelete = Decimal.ToInt32(numericUpDownDelete.Value);
                int QtySelected = int.Parse(listboxPurchaseDetails.SelectedItem.ToString().Substring(startIndex[3], length[3]));

                foreach (List<Item> itemList in Item)
                    foreach (Item item in itemList)
                        if (listboxPurchaseDetails.SelectedItem.ToString().Contains(item.ID))
                        {
                            numericUpDownDelete.Value = 1;

                            item.lblQty.Text = (int.Parse(item.lblQty.Text) + QtyDelete).ToString();
                            item.button.Enabled = true;
                            item.numeric.Maximum = int.Parse(item.lblQty.Text);
                            item.numeric.Minimum = 1;
                            item.numeric.Value = 1;

                            if (QtySelected == QtyDelete)
                            {
                                ItemIndex.RemoveAt(listboxPurchaseDetails.SelectedIndex);
                                listboxPurchaseDetails.Items.Remove(listboxPurchaseDetails.SelectedItem);
                            }
                            else
                            {
                                int Index = listboxPurchaseDetails.SelectedIndex;
                                int Qty = item.Quantity - int.Parse(item.lblQty.Text);
                                listboxPurchaseDetails.Items.RemoveAt(Index);
                                listboxPurchaseDetails.Items.Insert(Index, String.Format(PurchaseDetails, item.ID, item.Name, item.Price.ToString("0.00"), Qty, (Qty * item.Price).ToString("0.00")));
                            }

                            TotalPrice = Math.Round(TotalPrice - QtyDelete * item.Price, 2, MidpointRounding.AwayFromZero);
                            labelTotalPrice.Text = "RM " + TotalPrice.ToString("0.00");

                            goto OUTSIDE;
                        }
                    OUTSIDE:;
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Button ClickedButton = sender as Button;

            int i = int.Parse(ClickedButton.Name.Substring(0, 5));
            int j = int.Parse(ClickedButton.Name.Substring(5, 5));

            String ID = Item[i][j].ID;
            String Name = Item[i][j].Name;
            Double Price = Item[i][j].Price;
            int Quantity = Item[i][j].Quantity;
            int QtyPurchase = Decimal.ToInt32(Item[i][j].numeric.Value);
            int QtyCurrent = int.Parse(Item[i][j].lblQty.Text);

            int Index = -1;
            for (int a = 0; a < listboxPurchaseDetails.Items.Count; a++)
                if (listboxPurchaseDetails.Items[a].ToString().Contains(ID))
                {
                    Index = a;
                    break;
                }

            if (listboxPurchaseDetails.Items.Count == 0 || Index == -1)
            {
                ItemIndex.Add(new List<int>() { i, j });
                listboxPurchaseDetails.Items.Add(String.Format(PurchaseDetails, ID, Name, Price.ToString("0.00"), QtyPurchase, (QtyPurchase * Price).ToString("0.00")));
            }
            else
            {
                int TotalQty = QtyPurchase + (Quantity - QtyCurrent);
                listboxPurchaseDetails.Items.RemoveAt(Index);
                listboxPurchaseDetails.Items.Insert(Index, String.Format(PurchaseDetails, ID, Name, Price.ToString("0.00"), TotalQty, (TotalQty * Price).ToString("0.00")));
            }
            TotalPrice = Math.Round(TotalPrice + QtyPurchase * Price, 2, MidpointRounding.AwayFromZero);
            labelTotalPrice.Text = "RM " + TotalPrice.ToString("0.00");

            Item[i][j].numeric.Value = 1;
            Item[i][j].lblQty.Text = (QtyCurrent - QtyPurchase).ToString();
            Item[i][j].numeric.Maximum = int.Parse(Item[i][j].lblQty.Text);

            if (Item[i][j].lblQty.Text == "0")
            {
                Item[i][j].button.Enabled = false;
                Item[i][j].numeric.Minimum = 0;
            }
        }

        private void ButtonPay_Click(object sender, EventArgs e)
        {
            if (listboxPurchaseDetails.Items.Count != 0) 
            {
                String SaleID = CashierID + (int.Parse(CountSale()) + 1).ToString(new String('0',5));

                if (listboxMemberDetails.Items.Count == 0)
                    InsertSale(SaleID, CashierID);
                else
                {
                    String MemberID = listboxMemberDetails.Items[0].ToString().Substring(0, 15).Trim();
                    int MemberPoint = int.Parse(GetMemberPoint(MemberID));
                    int EarnedPoint = int.Parse((TotalPrice * 10).ToString());

                    InsertSale(SaleID, EarnedPoint, MemberID, CashierID);
                    UpdateMemberPoint(MemberID, MemberPoint + EarnedPoint);
                }

                for (int i = 0; i < listboxPurchaseDetails.Items.Count; i++)
                {
                    int type = ItemIndex[i][0];
                    int item = ItemIndex[i][1];
                    int SoldQty = Item[type][item].Quantity - int.Parse(Item[type][item].lblQty.Text);
                    double SoldProfit = SoldQty * (Item[type][item].Price - Item[type][item].Cost);

                    InsertItemsSold(SaleID, Item[type][item].ID, SoldQty, SoldProfit);
                    UpdateStockQuantity(Item[type][item].ID, int.Parse(Item[type][item].lblQty.Text));
                    Item[type][item].DeduteQuantity();
                }
                Receipt();
                MessageBox.Show("Payment Successful! \nReceipt had been printed");

                listboxPurchaseDetails.Items.Clear();
                listboxMemberDetails.Items.Clear();
                ItemIndex.Clear();
                TotalPrice = 0;
                labelTotalPrice.Text = "RM 0.00";
            }
        }

        private TableLayoutPanel InitializeTableLayoutPanel(TableLayoutPanel tableLayoutPanel, TabPage tabPage, int ItemQty)
        {
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.AutoScroll = true;
            tableLayoutPanel.ColumnCount = 4;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel.Name = tabPage.Text;
            tableLayoutPanel.RowCount = ItemQty + 1;

            for (int i = 0; i < ItemQty + 1; i++)
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));

            tabPage.Controls.Add(tableLayoutPanel);

            return tableLayoutPanel;
        }

        private TabPage InitializeTabPage(TabPage tabPage, String text)
        {
            tabPage.Name = text;
            tabPage.Padding = new Padding(3);
            tabPage.Text = text;
            tabPage.UseVisualStyleBackColor = true;

            this.tabControl1.Controls.Add(tabPage);

            return tabPage;
        }

        private void ListboxPurchaseDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listboxPurchaseDetails.SelectedIndex != -1)
                numericUpDownDelete.Maximum = int.Parse(listboxPurchaseDetails.SelectedItem.ToString().Substring(startIndex[3], length[3]));
        }

        private void Receipt()
        {
            Document dcm = new Document();
            PdfWriter.GetInstance(dcm, new FileStream("C:/Users/USER/Downloads/workshop folder/MyWorkshop/Receipt.pdf", FileMode.Create));
            dcm.Open();
            String format = "{0,-10}{1,-25}{2,-10}{3,-5}{4,10}";
            Paragraph header = new Paragraph(String.Format(format, "ID", "Name", "Price", "Qty", "Total(RM)"));
            String space = "                                                ";
            dcm.Add(new Paragraph("#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*"));
            dcm.Add(new Paragraph("                             "+Store.Name+"                            "));
            dcm.Add(new Paragraph("#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#"));

            dcm.Add(header);
            dcm.Add(new Paragraph("___________________________________________"));
            for (int i = 0; i < listboxPurchaseDetails.Items.Count; i++)
            {
                Paragraph p = new Paragraph(listboxPurchaseDetails.Items[i].ToString());
                dcm.Add(p);
            }
            dcm.Add(new Paragraph("___________________________________________"));
            Paragraph last = new Paragraph("Total Price:"+space+"RM " + TotalPrice.ToString("0.00"));
            dcm.Add(last);
            dcm.Close();
        }
    }
}