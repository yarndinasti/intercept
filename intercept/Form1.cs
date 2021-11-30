using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace interceptGUI
{
    public partial class Form1 : Form
    {
        StreamReader iniFile, jsonFile;
        private FileSystemWatcher _watcher;
        bool active = false;

        string dataMacro = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                @"\intercept\";

        Process AHK, interceptCMD;
        int AHKid;

        private int WM_QUERYENDSESSION = 0x11;
        private bool systemShutdown = false;

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
            File.WriteAllText(dataMacro + "keyboard.ahk", Config.AHK());
        }

        private void FileDeleted(object sender, FileSystemEventArgs e)
        {
            File.WriteAllText(dataMacro + "keyboard.ahk", Config.AHK());
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

        protected override void WndProc(ref Message m)
        {
            if (m.Msg.Equals(WM_QUERYENDSESSION))
                systemShutdown = true;

            // If this is WM_QUERYENDSESSION, the closing event should be fired in the base WndProc
            base.WndProc(ref m);
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
            jsonFile = new StreamReader(dataMacro + "settings.json");

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

            iniFile.Close();
            jsonFile.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (systemShutdown)
            {
                if (active) stopMacro();
                return;
            }

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
                    if (!File.Exists(Interception))
                    {
                        MessageBox.Show("Application cannot start because Interception not installed",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
            }

            if (!Directory.Exists(dataMacro))
                Directory.CreateDirectory(dataMacro);

            bool hasInt = CheckInterception();
            bool hasConfig = File.Exists(dataMacro + "settings.json");

            if (!hasInt || !hasConfig)
                new Wizard().ShowDialog();

            if (!File.Exists(dataMacro + "keyboard.ahk"))
                File.WriteAllText(dataMacro + "keyboard.ahk", Config.AHK());

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

        private bool CheckInterception()
        {
            bool result = false;
            Process process = new Process();

            // Stop the process from opening a new window
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            // Setup executable and parameters
            process.StartInfo.FileName = @"intercept_cmd.exe";
            process.StartInfo.Arguments = "/check";

            // Go
            process.Start();

            while (!process.StandardOutput.EndOfStream)
            {
                string line = process.StandardOutput.ReadLine();

                if (line == "interception installed")
                    result = true;
            }

            Config.hasInt = result;
            return result;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!active) return;

            DialogResult result = MessageBox.Show("The macro will be dismissed as this app exit.\nAre you sure?", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes) {
                active = false;
                stopMacro();
                Application.Exit();
            }
            
        }


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

        private void aHKSyntaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string osNameAndVersion = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            int build_ver = Int32.Parse(osNameAndVersion.Split('.').Last());

            if (build_ver >= 22000)
            {
                MessageBox.Show("Since Windows 11, the default browser system is changed," +
                    " we will bring the default OS in the future." +
                    " For now, click OK and paste it in your favorite browser", "Browser Default", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Clipboard.SetText("http://xahlee.info/mswin/autohotkey.html");
            } else {
                Process.Start("http://xahlee.info/mswin/autohotkey.html");
            }
            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) =>
            new AboutFrm().ShowDialog();


        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (active)
            {
                MessageBox.Show("Settings cannot be used while the system is running", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            new SettingsFrm().ShowDialog();
        }

        private void editMacroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigSettings.Settings settings = new ConfigSettings.Settings();
            string jsonSettings = File.ReadAllText(dataMacro + "settings.json");
            settings = JsonConvert.DeserializeObject<ConfigSettings.Settings>(jsonSettings);

            Process.Start(settings.code_editor, dataMacro + "keyboard.ahk");
        }
    }
}
