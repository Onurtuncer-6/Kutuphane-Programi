using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace WindowsFormsApp1.KULLANICI_DENETİMİ
{
    public partial class KitapKaldır : System.Windows.Forms.UserControl
    {
        public KitapKaldır()
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

        private void Güncelle()
        {
            guna2DataGridView1.Rows.Clear();
            using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("select KitapAdi,KitapYazarı,KitapTürü,KitapBarkod,KitapSayfaSayısı,KitapEklenmeTarihi from Book", connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            guna2DataGridView1.Rows.Add(reader["KitapAdi"].ToString(), reader["KitapYazarı"].ToString(), reader["KitapTürü"].ToString(), reader["KitapBarkod"].ToString(), reader["KitapSayfaSayısı"].ToString(), reader["KitapEklenmeTarihi"].ToString());
                        }
                        Temizle();
                    }

                    cmd.Dispose();
                    Temizle();
                }

                connect.Close();
                connect.Dispose();
                Temizle();
            }
            Temizle();
        }

        private void KitapKaldır_Load(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("select KitapAdi,KitapYazarı,KitapTürü,KitapBarkod,KitapSayfaSayısı,KitapEklenmeTarihi from Book",connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            guna2DataGridView1.Rows.Add(reader["KitapAdi"].ToString(), reader["KitapYazarı"].ToString(), reader["KitapTürü"].ToString(), reader["KitapBarkod"].ToString(), reader["KitapSayfaSayısı"].ToString(), reader["KitapEklenmeTarihi"].ToString());
                        }
                        Temizle();
                    }

                    cmd.Dispose();
                    Temizle();
                }

                connect.Close();
                connect.Dispose();
                Temizle();
            }
            Temizle();
        }

        private void KitapKaldır_VisibleChanged(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Clear();
            using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("select KitapAdi,KitapYazarı,KitapTürü,KitapBarkod,KitapSayfaSayısı,KitapEklenmeTarihi from Book", connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            guna2DataGridView1.Rows.Add(reader["KitapAdi"].ToString(), reader["KitapYazarı"].ToString(), reader["KitapTürü"].ToString(), reader["KitapBarkod"].ToString(), reader["KitapSayfaSayısı"].ToString(), reader["KitapEklenmeTarihi"].ToString());
                        }
                        Temizle();
                    }

                    cmd.Dispose();
                    Temizle();
                }

                connect.Close();
                connect.Dispose();
                Temizle();
            }
            Temizle();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text != "")
            {
                guna2DataGridView1.Rows.Clear();
                using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                {
                    connect.Open();

                    using (SqlCommand cmd = new SqlCommand("select KitapAdi,KitapYazarı,KitapTürü,KitapBarkod,KitapSayfaSayısı,KitapEklenmeTarihi from Book where KitapAdi LIKE '%" + guna2TextBox1.Text + "%' or KitapYazarı LIKE '%" + guna2TextBox1.Text + "%' or KitapTürü LIKE '%" + guna2TextBox1.Text + "%' or KitapKonusu LIKE '%" + guna2TextBox1.Text + "%' or KitapBarkod LIKE '%" + guna2TextBox1.Text + "%' or KitapEklenmeTarihi LIKE '%" + guna2TextBox1.Text + "%'", connect))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                guna2DataGridView1.Rows.Add(reader["KitapAdi"].ToString(), reader["KitapYazarı"].ToString(), reader["KitapTürü"].ToString(), reader["KitapBarkod"].ToString(), reader["KitapSayfaSayısı"].ToString(), reader["KitapEklenmeTarihi"].ToString());
                            }
                            Temizle();
                        }
                        cmd.Dispose();
                        Temizle();
                    }

                    connect.Close();
                    connect.Dispose();
                    Temizle();
                }
            }
            else
            {
                guna2DataGridView1.Rows.Clear();
                using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                {
                    connect.Open();

                    using (SqlCommand cmd = new SqlCommand("select KitapAdi,KitapYazarı,KitapTürü,KitapBarkod,KitapSayfaSayısı,KitapEklenmeTarihi from Book", connect))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                guna2DataGridView1.Rows.Add(reader["KitapAdi"].ToString(), reader["KitapYazarı"].ToString(), reader["KitapTürü"].ToString(), reader["KitapBarkod"].ToString(), reader["KitapSayfaSayısı"].ToString(), reader["KitapEklenmeTarihi"].ToString());
                            }
                            Temizle();
                        }

                        cmd.Dispose();
                        Temizle();
                    }

                    connect.Close();
                    connect.Dispose();
                    Temizle();
                }
                Temizle();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox2.Text != "")
            {
                using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                {
                    connect.Open();
                    
                    using (SqlCommand cmd = new SqlCommand("delete from Book where KitapAdi='" + guna2TextBox2.Text + "'", connect))
                    {
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        Temizle();

                        Dialog("Kitap Silindi",this.FindForm(),Properties.Settings.Default.Theme);

                        Güncelle();
                    }
                    connect.Close();
                    connect.Dispose();
                    Temizle();
                }
            }
            else
            {

            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2TextBox2.Text = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
