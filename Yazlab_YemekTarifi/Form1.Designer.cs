namespace Yazlab_YemekTarifi
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TxtAra = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbKategori = new Guna.UI2.WinForms.Guna2ComboBox();
            this.CmbMaliyet = new Guna.UI2.WinForms.Guna2ComboBox();
            this.CmbSiralama = new Guna.UI2.WinForms.Guna2ComboBox();
            this.Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnEkle = new Guna.UI2.WinForms.Guna2Button();
            this.BtnAra = new Guna.UI2.WinForms.Guna2Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.guna2ContextMenuStrip2 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.yemek_TarifiDataSet1 = new Yazlab_YemekTarifi.Yemek_TarifiDataSet();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yemek_TarifiDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtAra
            // 
            this.TxtAra.BackColor = System.Drawing.Color.DarkRed;
            this.TxtAra.BorderColor = System.Drawing.Color.DarkRed;
            this.TxtAra.BorderRadius = 15;
            this.TxtAra.BorderThickness = 2;
            this.TxtAra.CausesValidation = false;
            this.TxtAra.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtAra.DefaultText = "";
            this.TxtAra.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtAra.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtAra.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtAra.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtAra.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtAra.Font = new System.Drawing.Font("Malgun Gothic", 13.8F);
            this.TxtAra.ForeColor = System.Drawing.Color.DarkRed;
            this.TxtAra.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtAra.Location = new System.Drawing.Point(5, 16);
            this.TxtAra.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TxtAra.Name = "TxtAra";
            this.TxtAra.PasswordChar = '\0';
            this.TxtAra.PlaceholderText = "Yemek Tarifi Ara";
            this.TxtAra.SelectedText = "";
            this.TxtAra.Size = new System.Drawing.Size(915, 88);
            this.TxtAra.TabIndex = 0;
            this.TxtAra.TextChanged += new System.EventHandler(this.TxtAra_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(168, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sonuçları Filtreleyin :";
            // 
            // CmbKategori
            // 
            this.CmbKategori.BackColor = System.Drawing.Color.Transparent;
            this.CmbKategori.BorderColor = System.Drawing.Color.Maroon;
            this.CmbKategori.BorderRadius = 10;
            this.CmbKategori.BorderThickness = 3;
            this.CmbKategori.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbKategori.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CmbKategori.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CmbKategori.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CmbKategori.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CmbKategori.ItemHeight = 30;
            this.CmbKategori.Items.AddRange(new object[] {
            "Kategoriler"});
            this.CmbKategori.Location = new System.Drawing.Point(403, 128);
            this.CmbKategori.Name = "CmbKategori";
            this.CmbKategori.Size = new System.Drawing.Size(133, 36);
            this.CmbKategori.TabIndex = 2;
            this.CmbKategori.SelectedIndexChanged += new System.EventHandler(this.CmbKategori_SelectedIndexChanged);
            // 
            // CmbMaliyet
            // 
            this.CmbMaliyet.BackColor = System.Drawing.Color.Transparent;
            this.CmbMaliyet.BorderColor = System.Drawing.Color.Maroon;
            this.CmbMaliyet.BorderRadius = 10;
            this.CmbMaliyet.BorderThickness = 3;
            this.CmbMaliyet.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbMaliyet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMaliyet.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CmbMaliyet.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CmbMaliyet.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CmbMaliyet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CmbMaliyet.ItemHeight = 30;
            this.CmbMaliyet.Items.AddRange(new object[] {
            "Tüm Tarifler",
            "0-100 TL",
            "100-200 TL",
            "200-300 TL",
            "300-400 TL",
            "400-500 TL",
            "500-600 TL",
            "700-800 TL"});
            this.CmbMaliyet.Location = new System.Drawing.Point(542, 128);
            this.CmbMaliyet.Name = "CmbMaliyet";
            this.CmbMaliyet.Size = new System.Drawing.Size(140, 36);
            this.CmbMaliyet.TabIndex = 3;
            // 
            // CmbSiralama
            // 
            this.CmbSiralama.BackColor = System.Drawing.Color.Transparent;
            this.CmbSiralama.BorderColor = System.Drawing.Color.Maroon;
            this.CmbSiralama.BorderRadius = 10;
            this.CmbSiralama.BorderThickness = 3;
            this.CmbSiralama.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbSiralama.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSiralama.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CmbSiralama.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CmbSiralama.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CmbSiralama.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CmbSiralama.ItemHeight = 30;
            this.CmbSiralama.Items.AddRange(new object[] {
            "Tüm Tarifler",
            "Tarif İsmine Göre(a-z)",
            "Tarif İsmine Göre(z-a)",
            "Hazirlama Süresi(Hızlı-Yavaş)",
            "Hazirlama Süresi(Yavaş-Hızlı)",
            "Maliyet(Artan)",
            "Maliyet(Azalan)"});
            this.CmbSiralama.Location = new System.Drawing.Point(688, 128);
            this.CmbSiralama.Name = "CmbSiralama";
            this.CmbSiralama.Size = new System.Drawing.Size(221, 36);
            this.CmbSiralama.TabIndex = 4;
            // 
            // Panel1
            // 
            this.Panel1.BorderColor = System.Drawing.Color.DarkRed;
            this.Panel1.BorderRadius = 15;
            this.Panel1.BorderThickness = 2;
            this.Panel1.Controls.Add(this.label2);
            this.Panel1.Controls.Add(this.pictureBox1);
            this.Panel1.Controls.Add(this.CmbSiralama);
            this.Panel1.Controls.Add(this.CmbMaliyet);
            this.Panel1.Controls.Add(this.TxtAra);
            this.Panel1.Controls.Add(this.CmbKategori);
            this.Panel1.Controls.Add(this.label1);
            this.Panel1.FillColor = System.Drawing.Color.DarkRed;
            this.Panel1.Location = new System.Drawing.Point(85, 30);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(926, 198);
            this.Panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(848, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Filtrele";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(848, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // BtnEkle
            // 
            this.BtnEkle.BorderColor = System.Drawing.Color.DarkRed;
            this.BtnEkle.BorderRadius = 15;
            this.BtnEkle.BorderThickness = 2;
            this.BtnEkle.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnEkle.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnEkle.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnEkle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnEkle.FillColor = System.Drawing.Color.White;
            this.BtnEkle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnEkle.ForeColor = System.Drawing.Color.DarkRed;
            this.BtnEkle.Location = new System.Drawing.Point(259, 622);
            this.BtnEkle.Name = "BtnEkle";
            this.BtnEkle.Size = new System.Drawing.Size(277, 45);
            this.BtnEkle.TabIndex = 2;
            this.BtnEkle.Text = "Tarif Ekle";
            this.BtnEkle.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // BtnAra
            // 
            this.BtnAra.BorderColor = System.Drawing.Color.DarkRed;
            this.BtnAra.BorderRadius = 15;
            this.BtnAra.BorderThickness = 2;
            this.BtnAra.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnAra.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnAra.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnAra.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnAra.FillColor = System.Drawing.Color.White;
            this.BtnAra.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnAra.ForeColor = System.Drawing.Color.DarkRed;
            this.BtnAra.Location = new System.Drawing.Point(557, 622);
            this.BtnAra.Name = "BtnAra";
            this.BtnAra.Size = new System.Drawing.Size(260, 45);
            this.BtnAra.TabIndex = 3;
            this.BtnAra.Text = "Malzemeye Göre Ara";
            this.BtnAra.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(85, 248);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(926, 351);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // guna2ContextMenuStrip1
            // 
            this.guna2ContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
            this.guna2ContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
            this.guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.guna2ContextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.guna2ContextMenuStrip1.Text = "Tarifler";
            // 
            // guna2ContextMenuStrip2
            // 
            this.guna2ContextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.guna2ContextMenuStrip2.Name = "guna2ContextMenuStrip2";
            this.guna2ContextMenuStrip2.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip2.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip2.RenderStyle.ColorTable = null;
            this.guna2ContextMenuStrip2.RenderStyle.RoundedEdges = true;
            this.guna2ContextMenuStrip2.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip2.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip2.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip2.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip2.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.guna2ContextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // yemek_TarifiDataSet1
            // 
            this.yemek_TarifiDataSet1.DataSetName = "Yemek_TarifiDataSet";
            this.yemek_TarifiDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Yazlab_YemekTarifi.Properties.Resources.arkaplan;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1079, 695);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.BtnAra);
            this.Controls.Add(this.BtnEkle);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("Malgun Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yemek_TarifiDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox TxtAra;
        private Guna.UI2.WinForms.Guna2ComboBox CmbSiralama;
        private Guna.UI2.WinForms.Guna2ComboBox CmbMaliyet;
        private Guna.UI2.WinForms.Guna2ComboBox CmbKategori;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel Panel1;
        private Guna.UI2.WinForms.Guna2Button BtnEkle;
        private Guna.UI2.WinForms.Guna2Button BtnAra;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip1;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip2;
        private Yemek_TarifiDataSet yemek_TarifiDataSet1;
        private System.Windows.Forms.Label label2;
    }
}

