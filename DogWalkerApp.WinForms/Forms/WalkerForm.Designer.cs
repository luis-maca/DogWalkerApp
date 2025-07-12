namespace DogWalkerApp.WinForms.Forms
{
    partial class WalkerForm
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
            btnSearch = new Button();
            chkSearchAll = new CheckBox();
            txtSearch = new TextBox();
            label1 = new Label();
            dgvWalkers = new DataGridView();
            groupBox1 = new GroupBox();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnCreate = new Button();
            btnClear = new Button();
            chkAvailable = new CheckBox();
            txtPhone = new TextBox();
            txtName = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvWalkers).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(539, 28);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(123, 29);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "Search Client";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += BtnSearch_Click;
            // 
            // chkSearchAll
            // 
            chkSearchAll.AutoSize = true;
            chkSearchAll.Location = new Point(179, 63);
            chkSearchAll.Name = "chkSearchAll";
            chkSearchAll.Size = new Size(97, 24);
            chkSearchAll.TabIndex = 7;
            chkSearchAll.Text = "Search All";
            chkSearchAll.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(179, 30);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Enter Walker's Name";
            txtSearch.Size = new Size(332, 27);
            txtSearch.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 37);
            label1.Name = "label1";
            label1.Size = new Size(111, 20);
            label1.TabIndex = 5;
            label1.Text = "Search Walkers:";
            // 
            // dgvWalkers
            // 
            dgvWalkers.AllowUserToAddRows = false;
            dgvWalkers.AllowUserToDeleteRows = false;
            dgvWalkers.AllowUserToOrderColumns = true;
            dgvWalkers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWalkers.Location = new Point(40, 135);
            dgvWalkers.Name = "dgvWalkers";
            dgvWalkers.ReadOnly = true;
            dgvWalkers.RowHeadersWidth = 51;
            dgvWalkers.Size = new Size(748, 214);
            dgvWalkers.TabIndex = 9;
            dgvWalkers.SelectionChanged += DgvWalkers_SelectionChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(btnCreate);
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(chkAvailable);
            groupBox1.Controls.Add(txtPhone);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(40, 397);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(748, 302);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Create or Update Walker";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(627, 150);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 19;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(627, 96);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 18;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += BtnUpdate_Click;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(627, 45);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(94, 29);
            btnCreate.TabIndex = 17;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += BtnCreate_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(22, 253);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 16;
            btnClear.Text = "Clear Data";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += BtnClear_Click;
            // 
            // chkAvailable
            // 
            chkAvailable.AutoSize = true;
            chkAvailable.Location = new Point(185, 169);
            chkAvailable.Name = "chkAvailable";
            chkAvailable.Size = new Size(18, 17);
            chkAvailable.TabIndex = 6;
            chkAvailable.UseVisualStyleBackColor = true;
            chkAvailable.CheckedChanged += ChkAvailable_CheckedChanged;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(185, 104);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(286, 27);
            txtPhone.TabIndex = 5;
            txtPhone.TextChanged += TxtPhone_TextChanged;
            // 
            // txtName
            // 
            txtName.Location = new Point(185, 47);
            txtName.Name = "txtName";
            txtName.Size = new Size(286, 27);
            txtName.TabIndex = 4;
            txtName.TextChanged += TxtName_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 111);
            label3.Name = "label3";
            label3.Size = new Size(111, 20);
            label3.TabIndex = 3;
            label3.Text = "Phone Number:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 166);
            label4.Name = "label4";
            label4.Size = new Size(88, 20);
            label4.TabIndex = 2;
            label4.Text = "Is Available:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 54);
            label2.Name = "label2";
            label2.Size = new Size(101, 20);
            label2.TabIndex = 0;
            label2.Text = "Walker Name:";
            // 
            // WalkerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 737);
            Controls.Add(groupBox1);
            Controls.Add(dgvWalkers);
            Controls.Add(btnSearch);
            Controls.Add(chkSearchAll);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Name = "WalkerForm";
            Text = "WalkerForm";
            ((System.ComponentModel.ISupportInitialize)dgvWalkers).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSearch;
        private CheckBox chkSearchAll;
        private TextBox txtSearch;
        private Label label1;
        private DataGridView dgvWalkers;
        private GroupBox groupBox1;
        private Label label2;
        private Label label4;
        private Label label3;
        private TextBox txtPhone;
        private TextBox txtName;
        private CheckBox chkAvailable;
        private Button btnClear;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnCreate;
    }
}