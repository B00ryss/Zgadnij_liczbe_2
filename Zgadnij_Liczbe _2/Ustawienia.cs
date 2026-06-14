class Ustawienia
{
    private Jezyk jezyk = Jezyk.Polski;
    private bool pytajOZaklad = true;

    public Jezyk JezykGry
    {
        get { return jezyk; }
    }

    public bool CzyPytacOZaklad
    {
        get { return pytajOZaklad; }
    }

    // Przelacza jezyk gry z polskiego na angielski albo odwrotnie.
    public void ZmienJezyk()
    {
        if (jezyk == Jezyk.Polski)
        {
            jezyk = Jezyk.Angielski;
        }
        else
        {
            jezyk = Jezyk.Polski;
        }
    }

    // Wlacza albo wylacza pytanie o tryb zakladu przed gra standardowa.
    public void PrzelaczPytanieOZaklad()
    {
        pytajOZaklad = !pytajOZaklad;
    }
}
