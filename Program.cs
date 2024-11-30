using ConsoleApp_Kutuphane;

int secim;
List<Kitap> kitaps;
Menu _menu = new Menu();
List<string> menuOge = new List<string>();

Kutuphane kutuphane = new Kutuphane();

// Örnek Kitaplar
Kitap kitap1 = new Kitap(b: "1984", y: "George Orwell", t: Kitap.Kitaptur.Roman, s: 400, yy: 1949);
Kitap kitap2 = new Kitap(b: "Hayvan Çiftliği", y: "George Orwell", t: Kitap.Kitaptur.Roman, s: 500, yy: 1945);
Kitap kitap3 = new Kitap(b: "Sefiller", y: "Victor Hugo", t: Kitap.Kitaptur.Roman, s: 300, yy: 1862);
Kitap kitap4 = new Kitap(b: "Sihirli 7", y: "Sahra Doğa Çağdaş", t: Kitap.Kitaptur.Deneme, s: 64, yy: 2024);
Kitap kitap5 = new Kitap(b: "Lavinia - Aşk Şiirleri", y: "Özdemir Asaf", t: Kitap.Kitaptur.Şiir, s: 35, yy: 2015);

List<Kitap> yeniKitaplar = new();
yeniKitaplar = [kitap2, kitap3, kitap4, kitap5];

kutuphane.KitapEkle(kitap1);
kutuphane.KitapEkle(yeniKitaplar);

while (true)
{
    Console.Clear();
    menuOge = ["Kitap listele", "kitap ekle", "kitap ara", "kitap guncelle", "kitap sil", "çıkış"];
    secim = _menu.olustur("Kütüphane 2024", menuOge, [Menu.Renk.Yeşil, Menu.Renk.Kırmızı], 5);

    if (secim == 1)
    {
        _menu.MesajYaz("Tüm Kitapların Listesi", ConsoleColor.Blue);
        int cizgiUzunlugu = 44 + kutuphane.TumKitaplariListele().Count;
        _menu.cizgiCek(sayi: cizgiUzunlugu);
        kutuphane.TumKitaplariListele().ForEach(item => _menu.MesajYaz($"{item.ToString()}", ConsoleColor.Cyan));
        _menu.cizgiCek(sayi: cizgiUzunlugu);
    }
    if (secim == 2) kutuphane.KitapEkle(yeniKitapOlustur());
    if (secim == 3)
    {
        Console.Clear();
        menuOge = ["Başlığa Göre", "Yazara Göre", "Türe Göre", "Yayın Yılına Göre"];
        secim = _menu.olustur("Arama yaparken kullanacağınız işlemi seçin", menuOge, [Menu.Renk.Mavi, Menu.Renk.Kırmızı], 1);

        Console.Write("Kriteri Girin => ");
        string ara = $"{Console.ReadLine()}";

        switch (secim)
        {
            case 1: kutuphane.BasligaGoreAra(ara).ForEach(k => _menu.MesajYaz(k.ToString(), ConsoleColor.DarkRed)); break;
            case 2: kutuphane.YazaraGoreAra(ara).ForEach(k => _menu.MesajYaz(k.ToString(), ConsoleColor.DarkRed)); break;
            case 3:
                Kitap.Kitaptur kitaptur = kitapTuruSec();
                kutuphane.TureGoreAra(kitaptur).ForEach(k => _menu.MesajYaz(k.ToString(), ConsoleColor.DarkRed));
            break;
            case 4: kutuphane.YayinaGoreAra(Convert.ToInt32(ara)).ForEach(k => _menu.MesajYaz(k.ToString(), ConsoleColor.DarkRed)); break;
            default: break;
        }
    }
    if (secim == 4)
    {
        Console.Clear();
        menuOge = ["Kitap Numarasına Göre", "Başlığa Göre"];
        secim = _menu.olustur("Kitap Güncelle", menuOge, [Menu.Renk.Mavi, Menu.Renk.Kırmızı], 1);
        kitaps = kutuphane.TumKitaplariListele();
        int saysil = 0;
        kitaps.ForEach(k => { saysil++; Console.WriteLine($"{saysil}-\t{k}"); });

        switch (secim)
        {
            case 1:
                Console.Write("Kitap numarasını giriniz =>\t".ToUpper());
                int numara = Convert.ToInt32($"{Console.ReadLine()}");
                if (kutuphane.KitapGuncelle(kitaps[numara - 1], yeniKitapOlustur()))
                {
                    _menu.MesajYaz("Güncelleme Başarılı", ConsoleColor.Green);
                }
                else { _menu.MesajYaz("Güncelleme Başarısız", ConsoleColor.Red); }
            break;
            case 2:
                Console.Write("kitap başlığını giriniz =>\t".ToUpper());
                string ara = $"{Console.ReadLine()}";
                if (kutuphane.KitapGuncelle(ara, yeniKitapOlustur()))
                {
                    _menu.MesajYaz("Güncelleme Başarılı", ConsoleColor.Green);
                }
                else { _menu.MesajYaz("Güncelleme Başarısız", ConsoleColor.Red); }
            break;
            default: break;
        }
    }
    if (secim == 5)
    {
        Console.Clear();
        menuOge = ["Kitap Numarasına Göre", "Başlığa Göre"];
        secim = _menu.olustur("Kitap Silme", menuOge, [Menu.Renk.Mavi, Menu.Renk.Kırmızı], 1);
        kitaps = kutuphane.TumKitaplariListele();
        int saysil = 0;
        kitaps.ForEach(k => { saysil++; Console.WriteLine($"{saysil}-\t{k}"); });

        switch (secim)
        {
            case 1:
                Console.Write("Kitap numarasını giriniz =>\t".ToUpper());
                int numara = Convert.ToInt32($"{Console.ReadLine()}");
                if (kutuphane.KitapSil(kitaps[numara - 1]))
                {
                    _menu.MesajYaz("Silme Başarılı", ConsoleColor.Green);
                } else { _menu.MesajYaz("Silme Başarısız", ConsoleColor.Red); }
            break;
            case 2:
                Console.Write("kitap başlığını giriniz =>\t".ToUpper());
                string ara = $"{Console.ReadLine()}";
                if(kutuphane.KitapSil(ara))
                { 
                    _menu.MesajYaz("Silme Başarılı", ConsoleColor.Green); 
                } else { _menu.MesajYaz("Silme Başarısız", ConsoleColor.Red); }
            break;
            default: break;
        }
    }
    if (secim == 6) break;
    Console.Write("Devam etmek için bir tuşa basın");Console.ReadKey();
}

