namespace Yazlab_YemekTarifi
{
    partial class MalzemeyeGoreAra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MalzemeyeGoreAra));
            this.groupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnAra = new Guna.UI2.WinForms.Guna2Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BorderColor = System.Drawing.Color.DarkRed;
            this.groupBox1.BorderRadius = 10;
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.CustomBorderColor = System.Drawing.Color.DarkRed;
            this.groupBox1.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(716, 189);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.Text = "Malzemeler";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 43);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(710, 138);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 258);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(715, 363);
            this.flowLayoutPanel1.TabIndex = 6;
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
            this.BtnAra.Location = new System.Drawing.Point(12, 207);
            this.BtnAra.Name = "BtnAra";
            this.BtnAra.Size = new System.Drawing.Size(715, 45);
            this.BtnAra.TabIndex = 7;
            this.BtnAra.Text = "Ara";
            this.BtnAra.Click += new System.EventHandler(this.BtnAra_Click);
            // 
            // MalzemeyeGoreAra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Yazlab_YemekTarifi.Properties.Resources.arkaplan;
            this.ClientSize = new System.Drawing.Size(739, 633);
            this.Controls.Add(this.BtnAra);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Malgun Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MalzemeyeGoreAra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MalzemeyeGoreAra";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MalzemeyeGoreAra_FormClosed);
            this.Load += new System.EventHandler(this.MalzemeyeGoreAra_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Button BtnAra;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}