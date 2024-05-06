/****** Script for SelectTopNRows command from SSMS  ******/
CREATE DATABASE Ukiyo_db
GO
USE Ukiyo_db
GO
CREATE TABLE YoneticiTurleri
(
	ID int IDENTITY(1,1),
	Isim nvarchar(50),
	CONSTRAINT pk_yoneticiTur PRIMARY KEY(ID)
)
GO
INSERT INTO YoneticiTurleri(Isim) VALUES('Admin')
INSERT INTO YoneticiTurleri(Isim) VALUES('Moderatör')
GO
CREATE TABLE Yoneticiler
(
	ID int IDENTITY(1,1),
	YoneticiTur_ID int,
	KullaniciAdi nvarchar(20),
	Email nvarchar(170),
	Sifre nvarchar(20),
	Durum bit,
	CONSTRAINT pk_Yonetici PRIMARY KEY(ID),
	CONSTRAINT fk_YoneticiYoneticiTur FOREIGN KEY(YoneticiTur_ID) REFERENCES YoneticiTurleri(ID)
)
GO
INSERT INTO Yoneticiler
(YoneticiTur_ID,KullaniciAdi,Email,Sifre,Durum)
VALUES(1, 'vahit', 'vahit@gmail.com', '1234', 1)
GO
CREATE TABLE Kategoriler
(
	ID int IDENTITY(1,1),
	Isim nvarchar(50) NOT NULL,
	Aciklama nvarchar(500),
	Durum bit,
	CONSTRAINT pk_Kategori PRIMARY KEY(ID)
)
GO
CREATE TABLE Makaleler
(
	ID int IDENTITY(1,1),
	Kategori_ID int,
	Yukleyen_ID int,
	Baslik nvarchar(150),
	Ozet nvarchar(500),
	Icerik ntext,
	KapakResim nvarchar(50),
	Tarih datetime,
	GoruntulemeSayi int,
	Durum bit,
	CONSTRAINT pk_makale PRIMARY KEY(ID),
	CONSTRAINT fk_makaleKategori FOREIGN KEY(Kategori_ID) REFERENCES Kategoriler(ID),
	CONSTRAINT fk_makaleYazar FOREIGN KEY(Yukleyen_ID) REFERENCES Yoneticiler(ID)
)
GO
CREATE TABLE Uyeler
(
	ID int IDENTITY(1,1),
	KullaniciAdi nvarchar(20),
	Email nvarchar(170),
	Sifre nvarchar(20),
	UyelikTarihi datetime,
	Durum bit,
	CONSTRAINT pk_uye PRIMARY KEY(ID)
)
GO
CREATE TABLE Yorumlar
(
	ID int IDENTITY(1,1),
	Makale_ID int,
	Uye_ID int,
	Icerik nvarchar(500),
	Tarih datetime,
	Durum bit,
	UyeAdi nvarchar(20),
	CONSTRAINT pk_Yorum PRIMARY KEY(ID),
)
GO
CREATE TABLE Mangalar
(
	ID int IDENTITY(1,1),
	Kategori_ID int,
	Yukleyen_ID int,
	Baslik nvarchar(150),
	Ozet nvarchar(500),
	Icerik ntext,
	KapakResim nvarchar(50),
	Tarih datetime,
	GoruntulemeSayi int,
	Durum bit,
	CONSTRAINT pk_manga PRIMARY KEY(ID),
	CONSTRAINT fk_mangaKategori FOREIGN KEY(Kategori_ID) REFERENCES Kategoriler(ID),
	CONSTRAINT fk_mangayukleyen FOREIGN KEY(Yukleyen_ID) REFERENCES Yoneticiler(ID)
)