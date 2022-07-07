using IWshRuntimeLibrary;
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
  public partial class SettingsFrm : Form
  {
    bool save = true;
    bool setup;
    private int WM_QUERYENDSESSION = 0x11;
    private bool systemShutdown = false;
    ConfigSettings.Settings settings;
    string codeEditor;

    string ShortcutPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), Application.ProductName) +
           ".lnk";
    string programData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) +
    @"\intercept\";

    public SettingsFrm()
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

    private void SettingsFrm_Load(object sender, EventArgs e)
    {
      setup = false;
      saveBtn.Enabled = false;

      settings = new ConfigSettings.Settings();
      string jsonSettings = System.IO.File.ReadAllText(programData + "settings.json");
      settings = JsonConvert.DeserializeObject<ConfigSettings.Settings>(jsonSettings);

      Dictionary<string, string> comboSource = new Dictionary<string, string>();
      Dictionary<string, string> AHKvariant = new Dictionary<string, string>();

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

            if (Config.codeEditor.Any(displayName.Contains))
              comboSource.Add(displayIcon, displayName);
          }
        }
      }
      comboSource.Add("", "Custom");

      CodeCmb.DataSource = new BindingSource(comboSource, null);
      CodeCmb.DisplayMember = "Value";
      CodeCmb.ValueMember = "Key";

      // Add ahk variant list
      if (is64) AHKvariant.Add("U64", "64Bit Unicode");
      AHKvariant.Add("U32", "32Bit Unicode");
      AHKvariant.Add("A64", "64Bit ANSI");

      AHKcombo.DataSource = new BindingSource(AHKvariant, null);
      AHKcombo.DisplayMember = "Value";
      AHKcombo.ValueMember = "Key";

      HIDtxt.Text = settings.keyboard;
      AHKcombo.Text = settings.ahk_variant;

      if (CodeCmb.SelectedItem == null)
      {
        CodeCmb.SelectedValue = "";
        codeEditor = settings.code_editor;
      }
      else
      {
        CodeCmb.SelectedValue = settings.code_editor;
        codeEditor = null;
      }

      checkStartup.Checked = System.IO.File.Exists(ShortcutPath);
      setup = true;
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
          save = true;
          Application.Exit();
        }
        catch (Exception err)
        {
          MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void saveBtn_Click(object sender, EventArgs e)
    {
      string key = ((KeyValuePair<string, string>)CodeCmb.SelectedItem).Key;

      settings.keyboard = HIDtxt.Text;
      settings.code_editor = (key != "") ? key : codeEditor;
      settings.ahk_variant = ((KeyValuePair<string, string>)AHKcombo.SelectedItem).Key;

      string jsonSettings = JsonConvert.SerializeObject(settings);
      System.IO.File.WriteAllText(programData + "settings.json", jsonSettings);

      string files = Config.KeyMap().Replace("{MyKeyboards}", HIDtxt.Text);
      System.IO.File.WriteAllText(programData + "keyremap.ini", files);

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

      save = true;
      Close();
    }

    private void HIDtxt_TextChanged(object sender, EventArgs e)
    {
      if (setup)
        save = false;

      Regex regex = new Regex(@"^HID\\VID_[A-Z0-9]{4}&PID_[A-Z0-9]{4}&REV_[0-9]{4}&MI_[0-9]{2}$");
      Match match = regex.Match(HIDtxt.Text);

      saveBtn.Enabled = match.Success;
    }

    private void checkStartup_CheckedChanged(object sender, EventArgs e)
    {
      if (setup)
        save = false;
    }

    private void CodeCmb_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (setup)
      {
        save = false;
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

    private void SettingsFrm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (save || systemShutdown) return;

      DialogResult result = MessageBox.Show("Settings haven't been saved, do you want to save them before exiting?",
          "Save setting", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

      switch (result)
      {
        case DialogResult.Cancel:
          e.Cancel = true;
          break;
        case DialogResult.Yes:
          Regex regex = new Regex(@"^HID\\VID_[A-Z0-9]{4}&PID_[A-Z0-9]{4}&REV_[0-9]{4}&MI_[0-9]{2}$");
          Match match = regex.Match(HIDtxt.Text);
          if (!match.Success)
          {
            MessageBox.Show("Wrong HID keyboard format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Cancel = true;
          }
          else
          {
            saveBtn_Click(sender, e);
          }
          break;
        case DialogResult.No:
          save = false;
          break;
      }
    }
  }
}
