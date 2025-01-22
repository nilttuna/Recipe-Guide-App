using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Yazlab_YemekTarifi
{
    internal class Tarifler:ITarif
    {
        sqlConnection connection=new sqlConnection();
        public string Resim { get; set; }
        public string TarifAdi { get; set; }
        public int HazirlamaSuresi { get; set; }
        public float Maliyet { get; set; }
        public string Kategori { get; set; }
        public string Talimatlar { get; set; }
        public List<string> Malzemeler { get; set; }

        public float EslesmeOrani { get; set; }

        public List<Tarifler> GetTarifResimleri()
        {
            List<Tarifler> tarifler = new List<Tarifler>();
            SqlCommand command = new SqlCommand("SELECT TarifID, Resim, TarifAdi, HazirlamaSuresi FROM Tbl_Tarifler ORDER BY TarifAdi",connection.baglanti());
            SqlDataReader reader = command.ExecuteReader();

            Malzemeler malzemeMaliyet=new Malzemeler();

            try
            {
                while (reader.Read())
                {
                    Tarifler tarif = new Tarifler
                    {
                        Resim = reader["Resim"].ToString(),
                        TarifAdi = reader["TarifAdi"].ToString(),
                        HazirlamaSuresi = Convert.ToInt32(reader["HazirlamaSuresi"]),
                        Maliyet = malzemeMaliyet.MaliyetHesabı(Convert.ToInt32(reader["TarifID"])),
                    };
                    tarifler.Add(tarif);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }

            finally {
                reader.Close();
                connection.baglanti().Close();  
            }


            return tarifler;
        }

        public Tarifler GetTarifDetay(int tarifID)
        {
            Tarifler seciliTarif=new Tarifler();
            SqlCommand command = new SqlCommand("SELECT t.TarifID, t.TarifAdi, t.Resim, t.HazirlamaSuresi, t.Talimatlar, k.KategoriAdi, CONCAT(m.MalzemeAdi, ' ', tm.MalzemeMiktar, ' ', tm.MalzemeBirim) AS MalzemeBilgisi  " +
            "FROM Tbl_Tarifler t " +
            "INNER JOIN Tbl_Kategoriler k ON t.Kategori = k.KategoriID " +
            "LEFT JOIN Tbl_TarifMalzemeIliskisi tm ON t.TarifID = tm.TarifID " +
            "LEFT JOIN Tbl_Malzemeler m ON tm.MalzemeID = m.MalzemeID " +
            "WHERE t.TarifID = @id", connection.baglanti());
            command.Parameters.AddWithValue("@id", tarifID);
            SqlDataReader dr = command.ExecuteReader();

            List<string> malzemelerListesi = new List<string>();

            try
            {
                while (dr.Read())
                {
                    seciliTarif = new Tarifler
                    {
                        Resim = dr["Resim"].ToString(),
                        TarifAdi = dr["TarifAdi"].ToString(),
                        Kategori = dr["KategoriAdi"].ToString(),
                        HazirlamaSuresi = Convert.ToInt32(dr["HazirlamaSuresi"]),
                        Talimatlar = dr["Talimatlar"].ToString(),
                        
                    };
                    malzemelerListesi.Add(dr["MalzemeBilgisi"].ToString());

                }
                seciliTarif.Malzemeler = malzemelerListesi;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Tarif bilgileri getirilemedi");
            }
            finally {
                dr.Close();
                connection.baglanti().Close();
            }
            return seciliTarif;
        }


        public List<Tarifler> GetArananTarifResimleri(string aranan,string kategori)
        {
            List<Tarifler> tarifler = new List<Tarifler>();
            string query = "";

            
            query = "SELECT DISTINCT t.TarifID ,t.Resim, t.TarifAdi, t.HazirlamaSuresi FROM Tbl_Tarifler t"+
                    " LEFT JOIN Tbl_TarifMalzemeIliskisi tm ON t.TarifID = tm.TarifID"+
                    " LEFT JOIN Tbl_Malzemeler m ON tm.MalzemeID = m.MalzemeID"+
                    " WHERE (t.TarifAdi LIKE @aranan OR m.MalzemeAdi LIKE @aranan) ORDER BY t.TarifAdi";

            SqlCommand command = new SqlCommand(query, connection.baglanti());
            if (!string.IsNullOrEmpty(aranan))
            {
                command.Parameters.AddWithValue("@aranan", "%" + aranan + "%"); 
            }
           
            SqlDataReader reader = command.ExecuteReader();
            Malzemeler malzemeMaliyet = new Malzemeler();

            try
            {
                while (reader.Read())
                {
                    Tarifler tarif = new Tarifler
                    {
                        Resim = reader["Resim"].ToString(),
                        TarifAdi = reader["TarifAdi"].ToString(),
                        HazirlamaSuresi = Convert.ToInt32(reader["HazirlamaSuresi"]),
                        Maliyet = malzemeMaliyet.MaliyetHesabı(Convert.ToInt32(reader["TarifID"])),
                    };
                    tarifler.Add(tarif);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }

            finally
            {
                reader.Close();
                connection.baglanti().Close();
            }


            return tarifler;
        }

        public Boolean TarifEkle(string dosyayolu,string tarifadi,int sure, int kategori,List<Malzemeler> malzemeler,string talimat)
        {
            try
            {
                SqlCommand commandname = new SqlCommand("SELECT COUNT(*) FROM Tbl_Tarifler WHERE TarifAdi = @TarifAdi", connection.baglanti());
                commandname.Parameters.AddWithValue("@TarifAdi", tarifadi);

                int count = (int)commandname.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Bu tarif zaten mevcut.");
                    connection.baglanti().Close();
                    return false;
                }
                else
                {
                    SqlCommand command = new SqlCommand("Insert into Tbl_Tarifler(TarifAdi, HazirlamaSuresi, Resim, Kategori, Talimatlar)" +
                    "VALUES (@TarifAdi, @HazirlamaSuresi, @Resim, @Kategori, @Talimatlar)", connection.baglanti());

                    command.Parameters.AddWithValue("@TarifAdi", tarifadi);
                    command.Parameters.AddWithValue("@HazirlamaSuresi", sure);
                    command.Parameters.AddWithValue("@Resim", dosyayolu);
                    command.Parameters.AddWithValue("@Kategori", kategori);
                    command.Parameters.AddWithValue("@Talimatlar", talimat);
                    command.ExecuteNonQuery();
                    connection.baglanti().Close();



                    SqlCommand commandTarifID = new SqlCommand("Select TarifID From Tbl_Tarifler where TarifAdi=@p1", connection.baglanti());
                    commandTarifID.Parameters.AddWithValue("@p1", tarifadi);
                    int tarifid = (int)commandTarifID.ExecuteScalar();
                    connection.baglanti().Close();


                    foreach (var malzeme in malzemeler)
                    {
                        SqlCommand commandMalzemeID = new SqlCommand("Select MalzemeID From Tbl_Malzemeler where MalzemeAdi=@p1", connection.baglanti());
                        commandMalzemeID.Parameters.AddWithValue("@p1", malzeme.MalzemeAdi);
                        int malzemeID = (int)commandMalzemeID.ExecuteScalar();

                        SqlCommand commandTarifMalzeme = new SqlCommand("INSERT INTO Tbl_TarifMalzemeIliskisi (TarifID, MalzemeID, MalzemeMiktar,MalzemeBirim) VALUES (@TarifID, @MalzemeID, @Miktar, @MalzemeBirim)", connection.baglanti());
                        commandTarifMalzeme.Parameters.AddWithValue("@TarifID", tarifid);
                        commandTarifMalzeme.Parameters.AddWithValue("@MalzemeID", malzemeID);
                        commandTarifMalzeme.Parameters.AddWithValue("MalzemeBirim",malzeme.MalzemeBirim);
                        commandTarifMalzeme.Parameters.AddWithValue("@Miktar", malzeme.KullanilacakMalzemeMiktar);

                        commandTarifMalzeme.ExecuteNonQuery();
                        connection.baglanti().Close();

                    }
                }
                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Tarif ekleme işlemi sırasında bir hata oluştu");
                return false;

            }
            finally
            {
                connection.baglanti().Close();
            }


        }

        public Boolean TarifSil(int tarifID)
        {
            SqlCommand commandiliski = new SqlCommand("DELETE FROM Tbl_TarifMalzemeIliskisi WHERE TarifID = @TarifID",connection.baglanti());
            commandiliski.Parameters.AddWithValue("TarifID", tarifID);
            commandiliski.ExecuteNonQuery();

            SqlCommand commandtarif = new SqlCommand("DELETE FROM Tbl_Tarifler WHERE TarifID = @TarifID", connection.baglanti());
            commandtarif.Parameters.AddWithValue("TarifID", tarifID);
            try
            {
                int etkilenenSatirSayisi = commandtarif.ExecuteNonQuery();
                connection.baglanti().Close();
                return true;
            }
            catch (Exception ex)
            {
                connection.baglanti().Close();
                return false;
            }

        }

        public Boolean TarifGuncelle(int tarifID, string dosyayolu, string tarifadi, int sure, int kategori, string talimat, List<string> guncelmalzemeler,List<Malzemeler>malzemebilgileri)
        { 
            try
            {
                SqlCommand command = new SqlCommand("UPDATE Tbl_Tarifler SET TarifAdi = @TarifAdi, HazirlamaSuresi = @HazirlamaSuresi, Resim = @Resim, Kategori = @Kategori, Talimatlar = @Talimatlar WHERE TarifID = @TarifID", connection.baglanti());

                command.Parameters.AddWithValue("@TarifAdi", tarifadi);
                command.Parameters.AddWithValue("@HazirlamaSuresi", sure);
                command.Parameters.AddWithValue("@Resim", dosyayolu);
                command.Parameters.AddWithValue("@Kategori", kategori);
                command.Parameters.AddWithValue("@Talimatlar", talimat);
                command.Parameters.AddWithValue("@TarifID", tarifID);

                command.ExecuteNonQuery();

                TarifMalzemeGuncelle(tarifID,guncelmalzemeler,malzemebilgileri);
          
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.baglanti().Close();
            }
            
        }

        public void TarifMalzemeGuncelle(int tarifID, List<string> guncelmalzemeler, List<Malzemeler> malzemebilgileri)
        {
            try
            {
                // Mevcut malzemeleri almak
                List<int> mevcutMalzemeler = new List<int>();
                string query = "SELECT MalzemeID FROM Tbl_TarifMalzemeIliskisi WHERE TarifID = @tarifID";
                SqlCommand command2 = new SqlCommand(query, connection.baglanti());
                command2.Parameters.AddWithValue("@tarifID", tarifID);
                SqlDataReader reader = command2.ExecuteReader();

                while (reader.Read())
                {
                    mevcutMalzemeler.Add((int)reader["MalzemeID"]);
                }
                reader.Close();
                connection.baglanti().Close();  

                // Yeni malzemelerin ID'lerini almak
                List<int> yeniMalzemeler = new List<int>();
                foreach (var item in guncelmalzemeler)
                {
                    string query3 = "SELECT MalzemeID FROM Tbl_Malzemeler WHERE MalzemeAdi = @malzeme";
                    SqlCommand command3 = new SqlCommand(query3, connection.baglanti());
                    command3.Parameters.AddWithValue("@malzeme", item);
                    SqlDataReader reader2 = command3.ExecuteReader();

                    if (reader2.Read())
                    {
                        yeniMalzemeler.Add((int)reader2["MalzemeID"]);
                    }
                    reader2.Close();
                }

                // Yeni malzemeleri SQL'e ekleme
                foreach (int malzemeID in yeniMalzemeler)
                {
                    var malzemeBilgisi = malzemebilgileri.FirstOrDefault(m => m.MalzemeAdi == guncelmalzemeler[yeniMalzemeler.IndexOf(malzemeID)]);
                    if (malzemeBilgisi != null)
                    {
                        if (!mevcutMalzemeler.Contains(malzemeID))
                        {
                            // Ekleme işlemi
                            string insertQuery = "INSERT INTO Tbl_TarifMalzemeIliskisi (TarifID, MalzemeID, MalzemeMiktar, MalzemeBirim) VALUES (@TarifID, @MalzemeID, @Miktar, @MalzemeBirim)";
                            SqlCommand insertCommand = new SqlCommand(insertQuery, connection.baglanti());
                            insertCommand.Parameters.AddWithValue("@TarifID", tarifID);
                            insertCommand.Parameters.AddWithValue("@MalzemeID", malzemeID);
                            insertCommand.Parameters.AddWithValue("@Miktar", malzemeBilgisi.KullanilacakMalzemeMiktar);
                            insertCommand.Parameters.AddWithValue("@MalzemeBirim", malzemeBilgisi.MalzemeBirim);

                            insertCommand.ExecuteNonQuery();
                            connection.baglanti().Close();
                        }
                        else
                        {
                            // Güncelleme işlemi
                            string updateQuery = "UPDATE Tbl_TarifMalzemeIliskisi SET MalzemeMiktar = @Miktar, MalzemeBirim = @MalzemeBirim WHERE TarifID = @TarifID AND MalzemeID = @MalzemeID";
                            SqlCommand updateCommand = new SqlCommand(updateQuery, connection.baglanti());
                            updateCommand.Parameters.AddWithValue("@TarifID", tarifID);
                            updateCommand.Parameters.AddWithValue("@MalzemeID", malzemeID);
                            updateCommand.Parameters.AddWithValue("@Miktar", malzemeBilgisi.KullanilacakMalzemeMiktar);
                            updateCommand.Parameters.AddWithValue("@MalzemeBirim", malzemeBilgisi.MalzemeBirim);

                            updateCommand.ExecuteNonQuery();
                            connection.baglanti().Close();
                        }
                    }
                }

                // SQL'den silinmesi gereken malzemeler
                foreach (int malzemeID in mevcutMalzemeler)
                {
                    if (!yeniMalzemeler.Contains(malzemeID))
                    {
                        string deleteQuery = "DELETE FROM Tbl_TarifMalzemeIliskisi WHERE TarifID = @tarifID AND MalzemeID = @malzemeID";
                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection.baglanti());
                        deleteCommand.Parameters.AddWithValue("@tarifID", tarifID);
                        deleteCommand.Parameters.AddWithValue("@malzemeID", malzemeID);
                        deleteCommand.ExecuteNonQuery();
                        connection.baglanti().Close();

                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
            finally
            {
                connection.baglanti().Close();
                
            }
        }


        public List<Tarifler> Filtrele(string kategori, int sortOrder, float? maxMaliyet, float? minMaliyet)
        {
            List<Tarifler> tarifler = new List<Tarifler>();

            string queryByCategory = "SELECT DISTINCT t.TarifID, t.Resim, t.TarifAdi, t.HazirlamaSuresi FROM Tbl_Tarifler t" +
                    " INNER JOIN Tbl_Kategoriler k ON t.Kategori = k.KategoriID";


            
            if (!string.IsNullOrEmpty(kategori) && kategori != "")
            {
                queryByCategory += " where k.KategoriAdi='" + kategori + "'"; 
            }

            // Sıralama ekle
            if (sortOrder != 0 && (sortOrder >= 1 && sortOrder <= 4))
            {
                if (sortOrder == 1)
                {
                    queryByCategory += " ORDER BY t.TarifAdi ASC";
                }
                else if (sortOrder == 2)
                {
                    queryByCategory += " ORDER BY t.TarifAdi DESC";
                }
                else if (sortOrder == 3)
                {
                    queryByCategory += " ORDER BY t.HazirlamaSuresi ASC";
                }
                else if (sortOrder == 4)
                {
                    queryByCategory += " ORDER BY t.HazirlamaSuresi DESC";
                }
                else if (sortOrder == 5)
                {
                    queryByCategory += " ORDER BY t.HazirlamaSuresi DESC";

                }

            }

            SqlCommand command = new SqlCommand(queryByCategory, connection.baglanti());
            SqlDataReader reader = command.ExecuteReader();
            Malzemeler malzemeMaliyet = new Malzemeler();

            try
            {
                while (reader.Read())
                {
                    float maliyet = malzemeMaliyet.MaliyetHesabı(Convert.ToInt32(reader["TarifID"]));
                    if ((!minMaliyet.HasValue || maliyet >= minMaliyet.Value) && (!maxMaliyet.HasValue || maliyet <= maxMaliyet.Value))
                    {
                        Tarifler tarif = new Tarifler
                        {
                            Resim = reader["Resim"].ToString(),
                            TarifAdi = reader["TarifAdi"].ToString(),
                            HazirlamaSuresi = Convert.ToInt32(reader["HazirlamaSuresi"]),
                            Maliyet = maliyet,
                        };
                        tarifler.Add(tarif);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }

            finally
            {
                reader.Close();
                connection.baglanti().Close();
            }

            if (sortOrder != 0 && sortOrder >= 5)
            {
                if (sortOrder == 5)
                {
                    // Maliyete göre artan sıralama
                    tarifler = tarifler.OrderBy(t => t.Maliyet).ToList();
                }
                else if (sortOrder == 6)
                {
                    // Maliyete göre azalan sıralama
                    tarifler = tarifler.OrderByDescending(t => t.Maliyet).ToList();
                }

            }



            return tarifler;
        }

    }
}
