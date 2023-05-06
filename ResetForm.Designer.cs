namespace ResetWindows
{
    partial class ResetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResetForm));
            btnExit = new Button();
            lblInfo = new Label();
            btnResetAllWindows = new Button();
            SuspendLayout();
            //
            // btnExit
            //
            btnExit.Location = new Point(619, 386);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(169, 52);
            btnExit.TabIndex = 0;
            btnExit.Text = "&Close";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += CloseClick;
            //
            // lblInfo
            //
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(12, 9);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(549, 74);
            lblInfo.TabIndex = 1;
            lblInfo.Text = "Bring all application windows to this monitor\r\nvia Reset all windows\r\n";
            //
            // btnResetAllWindows
            //
            btnResetAllWindows.Location = new Point(261, 159);
            btnResetAllWindows.Name = "btnResetAllWindows";
            btnResetAllWindows.Size = new Size(300, 118);
            btnResetAllWindows.TabIndex = 2;
            btnResetAllWindows.Text = "Reset &all windows";
            btnResetAllWindows.UseVisualStyleBackColor = true;
            btnResetAllWindows.Click += ResetAllWindowsClick;
            //
            // ResetForm
            //
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(btnResetAllWindows);
            Controls.Add(lblInfo);
            Controls.Add(btnExit);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ResetForm";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reset windows";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExit;
        private Label lblInfo;
        private Button btnResetAllWindows;
    }
}