using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace WindowsFormsApp1.KULLANICI_DENETİMİ
{
    public partial class Kategori_Kaldır : UserControl
    {
        string soon;
        public Kategori_Kaldır()
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

                using (SqlCommand cmd = new SqlCommand("select * from BookType", connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            guna2DataGridView1.Rows.Add(reader["Typ_e"]);
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

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2TextBox1.Text = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void Kategori_Kaldır_Load(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("select * from BookType", connect))
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            guna2DataGridView1.Rows.Add(reader["Typ_e"]);
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

            using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("select * from BookType", connect))
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
            }
            Temizle();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
            {
                connect.Open();

                if (guna2TextBox1.Text != "")
                {
                    using (SqlCommand cmd  = new SqlCommand("delete from BookType where Typ_e='" + guna2TextBox1.Text + "'", connect))
                    {
                        cmd.ExecuteNonQuery();
                        Dialog("Kategori Kaldırıldı", this.FindForm(), Properties.Settings.Default.Theme);
                        cmd.Dispose();
                        Güncelle();
                        Temizle();
                    }
                    using (SqlConnection connect1 = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                    {
                        connect1.Open();
                        using (SqlCommand cmd1 = new SqlCommand("drop table [" + guna2TextBox1.Text + "]", connect1))
                        {
                            cmd1.ExecuteNonQuery();
                            Güncelle();
                            Temizle();
                        }
                        connect1.Close();
                        connect1.Dispose();
                        Temizle();
                    }
                    using (SqlConnection connect2 = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                    {
                        using (SqlDataAdapter da1 = new SqlDataAdapter("select * from BookType", connect2))
                        {
                            using (DataSet ds1 = new DataSet())
                            {
                                da1.Fill(ds1, "Typ_e");
                                guna2ComboBox1.DataSource = ds1.Tables["Typ_e"];
                                guna2ComboBox1.DisplayMember = "Typ_e";
                                ds1.Dispose();
                                Temizle();
                            }
                            da1.Dispose();
                            Temizle();
                        }
                        Temizle();
                        guna2TextBox1.Clear();
                    }
                    Temizle();
                }
                else
                {
                    Dialog("Böyle Bir Kategori Bulunmadı", this.FindForm(), Properties.Settings.Default.Theme);
                }

                connect.Close();
                connect.Dispose();
                Temizle();
            }
            Temizle();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (guna2TextBox2.Text != "")
            {
                try
                {
                    using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                    {
                        connect.Open();

                        using (SqlCommand cmd = new SqlCommand("delete from [" + guna2ComboBox1.Text + "] where Subjec_t='"+guna2TextBox2.Text+"'", connect))
                        {
                            cmd.ExecuteNonQuery();
                            Dialog("Kategori Kaldırıldı",this.FindForm(), Properties.Settings.Default.Theme);
                            cmd.Dispose();
                            Temizle();
                        }

                        connect.Close();
                        connect.Dispose();
                        Temizle();

                        guna2DataGridView2.Rows.Clear();
                        using (SqlConnection connect1 = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                        {
                            connect1.Open();
                            using (SqlCommand cmd1 = new SqlCommand("select * from [" + guna2ComboBox1.Text + "]", connect1))
                            {
                                using (SqlDataReader reader = cmd1.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        guna2DataGridView2.Rows.Add(reader["Subjec_t"]);
                                    }
                                }
                                cmd1.Dispose();
                                Temizle();
                            }
                            connect1.Close();
                            connect1.Dispose();
                            Temizle();
                        }
                        Temizle();
                    }
                }
                catch
                {
                    Dialog("Böyle Bir Kategöri Bulunmamaktadır", this.FindForm(), Properties.Settings.Default.Theme);
                }
            }
            else
            {
                Dialog("Böyle Bir Kategöri Bulunmamaktadır", this.FindForm(), Properties.Settings.Default.Theme);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2DataGridView2.Rows.Clear();
            using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
            {
                connect.Open();
                using (SqlCommand cmd = new SqlCommand("select * from ["+guna2ComboBox1.Text+"]",connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            guna2DataGridView2.Rows.Add(reader["Subjec_t"]);
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

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2TextBox2.Text = guna2DataGridView2.CurrentRow.Cells[0].Value.ToString();
        }

        private void guna2Button1_VisibleChanged(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Clear();
            using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("select * from BookType", connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            guna2DataGridView1.Rows.Add(reader["Typ_e"]);
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

            using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("select * from BookType", connect))
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
            }
            Temizle();
        }
    }
}
