using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace interceptGUI
{
    public partial class Wizard : Form
    {
        bool check = false;
        public Wizard()
        {
            InitializeComponent();
        }

        private void Wizard_Load(object sender, EventArgs e)
        {
            string Interception = Environment.ExpandEnvironmentVariables(@"%windir%\Sysnative\" + 
                @"\drivers\keyboard.sys");
            RegistryKey HKLM64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            bool is64 = Environment.Is64BitOperatingSystem;

            string uninstall_locate = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            string uninstall_user = @"Software\Microsoft\Windows\CurrentVersion\Uninstall";
            bool AutoHotKey = KeyExists((is64) ? HKLM64.OpenSubKey(uninstall_locate) : 
                Registry.LocalMachine.OpenSubKey(uninstall_locate), "AutoHotkey");
            bool VscodeUser = KeyExists(Registry.CurrentUser.OpenSubKey(uninstall_user), 
                "{771FD6B0-FA20-440A-A002-3B3BAC16DC50}_is1");

            AHKinstalled.Checked = AutoHotKey;
            InterceptionInstalled.Checked = File.Exists(Interception);
            IntInstall.Enabled = !File.Exists(Interception);
            VSCodeInstalled.Checked = VscodeUser;

            if (AHKinstalled.Checked && InterceptionInstalled.Checked)
            {
                check = true;
                Close();
            }
        }

        private bool KeyExists(RegistryKey baseKey, string subKeyName)
        {
            RegistryKey ret = baseKey.OpenSubKey(subKeyName);

            return ret != null;
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

                if (System.Environment.OSVersion.Version.Major >= 6)
                {
                    process.StartInfo.Verb = "runas";
                }

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
            if (check) return;

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
