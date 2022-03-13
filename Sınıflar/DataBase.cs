using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;


namespace Depo_Yonetimi.Sınıflar
{
    public class DataBase
    {


        private const string connectionStrings = "Data Source=LAPTOP-53M0RHJS\\OZGUNERBUDAK;Initial Catalog=DepoYonetimi;Trusted_Connection=True";

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
        public void PersonelGetir(Repeater rpt)
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
                    personel.Id = int.Parse(dataReader["PersonellerID"].ToString());
                }
                conn.Close();
                return personel;
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

                conn.Close();
                return personel;
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

                var result = komut.ExecuteNonQuery();
                conn.Close();
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

    }
}