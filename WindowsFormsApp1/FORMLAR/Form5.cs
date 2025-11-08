using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace WindowsFormsApp1.FORMLAR
{
    public partial class Form5 : Form
    {
        public string KitapAdı;
        public string KitapBarkod;
        public int Kaçkitapkullanımda;
        DateTime time;
        public Form5()
        {
            InitializeComponent();
        }

        private void Temizle()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
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

        private void Form5_Load(object sender, EventArgs e)
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
            if (string.IsNullOrEmpty(guna2TextBox1.Text) || string.IsNullOrEmpty(guna2TextBox2.Text) || string.IsNullOrEmpty(guna2TextBox3.Text))
            {
                Dialog("Boş Bırakılmaz", this.FindForm(), Properties.Settings.Default.Theme);
            }
            else
            {
                using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                {
                    connect.Open();

                    using (SqlCommand cmd = new SqlCommand("insert into BookUse(KitapAdi,KitapAlanınAdı,KitapAlanınSınıfı,KitapAlanınNumarası,KitabınAlınmaTarihi,KitabınGeriVerileceğiTarih,KitapBarkod) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", connect))
                    {
                        cmd.Parameters.AddWithValue("@p1", KitapAdı.ToString());
                        cmd.Parameters.AddWithValue("@p2", guna2TextBox1.Text);
                        cmd.Parameters.AddWithValue("@p3", guna2TextBox3.Text);
                        cmd.Parameters.AddWithValue("@p4", guna2TextBox2.Text);
                        cmd.Parameters.AddWithValue("@p5", DateTime.Now.Date);
                        if (guna2NumericUpDown1.Value == 0)
                        {
                            time = DateTime.Now.Date.AddDays(30);
                            cmd.Parameters.AddWithValue("@p6", time);
                        }
                        else
                        {
                            int count = ((int)guna2NumericUpDown1.Value);
                            time = DateTime.Now.Date.AddDays(count);
                            cmd.Parameters.AddWithValue("@p6", time);
                        }
                        cmd.Parameters.AddWithValue("@p7", KitapBarkod);
                        cmd.ExecuteNonQuery();

                        Dialog("Kayıt Edildi\nSon Teslim Tarihi:"+time.ToString()+"", this.FindForm(), Properties.Settings.Default.Theme);
                        cmd.Dispose();
                        Temizle();
                    }

                    connect.Close();
                    connect.Dispose();
                    Temizle();
                }
                using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                {
                    connect.Open();

                    int count = Kaçkitapkullanımda + 1;
                    using (SqlCommand cmd = new SqlCommand("update Book set KaçKitapKullanımda='"+count+"' where KitapAdi='" + KitapAdı + "'", connect))
                    {
                        cmd.ExecuteNonQuery();

                        cmd.Dispose();
                        Temizle();
                    }

                    connect.Close();
                    connect.Dispose();
                    Temizle();
                }
                Temizle();
            }
            Temizle();
            this.Close();
            WindowsFormsApp1.FORMLAR.Form4.fr.Close();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            WindowsFormsApp1.FORMLAR.Form4.fr.Close();
        }
    }
}
