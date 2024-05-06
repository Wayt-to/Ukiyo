using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ukiyo.AdminPaneli
{
    public partial class ModeratorAtama : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            Yoneticiler yon = (Yoneticiler)Session["yonetici"];
            // Kullanıcının rolünü kontrol et
            if (yon.YoneticiTur_ID == 2)
            {
                // Eğer kullanıcı moderatör ise, uyeler.aspx sayfasına erişimi engelle
                Response.Redirect("ErisimYok.aspx");
            }
            else
            {
                
            }
        }

        protected void btn_kayit_Click(object sender, EventArgs e)
        {
            bool kayitBasarili = true;
            Yoneticiler u = new Yoneticiler();
            if (!string.IsNullOrEmpty(tb_kullaniciadi.Text))
            {
                if ((tb_kullaniciadi.Text.Length) <= 20)
                {
                    if (!string.IsNullOrEmpty(tb_email.Text))
                    {
                        if (tb_email.Text.Length <= 170)
                        {
                            if (!string.IsNullOrEmpty(tb_sifre.Text))
                            {
                                if (tb_sifre.Text.Length <= 20)
                                {
                                    if (this.tb_email.Text.Contains('@') || this.tb_email.Text.Contains('.'))
                                    {
                                        if (kayitBasarili)
                                        {
                                            u.Email = tb_email.Text;
                                            u.KullaniciAdi = tb_kullaniciadi.Text;
                                            
                                            u.Sifre = tb_sifre.Text;
                                            int sonuc =dm.ModeratorAtama(u);
                                            if (sonuc == 0)
                                            {
                                                pnl_basarisiz.Visible = true;
                                                lbl_mesaj.Text = "Kayıt esnasında bir hata oluştu. Lütfen daha sonra tekrar deneyiniz.";
                                            }
                                            if (sonuc == 3)
                                            {
                                                pnl_basarisiz.Visible = true;
                                                lbl_mesaj.Text = "Aynı email veya kullanıcı adına sahip başka kullanıcılar var lütfen bilgilerini gözden geçiriniz.";
                                            }
                                            if (sonuc == 2)
                                            {
                                                pnl_basarili.Visible = true;
                                                lbl_mesaj2.Text = "Moderatör başarıyla kaydedildi.";
                                            }
                                        }
                                        else
                                        {
                                            pnl_basarisiz.Visible = true;
                                            lbl_mesaj.Text = "Kayıt esnasında bir hata oluştu. Lütfen daha sonra tekrar deneyiniz.";
                                        }
                                    }
                                    else
                                    {
                                        kayitBasarili = false;
                                        pnl_basarisiz.Visible = true;
                                        lbl_mesaj.Text = "Lütfen geçerli bir e-mail giriniz.";
                                    }
                                }
                                else
                                {
                                    kayitBasarili = false;
                                    pnl_basarisiz.Visible = true;
                                    lbl_mesaj.Text = "Şifre en fazla 20 karakterden oluşabilir.";
                                }

                            }
                            else
                            {
                                kayitBasarili = false;
                                pnl_basarisiz.Visible = true;
                                lbl_mesaj.Text = "Şifre boş bırakılamaz";
                            }
                        }
                        else
                        {
                            kayitBasarili = false;
                            pnl_basarisiz.Visible = true;
                            lbl_mesaj.Text = "Lütfen geçerli bir email giriniz.";
                        }

                    }
                    else
                    {
                        kayitBasarili = false;
                        pnl_basarisiz.Visible = true;
                        lbl_mesaj.Text = "Email boş bırakılamaz";
                    }
                }
                else
                {
                    kayitBasarili = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Kullanıcı adı en fazla 20 karakterden oluşabilir.";
                }

            }
            else
            {
                kayitBasarili = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Kullanıcı adı boş bırakılamaz";
            }
        }
    }
}