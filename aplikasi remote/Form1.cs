using System;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.IO;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;

namespace aplikasi_remote
{
    public partial class Form1 : Form
    {
        //Form Styles Variables
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        ToolTip tooltip = new ToolTip();

        public Form1()
        {
            InitializeComponent();
            //membuat tooltip pada element
            tooltip.SetToolTip(exit, "Exit");
            tooltip.SetToolTip(minimize, "Minimize");
            tooltip.SetToolTip(btnConnect, "Lakukan Koneksi");
            tooltip.SetToolTip(listen, "Menjadi Server");
        }

        //membuat form bisa didrag / draggable
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        //membuat drop shadow pada form
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //<MAIN>
        //Variables Untuk Main program
        ScreenCapture obj;
        TcpChannel chan;
        string URI;
        static byte[] buffer { get; set; }
        System.Drawing.Color defaultcolor;
        Form3 chat;

        private void start()
        {
            try
            {
                URI = "Tcp://" + txtIp.Text + ":6600/MyCaptureScreenServer";
                chan = new TcpChannel();
                ChannelServices.RegisterChannel(chan,false);
                obj = (ScreenCapture)Activator.GetObject(typeof(ScreenCapture), URI);

                Form2 layar = new Form2(true, obj, URI, chan);
                layar.Show();
                Form3 chat = new Form3("Client", true, obj, URI, chan);
                chat.Show();
                layar.Closed += delegate
                {
                    this.WindowState = FormWindowState.Normal;
                    chat.Close();
                };  

                this.WindowState = FormWindowState.Minimized;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error : "+e.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            start();
        }

        private void listen_Click(object sender, EventArgs e)
        {
            if (listen.Text == "listen")
            {
                string ipget = "";
                foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                    {
                        foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                if(!ip.Address.ToString().StartsWith("169"))
                                    ipget = ip.Address.ToString();
                            }
                        }
                    }
                }
                //if(ipget == "")
                    ipget = "127.0.0.1";
                URI = "Tcp://" + ipget + ":6600/MyCaptureScreenServer";
                chan = new TcpChannel(6600);
                ChannelServices.RegisterChannel(chan, false);
                RemotingConfiguration.RegisterWellKnownServiceType(
                    Type.GetType("ScreenCapture, ScreenCapture"),
                    "MyCaptureScreenServer",
                    WellKnownObjectMode.Singleton);
                obj = (ScreenCapture)Activator.GetObject(typeof(ScreenCapture), URI);
                chat = new Form3(ipget, true, obj, URI, chan);
                chat.Show();
                chat.Closed += delegate
                {
                    this.WindowState = FormWindowState.Normal;
                };  
                btnConnect.Enabled = false;
                defaultcolor = btnConnect.BackColor;
                btnConnect.BackColor = System.Drawing.Color.Gray;
                listen.Text = "Disconnect";
                timer1.Enabled = true;
                timer1.Start();
            }
            else
            {
                btnConnect.Enabled = true;
                btnConnect.BackColor = defaultcolor;
                timer1.Stop();
                timer1.Enabled = false;
                obj.con_stat = false;
                try
                {
                    ChannelServices.UnregisterChannel(chan);//to Un Register chan Channel
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error : " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                chat.Close();
                System.Threading.Thread.Sleep(1000);
                listen.Text = "listen";
            }
        }

        public static void sound()
        {
            string rootLocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fullPathToSound = Path.Combine(rootLocation, @"assets\sound.wav");
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(fullPathToSound);
            player.Play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(obj.sendMessage == true)
            {
                MessageBox.Show("Selamat Pagi Dunia", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (obj.soundStat == true)
            {
                sound();
            }
        }
    }
}
