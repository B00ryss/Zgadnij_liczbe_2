class Wynik
{
    // Przechowuje pojedynczy wpis w Hall of Fame.
    public Wynik(string imie, TypPoziomu poziom, bool czyPlus, int proby, int sekundy)
    {
        Imie = imie;
        Poziom = poziom;
        CzyPlus = czyPlus;
        Proby = proby;
        Sekundy = sekundy;
    }

    public string Imie { get; }
    public TypPoziomu Poziom { get; }
    public bool CzyPlus { get; }
    public int Proby { get; }
    public int Sekundy { get; }
}
