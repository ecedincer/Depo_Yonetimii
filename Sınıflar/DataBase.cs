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
        static SqlConnection conn = new SqlConnection("Data Source=DESKTOP-0RARGM4\\SQLEXPRESS;Initial Catalog=DepoYonetimi;Trusted_Connection=True");
        static SqlDataAdapter adapter;
        static DataTable dt;
        static SqlCommand komut;
        static SqlDataReader dr;
        string sifre;
        static DropDownList ddl=new DropDownList();

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

        public void SehirGetir(DropDownList ddl)
        {
            adapter = new SqlDataAdapter("Select * from Sehirler order by SehirAdi asc", conn);
            dt=new DataTable();
            adapter.Fill(dt);
            ddl.DataSource = dt;
            ddl.DataValueField = "SehirID";
            ddl.DataTextField = "SehirAdi";
            ddl.DataBind();
        }

        public void Ilce_MahGetir(DropDownList ddlmah,string table,int Id)
        {

            if (table=="Ilceler")
            {
                adapter = new SqlDataAdapter("Select * from Ilceler where SehirID='" + Id + "' order by IlceAdi asc", conn);
                dt = new DataTable();
                adapter.Fill(dt);
                ddlmah.DataSource = dt;
                ddlmah.DataValueField = "ilceId";
                ddlmah.DataTextField = "IlceAdi";
                ddlmah.DataBind();
            }
            else if (table=="SemtMah")
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

        public void MusteriGetir(Repeater rpt)
        {
            komut = new SqlCommand("spMusteriSelect", conn);
            conn.Open();
            rpt.DataSource = komut.ExecuteReader();
            rpt.DataBind();
            conn.Close();
        }




    }
}