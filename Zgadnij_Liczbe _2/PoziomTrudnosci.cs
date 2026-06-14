class PoziomTrudnosci
{
    // Przechowuje ustawienia poziomu: typ, zakres losowania i czestotliwosc przelosowania.
    public PoziomTrudnosci(TypPoziomu typ, int minimum, int maksimum, int przelosujCoIleProb)
    {
        Typ = typ;
        Minimum = minimum;
        Maksimum = maksimum;
        PrzelosujCoIleProb = przelosujCoIleProb;
    }

    public TypPoziomu Typ { get; }
    public int Minimum { get; }
    public int Maksimum { get; }
    public int PrzelosujCoIleProb { get; }
}
