using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;

namespace aplikasi_remote
{
    public partial class Form3 : Form
    {
        ScreenCapture obj;
        string URI;
        int defaultheight;
        TcpChannel chan;
        string nama="You";
        bool connection = false;

        public Form3(string n, bool con, ScreenCapture s, string uz, TcpChannel c)
        {
            InitializeComponent();
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);
            //Menerima data dari constructor
            obj = s;
            URI = uz;
            chan = c;
            nama = n;
            obj.con_stat = con;
            obj.sndmsg = null;
            obj.sndmsg1 = null;
            if(nama == "Client")
            {
                obj.sndmsg = "Kode-1995";
                connection = true;
            }
        }

        #region Desain Form
        //Form Styles Variables
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        //global brushes with ordinary/selected colors
        private SolidBrush reportsForegroundBrush = new SolidBrush(Color.DimGray);
        private SolidBrush reportsBackgroundBrush1 = new SolidBrush(Color.White);
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

        //custom method to draw the items, don't forget to set DrawMode of the ListBox to OwnerDrawFixed
        private void listBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            bool selected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);

            int index = e.Index;
            if (index >= 0 && index < listBox1.Items.Count)
            {
                string text = listBox1.Items[index].ToString();
                Graphics g = e.Graphics;

                //background:
                SolidBrush backgroundBrush;
                backgroundBrush = reportsBackgroundBrush1;
                g.FillRectangle(backgroundBrush, e.Bounds);

                //text:
                SolidBrush foregroundBrush = reportsForegroundBrush;
                g.DrawString(text, e.Font, foregroundBrush, listBox1.GetItemRectangle(index).Location);
            }

            e.DrawFocusRectangle();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (label2.Text == "_")
            {
                listBox1.Hide();
                panel2.Hide();
                defaultheight = this.Height;
                this.Size = new Size((int)this.Width, (int)panel1.Height);
                Rectangle workingArea = Screen.GetWorkingArea(this);
                this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);
                label2.Text = "^";
            }
            else
            {
                listBox1.Show();
                panel2.Show();
                this.Size = new Size((int)this.Width, (int)defaultheight);
                Rectangle workingArea = Screen.GetWorkingArea(this);
                this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);
                label2.Text = "_";
            }
        }

        #endregion

        //Main Program
        //dapatkan data dari-waktu-ke-waktu
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (obj.con_stat == false)
            {
                if(nama == "Client")
                    this.Close();
            }
            else
            {
                if(nama != "Client" && obj.sndmsg == "Kode-1995")
                {
                    listBox1.Items.Add("Klien Telah Terhubung!");
                    connection = true;
                    obj.sndmsg = null;
                }
                if (nama == "Client" && !string.IsNullOrEmpty(obj.sndmsg1))
                {
                    listBox1.Items.Add(obj.sndmsg1);
                    obj.sndmsg1 = null;
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                }
                else if(!string.IsNullOrEmpty(obj.sndmsg) && nama != "Client" && obj.sndmsg != "Kode-1995")
                {
                    listBox1.Items.Add(obj.sndmsg);
                    obj.sndmsg = null;
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                }
            }
        }
        //ketika button klik
        private void button1_Click(object sender, EventArgs e)
        {
            if(connection == true)
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    listBox1.Items.Add(nama + " : " + textBox1.Text);
                    if (nama == "Client")
                    {
                        obj.sndmsg = nama + " : " + textBox1.Text;
                    }
                    else
                    {
                        obj.sndmsg1 = nama + " : " + textBox1.Text;
                    }
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                }
                else
                {
                    textBox1.Focus();
                }
            }
            else
            {
                MessageBox.Show("Tidak Ada Klien Terhubung");
            }
        }
    }
}
