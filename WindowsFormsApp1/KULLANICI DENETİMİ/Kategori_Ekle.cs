using System;
using System.CodeDom;
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

namespace WindowsFormsApp1.KULLANICI_DENETİMİ
{
    public partial class Kategori_Ekle : UserControl
    {
        public Kategori_Ekle()
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
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text != "")
            {
                using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                {
                    connect.Open();
                    using (SqlCommand cmd = new SqlCommand("insert into BookType(Typ_e) values ('" + guna2TextBox1.Text + "')", connect))
                    {
                        cmd.ExecuteNonQuery();
                        Dialog("Kitap Türü Eklendi", this.FindForm(), Properties.Settings.Default.Theme);
                        cmd.Dispose();
                        Temizle();

                    }
                    Temizle();
                    connect.Close();
                    connect.Dispose();
                    Temizle();
                }
                using (SqlConnection connect1 = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                {
                    using (SqlCommand cmd1 = new SqlCommand("create table ["+guna2TextBox1.Text+"](ID int IDENTITY(1,1),\nSubjec_t nvarchar(max))", connect1))
                    {
                        connect1.Open();
                        cmd1.ExecuteNonQuery();
                        Temizle();
                    }
                    Temizle();
                    connect1.Close();
                    connect1.Dispose();
                    Temizle();
                }
                using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                {
                    connect.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter("select Typ_e from BookType", connect))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            da.Fill(ds, "Typ_e");
                            guna2ComboBox1.DataSource = ds.Tables["Typ_e"];
                            guna2ComboBox1.DisplayMember = "Typ_e";
                            ds.Dispose();
                            Temizle();
                        }
                        da.Dispose();
                        Temizle();
                    }
                    Temizle();
                    connect.Close();
                    connect.Dispose();
                    Temizle();
                }
                Temizle();
            }
            else
            {
                Dialog("Boş Bırakılmaz", this.FindForm(), Properties.Settings.Default.Theme);
            }
            Temizle();
        }

        private void Kategori_Ekle_Load(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
            {
                connect.Open();
                
                using (SqlDataAdapter da = new SqlDataAdapter("select Typ_e from BookType", connect))
                {
                    using (DataSet ds = new DataSet())
                    {
                        da.Fill(ds, "Typ_e");
                        guna2ComboBox1.DataSource = ds.Tables["Typ_e"];
                        guna2ComboBox1.DisplayMember = "Typ_e";
                        ds.Dispose();
                        Temizle();
                    }
                    da.Dispose();
                    Temizle();
                }
                Temizle();
                connect.Close();
                connect.Dispose();
                Temizle();
            }
            Temizle();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox2.Text != "")
            {
                using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                {
                    connect.Open();

                    using (SqlCommand cmd = new SqlCommand("insert into ["+guna2ComboBox1.Text+"](Subjec_t) values ('" + guna2TextBox2.Text + "')", connect))
                    {
                        cmd.ExecuteNonQuery();
                        guna2TextBox2.Clear();
                        Dialog("Kategori Eklendi", this.FindForm(), Properties.Settings.Default.Theme);
                        cmd.Dispose();
                        Temizle();
                    }
                    Temizle();
                    connect.Close();
                    connect.Dispose();
                    Temizle();
                }
                Temizle();
            }
            else
            {
                Dialog("Boş Bırakılmaz", this.FindForm(), Properties.Settings.Default.Theme);
            }
        }

        private void Kategori_Ekle_VisibleChanged(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
            {
                connect.Open();

                using (SqlDataAdapter da = new SqlDataAdapter("select Typ_e from BookType", connect))
                {
                    using (DataSet ds = new DataSet())
                    {
                        da.Fill(ds, "Typ_e");
                        guna2ComboBox1.DataSource = ds.Tables["Typ_e"];
                        guna2ComboBox1.DisplayMember = "Typ_e";
                        ds.Dispose();
                        Temizle();
                    }
                    da.Dispose();
                    Temizle();
                }
                Temizle();
                connect.Close();
                connect.Dispose();
                Temizle();
            }
            Temizle();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}