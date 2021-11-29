using System;
using System.Diagnostics;
using System.Management;
using System.Windows.Forms;

namespace interceptGUI
{
    public partial class SettingsFrm : Form
    {
        public SettingsFrm()
        {
            InitializeComponent();
        }

        private void SettingsFrm_Load(object sender, EventArgs e)
        {
            
        }

        private void HIDbtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Press any key in 2nd keyboard in blank console window for get Keyboard HID",
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Process process = new Process();

            process.StartInfo.FileName = @"intercept_cmd.exe";
            process.StartInfo.Arguments = "/add";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;

            // Go
            process.Start();
            process.WaitForExit();
            while (!process.StandardOutput.EndOfStream)
            {
                string line = process.StandardOutput.ReadLine();

                if (line == "Copied")
                    HIDtxt.Text = Clipboard.GetText();
            }
        }
    }
}
