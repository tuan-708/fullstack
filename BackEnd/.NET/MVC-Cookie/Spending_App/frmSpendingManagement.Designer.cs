namespace Spending_App
{
    partial class frmSpendingManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSpendingManagement));
            pn_1 = new Panel();
            pictureBox2 = new PictureBox();
            txt_remaining = new TextBox();
            txt_spend = new TextBox();
            txt_revenue = new TextBox();
            lb_remaining = new Label();
            lb_total_spend = new Label();
            lb_total_revenue = new Label();
            pn_2 = new Panel();
            btn_add_transaction = new Button();
            btn_last_week = new Button();
            btn_this_week = new Button();
            label2 = new Label();
            label1 = new Label();
            dgv_3 = new DataGridView();
            dgv_2 = new DataGridView();
            btn_last_month = new Button();
            btn_this_month = new Button();
            btn_yesterday = new Button();
            dt_to = new DateTimePicker();
            btn_today = new Button();
            dt_from = new DateTimePicker();
            lb_to = new Label();
            lb_from = new Label();
            pn_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            pn_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_2).BeginInit();
            SuspendLayout();
            // 
            // pn_1
            // 
            pn_1.BorderStyle = BorderStyle.FixedSingle;
            pn_1.Controls.Add(pictureBox2);
            pn_1.Controls.Add(txt_remaining);
            pn_1.Controls.Add(txt_spend);
            pn_1.Controls.Add(txt_revenue);
            pn_1.Controls.Add(lb_remaining);
            pn_1.Controls.Add(lb_total_spend);
            pn_1.Controls.Add(lb_total_revenue);
            pn_1.Location = new Point(21, 22);
            pn_1.Name = "pn_1";
            pn_1.Size = new Size(366, 582);
            pn_1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(22, 198);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(322, 368);
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // txt_remaining
            // 
            txt_remaining.Location = new Point(160, 105);
            txt_remaining.Name = "txt_remaining";
            txt_remaining.ReadOnly = true;
            txt_remaining.Size = new Size(184, 23);
            txt_remaining.TabIndex = 5;
            txt_remaining.TextAlign = HorizontalAlignment.Right;
            // 
            // txt_spend
            // 
            txt_spend.Location = new Point(160, 66);
            txt_spend.Name = "txt_spend";
            txt_spend.ReadOnly = true;
            txt_spend.Size = new Size(184, 23);
            txt_spend.TabIndex = 4;
            txt_spend.TextAlign = HorizontalAlignment.Right;
            // 
            // txt_revenue
            // 
            txt_revenue.Location = new Point(160, 24);
            txt_revenue.Name = "txt_revenue";
            txt_revenue.ReadOnly = true;
            txt_revenue.Size = new Size(184, 23);
            txt_revenue.TabIndex = 3;
            txt_revenue.TextAlign = HorizontalAlignment.Right;
            // 
            // lb_remaining
            // 
            lb_remaining.AutoSize = true;
            lb_remaining.Location = new Point(22, 113);
            lb_remaining.Name = "lb_remaining";
            lb_remaining.Size = new Size(92, 15);
            lb_remaining.TabIndex = 2;
            lb_remaining.Text = "Total remaining:";
            // 
            // lb_total_spend
            // 
            lb_total_spend.AutoSize = true;
            lb_total_spend.Location = new Point(22, 75);
            lb_total_spend.Name = "lb_total_spend";
            lb_total_spend.Size = new Size(70, 15);
            lb_total_spend.TabIndex = 1;
            lb_total_spend.Text = "Total spend:";
            // 
            // lb_total_revenue
            // 
            lb_total_revenue.AutoSize = true;
            lb_total_revenue.Location = new Point(22, 29);
            lb_total_revenue.Name = "lb_total_revenue";
            lb_total_revenue.Size = new Size(80, 15);
            lb_total_revenue.TabIndex = 0;
            lb_total_revenue.Text = "Total revenue:";
            // 
            // pn_2
            // 
            pn_2.BorderStyle = BorderStyle.FixedSingle;
            pn_2.Controls.Add(btn_add_transaction);
            pn_2.Controls.Add(btn_last_week);
            pn_2.Controls.Add(btn_this_week);
            pn_2.Controls.Add(label2);
            pn_2.Controls.Add(label1);
            pn_2.Controls.Add(dgv_3);
            pn_2.Controls.Add(dgv_2);
            pn_2.Controls.Add(btn_last_month);
            pn_2.Controls.Add(btn_this_month);
            pn_2.Controls.Add(btn_yesterday);
            pn_2.Controls.Add(dt_to);
            pn_2.Controls.Add(btn_today);
            pn_2.Controls.Add(dt_from);
            pn_2.Controls.Add(lb_to);
            pn_2.Controls.Add(lb_from);
            pn_2.Location = new Point(430, 22);
            pn_2.Name = "pn_2";
            pn_2.Size = new Size(959, 582);
            pn_2.TabIndex = 1;
            // 
            // btn_add_transaction
            // 
            btn_add_transaction.BackColor = Color.DarkOrange;
            btn_add_transaction.Location = new Point(470, 18);
            btn_add_transaction.Name = "btn_add_transaction";
            btn_add_transaction.Size = new Size(83, 69);
            btn_add_transaction.TabIndex = 19;
            btn_add_transaction.Text = "Add transaction";
            btn_add_transaction.UseVisualStyleBackColor = false;
            btn_add_transaction.Click += btn_add_transaction_Click_1;
            // 
            // btn_last_week
            // 
            btn_last_week.BackColor = Color.MediumOrchid;
            btn_last_week.Location = new Point(277, 56);
            btn_last_week.Name = "btn_last_week";
            btn_last_week.Size = new Size(79, 33);
            btn_last_week.TabIndex = 18;
            btn_last_week.Text = "Last week";
            btn_last_week.UseVisualStyleBackColor = false;
            btn_last_week.Click += btn_last_week_Click;
            // 
            // btn_this_week
            // 
            btn_this_week.BackColor = Color.MediumOrchid;
            btn_this_week.Location = new Point(277, 18);
            btn_this_week.Name = "btn_this_week";
            btn_this_week.Size = new Size(79, 33);
            btn_this_week.TabIndex = 17;
            btn_this_week.Text = "This week";
            btn_this_week.UseVisualStyleBackColor = false;
            btn_this_week.Click += btn_this_week_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(601, 122);
            label2.Name = "label2";
            label2.Size = new Size(190, 30);
            label2.TabIndex = 16;
            label2.Text = "Transaction spend";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(136, 122);
            label1.Name = "label1";
            label1.Size = new Size(209, 30);
            label1.TabIndex = 7;
            label1.Text = "Transaction revenue";
            // 
            // dgv_3
            // 
            dgv_3.BackgroundColor = SystemColors.ButtonHighlight;
            dgv_3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_3.Location = new Point(488, 169);
            dgv_3.Name = "dgv_3";
            dgv_3.RowTemplate.Height = 25;
            dgv_3.Size = new Size(444, 397);
            dgv_3.TabIndex = 15;
            dgv_3.CellDoubleClick += dgv_3_CellDoubleClick;
            // 
            // dgv_2
            // 
            dgv_2.BackgroundColor = SystemColors.ButtonHighlight;
            dgv_2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv_2.Location = new Point(22, 169);
            dgv_2.Name = "dgv_2";
            dgv_2.RowTemplate.Height = 25;
            dgv_2.Size = new Size(450, 397);
            dgv_2.TabIndex = 14;
            dgv_2.CellDoubleClick += dgv_2_CellDoubleClick;
            // 
            // btn_last_month
            // 
            btn_last_month.BackColor = Color.RoyalBlue;
            btn_last_month.Location = new Point(362, 56);
            btn_last_month.Name = "btn_last_month";
            btn_last_month.Size = new Size(79, 33);
            btn_last_month.TabIndex = 11;
            btn_last_month.Text = "Last month";
            btn_last_month.UseVisualStyleBackColor = false;
            btn_last_month.Click += btn_last_month_Click;
            // 
            // btn_this_month
            // 
            btn_this_month.BackColor = Color.RoyalBlue;
            btn_this_month.Location = new Point(362, 18);
            btn_this_month.Name = "btn_this_month";
            btn_this_month.Size = new Size(79, 33);
            btn_this_month.TabIndex = 10;
            btn_this_month.Text = "This month";
            btn_this_month.UseVisualStyleBackColor = false;
            btn_this_month.Click += btn_this_month_Click;
            // 
            // btn_yesterday
            // 
            btn_yesterday.BackColor = Color.IndianRed;
            btn_yesterday.Location = new Point(192, 56);
            btn_yesterday.Name = "btn_yesterday";
            btn_yesterday.Size = new Size(79, 33);
            btn_yesterday.TabIndex = 7;
            btn_yesterday.Text = "Yesterday";
            btn_yesterday.UseVisualStyleBackColor = false;
            btn_yesterday.Click += btn_yesterday_Click;
            // 
            // dt_to
            // 
            dt_to.CustomFormat = "dd/MM/yyyy";
            dt_to.Format = DateTimePickerFormat.Custom;
            dt_to.Location = new Point(66, 63);
            dt_to.Name = "dt_to";
            dt_to.Size = new Size(102, 23);
            dt_to.TabIndex = 6;
            dt_to.ValueChanged += dt_to_ValueChanged;
            // 
            // btn_today
            // 
            btn_today.BackColor = Color.IndianRed;
            btn_today.Location = new Point(192, 18);
            btn_today.Name = "btn_today";
            btn_today.Size = new Size(79, 33);
            btn_today.TabIndex = 4;
            btn_today.Text = "Today";
            btn_today.UseVisualStyleBackColor = false;
            btn_today.Click += btn_today_Click;
            // 
            // dt_from
            // 
            dt_from.CustomFormat = "dd/MM/yyyy";
            dt_from.Format = DateTimePickerFormat.Custom;
            dt_from.Location = new Point(66, 23);
            dt_from.Name = "dt_from";
            dt_from.Size = new Size(102, 23);
            dt_from.TabIndex = 2;
            dt_from.ValueChanged += dt_from_ValueChanged;
            // 
            // lb_to
            // 
            lb_to.AutoSize = true;
            lb_to.Location = new Point(22, 69);
            lb_to.Name = "lb_to";
            lb_to.Size = new Size(19, 15);
            lb_to.TabIndex = 1;
            lb_to.Text = "To";
            // 
            // lb_from
            // 
            lb_from.AutoSize = true;
            lb_from.Location = new Point(22, 27);
            lb_from.Name = "lb_from";
            lb_from.Size = new Size(38, 15);
            lb_from.TabIndex = 0;
            lb_from.Text = "From:";
            // 
            // frmSpendingManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1415, 616);
            Controls.Add(pn_2);
            Controls.Add(pn_1);
            Name = "frmSpendingManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Spending Manament";
            Load += frmSpendingManagement_Load;
            pn_1.ResumeLayout(false);
            pn_1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            pn_2.ResumeLayout(false);
            pn_2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGridView1;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private DataGridView dataGridView2;
        private Button button8;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private DateTimePicker dateTimePicker2;
        private Button button1;
        private DateTimePicker dateTimePicker1;
        private Label label5;
        private Label label4;
        private Panel pn_1;
        private DataGridViewTextBoxColumn dgv_column1;
        private DataGridViewTextBoxColumn dgv1_column2;
        private DataGridViewTextBoxColumn dgv2_column3;
        private TextBox txt_remaining;
        private TextBox txt_spend;
        private TextBox txt_revenue;
        private Label lb_remaining;
        private Label lb_total_spend;
        private Label lb_total_revenue;
        private Panel pn_2;
        private DataGridView dgv_2;
        private Button btn_last_month;
        private Button btn_this_month;
        private Button btn_yesterday;
        private DateTimePicker dt_to;
        private Button btn_today;
        private DateTimePicker dt_from;
        private Label lb_to;
        private Label lb_from;
        private DataGridView dgv_3;
        private Button button10;
        private Button btn_this_week;
        private Button btn_last_week;
        private Button btn_add_transaction;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}