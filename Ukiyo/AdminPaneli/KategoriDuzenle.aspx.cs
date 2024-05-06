using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ukiyo.AdminPaneli
{
    public partial class KategoriDuzenle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count !=0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["Kategori_ID"]);
                    Kategoriler kat = dm.KategoriGetir(id);
                    tb_katAdi.Text = kat.Isim;
                    tb_katAciklama.Text = kat.Aciklama;
                    cb_yayin.Checked = kat.Durum;
                }
            }
            else
            {
                Response.Redirect("KategoriListele.aspx");
            }
        }

        protected void lbtn_katDuzenle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["Kategori_ID"]);
            Kategoriler kat = dm.KategoriGetir(id);
            kat.Isim = tb_katAdi.Text;
            kat.Aciklama = tb_katAciklama.Text;
            kat.Durum = cb_yayin.Checked;
            if (dm.KategoriDuzenle(kat))
            {
                pnl_basarili.Visible = true;
                pnl_basarisiz.Visible = false;
            }
            else
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
                lbl_hatamesaj.Text = "Kategori düzenlenirken bir hata oluştu";
            }
        }

        protected void lbtn_katSil_Click(object sender, EventArgs e)
        {
            
            int id = Convert.ToInt32(Request.QueryString["Kategori_ID"]);
            try
            {
                dm.KategoriSil(id);
                Response.Redirect("KategoriListele.aspx");
            }
            catch
            {
                pnl_basarisiz.Visible = true;
                lbl_hatamesaj.Text = "Kullanımda olan bir kategoriyi silemezsin.";
            }
            finally
            {

            }
        }

        protected void lbtn_geri_Click(object sender, EventArgs e)
        {
            Response.Redirect("KategoriListele.aspx");
        }
    }
}