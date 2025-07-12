namespace DogWalkerApp.WinForms.Forms
{
    partial class SubscriptionForm
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
            dgvSubscriptions = new DataGridView();
            groupBox1 = new GroupBox();
            btnDelete = new Button();
            btnUpdate = new Button();
            numMaxDogs = new NumericUpDown();
            btnCreate = new Button();
            btnClear = new Button();
            chkIsActive = new CheckBox();
            cmbFrequency = new ComboBox();
            cmbClients = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSubscriptions).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMaxDogs).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 36);
            label1.Name = "label1";
            label1.Size = new Size(142, 20);
            label1.TabIndex = 0;
            label1.Text = "Subscription Search:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(174, 29);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Enter Client Name";
            txtSearch.Size = new Size(376, 27);
            txtSearch.TabIndex = 1;
            // 
            // chkSearchAll
            // 
            chkSearchAll.AutoSize = true;
            chkSearchAll.Location = new Point(175, 63);
            chkSearchAll.Name = "chkSearchAll";
            chkSearchAll.Size = new Size(97, 24);
            chkSearchAll.TabIndex = 2;
            chkSearchAll.Text = "Search All";
            chkSearchAll.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(579, 32);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += BtnSearch_Click;
            // 
            // dgvSubscriptions
            // 
            dgvSubscriptions.AllowUserToAddRows = false;
            dgvSubscriptions.AllowUserToDeleteRows = false;
            dgvSubscriptions.AllowUserToOrderColumns = true;
            dgvSubscriptions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSubscriptions.Location = new Point(26, 131);
            dgvSubscriptions.Name = "dgvSubscriptions";
            dgvSubscriptions.ReadOnly = true;
            dgvSubscriptions.RowHeadersWidth = 51;
            dgvSubscriptions.Size = new Size(744, 225);
            dgvSubscriptions.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(numMaxDogs);
            groupBox1.Controls.Add(btnCreate);
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(chkIsActive);
            groupBox1.Controls.Add(cmbFrequency);
            groupBox1.Controls.Add(cmbClients);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(26, 399);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(744, 345);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Create or Update a Subscription";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(621, 182);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(621, 119);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 11;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += BtnUpdate_Click;
            // 
            // numMaxDogs
            // 
            numMaxDogs.Location = new Point(170, 180);
            numMaxDogs.Name = "numMaxDogs";
            numMaxDogs.Size = new Size(150, 27);
            numMaxDogs.TabIndex = 7;
            numMaxDogs.ValueChanged += NumMaxDogs_ValueChanged;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(621, 62);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(94, 29);
            btnCreate.TabIndex = 10;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += BtnCreate_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(26, 293);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 9;
            btnClear.Text = "Clear Data";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += BtnClear_Click;
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Location = new Point(170, 237);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(18, 17);
            chkIsActive.TabIndex = 8;
            chkIsActive.UseVisualStyleBackColor = true;
            chkIsActive.CheckedChanged += ChkIsActive_CheckedChanged;
            // 
            // cmbFrequency
            // 
            cmbFrequency.FormattingEnabled = true;
            cmbFrequency.Location = new Point(170, 119);
            cmbFrequency.Name = "cmbFrequency";
            cmbFrequency.Size = new Size(354, 28);
            cmbFrequency.TabIndex = 6;
            cmbFrequency.SelectedIndexChanged += CmbFrequency_SelectedIndexChanged;
            // 
            // cmbClients
            // 
            cmbClients.FormattingEnabled = true;
            cmbClients.Location = new Point(170, 63);
            cmbClients.Name = "cmbClients";
            cmbClients.Size = new Size(354, 28);
            cmbClients.TabIndex = 5;
            cmbClients.SelectedIndexChanged += CmbClients_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 238);
            label5.Name = "label5";
            label5.Size = new Size(67, 20);
            label5.TabIndex = 3;
            label5.Text = "Is Active:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 182);
            label4.Name = "label4";
            label4.Size = new Size(79, 20);
            label4.TabIndex = 2;
            label4.Text = "Max Dogs:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 127);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 1;
            label3.Text = "Frequency:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 71);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 0;
            label2.Text = "Client:";
            // 
            // SubscriptionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 781);
            Controls.Add(groupBox1);
            Controls.Add(dgvSubscriptions);
            Controls.Add(btnSearch);
            Controls.Add(chkSearchAll);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Name = "SubscriptionForm";
            Text = "SubscriptionForm";
            ((System.ComponentModel.ISupportInitialize)dgvSubscriptions).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMaxDogs).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSearch;
        private CheckBox chkSearchAll;
        private Button btnSearch;
        private DataGridView dgvSubscriptions;
        private GroupBox groupBox1;
        private ComboBox cmbFrequency;
        private ComboBox cmbClients;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnClear;
        private CheckBox chkIsActive;
        private Button btnCreate;
        private Button btnDelete;
        private Button btnUpdate;
        private NumericUpDown numMaxDogs;
    }
}