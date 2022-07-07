﻿namespace interceptGUI
{
    partial class Form1
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.runBtn = new System.Windows.Forms.Button();
      this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.editMacroToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.generalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.editMacroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aHKSyntaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.restartCMDbtn = new System.Windows.Forms.Button();
      this.editBtn = new System.Windows.Forms.Button();
      this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.streamerBotCMDGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.contextMenuStrip1.SuspendLayout();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // runBtn
      // 
      this.runBtn.Location = new System.Drawing.Point(12, 35);
      this.runBtn.Name = "runBtn";
      this.runBtn.Size = new System.Drawing.Size(203, 39);
      this.runBtn.TabIndex = 0;
      this.runBtn.Text = "Run";
      this.runBtn.UseVisualStyleBackColor = true;
      this.runBtn.Click += new System.EventHandler(this.button1_Click);
      // 
      // notifyIcon
      // 
      this.notifyIcon.ContextMenuStrip = this.contextMenuStrip1;
      this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
      this.notifyIcon.Text = "Macro";
      this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
      this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.toolStripSeparator1,
            this.editMacroToolStripMenuItem1,
            this.toolStripSeparator4,
            this.exitToolStripMenuItem});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(132, 104);
      // 
      // runToolStripMenuItem
      // 
      this.runToolStripMenuItem.Name = "runToolStripMenuItem";
      this.runToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
      this.runToolStripMenuItem.Text = "&Run";
      this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
      // 
      // restartToolStripMenuItem
      // 
      this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
      this.restartToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
      this.restartToolStripMenuItem.Text = "R&estart";
      this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartClick);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(128, 6);
      // 
      // editMacroToolStripMenuItem1
      // 
      this.editMacroToolStripMenuItem1.Name = "editMacroToolStripMenuItem1";
      this.editMacroToolStripMenuItem1.Size = new System.Drawing.Size(131, 22);
      this.editMacroToolStripMenuItem1.Text = "E&dit Macro";
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(128, 6);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
      this.exitToolStripMenuItem.Text = "&Exit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(227, 24);
      this.menuStrip1.TabIndex = 5;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // settingsToolStripMenuItem
      // 
      this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalToolStripMenuItem,
            this.toolStripSeparator3,
            this.editMacroToolStripMenuItem});
      this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
      this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
      this.settingsToolStripMenuItem.Text = "&Settings";
      // 
      // generalToolStripMenuItem
      // 
      this.generalToolStripMenuItem.Name = "generalToolStripMenuItem";
      this.generalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.generalToolStripMenuItem.Text = "&General";
      this.generalToolStripMenuItem.Click += new System.EventHandler(this.generalToolStripMenuItem_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
      // 
      // editMacroToolStripMenuItem
      // 
      this.editMacroToolStripMenuItem.Name = "editMacroToolStripMenuItem";
      this.editMacroToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.editMacroToolStripMenuItem.Text = "&Edit Macro";
      this.editMacroToolStripMenuItem.Click += new System.EventHandler(this.editMacroToolStripMenuItem_Click);
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aHKSyntaxToolStripMenuItem,
            this.toolStripSeparator2,
            this.aboutToolStripMenuItem});
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.helpToolStripMenuItem.Text = "&Help";
      // 
      // aHKSyntaxToolStripMenuItem
      // 
      this.aHKSyntaxToolStripMenuItem.Name = "aHKSyntaxToolStripMenuItem";
      this.aHKSyntaxToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.aHKSyntaxToolStripMenuItem.Text = "&AHK Tutorial";
      this.aHKSyntaxToolStripMenuItem.Click += new System.EventHandler(this.aHKSyntaxToolStripMenuItem_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.aboutToolStripMenuItem.Text = "A&bout";
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
      // 
      // restartCMDbtn
      // 
      this.restartCMDbtn.Location = new System.Drawing.Point(12, 80);
      this.restartCMDbtn.Name = "restartCMDbtn";
      this.restartCMDbtn.Size = new System.Drawing.Size(203, 23);
      this.restartCMDbtn.TabIndex = 6;
      this.restartCMDbtn.Text = "Restart Command";
      this.restartCMDbtn.UseVisualStyleBackColor = true;
      this.restartCMDbtn.Click += new System.EventHandler(this.restartClick);
      // 
      // editBtn
      // 
      this.editBtn.Location = new System.Drawing.Point(12, 109);
      this.editBtn.Name = "editBtn";
      this.editBtn.Size = new System.Drawing.Size(203, 23);
      this.editBtn.TabIndex = 7;
      this.editBtn.Text = "Edit Macro";
      this.editBtn.UseVisualStyleBackColor = true;
      this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
      // 
      // toolsToolStripMenuItem
      // 
      this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.streamerBotCMDGeneratorToolStripMenuItem});
      this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
      this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
      this.toolsToolStripMenuItem.Text = "&Tools";
      // 
      // streamerBotCMDGeneratorToolStripMenuItem
      // 
      this.streamerBotCMDGeneratorToolStripMenuItem.Name = "streamerBotCMDGeneratorToolStripMenuItem";
      this.streamerBotCMDGeneratorToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
      this.streamerBotCMDGeneratorToolStripMenuItem.Text = "Streamer.Bot CMD Generator";
      this.streamerBotCMDGeneratorToolStripMenuItem.Click += new System.EventHandler(this.streamerBotCMDGeneratorToolStripMenuItem_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(227, 140);
      this.Controls.Add(this.editBtn);
      this.Controls.Add(this.restartCMDbtn);
      this.Controls.Add(this.menuStrip1);
      this.Controls.Add(this.runBtn);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.MainMenuStrip = this.menuStrip1;
      this.MaximizeBox = false;
      this.Name = "Form1";
      this.Text = "intercept";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.Resize += new System.EventHandler(this.Form1_Resize);
      this.contextMenuStrip1.ResumeLayout(false);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem editMacroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aHKSyntaxToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.Button restartCMDbtn;
    private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editMacroToolStripMenuItem1;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.Button editBtn;
    private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem streamerBotCMDGeneratorToolStripMenuItem;
  }
}

