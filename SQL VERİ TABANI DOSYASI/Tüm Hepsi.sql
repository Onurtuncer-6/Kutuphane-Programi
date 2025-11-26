create database Kütüphane_Programý

go

use Kütüphane_Programý
create table BookUse(
KitapAdi nvarchar(max),
KitapAlanýnAdý nvarchar(max),
KitapAlanýnSýnýfý nvarchar(max),
KitapAlanýnNumarasý nvarchar(max),
KitabýnAlýnmaTarihi date,
KitabýnGeriVerileceðiTarih date,
KitapBarkod nvarchar(max)
)
go
go

use Kütüphane_Programý
create table BookType(
ID int IDENTITY(1,1),
Typ_e nvarchar(max)
)

insert into BookType(Typ_e) values ('Edebiyat')
insert into BookType(Typ_e) values ('Çocuk ve Gençlik')
insert into BookType(Typ_e) values ('Eðitim ve Sýnav Kitaplarý')
insert into BookType(Typ_e) values ('Foreign Languages')
insert into BookType(Typ_e) values ('Baþvuru')
insert into BookType(Typ_e) values ('Araþtýrma - Tarih')
insert into BookType(Typ_e) values ('Din Tasavvuf')
insert into BookType(Typ_e) values ('Çocuk ve Gençlik')
insert into BookType(Typ_e) values ('Sanat - Tasarým')
insert into BookType(Typ_e) values ('Felsefe')
insert into BookType(Typ_e) values ('Hobi')
insert into BookType(Typ_e) values ('Çizgi Roman')
insert into BookType(Typ_e) values ('Bilim')
insert into BookType(Typ_e) values ('Mizah')
insert into BookType(Typ_e) values ('Prestij Kitaplarý')
go
go

use Kütüphane_Programý
create table [Edebiyat](
ID int IDENTITY(1,1),
Subjec_t nvarchar(max)
)

create table [Çocuk ve Gençlik](
ID int IDENTITY(1,1),
Subjec_t nvarchar(max)
)

create table [Eðitim ve Sýnav Kitaplarý](
ID int IDENTITY(1,1),
Subjec_t nvarchar(max)
)

create table [Foreign Languages](
ID int IDENTITY(1,1),
Subjec_t nvarchar(max)
)

create table [Baþvuru](
ID int IDENTITY(1,1),
Subjec_t nvarchar(max)
)

create table [Araþtýrma - Tarih](
ID int IDENTITY(1,1),
Subjec_t nvarchar(max)
)

create table [Din Tasavvuf](
ID int IDENTITY(1,1),
Subjec_t nvarchar(max)
)

create table [Sanat - Tasarým](
ID int IDENTITY(1,1),
Subjec_t nvarchar(max)
)

create table [Felsefe](
ID int IDENTITY(1,1),
Subjec_t nvarchar(max)
)

create table [Hobi](
ID int IDENTITY(1,1),
Subjec_t nvarchar(max)
)

create table [Çizgi Roman](
ID int IDENTITY(1,1),
Subjec_t nvarchar(max)
)

create table [Bilim](
ID int IDENTITY(1,1),
Subjec_t nvarchar(max)
)

create table [Mizah](
ID int IDENTITY(1,1),
Subjec_t nvarchar(max)
)

create table [Prestij Kitaplarý](
ID int IDENTITY(1,1),
Subjec_t nvarchar(max)
)

insert into [Edebiyat](Subjec_t) values ('Roman')
insert into [Edebiyat](Subjec_t) values ('Þiir')
insert into [Edebiyat](Subjec_t) values ('Deneme Yazýn')
insert into [Edebiyat](Subjec_t) values ('Edebiyat Ýnceleme')
insert into [Edebiyat](Subjec_t) values ('Biyografi & Otobiyografi')
insert into [Edebiyat](Subjec_t) values ('Türk Günlük Aný')
insert into [Edebiyat](Subjec_t) values ('Türk Öykü')
insert into [Edebiyat](Subjec_t) values ('Anlatý')
insert into [Edebiyat](Subjec_t) values ('Söyleþi')
insert into [Edebiyat](Subjec_t) values ('Dünya Öykü')
insert into [Edebiyat](Subjec_t) values ('Dünya Günlük Aný')
insert into [Edebiyat](Subjec_t) values ('Türk Mektup')
insert into [Edebiyat](Subjec_t) values ('Dünya Mektup')
insert into [Edebiyat](Subjec_t) values ('Edebiyatçýlar')
insert into [Edebiyat](Subjec_t) values ('Destan')
insert into [Edebiyat](Subjec_t) values ('Röportaj')
insert into [Edebiyat](Subjec_t) values ('Antoloji')
insert into [Edebiyat](Subjec_t) values ('Fotograflarla Anýlar (Prestij)')
insert into [Edebiyat](Subjec_t) values ('Halk Ozanlarý')

