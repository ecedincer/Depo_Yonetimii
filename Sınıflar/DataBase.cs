using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using Depo_Yonetimi.Sınıflar;


namespace Depo_Yonetimi.Sınıflar
{
    public class DataBase
    {


        private const string connectionStrings = "Data Source=DESKTOP-0RARGM4\\SQLEXPRESS;Initial Catalog=DepoYonetimi;Trusted_Connection=True";

        //static SqlConnection conn = new SqlConnection("Data Source=LAPTOP-53M0RHJS\\OZGUNERBUDAK;Initial Catalog=DepoYonetimi;Trusted_Connection=True");
        //static SqlConnection conn ;


        //public SqlConnection GetSqlConnection()
        //{
        //    if(conn !=null)
        //        return conn ;
        //    conn = new SqlConnection(connectionStrings);
        //    return conn ;
        //}

        static SqlDataAdapter adapter;
        static DataTable dt;
        static SqlCommand komut;
        static SqlDataReader dr;
        string sifre;
        static DropDownList ddl = new DropDownList();
        int personelID;

        public string UserGiris(string Email)
        {
            using (SqlConnection conn = new SqlConnection(connectionStrings))
            {
                komut = new SqlCommand("sp_Login", conn);

                dt = new DataTable();
                conn.Open();
                komut.CommandType = CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@Email", Email);
                dr = komut.ExecuteReader();

                while (dr.Read())
                {
                    sifre = dr.GetString(0).ToString();
                }

                conn.Close();
                return sifre;
            }

        }

        string ad, soyad;
        string adSoyad;

        public string User(string Email)
        {
            using (SqlConnection conn = new SqlConnection(connectionStrings))
            {
                komut = new SqlCommand("sp_LoginAd", conn);



                dt = new DataTable();
                conn.Open();
                komut.CommandType = CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@Email", Email);
                dr = komut.ExecuteReader();

                while (dr.Read())
                {
                    ad = dr.GetString(0).ToString();
                    soyad = dr.GetString(1).ToString();
                }

                adSoyad = ad + " " + soyad;

                conn.Close();
                return adSoyad;
            }
        }

        public void SehirGetir(DropDownList ddl)
        {
            using (SqlConnection conn = new SqlConnection(connectionStrings))
            {
                adapter = new SqlDataAdapter("Select * from Sehirler order by SehirAdi asc", conn);
                dt = new DataTable();
                adapter.Fill(dt);
                ddl.DataSource = dt;
                ddl.DataValueField = "SehirID";
                ddl.DataTextField = "SehirAdi";
                ddl.DataBind();
            }
            
        }

        public void Ilce_MahGetir(DropDownList ddlmah, string table, int Id)
        {
            using (SqlConnection conn = new SqlConnection(connectionStrings))
            {

                if (table == "Ilceler")
                {
                    adapter = new SqlDataAdapter("Select * from Ilceler where SehirID='" + Id + "' order by IlceAdi asc", conn);
                    dt = new DataTable();
                    adapter.Fill(dt);
                    ddlmah.DataSource = dt;
                    ddlmah.DataValueField = "ilceId";
                    ddlmah.DataTextField = "IlceAdi";
                    ddlmah.DataBind();
                }
                else if (table == "SemtMah")
                {
                    adapter = new SqlDataAdapter("Select * from SemtMah where ilceID='" + Id + "' order by MahalleAdi asc", conn);
                    dt = new DataTable();
                    adapter.Fill(dt);
                    ddlmah.DataSource = dt;
                    ddlmah.DataValueField = "MahalleID";
                    ddlmah.DataTextField = "MahalleAdi";
                    ddlmah.DataBind();
                }
            }

        }

