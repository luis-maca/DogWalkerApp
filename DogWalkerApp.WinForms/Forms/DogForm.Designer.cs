namespace DogWalkerApp.WinForms.Forms
{
    partial class DogForm
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
            dgvDogs = new DataGridView();
            groupBox1 = new GroupBox();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnCreate = new Button();
            btnClear = new Button();
            txtNotes = new TextBox();
            label6 = new Label();
            numAge = new NumericUpDown();
            cmbBreed = new ComboBox();
            txtName = new TextBox();
            cmbClients = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDogs).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAge).BeginInit();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(536, 27);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(123, 29);
            btnSearch.TabIndex = 12;
            btnSearch.Text = "Search Client";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += BtnSearch_Click;
            // 
            // chkSearchAll
            // 
            chkSearchAll.AutoSize = true;
            chkSearchAll.Location = new Point(176, 62);
            chkSearchAll.Name = "chkSearchAll";
            chkSearchAll.Size = new Size(97, 24);
            chkSearchAll.TabIndex = 11;
            chkSearchAll.Text = "Search All";
            chkSearchAll.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(176, 29);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Enter Dog's Name or Client Name";
            txtSearch.Size = new Size(332, 27);
            txtSearch.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 36);
            label1.Name = "label1";
            label1.Size = new Size(95, 20);
            label1.TabIndex = 9;
            label1.Text = "Search Dogs:";
            // 
            // dgvDogs
            // 
            dgvDogs.AllowUserToAddRows = false;
            dgvDogs.AllowUserToDeleteRows = false;
            dgvDogs.AllowUserToOrderColumns = true;
            dgvDogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDogs.Location = new Point(37, 142);
            dgvDogs.Name = "dgvDogs";
            dgvDogs.ReadOnly = true;
            dgvDogs.RowHeadersWidth = 51;
            dgvDogs.Size = new Size(771, 260);
            dgvDogs.TabIndex = 13;
            dgvDogs.SelectionChanged += DgvDogs_SelectionChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(btnCreate);
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(txtNotes);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(numAge);
            groupBox1.Controls.Add(cmbBreed);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(cmbClients);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(37, 451);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(771, 394);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Create or Update a Dog Record";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(635, 161);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 22;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(635, 107);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 21;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += BtnUpdate_Click;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(635, 56);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(94, 29);
            btnCreate.TabIndex = 20;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += BtnCreate_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(29, 350);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 17;
            btnClear.Text = "Clear Data";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += BtnClear_Click;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(205, 273);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(294, 71);
            txtNotes.TabIndex = 9;
            txtNotes.TextChanged += TxtNotes_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(29, 273);
            label6.Name = "label6";
            label6.Size = new Size(137, 20);
            label6.TabIndex = 8;
            label6.Text = "Special Care Notes:";
            // 
            // numAge
            // 
            numAge.Location = new Point(205, 209);
            numAge.Name = "numAge";
            numAge.Size = new Size(72, 27);
            numAge.TabIndex = 7;
            numAge.ValueChanged += numAge_ValueChanged;
            // 
            // cmbBreed
            // 
            cmbBreed.FormattingEnabled = true;
            cmbBreed.Location = new Point(205, 152);
            cmbBreed.Name = "cmbBreed";
            cmbBreed.Size = new Size(294, 28);
            cmbBreed.TabIndex = 6;
            cmbBreed.SelectedIndexChanged += cmbBreed_SelectedIndexChanged;
            // 
            // txtName
            // 
            txtName.Location = new Point(205, 102);
            txtName.Name = "txtName";
            txtName.Size = new Size(294, 27);
            txtName.TabIndex = 5;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // cmbClients
            // 
            cmbClients.FormattingEnabled = true;
            cmbClients.Location = new Point(205, 52);
            cmbClients.Name = "cmbClients";
            cmbClients.Size = new Size(294, 28);
            cmbClients.TabIndex = 4;
            cmbClients.SelectedIndexChanged += CmbClients_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 216);
            label5.Name = "label5";
            label5.Size = new Size(72, 20);
            label5.TabIndex = 3;
            label5.Text = "Dog Age:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 160);
            label4.Name = "label4";
            label4.Size = new Size(84, 20);
            label4.TabIndex = 2;
            label4.Text = "Dog Breed:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 109);
            label3.Name = "label3";
            label3.Size = new Size(85, 20);
            label3.TabIndex = 1;
            label3.Text = "Dog Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 60);
            label2.Name = "label2";
            label2.Size = new Size(94, 20);
            label2.TabIndex = 0;
            label2.Text = "Client Name:";
            // 
            // DogForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(883, 878);
            Controls.Add(groupBox1);
            Controls.Add(dgvDogs);
            Controls.Add(btnSearch);
            Controls.Add(chkSearchAll);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Name = "DogForm";
            Text = "DogForm";
            ((System.ComponentModel.ISupportInitialize)dgvDogs).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAge).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSearch;
        private CheckBox chkSearchAll;
        private TextBox txtSearch;
        private Label label1;
        private DataGridView dgvDogs;
        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Label label4;
        private Label label5;
        private NumericUpDown numAge;
        private ComboBox cmbBreed;
        private TextBox txtName;
        private ComboBox cmbClients;
        private TextBox txtNotes;
        private Label label6;
        private Button btnClear;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnCreate;
    }
}