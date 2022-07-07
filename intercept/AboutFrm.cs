﻿using System;
using System.Deployment.Application;
using System.Reflection;
using System.Windows.Forms;

namespace interceptGUI
{
  public partial class AboutFrm : Form
  {
    public AboutFrm()
    {
      InitializeComponent();
    }

    private void AboutFrm_Load(object sender, EventArgs e)
    {
      versionLbl.Text = ApplicationDeployment.IsNetworkDeployed
         ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
         : Assembly.GetExecutingAssembly().GetName().Version.ToString();
    }

    private void AHKLicenceBtn_Click(object sender, EventArgs e)
    {
      // Open AHKLicense.txt
      System.Diagnostics.Process.Start(@"AHKLicense.txt");
    }
  }
}
