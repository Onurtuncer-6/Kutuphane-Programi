using Guna.UI2.WinForms;
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
    public partial class Kitapp_Ver : UserControl
    {
        public Kitapp_Ver()
        {
            InitializeComponent();
        }
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
            if (string.IsNullOrEmpty(guna2TextBox1.Text)) { Dialog("Boş Bırakılmaz!", this.FindForm(), Properties.Settings.Default.Theme); }
            else
            {
                using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                {
                    connect.Open();
                    using (SqlCommand cmd = new SqlCommand("select * from Book where KitapBarkod='" + guna2TextBox1.Text + "'", connect))
                    {
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                byte[] KitapResim = null;
                                string Kitap_Adı = rdr["KitapAdi"].ToString();
                                if (rdr["KitapResim"].ToString() != "")
                                {
                                    KitapResim = (byte[])rdr["KitapResim"];
                                }
                                string KitapYazarı = rdr["KitapYazarı"].ToString();
                                string KaçKitapVar = rdr["KaçKitapVar"].ToString();
                                string KaçKitapKullanımda = rdr["KaçKitapKullanımda"].ToString();
                                userControl11.Visible = true;

                                if (KitapResim != null) { guna2PictureBox1.Image = ConvertByteToİmage(KitapResim); }
                                else { guna2PictureBox1.Image = null; }
                                label2.Text = "Kitap Adı: " + Kitap_Adı;
                                label3.Text = "Kitap Yazarı: " + KitapYazarı;
                                WindowsFormsApp1.KULLANICI_DENETİMİ.Kitap_Ver.UserControl1.th.Kitap_Adı = Kitap_Adı;
                                WindowsFormsApp1.KULLANICI_DENETİMİ.Kitap_Ver.UserControl1.th.Kitap_Barcode = guna2TextBox1.Text;
                            }
                            else
                            {
                                Dialog("Böyle Bir Kitap Bulunmamaktadır", this.FindForm(), Properties.Settings.Default.Theme);
                                userControl11.Visible = false;
                                guna2PictureBox1.Image = null;
                                label2.Text = "";
                                label3.Text = "";
                            }
                        }
                    }
                    connect.Close();
                }
            }
        }
    }
}