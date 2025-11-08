namespace WindowsFormsApp1.KULLANICI_DENETİMİ
{
    partial class Kitaplar
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.kategoriler1 = new WindowsFormsApp1.KULLANICI_DENETİMİ.Misafir_Kitap.Kategoriler();
            this.kitap_Bilgileri1 = new WindowsFormsApp1.KULLANICI_DENETİMİ.Misafir_Kitap.Kitap_Bilgileri();
            this.SuspendLayout();
            // 
            // guna2ComboBox1
            // 
            this.guna2ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.guna2ComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2ComboBox1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.guna2ComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.guna2ComboBox1.ItemHeight = 30;
            this.guna2ComboBox1.Items.AddRange(new object[] {
            "Kategoriler",
            "Kitap Bilgileri"});
            this.guna2ComboBox1.Location = new System.Drawing.Point(367, 3);
            this.guna2ComboBox1.Name = "guna2ComboBox1";
            this.guna2ComboBox1.Size = new System.Drawing.Size(214, 36);
            this.guna2ComboBox1.TabIndex = 0;
            this.guna2ComboBox1.SelectedIndexChanged += new System.EventHandler(this.guna2ComboBox1_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 97);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(940, 521);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // kategoriler1
            // 
            this.kategoriler1.Location = new System.Drawing.Point(3, 45);
            this.kategoriler1.Name = "kategoriler1";
            this.kategoriler1.Size = new System.Drawing.Size(940, 46);
            this.kategoriler1.TabIndex = 1;
            // 
            // kitap_Bilgileri1
            // 
            this.kitap_Bilgileri1.Location = new System.Drawing.Point(0, 45);
            this.kitap_Bilgileri1.Name = "kitap_Bilgileri1";
            this.kitap_Bilgileri1.Size = new System.Drawing.Size(940, 46);
            this.kitap_Bilgileri1.TabIndex = 0;
            this.kitap_Bilgileri1.Visible = false;
            // 
            // Kitaplar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kitap_Bilgileri1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.kategoriler1);
            this.Controls.Add(this.guna2ComboBox1);
            this.Name = "Kitaplar";
            this.Size = new System.Drawing.Size(946, 621);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;
        private Misafir_Kitap.Kategoriler kategoriler1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Misafir_Kitap.Kitap_Bilgileri kitap_Bilgileri1;
    }
}
