using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Method;
using Guna.UI2.WinForms;

namespace WindowsFormsApp1.FORMLAR
{
    public partial class Form1 : Form
    {
        METHOD mETHOD;
        public Form1()
        {
            InitializeComponent();

            mETHOD = new METHOD();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Theme.ToString() == "dark-mode")
            {
                this.BackColor = Color.FromArgb(30, 30, 30);
                this.ForeColor = Color.White;
                button3.BackgroundImage = Properties.Resources.light_bulb;
                button3.BackgroundImageLayout = ImageLayout.Stretch;
            }
            if (Properties.Settings.Default.Theme.ToString() == "light-mode")
            {
                this.BackColor = Color.FromArgb(248, 249, 250);
                this.ForeColor = Color.Black;
                button3.BackgroundImage = Properties.Resources.night_mode;
                button3.BackgroundImageLayout = ImageLayout.Stretch;
                guna2TextBox1.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Theme.ToString() == "dark-mode")
            {
                guna2MessageDialog2.Show();
                this.BackColor = Color.FromArgb(248, 249, 250);
                this.ForeColor = Color.Black;
                button3.BackgroundImage = Properties.Resources.night_mode;
                Properties.Settings.Default.Theme = "light-mode";
                Properties.Settings.Default.Save();
            }
            else
            {
                guna2MessageDialog1.Show();
                this.BackColor = Color.FromArgb(30, 30, 30);
                this.ForeColor = Color.White;
                button3.BackgroundImage = Properties.Resources.light_bulb;
                Properties.Settings.Default.Theme = "dark-mode";
                Properties.Settings.Default.Save();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(guna2TextBox1.Text) || string.IsNullOrEmpty(guna2TextBox2.Text))
            {
                mETHOD.Dialog("Boş Bırakılmaz", this, Properties.Settings.Default.Theme, mETHOD);
            }
            else
            {
                using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                {
                    connect.Open();
                    using (SqlCommand command = new SqlCommand("select * from Manager where Username=@p1 and Passwords=@p2", connect))
                    {
                        command.Parameters.AddWithValue("@p1", guna2TextBox1.Text);
                        command.Parameters.AddWithValue("@p2", guna2TextBox2.Text);
                        using (SqlDataReader rd = command.ExecuteReader())
                        {
                            if (rd.Read())
                            {
                                Random random = new Random();
                                int rand = random.Next(10000, 40000);
                                label4.Text = rand.ToString();
                                guna2Panel2.Visible = true;
                                guna2TextBox1.Enabled = false;
                                guna2TextBox2.Enabled = false;
                                guna2Button1.Enabled = false;
                                mETHOD.Temizle();
                            }
                            else
                            {
                                mETHOD.Dialog("Kullanıcı Adı Veya Şifre Hatalı", this, Properties.Settings.Default.Theme, mETHOD);
                                mETHOD.Temizle();
                            }
                            mETHOD.Temizle();
                        }
                        command.Dispose();
                        mETHOD.Temizle();
                    }
                    connect.Close();
                    connect.Dispose();
                    mETHOD.Temizle();
                }
                mETHOD.Temizle();
            }
            mETHOD.Temizle();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox3.Text == label4.Text)
            {
                mETHOD.Temizle();
                Form2 guna2 = new Form2();
                guna2.Show();
                this.Hide();
            }
            else
            {
                mETHOD.Dialog("reCAPTCHA Doğrulanmadı", this ,Properties.Settings.Default.Theme, mETHOD);
            }
        }
    }
}

namespace Method
{
    public class METHOD
    {
        public void Temizle()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        public void Dialog(string Message,Form th,string theme,METHOD mETHOD)
        {
            using (Guna2MessageDialog dialog = new Guna2MessageDialog())
            {
                dialog.Text = Message;
                dialog.Parent = th.FindForm();
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
                mETHOD.Temizle();
            }
            mETHOD.Temizle();
        }
    }
}