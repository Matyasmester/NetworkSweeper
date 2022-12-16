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
using System.Threading;

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

            ScanListAsync(allIPS);
        }

        private async void ScanListAsync(List<IPAddress> ips)
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
                    return "Port " + port + " OPEN at address " + IP.ToString() + "\n";
                }
                catch
                {
                    // port is closed, but we do not write it out 
                }
            }

            return null;
        }

        private List<PortRange> ChunkRangeBy(int min, int max, int chunkSize)
        {
            int previous = min;

            List<PortRange> ranges = new List<PortRange>();

            for(int i = min; i < max; i++)
            {
                if (i % chunkSize == 0) 
                {
                    ranges.Add(new PortRange(previous, i));
                    previous = i;
                }
            }

            return ranges;
        }

        private async Task<string> ScanPortRange(int min, int max, IPAddress IP)
        {

            // TODO: asyncokat visszarakni
            string retval = string.Empty;

            List<Task> allTasks = new List<Task>();

            List<PortRange> chunks = ChunkRangeBy(min, max, 3);

            foreach (PortRange range in chunks)
            {
                Task t = Task.Run(async () => {
                    
                    Thread.CurrentThread.IsBackground = true;

                    for (int port = range.Min; port < range.Max; port++)
                    {
                        string scanResult = await TryConnectPort(IP, port);

                        if (scanResult == null) continue;

                        retval += scanResult;
                    }
                });

                allTasks.Add(t);
            }

            Task.WaitAll(allTasks.ToArray());

            return retval;
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

            IPAddress selectedIP = currentAddresses[IPBox.SelectedIndex];

            string toShow = await ScanPortRange(min, max, selectedIP);
            
            if(toShow == string.Empty)
            {
                MessageBox.Show("No open ports found on this device.");
                return;
            }

            MessageBox.Show(toShow);
        }
    }
}
