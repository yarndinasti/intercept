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
    string programData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) +
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
      iniFile = new StreamReader(programData + "keyremap.ini");
      jsonFile = new StreamReader(programData + "settings.json");

      // Create incercept cmd
      interceptCMD = new Process();

      // Stop the process from opening a new window
      interceptCMD.StartInfo.RedirectStandardOutput = true;
      interceptCMD.StartInfo.UseShellExecute = false;
      interceptCMD.StartInfo.CreateNoWindow = true;

      // Setup executable and parameters
      interceptCMD.StartInfo.FileName = @"intercept_cmd.exe";
      interceptCMD.StartInfo.Arguments = "/apply /ini " + programData + "keyremap.ini";

      // Enabled Restart buttons
      restartCMDbtn.Enabled = true;
      restartToolStripMenuItem.Enabled = true;

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

      startAHK();
    }

    private void startAHK()
    {
      var programPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
      var programDir = System.IO.Path.GetDirectoryName(programPath);

      ConfigSettings.Settings settings = new ConfigSettings.Settings();
      string jsonSettings = File.ReadAllText(programData + "settings.json");
      settings = JsonConvert.DeserializeObject<ConfigSettings.Settings>(jsonSettings);

      // Create keyboard.ahk
      AHK = new Process();

      // Dont show
      AHK.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
      AHK.StartInfo.CreateNoWindow = true;
      AHK.StartInfo.RedirectStandardOutput = true;
      AHK.StartInfo.UseShellExecute = false;

      AHK.StartInfo.FileName = programDir + @"\AutoHotkey" + settings.ahk_variant + ".exe";
      AHK.StartInfo.Arguments = dataMacro + "keyboard.ahk";

      AHK.Start();
      AHKid = AHK.Id;
    }

    private void stopMacro()
    {
      interceptCMD.Kill();
      stopAHK();

      restartCMDbtn.Enabled = false;
      restartToolStripMenuItem.Enabled = false;

      iniFile.Close();
      jsonFile.Close();
    }

    private void stopAHK()
    {
      try
      {
        Process ahkProcess = Process.GetProcessById(AHKid);
        ahkProcess.Kill();
      }
      catch (Exception)
      {
        MessageBox.Show("Cannot close, because not opened by this program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (!active || systemShutdown) return;

      DialogResult result = MessageBox.Show("The macro will be dismissed as this app exit.\nAre you sure?", "Warning",
          MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

      if (result == DialogResult.Yes) stopMacro();
      else e.Cancel = true;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      restartCMDbtn.Enabled = false;
      restartToolStripMenuItem.Enabled = false;

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

      if (!Directory.Exists(programData))
        Directory.CreateDirectory(programData);

      if (File.Exists(dataMacro + "settings.json"))
      {
        File.Copy(dataMacro + "settings.json", programData + "settings.json");
        File.Copy(dataMacro + "keyremap.ini", programData + "keyremap.ini");

        File.Delete(dataMacro + "settings.json");
        File.Delete(dataMacro + "keyremap.ini");
      }

      bool hasInt = CheckInterception();
      bool hasConfig = File.Exists(programData + "settings.json");

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

      if (result == DialogResult.Yes)
      {
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
      // notifyIcon.Visible = false;
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

      Process.Start("http://xahlee.info/mswin/autohotkey.html");

    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e) =>
        new AboutFrm().ShowDialog();

    private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
    {

    }

    private void editBtn_Click(object sender, EventArgs e)
    {
      ConfigSettings.Settings settings = new ConfigSettings.Settings();
      string jsonSettings = File.ReadAllText(programData + "settings.json");
      settings = JsonConvert.DeserializeObject<ConfigSettings.Settings>(jsonSettings);

      Process.Start(settings.code_editor, dataMacro + "keyboard.ahk");
    }

    private void restartClick(object sender, EventArgs e)
    {
      runBtn.Enabled = false;
      runToolStripMenuItem.Enabled = false;
      restartCMDbtn.Enabled = false;
      restartToolStripMenuItem.Enabled = false;
      stopAHK();
      Thread.Sleep(1000);
      startAHK();
      runBtn.Enabled = true;
      runToolStripMenuItem.Enabled = true;
      restartCMDbtn.Enabled = true;
      restartToolStripMenuItem.Enabled = true;
    }

    private void streamerBotCMDGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
    {
      MessageBox.Show("Coming Soon", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

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
      string jsonSettings = File.ReadAllText(programData + "settings.json");
      settings = JsonConvert.DeserializeObject<ConfigSettings.Settings>(jsonSettings);

      Process.Start(settings.code_editor, dataMacro + "keyboard.ahk");
    }
  }
}
