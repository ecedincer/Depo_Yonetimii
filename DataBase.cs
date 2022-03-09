using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


namespace DepoYonetimi
{
    public class DataBase
    {
        static SqlConnection conn = new SqlConnection("Data Source=DESKTOP-0RARGM4\\SQLEXPRESS;Initial Catalog=DepoYonetimi;Trusted_Connection=True");
        static SqlDataAdapter adapter;
        static DataTable dt;
        static SqlCommand komut;
        static SqlDataReader dr;
        string sifre;

        public string UserGiris(string Email)
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
}