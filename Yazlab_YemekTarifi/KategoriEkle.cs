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
    public partial class KategoriEkle : Form
    {
        sqlConnection connection = new sqlConnection();
        public KategoriEkle()
        {
            InitializeComponent();
        }

        private void BtnKategoriEkle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand commandname = new SqlCommand("SELECT COUNT(*) FROM Tbl_Kategoriler WHERE KategoriAdi = @KategoriAdi", connection.baglanti());
                commandname.Parameters.AddWithValue("@KategoriAdi", TxtKategori.Text);

                int count = (int)commandname.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Bu kategori zaten mevcut.");
                    connection.baglanti().Close();
                }
                else
                {
                    SqlCommand command = new SqlCommand("INSERT INTO Tbl_Kategoriler (KategoriAdi) values (@KategoriAdi)", connection.baglanti());
                    command.Parameters.AddWithValue("@KategoriAdi", TxtKategori.Text);
                    int etkilenen_satir = command.ExecuteNonQuery();
                    if (etkilenen_satir > 0)
                    {
                        MessageBox.Show("Yeni kategori eklendi.");
                    }
                    else
                    {
                        MessageBox.Show("Yeni kategori eklenemedi.");

                    }
                }
            }
            catch
            {
                MessageBox.Show("Eklenemedi");
            }
            finally
            {
                connection.baglanti().Close();
            }
        }
    }
}
