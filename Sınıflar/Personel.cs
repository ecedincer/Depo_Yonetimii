using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Depo_Yonetimi.Sınıflar
{
    public class Personel
    {
        public int Id { get; set; }
        public string TC { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Unvan { get; set; }
        public string Cinsiyet { get; set; }
        public DateTime DogumGunu { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string SehirAdi { get; set; }
        public DateTime IsBasıTarihi { get; set; }
        public DateTime? IsSonuTarihi { get; set; }
        public string Email { get; set; }
        public int SehirId { get; set; }
        public int DepoId { get; set; }
        public string DepoAdi { get; set; }
       
    }
}