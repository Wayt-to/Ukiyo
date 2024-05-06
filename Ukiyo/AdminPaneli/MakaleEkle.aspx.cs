using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ukiyo.AdminPaneli
{
    public partial class MakaleEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_kategoriler.DataSource = dm.TumKategorileriGetir();
                ddl_kategoriler.DataBind();
            }
        }

        protected void lbtn_geri_Click(object sender, EventArgs e)
        {
            Response.Redirect("Makale.aspx");
        }
        protected void lbtn_makEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_makBaslik.Text))
            {
                bool eklemedurum = true;
                Makaleler mak = new Makaleler();
                mak.Baslik = tb_makBaslik.Text;
                mak.Durum = cb_yayin.Checked;
                mak.GoruntulemeSayi = 0;
                mak.Icerik = tb_Icerik.Text;
                mak.Kategori_ID = Convert.ToInt32(ddl_kategoriler.SelectedItem.Value);
                mak.Ozet = tb_makOzet.Text;
                mak.Tarih = DateTime.Now;
                Yoneticiler y = (Yoneticiler)Session["yonetici"];
                mak.Yukleyen_ID = y.ID;
                if (fu_resim.HasFile)
                {
                    FileInfo fi = new FileInfo(fu_resim.FileName);
                    string resimuzanti = fi.Extension;
                    if (resimuzanti == ".jpg" || resimuzanti == ".png")
                    {
                        string isim = Guid.NewGuid().ToString();
                        mak.KapakResim = isim + resimuzanti;
                        fu_resim.SaveAs(Server.MapPath("../Images/MakaleResimleri/" + isim + resimuzanti));
                    }
                    else
                    {
                        eklemedurum = false;
                        pnl_basarili.Visible = false;
                        pnl_basarisiz.Visible = true;
                        lbl_hatamesaj.Text = "Resim Formatı uygun değildir. jpg ve png dosya kabul edilir";
                    }
                }
                else
                {
                    mak.KapakResim = "../Images/MakaleResimleri/none.jpg" ;
                }
                if (eklemedurum)
                {
                    if (dm.MakaleEkle(mak))
                    {
                        pnl_basarili.Visible = true;
                        pnl_basarisiz.Visible = false;
                    }
                    else
                    {
                        pnl_basarili.Visible = false;
                        pnl_basarisiz.Visible = true;
                        lbl_hatamesaj.Text = "Makale eklenirken bir hata oluştu";
                    }
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_hatamesaj.Text = "Başlık Boş bırakılmamalıdır";
            }
        }
    }
}