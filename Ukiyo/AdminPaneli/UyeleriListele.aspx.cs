using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ukiyo.AdminPaneli
{
    public partial class UyeleriListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            Yoneticiler yon = (Yoneticiler)Session["yonetici"];
            // Kullanıcının rolünü kontrol et
            if (yon.YoneticiTur_ID == 2)
            {
                // Eğer kullanıcı moderatör ise, uyeler.aspx sayfasına erişimi engelle
                Response.Redirect("Default.aspx");
            }
            else
            {
                lv_Uyeler.DataSource = dm.UyeleriListele();
                lv_Uyeler.DataBind();
            }

        }

        protected void lv_Uyeler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            dm.UyeDurumDegistir(id);

            lv_Uyeler.DataSource = dm.UyeleriListele();
            lv_Uyeler.DataBind();

        }

        protected void lbtn_geri_Click(object sender, EventArgs e)
        {
            Response.Redirect("Uyeler.aspx");
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            var searchResults = from item in dm.UyeleriListele()
                                where item.KullaniciAdi.Contains(SearchBox.Text)
                                select item;

            lv_Uyeler.DataSource = searchResults;
            lv_Uyeler.DataBind();
        }

        
    }
}