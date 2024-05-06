using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ukiyo.AdminPaneli
{
    public partial class Uyeler : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Yoneticiler yon = (Yoneticiler)Session["yonetici"];
            if (yon.YoneticiTur_ID == 1)
            {
                
            }
            else
            {
                // Eğer kullanıcı admin değil ise, uyeler.aspx sayfasına erişimi engelle
                Response.Redirect("ErisimYok.aspx");
            }

        }

        
        
    }
}