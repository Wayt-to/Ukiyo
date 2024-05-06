using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ukiyo.AdminPaneli
{
    public partial class MakaleleriListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_makaleler.DataSource = dm.MakaleleriListele();
            lv_makaleler.DataBind();
        }

        protected void lbtn_geri_Click(object sender, EventArgs e)
        {
            Response.Redirect("Makale.aspx");
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            var searchResults = from item in dm.MakaleleriListele()
                                where item.Baslik.Contains(SearchBox.Text)
                                select item;

            lv_makaleler.DataSource = searchResults;
            lv_makaleler.DataBind();
        }
    }
}