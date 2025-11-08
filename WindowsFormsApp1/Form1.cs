using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            WindowsFormsApp1.FORMLAR.Form2 frm = new WindowsFormsApp1.FORMLAR.Form2();
            frm.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Theme.ToString() == "dark-mode")
            {
                this.BackColor = Color.FromArgb(30, 30, 30);
                this.ForeColor = Color.White;
                button6.BackgroundImage = Properties.Resources.light_bulb;
                button6.BackgroundImageLayout = ImageLayout.Stretch;
            }
            if (Properties.Settings.Default.Theme.ToString() == "light-mode")
            {
                this.BackColor = Color.FromArgb(248, 249, 250);
                this.ForeColor = Color.Black;
                button6.BackgroundImage = Properties.Resources.night_mode;
                button6.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Theme.ToString() == "dark-mode")
            {
                guna2MessageDialog2.Show();
                this.BackColor = Color.FromArgb(248, 249, 250);
                this.ForeColor = Color.Black;
                button6.BackgroundImage = Properties.Resources.night_mode;
                Properties.Settings.Default.Theme = "light-mode";
                Properties.Settings.Default.Save();
            }
            else
            {
                guna2MessageDialog1.Show();
                this.BackColor = Color.FromArgb(30, 30, 30);
                this.ForeColor = Color.White;
                button6.BackgroundImage = Properties.Resources.light_bulb;
                Properties.Settings.Default.Theme = "dark-mode";
                Properties.Settings.Default.Save();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            WindowsFormsApp1.FORMLAR.Form3 frm = new FORMLAR.Form3();
            frm.Show();
            this.Hide();
        }
    }
}
