namespace Yazlab_YemekTarifi
{
    partial class Stok
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stok));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtMalzeme = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtBirimFiyat = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtMiktar = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbBirim = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Txtid = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkRed;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.DarkRed;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(605, 413);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderColor = System.Drawing.Color.DarkRed;
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.BorderThickness = 3;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.White;
            this.guna2Button1.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.DarkRed;
            this.guna2Button1.Location = new System.Drawing.Point(643, 313);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(246, 36);
            this.guna2Button1.TabIndex = 37;
            this.guna2Button1.Text = "Güncelle";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Malgun Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(686, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(210, 17);
            this.label5.TabIndex = 36;
            this.label5.Text = "(kg-litre-adet-paket olarak giriniz)";
            // 
            // TxtMalzeme
            // 
            this.TxtMalzeme.BorderColor = System.Drawing.Color.DarkRed;
            this.TxtMalzeme.BorderRadius = 10;
            this.TxtMalzeme.BorderThickness = 3;
            this.TxtMalzeme.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtMalzeme.DefaultText = "";
            this.TxtMalzeme.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtMalzeme.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtMalzeme.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtMalzeme.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtMalzeme.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtMalzeme.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.TxtMalzeme.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtMalzeme.Location = new System.Drawing.Point(756, 74);
            this.TxtMalzeme.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtMalzeme.Name = "TxtMalzeme";
            this.TxtMalzeme.PasswordChar = '\0';
            this.TxtMalzeme.PlaceholderText = "";
            this.TxtMalzeme.SelectedText = "";
            this.TxtMalzeme.Size = new System.Drawing.Size(133, 36);
            this.TxtMalzeme.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(646, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "Birim:";
            // 
            // TxtBirimFiyat
            // 
            this.TxtBirimFiyat.BorderColor = System.Drawing.Color.DarkRed;
            this.TxtBirimFiyat.BorderRadius = 10;
            this.TxtBirimFiyat.BorderThickness = 3;
            this.TxtBirimFiyat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtBirimFiyat.DefaultText = "";
            this.TxtBirimFiyat.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtBirimFiyat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtBirimFiyat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtBirimFiyat.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtBirimFiyat.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtBirimFiyat.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.TxtBirimFiyat.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtBirimFiyat.Location = new System.Drawing.Point(757, 221);
            this.TxtBirimFiyat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtBirimFiyat.Name = "TxtBirimFiyat";
            this.TxtBirimFiyat.PasswordChar = '\0';
            this.TxtBirimFiyat.PlaceholderText = "";
            this.TxtBirimFiyat.SelectedText = "";
            this.TxtBirimFiyat.Size = new System.Drawing.Size(133, 36);
            this.TxtBirimFiyat.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(646, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Birim Fiyat:";
            // 
            // TxtMiktar
            // 
            this.TxtMiktar.BorderColor = System.Drawing.Color.DarkRed;
            this.TxtMiktar.BorderRadius = 10;
            this.TxtMiktar.BorderThickness = 3;
            this.TxtMiktar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtMiktar.DefaultText = "";
            this.TxtMiktar.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtMiktar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtMiktar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtMiktar.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtMiktar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtMiktar.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.TxtMiktar.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtMiktar.Location = new System.Drawing.Point(756, 118);
            this.TxtMiktar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtMiktar.Name = "TxtMiktar";
            this.TxtMiktar.PasswordChar = '\0';
            this.TxtMiktar.PlaceholderText = "";
            this.TxtMiktar.SelectedText = "";
            this.TxtMiktar.Size = new System.Drawing.Size(133, 36);
            this.TxtMiktar.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(645, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "Miktar:";
            // 
            // CmbBirim
            // 
            this.CmbBirim.BackColor = System.Drawing.Color.Transparent;
            this.CmbBirim.BorderColor = System.Drawing.Color.Maroon;
            this.CmbBirim.BorderRadius = 10;
            this.CmbBirim.BorderThickness = 3;
            this.CmbBirim.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbBirim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBirim.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CmbBirim.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CmbBirim.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CmbBirim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CmbBirim.ItemHeight = 30;
            this.CmbBirim.Items.AddRange(new object[] {
            "adet",
            "gram",
            "kilogram",
            "mililitre",
            "litre"});
            this.CmbBirim.Location = new System.Drawing.Point(756, 168);
            this.CmbBirim.Name = "CmbBirim";
            this.CmbBirim.Size = new System.Drawing.Size(133, 36);
            this.CmbBirim.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(645, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 28;
            this.label3.Text = "Malzeme Adı:";
            // 
            // Txtid
            // 
            this.Txtid.BorderColor = System.Drawing.Color.DarkRed;
            this.Txtid.BorderRadius = 10;
            this.Txtid.BorderThickness = 3;
            this.Txtid.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Txtid.DefaultText = "";
            this.Txtid.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Txtid.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Txtid.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Txtid.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Txtid.Enabled = false;
            this.Txtid.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Txtid.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.Txtid.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Txtid.Location = new System.Drawing.Point(756, 30);
            this.Txtid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Txtid.Name = "Txtid";
            this.Txtid.PasswordChar = '\0';
            this.Txtid.PlaceholderText = "";
            this.Txtid.SelectedText = "";
            this.Txtid.Size = new System.Drawing.Size(133, 36);
            this.Txtid.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(645, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 20);
            this.label6.TabIndex = 38;
            this.label6.Text = "Malzeme ID:";
            // 
            // Stok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Yazlab_YemekTarifi.Properties.Resources.arkaplan;
            this.ClientSize = new System.Drawing.Size(901, 451);
            this.Controls.Add(this.Txtid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtMalzeme);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtBirimFiyat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtMiktar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CmbBirim);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Stok";
            this.Text = "Stok";
            this.Load += new System.EventHandler(this.Stok_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox TxtMalzeme;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox TxtBirimFiyat;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox TxtMiktar;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ComboBox CmbBirim;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox Txtid;
        private System.Windows.Forms.Label label6;
    }
}