namespace interceptGUI
{
    partial class SettingsFrm
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
            this.generalGroup = new System.Windows.Forms.GroupBox();
            this.checkStartup = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.HIDlbl = new System.Windows.Forms.Label();
            this.HIDbtn = new System.Windows.Forms.Button();
            this.HIDtxt = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.CodeCmb = new System.Windows.Forms.ComboBox();
            this.unsIntBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.generalGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // generalGroup
            // 
            this.generalGroup.Controls.Add(this.checkStartup);
            this.generalGroup.Location = new System.Drawing.Point(12, 12);
            this.generalGroup.Name = "generalGroup";
            this.generalGroup.Size = new System.Drawing.Size(280, 46);
            this.generalGroup.TabIndex = 0;
            this.generalGroup.TabStop = false;
            this.generalGroup.Text = "General";
            // 
            // checkStartup
            // 
            this.checkStartup.AutoSize = true;
            this.checkStartup.Location = new System.Drawing.Point(6, 19);
            this.checkStartup.Name = "checkStartup";
            this.checkStartup.Size = new System.Drawing.Size(121, 17);
            this.checkStartup.TabIndex = 0;
            this.checkStartup.Text = "Set Startup window ";
            this.checkStartup.UseVisualStyleBackColor = true;
            this.checkStartup.CheckedChanged += new System.EventHandler(this.checkStartup_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.HIDlbl);
            this.groupBox1.Controls.Add(this.HIDbtn);
            this.groupBox1.Controls.Add(this.HIDtxt);
            this.groupBox1.Location = new System.Drawing.Point(12, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 87);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Keyboard Hardware ID";
            // 
            // HIDlbl
            // 
            this.HIDlbl.AutoSize = true;
            this.HIDlbl.Location = new System.Drawing.Point(32, 42);
            this.HIDlbl.Name = "HIDlbl";
            this.HIDlbl.Size = new System.Drawing.Size(215, 13);
            this.HIDlbl.TabIndex = 14;
            this.HIDlbl.Text = "Press any key on 2nd keyboard for continue";
            this.HIDlbl.Visible = false;
            // 
            // HIDbtn
            // 
            this.HIDbtn.Location = new System.Drawing.Point(181, 58);
            this.HIDbtn.Name = "HIDbtn";
            this.HIDbtn.Size = new System.Drawing.Size(92, 23);
            this.HIDbtn.TabIndex = 1;
            this.HIDbtn.Text = "Get Device HID";
            this.HIDbtn.UseVisualStyleBackColor = true;
            this.HIDbtn.Click += new System.EventHandler(this.HIDbtn_Click);
            // 
            // HIDtxt
            // 
            this.HIDtxt.Location = new System.Drawing.Point(6, 19);
            this.HIDtxt.Name = "HIDtxt";
            this.HIDtxt.Size = new System.Drawing.Size(267, 20);
            this.HIDtxt.TabIndex = 0;
            this.HIDtxt.TextChanged += new System.EventHandler(this.HIDtxt_TextChanged);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(213, 219);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // CodeCmb
            // 
            this.CodeCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CodeCmb.FormattingEnabled = true;
            this.CodeCmb.Location = new System.Drawing.Point(6, 19);
            this.CodeCmb.Name = "CodeCmb";
            this.CodeCmb.Size = new System.Drawing.Size(267, 21);
            this.CodeCmb.TabIndex = 4;
            this.CodeCmb.SelectedIndexChanged += new System.EventHandler(this.CodeCmb_SelectedIndexChanged);
            // 
            // unsIntBtn
            // 
            this.unsIntBtn.Location = new System.Drawing.Point(12, 219);
            this.unsIntBtn.Name = "unsIntBtn";
            this.unsIntBtn.Size = new System.Drawing.Size(127, 23);
            this.unsIntBtn.TabIndex = 6;
            this.unsIntBtn.Text = "Uninstall Interception";
            this.unsIntBtn.UseVisualStyleBackColor = true;
            this.unsIntBtn.Click += new System.EventHandler(this.unsIntBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CodeCmb);
            this.groupBox2.Location = new System.Drawing.Point(12, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 55);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Code editor";
            // 
            // SettingsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 254);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.unsIntBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.generalGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsFrm";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsFrm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsFrm_Load);
            this.generalGroup.ResumeLayout(false);
            this.generalGroup.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox generalGroup;
        private System.Windows.Forms.CheckBox checkStartup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button HIDbtn;
        private System.Windows.Forms.TextBox HIDtxt;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.ComboBox CodeCmb;
        private System.Windows.Forms.Button unsIntBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label HIDlbl;
    }
}