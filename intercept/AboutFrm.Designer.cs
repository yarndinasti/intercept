namespace interceptGUI
{
    partial class AboutFrm
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
      this.label1 = new System.Windows.Forms.Label();
      this.versionLbl = new System.Windows.Forms.Label();
      this.AHKLicenceBtn = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(75, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(149, 37);
      this.label1.TabIndex = 0;
      this.label1.Text = "Intercept";
      // 
      // versionLbl
      // 
      this.versionLbl.AutoSize = true;
      this.versionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.versionLbl.Location = new System.Drawing.Point(121, 46);
      this.versionLbl.Name = "versionLbl";
      this.versionLbl.Size = new System.Drawing.Size(57, 20);
      this.versionLbl.TabIndex = 1;
      this.versionLbl.Text = "label2";
      // 
      // AHKLicenceBtn
      // 
      this.AHKLicenceBtn.Location = new System.Drawing.Point(12, 91);
      this.AHKLicenceBtn.Name = "AHKLicenceBtn";
      this.AHKLicenceBtn.Size = new System.Drawing.Size(126, 23);
      this.AHKLicenceBtn.TabIndex = 2;
      this.AHKLicenceBtn.Text = "AutoHotKey Licence";
      this.AHKLicenceBtn.UseVisualStyleBackColor = true;
      this.AHKLicenceBtn.Click += new System.EventHandler(this.AHKLicenceBtn_Click);
      // 
      // AboutFrm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(298, 126);
      this.Controls.Add(this.AHKLicenceBtn);
      this.Controls.Add(this.versionLbl);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "AboutFrm";
      this.Text = "About";
      this.Load += new System.EventHandler(this.AboutFrm_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label versionLbl;
    private System.Windows.Forms.Button AHKLicenceBtn;
  }
}