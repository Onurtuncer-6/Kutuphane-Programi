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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
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
            Application.Exit();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (kitap_Ekle1.Visible == false)
            {
                kitap_Ekle1.Visible = true;
                kitapKaldır1.Visible = false;
                kitap_Düzenle1.Visible = false;
                bütün_Kitaplar1.Visible = false;
                kitap_Alan_Öğrenciler1.Visible = false;
                geri_Getirilmeyen_Kitaplar1.Visible = false;
                kategori_Ekle1.Visible = false;
                kategori_Kaldır1.Visible = false;
                kitapp_Ver1.Visible = false;
                kitap_Teslim_AL1.Visible = false;
                settings1.Visible = false;
            }
            else
            {
                kitap_Ekle1.Visible = false;
                kitapKaldır1.Visible = false;
                kitap_Düzenle1.Visible = false;
                bütün_Kitaplar1.Visible = false;
                kitap_Alan_Öğrenciler1.Visible = false;
                geri_Getirilmeyen_Kitaplar1.Visible = false;
                kategori_Ekle1.Visible = false;
                kategori_Kaldır1.Visible = false;
                kitapp_Ver1.Visible = false;
                kitap_Teslim_AL1.Visible = false;
                settings1.Visible = false;
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            if (kitapKaldır1.Visible == false)
            {
                kitap_Ekle1.Visible = false;
                kitapKaldır1.Visible = true;
                kitap_Düzenle1.Visible = false;
                bütün_Kitaplar1.Visible = false;
                kitap_Alan_Öğrenciler1.Visible = false;
                geri_Getirilmeyen_Kitaplar1.Visible = false;
                kategori_Ekle1.Visible = false;
                kategori_Kaldır1.Visible = false;
                kitapp_Ver1.Visible = false;
                kitap_Teslim_AL1.Visible = false;
                settings1.Visible = false;
            }
            else
            {
                kitap_Ekle1.Visible = false;
                kitapKaldır1.Visible = false;
                kitap_Düzenle1.Visible = false;
                bütün_Kitaplar1.Visible = false;
                kitap_Alan_Öğrenciler1.Visible = false;
                geri_Getirilmeyen_Kitaplar1.Visible = false;
                kategori_Ekle1.Visible = false;
                kategori_Kaldır1.Visible = false;
                kitapp_Ver1.Visible = false;
                kitap_Teslim_AL1.Visible = false;
                settings1.Visible = false;
            }
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            if (kitap_Düzenle1.Visible == false)
            {
                kitap_Ekle1.Visible = false;
                kitapKaldır1.Visible = false;
                kitap_Düzenle1.Visible = true;
                bütün_Kitaplar1.Visible = false;
                kitap_Alan_Öğrenciler1.Visible = false;
                geri_Getirilmeyen_Kitaplar1.Visible = false;
                kategori_Ekle1.Visible = false;
                kategori_Kaldır1.Visible = false;
                kitapp_Ver1.Visible = false;
                kitap_Teslim_AL1.Visible = false;
                settings1.Visible = false;
            }
            else
            {
                kitap_Ekle1.Visible = false;
                kitapKaldır1.Visible = false;
                kitap_Düzenle1.Visible = false;
                bütün_Kitaplar1.Visible = false;
                kitap_Alan_Öğrenciler1.Visible = false;
                geri_Getirilmeyen_Kitaplar1.Visible = false;
                kategori_Ekle1.Visible = false;
                kategori_Kaldır1.Visible = false;
                kitapp_Ver1.Visible = false;
                kitap_Teslim_AL1.Visible = false;
                settings1.Visible = false;
            }
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            if (bütün_Kitaplar1.Visible == false)
            {
                kitap_Ekle1.Visible = false;
                kitapKaldır1.Visible = false;
                kitap_Düzenle1.Visible = false;
                bütün_Kitaplar1.Visible = true;
                kitap_Alan_Öğrenciler1.Visible = false;
                geri_Getirilmeyen_Kitaplar1.Visible = false;
                kategori_Ekle1.Visible = false;
                kategori_Kaldır1.Visible = false;
                kitapp_Ver1.Visible = false;
                kitap_Teslim_AL1.Visible = false;
                settings1.Visible = false;
            }
            else
            {
                kitap_Ekle1.Visible = false;
                kitapKaldır1.Visible = false;
                kitap_Düzenle1.Visible = false;
                bütün_Kitaplar1.Visible = false;
                kitap_Alan_Öğrenciler1.Visible = false;
                geri_Getirilmeyen_Kitaplar1.Visible = false;
                kategori_Ekle1.Visible = false;
                kategori_Kaldır1.Visible = false;
                kitapp_Ver1.Visible = false;
                kitap_Teslim_AL1.Visible = false;
                settings1.Visible = false;
            }
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            if (kitap_Alan_Öğrenciler1.Visible == false)
            {
                kitap_Ekle1.Visible = false;
                kitapKaldır1.Visible = false;
                kitap_Düzenle1.Visible = false;
                bütün_Kitaplar1.Visible = false;
                kitap_Alan_Öğrenciler1.Visible = true;
                geri_Getirilmeyen_Kitaplar1.Visible = false;
                kategori_Ekle1.Visible = false;
                kategori_Kaldır1.Visible = false;
                kitapp_Ver1.Visible = false;
                kitap_Teslim_AL1.Visible = false;
                settings1.Visible = false;
            }
            else
            {
                kitap_Ekle1.Visible = false;
                kitapKaldır1.Visible = false;
                kitap_Düzenle1.Visible = false;
                bütün_Kitaplar1.Visible = false;
                kitap_Alan_Öğrenciler1.Visible = false;
                geri_Getirilmeyen_Kitaplar1.Visible = false;
                kategori_Ekle1.Visible = false;
                kategori_Kaldır1.Visible = false;
                kitapp_Ver1.Visible = false;
                kitap_Teslim_AL1.Visible = false;
                settings1.Visible = false;
            }
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            if (geri_Getirilmeyen_Kitaplar1.Visible == false)
            {
                kitap_Ekle1.Visible = false;
                kitapKaldır1.Visible = false;
                kitap_Düzenle1.Visible = false;
                bütün_Kitaplar1.Visible = false;
                kitap_Alan_Öğrenciler1.Visible = false;
                geri_Getirilmeyen_Kitaplar1.Visible = true;
                kategori_Ekle1.Visible = false;
                kategori_Kaldır1.Visible = false;
                kitapp_Ver1.Visible = false;
                kitap_Teslim_AL1.Visible = false;
                settings1.Visible = false;
            }
            else
            {
                kitap_Ekle1.Visible = false;
                kitapKaldır1.Visible = false;
                kitap_Düzenle1.Visible = false;
                bütün_Kitaplar1.Visible = false;
                kitap_Alan_Öğrenciler1.Visible = false;
                geri_Getirilmeyen_Kitaplar1.Visible = false;
                kategori_Ekle1.Visible = false;
                kategori_Kaldır1.Visible = false;
                kitapp_Ver1.Visible = false;
                kitap_Teslim_AL1.Visible = false;
                settings1.Visible = false;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (kategori_Ekle1.Visible == false)
            {
                kitap_Ekle1.Visible = false;
                kitapKaldır1.Visible = false;
                kitap_Düzenle1.Visible = false;
                bütün_Kitaplar1.Visible = false;
                kitap_Alan_Öğrenciler1.Visible = false;
                geri_Getirilmeyen_Kitaplar1.Visible = false;
                kategori_Ekle1.Visible = true;
                kategori_Kaldır1.Visible = false;
                kitapp_Ver1.Visible = false;
                kitap_Teslim_AL1.Visible = false;
                settings1.Visible = false;
            }
            else
            {
                kitap_Ekle1.Visible = false;
                kitapKaldır1.Visible = false;
                kitap_Düzenle1.Visible = false;
                bütün_Kitaplar1.Visible = false;
                kitap_Alan_Öğrenciler1.Visible = false;
                geri_Getirilmeyen_Kitaplar1.Visible = false;
                kategori_Ekle1.Visible = false;
                kategori_Kaldır1.Visible = false;
                kitapp_Ver1.Visible = false;
                kitap_Teslim_AL1.Visible = false;
                settings1.Visible = false;
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (kategori_Kaldır1.Visible == false)
            {
                kitap_Ekle1.Visible = false;
                kitapKaldır1.Visible = false;
                kitap_Düzenle1.Visible = false;
                bütün_Kitaplar1.Visible = false;
                kitap_Alan_Öğrenciler1.Visible = false;
                geri_Getirilmeyen_Kitaplar1.Visible = false;
                kategori_Ekle1.Visible = false;
                kategori_Kaldır1.Visible = true;
                kitapp_Ver1.Visible = false;
                kitap_Teslim_AL1.Visible = false;
                settings1.Visible = false;
            }
            else
            {
                kitap_Ekle1.Visible = false;
                kitapKaldır1.Visible = false;
                kitap_Düzenle1.Visible = false;
                bütün_Kitaplar1.Visible = false;
                kitap_Alan_Öğrenciler1.Visible = false;
                geri_Getirilmeyen_Kitaplar1.Visible = false;
                kategori_Ekle1.Visible = false;
                kategori_Kaldır1.Visible = false;
                kitapp_Ver1.Visible = false;
                kitap_Teslim_AL1.Visible = false;
                settings1.Visible = false;
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel2.Height < 50)
            {
                flowLayoutPanel2.Height = 468;
            }
            else
            {
                flowLayoutPanel2.Height = 49;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel3.Height < 53)
            {
                flowLayoutPanel3.Height = 158;
            }
            else
            {
                flowLayoutPanel3.Height = 52;
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            if (kitapp_Ver1.Visible == false)
            {
                kitap_Ekle1.Visible = false;
                kitapKaldır1.Visible = false;
                kitap_Düzenle1.Visible = false;
                bütün_Kitaplar1.Visible = false;
                kitap_Alan_Öğrenciler1.Visible = false;
                geri_Getirilmeyen_Kitaplar1.Visible = false;
                kategori_Ekle1.Visible = false;
                kategori_Kaldır1.Visible = false;
                kitapp_Ver1.Visible = true;
                kitap_Teslim_AL1.Visible = false;
                settings1.Visible = false;
            }
            else
            {
                kitap_Ekle1.Visible = false;
                kitapKaldır1.Visible = false;
                kitap_Düzenle1.Visible = false;
                bütün_Kitaplar1.Visible = false;
                kitap_Alan_Öğrenciler1.Visible = false;
                geri_Getirilmeyen_Kitaplar1.Visible = false;
                kategori_Ekle1.Visible = false;
                kategori_Kaldır1.Visible = false;
                kitapp_Ver1.Visible = false;
                kitap_Teslim_AL1.Visible = false;
                settings1.Visible = false;
            }
        }

        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
            if (kitap_Teslim_AL1.Visible == false)
            {
                kitap_Ekle1.Visible = false;
                kitapKaldır1.Visible = false;
                kitap_Düzenle1.Visible = false;
                bütün_Kitaplar1.Visible = false;
                kitap_Alan_Öğrenciler1.Visible = false;
                geri_Getirilmeyen_Kitaplar1.Visible = false;
                kategori_Ekle1.Visible = false;
                kategori_Kaldır1.Visible = false;
                kitapp_Ver1.Visible = false;
                kitap_Teslim_AL1.Visible = true;
                settings1.Visible = false;
            }
            else
            {
                kitap_Ekle1.Visible = false;
                kitapKaldır1.Visible = false;
                kitap_Düzenle1.Visible = false;
                bütün_Kitaplar1.Visible = false;
                kitap_Alan_Öğrenciler1.Visible = false;
                geri_Getirilmeyen_Kitaplar1.Visible = false;
                kategori_Ekle1.Visible = false;
                kategori_Kaldır1.Visible = false;
                kitapp_Ver1.Visible = false;
                kitap_Teslim_AL1.Visible = false;
                settings1.Visible = false;
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            if (settings1.Visible == false)
            {
                kitap_Ekle1.Visible = false;
                kitapKaldır1.Visible = false;
                kitap_Düzenle1.Visible = false;
                bütün_Kitaplar1.Visible = false;
                kitap_Alan_Öğrenciler1.Visible = false;
                geri_Getirilmeyen_Kitaplar1.Visible = false;
                kategori_Ekle1.Visible = false;
                kategori_Kaldır1.Visible = false;
                kitapp_Ver1.Visible = false;
                kitap_Teslim_AL1.Visible = false;
                settings1.Visible = true;
            }
            else
            {
                kitap_Ekle1.Visible = false;
                kitapKaldır1.Visible = false;
                kitap_Düzenle1.Visible = false;
                bütün_Kitaplar1.Visible = false;
                kitap_Alan_Öğrenciler1.Visible = false;
                geri_Getirilmeyen_Kitaplar1.Visible = false;
                kategori_Ekle1.Visible = false;
                kategori_Kaldır1.Visible = false;
                kitapp_Ver1.Visible = false;
                kitap_Teslim_AL1.Visible = false;
                settings1.Visible = false;
            }
        }
    }
}
