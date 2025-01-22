using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yazlab_YemekTarifi
{
    internal class Malzemeler:IMalzeme
    {
        sqlConnection connection = new sqlConnection();
        Random random = new Random();

        public string MalzemeAdi { get; set; }
        public string MalzemeBirim { get; set; }
        public float KullanilacakMalzemeMiktar { get; set; }

        public List<Malzemeler> MalzemeAdlari()
        {
            List<Malzemeler> malzemelist = new List<Malzemeler>();
            SqlCommand commandMalzeme = new SqlCommand("SELECT DISTINCT MalzemeAdi FROM Tbl_Malzemeler", connection.baglanti());
            SqlDataReader dr = commandMalzeme.ExecuteReader();

            while (dr.Read())
            {
                Malzemeler malzeme = new Malzemeler
                {
                    MalzemeAdi = dr["MalzemeAdi"].ToString(),
                };
                malzemelist.Add(malzeme);
                
            }
            dr.Close();
            connection.baglanti().Close();

            return malzemelist;
        }

        public List<string>MalzemeBirimleri()
        {
            List<string> birimlistesi = new List<string>();
            SqlCommand command = new SqlCommand("SELECT DISTINCT MalzemeBirim FROM Tbl_Malzemeler", connection.baglanti());
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                MalzemeBirim = dr["MalzemeBirim"].ToString();
                birimlistesi.Add(MalzemeBirim);
            }
            dr.Close();
            connection.baglanti().Close();

            return birimlistesi;
        }

        public Boolean YeniMalzemeEkle(string malzemead,string toplammikatar,string birim,decimal birimfiyat)
        {
            try
            {
                SqlCommand commandname = new SqlCommand("SELECT COUNT(*) FROM Tbl_Malzemeler WHERE MalzemeAdi = @MalzemeAdi", connection.baglanti());
                commandname.Parameters.AddWithValue("@MalzemeAdi", malzemead);

                int count = (int)commandname.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Bu malzeme zaten mevcut.");
                    connection.baglanti().Close();
                    return false;
                }
                else
                {
                    SqlCommand command = new SqlCommand("INSERT INTO Tbl_Malzemeler (MalzemeAdi,ToplamMiktar,MalzemeBirim,BirimFiyat)" +
                "values (@MalzemeAdi,@ToplamMiktar,@MalzemeBirim,@BirimFiyat)", connection.baglanti());
                    command.Parameters.AddWithValue("@MalzemeAdi", malzemead);
                    command.Parameters.AddWithValue("@ToplamMiktar", toplammikatar);
                    command.Parameters.AddWithValue("@MalzemeBirim", birim);
                    command.Parameters.AddWithValue("@BirimFiyat", birimfiyat);
                    int etkilenen_satir = command.ExecuteNonQuery();



                    if (etkilenen_satir > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

            }
                
            catch (Exception ex) 
            { 
                MessageBox.Show("Malzeme eklenemedi.");
                return false;
            }
            finally
            {
                connection.baglanti().Close();
            }


        }
        public List<Tarifler> GetMalzemeyeGöreTarif(List<string> secilimalzemeadlari)
        {
            List<Tarifler> tarifler = new List<Tarifler>();
            string malzemeParametreleri = string.Join(",", secilimalzemeadlari.Select((m, i) => $"@malzeme{i}"));

            int malzemeSayisi = secilimalzemeadlari.Count;


            string query = "SELECT t.TarifID, t.TarifAdi, t.Resim, t.HazirlamaSuresi, "+ "(SELECT COUNT(DISTINCT tm2.MalzemeID) FROM Tbl_TarifMalzemeIliskisi tm2 WHERE tm2.TarifID = t.TarifID) AS tarifMalzemeSayisi, "+
               "(CAST(@secilenMalzemeSayisi AS FLOAT) / (SELECT COUNT(DISTINCT tm2.MalzemeID) FROM Tbl_TarifMalzemeIliskisi tm2 WHERE tm2.TarifID = t.TarifID)) AS malzemeOrani " +
               "FROM Tbl_Tarifler t INNER JOIN Tbl_TarifMalzemeIliskisi tm ON t.TarifID = tm.TarifID " +
               "WHERE tm.MalzemeID IN (SELECT MalzemeID FROM Tbl_Malzemeler WHERE MalzemeAdi IN (" + malzemeParametreleri + ")) " +
               "GROUP BY t.TarifID, t.TarifAdi, t.Resim, t.HazirlamaSuresi " + 
               "HAVING COUNT(DISTINCT tm.MalzemeID) = @count "+
               "ORDER BY malzemeOrani DESC";

            SqlCommand commandtarif= new SqlCommand(query, connection.baglanti());
            
            // Parametreleri ekle
            for (int i = 0; i < secilimalzemeadlari.Count; i++)
            {
                commandtarif.Parameters.AddWithValue($"@malzeme{i}", secilimalzemeadlari[i]);
            }
            commandtarif.Parameters.AddWithValue("@count", secilimalzemeadlari.Count); 
            commandtarif.Parameters.AddWithValue("@secilenMalzemeSayisi", secilimalzemeadlari.Count);


            SqlDataReader dr = commandtarif.ExecuteReader();
            Malzemeler malzemeMaliyet = new Malzemeler();


            try
            {
                while (dr.Read())
                {
                    Tarifler tarif = new Tarifler
                    {
                        Resim = dr["Resim"].ToString(),
                        TarifAdi = dr["TarifAdi"].ToString(),
                        HazirlamaSuresi = Convert.ToInt32(dr["HazirlamaSuresi"]),
                        EslesmeOrani = (float.Parse(dr["malzemeOrani"].ToString()) * 100),
                        Maliyet = malzemeMaliyet.MaliyetHesabı(Convert.ToInt32(dr["TarifID"])), 
                    };
                    tarifler.Add(tarif);
                }

            }
            catch 
            {
                MessageBox.Show("Tarifler Listelenemedi");
            }
            finally
            {
                dr.Close();
                connection.baglanti().Close();
            }

            return tarifler;
        }

        public float MaliyetHesabı(int tarifid)
        {
            float toplammaliyet = 0;
            
                SqlCommand commandMaliyet = new SqlCommand(
                "SELECT SUM(CASE " +
                "WHEN tm.MalzemeBirim = 'gram'  THEN (tm.MalzemeMiktar / 1000) * m.BirimFiyat " +
                "WHEN tm.MalzemeBirim = 'mililitre' THEN (tm.MalzemeMiktar / 1000) * m.BirimFiyat " +
                "ELSE tm.MalzemeMiktar * m.BirimFiyat END) AS ToplamMaliyet " +
                "FROM Tbl_TarifMalzemeIliskisi tm " +
                "JOIN Tbl_Malzemeler m ON tm.MalzemeID = m.MalzemeID " +
                "WHERE tm.TarifID = @TarifID", connection.baglanti());

                commandMaliyet.Parameters.AddWithValue("@TarifID", tarifid);

                SqlDataReader dr = commandMaliyet.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (dr["ToplamMaliyet"] != DBNull.Value)
                    {
                        toplammaliyet = float.Parse(dr["ToplamMaliyet"].ToString());
                    }
                }
            }
            catch
            {
                Console.WriteLine("Hata");
            }
            finally
            {
                dr.Close();
                connection.baglanti().Close();
            }


            return toplammaliyet;
        }

        public float EksikMaliyetHesabı(int tarifid)
        {
            float eksikmaliyet = 0;

            return eksikmaliyet;


        }

        public bool StokKontrolu(string tarifAdi)
        {

            SqlCommand commandGetTarifID = new SqlCommand(
                "SELECT TarifID FROM Tbl_Tarifler WHERE TarifAdi = @TarifAdi", connection.baglanti());
            commandGetTarifID.Parameters.AddWithValue("@TarifAdi", tarifAdi);

            int tarifID = 0;

            SqlDataReader drTarifID = commandGetTarifID.ExecuteReader();
            if (drTarifID.Read())
            {
                tarifID = Convert.ToInt32(drTarifID["TarifID"]);
            }
            drTarifID.Close();

            if (tarifID == 0)
            {
                connection.baglanti().Close();
                return false;
            }

            SqlCommand commandStokKontrol = new SqlCommand(
                "SELECT tm.MalzemeMiktar, tm.MalzemeBirim AS TarifBirim, m.ToplamMiktar, m.MalzemeBirim " +
                "FROM Tbl_TarifMalzemeIliskisi tm " +
                "JOIN Tbl_Malzemeler m ON tm.MalzemeID = m.MalzemeID " +
                "WHERE tm.TarifID = @TarifID", connection.baglanti());
            commandStokKontrol.Parameters.AddWithValue("@TarifID", tarifID);

            SqlDataReader dr = commandStokKontrol.ExecuteReader();

            bool yeterliStok = true; 

            try
            {
                while (dr.Read())
                {
                    decimal tarifMiktar = Convert.ToDecimal(dr["MalzemeMiktar"]);
                    string tarifBirim = dr["TarifBirim"].ToString();
                    decimal stokMiktar = Convert.ToDecimal(dr["ToplamMiktar"]);
                    string stokBirim = dr["MalzemeBirim"].ToString();


                    if (stokBirim == "kilogram" && tarifBirim == "gram")
                    {
                        stokMiktar *= 1000;
                    }
                    else if (stokBirim == "gram" && tarifBirim == "kilogram")
                    {
                        stokMiktar /= 1000;
                    }
                    else if (stokBirim == "litre" && tarifBirim == "mililitre")
                    {
                        stokMiktar *= 1000;
                    }
                    else if (stokBirim == "mililitre" && tarifBirim == "litre")
                    {
                        stokMiktar /= 1000;
                    }


                    if (tarifMiktar > stokMiktar)
                    {
                        yeterliStok = false;
                        break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Başarısız");
            }
            finally
            {
                dr.Close();
                connection.baglanti().Close();

            }

            return yeterliStok;
        }




        public Boolean stokGuncelle(int malzemeid,string malzemeadi,string toplammiktar,string birim,float birimfiyat)
        {
            try
            {
                SqlCommand commandStok = new SqlCommand("UPDATE Tbl_Malzemeler SET MalzemeAdi = @MalzemeAdi, ToplamMiktar=@ToplamMiktar, MalzemeBirim = @MalzemeBirim, BirimFiyat = @BirimFiyat WHERE MalzemeID = @MalzemeID", connection.baglanti());
                commandStok.Parameters.AddWithValue("@MalzemeAdi", malzemeadi);
                commandStok.Parameters.AddWithValue("@ToplamMiktar", toplammiktar);
                commandStok.Parameters.AddWithValue("@MalzemeBirim", birim);
                commandStok.Parameters.AddWithValue("@BirimFiyat", birimfiyat);
                commandStok.Parameters.AddWithValue("@MalzemeID", malzemeid);
                int etkilenen_satir = commandStok.ExecuteNonQuery();
                if(etkilenen_satir>0)
                {
                    return true;

                }
                else
                { 
                    return false;
                }   

            }
            catch
            {
                return false;
            }
            finally
            {
                connection.baglanti().Close();
            }



        }



    }
}
