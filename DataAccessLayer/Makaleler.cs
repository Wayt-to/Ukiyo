using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Makaleler
    {
        public int ID { get; set; }
        public int Kategori_ID { get; set; }
        public string Kategori { get; set; }
        public int Yukleyen_ID { get; set; }
        public string Yukleyen { get; set; }
        public string Baslik { get; set; }
        public string Ozet { get; set; }
        public string Icerik { get; set; }
        public string KapakResim { get; set; }
        public DateTime Tarih { get; set; }
        public string TarihStr { get; set; }

        public int GoruntulemeSayi { get; set; }
        public bool Durum { get; set; }
        public int MakaleSayisi { get; set; }
    }
}
