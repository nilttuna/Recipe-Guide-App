using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebSockets;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Yazlab_YemekTarifi
{
    public partial class TarifEkle : Form
    {
        sqlConnection connection=new sqlConnection();
        
        List<Malzemeler> malzemebilgileri= new List<Malzemeler>();  

        public TarifEkle()
        {
            InitializeComponent();
        }


        private void TarifEkle_Load(object sender, EventArgs e)
        {

            FormBilgileriGetir();

        }

        public void FormBilgileriGetir()
        {
            CmbMalzemeAd.Items.Clear();
            CmbBirim.Items.Clear(); 
            Malzemeler malzemeler = new Malzemeler();

            foreach (var malzemead in malzemeler.MalzemeAdlari())
            {
                CmbMalzemeAd.Items.Add(malzemead.MalzemeAdi);
            }
            foreach (var malzemebirim in malzemeler.MalzemeBirimleri())
            {
                CmbBirim.Items.Add(malzemebirim);
            }

            SqlCommand command = new SqlCommand("SELECT DISTINCT KategoriID, KategoriAdi FROM Tbl_Kategoriler ", connection.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbKategori.DataSource = dt;
            CmbKategori.DisplayMember = "KategoriAdi";
            CmbKategori.ValueMember = "KategoriID";

        }

        private void BtnYeniMalzeme_Click(object sender, EventArgs e)
        {
            
            MalzemeEkle malzemeEkle = new MalzemeEkle();
            malzemeEkle.Owner = this; 
            malzemeEkle.Show();
        }

        private void BtnMalzemeEkle_Click(object sender, EventArgs e)
        {
            if (CmbMalzemeAd.SelectedItem != null && CmbBirim.SelectedItem != null)
            {
                string malzemeAdi = CmbMalzemeAd.SelectedItem.ToString();
                string malzemeBirim = CmbBirim.SelectedItem.ToString();
                if (float.TryParse(TxtMiktar.Text, out float miktar))
                {

                    Malzemeler malzemeler = new Malzemeler();
                    malzemeler.MalzemeAdi = malzemeAdi;
                    malzemeler.KullanilacakMalzemeMiktar = miktar;
                    malzemeler.MalzemeBirim = malzemeBirim.ToString();

                    if (!string.IsNullOrEmpty(malzemeAdi) && !string.IsNullOrEmpty(malzemeBirim) && !string.IsNullOrEmpty(miktar.ToString()))
                    {
                        malzemebilgileri.Add(malzemeler);

                        listBox1.Items.Add($"{malzemeAdi} - {miktar} {malzemeBirim}");
                    }
                }
                else
                {
                    MessageBox.Show("Geçerli bir miktar giriniz.");
                }

            }
           
            else
            {
                MessageBox.Show("Malzeme bilgilerini tam giriniz.");
            }
            

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.ImageLocation = ofd.FileName;
                TxtResimyolu.Text = ofd.FileName; 
            }
        }

        private void BtnTarifEkle_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TxtSure.Text, out int sure))
            {
                if (!string.IsNullOrEmpty(TxtResimyolu.Text) && !string.IsNullOrEmpty(TxtTarifAd.Text) && sure != 0 && Convert.ToInt32(CmbKategori.SelectedValue) != 0 && !string.IsNullOrEmpty(richTextBox2.Text))
                {
                    Tarifler tarif = new Tarifler();
                    if (tarif.TarifEkle(TxtResimyolu.Text, TxtTarifAd.Text, Convert.ToInt32(TxtSure.Text), Convert.ToInt32(CmbKategori.SelectedValue), malzemebilgileri, richTextBox2.Text) == true)
                    {
                        this.Close();

                    }

                }
                else
                {
                    MessageBox.Show("Alanları Doldurunuz!!!");
                }
            }
            else
            {
                MessageBox.Show("Süre için sayısal bir değer giriniz.");
            }



        }

        private void TarifEkle_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }

        private void TarifEkle_Activated(object sender, EventArgs e)
        {
            FormBilgileriGetir();
        }

        private void BtnKategoriEkle_Click(object sender, EventArgs e)
        {
            KategoriEkle ekle=new KategoriEkle();
            ekle.Show();
        }
    }
}
