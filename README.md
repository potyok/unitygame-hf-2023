# Russian Chase

# A játék koncepciója, motivációja
A Russian Chase egy végtelen hosszú útszakan játszódik, ahol egy régi szovjet kocsival kell a többi gépjárművet kikerülve minél messzebbre eljutni, továbbá pluszpontokért érmeket gyűjtögetni. A játékot tovább nehezíti, hogy egyre gyorsul a forgalom, így a játékos járműve is, valamint a játék egy 2×2 sávos útszakaszon játszódik, így néha a szembe jövő sávba is át kell térni, ha a játékos szeretné elkerülni az ütközést. A játék akkor ér véget, ha a játékos járműve teljesen megsemmisül az ütközések miatt, vagy elfogy az üzemanyaga. A játékot a Unity játék motor segítségével tervezem megvalósítani, amelyhez a Unity Asset Store-ban megtalálható 3D-s épület és jármű modelleket tervezek felhasználni. Valamint egy korábban általam Blenderben készített 3D-s Volvo kamion modellt.

# Use-case
## Jármű irányítása
1.	A járművet mozgási irányra merőleges tengely mentén tudja mozgatni a játékos a billentyűzetet használva. 
2.	Amikor a játékos kiválasztja az egyik mozgási irányt, akkor ameddig az gomb formájában lenyomva marad a jármű abba az irányba mozog egy előre meghatározott határig. 
3.	Egy előre meghatározott gomb lenyomásával pedig kürtölő hangot tud kiadni a jármű.

## Játék megszakítása
1.	A játékos egy meghatározott gomb lenyomásával megszakíthatja a játékmenetet, ekkor minden mozgás megáll. 
2.	Amennyiben a játékos tovább szeretné folytatni a játékot egy újabb gombot kell megnyomni és ekkor a megszakítás pillanatától folytathatja tovább a játékot. 
3.	A játék végleges megszakítására csak az ideiglenes megszakítás állapotában van lehetősége.

## Tokenek gyűjtése
1.	A játékos járművel különböző tokeneket tud felvenni az útja során. Mivel a járműve az ütközések során sérülhet, ezért a járműjavító token felvételével egy bizonyos mértékű javítást tud alkalmazni a járművén ezzel is növelve a játékmenet hosszát. 
2.	Továbbá a végleges pontszám növelésének érdekében pontszám növelő tokeneket is felvehet, amelyek csak a pontszámot növelik egy fix értékkel. 
3.	Valamint üzemanyag tokenek segítségével egy fix mennyiséggel megnövelheti a rendelkezésére álló üzemanyag mennyiséget.
4.	A fel nem vett tokeneknek nincs külön hatása a játékmenetre. 
5.	A tokenek generálása teljesen véletlenszerű.

## Pontszám, üzemanyag és életszint követése
1.	A játékos egy játékmenet során folyamatosan követni tudja az adott pillanatig megtett úthosszát, valamint a járműve életszintjét.
2.	Egy üzemanyag mérőn követni tudja a járműve aktuális üzemanyag mennyiségét. 
3.	Amennyiben megsemmisül a járműve, azaz az életszintje eléri a 0-t véget ér a játék. 
4.	Amennyiben elfogy az összes üzemanyag, akkor a játék véget ér.
5.	A játékos egy összefoglaló nézetben láthatja az elért pontszámát és a megtett út hosszát.

# User Story-k
## Zenei hangaláfestés
A legtöbb hasonló típusú játékban a játékmenetet végig kiséri egy háttérzene, amely megtöri a játék monotonságát, ezért ezt itt is használni tervezem.

## Jármű hangok
Mivel kocsis játék, így elvárható, hogy legyenek a járművek különféle motorhangjaik, esetleg képesek legyenek valamilyen kürtszót kiadni magukból. Különös sokat dobna, ha 3D-s hatás keltene a járművek mozgásával.

## Ütközések megjelenítése
Az ütközések egyértelmű jelzésére elengedhetetlen a hangeffekt, amellyel tudatni lehet a játékossal, hogy ütközött. Továbbá a többi jármű eltűntetésekor kellene valamilyen animáció, amely elrejti az egyszerű eltűnést. Talán egy robbanó részecskerendszer megfelelő erre, de mondjuk egy kis füsttel még a játékost is nehezíteni lehetne.

## Tokenek sikeres felvétele
A tokenek felvételekor érdemes valamilyen hangeffekttel jelezni a játékos irányába, hogy ő is tudomást szerezzen az eseményről. Esetleg különböző hangok a különböző tokenekhez, hogy akár hangból is meg tudja különböztetni őket.

## Tokenek animálása
Növelné a látvány színvonalát, ha tokenek nem mereven egy pozícióban, hanem valamilyen pörgő, esetleg fel-le mozgás végeznének, ezzel is felhívva a játékos figyelmét a jelenlétükre.

# Jelenetek
A játék két jelenetből fog állni. Az első egy kezdőképernyő, ahol a játék fogadja a játékost, itt semmi plusz funkció nem lesz azon kívül, hogy innen lehet majd elindítani a játékot. A második jelenet maga a játékmenet, ahol megtalálhatóak az objektumok és a játékos tudja irányítani a járművét. Amikor egy játékmenet véget ér, akkor mindig ez a jelenet fog újra töltődni és ebből jelenetből lehet elhagyni véglegesen is majd a játékot. 

# Technológiák
A játék a Unity játék motor épít teljes mértékben. A 3D-s objektum modelleket egy részről a Unity AssetStore-ról tervezem beszerezni, másrészről Blenderben készített saját modellt is tervezek használni. A terveim szerint az AssetStore-ról még további hangeffektetek, részecskerendszereket és zenéket tervezek beépíteni a játékba, hogy növeljem a játékélményt.

