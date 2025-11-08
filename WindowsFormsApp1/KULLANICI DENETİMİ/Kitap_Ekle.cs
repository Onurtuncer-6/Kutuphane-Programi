using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Method;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1.KULLANICI_DENETİMİ
{
    public partial class Kitap_Ekle : UserControl
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

        public Kitap_Ekle()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
            {
                connect.Open();
                using (SqlDataAdapter da = new SqlDataAdapter("select * from ["+ guna2ComboBox1.Text +"]", connect))
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

        private void Kitap_Ekle_Load(object sender, EventArgs e)
        {
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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(guna2TextBox1.Text) || string.IsNullOrEmpty(guna2TextBox2.Text) || string.IsNullOrEmpty(guna2TextBox3.Text) || guna2ComboBox2.Text == "")
            {
                Dialog("Boş Bırakılmaz", this.FindForm(), Properties.Settings.Default.Theme);
            }
            else
            {
                if (guna2TextBox5.Text == "")
                {
                    guna2TextBox1.Text = Regex.Replace(guna2TextBox1.Text, @"[^\w\s]", "");
                    using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                    {
                        connect.Open();
                        using (SqlCommand cmd = new SqlCommand("select * from Book where KitapAdi='" + guna2TextBox1.Text + "'", connect))
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    Dialog("Bu Kitap Zaten Daha Önceden Eklenmiş", this.FindForm(), Properties.Settings.Default.Theme);
                                }
                                else
                                {
                                    using (SqlConnection connect1 = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                                    {
                                        connect1.Open();
                                        if (guna2PictureBox1.Image != null)
                                        {
                                            using (SqlCommand cmd1 = new SqlCommand("insert into Book(KitapAdi,KitapResim,KitapYazarı,KitapTürü,KitapKonusu,KitapBarkod,KitapEklenmeTarihi,KitapSayfaSayısı,KaçKitapVar,KaçKitapKullanımda) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)",connect1))
                                            {
                                                cmd1.Parameters.AddWithValue("@p1", guna2TextBox1.Text);
                                                cmd1.Parameters.AddWithValue("@p2", ConvertImageToByte(guna2PictureBox1.Image));
                                                cmd1.Parameters.AddWithValue("@p3", guna2TextBox2.Text);
                                                cmd1.Parameters.AddWithValue("@p4", guna2ComboBox1.Text);
                                                cmd1.Parameters.AddWithValue("@p5", guna2ComboBox2.Text);
                                                cmd1.Parameters.AddWithValue("@p6", guna2TextBox3.Text);
                                                cmd1.Parameters.AddWithValue("@p7", DateTime.Now.Date);
                                                cmd1.Parameters.AddWithValue("@p8", guna2NumericUpDown2.Value.ToString());
                                                if (guna2NumericUpDown1.Value > 0)
                                                    cmd1.Parameters.AddWithValue("@p9", guna2NumericUpDown1.Value.ToString());
                                                else
                                                    cmd1.Parameters.AddWithValue("@p9", 1);
                                                cmd1.Parameters.AddWithValue("@p10", 0.ToString());
                                                cmd1.ExecuteNonQuery();

                                                Dialog("Kitap Eklendi", this.FindForm(), Properties.Settings.Default.Theme);

                                                guna2PictureBox1.Image = null;
                                                guna2TextBox1.Clear();
                                                guna2TextBox2.Clear();
                                                guna2TextBox3.Clear();
                                                guna2TextBox5.Clear();
                                                
                                            }
                                        }
                                        else
                                        {
                                            using (SqlCommand cmd1 = new SqlCommand("insert into Book(KitapAdi,KitapYazarı,KitapTürü,KitapKonusu,KitapBarkod,KitapEklenmeTarihi,KitapSayfaSayısı,KaçKitapVar,KaçKitapKullanımda) values (@p1,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", connect1))
                                            {
                                                cmd1.Parameters.AddWithValue("@p1", guna2TextBox1.Text);
                                                cmd1.Parameters.AddWithValue("@p3", guna2TextBox2.Text);
                                                cmd1.Parameters.AddWithValue("@p4", guna2ComboBox1.Text);
                                                cmd1.Parameters.AddWithValue("@p5", guna2ComboBox2.Text);
                                                cmd1.Parameters.AddWithValue("@p6", guna2TextBox3.Text);
                                                cmd1.Parameters.AddWithValue("@p7", DateTime.Now.Date);
                                                cmd1.Parameters.AddWithValue("@p8", guna2NumericUpDown2.Value.ToString());
                                                if (guna2NumericUpDown1.Value > 0)
                                                    cmd1.Parameters.AddWithValue("@p9", guna2NumericUpDown1.Value.ToString());
                                                else
                                                    cmd1.Parameters.AddWithValue("@p9", 1);
                                                cmd1.Parameters.AddWithValue("@p10", 0.ToString());
                                                cmd1.ExecuteNonQuery();

                                                Dialog("Kitap Eklendi", this.FindForm(), Properties.Settings.Default.Theme);

                                                guna2PictureBox1.Image = null;
                                                guna2TextBox1.Clear();
                                                guna2TextBox2.Clear();
                                                guna2TextBox3.Clear();
                                                guna2TextBox5.Clear();

                                            }
                                        }
                                        connect1.Close();
                                        connect1.Dispose();
                                        Temizle();
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
                else if (guna2TextBox5.Text != "")
                {
                    using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                    {
                        connect.Open();
                        using (SqlCommand cmd = new SqlCommand("select * from Book where KitapAdi='" + guna2TextBox1.Text + "'", connect))
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    Dialog("Bu Kitap Zaten Daha Önceden Eklenmiş", this.FindForm(), Properties.Settings.Default.Theme);
                                }
                                else
                                {
                                    using (SqlConnection connect1 = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                                    {
                                        connect1.Open();
                                        if (guna2PictureBox1.Image != null)
                                        {
                                            using (SqlCommand cmd1 = new SqlCommand("insert into Book(KitapAdi,KitapResim,KitapYazarı,KitapTürü,KitapKonusu,KitapBarkod,KitapEklenmeTarihi,KitapSayfaSayısı,KaçKitapVar,KaçKitapKullanımda,KitapAçıklaması) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", connect1))
                                            {
                                                cmd1.Parameters.AddWithValue("@p1", guna2TextBox1.Text);
                                                if (guna2PictureBox1.Image != null)
                                                {
                                                    cmd1.Parameters.AddWithValue("@p2", ConvertImageToByte(guna2PictureBox1.Image));
                                                }
                                                else
                                                {
                                                    cmd1.Parameters.AddWithValue("@p2", null);
                                                }
                                                cmd1.Parameters.AddWithValue("@p3", guna2TextBox2.Text);
                                                cmd1.Parameters.AddWithValue("@p4", guna2ComboBox1.Text);
                                                cmd1.Parameters.AddWithValue("@p5", guna2ComboBox2.Text);
                                                cmd1.Parameters.AddWithValue("@p6", guna2TextBox3.Text);
                                                cmd1.Parameters.AddWithValue("@p7", DateTime.Now.Date);
                                                cmd1.Parameters.AddWithValue("@p8", guna2NumericUpDown2.Value.ToString());
                                                cmd1.Parameters.AddWithValue("@p9", guna2NumericUpDown1.Value.ToString());
                                                cmd1.Parameters.AddWithValue("@p10", 0.ToString());
                                                cmd1.Parameters.AddWithValue("@p11", guna2TextBox5.Text);
                                                cmd1.ExecuteNonQuery();

                                                Dialog("Kitap Eklendi", this.FindForm(), Properties.Settings.Default.Theme);

                                                guna2PictureBox1.Image = null;
                                                guna2TextBox1.Clear();
                                                guna2TextBox2.Clear();
                                                guna2TextBox3.Clear();
                                                guna2TextBox5.Clear();

                                            }
                                        }
                                        else
                                        {
                                            using (SqlCommand cmd1 = new SqlCommand("insert into Book(KitapAdi,KitapYazarı,KitapTürü,KitapKonusu,KitapBarkod,KitapEklenmeTarihi,KitapSayfaSayısı,KaçKitapVar,KaçKitapKullanımda,KitapAçıklaması) values (@p1,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", connect1))
                                            {
                                                cmd1.Parameters.AddWithValue("@p1", guna2TextBox1.Text);
                                                cmd1.Parameters.AddWithValue("@p3", guna2TextBox2.Text);
                                                cmd1.Parameters.AddWithValue("@p4", guna2ComboBox1.Text);
                                                cmd1.Parameters.AddWithValue("@p5", guna2ComboBox2.Text);
                                                cmd1.Parameters.AddWithValue("@p6", guna2TextBox3.Text);
                                                cmd1.Parameters.AddWithValue("@p7", DateTime.Now.Date);
                                                cmd1.Parameters.AddWithValue("@p8", guna2NumericUpDown2.Value.ToString());
                                                cmd1.Parameters.AddWithValue("@p9", guna2NumericUpDown1.Value.ToString());
                                                cmd1.Parameters.AddWithValue("@p10", 0.ToString());
                                                cmd1.Parameters.AddWithValue("@p11", guna2TextBox5.Text);
                                                cmd1.ExecuteNonQuery();

                                                Dialog("Kitap Eklendi", this.FindForm(), Properties.Settings.Default.Theme);

                                                guna2PictureBox1.Image = null;
                                                guna2TextBox1.Clear();
                                                guna2TextBox2.Clear();
                                                guna2TextBox3.Clear();
                                                guna2TextBox5.Clear();

                                            }
                                        }
                                        connect1.Close();
                                        connect1.Dispose();
                                        Temizle();
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

        private void Kitap_Ekle_VisibleChanged(object sender, EventArgs e)
        {
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