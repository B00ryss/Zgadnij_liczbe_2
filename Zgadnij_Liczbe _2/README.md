# Zgadnij Liczbe 2

## Uruchomienie

W folderze projektu wpisz:

```bash
dotnet run
```

## Zasady gry

1. Z menu glownego wybierz nowa gre.
2. Wybierz rodzaj gry:
   - gra standardowa,
   - Nowa Gra Plus.
3. Wybierz poziom trudnosci:
   - latwy: 0-10,
   - sredni: 1-100,
   - trudny: 1-250.
4. Wpisuj kolejne liczby, az odgadniesz ukryta liczbe.
5. Po kazdej nieudanej probie gra podpowiada, czy trzeba strzelac wyzej czy nizej.
6. Po wygranej wpisz swoje imie. Wynik trafi do Hall of Fame.

## Tryb zakladu

W grze standardowej program moze zapytac, czy wlaczyc tryb zakladu.
W tym trybie gracz podaje maksymalna liczbe prob. Jesli nie odgadnie liczby w tym limicie, przegrywa.

Tryb zakladu nie jest dostepny w Nowej Grze Plus.

## Nowa Gra Plus

W Nowej Grze Plus ukryta liczba jest losowana ponownie co okreslona liczbe prob:

- latwy: co 6 prob,
- sredni: co 7 prob,
- trudny: co 8 prob.

## Hall of Fame

Hall of Fame pokazuje najlepsze 5 wynikow dla kazdego poziomu trudnosci.
Wyniki sa sortowane wedlug liczby prob. Jesli gracze maja taka sama liczbe prob, wyzej jest wynik z krotszym czasem gry.

## Ustawienia

W ustawieniach mozna:

- zmienic jezyk gry: PL / EN,
- wyczyscic Hall of Fame po potwierdzeniu,
- wlaczyc albo wylaczyc pytanie o tryb zakladu.

Aktualne ustawienia sa widoczne na ekranie ustawien.
