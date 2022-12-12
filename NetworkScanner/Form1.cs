using System;
using System.Collections.Generic;
using System.Net.Sockets;
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

        private List<IPAddress> currentAddresses = new List<IPAddress>();

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
            if (IPBox.SelectedItem != null) PortButton.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPBox.Items.Clear();

            string MinIPText = IPFromBox.Text;
            string MaxIPText = IPToBox.Text;

            if (!AreAllValidTextInputs(MinIPText, MaxIPText))
            {
                MessageBox.Show("Please put in a valid IP Address!");
                return;
            }

            List<IPAddress> allIPS = GetAllIPSInRange(MinIPText, MaxIPText);

            if (allIPS == null) return;

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
                    IPBox.Items.Add(reply.Address.ToString() + " in " + reply.RoundtripTime + "ms");
                    currentAddresses.Add(reply.Address);

                    nSuccesses++;
                }
            }

            MessageBox.Show("Scan completed, " + nSuccesses + " successful pings.");
        }

        private List<IPAddress> GetAllIPSInRange(string minText, string maxText)
        {
            List<IPAddress> ips = new List<IPAddress>();

            string IPMinTrimmed = minText.Remove(minText.LastIndexOf('.'));
            string IPMaxTrimmed = maxText.Remove(maxText.LastIndexOf('.'));

            if (!IPMinTrimmed.Equals(IPMaxTrimmed))
            {
                MessageBox.Show("Cannot start scan, two different subnets have been entered.");
                return null;
            }

            int min = GetIPEndValue(minText);
            int max = GetIPEndValue(maxText);

            if (min > max)
            {
                MessageBox.Show("Cannot start scan, start IP is bigger than end IP.");
                return null;
            }

            for (int i = min; i <= max; i++)
            {
                IPAddress ip = IPAddress.Parse(IPMinTrimmed + "." + i.ToString());

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

        private async Task<string> TryConnectPort(IPAddress IP, int port)
        {
            using (TcpClient scanner = new TcpClient())
            {
                try
                {
                    await scanner.ConnectAsync(IP, port);
                    return port + " OPEN at address " + IP.ToString() + "\n";
                }
                catch
                {
                    // port is closed, but we do not write it out 
                }
            }

            return null;
        }

        private async void PortButton_Click(object sender, EventArgs e)
        {
            int min = (int)MinPortUpDown.Value;
            int max = (int)MaxPortUpDown.Value;

            if(min > max)
            {
                MessageBox.Show("Cannot start port scan, minimum port is bigger than maximum port.");
                return;
            }

            string toShow = string.Empty;

            IPAddress selectedIP = currentAddresses[IPBox.SelectedIndex];

            string IPString = selectedIP.ToString();
            
            for(int port = min; port < max; port++)
            {
                string scanResult = await TryConnectPort(selectedIP, port);

                if (scanResult == null) continue;

                toShow += scanResult;
            }
            
            if(toShow == string.Empty)
            {
                MessageBox.Show("No open ports found on this device.");
                return;
            }

            MessageBox.Show(toShow);
        }
    }
}
