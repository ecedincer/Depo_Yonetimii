using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Depo_Yonetimi.Sınıflar;

namespace DepoYonetimi
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        static int kod;
        protected void btnGiris_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase(); 
            FA kontrol=new FA();

            string Email = txtEmail.Text.ToString();
            string sifre;
            string txtSifree = txtPassword.Text.ToString();
            
            sifre = db.UserGiris(Email);

            if (txtSifree == sifre)
            {
                // Response.Redirect("Menu.Master");
                kod=Convert.ToInt32(kontrol.dkod(Email));
                txtEmail.Enabled = false;
                txtPassword.Enabled = false;
                txtdkod.Visible = true;   
                btnGirisKod.Visible = true;
                btnGiris.Visible = false;
            }
            else
            {
                Response.Write("<script>alert('Email/Şifre hatalı tekrar deneyiniz...')</script>");
            }
        }

        protected void btnGirisKod_Click(object sender, EventArgs e)
        {
            int txtkod = Convert.ToInt32(txtdkod.Text);


            if (txtkod == kod)
            {
                Response.Redirect("Anasayfa.aspx");
            }
            else
            {
                Response.Write("<script>alert('Doğrulama kodu hatalı tekrar deneyiniz...')</script>");
            }
        }
    }
}