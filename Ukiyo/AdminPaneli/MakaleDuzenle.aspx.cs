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
    public partial class MakaleDuzenle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["Makale_ID"]);
                    Makaleler mak = dm.MakaleGetir(id);

                    ddl_kategoriler.DataSource = dm.TumKategorileriGetir();
                    ddl_kategoriler.DataBind();
                    ddl_kategoriler.SelectedValue = mak.Kategori_ID.ToString();
                    tb_makBaslik.Text = mak.Baslik;
                    tb_Icerik.Text = mak.Icerik;
                    tb_makOzet.Text = mak.Ozet;
                    cb_yayin.Checked = mak.Durum;
                    img_resim.ImageUrl = "../Images/MakaleResimleri/" + mak.KapakResim;

                }
            }
            else
            {
                Response.Redirect("MakaleleriListele.aspx");
            }
        }
       
        protected void lbtn_geri_Click(object sender, EventArgs e)
        {
            Response.Redirect("Makale.aspx");
        }

        protected void lbtn_makDuzenle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["Makale_ID"]);
            Makaleler mak = dm.MakaleGetir(id);
            mak.Durum = cb_yayin.Checked;
            mak.Baslik = tb_makBaslik.Text;
            mak.Ozet = tb_makOzet.Text;
            mak.Icerik = tb_Icerik.Text;
            mak.Kategori_ID = Convert.ToInt32(ddl_kategoriler.SelectedItem.Value);
            bool eklemedurum = true;
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
            if (eklemedurum)
            {
                if (dm.MakaleDuzenle(mak))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                    
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_hatamesaj.Text = "Makale Düzenlenirken Bir Hata Oluştu";
                }
            }
        }

        protected void lbtn_makSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["Makale_ID"]);
            dm.MakaleSil(id);
            Response.Redirect("MakaleleriListele.aspx");
        }
    }
}