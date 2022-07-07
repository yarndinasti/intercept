namespace interceptGUI
{
    partial class KeySetFrm
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
            this.keyKeyboard = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.getKeyDevice = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Press here for get Device HID";
            // 
            // keyKeyboard
            // 
            this.keyKeyboard.Location = new System.Drawing.Point(12, 29);
            this.keyKeyboard.Name = "keyKeyboard";
            this.keyKeyboard.Size = new System.Drawing.Size(245, 20);
            this.keyKeyboard.TabIndex = 3;
            this.keyKeyboard.TextChanged += new System.EventHandler(this.keyKeyboard_TextChanged);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(182, 55);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 4;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // getKeyDevice
            // 
            this.getKeyDevice.Location = new System.Drawing.Point(12, 55);
            this.getKeyDevice.Name = "getKeyDevice";
            this.getKeyDevice.Size = new System.Drawing.Size(96, 23);
            this.getKeyDevice.TabIndex = 5;
            this.getKeyDevice.Text = "Get Device HID";
            this.getKeyDevice.UseVisualStyleBackColor = true;
            this.getKeyDevice.Click += new System.EventHandler(this.getKeyDevice_Click);
            // 
            // KeySetFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 85);
            this.Controls.Add(this.getKeyDevice);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.keyKeyboard);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "KeySetFrm";
            this.Text = "Set Device HID";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KeySetFrm_FormClosing);
            this.Load += new System.EventHandler(this.KeySetFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox keyKeyboard;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button getKeyDevice;
    }
}