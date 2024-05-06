using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Yorumlar
    {
        public int ID { get; set; }
        public int Makale_ID { get; set; }
        public string MakaleBaslik { get; set; }
        public int Uye_ID { get; set; }
        public string UyeIsim { get; set;}
        public string Icerik { get; set; }
        public DateTime Tarih { get; set; }
        public string TarihStr { get; set; }
        public bool Durum { get; set; }

    }
}
