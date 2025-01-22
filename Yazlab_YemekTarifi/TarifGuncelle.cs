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

namespace Yazlab_YemekTarifi
{
    public partial class TarifGuncelle : Form
    {
        sqlConnection connection=new sqlConnection();
        List<Malzemeler> malzemebilgileri = new List<Malzemeler>();
        List<string> listMalzemeler = new List<string>();

        public int tarifid;
        public TarifGuncelle(int tarifid)
        {
            this.tarifid=tarifid;
            InitializeComponent();
        }

        private void TarifGuncelle_Load(object sender, EventArgs e)
        {

            tarifbilgileri();
        }


        public void tarifbilgileri()
        {

            CmbMalzeme.Items.Clear();
            CmbBirim.Items.Clear();

            Malzemeler malzemeler = new Malzemeler();

            foreach (var malzemead in malzemeler.MalzemeAdlari())
            {
                CmbMalzeme.Items.Add(malzemead.MalzemeAdi);
            }
            foreach (var malzemebirim in malzemeler.MalzemeBirimleri())
            {
                CmbBirim.Items.Add(malzemebirim);
            }

            SqlCommand command = new SqlCommand("SELECT KategoriID, KategoriAdi FROM Tbl_Kategoriler ", connection.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbKategori.DataSource = dt;
            CmbKategori.DisplayMember = "KategoriAdi";
            CmbKategori.ValueMember = "KategoriID";



            Tarifler tarifdetay = new Tarifler();
            tarifdetay = tarifdetay.GetTarifDetay(this.tarifid);
            if (System.IO.File.Exists(tarifdetay.Resim))
            {
                pictureBox3.Image = Image.FromFile(tarifdetay.Resim);
            }
            TxtTarifAd.Text = tarifdetay.TarifAdi;
            TxtSure.Text = (tarifdetay.HazirlamaSuresi).ToString();
            CmbKategori.Text = tarifdetay.Kategori.ToString();
            richTextBox1.Text = tarifdetay.Talimatlar;
            TxtResimyolu.Text = tarifdetay.Resim;
            foreach (var malzeme in tarifdetay.Malzemeler)
            {
                listBox1.Items.Add(malzeme); 
                string[] tutucudizi = malzeme.Split(' ');
                listMalzemeler.Add(tutucudizi[0]);
            }

        
        }

        Malzemeler malzemeler ;
        private void BtnMalzemeEkle_Click(object sender, EventArgs e)
        {
            if (CmbMalzeme.SelectedItem != null && CmbBirim.SelectedItem != null)
            {
                string malzemeAdi = CmbMalzeme.SelectedItem.ToString();
                string malzemeBirim = CmbBirim.SelectedItem.ToString();
                if (float.TryParse(TxtMiktar.Text, out float miktar))
                {

                    malzemeler = new Malzemeler();
                    {
                        malzemeler.MalzemeAdi = malzemeAdi;
                        malzemeler.KullanilacakMalzemeMiktar = miktar;
                        malzemeler.MalzemeBirim = malzemeBirim.ToString();
                    }
                    

                    if (!string.IsNullOrEmpty(malzemeAdi) && !string.IsNullOrEmpty(malzemeBirim) && !string.IsNullOrEmpty(miktar.ToString()))
                    {
                        malzemebilgileri.Add(malzemeler);

                        listBox1.Items.Add($"{malzemeAdi} {miktar} {malzemeBirim}");
                        listMalzemeler.Add(malzemeAdi);                    
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

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            Tarifler tarifguncelle= new Tarifler();
            if (!string.IsNullOrEmpty(TxtResimyolu.Text) && !string.IsNullOrEmpty(TxtTarifAd.Text) && Convert.ToInt32(TxtSure.Text) != 0 && Convert.ToInt32(CmbKategori.SelectedValue) != 0 && !string.IsNullOrEmpty(richTextBox1.Text))
            {
                if (tarifguncelle.TarifGuncelle(this.tarifid,TxtResimyolu.Text, TxtTarifAd.Text, Convert.ToInt32(TxtSure.Text), Convert.ToInt32(CmbKategori.SelectedValue), richTextBox1.Text,listMalzemeler,malzemebilgileri))
                {
                    this.Close();
                    MessageBox.Show("Tarif Güncellendi.");

                }
                else
                {
                    MessageBox.Show("Tarif güncellenemedi.");
                }

            }
            else
            {
               
                MessageBox.Show("Alanlar boş bırakılamaz.");
            }


        }

        private void BtnMalzemeSil_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string[] seciliMalzemekelimedizisi = listBox1.SelectedItem.ToString().Split(' ');

                listBox1.Items.Remove(listBox1.SelectedItem);

                listMalzemeler.Remove(seciliMalzemekelimedizisi[0]);

                malzemebilgileri.RemoveAll(malzeme => malzeme.MalzemeAdi == seciliMalzemekelimedizisi[0]);

            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir öğe seçin.");
            }


        }

        private void BtnYeniMalzeme_Click(object sender, EventArgs e)
        {
            MalzemeEkle malzemeEkle = new MalzemeEkle();
            malzemeEkle.Owner = this; 
            malzemeEkle.Show();
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

        private void TarifGuncelle_Activated(object sender, EventArgs e)
        {
            CmbMalzeme.Items.Clear();
            CmbBirim.Items.Clear();

            Malzemeler malzemeler = new Malzemeler();

            foreach (var malzemead in malzemeler.MalzemeAdlari())
            {
                CmbMalzeme.Items.Add(malzemead.MalzemeAdi);
            }
            foreach (var malzemebirim in malzemeler.MalzemeBirimleri())
            {
                CmbBirim.Items.Add(malzemebirim);
            }

            SqlCommand command = new SqlCommand("SELECT KategoriID, KategoriAdi FROM Tbl_Kategoriler ", connection.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbKategori.DataSource = dt;
            CmbKategori.DisplayMember = "KategoriAdi";
            CmbKategori.ValueMember = "KategoriID";


        }

        private void BtnKategoriEkle_Click(object sender, EventArgs e)
        {
            KategoriEkle ekle = new KategoriEkle();
            ekle.Show();
        }
    }
}
