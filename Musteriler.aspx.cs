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
                db.SehirGetir(drpSehir);
                db.MusteriGetir(rptMusteri);
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

        protected void btnKaydet_Click(object sender, EventArgs e)
        {

        }
    }
}