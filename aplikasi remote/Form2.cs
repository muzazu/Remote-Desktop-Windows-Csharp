using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Windows.Forms;

namespace aplikasi_remote
{
    public partial class Form2 : Form
    {
        bool connected = false;
        int rY; int rX;
        Size Remotescreen;
        ScreenCapture obj;
        string URI;
        TcpChannel chan;

        //Form Styles Variables
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        ToolTip tooltip = new ToolTip();

        public Form2(bool con,ScreenCapture s,string uz,TcpChannel c)
        {
            InitializeComponent();
            //membuat tooltip pada element
            tooltip.SetToolTip(dc, "Putuskan Sambungan");
            tooltip.SetToolTip(label1, "Minimize Menu");
            tooltip.SetToolTip(sound, "Jalankan Suara");
            tooltip.SetToolTip(warn, "Munculkan Warning");
            tooltip.SetToolTip(max, "Max/Min Window");
            //Menerima data dari constructor
            connected = con;
            obj = s;
            Remotescreen = obj.GetDesktopBitmapSize();
            URI = uz;
            chan = c;
            obj.con_stat = true;
            obj.soundStat = false;
            obj.sendMessage = false;
            textBox1.Visible = false;
            this.ActiveControl = textBox1;
        }

        [DllImport("user32.dll")]
        private static extern uint MapVirtualKey(
            uint uCode,     // virtual-key code or scan code
            uint uMapType   // translation to perform
            );

        #region Form Style
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
        #endregion

        //Main Program
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (connected == true)
            {
                rX = (e.X * Remotescreen.Width) / pictureBox1.Width;
                rY = (e.Y * Remotescreen.Height) / pictureBox1.Height;
                obj.MoveMouse(rX, rY);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (connected == true)
            {
                rX = (e.X * Remotescreen.Width) / pictureBox1.Width;
                rY = (e.Y * Remotescreen.Height) / pictureBox1.Height;
                obj.PressOrReleaseMouseButton(true, e.Button == MouseButtons.Left, rX, rY);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (connected == true)
            {
                rX = (e.X * Remotescreen.Width) / pictureBox1.Width;
                rY = (e.Y * Remotescreen.Height) / pictureBox1.Height;
                obj.PressOrReleaseMouseButton(false, e.Button == MouseButtons.Left, rX, rY);
            }
        }

        private void sound_Click(object sender, EventArgs e)
        {
            obj.soundStat = true;
        }

        private void warn_Click(object sender, EventArgs e)
        {
            obj.sendMessage = true;
        }

        private void max_Click(object sender, EventArgs e)
        {
            if (max.Text == "Max")
            {
                this.WindowState = FormWindowState.Maximized;
                panel1.Location = new Point((this.Width - panel1.Width) / 2, panel1.Location.Y);
                label1.Location = new Point(((this.Width / 2) - (panel1.Width / 2)) - 20, panel1.Location.Y);
                max.Text = "Min";
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                panel1.Location = new Point((this.Width - panel1.Width) / 2, panel1.Location.Y);
                label1.Location = new Point(((this.Width / 2) - (panel1.Width / 2)) - 20, panel1.Location.Y);
                max.Text = "Max";
            }
        }

        private void btnhide_Click(object sender, EventArgs e)
        {            
            if (label1.Text == "H")
            {
                panel1.Hide();
                label1.Text = "S";
            }
            else
            {
                panel1.Show();
                label1.Text = "H";
            }
        }

        private void keyform(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            obj.SendKeystroke((byte)e.KeyCode, (byte)MapVirtualKey((uint)e.KeyCode, 0), false, false);
        }

        private void keydown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            obj.SendKeystroke((byte)e.KeyCode, (byte)MapVirtualKey((uint)e.KeyCode, 0), true, false);
        }

        private void dc_Click(object sender, EventArgs e)
        {
            try
            {
                ChannelServices.UnregisterChannel(chan);//to Un Register chan Channel
            }
            catch (Exception err)
            {
                MessageBox.Show("Error : " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            obj.con_stat = false;
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (obj.con_stat == false)
            {
                try
                {
                    ChannelServices.UnregisterChannel(chan);//to Un Register chan Channel
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error : " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
            else
            {
                try
                {
                    byte[] buffer = obj.GetDesktopBitmapBytes();
                    MemoryStream ms = new MemoryStream(buffer);
                    pictureBox1.Image = Image.FromStream(ms);
                    if (obj.sendMessage == true)
                        obj.sendMessage = false;
                    if (obj.soundStat == true)
                        obj.soundStat = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                };
            }
        }

        private void pic_click(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
        }
    }
}
