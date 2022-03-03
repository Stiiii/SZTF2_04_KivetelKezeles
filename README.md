# Órai feladat – Kivételkezelés

## Bevezetés

Készítsünk egy űrhajó-szimulátort kivételkezelés segítségével! A program törzse az űrhajó (vagy
annak leszármazottjai), amelyhez számos komponens és mechanizmus kapcsolódik. A program
kivételek segítségével jelzi, ha valamely művelet végrehajtása nem lehetséges, vagy nem sikerült.

```
Mivel a leadott feladatokat lehetséges, hogy automatizált módon fogjuk ellenőrizni, ezért kérünk mindenkit,
hogy a lenti (ékezetek nélküli) elnevezéseket tartsa meg. Szükség esetén további mezőket fel lehet venni, bár
ezekre általában nincs szükség.
Ugyanígy kérünk mindenkit, hogy próbálja meg önállóan megoldani a feladatot, mivel csak így fog bármit
tanulni belőle. Szükség esetén persze a laborvezetőket nyugodtan meg lehet keresni, akik segíteni fognak.
```
## Feladatok

## Alap adatszerkezetek

Készíts egy **UrhajoKategoria** nevű **felsorolás típust (enum)** az alábbi elemekkel:

```
 Yacht – kicsi, gyors személyszállító
 Korvett – kis méretű harcászati célú űrhajó
 Fregatt – közepes méretű harcászati célú űrhajó
 Rombolo – nagy méretű harcászati célú űrhajó
 Teher – nagy méretű teherszállító űrhajó
 Allomas – korlátozott mobilitású, hatalmas űrhajó
```
Készíts egy I **Komponens** nevű **interfészt** az alábbi tartalommal:

```
 Teljesitmeny – egész szám, a komponens aktuális teljesítménye [MW], írható és olvasható
tulajdonság, amennyiben negatív, a komponens energiát termel
 Allapot – logikai, a komponens állapotát jelzi, írható és olvasható tulajdonság
 Aktival() – a komponens aktiválására szolgáló visszatérési érték nélküli metódus
 Deaktival() – a komponens deaktiválására szolgáló visszatérési érték nélküli metódus
```
Készíts egy **Urhajo** nevű **osztályt** az alábbi tartalommal:

```
 nev – karakterlánc, az űrhajó neve, legyen csak olvasható tulajdonsága
 uresTomeg – egész szám, az űrhajó aktuális tömege [kg], legyen csak olvasható tulajdonsága
 aktualisTeljesitmeny – egész szám, az űrhajó aktuális teljesítménye [MW], legyen csak
olvasható tulajdonsága
 kategoria – UrhajoKategoria típusú adattag, az űrhajó kategóriáját ábrázolja, legyen csak
olvasható tulajdonsága
 komponensek – IKomponens típusú tömb, mérete a hajó kategóriájától függ (lásd lentebb)
 konstruktor : paraméterként kapja meg és tárolja el a nev, uresTomeg és kategoria kezdeti
értékét, a komponensek tömb méretét pedig az alábbi táblázat alapján állítsa elő:
```
```
Kategória Érték
Yacht 2
Korvett 4
Fregatt 6
Rombolo 8
Teher 8
```

```
Kategória Érték
Allomas 20
 KomponensFelszerel(IKomponens) : a paraméterként megkapott komponenst felszereli az
űrhajóra, vagyis a komponensek tömb első üres helyén eltárolja
 KomponensLeszerel(int) : a paraméterként megadott indexen szereplő komponenst leszereli
az űrhajóról, vagyis a komponensek tömb adott indexű helyén lévő értéket null - ra állítja
```
## Komponens megvalósítások

Készítsd el az alábbi **_IKomponens_** **interfészt megvalósító** osztályokat:

**Hajtomu** osztály:

```
 toloero – egész szám típusú adattag, a hajtómű tolóereje [MW ekvivalens]
 konstruktor , amely paraméterként megkapja és eltárolja a toloero adattag értékét.
 implementálja az Aktival metódust oly módon, hogy meghívásakor a Teljesitmeny
tulajdonság értékét a toloero adattag értékével tegye egyenlővé, az Allapot tulajdonság
pedig igaz értékű legyen
 implementálja a Deaktival metódust oly módon, hogy a meghívásakor a Teljesitmeny
tulajdonság értékét nullára állítsa, az Allapot tulajdonság pedig hamis értékű legyen
```
**Reaktor** osztály:

