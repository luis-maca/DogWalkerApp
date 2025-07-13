namespace DogWalkerApp.WinForms.Forms
{
    partial class PaymentForm
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
            txtSearch = new TextBox();
            chkSearchAll = new CheckBox();
            btnSearch = new Button();
            dgvPayments = new DataGridView();
            groupBox1 = new GroupBox();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnCreate = new Button();
            numAmount = new NumericUpDown();
            cmbMethod = new ComboBox();
            dtpDate = new DateTimePicker();
            cmbSubscriptions = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAmount).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 33);
            label1.Name = "label1";
            label1.Size = new Size(122, 20);
            label1.TabIndex = 0;
            label1.Text = "Search Payments:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(181, 26);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Enter Client's Name";
            txtSearch.Size = new Size(332, 27);
            txtSearch.TabIndex = 1;
            // 
            // chkSearchAll
            // 
            chkSearchAll.AutoSize = true;
            chkSearchAll.Location = new Point(181, 59);
            chkSearchAll.Name = "chkSearchAll";
            chkSearchAll.Size = new Size(97, 24);
            chkSearchAll.TabIndex = 3;
            chkSearchAll.Text = "Search All";
            chkSearchAll.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(541, 24);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(123, 29);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search Client";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += BtnSearch_Click;
            // 
            // dgvPayments
            // 
            dgvPayments.AllowUserToAddRows = false;
            dgvPayments.AllowUserToDeleteRows = false;
            dgvPayments.AllowUserToOrderColumns = true;
            dgvPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPayments.Location = new Point(42, 133);
            dgvPayments.Name = "dgvPayments";
            dgvPayments.ReadOnly = true;
            dgvPayments.RowHeadersWidth = 51;
            dgvPayments.Size = new Size(730, 241);
            dgvPayments.TabIndex = 5;
            dgvPayments.SelectionChanged += DgvPayments_SelectionChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(btnCreate);
            groupBox1.Controls.Add(numAmount);
            groupBox1.Controls.Add(cmbMethod);
            groupBox1.Controls.Add(dtpDate);
            groupBox1.Controls.Add(cmbSubscriptions);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(42, 413);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(714, 265);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add or Update Payment Method";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(22, 230);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 15;
            btnClear.Text = "Clear Data";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += BtnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(601, 143);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(601, 89);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += BtnUpdate_Click;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(601, 38);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(94, 29);
            btnCreate.TabIndex = 12;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += BtnCreate_Click;
            // 
            // numAmount
            // 
            numAmount.Location = new Point(218, 120);
            numAmount.Name = "numAmount";
            numAmount.Size = new Size(295, 27);
            numAmount.TabIndex = 7;
            numAmount.ValueChanged += NumAmount_ValueChanged;
            // 
            // cmbMethod
            // 
            cmbMethod.FormattingEnabled = true;
            cmbMethod.Location = new Point(218, 163);
            cmbMethod.Name = "cmbMethod";
            cmbMethod.Size = new Size(295, 28);
            cmbMethod.TabIndex = 6;
            cmbMethod.SelectedIndexChanged += CmbMethod_SelectedIndexChanged;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(219, 79);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(295, 27);
            dtpDate.TabIndex = 5;
            // 
            // cmbSubscriptions
            // 
            cmbSubscriptions.FormattingEnabled = true;
            cmbSubscriptions.Location = new Point(219, 38);
            cmbSubscriptions.Name = "cmbSubscriptions";
            cmbSubscriptions.Size = new Size(295, 28);
            cmbSubscriptions.TabIndex = 4;
            cmbSubscriptions.SelectedIndexChanged += CmbSubscriptions_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 127);
            label5.Name = "label5";
            label5.Size = new Size(125, 20);
            label5.TabIndex = 3;
            label5.Text = "Payment Amount:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 171);
            label4.Name = "label4";
            label4.Size = new Size(124, 20);
            label4.TabIndex = 2;
            label4.Text = "Payment Method:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 86);
            label3.Name = "label3";
            label3.Size = new Size(104, 20);
            label3.TabIndex = 1;
            label3.Text = "Payment Date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 46);
            label2.Name = "label2";
            label2.Size = new Size(136, 20);
            label2.TabIndex = 0;
            label2.Text = "Client Subscription:";
            // 
            // PaymentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 723);
            Controls.Add(groupBox1);
            Controls.Add(dgvPayments);
            Controls.Add(btnSearch);
            Controls.Add(chkSearchAll);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Name = "PaymentForm";
            Text = "PaymentForm";
            ((System.ComponentModel.ISupportInitialize)dgvPayments).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSearch;
        private CheckBox chkSearchAll;
        private Button btnSearch;
        private DataGridView dgvPayments;
        private GroupBox groupBox1;
        private Label label2;
        private Label label5;
        private Label label4;
        private Label label3;
        private ComboBox cmbSubscriptions;
        private DateTimePicker dtpDate;
        private ComboBox cmbMethod;
        private NumericUpDown numAmount;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnCreate;
        private Button btnClear;
    }
}