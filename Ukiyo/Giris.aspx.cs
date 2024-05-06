using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ukiyo
{
    public partial class Giris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_giris_Click(object sender, EventArgs e)
        {
            DataModel dm = new DataModel();
            if (!string.IsNullOrEmpty(tb_kullaniciadi.Text))
            {
                if (!string.IsNullOrEmpty(tb_sifre.Text))
                {
                    Uyeler u = dm.UyeGiris(tb_kullaniciadi.Text, tb_sifre.Text);
                    if (u != null)
                    {
                        if (u.ID != 0)
                        {
                            if (u.Durum)
                            {
                                Session["uye"] = u;
                                Response.Redirect("Default.aspx");
                            }
                            else
                            {
                                pnl_basarisiz.Visible = true;
                                lbl_mesaj.Text = "Hesabınız askıya alınmıştır. Yönetici ile görüşünüz!";
                            }
                        }
                        else
                        {
                            pnl_basarisiz.Visible = true;
                            lbl_mesaj.Text = "Kullanıcı bulunamadı. Bilgileri kontrol ediniz";
                        }
                    }
                    else
                    {
                        pnl_basarisiz.Visible = true;
                        lbl_mesaj.Text = "Bir hata oluştu lütfen daha sonra deneyiniz";
                    }
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Şifre boş bırakılamaz";
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Kullanıcı adı boş bırakılamaz";
            }
        }
    }
}