﻿using IWshRuntimeLibrary;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace interceptGUI
{
    public partial class Form1 : Form
    {
        bool active = false;
        StreamReader iniFile, txtFile;
        private FileSystemWatcher _watcher;

        string dataMacro = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                @"\intercept\";
        string ShortcutPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), Application.ProductName) +
                ".lnk";

        Process AHK, interceptCMD;
        int AHKid;

        public Form1()
        {
            InitializeComponent();

            _watcher = new FileSystemWatcher();
            _watcher.SynchronizingObject = this;
            _watcher.Path = dataMacro;
            _watcher.EnableRaisingEvents = true;
            _watcher.NotifyFilter = NotifyFilters.LastWrite;

            _watcher.Filter = "keyboard.ahk";

            _watcher.Changed += new FileSystemEventHandler(FileChanged);
            _watcher.Deleted += new FileSystemEventHandler(FileDeleted);
            _watcher.Renamed += new RenamedEventHandler(FileRenamed);
        }

        private void FileRenamed(object sender, RenamedEventArgs e)
        {
            System.IO.File.WriteAllText(dataMacro + "keyboard.ahk", keyremap.AHK());
        }

        private void FileDeleted(object sender, FileSystemEventArgs e)
        {
            System.IO.File.WriteAllText(dataMacro + "keyboard.ahk", keyremap.AHK());
        }

        private void FileChanged(object sender, FileSystemEventArgs e)
        {
            if (active)
            {
                Thread.Sleep(800);
                AHK.Start();
                AHKid = AHK.Id;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            active = !active;

            if (active)
            {
                runBtn.Enabled = false;
                runToolStripMenuItem.Enabled = false;
                Thread.Sleep(1000);
                runBtn.Text = "Stop";
                runToolStripMenuItem.Text = "&Stop";
                runBtn.Enabled = true;
                runToolStripMenuItem.Enabled = true;

                startMacro();
            }
            else
            {
                runBtn.Enabled = false;
                runToolStripMenuItem.Enabled = false;
                Thread.Sleep(1000);
                runBtn.Text = "Run";
                runToolStripMenuItem.Text = "&Run";
                runBtn.Enabled = true;
                runToolStripMenuItem.Enabled = true;

                stopMacro();
            }
        }

        private void startMacro()
        {
            iniFile = new StreamReader(dataMacro + "keyremap.ini");
            txtFile = new StreamReader(dataMacro + "keyboardHID.txt");

            // Create incercept cmd
            interceptCMD = new Process();

            // Stop the process from opening a new window
            interceptCMD.StartInfo.RedirectStandardOutput = true;
            interceptCMD.StartInfo.UseShellExecute = false;
            interceptCMD.StartInfo.CreateNoWindow = true;

            // Setup executable and parameters
            interceptCMD.StartInfo.FileName = @"intercept_cmd.exe";
            interceptCMD.StartInfo.Arguments = "/apply /ini " + dataMacro + "keyremap.ini";

            // Create keyboard.ahk
            AHK = new Process();
            AHK.StartInfo.FileName = dataMacro + "keyboard.ahk";

            try
            {
                interceptCMD.Start();

                bool isRunning = !interceptCMD.WaitForExit(1500);

                if (!isRunning)
                    throw new Exception("Interception not installed correctly,\ntry to reboot and install again");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                runBtn.Text = "Run";
                runToolStripMenuItem.Text = "&Run";
                active = false;

                return;
            }

            AHK.Start();
            AHKid = AHK.Id;
        }

        private void stopMacro()
        {
            Process ahkProcess = Process.GetProcessById(AHKid);
            interceptCMD.Kill();
            ahkProcess.Kill();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!active) return;

            DialogResult result = MessageBox.Show("The macro will be dismissed as this app exit.\nAre you sure?", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes) stopMacro();
            else e.Cancel = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int intOpen = 0;
            Process[] GetPArry = Process.GetProcesses();
            foreach (Process testProcess in GetPArry)
            {
                string ProcessName = testProcess.ProcessName;

                ProcessName = ProcessName.ToLower();
                if (ProcessName.CompareTo("interceptgui") == 0)
                    intOpen++; //Application.Exit();
            }

            if (intOpen > 1)
                Application.Exit();

            Process[] get = Process.GetProcesses();
            foreach (Process testProcess in get)
            {
                string ProcessName = testProcess.ProcessName;

                ProcessName = ProcessName.ToLower();
                if (ProcessName.CompareTo("intercept_cmd") == 0)
                    testProcess.Kill();
            }


            string[] args = Environment.GetCommandLineArgs();
            foreach (string arg in args)
            {
                if (arg == "/play")
                {
                    string Interception = Environment.ExpandEnvironmentVariables(@"%windir%\Sysnative\" + @"\drivers\keyboard.sys");
                    if (!System.IO.File.Exists(Interception))
                    {
                        MessageBox.Show("Application cannot start because Interception not installed",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
            }

            if (!Directory.Exists(dataMacro))
                Directory.CreateDirectory(dataMacro);

            new Wizard().ShowDialog();
            if (!System.IO.File.Exists(dataMacro + "keyboardHID.txt"))
                new KeySetFrm().ShowDialog();

            if (!System.IO.File.Exists(dataMacro + "keyboard.ahk"))
                System.IO.File.WriteAllText(dataMacro + "keyboard.ahk", keyremap.AHK());

            checkStartup.Checked = System.IO.File.Exists(ShortcutPath);


            foreach (string arg in args)
            {
                if (arg == "/tray")
                {
                    ShowInTaskbar = false;
                    notifyIcon.Visible = true;
                    Hide();
                }

                if (arg == "/play")
                {
                    active = true;
                    runBtn.Text = "Stop";
                    runToolStripMenuItem.Text = "&Stop";

                    startMacro();
                }
            }
        }

        private void ahkEditBtn_Click(object sender, EventArgs e)
        {
            string uninstall_user = @"Software\Microsoft\Windows\CurrentVersion\Uninstall";
            bool VscodeUser = KeyExists(Registry.CurrentUser.OpenSubKey(uninstall_user), "{771FD6B0-FA20-440A-A002-3B3BAC16DC50}_is1");

            if (VscodeUser)
                Process.Start(@"C:\Users\Administrator\AppData\Local\Programs\Microsoft VS Code\Code.exe", dataMacro + "keyboard.ahk");
            else
                Process.Start("Notepad.exe", dataMacro + "keyboard.ahk");
        }

        private bool KeyExists(RegistryKey baseKey, string subKeyName)
        {
            RegistryKey ret = baseKey.OpenSubKey(subKeyName);

            return ret != null;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) =>
            Application.Exit();


        private void runToolStripMenuItem_Click(object sender, EventArgs e) =>
            button1_Click(sender, e);

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowInTaskbar = true;
            notifyIcon.Visible = false;
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //base.OnResize(e);

            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                notifyIcon.Visible = true;
                Hide();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.F5) unsIntBtn_Click(sender, e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkStartup.Checked)
                System.IO.File.Delete(ShortcutPath);
            else
            {
                object shDesktop = "Desktop";
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(ShortcutPath);
                shortcut.TargetPath = Environment.CurrentDirectory + @"\interceptGUI.exe";
                shortcut.WorkingDirectory = Application.StartupPath;
                shortcut.Arguments = "/tray /play";
                shortcut.Description = "";
                shortcut.Save();
            }
        }

        private void unsIntBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("If Interception uninstalled, the application will be closed,\nare you sure?", "Really???",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
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
                    process.StartInfo.Arguments = "/uninstall";

                    if (Environment.OSVersion.Version.Major >= 6)
                        process.StartInfo.Verb = "runas";

                    // Go
                    process.Start();

                    while (!process.StandardOutput.EndOfStream)
                    {
                        string line = process.StandardOutput.ReadLine();

                        if (line == "Interception uninstalled. You must reboot for this to take effect.")
                            MessageBox.Show(line, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (line == "" || line == "Copyright (C) 2008-2018 Francisco Lopes da Silva" ||
                            line == "Interception command line installation tool")
                        { }
                        else
                            throw new Exception("Interception already uninstalled, please reboot");

                    }
                    Application.Exit();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KeySetFrm keyfrm = new KeySetFrm();
            keyfrm.edit = true;
            keyfrm.ShowDialog();
        }
    }
}
