using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace Yazlab_YemekTarifi
{
    public partial class Form1 : Form
    {
        sqlConnection connection=new sqlConnection();
        string selectedKategori="";
        Malzemeler stokkontrol=new Malzemeler();    
        
        public Form1()
        {
            InitializeComponent();
        }



        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            TarifEkle ekle=new TarifEkle();
            ekle.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1DetayYukleme();
        }

        public void Form1DetayYukleme()
        {
            CmbSiralama.Text = "Tüm Tarifler";
            CmbMaliyet.Text = "Tüm Tarifler";
            flowLayoutPanel1.AutoScroll = true;
            if (string.IsNullOrEmpty(TxtAra.Text))
            {
                LoadPictures();
            }
            SqlCommand command = new SqlCommand("SELECT KategoriID, KategoriAdi FROM Tbl_Kategoriler ", connection.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataRow dr = dt.NewRow();
            dr["KategoriID"] = 0;
            dr["KategoriAdi"] = "Tümü";
            dt.Rows.InsertAt(dr, 0);
            CmbKategori.DataSource = dt;
            CmbKategori.DisplayMember = "KategoriAdi";
            CmbKategori.ValueMember = "KategoriID";
            selectedKategori = "";
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MalzemeyeGoreAra ara=new MalzemeyeGoreAra();
            ara.Show();
        }

        private void LoadPictures()
        {
            flowLayoutPanel1.Controls.Clear();  
            Tarifler resim = new Tarifler();
            List<Tarifler> tarifler = resim.GetTarifResimleri(); 

            foreach (var tarif in tarifler)
            {
                UserControl1 userControl = new UserControl1();

                // Resim dosyasını kontrol et ve yükle
                if (System.IO.File.Exists(tarif.Resim))
                {
                    userControl.BackgroundImage = Image.FromFile(tarif.Resim); 
                }


                if(stokkontrol.StokKontrolu(tarif.TarifAdi))
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


                flowLayoutPanel1.Controls.Add(userControl);
            }
        }

        private void TxtAra_TextChanged(object sender, EventArgs e)
        {
            //Ara();
            if(TxtAra.Text=="")
            {
                CmbKategori.Text = "Tümü";
                CmbMaliyet.Text = "Tüm Tarifler";
                CmbSiralama.Text = "Tüm Tarifler";
                LoadPictures();
                
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Ara();
            CmbKategori.Text = "Tümü";
            CmbMaliyet.Text = "Tüm Tarifler";
            CmbSiralama.Text = "Tüm Tarifler";
        }

        private void Ara()
        {
            flowLayoutPanel1.Controls.Clear();


            if (!string.IsNullOrEmpty(TxtAra.Text))
            {
                Tarifler resim = new Tarifler();
                List<Tarifler> tarifler = resim.GetArananTarifResimleri(TxtAra.Text,selectedKategori);

                foreach (var tarif in tarifler)
                {
                    UserControl1 userControl = new UserControl1();

                    // Resim dosyasını kontrol et ve yükle
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

                    flowLayoutPanel1.Controls.Add(userControl);
                }

            }
            else
            {
                LoadPictures();
            }
        }

        private void CmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbKategori.SelectedIndex == 0)
            {
                selectedKategori = "";
            }
            else
            {
                DataRowView selectedRow = (DataRowView)CmbKategori.SelectedItem;
                selectedKategori = (selectedRow["KategoriAdi"].ToString());
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            Tarifler tarifresim = new Tarifler();
            List<Tarifler> tarifler = new List<Tarifler> ();

            float minMaliyet = 0;
            float maxMaliyet = 0;

           
            if (CmbMaliyet.SelectedIndex==0 || CmbMaliyet.Text=="Tüm Tarifler")
            {
                tarifler = tarifresim.Filtrele(selectedKategori, CmbSiralama.SelectedIndex,null,null);
            }
            else
            {
                string maliyetaraligi = CmbMaliyet.SelectedItem.ToString().Replace(" TL", "").Trim();
                string[] maliyetler = maliyetaraligi.Split('-');
                minMaliyet = float.Parse(maliyetler[0]);
                maxMaliyet = float.Parse(maliyetler[1]);

                tarifler = tarifresim.Filtrele(selectedKategori, CmbSiralama.SelectedIndex,maxMaliyet,minMaliyet);
            }

                
            if(!string.IsNullOrEmpty(selectedKategori) || CmbSiralama.SelectedIndex!=0 || CmbMaliyet.SelectedIndex != 0)
            {
                foreach (var tarif in tarifler)
                {
                    UserControl1 userControl = new UserControl1();

                    // Resim dosyasını kontrol et ve yükle
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

                    flowLayoutPanel1.Controls.Add(userControl);
                }

            }
            else if((selectedKategori=="Tümü" || selectedKategori=="") && CmbSiralama.SelectedIndex==0 && CmbMaliyet.SelectedIndex == 0)
            {
                LoadPictures();
            }

        }

    }
}
