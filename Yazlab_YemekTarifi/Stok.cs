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
using static System.Net.Mime.MediaTypeNames;

namespace Yazlab_YemekTarifi
{
    public partial class Stok : Form
    {
        sqlConnection conn=new sqlConnection();
        Malzemeler malzeme=new Malzemeler();
        public Stok()
        {
            InitializeComponent();
        }

        private void Stok_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                Txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtMalzeme.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                TxtMiktar.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                CmbBirim.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                TxtBirimFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();


                if (e.ColumnIndex == 0) 
                {
                    dataGridView1.Sort(dataGridView1.Columns[0], System.ComponentModel.ListSortDirection.Ascending); 
                }
            }



        }

        public void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Malzemeler", conn.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(malzeme.stokGuncelle(Convert.ToInt32( Txtid.Text),TxtMalzeme.Text,TxtMiktar.Text,CmbBirim.SelectedItem.ToString(),float.Parse(TxtBirimFiyat.Text)))
            {

                MessageBox.Show("Malzeme Güncellendi.");
                listele();

            }
            else
            {
                MessageBox.Show("Malzeme güncelleme başarısız.");
            }
        }

    }
}
