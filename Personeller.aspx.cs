using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Depo_Yonetimi.Sınıflar;


namespace Depo_Yonetimi
{
    public partial class Personeller : System.Web.UI.Page
    {
        DataBase db = new DataBase();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                db.SehirGetir(drpSehir);
                db.PersonelGetir(rptPersonel);
                var depolar = db.Depolar();
                DoldurDepolar(depolar);
            }
        }

        private void DoldurDepolar(List<Depo> depolar)
        {
            drpDepo.DataSource = depolar;
            drpDepo.DataValueField = nameof(Depo.DepoId);
            drpDepo.DataTextField = nameof(Depo.DepoAdi);
            drpDepo.DataBind(); 
        }

        int SehirID;
        int DepoId;


        protected void drpSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            SehirID = Convert.ToInt32(drpSehir.SelectedValue.ToString());

        }

        protected void drpSehir_DataBound(object sender, EventArgs e)
        {
            drpSehir.Items.Insert(0, "--Seçiniz--");
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            Personel personel = new Personel();
            personel.Id =Convert.ToInt32( txtpID.Text);
            personel.TC = txtpTc.Text;
            personel.Ad = txtpAd.Text;
            personel.Soyad = txtpSoyad.Text;
            personel.Unvan = txtpUnvan.Text;
            if (pCErkek.Checked == true)
                personel.Cinsiyet = "E";
            else if (pCKadin.Checked == true)
                personel.Cinsiyet = "K";


            personel.DogumGunu = Convert.ToDateTime(txtpDogumGunu.Text);
            personel.Adres = txtpAdres.Text;
            personel.SehirId = Convert.ToInt32(drpSehir.SelectedValue);
            personel.Telefon = txtpTelefon.Text;
            personel.IsBasıTarihi = Convert.ToDateTime(txtBaslangic.Text);
            personel.DepoId = Convert.ToInt32(drpDepo.SelectedValue);
            if (!string.IsNullOrEmpty(txtBitis.Text))
            {
                personel.IsSonuTarihi = Convert.ToDateTime(txtBitis.Text);
            }
            personel.Email = txtMail.Text;

            if (txtpID.Text != null && !string.IsNullOrWhiteSpace(txtpID.Text))
            {
                personel.Id =Convert.ToInt32(txtpID.Text);
                db.PersonelGuncelle(personel);
            }
            else
            {

                db.PersonelEkle(personel);

            }
            


            db.PersonelGetir(rptPersonel);
            ClearText();
        }

        private void ClearText()
        {
            txtpID.Text = "";
            txtpTc.Text = "";
            txtpAd.Text = "";
            txtpSoyad.Text = "";
            pCErkek.Checked = false;
            pCKadin.Checked = false;
            txtpDogumGunu.Text = "";
            txtpAdres.Text = "";
            txtpUnvan.Text = "";
            txtpTelefon.Text = "";
            txtBaslangic.Text = "";
            txtBitis.Text = "";
            txtMail.Text = "";
            drpSehir.SelectedValue = "--Seçiniz--";
            drpDepo.SelectedValue = "--Seçiniz--";


        }

        protected void btnSil_Click(object sender, EventArgs e)
        {

        }

        protected void PersonelSec_Click(object sender, EventArgs e)
        {

        }

        protected void pCErkek_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void pCKadin_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void rptPersonel_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case "Update":
                    string personelId = e.CommandArgument.ToString();
                    var personel = db.PersonelGoster(int.Parse(personelId));
                    txtpID.Text = personel.Id.ToString();
                    txtpTc.Text = Convert.ToString(personel.TC);
                    txtpAd.Text = personel.Ad;
                    txtpSoyad.Text = personel.Soyad;
                    txtpUnvan.Text = personel.Unvan;
                    if (personel.Cinsiyet == "E")
                        pCErkek.Checked = true;
                    else if (personel.Cinsiyet == "K")
                        pCKadin.Checked = true;

                    txtpDogumGunu.Text = personel.DogumGunu.ToString("yyyy-MM-dd");
                    txtpAdres.Text = personel.Adres;
                    txtpTelefon.Text = personel.Telefon;
                    drpSehir.SelectedValue = personel.SehirId.ToString();
                    txtBaslangic.Text = personel.IsBasıTarihi.ToString("yyyy-MM-dd");
                    if (personel.IsSonuTarihi.HasValue)
                        txtBitis.Text = personel.IsSonuTarihi.Value.ToString("yyyy-MM-dd");
                    txtMail.Text = personel.Email;
                    drpDepo.SelectedValue = personel.DepoId.ToString();


                    break;
                case "Delete":
                    int deletedPersonelId = int.Parse(e.CommandArgument.ToString());
                    db.PersonelSil(deletedPersonelId);
                    break;

                default:
                    break;
            }

            db.PersonelGetir(rptPersonel);

        }

        protected void txtpAdres_TextChanged(object sender, EventArgs e)
        {

        }

        protected void drpDepo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DepoId = Convert.ToInt32(drpDepo.SelectedValue.ToString());

        }

        protected void drpDepo_DataBound(object sender, EventArgs e)
        {
            drpDepo.Items.Insert(0, "--Seçiniz--");
        }
        //protected void perPersonelSec_ClickClicked(object sender, EventArgs e)
        //{
        //    db.PersonelGoster();
        //}
    }
}