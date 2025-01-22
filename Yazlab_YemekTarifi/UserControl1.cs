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
    public partial class UserControl1 : UserControl
    {
        sqlConnection connection=new sqlConnection();
        public UserControl1()
        {
            InitializeComponent();
            
            
        }


        private void UserControl1_DoubleClick(object sender, EventArgs e)
        {
            clickOzelligi();
        }

        private void guna2GradientPanel1_DoubleClick(object sender, EventArgs e)
        {
            clickOzelligi();
        }


        public void clickOzelligi()
        {
            int tarifid = 0;
            SqlCommand command = new SqlCommand("Select TarifID From Tbl_Tarifler where TarifAdi=@p1", connection.baglanti());
            command.Parameters.AddWithValue("@p1", label1.Text);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) 
            {
                tarifid = Convert.ToInt32(reader["TarifID"]);  
            }
            reader.Close();
            connection.baglanti().Close();

            TarifDetay detay = new TarifDetay();
            TarifDetay.tarifid = tarifid;
            detay.Show();

            // UserControl'ün bağlı olduğu ana formu kapat
            Form parentForm = this.FindForm(); // UserControl'ün bağlı olduğu ana formu bul
            if (parentForm != null)
            {
                parentForm.Hide(); // Ana formu kapat
            }
        }
    }
}
