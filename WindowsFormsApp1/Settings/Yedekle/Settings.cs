using Guna.UI2.WinForms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Settings.Yedekle
{
    public partial class Settings : UserControl
    {
        public static Settings settings;
        public Settings()
        {
            InitializeComponent();
            settings = this;
        }
        public string SeçilenFlashYolu { get; set; }
        public string SeçilenFlashAdı { get; set; }

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

        private void textBox1_Enter(object sender, EventArgs e)
        {
            timer1.Start();
            flowLayoutPanel1.Visible = true;
            flowLayoutPanel1.Controls.Clear();
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.DriveType == DriveType.Removable)
                {
                    if (drive.IsReady == true)
                    {
                        Show_Usb_Devices.Usb_Devices usbdeviceshow = new Show_Usb_Devices.Usb_Devices();
                        usbdeviceshow.label1.Text = drive.VolumeLabel.ToString() + " (" + drive.Name.ToString() + ")";
                        usbdeviceshow.FlashAdı = drive.VolumeLabel.ToString();
                        usbdeviceshow.FlashYolu = drive.Name.ToString();
                        usbdeviceshow.Name = drive.VolumeLabel.ToString();
                        flowLayoutPanel1.Controls.Add(usbdeviceshow);
                    }
                }
            }   
        }

        private async void textBox1_Leave(object sender, EventArgs e)
        {
            timer1.Stop();
            await Task.Delay(400);
            flowLayoutPanel1.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = true;
            flowLayoutPanel1.Controls.Clear();
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.DriveType == DriveType.Removable)
                {
                    if (drive.IsReady == true)
                    {
                        Show_Usb_Devices.Usb_Devices usbdeviceshow = new Show_Usb_Devices.Usb_Devices();
                        usbdeviceshow.label1.Text = drive.VolumeLabel.ToString() + " (" + drive.Name.ToString() + ")";
                        usbdeviceshow.FlashAdı = drive.VolumeLabel.ToString();
                        usbdeviceshow.FlashYolu = drive.Name.ToString();
                        usbdeviceshow.Name = drive.VolumeLabel.ToString();
                        flowLayoutPanel1.Controls.Add(usbdeviceshow);
                    }
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.DriveType == DriveType.Removable)
                {
                    if (drive.IsReady == true)
                    {
                        if (SeçilenFlashAdı == drive.VolumeLabel.ToString())
                        {
                            string path = @"" + drive.Name.ToString() + ""+DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")+"";
                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                                path = @"" + drive.Name.ToString() + "" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + "\\backup.bak";
                                using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kütüphane_Programı;Integrated Security=True;TrustServerCertificate=True"))
                                {
                                    connect.Open();

                                    SqlCommand cmd = new SqlCommand($"BACKUP DATABASE [Kütüphane_Programı] TO DISK = '{path}'",connect);
                                    cmd.CommandTimeout = 1800;
                                    cmd.ExecuteNonQuery();
                                    Dialog($"Veritabanı '{path}' Klasörüne Yedeklendi ", this.FindForm(), Properties.Settings.Default.Theme);

                                    connect.Close();
                                }
                            }
                        }
                    }
                }
            }
        }
        // SQL Server Express veri klasörünü Registry’den bul
        private string GetSqlDataPathFromSql()
        {
            string path = "";
            using (SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT SERVERPROPERTY('InstanceDefaultDataPath')", conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        path = result.ToString();
                }
                conn.Close();
            }

            // Eğer boş dönerse varsayılan yol
            if (string.IsNullOrEmpty(path))
                path = @"C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\";

            return path;
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Bak Dosyası (*.bak)|*.bak",
                Title = "Yedeği Seçin",
                Multiselect = false
            })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string basePath = GetSqlDataPathFromSql();
                    if (!Directory.Exists(basePath))
                    {
                        MessageBox.Show("SQL veri klasörü bulunamadı.");
                        return;
                    }

                    string dataFile = Path.Combine(basePath, "Kütüphane_Programı.mdf");
                    string logFile = Path.Combine(basePath, "Kütüphane_Programı_log.ldf");

                    string restoreQuery = $@"
ALTER DATABASE [Kütüphane_Programı] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

RESTORE DATABASE [Kütüphane_Programı]
FROM DISK = '{openFileDialog.FileName}'
WITH REPLACE,
MOVE 'Kütüphane_Programı' TO '{dataFile}',
MOVE 'Kütüphane_Programı_log' TO '{logFile}';

ALTER DATABASE [Kütüphane_Programı] SET MULTI_USER;
";

                    using (SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True"))
                    {
                        connect.Open();
                        SqlCommand cmd = new SqlCommand(restoreQuery, connect);
                        cmd.CommandTimeout = 1800;
                        cmd.ExecuteNonQuery();
                        connect.Close();

                        MessageBox.Show("Veri Tabanı Yedeği Yüklendi!");
                    }
                }
            }
        }
    }
}