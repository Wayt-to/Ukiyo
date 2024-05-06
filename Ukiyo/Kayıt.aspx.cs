using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ukiyo
{
    public partial class Kayıt : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_giris_Click(object sender, EventArgs e)
        {
            bool kayitBasarili = true;
            Uyeler u = new Uyeler();
            if (!string.IsNullOrEmpty(tb_kullaniciadi.Text))
            {
                if ((tb_kullaniciadi.Text.Length)<=20)
                {
                    if (!string.IsNullOrEmpty(tb_email.Text))
                    {
                        if (tb_email.Text.Length<=170)
                        {
                            if (!string.IsNullOrEmpty(tb_sifre.Text))
                            {
                                if (tb_sifre.Text.Length<=20)
                                {
                                    if (this.tb_email.Text.Contains('@') || this.tb_email.Text.Contains('.'))
                                    {
                                        if (kayitBasarili)
                                        {
                                            u.Email = tb_email.Text;
                                            u.KullaniciAdi = tb_kullaniciadi.Text;
                                            u.UyelikTarihi = DateTime.Now;
                                            u.Sifre = tb_sifre.Text;
                                            int sonuc = dm.UyeKayit(u);
                                            if (sonuc==0)
                                            {
                                                pnl_basarisiz.Visible = true;
                                                lbl_mesaj.Text = "Kayıt esnasında bir hata oluştu. Lütfen daha sonra tekrar deneyiniz.";
                                            }
                                            if (sonuc==3)
                                            {
                                                pnl_basarisiz.Visible = true;
                                                lbl_mesaj.Text = "Aynı email veya kullanıcı adına sahip başka kullanıcılar var lütfen bilgilerini gözden geçiriniz.";
                                            }
                                            if (sonuc==2)
                                            {
                                                Session["uye"] = u;
                                                Response.Redirect("Default.aspx");
                                            }
                                        }
                                        else
                                        {
                                            pnl_basarisiz.Visible = true;
                                            lbl_mesaj.Text = "Kayıt esnasında bir hata oluştu. Lütfen daha sonra tekrar deneyiniz2.";
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