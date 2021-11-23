namespace interceptGUI
{
    partial class Wizard
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
            this.AHKinstalled = new System.Windows.Forms.CheckBox();
            this.InterceptionInstalled = new System.Windows.Forms.CheckBox();
            this.VSCodeInstalled = new System.Windows.Forms.CheckBox();
            this.IntInstall = new System.Windows.Forms.Button();
            this.RestartLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AHKinstalled
            // 
            this.AHKinstalled.AutoCheck = false;
            this.AHKinstalled.AutoSize = true;
            this.AHKinstalled.Location = new System.Drawing.Point(12, 10);
            this.AHKinstalled.Name = "AHKinstalled";
            this.AHKinstalled.Size = new System.Drawing.Size(83, 17);
            this.AHKinstalled.TabIndex = 0;
            this.AHKinstalled.Text = "AutoHotKey";
            this.AHKinstalled.UseVisualStyleBackColor = true;
            // 
            // InterceptionInstalled
            // 
            this.InterceptionInstalled.AutoCheck = false;
            this.InterceptionInstalled.AutoSize = true;
            this.InterceptionInstalled.Location = new System.Drawing.Point(12, 33);
            this.InterceptionInstalled.Name = "InterceptionInstalled";
            this.InterceptionInstalled.Size = new System.Drawing.Size(82, 17);
            this.InterceptionInstalled.TabIndex = 1;
            this.InterceptionInstalled.Text = "Interception";
            this.InterceptionInstalled.UseVisualStyleBackColor = true;
            // 
            // VSCodeInstalled
            // 
            this.VSCodeInstalled.AutoCheck = false;
            this.VSCodeInstalled.AutoSize = true;
            this.VSCodeInstalled.Location = new System.Drawing.Point(12, 93);
            this.VSCodeInstalled.Name = "VSCodeInstalled";
            this.VSCodeInstalled.Size = new System.Drawing.Size(163, 17);
            this.VSCodeInstalled.TabIndex = 2;
            this.VSCodeInstalled.Text = "Visual Studio Code (Optional)";
            this.VSCodeInstalled.UseVisualStyleBackColor = true;
            // 
            // IntInstall
            // 
            this.IntInstall.Location = new System.Drawing.Point(142, 29);
            this.IntInstall.Name = "IntInstall";
            this.IntInstall.Size = new System.Drawing.Size(75, 23);
            this.IntInstall.TabIndex = 4;
            this.IntInstall.Text = "Install";
            this.IntInstall.UseVisualStyleBackColor = true;
            this.IntInstall.Click += new System.EventHandler(this.IntInstall_Click);
            // 
            // RestartLbl
            // 
            this.RestartLbl.AutoSize = true;
            this.RestartLbl.ForeColor = System.Drawing.Color.Red;
            this.RestartLbl.Location = new System.Drawing.Point(9, 53);
            this.RestartLbl.Name = "RestartLbl";
            this.RestartLbl.Size = new System.Drawing.Size(100, 13);
            this.RestartLbl.TabIndex = 5;
            this.RestartLbl.Text = "Restart for continue";
            this.RestartLbl.Visible = false;
            // 
            // Wizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 121);
            this.Controls.Add(this.RestartLbl);
            this.Controls.Add(this.IntInstall);
            this.Controls.Add(this.VSCodeInstalled);
            this.Controls.Add(this.InterceptionInstalled);
            this.Controls.Add(this.AHKinstalled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Wizard";
            this.Text = "Check Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Wizard_FormClosing);
            this.Load += new System.EventHandler(this.Wizard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox AHKinstalled;
        private System.Windows.Forms.CheckBox InterceptionInstalled;
        private System.Windows.Forms.CheckBox VSCodeInstalled;
        private System.Windows.Forms.Button IntInstall;
        private System.Windows.Forms.Label RestartLbl;
    }
}