using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace WindowsFormsApp1.KULLANICI_DENETİMİ.Misafir_Kitap
{
    public partial class Kitap_Bilgileri : UserControl
    {
        public Kitap_Bilgileri()
        {
            InitializeComponent();
        }
        private void Temizle()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void Kitap_Bilgileri_Load(object sender, EventArgs e)
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text != "")
            {
                WindowsFormsApp1.KULLANICI_DENETİMİ.Kitaplar.th.flowLayoutPanel.Controls.Clear();
                using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                {
                    connect.Open();
                    using (SqlCommand cmd = new SqlCommand("select count(*) from Book where KitapAdi LIKE '%"+guna2TextBox1.Text+ "%' or KitapYazarı LIKE '%"+guna2TextBox1.Text+ "%' or KitapTürü LIKE '%"+guna2TextBox1.Text+ "%' or KitapKonusu LIKE '%"+guna2TextBox1.Text+ "%' or KitapBarkod LIKE '%" + guna2TextBox1.Text + "%'", connect))
                    {
                        Int32 count = (Int32)cmd.ExecuteScalar();

                        using (SqlConnection connect1 = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                        {
                            connect1.Open();
                            using (SqlCommand cmd1 = new SqlCommand("select * from Book where KitapAdi LIKE '%"+guna2TextBox1.Text+"%' or KitapYazarı LIKE '%"+guna2TextBox1.Text+ "%' or KitapTürü LIKE '%"+guna2TextBox1.Text+ "%' or KitapKonusu LIKE '%"+guna2TextBox1.Text+ "%' or KitapBarkod LIKE '%" + guna2TextBox1.Text + "%'",connect1))
                            {
                                using (SqlDataReader reader = cmd1.ExecuteReader())
                                {
                                    for (int i = 0; i < count; i++)
                                    {
                                        if (reader.Read())
                                        {
                                            string Kitap_Adı = reader["KitapAdi"].ToString();
                                            string KitapResim = reader["KitapResim"].ToString();

                                            Guna2Panel guna2Panel = new Guna2Panel();
                                            guna2Panel.Name = Kitap_Adı;
                                            guna2Panel.Size = new System.Drawing.Size(211, 295);
                                            guna2Panel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                                            guna2Panel.BorderRadius = 1;
                                            guna2Panel.BorderColor = System.Drawing.Color.DarkGray;
                                            guna2Panel.BorderThickness = 1;
                                            WindowsFormsApp1.KULLANICI_DENETİMİ.Kitaplar.th.flowLayoutPanel.Controls.Add(guna2Panel);
                                            guna2Panel.DoubleClick += WindowsFormsApp1.KULLANICI_DENETİMİ.Kitaplar.th.Panel_DoubleClick;

                                            PictureBox pictureBox = new PictureBox();
                                            if (KitapResim != "")
                                            {
                                                pictureBox.Image = Image.FromFile(KitapResim);
                                                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                                                pictureBox.Size = new System.Drawing.Size(205, 237);
                                                pictureBox.Location = new System.Drawing.Point(3, 3);
                                                guna2Panel.Controls.Add(pictureBox);
                                            }
                                            else
                                            {
                                                pictureBox.Image = null;
                                                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                                                pictureBox.Size = new System.Drawing.Size(205, 237);
                                                pictureBox.Location = new System.Drawing.Point(3, 3);
                                                guna2Panel.Controls.Add(pictureBox);
                                            }
                                            Label label = new Label();
                                            label.Text = Kitap_Adı;
                                            label.AutoEllipsis = true;
                                            label.TabIndex = 2;
                                            label.Size = new System.Drawing.Size(35, 13);
                                            label.Location = new System.Drawing.Point(12, 260);
                                            guna2Panel.Controls.Add(label);
                                        }
                                    }
                                }
                                cmd1.Dispose();
                                Temizle();
                            }
                            connect1.Close();
                            connect.Dispose();
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
        }
    }
}
