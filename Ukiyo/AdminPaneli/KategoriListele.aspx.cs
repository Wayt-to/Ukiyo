using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ukiyo.AdminPaneli
{
    public partial class KategoriListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_kategoriler.DataSource = dm.TumKategorileriGetir();
            lv_kategoriler.DataBind();
        }

        protected void lbtn_geri_Click(object sender, EventArgs e)
        {
            Response.Redirect("Kategori.aspx");
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            var searchResults = from item in dm.TumKategorileriGetir()
                                where item.Isim.Contains(SearchBox.Text)
                                select item;

            lv_kategoriler.DataSource = searchResults;
            lv_kategoriler.DataBind();
        }
    }
}