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
            this.IntInstall = new System.Windows.Forms.Button();
            this.RestartLbl = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.HIDbtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.HIDtxt = new System.Windows.Forms.TextBox();
            this.CodeCmb = new System.Windows.Forms.ComboBox();
            this.HIDlbl = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // AHKinstalled
            // 
            this.AHKinstalled.AutoCheck = false;
            this.AHKinstalled.AutoSize = true;
            this.AHKinstalled.Location = new System.Drawing.Point(6, 15);
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
            this.InterceptionInstalled.Location = new System.Drawing.Point(6, 34);
            this.InterceptionInstalled.Name = "InterceptionInstalled";
            this.InterceptionInstalled.Size = new System.Drawing.Size(82, 17);
            this.InterceptionInstalled.TabIndex = 1;
            this.InterceptionInstalled.Text = "Interception";
            this.InterceptionInstalled.UseVisualStyleBackColor = true;
            // 
            // IntInstall
            // 
            this.IntInstall.Location = new System.Drawing.Point(180, 28);
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
            this.RestartLbl.Location = new System.Drawing.Point(6, 54);
            this.RestartLbl.Name = "RestartLbl";
            this.RestartLbl.Size = new System.Drawing.Size(100, 13);
            this.RestartLbl.TabIndex = 5;
            this.RestartLbl.Text = "Restart for continue";
            this.RestartLbl.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IntInstall);
            this.groupBox1.Controls.Add(this.AHKinstalled);
            this.groupBox1.Controls.Add(this.RestartLbl);
            this.groupBox1.Controls.Add(this.InterceptionInstalled);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 76);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pre-requiesed";
            // 
            // HIDbtn
            // 
            this.HIDbtn.Enabled = false;
            this.HIDbtn.Location = new System.Drawing.Point(145, 61);
            this.HIDbtn.Name = "HIDbtn";
            this.HIDbtn.Size = new System.Drawing.Size(107, 23);
            this.HIDbtn.TabIndex = 11;
            this.HIDbtn.Text = "Get Keyboard HID";
            this.HIDbtn.UseVisualStyleBackColor = true;
            this.HIDbtn.Click += new System.EventHandler(this.HIDbtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Enabled = false;
            this.saveBtn.Location = new System.Drawing.Point(198, 251);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 10;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // HIDtxt
            // 
            this.HIDtxt.Enabled = false;
            this.HIDtxt.Location = new System.Drawing.Point(6, 21);
            this.HIDtxt.Name = "HIDtxt";
            this.HIDtxt.Size = new System.Drawing.Size(246, 20);
            this.HIDtxt.TabIndex = 9;
            this.HIDtxt.TextChanged += new System.EventHandler(this.HIDtxt_TextChanged);
            // 
            // CodeCmb
            // 
            this.CodeCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CodeCmb.Enabled = false;
            this.CodeCmb.FormattingEnabled = true;
            this.CodeCmb.Location = new System.Drawing.Point(6, 19);
            this.CodeCmb.Name = "CodeCmb";
            this.CodeCmb.Size = new System.Drawing.Size(249, 21);
            this.CodeCmb.TabIndex = 12;
            this.CodeCmb.SelectedIndexChanged += new System.EventHandler(this.CodeCmb_SelectedIndexChanged);
            // 
            // HIDlbl
            // 
            this.HIDlbl.AutoSize = true;
            this.HIDlbl.Location = new System.Drawing.Point(18, 44);
            this.HIDlbl.Name = "HIDlbl";
            this.HIDlbl.Size = new System.Drawing.Size(215, 13);
            this.HIDlbl.TabIndex = 13;
            this.HIDlbl.Text = "Press any key on 2nd keyboard for continue";
            this.HIDlbl.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.HIDtxt);
            this.groupBox2.Controls.Add(this.HIDlbl);
            this.groupBox2.Controls.Add(this.HIDbtn);
            this.groupBox2.Location = new System.Drawing.Point(12, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(261, 91);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Keyboard HID";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CodeCmb);
            this.groupBox3.Location = new System.Drawing.Point(12, 192);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(261, 53);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Code Editor";
            // 
            // Wizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 285);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Wizard";
            this.Text = "Check Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Wizard_FormClosing);
            this.Load += new System.EventHandler(this.Wizard_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox AHKinstalled;
        private System.Windows.Forms.CheckBox InterceptionInstalled;
        private System.Windows.Forms.Button IntInstall;
        private System.Windows.Forms.Label RestartLbl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button HIDbtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox HIDtxt;
        private System.Windows.Forms.ComboBox CodeCmb;
        private System.Windows.Forms.Label HIDlbl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}