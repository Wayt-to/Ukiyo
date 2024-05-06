using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ukiyo.AdminPaneli
{
    public partial class ModeratorListesi : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            Yoneticiler yon = (Yoneticiler)Session["yonetici"];
            if (yon.YoneticiTur_ID == 2)
            {
                
                Response.Redirect("ErisimYok.aspx");
            }
            else
            {
                lv_Modlar.DataSource = dm.ModlariListele();
                lv_Modlar.DataBind();
            }
        }
        protected void lbtn_geri_Click(object sender, EventArgs e)
        {
            Response.Redirect("Uyeler.aspx");
        }

        protected void lv_Modlar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            dm.ModDurumDeğiştir(id);

            lv_Modlar.DataSource = dm.ModlariListele();
            lv_Modlar.DataBind();
            
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            var searchResults = from item in dm.ModlariListele()
                                where item.KullaniciAdi.Contains(SearchBox.Text)
                                select item;

            lv_Modlar.DataSource = searchResults;
            lv_Modlar.DataBind();
        }

        protected void SearchButton_Click1(object sender, EventArgs e)
        {

        }
    }
}