insert into [Çocuk ve Gençlik](Subjec_t) values ('Okul Öncesi 6 Ay-5 Yaþ')
insert into [Çocuk ve Gençlik](Subjec_t) values ('Okul Çaðý 6-10 Yaþ')
insert into [Çocuk ve Gençlik](Subjec_t) values ('Gençlik 10+ Yaþ')
insert into [Çocuk ve Gençlik](Subjec_t) values ('Ýslami Çocuk Kitaplarý')

insert into [Eðitim ve Sýnav Kitaplarý](Subjec_t) values ('Akademik Kitaplar')
insert into [Eðitim ve Sýnav Kitaplarý](Subjec_t) values ('Üniversiteye Hazýrlýk')
insert into [Eðitim ve Sýnav Kitaplarý](Subjec_t) values ('Ortaokul Ders Kitaplarý')
insert into [Eðitim ve Sýnav Kitaplarý](Subjec_t) values ('Sözlük, Atlas, Ýmla Kýlavuzu')
insert into [Eðitim ve Sýnav Kitaplarý](Subjec_t) values ('Bilgisayar Kitaplarý')
insert into [Eðitim ve Sýnav Kitaplarý](Subjec_t) values ('Lise Ders Kitaplarý')
insert into [Eðitim ve Sýnav Kitaplarý](Subjec_t) values ('KPSS')
insert into [Eðitim ve Sýnav Kitaplarý](Subjec_t) values ('Liselere Geçiþ Sýnavý')
insert into [Eðitim ve Sýnav Kitaplarý](Subjec_t) values ('Dil Öðrenim Kitaplarý')
insert into [Eðitim ve Sýnav Kitaplarý](Subjec_t) values ('Ýlköðretim Ders Kitaplarý')
insert into [Eðitim ve Sýnav Kitaplarý](Subjec_t) values ('Diðer Sýnavlara Hazýrlýk')

insert into [Foreign Languages](Subjec_t) values ('Literature and Novel')
insert into [Foreign Languages](Subjec_t) values ('Children and Teen')
insert into [Foreign Languages](Subjec_t) values ('Other Languages')
insert into [Foreign Languages](Subjec_t) values ('Reference')
insert into [Foreign Languages](Subjec_t) values ('Language')
insert into [Foreign Languages](Subjec_t) values ('Graphic Novel')
insert into [Foreign Languages](Subjec_t) values ('History')
insert into [Foreign Languages](Subjec_t) values ('Hobby')
insert into [Foreign Languages](Subjec_t) values ('Personal Development')
insert into [Foreign Languages](Subjec_t) values ('Food and Beverage')
insert into [Foreign Languages](Subjec_t) values ('Travel Guides and Maps')
insert into [Foreign Languages](Subjec_t) values ('Humour Books')

insert into [Baþvuru](Subjec_t) values ('Kiþisel Geliþim')
insert into [Baþvuru](Subjec_t) values ('Eðitim')
insert into [Baþvuru](Subjec_t) values ('Ýþ Ekonomi - Hukuk')
insert into [Baþvuru](Subjec_t) values ('Psikoloji Bilimi')
insert into [Baþvuru](Subjec_t) values ('Aile Çocuk')
insert into [Baþvuru](Subjec_t) values ('Saðlýk')
insert into [Baþvuru](Subjec_t) values ('Gezi')
insert into [Baþvuru](Subjec_t) values ('Dilbilimi/Etimoloji')
insert into [Baþvuru](Subjec_t) values ('Bilgisayar')
insert into [Baþvuru](Subjec_t) values ('Sözlük')

insert into [Araþtýrma - Tarih](Subjec_t) values ('Tarih')
insert into [Araþtýrma - Tarih](Subjec_t) values ('Politika/Araþtýrma')
insert into [Araþtýrma - Tarih](Subjec_t) values ('Sosyoloji')
insert into [Araþtýrma - Tarih](Subjec_t) values ('Mitoloji Efsane')
insert into [Araþtýrma - Tarih](Subjec_t) values ('Etnoloji')
insert into [Araþtýrma - Tarih](Subjec_t) values ('Kadýn')
insert into [Araþtýrma - Tarih](Subjec_t) values ('Ýstanbul Kitaplarý')
insert into [Araþtýrma - Tarih](Subjec_t) values ('Tarihi Kiþiler')
insert into [Araþtýrma - Tarih](Subjec_t) values ('Ermeni Meselesi')
insert into [Araþtýrma - Tarih](Subjec_t) values ('Organize Suç')

