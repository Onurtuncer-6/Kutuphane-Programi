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
    public partial class Geri_Getirilmeyen_Kitaplar : UserControl
    {
        public Geri_Getirilmeyen_Kitaplar()
        {
            InitializeComponent();
        }

        private void Temizle()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void Geri_Getirilmeyen_Kitaplar_Load(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("select * from BookUse", connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime dateTime = (DateTime)reader["KitabınGeriVerileceğiTarih"];
                            if (DateTime.Now.Date > dateTime)
                            {
                                guna2DataGridView1.Rows.Add(reader["KitapAdi"].ToString(), reader["KitapAlanınAdı"].ToString(), reader["KitapAlanınSınıfı"].ToString(), reader["KitapAlanınNumarası"].ToString(), reader["KitabınAlınmaTarihi"].ToString(), reader["KitabınGeriVerileceğiTarih"].ToString(), reader["KitapBarkod"].ToString());
                            }
                        }
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.CreatePrompt = true;
                    saveFileDialog.OverwritePrompt = true;
                    saveFileDialog.Title = "Metin Dosyası";
                    saveFileDialog.DefaultExt = "txt";
                    saveFileDialog.Filter = "txt Dosyaları (*.txt)|*.txt|Tüm Dosyalar(*.*)|*.*";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            fs.Close();

                            connect.Open();

                            using (SqlCommand cmd = new SqlCommand("select * from BookUse", connect))
                            {
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    File.AppendAllText(saveFileDialog.FileName, Environment.NewLine + "             Geri Getirilmeyen Kitaplar;\n\n\n");
                                    for (int i = 0; i < guna2DataGridView1.Rows.Count; i++)
                                    {
                                        if (reader.Read())
                                        {
                                            DateTime date = (DateTime)reader["KitabınGeriVerileceğiTarih"];
                                            if (DateTime.Now.Date > date)
                                            {
                                                File.AppendAllText(saveFileDialog.FileName, Environment.NewLine + reader["KitapAdi"].ToString() + " - " + reader["KitapAlanınAdı"].ToString() + " - " + reader["KitapAlanınSınıfı"].ToString() + " - " + reader["KitapAlanınNumarası"].ToString() + " - " + reader["KitabınAlınmaTarihi"].ToString() + " - " + reader["KitabınGeriVerileceğiTarih"].ToString() + " - " + reader["KitapBarkod"].ToString());
                                            }
                                        }
                                    }
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
                    Temizle();
                }
                Temizle();
            }
            Temizle();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Clear();
            if (guna2TextBox1.Text != "")
            {
                using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                {
                    connect.Open();

                    using (SqlCommand cmd = new SqlCommand("select * from BookUse where KitapAdi LIKE '%" + guna2TextBox1.Text + "%' or KitapAlanınAdı LIKE '%" + guna2TextBox1.Text + "%' or KitapAlanınSınıfı LIKE '%" + guna2TextBox1.Text + "%' or KitapAlanınNumarası LIKE '%" + guna2TextBox1.Text + "%' or KitabınAlınmaTarihi LIKE '%" + guna2TextBox1.Text + "%' or KitabınGeriVerileceğiTarih LIKE '%" + guna2TextBox1.Text + "%' or KitapBarkod LIKE '%" + guna2TextBox1.Text + "%'", connect))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                guna2DataGridView1.Rows.Add(reader["KitapAdi"].ToString(), reader["KitapAlanınAdı"].ToString(), reader["KitapAlanınSınıfı"].ToString(), reader["KitapAlanınNumarası"].ToString(), reader["KitabınAlınmaTarihi"].ToString(), reader["KitabınGeriVerileceğiTarih"].ToString(), reader["KitapBarkod"].ToString());
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
            else
            {
                using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                {
                    connect.Open();

                    using (SqlCommand cmd = new SqlCommand("select * from BookUse", connect))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime dateTime = (DateTime)reader["KitabınGeriVerileceğiTarih"];
                                if (DateTime.Now.Date > dateTime)
                                {
                                    guna2DataGridView1.Rows.Add(reader["KitapAdi"].ToString(), reader["KitapAlanınAdı"].ToString(), reader["KitapAlanınSınıfı"].ToString(), reader["KitapAlanınNumarası"].ToString(), reader["KitabınAlınmaTarihi"].ToString(), reader["KitabınGeriVerileceğiTarih"].ToString(), reader["KitapBarkod"].ToString());
                                }
                            }
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

        private void Geri_Getirilmeyen_Kitaplar_VisibleChanged(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Clear();
            using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("select * from BookUse", connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime dateTime = (DateTime)reader["KitabınGeriVerileceğiTarih"];
                            if (DateTime.Now.Date > dateTime)
                            {
                                guna2DataGridView1.Rows.Add(reader["KitapAdi"].ToString(), reader["KitapAlanınAdı"].ToString(), reader["KitapAlanınSınıfı"].ToString(), reader["KitapAlanınNumarası"].ToString(), reader["KitabınAlınmaTarihi"].ToString(), reader["KitabınGeriVerileceğiTarih"].ToString(), reader["KitapBarkod"].ToString());
                            }
                        }
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
}
