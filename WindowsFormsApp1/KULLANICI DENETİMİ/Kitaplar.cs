using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using WindowsFormsApp1.FORMLAR;

namespace WindowsFormsApp1.KULLANICI_DENETİMİ
{
    public partial class Kitaplar : System.Windows.Forms.UserControl
    {
        public static Kitaplar th;
        public FlowLayoutPanel flowLayoutPanel;

        private void Temizle()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        public Kitaplar()
        {
            InitializeComponent();
            th = this;
            flowLayoutPanel = flowLayoutPanel1;
        }

        internal void Panel_DoubleClick(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("select * from Book where KitapAdi='" + panel.Name.ToString() + "'", connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string KitapResim = reader["KitapResim"].ToString();
                            string KaçKitapVar = reader["KaçKitapVar"].ToString();
                            string KaçKitapKullanımda = reader["KaçKitapKullanımda"].ToString();
                            string KitapBarkod = reader["KitapBarkod"].ToString();

                            Temizle();
                            Form4 form4 = new Form4();
                            form4.KitapAdı = panel.Name;
                            if (KitapResim != "")
                            {
                                form4.KitapResim = KitapResim;
                            }
                            else
                            {
                                form4.KitapResim = "";
                            }
                            form4.KaçKitapKullanımda = KaçKitapKullanımda;
                            form4.KaçKitapVar = KaçKitapVar;
                            form4.KitapBarkod = KitapBarkod;
                            form4.ShowDialog();
                        }
                    }
                }

                connect.Close();
                connect.Dispose();
                Temizle();
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox1.Text == "")
            {

            }
            else
            {
                if (guna2ComboBox1.Text == "Kategoriler")
                {
                    kategoriler1.Visible = true;
                    kitap_Bilgileri1.Visible = false;
                }
                else
                {
                    kategoriler1.Visible = false;
                    kitap_Bilgileri1.Visible = true;
                }
            }
        }
    }
}
