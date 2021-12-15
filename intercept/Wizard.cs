using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace interceptGUI
{
    public partial class Wizard : Form
    {
        string programData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) +
                           @"\intercept\";

        ConfigSettings.Settings settings;
        bool check = false;
        private int WM_QUERYENDSESSION = 0x11;
        private bool systemShutdown = false;
        string codeEditor;
        private bool setup = false;

        public Wizard()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg.Equals(WM_QUERYENDSESSION))
                systemShutdown = true;

            // If this is WM_QUERYENDSESSION, the closing event should be fired in the base WndProc
            base.WndProc(ref m);
        }

        private void Wizard_Load(object sender, EventArgs e)
        {
            string Interception = Environment.ExpandEnvironmentVariables(@"%windir%\Sysnative\" +
                @"\drivers\keyboard.sys");

            IntInstall.Enabled = !File.Exists(Interception);
            InterceptionInstalled.Checked = Config.hasInt;

            settings = new ConfigSettings.Settings();

            // Code editor
            Dictionary<string, string> comboSource = new Dictionary<string, string>();

            comboSource.Add("notepad.exe", "Notepad");
            string pathKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            string path64Key = @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
            string pathUserKey = @"Software\Microsoft\Windows\CurrentVersion\Uninstall";

            RegistryKey HKLM64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey HKCU64 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
            bool is64 = Environment.Is64BitOperatingSystem;

            using (RegistryKey listApp = (is64) ? HKLM64.OpenSubKey(pathKey) :
                                            Registry.LocalMachine.OpenSubKey(pathKey))
            using (RegistryKey listUserApp = (is64) ? HKCU64.OpenSubKey(pathUserKey) :
                                            Registry.CurrentUser.OpenSubKey(pathUserKey))
            using (RegistryKey list64App = Registry.LocalMachine.OpenSubKey(path64Key))
            {
                StringCollection apps = new StringCollection();
                apps.AddRange(listApp.GetSubKeyNames());
                apps.AddRange(listUserApp.GetSubKeyNames());
                if (list64App != null) apps.AddRange(list64App.GetSubKeyNames());

                foreach (String app in apps)
                {
                    RegistryKey getApp = (listApp.OpenSubKey(app) != null) ?
                        listApp.OpenSubKey(app) : listUserApp.OpenSubKey(app);

                    if (is64)
                        getApp = (list64App.OpenSubKey(app) != null)
                            ? list64App.OpenSubKey(app) : getApp;


                    string displayName = (string)getApp.GetValue("DisplayName");
                    string displayIcon = (string)getApp.GetValue("DisplayIcon");

                    if (displayName != null)
                    {
                        if (displayName.ToLower().Contains("autohotkey"))
                            AHKinstalled.Checked = true;

                        if (Config.codeEditor.Any(displayName.Contains))
                            comboSource.Add((displayName == "Atom" ) ? displayIcon.Replace("app.ico", "atom.exe") : displayIcon, displayName);
                    }
                }
            }
            comboSource.Add("", "Custom");

            CodeCmb.DataSource = new BindingSource(comboSource, null);
            CodeCmb.DisplayMember = "Value";
            CodeCmb.ValueMember = "Key";

            if (File.Exists(programData + "settings.json"))
            {
                string jsonSettings = File.ReadAllText(programData + "settings.json");
                settings = JsonConvert.DeserializeObject<ConfigSettings.Settings>(jsonSettings);

                HIDtxt.Text = settings.keyboard;
                CodeCmb.SelectedValue = settings.code_editor;

                if (CodeCmb.SelectedItem == null)
                {
                    CodeCmb.SelectedValue = "";
                    codeEditor = settings.code_editor;
                }
            }


            if (AHKinstalled.Checked && InterceptionInstalled.Checked && !File.Exists(programData + "settings.json"))
            {
                HIDbtn.Enabled = true;
                HIDtxt.Enabled = true;
                CodeCmb.Enabled = true;
            }

            setup = true;
        }

        private void IntInstall_Click(object sender, EventArgs e)
        {
            try
            {
                Process process = new Process();

                // Stop the process from opening a new window
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                // Setup executable and parameters
                process.StartInfo.FileName = @"install-interception.exe";
                process.StartInfo.Arguments = "/install";

                if (Environment.OSVersion.Version.Major >= 6)
                    process.StartInfo.Verb = "runas";

                // Go
                process.Start();

                while (!process.StandardOutput.EndOfStream)
                {
                    string line = process.StandardOutput.ReadLine();

                    if (line == "Interception successfully installed. You must reboot for it to take effect.")
                        MessageBox.Show(line, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (line == "" || line == "Copyright (C) 2008-2018 Francisco Lopes da Silva" ||
                        line == "Interception command line installation tool")
                    { }
                    else
                        throw new Exception(line);
                }
                IntInstall.Enabled = false;
                RestartLbl.Visible = true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Wizard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (systemShutdown || check) return;

            DialogResult result = MessageBox.Show("The installation has not been completed,\nthe application will be closed. Are you sure?", "Continue",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                check = true;
                Application.Exit();
            }

            e.Cancel = result == DialogResult.No;
        }

        private void HIDbtn_Click(object sender, EventArgs e)
        {
            HIDlbl.Visible = true;
            Process process = new Process();

            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = @"intercept_cmd.exe";
            process.StartInfo.Arguments = "/add";

            // Go
            process.Start();
            process.WaitForExit();
            while (!process.StandardOutput.EndOfStream)
            {
                string line = process.StandardOutput.ReadLine();

                if (line == "Copied")
                    HIDtxt.Text = Clipboard.GetText();
            }
            HIDlbl.Visible = false;
        }

        private void CodeCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (setup)
            {
                string key = ((KeyValuePair<string, string>)CodeCmb.SelectedItem).Key;

                //Make OFD when selected custom
                OpenFileDialog open = new OpenFileDialog();
                open.Title = "Get code editor here";
                open.Filter = "Exe file|*.exe";

                if (key == "")
                {
                    if (open.ShowDialog() == DialogResult.OK)
                        codeEditor = open.FileName;
                    else
                        CodeCmb.SelectedIndex = 0;
                }
            }
        }

        private void HIDtxt_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^HID\\VID_[A-Z0-9]{4}&PID_[A-Z0-9]{4}&REV_[0-9]{4}&MI_[0-9]{2}$");
            Match match = regex.Match(HIDtxt.Text);

            saveBtn.Enabled = match.Success;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!File.Exists(programData + "settings.json"))
            {
                string key = ((KeyValuePair<string, string>)CodeCmb.SelectedItem).Key;

                settings.keyboard = HIDtxt.Text;
                settings.code_editor = (key != "") ? key : codeEditor;

                string jsonSettings = JsonConvert.SerializeObject(settings);
                File.WriteAllText(programData + "settings.json", jsonSettings);

                check = true;

                string files = Config.KeyMap().Replace("{MyKeyboards}", HIDtxt.Text);
                File.WriteAllText(programData + "keyremap.ini", files);
            }

            Close();
        }
    }
}