insert into [Din Tasavvuf](Subjec_t) values ('Ýslamiyet')
insert into [Din Tasavvuf](Subjec_t) values ('Tasavvuf')
insert into [Din Tasavvuf](Subjec_t) values ('Dinler Tarihi')
insert into [Din Tasavvuf](Subjec_t) values ('Diðer Ýnançlar')
insert into [Din Tasavvuf](Subjec_t) values ('Hristiyanlýk')
insert into [Din Tasavvuf](Subjec_t) values ('Musevilik')
insert into [Din Tasavvuf](Subjec_t) values ('Budizm')
insert into [Din Tasavvuf](Subjec_t) values ('Din Adamlarý')

insert into [Araþtýrma - Tarih](Subjec_t) values ('Tarih')
insert into [Araþtýrma - Tarih](Subjec_t) values ('Politika/Araþtýrma')
insert into [Araþtýrma - Tarih](Subjec_t) values ('Sosyoloji')
insert into [Araþtýrma - Tarih](Subjec_t) values ('Mitoloji Efsane')
insert into [Araþtýrma - Tarih](Subjec_t) values ('Etnoloji')
insert into [Araþtýrma - Tarih](Subjec_t) values ('Kadýn')
insert into [Araþtýrma - Tarih](Subjec_t) values ('Ýstanbul Kitaplarý')
insert into [Araþtýrma - Tarih](Subjec_t) values ('Tarihi Kiþiler')
insert into [Araþtýrma - Tarih](Subjec_t) values ('Ermeni Meselesi')
insert into [Araþtýrma - Tarih](Subjec_t) values ('Organize Suç')

insert into [Din Tasavvuf](Subjec_t) values ('Ýslamiyet')
insert into [Din Tasavvuf](Subjec_t) values ('Tasavvuf')
insert into [Din Tasavvuf](Subjec_t) values ('Dinler Tarihi')
insert into [Din Tasavvuf](Subjec_t) values ('Diðer Ýnançlar')
insert into [Din Tasavvuf](Subjec_t) values ('Hristiyanlýk')
insert into [Din Tasavvuf](Subjec_t) values ('Musevilik')
insert into [Din Tasavvuf](Subjec_t) values ('Budizm')
insert into [Din Tasavvuf](Subjec_t) values ('Din Adamlarý')

insert into [Sanat - Tasarým](Subjec_t) values ('Tiyatro')
insert into [Sanat - Tasarým](Subjec_t) values ('Sanat Tarihi ve Kuramý')
insert into [Sanat - Tasarým](Subjec_t) values ('Müzik')
insert into [Sanat - Tasarým](Subjec_t) values ('Sinema')
insert into [Sanat - Tasarým](Subjec_t) values ('Mimari')
insert into [Sanat - Tasarým](Subjec_t) values ('Fotoðraf - Grafik Sanatý')
insert into [Sanat - Tasarým](Subjec_t) values ('Sanatçýlar')
insert into [Sanat - Tasarým](Subjec_t) values ('Resim-Plastik Sanatlar')
insert into [Sanat - Tasarým](Subjec_t) values ('Diðer Sanatlar')
insert into [Sanat - Tasarým](Subjec_t) values ('Senaryo')
insert into [Sanat - Tasarým](Subjec_t) values ('Türk Osmanlý Sanatý')

insert into [Felsefe](Subjec_t) values ('Felsefe Bilimi')
insert into [Felsefe](Subjec_t) values ('Bilgelik')
insert into [Felsefe](Subjec_t) values ('Felsefeciler')
insert into [Felsefe](Subjec_t) values ('Felsefi Romanlar')
insert into [Felsefe](Subjec_t) values ('Felsefi Süreli Yayýnlar')

