using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net.NetworkInformation;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Windows.Forms;
using System.Net;
using System.Threading.Tasks;

namespace NetworkScanner
{
    public partial class MainForm : Form
    {
        private bool IsUserElevated = false;
        public MainForm()
        {
            InitializeComponent();

            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);

                IsUserElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }

            if (IsUserElevated) AdminLabel.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void IPBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string MinIPText = IPFromBox.Text;
            string MaxIPText = IPToBox.Text;

            if (!AreAllValidTextInputs(MinIPText, MaxIPText))
            {
                MessageBox.Show("Please put in a valid IP Address!");
                return;
            }

            List<IPAddress> allIPS = GetAllIPSInRange(MinIPText, MaxIPText);

            ScanList(allIPS);
        }

        private async void ScanList(List<IPAddress> ips)
        {
            int nSuccesses = 0;

            var tasks = ips.Select(ip => new Ping().SendPingAsync(ip, 2000));

            var results = await Task.WhenAll(tasks);

            foreach(PingReply reply in results)
            {
                if (reply.Status == IPStatus.Success)
                {
                    IPBox.Items.Add(reply.Address.ToString());
                    nSuccesses++;
                }
            }

            MessageBox.Show("Scan completed, " + nSuccesses + " successful pings.");
        }

        private List<IPAddress> GetAllIPSInRange(string minText, string maxText)
        {
            List<IPAddress> ips = new List<IPAddress>();

            string IPTrimmed = minText.Remove(minText.LastIndexOf('.'));

            int min = GetIPEndValue(minText);
            int max = GetIPEndValue(maxText);

            if (min > max)
            {
                MessageBox.Show("Cannot start scan, start IP is bigger than end IP.");
                return null;
            }

            for (int i = min; i <= max; i++)
            {
                IPAddress ip = IPAddress.Parse(IPTrimmed + "." + i.ToString());

                ips.Add(ip);
            }

            return ips;
        }

        private bool AreAllValidTextInputs(params string[] inputs)
        {
            foreach(string input in inputs)
            {
                // The user has not entered anything
                if (string.IsNullOrWhiteSpace(input) || input.Equals(string.Empty)) return false;

                // The user supplied a seemingly incorrect IP address
                if (input.Split('.').Length != 4) return false;
            }

            return true;
        }

        private int GetIPEndValue(string s)
        {
            return Convert.ToInt32(s.Substring(s.LastIndexOf('.') + 1));
        }
    }
}
