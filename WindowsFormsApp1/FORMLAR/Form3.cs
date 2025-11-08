using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.FORMLAR
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Theme.ToString() == "dark-mode")
            {
                this.BackColor = Color.FromArgb(30, 30, 30);
                this.ForeColor = Color.White;
                flowLayoutPanel1.BackColor = Color.FromArgb(40, 40, 40);
            }
            if (Properties.Settings.Default.Theme.ToString() == "light-mode")
            {
                this.BackColor = Color.FromArgb(248, 249, 250);
                this.ForeColor = Color.Black;
                flowLayoutPanel1.BackColor = Color.FromArgb(39, 35, 67);
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
         Application.Restart();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (kitaplar1.Visible == false)
                kitaplar1.Visible = true;
            else if (kitaplar1.Visible == true)
                kitaplar1.Visible = false;
        }
    }
}
