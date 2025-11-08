using Guna.UI2.WinForms;
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

namespace WindowsFormsApp1.KULLANICI_DENETİMİ.Kitap_Ver
{
    public partial class UserControl1 : UserControl
    {
        public static UserControl1 th;
        public UserControl1()
        {
            InitializeComponent();
            th = this;
        }
        public string Kitap_Adı;
        public string Kitap_Barcode;

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
        private void UserControl1_Load(object sender, EventArgs e)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("select * from Book where KitapAdi='"+Kitap_Adı+"'", connect))
                {
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            string KaçKitapKullanımda = rd["KaçKitapKullanımda"].ToString();
                            string KaçKitapVar = rd["KaçKitapVar"].ToString();
                            int kaçkitapvar = Convert.ToInt32(KaçKitapVar);
                            int kaçkitapkullanımda = Convert.ToInt32(KaçKitapKullanımda);

                            if (kaçkitapkullanımda < kaçkitapvar)
                            {
                                using (SqlConnection connect1 = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                                {
                                    connect1.Open();
                                    using (SqlCommand cmd1 = new SqlCommand("insert into BookUse(KitapAdi,KitapAlanınAdı,KitapAlanınSınıfı,KitapAlanınNumarası,KitabınAlınmaTarihi,KitabınGeriVerileceğiTarih,KitapBarkod) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", connect1))
                                    {
                                        cmd1.Parameters.AddWithValue("@p1", Kitap_Adı);
                                        cmd1.Parameters.AddWithValue("@p2", guna2TextBox1.Text);
                                        cmd1.Parameters.AddWithValue("@p3", guna2TextBox2.Text);
                                        cmd1.Parameters.AddWithValue("@p4", guna2TextBox3.Text);
                                        cmd1.Parameters.AddWithValue("@p5", DateTime.Now.Date);
                                        if ((int)guna2NumericUpDown1.Value == 0)
                                        {
                                            cmd1.Parameters.AddWithValue("@p6", DateTime.Now.AddDays(30));
                                            Dialog("Kayıt Edildi\nKitabın Son Teslim Tarihi " + DateTime.Now.AddDays(30).ToString(),this.FindForm(),Properties.Settings.Default.Theme);
                                        }
                                        else
                                        {
                                            cmd1.Parameters.AddWithValue("@p6", DateTime.Now.AddDays((int)guna2NumericUpDown1.Value));
                                            Dialog("Kayıt Edildi\nKitabın Son Teslim Tarihi " + DateTime.Now.AddDays((int)guna2NumericUpDown1.Value).ToString(), this.FindForm(), Properties.Settings.Default.Theme);
                                        }
                                        cmd1.Parameters.AddWithValue("@p7", Kitap_Barcode);
                                        cmd1.ExecuteNonQuery();
                                        
                                        connect1.Close();
                                    }
                                    using (SqlConnection connect2 = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                                    {
                                        connect2.Open();

                                        int a = kaçkitapkullanımda + 1;
                                        using (SqlCommand cmd2 = new SqlCommand("update Book set KaçKitapKullanımda='" + a + "' where KitapAdi='"+Kitap_Adı+"'", connect2))
                                        {
                                            cmd2.ExecuteNonQuery();
                                        }

                                        connect2.Close();
                                    }
                                    connect.Close();
                                }
                            }
                            else if(kaçkitapkullanımda == kaçkitapvar) { Dialog("Bütün Kitaplar Kullanımda", this.FindForm(), Properties.Settings.Default.Theme); }
                        }
                    }
                }

                connect.Close();
            }
        }
    }
}