namespace DogWalkerApp.WinForms
{
    partial class HomeForm
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
            lblWeeklySummary = new Label();
            label2 = new Label();
            dgvTodayDogs = new DataGridView();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvTodayDogs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(26, 39);
            label1.Name = "label1";
            label1.Size = new Size(439, 28);
            label1.TabIndex = 0;
            label1.Text = "How many dogs are we making happy this week?";
            // 
            // lblWeeklySummary
            // 
            lblWeeklySummary.AutoSize = true;
            lblWeeklySummary.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblWeeklySummary.Location = new Point(31, 87);
            lblWeeklySummary.Name = "lblWeeklySummary";
            lblWeeklySummary.Size = new Size(59, 23);
            lblWeeklySummary.TabIndex = 1;
            lblWeeklySummary.Text = "label2";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(26, 175);
            label2.Name = "label2";
            label2.Size = new Size(161, 28);
            label2.TabIndex = 2;
            label2.Text = "Today's Schedule";
            // 
            // dgvTodayDogs
            // 
            dgvTodayDogs.AllowUserToAddRows = false;
            dgvTodayDogs.AllowUserToDeleteRows = false;
            dgvTodayDogs.AllowUserToOrderColumns = true;
            dgvTodayDogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTodayDogs.Location = new Point(26, 227);
            dgvTodayDogs.Name = "dgvTodayDogs";
            dgvTodayDogs.ReadOnly = true;
            dgvTodayDogs.RowHeadersWidth = 51;
            dgvTodayDogs.Size = new Size(439, 122);
            dgvTodayDogs.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.MenuImage;
            pictureBox1.Location = new Point(567, 62);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(253, 232);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 450);
            Controls.Add(pictureBox1);
            Controls.Add(dgvTodayDogs);
            Controls.Add(label2);
            Controls.Add(lblWeeklySummary);
            Controls.Add(label1);
            Name = "HomeForm";
            Text = "Dog Walker App - Home";
            Load += HomeForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTodayDogs).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblWeeklySummary;
        private Label label2;
        private DataGridView dgvTodayDogs;
        private PictureBox pictureBox1;
    }
}