Kitap yeniKitapOlustur()
{
    _menu.MesajYaz("Yeni Kitap Ekle", ConsoleColor.Blue);
    Console.Write("Kitap Adı => ");
    string kitapAdi = $"{Console.ReadLine()}";
    Console.Write("Kitap Yazarı => ");
    string kitapYazar = $"{Console.ReadLine()}";

    Console.Write("Kitap Türü => \n");
    Kitap.Kitaptur kitapTur = kitapTuruSec();

    Console.Write("Kitap Sayfa Sayısı => ");
    int kitapSayfaSayisi = Convert.ToInt32($"{Console.ReadLine()}");
    Console.Write("Kitap Yayın Yılı => ");
    int kitapYayinYili = Convert.ToInt32($"{Console.ReadLine()}");
    return new Kitap(kitapAdi, kitapYazar, kitapTur, kitapSayfaSayisi, kitapYayinYili);
}

Kitap.Kitaptur kitapTuruSec()
{
    int say = 0;
    foreach (var item in Enum.GetNames(typeof(Kitap.Kitaptur)))
    {
        say++; Console.WriteLine($"\t{say}-{item}");
    }
    Console.Write($"Seçiminiz (1 - {Enum.GetNames(typeof(Kitap.Kitaptur)).Length}) => ");
    int secim = Convert.ToInt32(Console.ReadLine());
    return Enum.GetValues<Kitap.Kitaptur>()[secim - 1];
}