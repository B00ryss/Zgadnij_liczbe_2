using System.Collections.Generic;

class TabelaWynikow
{
    private List<Wynik> wyniki = new List<Wynik>();

    public bool CzySaWyniki()
    {
        return wyniki.Count > 0;
    }

    // Dodaje nowy wynik i zwraca true, jesli wynik znajduje sie w TOP 5 danego poziomu.
    public bool DodajWynik(Wynik wynik)
    {
        wyniki.Add(wynik);
        List<Wynik> najlepszeWyniki = PobierzNajlepszeWyniki(wynik.Poziom);
        return najlepszeWyniki.Contains(wynik);
    }

    // Pobiera maksymalnie 5 najlepszych wynikow dla wskazanego poziomu trudnosci.
    public List<Wynik> PobierzNajlepszeWyniki(TypPoziomu poziom)
    {
        List<Wynik> wynikPoziomu = new List<Wynik>();

        foreach (Wynik wynik in wyniki)
        {
            if (wynik.Poziom == poziom)
            {
                wynikPoziomu.Add(wynik);
            }
        }

        wynikPoziomu.Sort(PorownajWyniki);

        if (wynikPoziomu.Count > 5)
        {
            wynikPoziomu.RemoveRange(5, wynikPoziomu.Count - 5);
        }

        return wynikPoziomu;
    }

    // Porownuje wyniki: najpierw liczba prob, a przy remisie czas gry.
    private int PorownajWyniki(Wynik pierwszy, Wynik drugi)
    {
        if (pierwszy.Proby != drugi.Proby)
        {
            return pierwszy.Proby.CompareTo(drugi.Proby);
        }

        return pierwszy.Sekundy.CompareTo(drugi.Sekundy);
    }

    // Usuwa wszystkie zapisane wyniki z Hall of Fame.
    public void Wyczysc()
    {
        wyniki.Clear();
    }
}
