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
    public partial class MakaleIcerik : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataModel dm = new DataModel();
            if (!IsPostBack)
            {
                
                if (Request.QueryString.Count != 0)
                {
                    int id = Convert.ToInt32(Request.QueryString["MakaleID"]);
                    Makaleler m = dm.MakaleGetir(id);
                    ltrl_Yazar.Text = m.Yukleyen;
                    ltrl_baslik.Text = m.Baslik;
                    ltrl_Icerik.Text = m.Icerik;
                    ltrl_kategori.Text = m.Kategori;
                    ltrl_Tarih.Text = m.TarihStr;
                    img_resim.ImageUrl = "Images/MakaleResimleri/" + m.KapakResim;
                    if (Session["uye"] != null)
                    {
                        pnl_girisvar.Visible = true;
                        pnl_girisYok.Visible = false;
                    }
                    else
                    {
                        pnl_girisvar.Visible = false;
                        pnl_girisYok.Visible = true;
                    }
                    rp_yorumlar.DataSource = dm.YorumlariGetir(id);
                    rp_yorumlar.DataBind();
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
            
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            DataModel dm = new DataModel();
            if (tb_yorum.Text.Length<=500)
            {
                if (!string.IsNullOrEmpty(tb_yorum.Text))
                {

                    DataAccessLayer.Yorumlar yorum = new DataAccessLayer.Yorumlar();
                    DataAccessLayer.Uyeler uye = (DataAccessLayer.Uyeler)Session["uye"];
                    yorum.Uye_ID = uye.ID;
                    yorum.UyeIsim = uye.KullaniciAdi;
                    yorum.Icerik = tb_yorum.Text;
                    yorum.Tarih = DateTime.Now;
                    yorum.Durum = false;
                    yorum.Makale_ID = Convert.ToInt32(Request.QueryString["MakaleID"]);
                    dm.YorumEkle(yorum);
                    pnl_basarili.Visible = true;
                    lbl_mesaj2.Text = "Yorumunuz alındı. Moderatörlerimizin incelemesi sonrasında yayınlanacak.";

                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Yorumunuz çok uzun. Lütfen 500 karakteri aşmayınız.";

            }
            
            
        }
    }
}