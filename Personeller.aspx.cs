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
            }
        }
        int SehirID;


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
            if (!string.IsNullOrEmpty(txtBitis.Text))
            {
                personel.IsSonuTarihi = Convert.ToDateTime(txtBitis.Text);
            }
            personel.Email = txtMail.Text;

            if (txtpID.Text != null && !string.IsNullOrWhiteSpace(txtpID.Text))
            {
                personel.Id = int.Parse(txtpID.Text);
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
            txtpTc.Text = "";
            txtpAd.Text = "";
            txtpSoyad.Text = "";
            pCErkek.Checked = false;
            pCKadin.Checked = false;
            txtpDogumGunu.Text = "";
            txtpAdres.Text = "";
            txtpTelefon.Text = "";
            txtBaslangic.Text = "";
            txtBitis.Text = "";
            txtMail.Text = "";
            drpSehir.SelectedValue = "--Seçiniz--";

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
        //protected void perPersonelSec_ClickClicked(object sender, EventArgs e)
        //{
        //    db.PersonelGoster();
        //}
    }
}