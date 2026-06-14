class TrybPlus : TrybGry
{
    // W Nowej Grze Plus liczba zmienia sie co kilka prob zaleznie od poziomu.
    public override bool CzyPrzelosowacLiczbe(int proba, PoziomTrudnosci poziom)
    {
        return proba > 1 && (proba - 1) % poziom.PrzelosujCoIleProb == 0;
    }
}
