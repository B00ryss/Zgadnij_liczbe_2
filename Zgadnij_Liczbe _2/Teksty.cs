class Teksty
{
    private Ustawienia ustawienia;

    public Teksty(Ustawienia ustawienia)
    {
        this.ustawienia = ustawienia;
    }

    // Zwraca tekst w aktualnym jezyku gry.
    public string Pobierz(string klucz)
    {
        if (ustawienia.JezykGry == Jezyk.Angielski)
        {
            return PobierzAngielski(klucz);
        }

        return PobierzPolski(klucz);
    }

    // Zwraca polska wersje tekstu dla podanego klucza.
    private string PobierzPolski(string klucz)
    {
        return klucz switch
        {
            "Tytul" => "GRA: ZGADNIJ LICZBE 2",
            "MenuGlowne" => "MENU GLOWNE",
            "NowaGra" => "Nowa gra",
            "TabelaWynikow" => "Hall of Fame",
            "Ustawienia" => "Ustawienia",
            "Wyjscie" => "Wyjscie",
            "TwojWybor" => "Twoj wybor: ",
            "ZlyWybor" => "Nie ma takiej opcji.",
            "NacisnijEnter" => "Nacisnij ENTER, aby kontynuowac.",
            "WybierzTrybGry" => "Wybierz rodzaj gry",
            "GraStandardowa" => "Gra standardowa",
            "GraPlus" => "Nowa gra plus",
            "WybierzPoziom" => "Wybierz poziom trudnosci",
            "Latwy" => "Latwy",
            "Sredni" => "Sredni",
            "Trudny" => "Trudny",
            "ZapytajOZaklad" => "Czy chcesz wlaczyc tryb zakladu? (t/n): ",
            "MaksymalnaLiczbaProb" => "Podaj maksymalna liczbe prob: ",
            "Proba" => "PROBA",
            "PodajLiczbe" => "Podaj liczbe: ",
            "ZaDuzo1" => "Za wysoko! Sprobuj nizej!",
            "ZaDuzo2" => "Oj, za wysoko. W dol!",
            "ZaDuzo3" => "Nie tym razem, liczba jest nizsza!",
            "ZaDuzo4" => "Strzelaj nizej!",
            "ZaDuzo5" => "Troszke za duzo!",
            "ZaMalo1" => "Za nisko! Celuj wyzej!",
            "ZaMalo2" => "Oj, za nisko. W gore!",
            "ZaMalo3" => "Nie tym razem, liczba jest wyzsza!",
            "ZaMalo4" => "Strzelaj wyzej!",
            "ZaMalo5" => "Troszke za malo!",
            "Wygrana" => "Brawo! Zgadles!",
            "Przegrana" => "Przegrales. Skonczyly Ci sie proby.",
            "PoprawnaLiczba" => "Prawidlowa liczba to",
            "Proby" => "Liczba prob",
            "Czas" => "Czas gry",
            "Sekundy" => "sekund",
            "PodajImie" => "Podaj swoje imie: ",
            "Dzieki" => "Dzieki za gre",
            "NowyNajlepszyWynik" => "Twoj wynik trafil do Hall of Fame!",
            "LiczbaPrzelosowana" => "Ukryta liczba zostala przelosowana.",
            "BrakWynikow" => "Brak zapisanych wynikow.",
            "Powrot" => "Powrot",
            "AktualneUstawienia" => "Aktualne ustawienia",
            "JezykGry" => "Jezyk",
            "UstawieniePytaniaOZaklad" => "Pytanie o tryb zakladu",
            "Wlaczone" => "wlaczone",
            "Wylaczone" => "wylaczone",
            "ZmienJezyk" => "Zmien jezyk PL/EN",
            "WyczyscTabeleWynikow" => "Wyczysc Hall of Fame",
            "PrzelaczZaklad" => "Przelacz pytanie o zaklad",
            "PotwierdzCzyszczenie" => "Czy na pewno wyczyscic Hall of Fame? (t/n): ",
            "Wyczyszczono" => "Hall of Fame zostalo wyczyszczone.",
            _ => klucz
        };
    }

    // Zwraca angielska wersje tekstu dla podanego klucza.
    private string PobierzAngielski(string klucz)
    {
        return klucz switch
        {
            "Tytul" => "GAME: GUESS THE NUMBER 2",
            "MenuGlowne" => "MAIN MENU",
            "NowaGra" => "New game",
            "TabelaWynikow" => "Hall of Fame",
            "Ustawienia" => "Settings",
            "Wyjscie" => "Exit",
            "TwojWybor" => "Your choice: ",
            "ZlyWybor" => "There is no such option.",
            "NacisnijEnter" => "Press ENTER to continue.",
            "WybierzTrybGry" => "Choose game type",
            "GraStandardowa" => "Standard game",
            "GraPlus" => "New game plus",
            "WybierzPoziom" => "Choose difficulty",
            "Latwy" => "Easy",
            "Sredni" => "Medium",
            "Trudny" => "Hard",
            "ZapytajOZaklad" => "Do you want to use bet mode? (y/n): ",
            "MaksymalnaLiczbaProb" => "Enter maximum number of attempts: ",
            "Proba" => "ATTEMPT",
            "PodajLiczbe" => "Enter number: ",
            "ZaDuzo1" => "Too high! Try lower!",
            "ZaDuzo2" => "A bit too high. Go down!",
            "ZaDuzo3" => "Not this time, the number is lower!",
            "ZaDuzo4" => "Shoot lower!",
            "ZaDuzo5" => "A little too much!",
            "ZaMalo1" => "Too low! Aim higher!",
            "ZaMalo2" => "A bit too low. Go up!",
            "ZaMalo3" => "Not this time, the number is higher!",
            "ZaMalo4" => "Shoot higher!",
            "ZaMalo5" => "A little too low!",
            "Wygrana" => "Great! You guessed it!",
            "Przegrana" => "You lost. You ran out of attempts.",
            "PoprawnaLiczba" => "Correct number is",
            "Proby" => "Attempts",
            "Czas" => "Game time",
            "Sekundy" => "seconds",
            "PodajImie" => "Enter your name: ",
            "Dzieki" => "Thanks for playing",
            "NowyNajlepszyWynik" => "Your score is now in Hall of Fame!",
            "LiczbaPrzelosowana" => "The hidden number has been changed.",
            "BrakWynikow" => "No saved scores.",
            "Powrot" => "Back",
            "AktualneUstawienia" => "Current settings",
            "JezykGry" => "Language",
            "UstawieniePytaniaOZaklad" => "Bet mode question",
            "Wlaczone" => "on",
            "Wylaczone" => "off",
            "ZmienJezyk" => "Change language PL/EN",
            "WyczyscTabeleWynikow" => "Clear Hall of Fame",
            "PrzelaczZaklad" => "Toggle bet question",
            "PotwierdzCzyszczenie" => "Are you sure you want to clear Hall of Fame? (y/n): ",
            "Wyczyszczono" => "Hall of Fame has been cleared.",
            _ => klucz
        };
    }
}
