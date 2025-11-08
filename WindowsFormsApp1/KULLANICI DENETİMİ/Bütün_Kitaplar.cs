using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.KULLANICI_DENETİMİ
{
    public partial class Bütün_Kitaplar : UserControl
    {
        public Bütün_Kitaplar()
        {
            InitializeComponent();
        }

        private void Temizle()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void Bütün_Kitaplar_Load(object sender, EventArgs e)
        {
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

        private void Bütün_Kitaplar_VisibleChanged(object sender, EventArgs e)
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
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.CreatePrompt = true;
                saveFileDialog.OverwritePrompt = true;
                saveFileDialog.Title = "Metin Dosyası";
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.Filter = "txt Dosyaları (*.txt)|*.txt|Tüm Dosyalar(*.*)|*.*";


                using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            fs.Close();

                            connect.Open();
                            using (SqlCommand cmd = new SqlCommand("select * from Book", connect))
                            {
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    File.AppendAllText(saveFileDialog.FileName, Environment.NewLine + "             Bütün Kitaplar;\n\n\n");
                                    for (int i = 0; i < guna2DataGridView1.Rows.Count; i++)
                                    {
                                        if (reader.Read())
                                        {
                                            File.AppendAllText(saveFileDialog.FileName, Environment.NewLine + reader["KitapAdi"].ToString() + " - " + reader["KitapYazarı"].ToString() + " - " + reader["KitapTürü"].ToString() + " - " + reader["KitapKonusu"].ToString() + " - " + reader["KitapBarkod"].ToString() + " - " + reader["KitapEklenmeTarihi"].ToString());
                                        }
                                    }
                                    connect.Close();
                                    connect.Dispose();
                                    Temizle();
                                }
                                cmd.Dispose();
                                Temizle();
                            }
                            Temizle();
                        }
                        Temizle();
                    }
                    Temizle();
                }
            }
        }
    }
}
