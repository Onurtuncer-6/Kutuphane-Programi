using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace WindowsFormsApp1.FORMLAR
{
    public partial class Form4 : Form
    {
        public string KitapAdı;
        public string KitapResim;
        public string KaçKitapVar;
        public string KaçKitapKullanımda;
        public string KitapBarkod;

        public static Form4 fr;
        public Form4()
        {
            InitializeComponent();
            fr = this;
        }

        private void Dialog(string Message, Form th, string theme)
        {
            using (Guna2MessageDialog dialog = new Guna2MessageDialog())
            {
                dialog.Text = Message;
                dialog.Parent = th;
                dialog.Buttons = MessageDialogButtons.OK;
                dialog.Icon = MessageDialogIcon.Information;
                if (theme == "dark-mode")
                {
                    dialog.Style = MessageDialogStyle.Dark;
                }
                else if (theme == "light-mode")
                {
                    dialog.Style = MessageDialogStyle.Light;
                }
                dialog.Show();
                dialog.Dispose();
                Temizle();
            }
            Temizle();
        }
        private void Temizle()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            guna2HtmlLabel1.Text = KitapAdı;
            if (KitapResim != "")
            {
                guna2PictureBox1.Image = Image.FromFile(KitapResim);
            }
            else
            {
                guna2PictureBox1.Image = null;
            }
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Theme.ToString() == "dark-mode")
            {
                this.BackColor = Color.FromArgb(30, 30, 30);
                this.ForeColor = Color.White;
            }
            if (Properties.Settings.Default.Theme.ToString() == "light-mode")
            {
                this.BackColor = Color.FromArgb(248, 249, 250);
                this.ForeColor = Color.Black;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int kaçkitapvar = Convert.ToInt32(KaçKitapVar);
            int kaçkitapkullanımda = Convert.ToInt32(KaçKitapKullanımda);

            if (kaçkitapvar == kaçkitapkullanımda)
            {
                Dialog("Kitapların Hepsi Kullanımda", this.FindForm(), Properties.Settings.Default.Theme);
            }
            else if (kaçkitapkullanımda < kaçkitapvar)
            {
                Temizle();
                Form5 frm = new Form5();
                frm.KitapAdı = guna2HtmlLabel1.Text;
                frm.Kaçkitapkullanımda = kaçkitapkullanımda;
                frm.KitapBarkod = KitapBarkod;
                frm.ShowDialog();
            }
            else
            {
                Dialog("Kütüphanedeki Kitap Sayısı Kullanımda Olan Kitap Sayısından Fazla", this.FindForm(), Properties.Settings.Default.Theme);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Temizle();
            Form6 form6 = new Form6();
            form6.KitapAdı = KitapAdı;
            form6.KitapBarkod = KitapBarkod;
            form6.KaçKitapkULLANIMDA = KaçKitapKullanımda;
            form6.ShowDialog();
        }
    }
}
