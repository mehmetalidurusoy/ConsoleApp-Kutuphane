namespace ConsoleApp_Kutuphane
{
    internal class Menu
    {
        public enum Renk
        {
            Kırmızı, Mavi, Yeşil, Beyaz, Siyah
        }

        private string baslik = "";

        public int olustur(string _baslik, List<string> ogeler, List<Renk> renkler, int bosluk)
        {
            baslik = _baslik;
            int _secim;
            string _bosluk = "";
            for (int i = 0; i < bosluk; i++) { _bosluk += "\t"; }

            MesajYaz($"{_bosluk} {_baslik.ToUpper()}", ConsoleColor.Cyan);

            cizgiCek(_bosluk);

            while (true)
            {
                var secim = menuOlustur(ogeler, renkler, _bosluk);
                _secim = 0;
                bool hata = true;
                if (Int32.TryParse(secim, out _secim))
                {
                    if (_secim > 0 && _secim < ogeler.Count + 1) { hata = false; }
                }
                if (hata)
                {
                    Console.WriteLine($"{_bosluk}hatalı seçim".ToUpper());
                    Console.WriteLine($"{_bosluk}Devam etmek için bir tuşa basın...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else { break; }
            }
            cizgiCek(_bosluk);
            return _secim;
        }

        public void cizgiCek(string _bosluk = "", string _cizgi = "=", string _baslik = "", int sayi = 0)
        {
            string cizgi = "";
            int _sayi = sayi > 0 ? sayi : 0;
            for (int i = 0; i < (_baslik != string.Empty ? _baslik : baslik).Length + _sayi + 6; i++) { cizgi += "="; }
            MesajYaz($"{(_bosluk != string.Empty ? _bosluk + " " : "") + cizgi}", ConsoleColor.Magenta);
        }

        private string menuOlustur(List<string> ogeler, List<Renk> renkler, string _bosluk)
        {
            List<ConsoleColor> _renkler = new();
            renkler.ForEach(r =>
            {
                switch (r)
                {
                    case Renk.Mavi: _renkler.Add(ConsoleColor.Blue); break;
                    case Renk.Yeşil: _renkler.Add(ConsoleColor.Green); break;
                    case Renk.Beyaz: _renkler.Add(ConsoleColor.White); break;
                    case Renk.Siyah: _renkler.Add(ConsoleColor.Black); break;
                    case Renk.Kırmızı: _renkler.Add(ConsoleColor.Red); break;
                }
            });

            int sayac = 0;
            ogeler.ForEach(x => {
                sayac++;
                MesajYaz($"{_bosluk} {sayac}", ConsoleColor.Red, false);
                MesajYaz($" - ", ConsoleColor.Blue, false);
                MesajYaz($"{x.ToUpper()}", ConsoleColor.Yellow);
            });
            cizgiCek(_bosluk);
            Console.Write($"{_bosluk} Seçiniz => ");
            return Console.ReadLine();
        }

        public void MesajYaz(string v, ConsoleColor renk, bool satir = true)
        {
            ConsoleColor anaRenk = Console.ForegroundColor;
            Console.ForegroundColor = renk;
            if (satir) { Console.WriteLine(v); } else { Console.Write(v); }
            Console.ForegroundColor = anaRenk;
        }
    }
}
