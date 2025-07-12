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
            dgvSelectedDogs = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvWalks).BeginInit();
            groupBox1.SuspendLayout();
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
            dgvWalks.Size = new Size(775, 254);
            dgvWalks.TabIndex = 13;
            // 
            // groupBox1
            // 
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
            groupBox1.Location = new Point(38, 424);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(771, 469);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Create or Update a Dog Walk Record";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(638, 155);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 22;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(638, 101);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 21;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(638, 50);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(94, 29);
            btnCreate.TabIndex = 20;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(22, 424);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 17;
            btnClear.Text = "Clear Data";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnRemoveDogFromWalk
            // 
            btnRemoveDogFromWalk.Location = new Point(298, 237);
            btnRemoveDogFromWalk.Name = "btnRemoveDogFromWalk";
            btnRemoveDogFromWalk.Size = new Size(123, 29);
            btnRemoveDogFromWalk.TabIndex = 10;
            btnRemoveDogFromWalk.Text = "Remove Dog";
            btnRemoveDogFromWalk.UseVisualStyleBackColor = true;
            // 
            // btnAddDogToWalk
            // 
            btnAddDogToWalk.Location = new Point(171, 237);
            btnAddDogToWalk.Name = "btnAddDogToWalk";
            btnAddDogToWalk.Size = new Size(94, 29);
            btnAddDogToWalk.TabIndex = 9;
            btnAddDogToWalk.Text = "Add Dog";
            btnAddDogToWalk.UseVisualStyleBackColor = true;
            // 
            // dtpWalkDate
            // 
            dtpWalkDate.Location = new Point(171, 99);
            dtpWalkDate.Name = "dtpWalkDate";
            dtpWalkDate.Size = new Size(334, 27);
            dtpWalkDate.TabIndex = 7;
            // 
            // cmbAvailableDogs
            // 
            cmbAvailableDogs.FormattingEnabled = true;
            cmbAvailableDogs.Location = new Point(171, 198);
            cmbAvailableDogs.Name = "cmbAvailableDogs";
            cmbAvailableDogs.Size = new Size(334, 28);
            cmbAvailableDogs.TabIndex = 6;
            // 
            // cmbClients
            // 
            cmbClients.FormattingEnabled = true;
            cmbClients.Location = new Point(171, 150);
            cmbClients.Name = "cmbClients";
            cmbClients.Size = new Size(334, 28);
            cmbClients.TabIndex = 5;
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
            label5.Location = new Point(22, 206);
            label5.Name = "label5";
            label5.Size = new Size(113, 20);
            label5.TabIndex = 3;
            label5.Text = "Available Dogs:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 158);
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
            // dgvSelectedDogs
            // 
            dgvSelectedDogs.AllowUserToAddRows = false;
            dgvSelectedDogs.AllowUserToDeleteRows = false;
            dgvSelectedDogs.AllowUserToOrderColumns = true;
            dgvSelectedDogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSelectedDogs.Location = new Point(22, 281);
            dgvSelectedDogs.Name = "dgvSelectedDogs";
            dgvSelectedDogs.ReadOnly = true;
            dgvSelectedDogs.RowHeadersWidth = 51;
            dgvSelectedDogs.Size = new Size(658, 127);
            dgvSelectedDogs.TabIndex = 23;
            // 
            // DogWalkForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 921);
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
    }
}