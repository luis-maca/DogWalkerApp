namespace DogWalkerApp.WinForms.Forms
{
    partial class DogWalkForm
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
            dgvWalks = new DataGridView();
            groupBox1 = new GroupBox();
            numDuration = new NumericUpDown();
            label6 = new Label();
            dtpWalkTime = new DateTimePicker();
            dgvSelectedDogs = new DataGridView();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnCreate = new Button();
            btnClear = new Button();
            btnRemoveDogFromWalk = new Button();
            btnAddDogToWalk = new Button();
            dtpWalkDate = new DateTimePicker();
            cmbAvailableDogs = new ComboBox();
            cmbClients = new ComboBox();
            cmbWalker = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvWalks).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSelectedDogs).BeginInit();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(534, 29);
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
            chkSearchAll.Location = new Point(174, 64);
            chkSearchAll.Name = "chkSearchAll";
            chkSearchAll.Size = new Size(97, 24);
            chkSearchAll.TabIndex = 11;
            chkSearchAll.Text = "Search All";
            chkSearchAll.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(174, 31);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Enter Walker's Name";
            txtSearch.Size = new Size(332, 27);
            txtSearch.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 38);
            label1.Name = "label1";
            label1.Size = new Size(131, 20);
            label1.TabIndex = 9;
            label1.Text = "Search Dog Walks:";
            // 
            // dgvWalks
            // 
            dgvWalks.AllowUserToAddRows = false;
            dgvWalks.AllowUserToDeleteRows = false;
            dgvWalks.AllowUserToOrderColumns = true;
            dgvWalks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWalks.Location = new Point(35, 133);
            dgvWalks.Name = "dgvWalks";
            dgvWalks.ReadOnly = true;
            dgvWalks.RowHeadersWidth = 51;
            dgvWalks.Size = new Size(775, 190);
            dgvWalks.TabIndex = 13;
            dgvWalks.SelectionChanged += DgvWalks_SelectionChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(numDuration);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(dtpWalkTime);
            groupBox1.Controls.Add(dgvSelectedDogs);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(btnCreate);
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(btnRemoveDogFromWalk);
            groupBox1.Controls.Add(btnAddDogToWalk);
            groupBox1.Controls.Add(dtpWalkDate);
            groupBox1.Controls.Add(cmbAvailableDogs);
            groupBox1.Controls.Add(cmbClients);
            groupBox1.Controls.Add(cmbWalker);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(35, 352);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(771, 505);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Create or Update a Dog Walk Record";
            // 
            // numDuration
            // 
            numDuration.Increment = new decimal(new int[] { 15, 0, 0, 0 });
            numDuration.Location = new Point(171, 141);
            numDuration.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            numDuration.Minimum = new decimal(new int[] { 15, 0, 0, 0 });
            numDuration.Name = "numDuration";
            numDuration.Size = new Size(103, 27);
            numDuration.TabIndex = 26;
            numDuration.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 148);
            label6.Name = "label6";
            label6.Size = new Size(109, 20);
            label6.TabIndex = 25;
            label6.Text = "Duration (Min):";
            // 
            // dtpWalkTime
            // 
            dtpWalkTime.CustomFormat = "HH:mm";
            dtpWalkTime.Format = DateTimePickerFormat.Time;
            dtpWalkTime.Location = new Point(298, 99);
            dtpWalkTime.Name = "dtpWalkTime";
            dtpWalkTime.ShowUpDown = true;
            dtpWalkTime.Size = new Size(83, 27);
            dtpWalkTime.TabIndex = 24;
            dtpWalkTime.Value = new DateTime(2025, 7, 12, 9, 0, 0, 0);
            // 
            // dgvSelectedDogs
            // 
            dgvSelectedDogs.AllowUserToAddRows = false;
            dgvSelectedDogs.AllowUserToDeleteRows = false;
            dgvSelectedDogs.AllowUserToOrderColumns = true;
            dgvSelectedDogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSelectedDogs.Location = new Point(171, 316);
            dgvSelectedDogs.Name = "dgvSelectedDogs";
            dgvSelectedDogs.ReadOnly = true;
            dgvSelectedDogs.RowHeadersWidth = 51;
            dgvSelectedDogs.Size = new Size(334, 127);
            dgvSelectedDogs.TabIndex = 23;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(638, 155);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 22;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(638, 101);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 21;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += BtnUpdate_Click;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(638, 50);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(94, 29);
            btnCreate.TabIndex = 20;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += BtnCreate_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(22, 459);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 17;
            btnClear.Text = "Clear Data";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += BtnClear_Click;
            // 
            // btnRemoveDogFromWalk
            // 
            btnRemoveDogFromWalk.Location = new Point(298, 272);
            btnRemoveDogFromWalk.Name = "btnRemoveDogFromWalk";
            btnRemoveDogFromWalk.Size = new Size(123, 29);
            btnRemoveDogFromWalk.TabIndex = 10;
            btnRemoveDogFromWalk.Text = "Remove Dog";
            btnRemoveDogFromWalk.UseVisualStyleBackColor = true;
            btnRemoveDogFromWalk.Click += BtnRemoveDog_Click;
            // 
            // btnAddDogToWalk
            // 
            btnAddDogToWalk.Location = new Point(171, 272);
            btnAddDogToWalk.Name = "btnAddDogToWalk";
            btnAddDogToWalk.Size = new Size(94, 29);
            btnAddDogToWalk.TabIndex = 9;
            btnAddDogToWalk.Text = "Add Dog";
            btnAddDogToWalk.UseVisualStyleBackColor = true;
            btnAddDogToWalk.Click += btnAddDogToWalk_Click;
            // 
            // dtpWalkDate
            // 
            dtpWalkDate.Format = DateTimePickerFormat.Short;
            dtpWalkDate.Location = new Point(171, 99);
            dtpWalkDate.Name = "dtpWalkDate";
            dtpWalkDate.Size = new Size(103, 27);
            dtpWalkDate.TabIndex = 7;
            // 
            // cmbAvailableDogs
            // 
            cmbAvailableDogs.FormattingEnabled = true;
            cmbAvailableDogs.Location = new Point(171, 233);
            cmbAvailableDogs.Name = "cmbAvailableDogs";
            cmbAvailableDogs.Size = new Size(334, 28);
            cmbAvailableDogs.TabIndex = 6;
            // 
            // cmbClients
            // 
            cmbClients.FormattingEnabled = true;
            cmbClients.Location = new Point(171, 185);
            cmbClients.Name = "cmbClients";
            cmbClients.Size = new Size(334, 28);
            cmbClients.TabIndex = 5;
            cmbClients.SelectedIndexChanged += cmbClients_SelectedIndexChanged;
            // 
            // cmbWalker
            // 
            cmbWalker.FormattingEnabled = true;
            cmbWalker.Location = new Point(171, 51);
            cmbWalker.Name = "cmbWalker";
            cmbWalker.Size = new Size(334, 28);
            cmbWalker.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 241);
            label5.Name = "label5";
            label5.Size = new Size(113, 20);
            label5.TabIndex = 3;
            label5.Text = "Available Dogs:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 193);
            label4.Name = "label4";
            label4.Size = new Size(94, 20);
            label4.TabIndex = 2;
            label4.Text = "Client Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 106);
            label3.Name = "label3";
            label3.Size = new Size(116, 20);
            label3.TabIndex = 1;
            label3.Text = "Walk Start Time:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 59);
            label2.Name = "label2";
            label2.Size = new Size(101, 20);
            label2.TabIndex = 0;
            label2.Text = "Walker Name:";
            // 
            // DogWalkForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 875);
            Controls.Add(groupBox1);
            Controls.Add(dgvWalks);
            Controls.Add(btnSearch);
            Controls.Add(chkSearchAll);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Name = "DogWalkForm";
            Text = "DogWalkForm";
            ((System.ComponentModel.ISupportInitialize)dgvWalks).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSelectedDogs).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSearch;
        private CheckBox chkSearchAll;
        private TextBox txtSearch;
        private Label label1;
        private DataGridView dgvWalks;
        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Label label5;
        private Label label4;
        private ComboBox cmbAvailableDogs;
        private ComboBox cmbClients;
        private ComboBox cmbWalker;
        private DateTimePicker dtpWalkDate;
        private Button btnRemoveDogFromWalk;
        private Button btnAddDogToWalk;
        private Button btnClear;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnCreate;
        private DataGridView dgvSelectedDogs;
        private DateTimePicker dtpWalkTime;
        private Label label6;
        private NumericUpDown numDuration;
    }
}