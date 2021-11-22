using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using IWshRuntimeLibrary;

namespace intercept
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
        string AHK = @"#NoEnv ; Recommended for performance and compatibility with future AutoHotkey releases.
; #Warn  ; Enable warnings to assist with detecting common errors.
SendMode Input ; Recommended for new scripts due to its superior speed and reliability.
SetWorkingDir %A_ScriptDir% ; Ensures a consistent starting directory.

#SingleInstance force
#if (getKeyState(""F23"", ""P""))
  F23::return
; Code here!!!

; End Code
#if
  ;Done with F23";

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
            System.IO.File.WriteAllText(dataMacro + "keyboard.ahk", AHK);
        }

        private void FileDeleted(object sender, FileSystemEventArgs e)
        {
            System.IO.File.WriteAllText(dataMacro + "keyboard.ahk", AHK);
        }

        private void FileChanged(object sender, FileSystemEventArgs e)
        {
            if (active) Process.Start(dataMacro + "keyboard.ahk");
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
                editAhk.Start();
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
                editAhk.Stop();
            }
        }

        private void startMacro()
        {
            iniFile = new StreamReader(dataMacro + "keyremap.ini");
            txtFile = new StreamReader(dataMacro + "keyboardHID.txt");

            Process process = new Process();

            // Stop the process from opening a new window
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            // Setup executable and parameters
            process.StartInfo.FileName = @"intercept_cmd.exe";
            process.StartInfo.Arguments = "/apply /ini " + dataMacro + "keyremap.ini";

            // Go
            process.Start();
            Process.Start(dataMacro + "keyboard.ahk");
        }

        private void stopMacro()
        {
            Process[] GetPArry = Process.GetProcesses();
            foreach (Process testProcess in GetPArry)
            {
                string ProcessName = testProcess.ProcessName;

                ProcessName = ProcessName.ToLower();
                if (ProcessName.CompareTo("intercept_cmd") == 0)
                    testProcess.Kill();

                if (ProcessName.CompareTo("AutoHotKey") == 0)
                    testProcess.Kill();
            }
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
            if (!Directory.Exists(dataMacro))
                Directory.CreateDirectory(dataMacro);

            new Wizard().ShowDialog();
            if (!System.IO.File.Exists(dataMacro + "keyboardHID.txt"))
                new KeySetFrm().ShowDialog();

            if (!System.IO.File.Exists(dataMacro + "keyboard.ahk"))
                System.IO.File.WriteAllText(dataMacro + "keyboard.ahk", AHK);

            checkStartup.Checked = System.IO.File.Exists(ShortcutPath);

            string[] args = Environment.GetCommandLineArgs();

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
                    runBtn.Text = "Stop";
                    runToolStripMenuItem.Text = "&Stop";

                    startMacro();
                    editAhk.Start();
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

        private void editAhk_Tick(object sender, EventArgs e)
        {

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
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //base.OnResize(e);

            if (this.WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                notifyIcon.Visible = true;
                Hide();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.F5)
            {
                DialogResult result = MessageBox.Show("If the intercept, the application will be closed,\nare you sure?", "Really???",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    Process process = new Process();

                    // Stop the process from opening a new window
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;

                    // Setup executable and parameters
                    process.StartInfo.FileName = @"install-interception.exe";
                    process.StartInfo.Arguments = "/uninstall";

                    if (System.Environment.OSVersion.Version.Major >= 6)
                    {
                        process.StartInfo.Verb = "runas";
                    }

                    // Go
                    process.Start();
                    Application.Exit();
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkStartup.Checked)
                System.IO.File.Delete(ShortcutPath);
            else
            {
                object shDesktop = (object)"Desktop";
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(ShortcutPath);
                shortcut.Arguments = "/tray /play";
                shortcut.TargetPath = Environment.CurrentDirectory + @"\intercept.exe";
                shortcut.Save();
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