insert into [Hobi](Subjec_t) values ('Yemek ve Tatlý')
insert into [Hobi](Subjec_t) values ('Spor ve Sporcular')
insert into [Hobi](Subjec_t) values ('Parapsikoloji')
insert into [Hobi](Subjec_t) values ('Genel Ýlgi')
insert into [Hobi](Subjec_t) values ('Astroloji-Fal')
insert into [Hobi](Subjec_t) values ('Bulmaca')
insert into [Hobi](Subjec_t) values ('El Sanatlarý')
insert into [Hobi](Subjec_t) values ('Kehanet')
insert into [Hobi](Subjec_t) values ('Oyun Kitaplarý/Oyun')
insert into [Hobi](Subjec_t) values ('Hayvan Bakýmý')
insert into [Hobi](Subjec_t) values ('Resim Tekniði')
insert into [Hobi](Subjec_t) values ('Rüya Tabirleri')
insert into [Hobi](Subjec_t) values ('Moda')
insert into [Hobi](Subjec_t) values ('Fotoðraf')
insert into [Hobi](Subjec_t) values ('Eðlenceli Kitaplar/Hediyelik Kitaplar')
insert into [Hobi](Subjec_t) values ('Bahçe Bakýmý/Çiçek Sanatý')
insert into [Hobi](Subjec_t) values ('Avcýlýk')
insert into [Hobi](Subjec_t) values ('Kurgu')
insert into [Hobi](Subjec_t) values ('Elektrik-Elektronik')

insert into [Çizgi Roman](Subjec_t) values ('Manga')

insert into [Bilim](Subjec_t) values ('Popüler Bilim')
insert into [Bilim](Subjec_t) values ('Ekoloji/Çevre Bilim')
insert into [Bilim](Subjec_t) values ('Bilim Tarihi ve Felsefesi')
insert into [Bilim](Subjec_t) values ('Arkeoloji')
insert into [Bilim](Subjec_t) values ('Antropoloji')
insert into [Bilim](Subjec_t) values ('Matematik')
insert into [Bilim](Subjec_t) values ('Coðrafya')
insert into [Bilim](Subjec_t) values ('Tübitak Kitaplarý')
insert into [Bilim](Subjec_t) values ('Mühendislik')
insert into [Bilim](Subjec_t) values ('Botanik')
insert into [Bilim](Subjec_t) values ('Fizik')
insert into [Bilim](Subjec_t) values ('Jeoloji')
insert into [Bilim](Subjec_t) values ('Astronomi')
insert into [Bilim](Subjec_t) values ('Biyoloji')
insert into [Bilim](Subjec_t) values ('Kimya')
insert into [Bilim](Subjec_t) values ('Zooloji')
insert into [Bilim](Subjec_t) values ('Anatomi')
insert into [Bilim](Subjec_t) values ('Kaþifler')

insert into [Mizah](Subjec_t) values ('Mizah Romaný - Öykü')
insert into [Mizah](Subjec_t) values ('Karikatür')
insert into [Mizah](Subjec_t) values ('Fýkra')

insert into [Prestij Kitaplarý](Subjec_t) values ('Sanat Prestij')
insert into [Prestij Kitaplarý](Subjec_t) values ('Tarih Prestij')
insert into [Prestij Kitaplarý](Subjec_t) values ('Diðer Prestij')
insert into [Prestij Kitaplarý](Subjec_t) values ('Fotograf Prestij')
insert into [Prestij Kitaplarý](Subjec_t) values ('Ýstanbul Prestij')
insert into [Prestij Kitaplarý](Subjec_t) values ('Türk Prestij')
insert into [Prestij Kitaplarý](Subjec_t) values ('Müzeler')
insert into [Prestij Kitaplarý](Subjec_t) values ('Ýslam Prestij')
insert into [Prestij Kitaplarý](Subjec_t) values ('Atatürk Prestij')
insert into [Prestij Kitaplarý](Subjec_t) values ('Doða Prestij')
insert into [Prestij Kitaplarý](Subjec_t) values ('Ülkeler- Kentler Prestij')
insert into [Prestij Kitaplarý](Subjec_t) values ('Foreign Language Prestij')
go
go
use Kütüphane_Programý
create table Book(
ID int IDENTITY(1,1),
KitapAdi nvarchar(max),
KitapResim image,
KitapYazarý nvarchar(max),
KitapAçýklamasý text,
KitapTürü nvarchar(max),
KitapKonusu nvarchar(max),
KitapBarkod nvarchar(max),
KitapEklenmeTarihi date,
KitapSayfaSayýsý nvarchar(max),
KaçKitapVar nvarchar(max),
KaçKitapKullanýmda nvarchar(max),
)
go
go
use Kütüphane_Programý
create table Manager(
ID int IDENTITY(1,1),
Username nvarchar(max),
Passwords nvarchar(max)
)

insert into Manager (Username,Passwords) values ('admin','admin')
go