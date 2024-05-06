using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData.ModelProviders;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace Ukiyo.AdminPaneli
{
    

    public partial class AdminLogin : System.Web.UI.Page
    {
        
        DataModel db = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_giris_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_kullaniciadi.Text))
            {
                if (!string.IsNullOrEmpty(tb_sifre.Text))
                {
                    
                    Yoneticiler yon = db.YoneticiGiris(tb_kullaniciadi.Text, tb_sifre.Text);
                    if (yon != null)
                    {
                        if (yon.ID != 0)
                        {
                            if (yon.Durum)
                            {
                                Session["yonetici"] = yon;
                                Response.Redirect("Default.aspx"); ;
                            }
                            else
                            {
                                pnl_basarisiz.Visible = true;
                                lbl_mesaj.Text = "Banlanmışsınız.";
                            }
                        }
                        else
                        {
                            pnl_basarisiz.Visible = true;
                            lbl_mesaj.Text = "Kullanıcı Bulunamadı";

                        }
                    }
                    else
                    {
                        pnl_basarisiz.Visible = true;
                        lbl_mesaj.Text = "Bir Hata Oluştu";
                    }
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Şifre Boş Bırakılamaz";
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Kullanıcı Adı Boş Bırakılamaz";
            }
        }
    }
}