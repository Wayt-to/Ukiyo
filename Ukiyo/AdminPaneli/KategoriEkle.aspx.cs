using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace Ukiyo.AdminPaneli
{
    public partial class KategoriEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_katEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_katAdi.Text))
            {
                Kategoriler kat = new Kategoriler();
                kat.Isim = tb_katAdi.Text;
                kat.Aciklama = tb_katAciklama.Text;
                kat.Durum = cb_yayin.Checked;
                if (dm.KategoriEkle(kat))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_hatamesaj.Text = "Kategori eklenirken bir hata oluştu.";
                }

            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_hatamesaj.Text = "Kategori adı boş bırakılamaz.";
            }
        }

        protected void lbtn_geri_Click(object sender, EventArgs e)
        {
            Response.Redirect("Kategori.aspx");
        }
    }
}