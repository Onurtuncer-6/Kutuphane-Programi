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
using WindowsFormsApp1.KULLANICI_DENETİMİ;

namespace WindowsFormsApp1.FORMLAR
{
    public partial class Form6 : Form
    {
        public string KitapAdı;
        public string KitapBarkod;
        public string KaçKitapkULLANIMDA;
        bool trufalse;
        public Form6()
        {
            InitializeComponent();
        }
        private void Dialog(string Message, Form th, string theme)
        {
            trufalse = false;
            using (Guna2MessageDialog dialog = new Guna2MessageDialog())
            {
                dialog.Text = Message;
                dialog.Parent = th;
                dialog.Buttons = MessageDialogButtons.YesNo;
                dialog.Icon = MessageDialogIcon.Information;
                if (theme == "dark-mode")
                {
                    dialog.Style = MessageDialogStyle.Dark;
                }
                else if (theme == "light-mode")
                {
                    dialog.Style = MessageDialogStyle.Light;
                }
                DialogResult rsul = dialog.Show();
                if (rsul == DialogResult.Yes)
                {
                    trufalse = true;
                }
                else if (rsul == DialogResult.No)
                {
                    
                }
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
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
            {
                connect.Open();

                using (SqlDataAdapter da = new SqlDataAdapter("select * from BookUse where KitapAdi='" + KitapAdı + "'", connect))
                {
                    using (DataSet ds = new DataSet())
                    {
                        da.Fill(ds, "KitapAlanınAdı");
                        guna2ComboBox1.DataSource = ds.Tables["KitapAlanınAdı"];
                        guna2ComboBox1.DisplayMember = "KitapAlanınAdı";
                        ds.Dispose();
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

        private void Form6_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Theme.ToString() == "dark-mode")
            {
                this.BackColor = Color.FromArgb(30, 30, 30);
                this.ForeColor = Color.White;
            }
            if (Properties.Settings.Default.Theme.ToString() == "light-mode")
            {
                this.BackColor = Color.FromArgb(248, 249, 250);
                this.ForeColor = Color.Black;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2ComboBox1.Text != "")
            {
                using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                {
                    connect.Open();

                    using (SqlCommand cmd = new SqlCommand("delete from BookUse Where KitapAlanınAdı='" + guna2ComboBox1.Text + "'", connect))
                    {
                        using (SqlConnection connect1 = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                        {
                            connect1.Open();
                            int kackitapkullanımda = Convert.ToInt32(KaçKitapkULLANIMDA);
                            int count = kackitapkullanımda - 1;
                            using (SqlCommand cmd1 = new SqlCommand("update Book set KaçKitapKullanımda='" + count + "' where KitapAdi='" + KitapAdı + "'", connect1))
                            {
                                cmd1.ExecuteNonQuery();
                                cmd1.Dispose();
                                Temizle();
                            }
                            connect1.Close();
                            connect1.Dispose(); Temizle();
                        }
                        Dialog("Kitap Teslim Edilsinmi", this.FindForm(), Properties.Settings.Default.Theme);
                        if (trufalse == true)
                        {
                            cmd.ExecuteNonQuery();
                            this.Close();
                            WindowsFormsApp1.FORMLAR.Form4.fr.Close();
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
                using (Guna2MessageDialog dialog = new Guna2MessageDialog())
                {
                    dialog.Text = "Öğrenci Bulunamadı";
                    dialog.Parent = this.FindForm();
                    dialog.Buttons = MessageDialogButtons.OK;
                    dialog.Icon = MessageDialogIcon.Information;
                    if (Properties.Settings.Default.Theme == "dark-mode")
                    {
                        dialog.Style = MessageDialogStyle.Dark;
                    }
                    else if (Properties.Settings.Default.Theme == "light-mode")
                    {
                        dialog.Style = MessageDialogStyle.Light;
                    }
                    dialog.Show();
                    dialog.Dispose();
                    Temizle();

                }
                Temizle();
            }
            
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            WindowsFormsApp1.FORMLAR.Form4.fr.Close();
        }
    }
}
