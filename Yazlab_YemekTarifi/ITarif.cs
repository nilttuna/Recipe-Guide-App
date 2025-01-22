using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yazlab_YemekTarifi
{
    internal interface ITarif
    {
        Boolean TarifEkle(string dosyayolu, string tarifadi, int sure, int kategori, List<Malzemeler> malzemeler, string talimat);
        Boolean TarifSil(int tarifID);
        Boolean TarifGuncelle(int tarifID, string dosyayolu, string tarifadi, int sure, int kategori, string talimat, List<string> guncelmalzemeler, List<Malzemeler> malzemebilgileri);
        void TarifMalzemeGuncelle(int tarifID, List<string> guncelmalzemeler, List<Malzemeler> malzemebilgileri);
    }
}
