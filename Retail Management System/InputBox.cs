using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Retail_Management_System
{
    public class InputBox
    {
        public static DialogResult Show(String title, String promptText, ref String value)
        {
            return Show(title, promptText, ref value, null);
        }

        public static DialogResult Show(String title, String promptText, ref String value, InputBoxValidation validation)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;
            if (validation != null)
            {
                form.FormClosing += delegate (object sender, FormClosingEventArgs e)
                {
                    if (form.DialogResult == DialogResult.OK)
                    {
                        String errorText = validation(textBox.Text);
                        if (e.Cancel = (errorText != ""))
                        {
                            MessageBox.Show(form, errorText, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox.Clear();
                            textBox.Focus();
                        }
                    }
                };
            }
            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }


        public static DialogResult Show(String title, String[] promptText, ref String[] value, InputBoxValidation[] validation, String successMessage, int count)
        {
            Form form = new Form();
            List<Label> labels = new List<Label>();
            List<TextBox> textBoxs = new List<TextBox>();
            List<String> textInTxtBox = new List<String>();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            for (int i = 0; i < count; i++)
            {
                labels.Add(Initialize(new Label(), promptText[i], i + 1));
                textBoxs.Add(Initialize(new TextBox(), value[i], i + 1));
                textInTxtBox.Add(value[i]);
            }

            form.Text = title;
            form.ClientSize = new Size(396, count * 107 - ((count - 1) * 50));

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            buttonOk.SetBounds(228, form.ClientSize.Height - 35, 75, 23);
            buttonCancel.SetBounds(309, form.ClientSize.Height - 35, 75, 23);

            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            Control[] control = new Control[count * 2 + 2];
            for (int i = 0, j = 0; i < count * 2; j++)  
            {
                control[i++] = labels[j];
                control[i++] = textBoxs[j];
            }
            control[count * 2 + 0] = buttonOk;
            control[count * 2 + 1] = buttonCancel;

            form.Controls.AddRange(control);

            for (int width = 300, i = 0; i < count; i++)
            {
                form.ClientSize = new Size(Math.Max(width, labels[i].Right + 10), form.ClientSize.Height);
                width = form.ClientSize.Width;
            }

            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;
            if (validation != null)
            {
                form.FormClosing += delegate (object sender, FormClosingEventArgs e)
                {
                    if (form.DialogResult == DialogResult.OK)
                    {
                        for (int i = 0; i < count; i++) 
                        {
                            String errorText = validation[i](textBoxs[i].Text);
                            if (e.Cancel = (errorText != ""))
                            {
                                MessageBox.Show(form, errorText, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBoxs[i].Text = textInTxtBox[i];
                                textBoxs[i].SelectAll();
                                textBoxs[i].Focus();
                                break;
                            }
                            else if (i == count - 1 && errorText == "")
                                MessageBox.Show(successMessage);
                            else
                                textInTxtBox[i] = textBoxs[i].Text;
                        }
                    }
                };
            }
            DialogResult dialogResult = form.ShowDialog();
            for (int i = 0; i < count; i++)
                value[i] = textBoxs[i].Text;
            return dialogResult;
        }

        private static Label Initialize(Label label, String promptText, int num)
        {
            label.Text = promptText;
            label.SetBounds(9, 20 * num + ((num - 1) * 30), 372, 13);
            label.AutoSize = true;

            return label;
        }

        private static TextBox Initialize(TextBox textBox, String value, int num)
        {
            textBox.Text = value;
            textBox.SetBounds(12, 20 * num + ((num - 1) * 30) + 16, 372, 20);
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;

            return textBox;
        }

        public delegate String InputBoxValidation(String errorMessage);

        public static DialogResult Password(String title, String promptText, InputBoxValidation validation)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonEnter = new Button();

            form.Text = title;
            label.Text = promptText;

            buttonEnter.Text = "Enter";
            buttonEnter.DialogResult = DialogResult.OK;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonEnter.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonEnter.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            textBox.UseSystemPasswordChar = true;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonEnter });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonEnter;
            if (validation != null)
            {
                form.FormClosing += delegate (object sender, FormClosingEventArgs e)
                {
                    if (form.DialogResult == DialogResult.OK)
                    {
                        String errorText = validation(textBox.Text);
                        if (e.Cancel = (errorText != ""))
                        {
                            MessageBox.Show(form, errorText, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox.Clear();
                            textBox.Focus();
                        }
                    }
                };
            }
            DialogResult dialogResult = form.ShowDialog();
            return dialogResult;
        }
    }
}