```
 teljesitmeny – egész szám típusú adattag, a reaktor teljesítménye [MW]
 konstruktor , amely paraméterként megkapja és eltárolja a teljesitmeny adattag értékét.
 implementálja az Aktival metódust oly módon, hogy a meghívásakor a Teljesitmeny
tulajdonság értékét a teljesitmeny adattag ellentettjével tegye egyenlővé, az Allapot
tulajdonság pedig igaz értékű legyen
 implementálja a Deaktival metódust oly módon, hogy a meghívásakor a Teljesitmeny
tulajdonság értékét nullára állítsa, az Allapot tulajdonság pedig hamis értékű legyen
```
Teszteld le az eddig elkészült programrészeket!

## Saját kivételek készítése

Készítsd el az alábbi kivételosztályokat a **System.Exception** osztályból származtatva:

**KomponensNemTalalhatoKivetel**

```
 konstruktor , amely nem vár paramétert
 konstruktor , amely paraméterként egy hibaüzenetet vár és meghívja az ősosztály
konstruktorát a kapott paraméterrel
```
**NemDeaktivalhatoKivetel**

```
 konstruktor , amely paraméterként egy hibaüzenetet és egy kivételt vár és meghívja az
ősosztály konstruktorát a kapott paraméterekkel
```
**KomponensNemFerElKivetel**

```
 komponens – IKomponens típusú adattag, legyen csak olvasható tulajdonsága
 konstruktor , amely paraméterként egy hibaüzenetet és egy IKomponens típusú
objektumot vár, amit eltárol és meghívja az ősosztály konstruktorát a kapott üzenet
paraméterrel
```

**NincsElegEnergiaKivetel**

```
 hianyMerteke – egész szám, a hiányzó teljesítmény [MW] mértékét tárolja, legyen csak
olvasható tulajdonsága
 konstruktor , ami bekéri a hiányzó teljesítmény mennyiségét és a hianyMerteke
adattagban eltárolja azt, majd meghívja az ősosztálya egyparaméteres konstruktorát az
alábbi formátumú üzenettel: „Nincs elég teljesítmény, { hianyMerteke } MW hiányzik”
```
## Kivételek eldobása

Módosítsd úgy az **Urhajo** osztály **konstruktorát** , hogy

```
 amennyiben az uresTomeg paraméter értéke kisebb vagy egyenlő nullával, dobjon
ArgumentOutOfRangeException típusú kivételt, amelyben megnevezi a kivételt kiváltó
paramétert ( uresTomeg ), és szöveges üzenetben is leírja a hibát
 amennyiben a nev paraméter értéke null , úgy dobjon ArgumentNullException típusú
kivételt, amelyben megnevezi a kivételt kiváltó paramétert ( nev )
```
Módosítsd úgy az **Urhajo** osztály **KomponensFelszerel** metódusát, hogy dobjon
_KomponensNemFerElKivetel_ típusú hibát, ha nincs üres hely a _komponensek_ tömbben.

Módosítsd úgy az **Urhajo** osztály **KomponensLeszerel** metódusát, hogy dobjon
_KomponensNemTalalhatoKivetel_ típusú hibát, ha nem található komponens a megadott
tömbindexen.

Módosítsd úgy a **Reaktor** osztály **Aktival** metódusát, hogy amennyiben a reaktor már aktiválva van,
dobjon _InvalidOperationException_ típusú kivételt.

Módosítsd úgy a **Reaktor** osztály **Aktival** metódusát, hogy amennyiben a reaktor teljesítménye 0
MW, úgy dobjon _NotSupportedException_ típusú kivételt.

Módosítsd úgy a **Reaktor** osztály **Deaktival** metódusát, hogy amennyiben a reaktor még nincs
aktiválva, dobjon _InvalidOperationException_ típusú kivételt.

Teszteld le az eddig elkészült programrészeket!

## Kivételek kezelése

Egészítsd ki az **Urhajo** osztályt az alábbiak szerint:

