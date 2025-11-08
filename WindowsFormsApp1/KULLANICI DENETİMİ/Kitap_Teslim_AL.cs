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
using Guna.UI2.WinForms;

namespace WindowsFormsApp1.KULLANICI_DENETİMİ
{
    public partial class Kitap_Teslim_AL : UserControl
    {
        public Kitap_Teslim_AL()
        {
            InitializeComponent();
        }
        string KitapAdi = "";
        string Sınıf = "";

        public byte[] ConvertImageToByte(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
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
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(guna2TextBox1.Text)) { Dialog("Boş Bırakılmaz", this.FindForm(), Properties.Settings.Default.Theme); }
            else
            {
                using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                {
                    connect.Open();
                    using (SqlCommand cmd = new SqlCommand("select * from Book where KitapBarkod='"+guna2TextBox1.Text+"'", connect))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                KitapAdi = reader["KitapAdi"].ToString();
                                label2.Text = "Kitap Adı: "+ reader["KitapAdi"].ToString();
                                label3.Text = "Kitabın Yazarı: "+reader["KitapYazarı"].ToString();
                                string KitapAdı = reader["KitapAdi"].ToString();

                                if (reader["KitapResim"].ToString() != "")
                                {
                                    guna2PictureBox1.Image = ConvertByteToİmage((byte[])reader["KitapResim"]);
                                }
                                else
                                {
                                    guna2PictureBox1.Image = null;
                                }

                                using (SqlConnection connect1 = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                                {
                                    using (SqlDataAdapter da = new SqlDataAdapter("select * from BookUse where KitapAdi='" + KitapAdı +"'", connect1))
                                    {
                                        using (DataSet ds = new DataSet())
                                        {
                                            da.Fill(ds, "KitapAdi");
                                            guna2ComboBox1.DataSource = ds.Tables["KitapAdi"];
                                            guna2ComboBox1.DisplayMember = "KitapAlanınAdı";
                                            guna2Panel1.Visible = true;
                                        }
                                    }
                                    connect1.Close();
                                }
                            }
                            else
                            {
                                Dialog("Böyle Bir Kitap Bulunmamaktadır", this.FindForm(), Properties.Settings.Default.Theme);
                            }
                        }
                    }
                    connect.Close();
                }
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool truefalse = false;
            using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("select * from BookUse where KitapAdi='" + KitapAdi + "'", connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["KitapAlanınAdı"].ToString() == guna2ComboBox1.Text)
                            {
                                Sınıf = reader["KitapAlanınSınıfı"].ToString();
                                truefalse = true;
                                break;
                            }
                        }

                        if (truefalse)
                        {
                            label5.Text = "Sınıfı: " + Sınıf;
                        }
                    }
                }
                connect.Close();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Guna2MessageDialog dialog = new Guna2MessageDialog();
            dialog.Buttons = MessageDialogButtons.YesNo;
            dialog.Parent = this.FindForm();
            dialog.Icon = MessageDialogIcon.Information;
            if (Properties.Settings.Default.Theme == "dark-mode")
            {
                dialog.Style = MessageDialogStyle.Dark;
            }
            else
            {
                dialog.Style = MessageDialogStyle.Light;
            }
                dialog.Text = guna2ComboBox1.Text + " Adlı " + Sınıf + " Sınıflı Öğrencinin Kitabı Teslim Edilsinmi";
            DialogResult dr = dialog.Show();
            switch (dr)
            {
                case DialogResult.Yes:
                    using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                    {
                        connect.Open();

                        using (SqlCommand cmd = new SqlCommand("select * from Book where KitapAdi='"+KitapAdi+"'",connect))
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string KaçKitapKullanımda = reader["KaçKitapKullanımda"].ToString();

                                    using (SqlConnection connect1 = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                                    {
                                        connect1.Open();
                                        int count = Convert.ToInt32(KaçKitapKullanımda);
                                        int a = count - 1;
                                        using (SqlCommand cmd1 = new SqlCommand("update Book set KaçKitapKullanımda='" + a.ToString() + "' where KitapAdi='"+KitapAdi+"'", connect1))
                                        {
                                            cmd1.ExecuteNonQuery();
                                        }
                                        connect1.Close();
                                        using (SqlConnection connect2 = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                                        {
                                            connect1.Open();
                                            using (SqlCommand cmd2 = new SqlCommand("delete from BookUse where KitapAdi='"+KitapAdi+ "' and KitapAlanınAdı='"+guna2ComboBox1.Text+"'", connect1))
                                            {
                                                cmd2.ExecuteNonQuery();
                                            }
                                            connect2.Close();
                                        }
                                    }
                                }
                            }
                        }

                        Dialog("Kitap Teslim Edildi ", this.FindForm(), Properties.Settings.Default.Theme);
                        connect.Close();
                        using (SqlConnection connect1 = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                        {
                            using (SqlDataAdapter da = new SqlDataAdapter("select * from BookUse where KitapAdi='" + KitapAdi + "'", connect1))
                            {
                                using (DataSet ds = new DataSet())
                                {
                                    da.Fill(ds, "KitapAdi");
                                    guna2ComboBox1.DataSource = ds.Tables["KitapAdi"];
                                    guna2ComboBox1.DisplayMember = "KitapAlanınAdı";
                                    guna2Panel1.Visible = true;
                                }
                            }
                            connect1.Close();
                        }

                    }
                    if (guna2ComboBox1.Text == "") { label5.Text = "Sınıfı: "; }
                        break;
                case DialogResult.No:
                    break;
            }
        }
    }
}
