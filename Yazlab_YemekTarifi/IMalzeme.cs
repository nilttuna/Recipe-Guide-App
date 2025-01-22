using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yazlab_YemekTarifi
{
    internal interface IMalzeme
    {
        Boolean YeniMalzemeEkle(string malzemead, string toplammikatar, string birim, decimal birimfiyat);
        float MaliyetHesabı(int tarifid);
        float EksikMaliyetHesabı(int tarifid);
        bool StokKontrolu(string tarifAdi);
        Boolean stokGuncelle(int malzemeid, string malzemeadi, string toplammiktar, string birim, float birimfiyat);


    }
}
