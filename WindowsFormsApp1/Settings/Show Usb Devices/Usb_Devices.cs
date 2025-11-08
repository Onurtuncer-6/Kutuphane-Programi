using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Settings.Show_Usb_Devices
{
    public partial class Usb_Devices : UserControl
    {
        public Usb_Devices()
        {
            InitializeComponent();
        }
        public string FlashAdı { get; set; }
        public string FlashYolu { get; set; }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Yedekle.Settings.settings.SeçilenFlashAdı = FlashAdı;
            Yedekle.Settings.settings.SeçilenFlashYolu = FlashYolu;
        }
    }
}
