using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Depo_Yonetimi.Sınıflar
{
    public class Depo
    {
        public int DepoId { get; set; }
        public string DepoAdi { get; set; }
        public int DepoTuruID { get; set; }
        public string Kapasite { get; set; }
        public string Adres { get; set; }
        public int SehirId { get; set; }
    }
}