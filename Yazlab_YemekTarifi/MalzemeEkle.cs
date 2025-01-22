using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yazlab_YemekTarifi
{
    public partial class MalzemeEkle : Form
    {
        public MalzemeEkle()
        {
            InitializeComponent();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if(TxtMalzeme.Text != null && TxtMiktar.Text != null && CmbBirim.SelectedItem != null && TxtBirimFiyat.Text != null)
            {
                Malzemeler malzeme = new Malzemeler();
                if(malzeme.YeniMalzemeEkle(TxtMalzeme.Text,TxtMiktar.Text,CmbBirim.SelectedItem.ToString(),Convert.ToDecimal(TxtBirimFiyat.Text))==true)
                {
                    MessageBox.Show("Malzeme başarıyla eklendi.");
                    TxtMalzeme.Text = "";
                    TxtMiktar.Text = "";
                    CmbBirim.SelectedIndex = 0;
                    TxtBirimFiyat.Text = "";
                }
                else
                {
                    MessageBox.Show("Malzeme Eklenemedi");
                }
            }
            else
            {
                MessageBox.Show("Alanları doldurunuz!!");
            }

     

        }



        private void MalzemeEkle_Load(object sender, EventArgs e)
        {
            Malzemeler malzemeler = new Malzemeler();
            foreach (var malzemebirim in malzemeler.MalzemeBirimleri())
            {
                CmbBirim.Items.Add(malzemebirim);
            }
        }

        private void MalzemeEkle_FormClosed(object sender, FormClosedEventArgs e)
        {
            /*if (this.Owner != null)
            {
                this.Owner.Show();
            }*/
        }
    }
}
