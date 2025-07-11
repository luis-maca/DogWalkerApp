namespace DogWalkerApp.WinForms
{
    partial class MainMenuForm
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
            btnClients = new Button();
            SuspendLayout();
            // 
            // btnClients
            // 
            btnClients.Location = new Point(44, 188);
            btnClients.Name = "btnClients";
            btnClients.Size = new Size(94, 60);
            btnClients.TabIndex = 0;
            btnClients.Text = "Manage Clients";
            btnClients.UseVisualStyleBackColor = true;
            btnClients.Click += btnClients_Click;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClients);
            Name = "MainMenuForm";
            Text = "MainMenuForm";
            ResumeLayout(false);
        }

        #endregion

        private Button btnClients;
    }
}