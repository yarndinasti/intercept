using System;
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
            SelectQuery Sq = new SelectQuery("Win32_Keyboard");
            ManagementObjectSearcher objOSDetails = new ManagementObjectSearcher(Sq);
            ManagementObjectCollection osDetailsCollection = objOSDetails.Get();

            foreach (ManagementObject mo in osDetailsCollection)
            {
                //cbKeys is a combo box that lists all connected keyboards
                listBox1.Items.Add((string)mo["PNPDeviceID"]);
            }
        }
    }
}
