using System;
using System.Collections.Generic;
using System.Diagnostics;

class Gra
{
    private Ustawienia ustawienia = new Ustawienia();
    private TabelaWynikow tabelaWynikow = new TabelaWynikow();
    private Random los = new Random();
    private Teksty teksty;

    public Gra()
    {
        teksty = new Teksty(ustawienia);
    }

    // Glowne menu programu. Dziala w petli, dopoki gracz nie wybierze wyjscia.
    public void Uruchom()
    {
        bool programDziala = true;

        while (programDziala)
        {
            Console.Clear();
            PokazNaglowek(teksty.Pobierz("MenuGlowne"));
            Console.WriteLine("1 - " + teksty.Pobierz("NowaGra"));

            if (tabelaWynikow.CzySaWyniki())
            {
                Console.WriteLine("2 - " + teksty.Pobierz("TabelaWynikow"));
            }

            Console.WriteLine("3 - " + teksty.Pobierz("Ustawienia"));
            Console.WriteLine("0 - " + teksty.Pobierz("Wyjscie"));
            Console.Write(teksty.Pobierz("TwojWybor"));

            int wybor = WczytajLiczbe();

            if (wybor == 1)
            {
                RozpocznijNowaGre();
            }
            else if (wybor == 2 && tabelaWynikow.CzySaWyniki())
            {
                PokazTabeleWynikow();
            }
            else if (wybor == 3)
            {
                PokazUstawienia();
            }
            else if (wybor == 0)
            {
                programDziala = false;
            }
            else
            {
                PokazKomunikat(teksty.Pobierz("ZlyWybor"));
            }
        }
    }

    // Przygotowuje nowa gre: wybiera tryb, poziom trudnosci i ewentualnie zaklad.
    private void RozpocznijNowaGre()
    {
        TrybGry trybGry = WybierzTrybGry();
        PoziomTrudnosci poziom = WybierzPoziom();
        bool trybZakladu = false;
        int maksProb = 0;

        if (trybGry.CzyMoznaUzycZakladu() && ustawienia.CzyPytacOZaklad)
        {
            trybZakladu = ZapytajTakNie(teksty.Pobierz("ZapytajOZaklad"));

            if (trybZakladu)
            {
                Console.Write(teksty.Pobierz("MaksymalnaLiczbaProb"));
                maksProb = WczytajLiczbe();
            }
        }

        Graj(trybGry, poziom, trybZakladu, maksProb);
    }

    // Pokazuje menu wyboru trybu gry i zwraca wybrany obiekt trybu.
    private TrybGry WybierzTrybGry()
    {
        while (true)
        {
            Console.Clear();
            PokazNaglowek(teksty.Pobierz("WybierzTrybGry"));
            Console.WriteLine("1 - " + teksty.Pobierz("GraStandardowa"));
            Console.WriteLine("2 - " + teksty.Pobierz("GraPlus"));
            Console.Write(teksty.Pobierz("TwojWybor"));

            int wybor = WczytajLiczbe();

            if (wybor == 1)
            {
                return new TrybStandardowy();
            }

            if (wybor == 2)
            {
                return new TrybPlus();
            }

            PokazKomunikat(teksty.Pobierz("ZlyWybor"));
        }
    }

    // Pokazuje menu poziomow trudnosci i zwraca wybrany poziom z zakresem liczb.
    private PoziomTrudnosci WybierzPoziom()
    {
        while (true)
        {
            Console.Clear();
            PokazNaglowek(teksty.Pobierz("WybierzPoziom"));
            Console.WriteLine("1 - " + teksty.Pobierz("Latwy") + " (0-10)");
            Console.WriteLine("2 - " + teksty.Pobierz("Sredni") + " (1-100)");
            Console.WriteLine("3 - " + teksty.Pobierz("Trudny") + " (1-250)");
            Console.Write(teksty.Pobierz("TwojWybor"));

            int wybor = WczytajLiczbe();

            if (wybor == 1)
            {
                return new PoziomTrudnosci(TypPoziomu.Latwy, 0, 10, 6);
            }

            if (wybor == 2)
            {
                return new PoziomTrudnosci(TypPoziomu.Sredni, 1, 100, 7);
            }

            if (wybor == 3)
            {
                return new PoziomTrudnosci(TypPoziomu.Trudny, 1, 250, 8);
            }

            PokazKomunikat(teksty.Pobierz("ZlyWybor"));
        }
    }

