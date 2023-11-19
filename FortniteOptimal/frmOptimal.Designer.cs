namespace FortniteOptimal
{
    partial class frmOptimal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLaunch = new Button();
            chkLaunch = new CheckBox();
            chkClose = new CheckBox();
            lstConfig = new ListBox();
            chkCustomSettings = new CheckBox();
            SuspendLayout();
            // 
            // btnLaunch
            // 
            btnLaunch.BackColor = Color.Lime;
            btnLaunch.FlatStyle = FlatStyle.Flat;
            btnLaunch.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnLaunch.Location = new Point(12, 12);
            btnLaunch.Name = "btnLaunch";
            btnLaunch.Size = new Size(75, 23);
            btnLaunch.TabIndex = 0;
            btnLaunch.Text = "Launch";
            btnLaunch.UseVisualStyleBackColor = false;
            btnLaunch.Click += btnLaunch_Click;
            // 
            // chkLaunch
            // 
            chkLaunch.AutoSize = true;
            chkLaunch.Location = new Point(93, 16);
            chkLaunch.Name = "chkLaunch";
            chkLaunch.Size = new Size(96, 19);
            chkLaunch.TabIndex = 1;
            chkLaunch.Text = "Auto-Launch";
            chkLaunch.UseVisualStyleBackColor = true;
            chkLaunch.CheckedChanged += chkLaunch_CheckedChanged;
            // 
            // chkClose
            // 
            chkClose.AutoSize = true;
            chkClose.Location = new Point(93, 41);
            chkClose.Name = "chkClose";
            chkClose.Size = new Size(86, 19);
            chkClose.TabIndex = 2;
            chkClose.Text = "Auto-Close";
            chkClose.UseVisualStyleBackColor = true;
            chkClose.CheckedChanged += chkClose_CheckedChanged;
            // 
            // lstConfig
            // 
            lstConfig.FormattingEnabled = true;
            lstConfig.ItemHeight = 15;
            lstConfig.Location = new Point(12, 100);
            lstConfig.Name = "lstConfig";
            lstConfig.Size = new Size(353, 94);
            lstConfig.TabIndex = 4;
            // 
            // chkCustomSettings
            // 
            chkCustomSettings.AutoSize = true;
            chkCustomSettings.Location = new Point(12, 75);
            chkCustomSettings.Name = "chkCustomSettings";
            chkCustomSettings.Size = new Size(135, 19);
            chkCustomSettings.TabIndex = 3;
            chkCustomSettings.Text = "Use Custom Settings";
            chkCustomSettings.UseVisualStyleBackColor = true;
            chkCustomSettings.CheckedChanged += chkCustomSettings_CheckedChanged;
            // 
            // frmOptimal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(chkCustomSettings);
            Controls.Add(lstConfig);
            Controls.Add(chkClose);
            Controls.Add(chkLaunch);
            Controls.Add(btnLaunch);
            Name = "frmOptimal";
            Text = "FNOP";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLaunch;
        private CheckBox chkLaunch;
        private CheckBox chkClose;
        private ListBox lstConfig;
        private CheckBox chkCustomSettings;
    }
}