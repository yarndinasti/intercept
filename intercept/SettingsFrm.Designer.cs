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
      this.checkBox1 = new System.Windows.Forms.CheckBox();
      this.comboBox1 = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.checkStartup = new System.Windows.Forms.CheckBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.HIDlbl = new System.Windows.Forms.Label();
      this.HIDbtn = new System.Windows.Forms.Button();
      this.HIDtxt = new System.Windows.Forms.TextBox();
      this.saveBtn = new System.Windows.Forms.Button();
      this.CodeCmb = new System.Windows.Forms.ComboBox();
      this.unsIntBtn = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.AHKcombo = new System.Windows.Forms.ComboBox();
      this.generalGroup.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.SuspendLayout();
      // 
      // generalGroup
      // 
      this.generalGroup.Controls.Add(this.checkBox1);
      this.generalGroup.Controls.Add(this.comboBox1);
      this.generalGroup.Controls.Add(this.label1);
      this.generalGroup.Controls.Add(this.checkStartup);
      this.generalGroup.Location = new System.Drawing.Point(12, 12);
      this.generalGroup.Name = "generalGroup";
      this.generalGroup.Size = new System.Drawing.Size(280, 98);
      this.generalGroup.TabIndex = 0;
      this.generalGroup.TabStop = false;
      this.generalGroup.Text = "General";
      // 
      // checkBox1
      // 
      this.checkBox1.AutoSize = true;
      this.checkBox1.Enabled = false;
      this.checkBox1.Location = new System.Drawing.Point(6, 42);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new System.Drawing.Size(129, 17);
      this.checkBox1.TabIndex = 3;
      this.checkBox1.Text = "Disable Macro Editing";
      this.checkBox1.UseVisualStyleBackColor = true;
      // 
      // comboBox1
      // 
      this.comboBox1.Enabled = false;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new System.Drawing.Point(69, 67);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(204, 21);
      this.comboBox1.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 70);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(55, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Language";
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
      this.groupBox1.Location = new System.Drawing.Point(12, 116);
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
      this.saveBtn.Location = new System.Drawing.Point(210, 328);
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
      this.unsIntBtn.Location = new System.Drawing.Point(12, 328);
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
      this.groupBox2.Location = new System.Drawing.Point(12, 209);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(280, 55);
      this.groupBox2.TabIndex = 7;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Code editor";
      // 
      // groupBox4
      // 
      this.groupBox4.Controls.Add(this.AHKcombo);
      this.groupBox4.Location = new System.Drawing.Point(12, 270);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new System.Drawing.Size(280, 52);
      this.groupBox4.TabIndex = 17;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "AutoHotKey Variant";
      // 
      // AHKcombo
      // 
      this.AHKcombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.AHKcombo.FormattingEnabled = true;
      this.AHKcombo.Location = new System.Drawing.Point(6, 19);
      this.AHKcombo.Name = "AHKcombo";
      this.AHKcombo.Size = new System.Drawing.Size(267, 21);
      this.AHKcombo.TabIndex = 0;
      // 
      // SettingsFrm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(304, 361);
      this.Controls.Add(this.groupBox4);
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
      this.groupBox4.ResumeLayout(false);
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
    private System.Windows.Forms.CheckBox checkBox1;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.ComboBox AHKcombo;
  }
}