    // Prowadzi sama rozgrywke: losuje liczbe, liczy proby i sprawdza odpowiedzi gracza.
    private void Graj(TrybGry trybGry, PoziomTrudnosci poziom, bool trybZakladu, int maksProb)
    {
        Console.Clear();
        int wylosowanaLiczba = WylosujLiczbe(poziom);
        int proba = 0;
        Stopwatch stoper = Stopwatch.StartNew();

        while (true)
        {
            proba++;

            if (trybGry.CzyPrzelosowacLiczbe(proba, poziom))
            {
                wylosowanaLiczba = WylosujLiczbe(poziom);
                Console.WriteLine(teksty.Pobierz("LiczbaPrzelosowana"));
            }

            Console.WriteLine();
            Console.WriteLine(teksty.Pobierz("Proba") + " #" + proba);
            Console.Write(teksty.Pobierz("PodajLiczbe"));
            int liczbaGracza = WczytajLiczbe();

            if (liczbaGracza == wylosowanaLiczba)
            {
                stoper.Stop();
                bool czyPlus = trybGry is TrybPlus;
                ZakonczWygranaGre(czyPlus, poziom, proba, (int)stoper.Elapsed.TotalSeconds);
                return;
            }

            if (liczbaGracza > wylosowanaLiczba)
            {
                Console.WriteLine(LosowyTekstZaDuzo());
            }
            else
            {
                Console.WriteLine(LosowyTekstZaMalo());
            }

            if (trybZakladu && proba >= maksProb)
            {
                stoper.Stop();
                Console.WriteLine();
                Console.WriteLine(teksty.Pobierz("Przegrana"));
                Console.WriteLine(teksty.Pobierz("PoprawnaLiczba") + ": " + wylosowanaLiczba);
                Pauza();
                return;
            }
        }
    }

    // Obsluguje koniec wygranej gry: pokazuje wynik, pyta o imie i zapisuje Hall of Fame.
    private void ZakonczWygranaGre(bool czyPlus, PoziomTrudnosci poziom, int proby, int sekundy)
    {
        Console.WriteLine();
        Console.WriteLine(teksty.Pobierz("Wygrana"));
        Console.WriteLine(teksty.Pobierz("Proby") + ": " + proby);
        Console.WriteLine(teksty.Pobierz("Czas") + ": " + sekundy + " " + teksty.Pobierz("Sekundy"));
        Console.Write(teksty.Pobierz("PodajImie"));
        string imie = Console.ReadLine() ?? "";

        Wynik wynik = new Wynik(imie, poziom.Typ, czyPlus, proby, sekundy);
        bool czyNajlepszyWynik = tabelaWynikow.DodajWynik(wynik);

        Console.WriteLine();
        Console.WriteLine(teksty.Pobierz("Dzieki") + ", " + imie + "!");

        if (czyNajlepszyWynik)
        {
            Console.WriteLine(teksty.Pobierz("NowyNajlepszyWynik"));
        }

        Pauza();
    }

    // Pokazuje Hall of Fame dla wszystkich poziomow trudnosci.
    private void PokazTabeleWynikow()
    {
        Console.Clear();
        PokazNaglowek(teksty.Pobierz("TabelaWynikow"));
        PokazWynikiPoziomu(TypPoziomu.Latwy);
        PokazWynikiPoziomu(TypPoziomu.Sredni);
        PokazWynikiPoziomu(TypPoziomu.Trudny);
        Pauza();
    }

    // Wypisuje najlepsze wyniki tylko dla jednego poziomu trudnosci.
    private void PokazWynikiPoziomu(TypPoziomu poziom)
    {
        Console.WriteLine();
        Console.WriteLine(PobierzNazwePoziomu(poziom) + ":");
        List<Wynik> wyniki = tabelaWynikow.PobierzNajlepszeWyniki(poziom);

        if (wyniki.Count == 0)
        {
            Console.WriteLine(teksty.Pobierz("BrakWynikow"));
            return;
        }

        for (int i = 0; i < wyniki.Count; i++)
        {
            Wynik wynik = wyniki[i];
            string znakPlus = "";

            if (wynik.CzyPlus)
            {
                znakPlus = "[PLUS] ";
            }

            Console.WriteLine($"{i + 1}. {znakPlus}{wynik.Imie} - {wynik.Proby} - {wynik.Sekundy}s");
        }
    }

    // Pokazuje ekran ustawien: jezyk, czyszczenie wynikow i pytanie o zaklad.
    private void PokazUstawienia()
    {
        bool menuOtwarte = true;

        while (menuOtwarte)
        {
            Console.Clear();
            PokazNaglowek(teksty.Pobierz("Ustawienia"));
            Console.WriteLine(teksty.Pobierz("AktualneUstawienia") + ":");
            Console.WriteLine(teksty.Pobierz("JezykGry") + ": " + PobierzNazweJezyka());
            Console.WriteLine(teksty.Pobierz("UstawieniePytaniaOZaklad") + ": " + PobierzTekstPytaniaOZaklad());
            Console.WriteLine();
            Console.WriteLine("1 - " + teksty.Pobierz("ZmienJezyk"));
            Console.WriteLine("2 - " + teksty.Pobierz("WyczyscTabeleWynikow"));
            Console.WriteLine("3 - " + teksty.Pobierz("PrzelaczZaklad"));
            Console.WriteLine("0 - " + teksty.Pobierz("Powrot"));
            Console.Write(teksty.Pobierz("TwojWybor"));

            int wybor = WczytajLiczbe();

            if (wybor == 1)
            {
                ustawienia.ZmienJezyk();
            }
            else if (wybor == 2)
            {
                WyczyscTabelePoPotwierdzeniu();
            }
            else if (wybor == 3)
            {
                ustawienia.PrzelaczPytanieOZaklad();
            }
            else if (wybor == 0)
            {
                menuOtwarte = false;
            }
            else
            {
                PokazKomunikat(teksty.Pobierz("ZlyWybor"));
            }
        }
    }

