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
    public partial class MalzemeyeGoreAra : Form
    {
        List<CheckBox> checkboxList = new List<CheckBox>();
        Malzemeler stokkontrol = new Malzemeler();

        public MalzemeyeGoreAra()
        {
            InitializeComponent();

        }

        private void MalzemeyeGoreAra_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.Dock = DockStyle.Fill;
            MalzemeAdlari();

        }

        public void MalzemeAdlari()
        {
            int checkboxYPosition = 43;
            int checkboxXPosition = 28;
            int i = 6; 


            Malzemeler malzemead = new Malzemeler();
            List<Malzemeler> malzemelist=malzemead.MalzemeAdlari();

            foreach (var malzeme in malzemelist)
            {
                CheckBox chk = new CheckBox();
                chk.Location = new Point(checkboxXPosition, checkboxYPosition);  
                chk.Text = malzeme.MalzemeAdi;
                chk.ForeColor = Color.DarkRed;
                chk.BackColor = Color.White; 

                flowLayoutPanel2.Controls.Add(chk);
                checkboxList.Add(chk);
                i++;

                checkboxXPosition += chk.Width+10; 

                
                if (i%6==0)
                {
                    checkboxYPosition += chk.Height+5;
                    checkboxXPosition = 28; // Yeni satırda X pozisyonunu sıfırla


                }
            }
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();  
            List<string> selectedMalzemeler=new List<string>();
           
            if (checkboxList.Count > 0)
            {
                foreach (CheckBox chk in checkboxList)
                {
                    if (chk.Checked)
                    {
                        selectedMalzemeler.Add(chk.Text);
                    }
                }

                if(selectedMalzemeler.Count>0)
                {
                    List<Tarifler> tarifler = new List<Tarifler>();
                    Malzemeler malzemeyeGoreResim = new Malzemeler();
                    tarifler = malzemeyeGoreResim.GetMalzemeyeGöreTarif(selectedMalzemeler);

                    foreach (var tarif in tarifler)
                    {
                        UserControl1 userControl = new UserControl1();

                        if (System.IO.File.Exists(tarif.Resim))
                        {
                            userControl.BackgroundImage = Image.FromFile(tarif.Resim);
                        }

                        if (stokkontrol.StokKontrolu(tarif.TarifAdi))
                        {
                            userControl.label1.ForeColor = Color.Green;
                            userControl.label1.Text = tarif.TarifAdi;
                        }
                        else
                        {
                            userControl.label1.ForeColor = Color.Red;
                            userControl.label1.Text = tarif.TarifAdi;
                        }

                        if (tarif.HazirlamaSuresi >= 60)
                        {
                            if (tarif.HazirlamaSuresi % 60 == 0)
                                userControl.label2.Text = (tarif.HazirlamaSuresi / 60).ToString() + " Saat";
                            else
                                userControl.label2.Text = (tarif.HazirlamaSuresi / 60).ToString() + " Saat " + (tarif.HazirlamaSuresi % 60).ToString() + " dakika";
                        }
                        else
                        {
                            userControl.label2.Text = tarif.HazirlamaSuresi.ToString() + " dakika";
                        }

                        userControl.label3.Text = tarif.Maliyet + " TL";

                        userControl.label4.Visible = true;
                        userControl.label4.Text = "Eşleşme: %"+tarif.EslesmeOrani.ToString("0.00");

                        flowLayoutPanel1.Controls.Add(userControl);
                    }


                }
                else
                {
                    MessageBox.Show("Malzeme Seçimi Yapılmadı");

                }
            }
            else
            {
                MessageBox.Show("Malzeme Seçimi Yapılmadı");
            }
        }

        private void MalzemeyeGoreAra_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }
    }
}
