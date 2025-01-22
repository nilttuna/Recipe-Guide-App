using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yazlab_YemekTarifi
{
    internal class sqlConnection
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-9UGD5QJ\\SQLEXPRESS;Initial Catalog=Yemek_Tarifi;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
