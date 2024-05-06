using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace Ukiyo.AdminPaneli
{
    
    public partial class YorumOnay : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_Yorumlar.DataSource = dm.OnaysizYorumlar();
            lv_Yorumlar.DataBind();

        }
        protected void lv_Yorumlar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName=="durum")
            {
                dm.YorumDurumDegistir(id);
                lv_Yorumlar.DataSource = dm.YorumlariGetir();
                lv_Yorumlar.DataBind();
            }
            if (e.CommandName=="sil")
            {
                bool sil =dm.YorumSil(id);
                if (sil)
                {
                    pnl_basarili.Visible = true;
                    lbl_basarili.Text = "Yorum silme işlemi başarılı.";
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    lbl_basarisiz.Text ="Yorum silme işlemi başarısız. Bir hata oluştu.";
                }
            }
            lv_Yorumlar.DataSource = dm.OnaysizYorumlar();
            lv_Yorumlar.DataBind();
        }

        protected void lbtn_geri_Click(object sender, EventArgs e)
        {
            Response.Redirect("Yorumlar.aspx");
        }
    }
}