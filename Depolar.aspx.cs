using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Depo_Yonetimi.Sınıflar;


namespace Depo_Yonetimi
{
    public partial class Depolar : System.Web.UI.Page
    {
        DataBase db = new DataBase();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                db.SehirGetir(drpSehir);
                //db.DepoGetir(rptDepo);
                var depolar = db.Depolar();
                db.Getir(rptDepo, "spDepoSelect");
            }
        }
        int SehirID;

        protected void drpSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            SehirID = Convert.ToInt32(drpSehir.SelectedValue.ToString());

        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            Depo depo = new Depo();
            depo.DepoAdi = txtdAd.Text;
            depo.Adres = txtAdres.Text;
            depo.Kapasite = txtKapasite.Text;
            depo.DepoTuruID = Convert.ToInt32(drpDTuru.SelectedValue);
            depo.SehirId = Convert.ToInt32(drpSehir.SelectedValue);
            depo.IlceId = Convert.ToInt32(drpIlce.SelectedValue);
            ClearText();
        }
        private void ClearText()
        {
            txtdAd.Text = "";
            txtAdres.Text = "";
            txtKapasite.Text = "";
            drpSehir.SelectedValue = "--Seçiniz--";
            drpIlce.SelectedValue = "--Seçiniz--";
            drpDTuru.SelectedValue = "--Seçiniz--";

        }
        protected void rptDepo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case "Update":
                    string depoId = e.CommandArgument.ToString();
                    var depo = db.DepoGoster(int.Parse(depoId));
                    txtdAd.Text = depo.DepoAdi;
                    txtAdres.Text = depo.Adres;
                    txtKapasite.Text = depo.Kapasite;
                    drpSehir.SelectedValue = depo.SehirId.ToString();
                    drpSehir.SelectedValue = depo.IlceId .ToString();
                    drpSehir.SelectedValue = depo.DepoTuruID.ToString();

                    break;
                case "Delete":
                    int deletedDepoId = int.Parse(e.CommandArgument.ToString());
                    db.DepoSil(deletedDepoId);
                    break;

                default:
                    break;
            }

            db.DepoGetir(rptDepo);

        }
        protected void btnSil_Click(object sender, EventArgs e)
        {

        }
        protected void PersonelSec_Click(object sender, EventArgs e)
        {

        }

        protected void drpTuru_DataBound(object sender, EventArgs e)
        {
            drpDTuru.Items.Insert(0, "--Seçiniz--");
        }

        protected void drpTuru_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void drpSehir_DataBound(object sender, EventArgs e)
        {
            drpSehir.Items.Insert(0, "--Seçiniz--");
        }



        protected void drpIlce_DataBound(object sender, EventArgs e)
        {
            drpIlce.Items.Insert(0, "--Seçiniz--");
        }

        protected void drpIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        protected void DepoSec_Click(object sender, EventArgs e)
        {

        }
    }
}