        public void MusteriGetir(Repeater rpt)
        {
            using (SqlConnection conn = new SqlConnection(connectionStrings))
            {

                komut = new SqlCommand("spMusteriSelect", conn);
                conn.Open();
                rpt.DataSource = komut.ExecuteReader();
                rpt.DataBind();
                conn.Close();
            }
        }
        public void  PersonelGetir(Repeater rpt)
        {
            using (SqlConnection conn = new SqlConnection(connectionStrings))
            {
                komut = new SqlCommand("spPersonelSelect", conn);
                conn.Open();
                rpt.DataSource = komut.ExecuteReader();
                rpt.DataBind();
                conn.Close();
            }
            

        }
        public void Getir(Repeater rpt,String a)
        {
            using (SqlConnection conn = new SqlConnection(connectionStrings))
            {
                komut = new SqlCommand(a.ToString(), conn);
                conn.Open();
                rpt.DataSource = komut.ExecuteReader();
                rpt.DataBind();
                conn.Close();
            }



        }

        public void DepoGetir(Repeater rpt)
        {
            using (SqlConnection conn = new SqlConnection(connectionStrings))
            {
                komut = new SqlCommand("spDepoSelect", conn);
                conn.Open();
                rpt.DataSource = komut.ExecuteReader();
                rpt.DataBind();
                conn.Close();
            }


        }

        public Personel PersonelGoster(int personelId)
        {
            using (SqlConnection conn = new SqlConnection(connectionStrings))
            {
                komut = new SqlCommand("spPersonelGetir", conn);
                komut.CommandType = CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@PersonellerID", personelId);
                conn.Open();
                var dataReader = komut.ExecuteReader();
                Personel personel = new Personel();
                while (dataReader.Read())
                {
                    personel.TC = dataReader["TC"].ToString();
                    personel.Ad = dataReader["Adı"].ToString();
                    personel.Soyad = dataReader["Soyadı"].ToString();
                    personel.Unvan = dataReader["Unvan"].ToString();
                    personel.Cinsiyet = dataReader["Cinsiyet"].ToString();
                    personel.DogumGunu = Convert.ToDateTime(dataReader["DogumGunu"].ToString());
                    personel.Adres = dataReader["Adres"].ToString();
                    personel.Telefon = dataReader["Telefon"].ToString();
                    personel.SehirAdi = dataReader["SehirAdi"].ToString();
                    personel.IsBasıTarihi = Convert.ToDateTime(dataReader["IsBasıTarihi"].ToString());
                    if (!string.IsNullOrEmpty(dataReader["IsSonuTarihi"].ToString()))
                    {               
                        personel.IsSonuTarihi = Convert.ToDateTime(dataReader["IsSonuTarihi"].ToString());
                    }
                    personel.Email = dataReader["Email"].ToString();
                    personel.SehirId = int.Parse(dataReader["SehirId"].ToString());
                    personel.DepoAdi = dataReader["DepoAdi"].ToString();
                    personel.DepoId = Convert.ToInt32(dataReader["DepoID"].ToString());
                    personel.Id = int.Parse(dataReader["PersonellerID"].ToString());
                }
                conn.Close();
                 return personel;
            }
        }
        public Depo DepoGoster(int depoId)
        {
            using (SqlConnection conn = new SqlConnection(connectionStrings))
            {
                komut = new SqlCommand("spDepoGetir", conn);
                komut.CommandType = CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@DepolarID", depoId);
                conn.Open();
                var dataReader = komut.ExecuteReader();
                Depo depo = new Depo();
                while (dataReader.Read())
                {
                    depo.DepoAdi = dataReader["DepoAdi"].ToString();
                    depo.Kapasite = dataReader["Kapasite"].ToString();
                    depo.DepoTuruID = Convert.ToInt32(dataReader["Adres"].ToString());
                    depo.Adres = dataReader["Adres"].ToString();
                    depo.SehirId = int.Parse(dataReader["SehirId"].ToString());
                }
                conn.Close();
                return depo;
            }
        }
        public Personel PersonelGuncelle(Personel personel)
        {

            using (SqlConnection conn = new SqlConnection(connectionStrings))

            {

                komut = new SqlCommand("spPersonelGuncelle ", conn);
                komut.CommandType = CommandType.StoredProcedure;
                conn.Open();
                komut.Parameters.AddWithValue("@PersonellerID", personel.Id);
                komut.Parameters.AddWithValue("@TC", personel.TC);
                komut.Parameters.AddWithValue("@Adi", personel.Ad);
                komut.Parameters.AddWithValue("@Soyadı", personel.Soyad);
                komut.Parameters.AddWithValue("@Unvan", personel.Unvan);
                komut.Parameters.AddWithValue("@Cinsiyet", personel.Cinsiyet);
                komut.Parameters.AddWithValue("@DogumGunu", personel.DogumGunu);
                komut.Parameters.AddWithValue("@Adres", personel.Adres);
                komut.Parameters.AddWithValue("@SehirID", personel.SehirId);
                komut.Parameters.AddWithValue("@Telefon", personel.Telefon);
                komut.Parameters.AddWithValue("@IsBasıTarihi", personel.IsBasıTarihi);
                komut.Parameters.AddWithValue("@IsSonuTarihi", personel.IsSonuTarihi);
                komut.Parameters.AddWithValue("@Email", personel.Email);
                komut.Parameters.AddWithValue("@DepoId", personel.DepoId);

                conn.Close();
                return personel;
            }
        }
        public Depo DepoGuncelle(Depo depo)
        {

            using (SqlConnection conn = new SqlConnection(connectionStrings))

            {

                komut = new SqlCommand("spDepoGuncelle ", conn);
                komut.CommandType = CommandType.StoredProcedure;
                conn.Open();
                komut.Parameters.AddWithValue("@DepolarID", depo.DepoId);
                komut.Parameters.AddWithValue("@DepoAdı", depo.DepoAdi);
                komut.Parameters.AddWithValue("@DepoTuruID", depo.DepoTuruID);
                komut.Parameters.AddWithValue("@Kapasite", depo.Kapasite);
                komut.Parameters.AddWithValue("@Adres", depo.Adres);
                komut.Parameters.AddWithValue("@SehirID", depo.SehirId);
                komut.Parameters.AddWithValue("@IlceID", depo.IlceId);

                conn.Close();
                return depo;
            }
        }

