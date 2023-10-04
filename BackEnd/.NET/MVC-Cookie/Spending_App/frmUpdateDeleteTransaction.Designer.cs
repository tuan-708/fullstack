namespace Spending_App
{
    partial class frmUpdateDeleteTransaction
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
            label1 = new Label();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            lb_id_transaction = new Label();
            label2 = new Label();
            lb_type_category = new Label();
            label3 = new Label();
            cb_category = new ComboBox();
            label4 = new Label();
            dt_date = new DateTimePicker();
            label5 = new Label();
            txt_amount = new TextBox();
            label6 = new Label();
            txt_description = new TextBox();
            btn_update = new Button();
            btn_delete = new Button();
            btn_cancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 29);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 0;
            label1.Text = "Id transaction:";
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // lb_id_transaction
            // 
            lb_id_transaction.AutoSize = true;
            lb_id_transaction.Location = new Point(142, 29);
            lb_id_transaction.Name = "lb_id_transaction";
            lb_id_transaction.Size = new Size(17, 15);
            lb_id_transaction.TabIndex = 1;
            lb_id_transaction.Text = "id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 77);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 2;
            label2.Text = "Type category:";
            // 
            // lb_type_category
            // 
            lb_type_category.AutoSize = true;
            lb_type_category.Location = new Point(142, 77);
            lb_type_category.Name = "lb_type_category";
            lb_type_category.Size = new Size(30, 15);
            lb_type_category.TabIndex = 3;
            lb_type_category.Text = "type";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 124);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 4;
            label3.Text = "Category:";
            // 
            // cb_category
            // 
            cb_category.FormattingEnabled = true;
            cb_category.Location = new Point(142, 116);
            cb_category.Name = "cb_category";
            cb_category.Size = new Size(121, 23);
            cb_category.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 172);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 6;
            label4.Text = "Date:";
            // 
            // dt_date
            // 
            dt_date.CustomFormat = "dd/MM/yyyy";
            dt_date.Format = DateTimePickerFormat.Custom;
            dt_date.Location = new Point(142, 166);
            dt_date.Name = "dt_date";
            dt_date.Size = new Size(121, 23);
            dt_date.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(33, 218);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 8;
            label5.Text = "Amount:";
            // 
            // txt_amount
            // 
            txt_amount.Location = new Point(141, 216);
            txt_amount.Name = "txt_amount";
            txt_amount.Size = new Size(122, 23);
            txt_amount.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(33, 268);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 10;
            label6.Text = "Description:";
            // 
            // txt_description
            // 
            txt_description.Location = new Point(141, 260);
            txt_description.Name = "txt_description";
            txt_description.Size = new Size(119, 23);
            txt_description.TabIndex = 11;
            // 
            // btn_update
            // 
            btn_update.Location = new Point(37, 342);
            btn_update.Name = "btn_update";
            btn_update.Size = new Size(75, 23);
            btn_update.TabIndex = 12;
            btn_update.Text = "Update";
            btn_update.UseVisualStyleBackColor = true;
            btn_update.Click += btn_update_Click;
            // 
            // btn_delete
            // 
            btn_delete.Location = new Point(142, 342);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(75, 23);
            btn_delete.TabIndex = 13;
            btn_delete.Text = "Delete";
            btn_delete.UseVisualStyleBackColor = true;
            btn_delete.Click += btn_delete_Click;
            // 
            // btn_cancel
            // 
            btn_cancel.Location = new Point(244, 342);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(75, 23);
            btn_cancel.TabIndex = 14;
            btn_cancel.Text = "Cancel";
            btn_cancel.UseVisualStyleBackColor = true;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // frmUpdateDeleteTransaction
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(355, 450);
            Controls.Add(btn_cancel);
            Controls.Add(btn_delete);
            Controls.Add(btn_update);
            Controls.Add(txt_description);
            Controls.Add(label6);
            Controls.Add(txt_amount);
            Controls.Add(label5);
            Controls.Add(dt_date);
            Controls.Add(label4);
            Controls.Add(cb_category);
            Controls.Add(label3);
            Controls.Add(lb_type_category);
            Controls.Add(label2);
            Controls.Add(lb_id_transaction);
            Controls.Add(label1);
            Name = "frmUpdateDeleteTransaction";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Delete/Update Transaction";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Label lb_id_transaction;
        private Label label2;
        private Label lb_type_category;
        private Label label3;
        private ComboBox cb_category;
        private Label label4;
        private DateTimePicker dt_date;
        private Label label5;
        private TextBox txt_amount;
        private Label label6;
        private TextBox txt_description;
        private Button btn_update;
        private Button btn_delete;
        private Button btn_cancel;
    }
}