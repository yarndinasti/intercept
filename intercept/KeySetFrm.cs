
using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace interceptGUI
{
    public partial class KeySetFrm : Form
    {
        bool check = false;
        public bool edit = false;

        public KeySetFrm()
        {
            InitializeComponent();
        }

        

        private void KeySetFrm_Load(object sender, EventArgs e)
        {
            saveBtn.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dataMacro = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                @"\intercept\";

            string files = Config.KeyMap().Replace("{MyKeyboards}", keyKeyboard.Text);
            File.WriteAllText(dataMacro + "keyremap.ini", files);

            File.WriteAllText(dataMacro + "keyboardHID.txt", keyKeyboard.Text);

            check = true;
            Close();
        }

        private void keyKeyboard_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^HID\\VID_[A-Z0-9]{4}&PID_[A-Z0-9]{4}&REV_[0-9]{4}&MI_[0-9]{2}$");
            Match match = regex.Match(keyKeyboard.Text);

            saveBtn.Enabled = match.Success;
        }

        private void getKeyDevice_Click(object sender, EventArgs e)
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
                    keyKeyboard.Text = Clipboard.GetText();
            }
        }

        private void KeySetFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (check || edit) return;

            DialogResult result = MessageBox.Show("The installation has not been completed,\nthe application will be closed. Are you sure?", "Continue",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                check = true;
                Application.Exit();
            }

            e.Cancel = result == DialogResult.No;
        }
    }
}
