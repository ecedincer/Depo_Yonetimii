using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Depo_Yonetimi.Sınıflar;


namespace Depo_Yonetimi
{
    public partial class Musteriler : System.Web.UI.Page
    {
        DataBase db = new DataBase();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DataBase db = new DataBase();
                object admink = Session["Email"];

                string adsoyad;

                adsoyad = db.User((string)admink);


                if (admink == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    txtkullanici.Text = adsoyad;
                    db.SehirGetir(drpSehir);
                    db.MusteriGetir(rptMusteri);
                }
            }

        }
        int SehirID;
        int IlceID;
        protected void drpSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            SehirID = Convert.ToInt32(drpSehir.SelectedValue.ToString());
            db.Ilce_MahGetir(drpIlce, "Ilceler", SehirID);
            drpIlce.SelectedIndex = 0;
            drpMah.SelectedIndex = 0;
        }

        protected void drpIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            IlceID= Convert.ToInt32(drpIlce.SelectedValue.ToString());
            db.Ilce_MahGetir(drpMah, "SemtMah", IlceID);
        }

        protected void drpIlce_DataBound(object sender, EventArgs e)
        {
            drpIlce.Items.Insert(0, "--Seçiniz--");
            drpMah.Items.Insert(0, "--Seçiniz--");
        }

        protected void drpSehir_DataBound(object sender, EventArgs e)
        {
            drpSehir.Items.Insert(0, "--Seçiniz--");
            drpIlce.Items.Insert(0, "--Seçiniz--");
            drpMah.Items.Insert(0, "--Seçiniz--");
        }

        protected void drpMah_DataBound(object sender, EventArgs e)
        {
            drpMah.Items.Insert(0, "--Seçiniz--");
        }

        
        
        protected void btnSil_Click(object sender, EventArgs e)
        {

        }

        protected void MusteriSec_Click(object sender, EventArgs e)
        {

        }


        int MusteriID;
        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            DataBase db= new DataBase();
            //TEXTBOXLAR BOŞ GEÇİLEMEZ SORGUSU
            if (string.IsNullOrEmpty(txtmAd.Text) || string.IsNullOrWhiteSpace(txtKontak.Text)
                && string.IsNullOrEmpty(txtAdres.Text) || string.IsNullOrWhiteSpace(txtTelefon.Text)
                && string.IsNullOrEmpty(txtUnvan.Text)
                )
            {
                Response.Write("<script>alert('Boş Geçilemez')</script>");
            }

            else
            {
                //TELEFON NO 11 HANEDEN KISA OLAMAZ SORGUSU
                string tel = txtTelefon.Text;
                if (tel.Length == 11)
                {

                    int telno = Convert.ToInt32(db.telno(txtUnvan.Text));
                    //DATABASEDE GİRİLEN TEDARİKCİ İSMİNDE KAYIT VAR MI SORGUSU

                    if (telno > 0)
                    {
                        Response.Write("<script>alert('Bu İsimde Veri Kayıtlı')</script>");
                    }
                }
                else
                {
                    //TEK BUTTONDA KAYIT YAPTIĞIMIZ İÇİN SEÇİLEN TEDARİKCİNİNS İD Sİ YOK İSE YENİ KAYIT EKLE SORUGUSU
                    if (string.IsNullOrEmpty(txtmID.Text) || string.IsNullOrWhiteSpace(txtmID.Text))
                    {
                        Response.Write("<script>alert('Tedarikci Eklendi')</script>");

                        db.MusteriEkle();

                        MusteriID = Convert.ToInt32(db.MusteriID());

                        txtAdres = "";
                        txtTelefon.Text = "";
                        txtmAd.Text = "";

                    }
                }
            }