        public void PersonelEkle(Personel personel)
        {
            using (SqlConnection conn = new SqlConnection(connectionStrings))
            {
                komut = new SqlCommand("spPersonelEkle", conn);
                komut.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                komut.Parameters.AddWithValue("@TC", personel.TC);
                komut.Parameters.AddWithValue("@Adi", personel.Ad);
                komut.Parameters.AddWithValue("@Soyadi", personel.Soyad);
                komut.Parameters.AddWithValue("@Unvan", personel.Unvan);
                komut.Parameters.AddWithValue("@Cinsiyet", personel.Cinsiyet);
                komut.Parameters.AddWithValue("@DogumGunu", personel.DogumGunu);
                komut.Parameters.AddWithValue("@Adres", personel.Adres);
                komut.Parameters.AddWithValue("@SehirID", personel.SehirId);
                komut.Parameters.AddWithValue("@Telefon", personel.Telefon);
                komut.Parameters.AddWithValue("@IsBasiTarihi", personel.IsBasıTarihi);
                komut.Parameters.AddWithValue("@IsSonuTarihi", personel.IsSonuTarihi);
                komut.Parameters.AddWithValue("@Email", personel.Email);
                komut.Parameters.AddWithValue("@DepoId", personel.DepoId);

                
                var result = komut.ExecuteNonQuery();
                conn.Close();
            }


        }
        public void DepoEkle(Depo depo)
        {
            using (SqlConnection conn = new SqlConnection(connectionStrings))
            {

                komut = new SqlCommand("spDepoEkle ", conn);
                komut.CommandType = CommandType.StoredProcedure;
                conn.Open();
                komut.Parameters.AddWithValue("@DepoAdı", depo.DepoAdi);
                komut.Parameters.AddWithValue("@DepoTuruID", depo.DepoTuruID);
                komut.Parameters.AddWithValue("@Kapasite", depo.Kapasite);
                komut.Parameters.AddWithValue("@Adres", depo.Adres);
                komut.Parameters.AddWithValue("@SehirID", depo.SehirId);
                komut.Parameters.AddWithValue("@IlceID", depo.IlceId);

                conn.Close();
            }


        }

