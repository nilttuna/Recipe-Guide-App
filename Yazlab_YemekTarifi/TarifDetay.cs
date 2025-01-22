using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace Yazlab_YemekTarifi
{
    public partial class TarifDetay : Form
    {
        public static int tarifid;
        public TarifDetay()
        {
            InitializeComponent();
        }

        private void TarifDetay_Load(object sender, EventArgs e)
        {
            tarifDetay();

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            
            TarifGuncelle guncelle = new TarifGuncelle(tarifid);
            guncelle.Show();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            Tarifler tarifsil= new Tarifler();
            if (tarifsil.TarifSil(tarifid)==true)
            {
                this.Close();
               
;               MessageBox.Show("Tarif silindi.");
                
            }
            else
            {
                MessageBox.Show("Tarif silinemedi.");
            }

        }

        public void tarifDetay()
        {
            listBox1.Items.Clear();
            Tarifler tarifdetay = new Tarifler();
            tarifdetay = tarifdetay.GetTarifDetay(tarifid);
            if (System.IO.File.Exists(tarifdetay.Resim))
            {
                pictureBox3.Image = Image.FromFile(tarifdetay.Resim);
            }
            TxtTarifAd.Text = tarifdetay.TarifAdi;
            if (tarifdetay.HazirlamaSuresi >= 60)
            {
                if (tarifdetay.HazirlamaSuresi % 60 == 0)
                    TxtSure.Text = (tarifdetay.HazirlamaSuresi / 60).ToString() + " Saat";
                else
                    TxtSure.Text = (tarifdetay.HazirlamaSuresi / 60).ToString() + " Saat " + (tarifdetay.HazirlamaSuresi % 60).ToString() + " dakika";
            }
            else
            {
                TxtSure.Text = tarifdetay.HazirlamaSuresi.ToString() + " dakika";
            }
            TxtKategori.Text = tarifdetay.Kategori;
            richTextBox1.Text = tarifdetay.Talimatlar;
            foreach (var malzeme in tarifdetay.Malzemeler)
            {
                listBox1.Items.Add(malzeme); 
            }

        }

        private void TarifDetay_FormClosed(object sender, FormClosedEventArgs e)
        {
             Form1 form1 = new Form1();
             form1.Show();
        }

        private void LblStok_Click(object sender, EventArgs e)
        {
            Stok stok=new Stok();
            stok.Show();    
        }

        private void TarifDetay_Activated(object sender, EventArgs e)
        {
            tarifDetay();
        }
    }
}
