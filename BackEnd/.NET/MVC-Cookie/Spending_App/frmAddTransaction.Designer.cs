namespace Spending_App
{
    partial class frmAddTransaction
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
            lb_type_category = new Label();
            lb_date = new Label();
            lb_amount = new Label();
            cb_type_category = new ComboBox();
            lb_description = new Label();
            btn_save = new Button();
            dt_date = new DateTimePicker();
            txt_amount = new TextBox();
            txt_description = new TextBox();
            cb_category = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // lb_type_category
            // 
            lb_type_category.AutoSize = true;
            lb_type_category.Location = new Point(28, 20);
            lb_type_category.Name = "lb_type_category";
            lb_type_category.Size = new Size(85, 15);
            lb_type_category.TabIndex = 0;
            lb_type_category.Text = "Type Category:";
            // 
            // lb_date
            // 
            lb_date.AutoSize = true;
            lb_date.Location = new Point(28, 113);
            lb_date.Name = "lb_date";
            lb_date.Size = new Size(34, 15);
            lb_date.TabIndex = 1;
            lb_date.Text = "Date:";
            // 
            // lb_amount
            // 
            lb_amount.AutoSize = true;
            lb_amount.Location = new Point(28, 161);
            lb_amount.Name = "lb_amount";
            lb_amount.Size = new Size(54, 15);
            lb_amount.TabIndex = 2;
            lb_amount.Text = "Amount:";
            // 
            // cb_type_category
            // 
            cb_type_category.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_type_category.FormattingEnabled = true;
            cb_type_category.Items.AddRange(new object[] { "Category Revenue", "Category Spend" });
            cb_type_category.Location = new Point(146, 12);
            cb_type_category.Name = "cb_type_category";
            cb_type_category.Size = new Size(121, 23);
            cb_type_category.Sorted = true;
            cb_type_category.TabIndex = 3;
            cb_type_category.SelectedIndexChanged += cb_type_category_SelectedIndexChanged_1;
            // 
            // lb_description
            // 
            lb_description.AutoSize = true;
            lb_description.Location = new Point(28, 201);
            lb_description.Name = "lb_description";
            lb_description.Size = new Size(70, 15);
            lb_description.TabIndex = 4;
            lb_description.Text = "Description:";
            // 
            // btn_save
            // 
            btn_save.Location = new Point(146, 257);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(75, 23);
            btn_save.TabIndex = 5;
            btn_save.Text = "Save";
            btn_save.UseVisualStyleBackColor = true;
            btn_save.Click += btn_save_Click;
            // 
            // dt_date
            // 
            dt_date.CustomFormat = "dd/MM/yyy";
            dt_date.Format = DateTimePickerFormat.Custom;
            dt_date.Location = new Point(146, 107);
            dt_date.Name = "dt_date";
            dt_date.Size = new Size(121, 23);
            dt_date.TabIndex = 6;
            // 
            // txt_amount
            // 
            txt_amount.Location = new Point(146, 153);
            txt_amount.Name = "txt_amount";
            txt_amount.Size = new Size(121, 23);
            txt_amount.TabIndex = 7;
            // 
            // txt_description
            // 
            txt_description.Location = new Point(146, 198);
            txt_description.Name = "txt_description";
            txt_description.Size = new Size(121, 23);
            txt_description.TabIndex = 8;
            // 
            // cb_category
            // 
            cb_category.FormattingEnabled = true;
            cb_category.Location = new Point(146, 59);
            cb_category.Name = "cb_category";
            cb_category.Size = new Size(121, 23);
            cb_category.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 67);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 10;
            label1.Text = "Category:";
            // 
            // frmAddTransaction
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(324, 371);
            Controls.Add(label1);
            Controls.Add(cb_category);
            Controls.Add(txt_description);
            Controls.Add(txt_amount);
            Controls.Add(dt_date);
            Controls.Add(btn_save);
            Controls.Add(lb_description);
            Controls.Add(cb_type_category);
            Controls.Add(lb_amount);
            Controls.Add(lb_date);
            Controls.Add(lb_type_category);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "frmAddTransaction";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add transaction";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lb_type_category;
        private Label lb_date;
        private Label lb_amount;
        private ComboBox cb_type_category;
        private Label lb_description;
        private Button btn_save;
        private DateTimePicker dt_date;
        private TextBox txt_amount;
        private TextBox txt_description;
        private ComboBox cb_category;
        private Label label1;
    }
}