```
 Padlogaz() visszatérési érték nélküli metódus, amely megpróbálja aktiválni az összes hajtómű
típusú komponenst:
o Minden még nem aktivált hajtóműnek meghívja az Aktival metódusát, majd a hajtómű
teljesítményét kivonja az űrhajó aktualisTeljesitmeny adattagjának értékéből
o Amennyiben a művelet közben negatív tartományba kerülne az űrhajó teljesítménye, úgy
dobjon NincsElegEnergiaKivetel típusú kivételt és állítsa le az összes hajtóművet (ne
felejtsd az aktualisTeljesitmeny adattag értékét is visszaállítani!)
 Beindit() visszatérési érték nélküli metódus, amely megpróbálja aktiválni az összes reaktor
típusú komponenst és sikeres indítás esetén megnöveli az aktualisTeljesitmeny értékét a
reaktor teljesítményével
o Amennyiben valamelyik reaktor InvalidOperationException típusú kivételt dob, írja ki a
konzolra a kivétel tényét, de folytassa a többi reaktor indítását.
o Amennyiben valamelyik reaktor NotSupportedException típusú kivételt dob, úgy az adott
reaktort szerelje le az űrhajóról
```

```
 Leallit () visszatérési érték nélküli metódus, amely megpróbálja deaktiválni az összes
komponenst, és amennyiben valamelyik a leállítás során kivételt dob, úgy tovább dobja egy
NemDeaktivalhatoKivetel típusú kivételbe csomagolva és végül (a sikerességtől függetlenül)
kiírja ki a konzolra a meghívás tényét
```
Teszteld le az egész programot az alábbiak szerint:

```
 Hozz létre néhány űrhajó példányt, majd szerelj fel rájuk komponenseket
 Teszteld le az űrhajók
o Padlogaz,
o Beindit és
o Leallit
metódusait
 A tesztelés során minden kivételt kapj el, és az üzenetüket írd ki a konzolra!
```
Egy példa kimenet:

```
Star Destroyer #5530 letrehozva!
Serenity letrehozva!
Old Bessie letrehozva!
Razorback letrehozva!
[KIVETEL] Az üres tömeg nem lehet negatív!
Parameter name: uresTomeg
[KIVETEL] Value cannot be null.
Parameter name: nev
[Hozzaadas] Hajtomu hozzaadva a(z) Serenity hajohoz
[Hozzaadas] Hajtomu hozzaadva a(z) Serenity hajohoz
[Hozzaadas] Hajtomu hozzaadva a(z) Old Bessie hajohoz
[Hozzaadas] Hajtomu hozzaadva a(z) Razorback hajohoz
[Hozzaadas] Reaktor hozzaadva a(z) Razorback hajohoz
[Hozzaadas] Hajtomu hozzaadva a(z) Star Destroyer #5530 hajohoz
[Hozzaadas] Hajtomu hozzaadva a(z) Star Destroyer #5530 hajohoz
[Hozzaadas] Hajtomu hozzaadva a(z) Star Destroyer #5530 hajohoz
[Hozzaadas] Hajtomu hozzaadva a(z) Star Destroyer #5530 hajohoz
[Hozzaadas] Hajtomu hozzaadva a(z) Star Destroyer #5530 hajohoz
[Hozzaadas] Hajtomu hozzaadva a(z) Star Destroyer #5530 hajohoz
[Hozzaadas] Hajtomu hozzaadva a(z) Star Destroyer #5530 hajohoz
[Hozzaadas] Reaktor hozzaadva a(z) Star Destroyer #5530 hajohoz
[KIVETEL] A komponens nem fér el!
[Leszereles] A(z) 0 indexu komponens leszerelve a(z) Star Destroyer #
hajorol
[KIVETEL] A törölni kívánt komponens nem található!
[KIVETEL] Nincs elég teljesítmény, 1280 MW hiányzik
[Beinditas] A(z) Star Destroyer #5530 urhajo beinditva
[HIBA] Egy reaktor már fut!
[Beinditas] A(z) Star Destroyer #5530 urhajo beinditva
[Padlogaz] A(z) Star Destroyer #5530 urhajo padlogazon megy
[Leallitas] A(z) Star Destroyer #5530 urhajo leallitasa meghivva
[Leallitas] A(z) Razorback urhajo leallitasa meghivva
[KIVETEL] Egy komponens nem deaktiválható!
[BELSO KIVETEL]: Operation is not valid due to the current state of the
object. (ex.InnerException)
```

