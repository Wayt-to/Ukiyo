using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ukiyo.AdminPaneli;

namespace Ukiyo
{
    public partial class Default : System.Web.UI.MasterPage
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uye"] != null)
            {
                DataAccessLayer.Uyeler u = Session["uye"] as DataAccessLayer.Uyeler;
                pnl_girisvar.Visible = true;
                pnl_girisyok.Visible = false;
                ltrl_uye.Text = u.KullaniciAdi;
            }
            else
            {
                pnl_girisvar.Visible = false;
                pnl_girisyok.Visible = true;
            }
            if (!IsPostBack)
            {
                int Uzunluk = dm.AktifMakSayi();
                int id = dm.RandomMakaleID(Uzunluk);
                sas.HRef = $"MakaleIcerik.aspx?MakaleID={id}";
            }
        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["uye"] = null;
            Response.Redirect("Default.aspx");
            
        }
    }
}
