abstract class TrybGry
{
    // Domyslnie tryb gry nie pozwala na zaklad.
    public virtual bool CzyMoznaUzycZakladu()
    {
        return false;
    }

    // Domyslnie tryb gry nie przelosowuje liczby w trakcie rozgrywki.
    public virtual bool CzyPrzelosowacLiczbe(int proba, PoziomTrudnosci poziom)
    {
        return false;
    }
}