    // Czysci Hall of Fame dopiero po potwierdzeniu przez gracza.
    private void WyczyscTabelePoPotwierdzeniu()
    {
        bool potwierdzone = ZapytajTakNie(teksty.Pobierz("PotwierdzCzyszczenie"));

        if (potwierdzone)
        {
            tabelaWynikow.Wyczysc();
            PokazKomunikat(teksty.Pobierz("Wyczyszczono"));
        }
    }

    // Losuje liczbe z zakresu przypisanego do wybranego poziomu trudnosci.
    private int WylosujLiczbe(PoziomTrudnosci poziom)
    {
        return los.Next(poziom.Minimum, poziom.Maksimum + 1);
    }

    // Wczytuje liczbe z klawiatury i powtarza pytanie, jesli wpis nie jest liczba.
    private int WczytajLiczbe()
    {
        while (true)
        {
            string tekst = Console.ReadLine() ?? "";
            bool czyLiczba = int.TryParse(tekst, out int liczba);

            if (czyLiczba)
            {
                return liczba;
            }

            Console.Write(teksty.Pobierz("TwojWybor"));
        }
    }

    // Zadaje pytanie typu tak/nie i zwraca true tylko dla odpowiedzi twierdzacej.
    private bool ZapytajTakNie(string pytanie)
    {
        Console.Write(pytanie);
        string odpowiedz = (Console.ReadLine() ?? "").ToLower();
        return odpowiedz == "t" || odpowiedz == "tak" || odpowiedz == "y" || odpowiedz == "yes";
    }

    // Zwraca losowy komunikat, gdy liczba gracza jest za duza.
    private string LosowyTekstZaDuzo()
    {
        string[] klucze = { "ZaDuzo1", "ZaDuzo2", "ZaDuzo3", "ZaDuzo4", "ZaDuzo5" };
        return teksty.Pobierz(klucze[los.Next(klucze.Length)]);
    }

    // Zwraca losowy komunikat, gdy liczba gracza jest za mala.
    private string LosowyTekstZaMalo()
    {
        string[] klucze = { "ZaMalo1", "ZaMalo2", "ZaMalo3", "ZaMalo4", "ZaMalo5" };
        return teksty.Pobierz(klucze[los.Next(klucze.Length)]);
    }

    // Zamienia typ poziomu na tekst widoczny dla gracza.
    private string PobierzNazwePoziomu(TypPoziomu poziom)
    {
        if (poziom == TypPoziomu.Latwy)
        {
            return teksty.Pobierz("Latwy");
        }

        if (poziom == TypPoziomu.Sredni)
        {
            return teksty.Pobierz("Sredni");
        }

        return teksty.Pobierz("Trudny");
    }

    // Zwraca skrot aktualnego jezyka: PL albo EN.
    private string PobierzNazweJezyka()
    {
        if (ustawienia.JezykGry == Jezyk.Polski)
        {
            return "PL";
        }

        return "EN";
    }

    // Zwraca tekst informujacy, czy pytanie o tryb zakladu jest wlaczone.
    private string PobierzTekstPytaniaOZaklad()
    {
        if (ustawienia.CzyPytacOZaklad)
        {
            return teksty.Pobierz("Wlaczone");
        }

        return teksty.Pobierz("Wylaczone");
    }

    // Wypisuje prosty naglowek ekranu z tytulem gry i nazwa aktualnego menu.
    private void PokazNaglowek(string tytul)
    {
        Console.WriteLine("========================================");
        Console.WriteLine(teksty.Pobierz("Tytul"));
        Console.WriteLine(tytul);
        Console.WriteLine("========================================");
    }

    // Pokazuje komunikat i czeka na ENTER.
    private void PokazKomunikat(string komunikat)
    {
        Console.WriteLine(komunikat);
        Pauza();
    }

    // Zatrzymuje ekran, zeby gracz mogl przeczytac komunikat.
    private void Pauza()
    {
        Console.WriteLine(teksty.Pobierz("NacisnijEnter"));
        Console.ReadLine();
    }
}
