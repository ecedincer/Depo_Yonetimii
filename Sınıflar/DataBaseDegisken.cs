using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Depo_Yonetimi.Sınıflar
{
    public class DataBaseDegisken
    {
    }
    public class Sehir
    {
        public int SehirId { get; set; }
        public string SehirName { get; set; }
    }
    public class Ilce:Sehir
    {
        public int IlceId { get; set; }
        public string IlceAdi { get; set; }
    }
    public class Mah:Ilce
    {
        public int MahId { get; set; }
        public string MahName { get; set; }
    }


}