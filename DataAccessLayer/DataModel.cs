using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {
        
        SqlConnection con;SqlCommand cmd;
        public DataModel()
        {
            con = new SqlConnection(ConnectionPath.MainConnection);
            cmd = con.CreateCommand();
        }

        #region Yonetici Islemleri

        public Yoneticiler YoneticiGiris(string kullaniciAdi, string sifre)
        {
            try
            {
                Yoneticiler yon = new Yoneticiler();
                cmd.CommandText = "SELECT Y.ID, Y.YoneticiTur_ID, YT.Isim,Y.KullaniciAdi,Y.Email,Y.Sifre,Y.Durum FROM Yoneticiler AS Y JOIN YoneticiTurleri AS YT ON Y.YoneticiTur_ID = YT.ID WHERE Y.KullaniciAdi = @kadi AND Y.Sifre =@sifre";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kadi", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@sifre",sifre);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    yon.ID = reader.GetInt32(0);
                    yon.YoneticiTur_ID = reader.GetInt32(1);
                    yon.YoneticiTur = reader.GetString(2);
                    yon.KullaniciAdi = reader.GetString(3);
                    yon.Email = reader.GetString(4);
                    yon.Sifre = reader.GetString(5);
                    yon.Durum = reader.GetBoolean(6);
                }
                return yon;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Kategori Metotlari

        public bool KategoriEkle(Kategoriler kat)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Kategoriler(Isim,Aciklama,Durum) VALUES (@isim,@aciklama,@durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", kat.Isim);
                cmd.Parameters.AddWithValue("@durum", kat.Durum);
                cmd.Parameters.AddWithValue("@aciklama", kat.Aciklama);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Kategoriler> TumKategorileriGetir()
        {
            List<Kategoriler> kategoriler = new List<Kategoriler>();
            try
            {
                cmd.CommandText = "SELECT ID,Isim,Aciklama,Durum FROM Kategoriler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kategoriler kat = new Kategoriler();
                    kat.ID = reader.GetInt32(0);
                    kat.Isim = reader.GetString(1);
                    kat.Aciklama = reader.GetString(2);
                    kat.Durum = reader.GetBoolean(3);
                    kategoriler.Add(kat);
                }
                return kategoriler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Kategoriler> TumAktifKategorileriGetir()
        {
            List<Kategoriler> kategoriler = new List<Kategoriler>();
            try
            {
                cmd.CommandText = "SELECT ID,Isim,Aciklama,Durum FROM Kategoriler WHERE Durum=1";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kategoriler kat = new Kategoriler();
                    kat.ID = reader.GetInt32(0);
                    kat.Isim = reader.GetString(1);
                    kat.Aciklama = reader.GetString(2);
                    kat.Durum = reader.GetBoolean(3);
                    kategoriler.Add(kat);
                }
                return kategoriler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public Kategoriler KategoriGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID, Isim, Aciklama, Durum FROM Kategoriler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Kategoriler kat = new Kategoriler();
                while (reader.Read())
                {
                    kat.ID = reader.GetInt32(0);
                    kat.Isim = reader.GetString(1);
                    kat.Aciklama = reader.GetString(2);
                    kat.Durum = reader.GetBoolean(3);
                }
                return kat;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public bool KategoriDuzenle(Kategoriler kat)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler SET Isim=@isim, Aciklama=@aciklama, Durum=@durum WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", kat.ID);
                cmd.Parameters.AddWithValue("@isim", kat.Isim);
                cmd.Parameters.AddWithValue("@aciklama", kat.Aciklama);
                cmd.Parameters.AddWithValue("@durum", kat.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public void KategoriSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Kategoriler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Makale Metotlari

        public bool MakaleEkle(Makaleler mak)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Makaleler(Kategori_ID, Yukleyen_ID, Baslik, Ozet,Icerik,KapakResim,Tarih,GoruntulemeSayi,Durum) VALUES(@kategori_ID, @Yukleyen_ID, @baslik, @ozet, @icerik, @kapakResim, @tarih, @goruntulemeSayi, @durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kategori_ID", mak.Kategori_ID);
                cmd.Parameters.AddWithValue("@Yukleyen_ID", mak.Yukleyen_ID);
                cmd.Parameters.AddWithValue("@baslik", mak.Baslik);
                cmd.Parameters.AddWithValue("@ozet", mak.Ozet);
                cmd.Parameters.AddWithValue("@icerik", mak.Icerik);
                cmd.Parameters.AddWithValue("@kapakResim", mak.KapakResim);
                cmd.Parameters.AddWithValue("@tarih", mak.Tarih);
                cmd.Parameters.AddWithValue("@goruntulemeSayi", mak.GoruntulemeSayi);
                cmd.Parameters.AddWithValue("@durum", mak.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Makaleler> MakaleleriListele()
        {
            try
            {
                List<Makaleler> makaleler = new List<Makaleler>();
                cmd.CommandText = "SELECT M.ID,M.Kategori_ID,K.Isim,M.Yukleyen_ID, Y.KullaniciAdi, M.Baslik, M.Ozet,M.Icerik,M.KapakResim,M.Tarih,M.GoruntulemeSayi, M.Durum FROM Makaleler AS M JOIN Kategoriler AS K ON M.Kategori_ID=K.ID JOIN Yoneticiler AS Y ON M.Yukleyen_ID=Y.ID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Makaleler mak = new Makaleler();
                    mak.ID = reader.GetInt32(0);
                    mak.Kategori_ID = reader.GetInt32(1);
                    mak.Kategori = reader.GetString(2);
                    mak.Yukleyen_ID = reader.GetInt32(3);
                    mak.Yukleyen = reader.GetString(4);
                    mak.Baslik = reader.GetString(5);
                    mak.Ozet = reader.GetString(6);
                    mak.Icerik = reader.GetString(7);
                    mak.KapakResim = reader.GetString(8);
                    mak.Tarih = reader.GetDateTime(9);
                    mak.GoruntulemeSayi = reader.GetInt32(10);
                    mak.Durum = reader.GetBoolean(11);
                    mak.TarihStr = mak.Tarih.ToShortDateString();
                    makaleler.Add(mak);
                }
                return makaleler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Makaleler> MakaleleriListele(bool durum)
        {
            try
            {
                List<Makaleler> makaleler = new List<Makaleler>();
                cmd.CommandText = "SELECT M.ID,M.Kategori_ID,K.Isim,M.Yukleyen_ID, Y.KullaniciAdi, M.Baslik, M.Ozet,M.Icerik,M.KapakResim,M.Tarih,M.GoruntulemeSayi, M.Durum FROM Makaleler AS M JOIN Kategoriler AS K ON M.Kategori_ID=K.ID JOIN Yoneticiler AS Y ON M.Yukleyen_ID=Y.ID WHERE M.Durum =@d AND K.Durum =1";
                //Kategori durumu aktif olmayan makaleler görünmeyecek.
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@d",durum);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Makaleler mak = new Makaleler();
                    mak.ID = reader.GetInt32(0);
                    mak.Kategori_ID = reader.GetInt32(1);
                    mak.Kategori = reader.GetString(2);
                    mak.Yukleyen_ID = reader.GetInt32(3);
                    mak.Yukleyen = reader.GetString(4);
                    mak.Baslik = reader.GetString(5);
                    mak.Ozet = reader.GetString(6);
                    mak.Icerik = reader.GetString(7);
                    mak.KapakResim = reader.GetString(8);
                    mak.Tarih = reader.GetDateTime(9);
                    mak.GoruntulemeSayi = reader.GetInt32(10);
                    mak.Durum = reader.GetBoolean(11);
                    mak.TarihStr = mak.Tarih.ToShortDateString();
                    makaleler.Add(mak);
                }
                return makaleler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Makaleler> MakaleleriListele(int KategoriID)
        {
            try
            {
                List<Makaleler> makaleler = new List<Makaleler>();
                cmd.CommandText = "SELECT M.ID,M.Kategori_ID,K.Isim,M.Yukleyen_ID, Y.KullaniciAdi, M.Baslik, M.Ozet,M.Icerik,M.KapakResim,M.Tarih,M.GoruntulemeSayi, M.Durum FROM Makaleler AS M JOIN Kategoriler AS K ON M.Kategori_ID=K.ID JOIN Yoneticiler AS Y ON M.Yukleyen_ID=Y.ID WHERE M.Kategori_ID=@kid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kid", KategoriID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Makaleler mak = new Makaleler();
                    mak.ID = reader.GetInt32(0);
                    mak.Kategori_ID = reader.GetInt32(1);
                    mak.Kategori = reader.GetString(2);
                    mak.Yukleyen_ID = reader.GetInt32(3);
                    mak.Yukleyen = reader.GetString(4);
                    mak.Baslik = reader.GetString(5);
                    mak.Ozet = reader.GetString(6);
                    mak.Icerik = reader.GetString(7);
                    mak.KapakResim = reader.GetString(8);
                    mak.Tarih = reader.GetDateTime(9);
                    mak.GoruntulemeSayi = reader.GetInt32(10);
                    mak.Durum = reader.GetBoolean(11);
                    mak.TarihStr = mak.Tarih.ToShortDateString();
                    makaleler.Add(mak);
                }
                return makaleler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public Makaleler MakaleGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT M.ID, M.Kategori_ID, K.Isim, M.Yukleyen_ID, Y.KullaniciAdi, M.Baslik, M.Ozet, M.Icerik, M.KapakResim, M.Tarih, M.GoruntulemeSayi, M.Durum FROM Makaleler AS M JOIN Kategoriler AS K ON M.Kategori_ID = K.ID JOIN Yoneticiler AS Y ON M.Yukleyen_ID = Y.ID WHERE M.ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Makaleler mak = new Makaleler();
                while (reader.Read())
                {
                    mak.ID = reader.GetInt32(0);
                    mak.Kategori_ID = reader.GetInt32(1);
                    mak.Kategori = reader.GetString(2);
                    mak.Yukleyen_ID = reader.GetInt32(3);
                    mak.Yukleyen = reader.GetString(4);
                    mak.Baslik = reader.GetString(5);
                    mak.Ozet = reader.GetString(6);
                    mak.Icerik = reader.GetString(7);
                    mak.KapakResim = reader.GetString(8);
                    mak.Tarih = reader.GetDateTime(9);
                    mak.TarihStr = mak.Tarih.ToShortDateString();
                    mak.GoruntulemeSayi = reader.GetInt32(10);
                    mak.Durum = reader.GetBoolean(11);
                }
                return mak;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public bool MakaleDuzenle(Makaleler mak)
        {
            
            try
            {
                cmd.CommandText = "UPDATE Makaleler SET Kategori_ID=@kategori_ID, Baslik=@baslik, Ozet=@ozet, Icerik=@icerik, KapakResim=@kapakResim, Durum=@durum WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", mak.ID);
                cmd.Parameters.AddWithValue("@kategori_ID",mak.Kategori_ID);
                cmd.Parameters.AddWithValue("@baslik", mak.Baslik);
                cmd.Parameters.AddWithValue("@ozet", mak.Ozet);
                cmd.Parameters.AddWithValue("@icerik", mak.Icerik);
                cmd.Parameters.AddWithValue("@kapakResim", mak.KapakResim);
                cmd.Parameters.AddWithValue("@durum", mak.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool MakaleSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Makaleler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public int AktifMakSayi()
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Makaleler WHERE Durum=1";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int Uzunluk = 1;
                while (reader.Read())
                {
                    Uzunluk = reader.GetInt32(0);
                }
                return Uzunluk;
            }
            catch
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }
        public int RandomMakaleID(int Uzunluk)
        {
            try
            {
                
                cmd.CommandText = "SELECT ID FROM Makaleler WHERE Durum=1";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int[] idler = new int[Uzunluk];
                for (int i = 0; i < idler.Length;)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        idler[i] = id;
                        i++;
                    }
                }
                Random rnd = new Random();
                int rndEleman = rnd.Next(0, Uzunluk);
                return idler[rndEleman];
                
            }
            catch
            {
                return 0;

            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Uye Metotlari

        public int UyeKayit(Uyeler u)
        {
            try
            {
                cmd.CommandText="SELECT COUNT(*) FROM Uyeler WHERE KullaniciAdi = @kadi OR Email = @email";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kadi", u.KullaniciAdi);
                cmd.Parameters.AddWithValue("@email", u.Email);
                con.Open();
                int varMi = (int)cmd.ExecuteScalar();
                con.Close();
                if (varMi >0)
                {
                    return 3;
                }
                else
                {
                    cmd.CommandText = "INSERT INTO Uyeler(KullaniciAdi, Email, Sifre, UyelikTarihi,Durum) VALUES(@kadi,@email,@sifre,@time,@durum)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@kadi", u.KullaniciAdi);
                    cmd.Parameters.AddWithValue("@email", u.Email);
                    cmd.Parameters.AddWithValue("@sifre", u.Sifre);
                    cmd.Parameters.AddWithValue("@time", u.UyelikTarihi);
                    cmd.Parameters.AddWithValue("@durum", 1);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    return 2;
                }

                
            }
            catch
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }

        public Uyeler UyeGiris(string kadi, string sifre)
        {
            try
            {
                Uyeler u = new Uyeler();
                cmd.CommandText = "SELECT * FROM Uyeler WHERE KullaniciAdi=@kadi AND Sifre =@sifre";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kadi",kadi);
                cmd.Parameters.AddWithValue("@sifre",sifre);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    u.ID = reader.GetInt32(0);
                    u.KullaniciAdi = reader.GetString(1);
                    u.Email = reader.GetString(2);
                    u.Sifre = reader.GetString(3);
                    u.UyelikTarihi = reader.GetDateTime(4);
                    u.Durum = reader.GetBoolean(5);
                }
                return u;
            }
            catch
            {
                return null;

            }
            finally
            {
                con.Close();
            }
        }

        public List<Uyeler> UyeleriListele()
        {
            try
            {
                List<Uyeler> uyelist = new List<Uyeler>();
                cmd.CommandText = "SELECT ID,KullaniciAdi,Email,UyelikTarihi,Durum FROM Uyeler ";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    Uyeler u = new Uyeler();
                    u.ID = reader.GetInt32(0);
                    u.KullaniciAdi = reader.GetString(1);
                    u.Email = reader.GetString(2);
                    u.UyelikTarihi = reader.GetDateTime(3);
                    u.Durum = reader.GetBoolean(4);
                    uyelist.Add(u);
                }
                return uyelist;
            }
            catch
            {
                
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public void UyeDurumDegistir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Durum From Uyeler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum = Convert.ToBoolean(cmd.ExecuteScalar());

                cmd.CommandText = "UPDATE Uyeler SET Durum=@d WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@d", !durum);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Yorum Metotlari

        public bool YorumEkle(Yorumlar y)
        {
            try
            {
                
                cmd.CommandText = "INSERT INTO Yorumlar(Makale_ID, Uye_ID,UyeAdi, Icerik,Tarih,Durum) VALUES(@makale_ID, @Uye_ID,@kadi, @icerik, @tarih, @durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@makale_ID", y.Makale_ID);
                cmd.Parameters.AddWithValue("@Uye_ID", y.Uye_ID);
                cmd.Parameters.AddWithValue("@kadi", y.UyeIsim);
                cmd.Parameters.AddWithValue("@icerik", y.Icerik);
                cmd.Parameters.AddWithValue("@tarih", y.Tarih);
                cmd.Parameters.AddWithValue("@durum", y.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Yorumlar> YorumlariGetir(int mak_id)
        {
            try
            {
                List<Yorumlar> yorumlar = new List<Yorumlar>();
                cmd.CommandText = "SELECT Y.ID, Y.Makale_ID, M.Baslik, Y.Uye_ID, U.KullaniciAdi, Y.Icerik, Y.Tarih, Y.Durum FROM Yorumlar AS Y JOIN Uyeler AS U ON Y.Uye_ID = U.ID JOIN Makaleler AS M ON Y.Makale_ID = M.ID WHERE M.ID = @mid AND Y.Durum = 1;";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mid", mak_id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    Yorumlar y = new Yorumlar();
                    y.ID = reader.GetInt32(0);
                    y.Makale_ID = reader.GetInt32(1);
                    y.MakaleBaslik = reader.GetString(2);
                    y.Uye_ID = reader.GetInt32(3);
                    y.UyeIsim = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.Tarih = reader.GetDateTime(6);
                    y.TarihStr = y.Tarih.ToShortDateString();
                    y.Durum = reader.GetBoolean(7);
                    yorumlar.Add(y);
                    
                }
                return yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Yorumlar> YorumlariGetir()
        {
            try
            {
                List<Yorumlar> yorumlar = new List<Yorumlar>();
                cmd.CommandText = "SELECT Y.ID, Y.Makale_ID,M.Baslik, Y.Uye_ID, U.KullaniciAdi,Y.Icerik,Y.Tarih,Y.Durum FROM Yorumlar AS Y JOIN Uyeler AS U ON Y.Uye_ID=U.ID JOIN Makaleler AS M ON Y.Makale_ID=M.ID;";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    Yorumlar y = new Yorumlar();
                    y.ID = reader.GetInt32(0);
                    y.Makale_ID = reader.GetInt32(1);
                    y.MakaleBaslik = reader.GetString(2);
                    y.Uye_ID = reader.GetInt32(3);
                    y.UyeIsim = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.Tarih = reader.GetDateTime(6);
                    y.TarihStr = y.Tarih.ToShortDateString();
                    y.Durum = reader.GetBoolean(7);
                    yorumlar.Add(y);
                   
                }
                return yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Yorumlar> OnaysizYorumlar()
        {
            try
            {
                List<Yorumlar> yorumlar = new List<Yorumlar>();
                cmd.CommandText = "SELECT Y.ID, Y.Makale_ID,M.Baslik, Y.Uye_ID, U.KullaniciAdi,Y.Icerik,Y.Tarih,Y.Durum FROM Yorumlar AS Y JOIN Uyeler AS U ON Y.Uye_ID=U.ID JOIN Makaleler AS M ON Y.Makale_ID=M.ID WHERE Y.Durum=0;";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Yorumlar y = new Yorumlar();
                    y.ID = reader.GetInt32(0);
                    y.Makale_ID = reader.GetInt32(1);
                    y.MakaleBaslik = reader.GetString(2);
                    y.Uye_ID = reader.GetInt32(3);
                    y.UyeIsim = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.Tarih = reader.GetDateTime(6);
                    y.TarihStr = y.Tarih.ToShortDateString();
                    y.Durum = reader.GetBoolean(7);
                    yorumlar.Add(y);

                }
                return yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public void YorumDurumDegistir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Durum From Yorumlar WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum = Convert.ToBoolean(cmd.ExecuteScalar());

                cmd.CommandText = "UPDATE Yorumlar SET Durum=@d WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@d", !durum);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
        }
        public int OnaysizYorumSayisi()
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Yorumlar WHERE Durum=0;";
                cmd.Parameters.Clear();
                con.Open();
                int sayi = 1;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sayi = reader.GetInt32(0);

                }
                return sayi;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }
        public bool YorumSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Yorumlar WHERE ID=@id; ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;

            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Moderatör İşlemleri

        public int ModeratorAtama(Yoneticiler mod)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE KullaniciAdi = @kadi OR Email = @email";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kadi", mod.KullaniciAdi);
                cmd.Parameters.AddWithValue("@email", mod.Email);
                con.Open();
                int varMi = (int)cmd.ExecuteScalar();
                con.Close();
                if (varMi > 0)
                {
                    return 3;
                }
                else
                {
                    cmd.CommandText = "INSERT INTO Yoneticiler(YoneticiTur_ID,KullaniciAdi,Email, Sifre,Durum) VALUES(@yonTurid,@kadi,@email,@sifre,@durum)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@yonTurid", 2);
                    cmd.Parameters.AddWithValue("@kadi", mod.KullaniciAdi);
                    cmd.Parameters.AddWithValue("@email", mod.Email);
                    cmd.Parameters.AddWithValue("@sifre", mod.Sifre);
                    cmd.Parameters.AddWithValue("@durum", 1);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    return 2;
                }

            }
            catch
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Yoneticiler> ModlariListele()
        {
            try
            {
                List<Yoneticiler> yonlist = new List<Yoneticiler>();
                cmd.CommandText = "SELECT ID,KullaniciAdi,Email,Durum FROM Yoneticiler WHERE YoneticiTur_ID=2";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Yoneticiler u = new Yoneticiler();
                    u.ID = reader.GetInt32(0);
                    u.KullaniciAdi = reader.GetString(1);
                    u.Email = reader.GetString(2);
                    u.Durum = reader.GetBoolean(3);
                    yonlist.Add(u);
                }
                return yonlist;
            }
            catch
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public void ModDurumDeğiştir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Durum From Yoneticiler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum = Convert.ToBoolean(cmd.ExecuteScalar());

                cmd.CommandText = "UPDATE Yoneticiler SET Durum=@d WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@d", !durum);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
        }
        #endregion
    }
}
