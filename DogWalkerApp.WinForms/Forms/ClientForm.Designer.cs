namespace DogWalkerApp.WinForms
{
    partial class ClientForm
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
            txtSearch = new TextBox();
            chkSearchAll = new CheckBox();
            btnSearch = new Button();
            dgvClients = new DataGridView();
            AddUpdateClientGB = new GroupBox();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnCreate = new Button();
            btnClear = new Button();
            txtAddress = new TextBox();
            txtPhone = new TextBox();
            txtName = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            AddUpdateClientGB.SuspendLayout();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(154, 43);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Client Name or Phone Number";
            txtSearch.Size = new Size(236, 27);
            txtSearch.TabIndex = 1;
            // 
            // chkSearchAll
            // 
            chkSearchAll.AutoSize = true;
            chkSearchAll.Location = new Point(156, 76);
            chkSearchAll.Name = "chkSearchAll";
            chkSearchAll.Size = new Size(97, 24);
            chkSearchAll.TabIndex = 2;
            chkSearchAll.Text = "Search All";
            chkSearchAll.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(410, 44);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(123, 29);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search Client";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += BtnSearch_Click;
            // 
            // dgvClients
            // 
            dgvClients.AllowUserToAddRows = false;
            dgvClients.AllowUserToDeleteRows = false;
            dgvClients.AllowUserToOrderColumns = true;
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Location = new Point(37, 144);
            dgvClients.MultiSelect = false;
            dgvClients.Name = "dgvClients";
            dgvClients.ReadOnly = true;
            dgvClients.RowHeadersWidth = 51;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.Size = new Size(690, 188);
            dgvClients.TabIndex = 4;
            dgvClients.SelectionChanged += DgvClients_SelectionChanged;
            // 
            // AddUpdateClientGB
            // 
            AddUpdateClientGB.Controls.Add(btnDelete);
            AddUpdateClientGB.Controls.Add(btnUpdate);
            AddUpdateClientGB.Controls.Add(btnCreate);
            AddUpdateClientGB.Controls.Add(btnClear);
            AddUpdateClientGB.Controls.Add(txtAddress);
            AddUpdateClientGB.Controls.Add(txtPhone);
            AddUpdateClientGB.Controls.Add(txtName);
            AddUpdateClientGB.Controls.Add(label4);
            AddUpdateClientGB.Controls.Add(label3);
            AddUpdateClientGB.Controls.Add(label2);
            AddUpdateClientGB.Location = new Point(37, 378);
            AddUpdateClientGB.Name = "AddUpdateClientGB";
            AddUpdateClientGB.Size = new Size(690, 255);
            AddUpdateClientGB.TabIndex = 5;
            AddUpdateClientGB.TabStop = false;
            AddUpdateClientGB.Text = "Create or Update Client";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(550, 142);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(550, 88);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += BtnUpdate_Click;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(550, 37);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(94, 29);
            btnCreate.TabIndex = 9;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += BtnCreate_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(122, 204);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 8;
            btnClear.Text = "Clear Data";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += BtnClear_Click;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(119, 123);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(328, 66);
            txtAddress.TabIndex = 7;
            txtAddress.TextChanged += TxtAddress_TextChanged;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(118, 81);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(328, 27);
            txtPhone.TabIndex = 6;
            txtPhone.TextChanged += TxtPhone_TextChanged;
            // 
            // txtName
            // 
            txtName.Location = new Point(119, 35);
            txtName.Name = "txtName";
            txtName.Size = new Size(328, 27);
            txtName.TabIndex = 5;
            txtName.TextChanged += TxtName_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 130);
            label4.Name = "label4";
            label4.Size = new Size(65, 20);
            label4.TabIndex = 2;
            label4.Text = "Address:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 88);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
            label3.TabIndex = 1;
            label3.Text = "Phone:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 42);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 0;
            label2.Text = "Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 46);
            label1.Name = "label1";
            label1.Size = new Size(98, 20);
            label1.TabIndex = 6;
            label1.Text = "Client Search:";
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 675);
            Controls.Add(label1);
            Controls.Add(AddUpdateClientGB);
            Controls.Add(dgvClients);
            Controls.Add(btnSearch);
            Controls.Add(chkSearchAll);
            Controls.Add(txtSearch);
            Name = "ClientForm";
            Text = "ClientForm";
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            AddUpdateClientGB.ResumeLayout(false);
            AddUpdateClientGB.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtSearch;
        private CheckBox chkSearchAll;
        private Button btnSearch;
        private DataGridView dgvClients;
        private GroupBox AddUpdateClientGB;
        private TextBox txtAddress;
        private TextBox txtPhone;
        private TextBox txtName;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnClear;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnCreate;
        private Label label1;
    }
}