        public List<Depo> Depolar()
        {
            List<Depo> depolar = new List<Depo>();
            using (SqlConnection conn = new SqlConnection(connectionStrings))
            {
                komut = new SqlCommand("SELECT * FROM Depolar", conn);
        
                conn.Open();
                var dataReader = komut.ExecuteReader();
                
           
                while (dataReader.Read())
                {
                    Depo depo = new Depo();
                    depo.DepoId =int.Parse( dataReader["DepolarID"].ToString());
                    depo.DepoAdi = dataReader["DepoAdi"].ToString();
                    depolar.Add(depo);
                    
                }
                conn.Close();
                return depolar;
            }
        }


        public void PersonelSil(int personelId)
        {
            using (SqlConnection conn = new SqlConnection(connectionStrings))
            {
                komut = new SqlCommand("spPersonelSil", conn);
                komut.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                komut.Parameters.AddWithValue("@PersonellerID", personelId);
                var result = komut.ExecuteNonQuery();

                conn.Close();
            }


        }
        public void DepoSil(int depoId)
        {
            using (SqlConnection conn = new SqlConnection(connectionStrings))
            {
                komut = new SqlCommand("spDepoSil", conn);
                komut.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                komut.Parameters.AddWithValue("@ID", depoId);
                var result = komut.ExecuteNonQuery();

                conn.Close();
            }


        }
        

        public  string telno(string MusteriAd)
        {
            using (SqlConnection conn = new SqlConnection(connectionStrings)) 
            {
                
                string vs_Select = "SELECT * FROM Musteriler where ";
                vs_Select += "Kontak='" + MusteriAd + "'";
                
                SqlCommand komut = new SqlCommand(vs_Select, conn);
                conn.Open();
                SqlDataAdapter oku = new SqlDataAdapter();
                oku.SelectCommand = komut;
                DataTable dt = new DataTable();
                oku.Fill(dt);

                string tel=dt.Rows[0][0].ToString();

                return tel;

                

            }
        }

        public void MusteriEkle()
        {
            using (SqlConnection conn = new SqlConnection(connectionStrings))
            {
                

                DataTable tablo = new DataTable();
                Musteriler dbd = new Musteriler();
                conn.Open();
                komut = new SqlCommand("spMusteriEkle", conn);
                komut.CommandType = CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@SirketAdi", dbd.SirketAdi );
                komut.Parameters.AddWithValue("@Kontak", dbd.Kontak);
                komut.Parameters.AddWithValue("@Unvan", dbd.Unvan);
                komut.Parameters.AddWithValue("@Adres", dbd.Adres);
                komut.Parameters.AddWithValue("@MahalleID", dbd.MahalleID);
                komut.Parameters.AddWithValue("@Telefon", dbd.Telefon);
                komut.ExecuteNonQuery();
                conn.Close();
                
            }
        }

        public string MusteriID()
        {
            using (SqlConnection conn = new SqlConnection(connectionStrings))
            {
                
                string sql = "Select top 1 MusteriID from Musteriler order by MusteriID desc";
                SqlCommand cmd2 = new SqlCommand(sql, conn);

                conn.Open();
                SqlDataReader sonuc = cmd2.ExecuteReader();
                while (sonuc.Read())
                {
                   string MusteriID = sonuc["MusteriID"].ToString();
                }
                conn.Close();


                return MusteriID;
            }
        }

    }
}