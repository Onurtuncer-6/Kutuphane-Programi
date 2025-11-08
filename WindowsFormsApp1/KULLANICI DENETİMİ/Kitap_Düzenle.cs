using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace WindowsFormsApp1.KULLANICI_DENETİMİ
{
    public partial class Kitap_Düzenle : UserControl
    {
        public byte[] ConvertImageToByte(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        public Image ConvertByteToİmage(byte[] byteArrayIn)
        {
            using (var ms = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }
        public Kitap_Düzenle()
        {
            InitializeComponent();
        }
        Image ımage;
        string KitapAdı = "";

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
            if (guna2TextBox1.Text != "")
            {
                guna2DataGridView1.Rows.Clear();
                using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                {
                    connect.Open();

                    using (SqlCommand cmd = new SqlCommand("select * from Book where KitapAdi LIKE '%" + guna2TextBox1.Text + "%' or KitapYazarı LIKE '%" + guna2TextBox1.Text + "%' or KitapTürü LIKE '%" + guna2TextBox1.Text + "%' or KitapKonusu LIKE '%" + guna2TextBox1.Text + "%' or KitapBarkod LIKE '%" + guna2TextBox1.Text + "%' or KitapEklenmeTarihi LIKE '%" + guna2TextBox1.Text + "%'", connect))
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
            else
            {
                guna2DataGridView1.Rows.Clear();
                using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                {
                    connect.Open();

                    using (SqlCommand cmd = new SqlCommand("select * from Book", connect))
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

        private void Kitap_Düzenle_Load(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("select * from Book", connect))
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

            using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
            {
                connect.Open();
                using (SqlDataAdapter da = new SqlDataAdapter("select * from BookType", connect))
                {
                    using (DataSet dt = new DataSet())
                    {
                        da.Fill(dt, "Typ_e");
                        guna2ComboBox1.DataSource = dt.Tables["Typ_e"];
                        guna2ComboBox1.DisplayMember = "Typ_e";
                        dt.Dispose();
                        Temizle();
                    }
                    da.Dispose();
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

                    using (SqlCommand cmd = new SqlCommand("select * from Book where KitapAdi LIKE '%" + guna2TextBox1.Text + "%' or KitapYazarı LIKE '%" + guna2TextBox1.Text + "%' or KitapTürü LIKE '%" + guna2TextBox1.Text + "%' or KitapKonusu LIKE '%" + guna2TextBox1.Text + "%' or KitapBarkod LIKE '%" + guna2TextBox1.Text + "%' or KitapEklenmeTarihi LIKE '%" + guna2TextBox1.Text + "%'", connect))
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
            else
            {
                guna2DataGridView1.Rows.Clear();
                using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                {
                    connect.Open();

                    using (SqlCommand cmd = new SqlCommand("select * from Book", connect))
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

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            KitapAdı = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
            {
                connect.Open();
                using (SqlCommand cmd = new SqlCommand("select * from Book where KitapAdi='" + guna2DataGridView1.CurrentRow.Cells[0].Value.ToString() +"'",connect))
                {
                    using(SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            guna2TextBox2.Text = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
                            guna2TextBox3.Text = rdr["KitapYazarı"].ToString();
                            guna2TextBox4.Text = rdr["KitapBarkod"].ToString();
                            string KitapSayfaSayısı = rdr["KitapSayfaSayısı"].ToString();
                            string KaçKitapVar = rdr["KaçKitapVar"].ToString();
                            string KaçKitapKullanımda = rdr["KaçKitapKullanımda"].ToString();
                            if (rdr["KitapResim"].ToString() != "")
                            {
                                byte[] image = (byte[])rdr["KitapResim"];
                                ımage = ConvertByteToİmage(image);
                                guna2PictureBox1.Image = ConvertByteToİmage(image);
                                guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                            else
                            {
                                ımage = null;
                                guna2PictureBox1.Image = null;
                            }
                            guna2NumericUpDown2.Value = Convert.ToInt32(KitapSayfaSayısı);
                            guna2NumericUpDown3.Value = Convert.ToInt32(KaçKitapVar);

                            using (SqlConnection connect1 = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                            {
                                connect1.Open();
                                
                                using(SqlCommand cmd1 = new SqlCommand("select * from BookType where Typ_e='" + rdr["KitapTürü"].ToString() + "'", connect1))
                                {
                                    using (SqlDataReader rdr1 = cmd1.ExecuteReader())
                                    {
                                        if (rdr1.Read())
                                        {
                                            guna2ComboBox1.Text = rdr["KitapTürü"].ToString();

                                            using (SqlConnection connect2 = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                                            {
                                                connect2.Open();

                                                using (SqlDataAdapter da = new SqlDataAdapter("select * from [" + rdr["KitapTürü"].ToString() +"]", connect2))
                                                {
                                                    using (DataSet ds = new DataSet())
                                                    {
                                                        da.Fill(ds, "Subject");
                                                        guna2ComboBox2.DataSource = ds.Tables["Subject"];
                                                        guna2ComboBox2.DisplayMember = "Subjec_t";
                                                        ds.Dispose();
                                                        Temizle();
                                                    }
                                                    da.Dispose();
                                                    Temizle();
                                                }
                                                connect2.Close();
                                                connect2.Dispose();
                                                Temizle();
                                            }
                                        }
                                        else
                                        {
                                            Dialog("Böyle Bir Tür Bulunmamaktadır \n Kitap Türünü Değiştirin", this.FindForm(), Properties.Settings.Default.Theme);
                                        }
                                    }
                                    cmd1.Dispose();
                                    Temizle();
                                }
                                connect1.Close();
                                connect1.Dispose();
                                Temizle();
                            }
                        }
                    }
                    cmd.Dispose();
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
                connect.Open();
                using (SqlDataAdapter da = new SqlDataAdapter("select * from [" + guna2ComboBox1.Text + "]", connect))
                {
                    using (DataSet dt = new DataSet())
                    {
                        da.Fill(dt, "Subjec_t");
                        guna2ComboBox2.DataSource = dt.Tables["Subjec_t"];
                        guna2ComboBox2.DisplayMember = "Subjec_t";
                        dt.Dispose();
                        Temizle();
                    }
                    da.Dispose();
                    Temizle();
                }
                connect.Close();
                connect.Dispose();
                Temizle();
            }
            Temizle();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim Dosyaları(*.jpg,*.jpeg,*.png) | *.jpg;*.jpeg;*.png";
            ofd.Title = "Resim Dosyası";
            ofd.Multiselect = false;
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    byte[] imagebyte = ConvertImageToByte(Image.FromFile(ofd.FileName));
                    guna2PictureBox1.Image = ConvertByteToİmage(imagebyte);
                    guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch
                {
                    Dialog("Resim Dosyası Bozuk Başka Bir Resim Deneyin", this.FindForm(), Properties.Settings.Default.Theme);
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(guna2TextBox2.Text) || string.IsNullOrEmpty(guna2TextBox3.Text) || string.IsNullOrEmpty(guna2TextBox4.Text))
            {
                Dialog("Boşluk Bırakılmaz", this.FindForm(), Properties.Settings.Default.Theme);
            }
            else
            {
                if (guna2NumericUpDown3.Value == 0)
                {
                    Dialog("Kitap Sayısı 0 Olamaz", this.FindForm(), Properties.Settings.Default.Theme);
                }
                else if (guna2NumericUpDown3.Value > 0)
                {
                    guna2TextBox1.Text = Regex.Replace(guna2TextBox1.Text, @"[^\w\s]", "");
                    if (guna2PictureBox1.Image == null)
                    {
                        using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                        {
                            connect.Open();

                            using (SqlCommand cmd = new SqlCommand("update Book set KitapAdi=@p1, KitapYazarı=@p2, KitapTürü=@p3,KitapKonusu=@p4,KitapBarkod=@p5,KitapSayfaSayısı=@p6,KaçKitapVar=@p7 where KitapAdi='"+KitapAdı+"'", connect))
                            {
                                cmd.Parameters.AddWithValue("@p1", guna2TextBox2.Text);
                                cmd.Parameters.AddWithValue("@p2", guna2TextBox3.Text);
                                cmd.Parameters.AddWithValue("@p3", guna2ComboBox1.Text);
                                cmd.Parameters.AddWithValue("@p4", guna2ComboBox2.Text);
                                cmd.Parameters.AddWithValue("@p5", guna2TextBox4.Text);
                                cmd.Parameters.AddWithValue("@p6", guna2NumericUpDown2.Value.ToString());
                                cmd.Parameters.AddWithValue("@p7", guna2NumericUpDown3.Value.ToString());
                                cmd.ExecuteNonQuery();
                                Dialog("Kitap Güncellendi", this.FindForm(), Properties.Settings.Default.Theme);
                                Güncelle();
                            }
                            connect.Close();
                            connect.Dispose();
                            Temizle();
                        }
                    }
                    else
                    {
                        if (guna2PictureBox1.Image != ımage)
                        {
                            using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                            {
                                connect.Open();

                                using (SqlCommand cmd = new SqlCommand("update Book set KitapAdi=@p1, KitapResim=@p8,KitapYazarı=@p2, KitapTürü=@p3,KitapKonusu=@p4,KitapBarkod=@p5,KitapSayfaSayısı=@p6,KaçKitapVar=@p7 where KitapAdi='"+KitapAdı+"'", connect))
                                {
                                    cmd.Parameters.AddWithValue("@p1", guna2TextBox2.Text);
                                    cmd.Parameters.AddWithValue("@p2", guna2TextBox3.Text);
                                    cmd.Parameters.AddWithValue("@p3", guna2ComboBox1.Text);
                                    cmd.Parameters.AddWithValue("@p4", guna2ComboBox2.Text);
                                    cmd.Parameters.AddWithValue("@p5", guna2TextBox4.Text);
                                    cmd.Parameters.AddWithValue("@p6", guna2NumericUpDown2.Value.ToString());
                                    cmd.Parameters.AddWithValue("@p7", guna2NumericUpDown3.Value.ToString());
                                    cmd.Parameters.AddWithValue("@p8", ConvertImageToByte(guna2PictureBox1.Image));
                                    cmd.ExecuteNonQuery();
                                    Dialog("Kitap Güncellendi", this.FindForm(), Properties.Settings.Default.Theme);
                                    Güncelle();
                                }
                                connect.Close();
                                connect.Dispose();
                                Temizle();
                            }
                        }
                        else
                        {
                            using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                            {
                                connect.Open();

                                using (SqlCommand cmd = new SqlCommand("update Book set KitapAdi=@p1, KitapYazarı=@p2, KitapTürü=@p3,KitapKonusu=@p4,KitapBarkod=@p5,KitapSayfaSayısı=@p6,KaçKitapVar=@p7 where KitapAdi='"+KitapAdı+"'", connect))
                                {
                                    cmd.Parameters.AddWithValue("@p1", guna2TextBox2.Text);
                                    cmd.Parameters.AddWithValue("@p2", guna2TextBox3.Text);
                                    cmd.Parameters.AddWithValue("@p3", guna2ComboBox1.Text);
                                    cmd.Parameters.AddWithValue("@p4", guna2ComboBox2.Text);
                                    cmd.Parameters.AddWithValue("@p5", guna2TextBox4.Text);
                                    cmd.Parameters.AddWithValue("@p6", guna2NumericUpDown2.Value.ToString());
                                    cmd.Parameters.AddWithValue("@p7", guna2NumericUpDown3.Value.ToString());
                                    cmd.ExecuteNonQuery();
                                    Dialog("Kitap Güncellendi", this.FindForm(), Properties.Settings.Default.Theme);
                                    Güncelle();
                                }
                                connect.Close();
                                connect.Dispose();
                                Temizle();
                            }
                        }
                    }
                }
            }
        }

        private void Kitap_Düzenle_VisibleChanged(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Clear();
            using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("select * from Book", connect))
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

            using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
            {
                connect.Open();
                using (SqlDataAdapter da = new SqlDataAdapter("select * from BookType", connect))
                {
                    using (DataSet dt = new DataSet())
                    {
                        da.Fill(dt, "Typ_e");
                        guna2ComboBox1.DataSource = dt.Tables["Typ_e"];
                        guna2ComboBox1.DisplayMember = "Typ_e";
                        dt.Dispose();
                        Temizle();
                    }
                    da.Dispose();
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
