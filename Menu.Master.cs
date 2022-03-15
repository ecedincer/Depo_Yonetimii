using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Depo_Yonetimi.Sınıflar;

namespace Depo_Yonetimi
{
    public partial class Menu : System.Web.UI.MasterPage
    {
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
                else { lblLogin.Text = adsoyad; }
            }

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}