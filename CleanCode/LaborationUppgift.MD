Introduktion
 Laborationen utförs individuellt eller i par, dessa par måste bestämmas innan ni påbörjar uppgiften genom att
 skriva till mig på Teams (skicka meddelandet i en grupp där ni båda är med).
 Inlämning sker via ZIP l på ITHSdistans. Zip-len ska innehålla programkoden och en PDF med er skriftliga
 redovisning. Ni ska även använda Git (och Github) medan ni arbetar och ni får gärna komplettera med en länk
 till ert Githubprojekt.
 Laborationen ska vara inlämnad senast den: 2025-09-05 kl 23:59.

För Godkänt (G) i laborationen ska er inlämning innehålla:
 Er kod i form av ett C#-projekt + tester (minst ca 5 tester bör nnas, men desto mer desto bättre)
 En skriftlig redovisning där ni beskriver de refaktoriseringar och andra förbättringar som har utförts.
 Ca en A4-sida text (standard marginaler, textstorlek 11/12…) ska skrivas.
 Ni ska ha med referenser till kurslitteratur och gärna externa webbsidor med relevant information.

 Utöver denna sida får ni gärna komplettera med gurer, tabeller eller kodexempel och se till att ni har väl
 utplacerade rubriker (dessa gurer etc. räknas inte in till er totala mängd).

Programmet
 Koden som skall refaktoriseras och testas är medvetet fullt av code smells men fungerar vid normal
 användning. Det implementerar spelet ”Moo” som är ett Mastermind-liknande spel där programmet slumpar
 fram en fyrsiffrig sträng som spelaren skall gissa, med så få gissningar som möjligt. Den slumpade strängen har
 garanterat fyra unika siffror.

 Spelaren gissar med fyra siffror. Som svar visar spelet ett antal B:n och C:n (bulls and cows).
 Ett B för varje siffra som har satts på rätt plats
 Ett C för varje siffra som nns med bland de fyra men är på fel plats

 Exempel:
 B, betyder att en av fyra siffror i gissningen är rätt och är på rätt plats

 ,CCC betyder att tre gissade siffror nns med, men ingen är på rätt plats

 BBBB, är målet och då är omgången slut.

 Spela några gånger med en ”fuskutskrift” av talet så är det lätt att lära sig reglerna.

 Spelaren får göra gissningar med icke-unika siffror om hen vill, men målet har alltid fyra unika.

 Efter varje spel skrivs alla spelares genomsnittliga antal gissningar ut i en topplista, ordnad efter bästa gissningsgenomsnitt.

 Spelet lagrar statistik över utförda spel i en l, från vilken topplistan beräknas och skrivs ut efter varje spel.

Er uppgift
 Uppgiften är att refaktorisera programmet genom att identi era code smells och minimera/eliminera dem
 samt att göra koddelarna testbara för unit-testing och skriva tester som testar programlogiken.

Refaktorisering
 Programmet skall göras ”vackrare” genom utförande av refaktorisering på lämpliga delar.
 Kursbokens idéer om:
 namngivning
 funktioner/metoder
 kommentarer
 klasser
 felhantering
 clean tests
 …skall beaktas och genomföras. Om något designmönster är lämpligt att använda, gör så.

 Programmets olika skikt som sköter:

 Användargränssnitt

 Programlogik

 Statistikinsamling/redovisning

 …skall separeras och delarna skall inte känna till annat om de andra delarna än ett interface
 och skall använda Dependency Injection för sammansättning av delarna.

 Konkret objektskapande och sammansättning av delarna kan skötas med manuell kod i main metoden/klassen.


Testning
 Tester skall skrivas för programlogikkoden. Eftersom den anropar IO och användargränssnittkod,
 behöver dessa kanske Mock-Object-implementeras för att kunna utföra testerna.

 Kanske behöver också metoden som genererar slumpsiffrorna mockas,
 så att tester på programlogiken kan utföras med kända ”slump”-siffror.

Arbetets omfattning
 En uppgift av detta slag har naturligtvis inget enda ”rätt svar”.

 Koden skall efter utförd refaktorisering sakna tydliga code smells.

 Koden skall vara uppdelad i helt skilda skikt för användargränssnitt, spel och IO/integration.

 Spelet bör troligtvis uppdelas i spel-controller och spellogik, så att logiken kan testas separat.

 Testerna skall testa väsentliga delar av programlogiken, men behöver inte vara alltäckande. Det viktigaste
 är att visa att tester går att genomföra och att några representativa tester finns på plats.

 De viktiga steg som utförts skall dokumenteras på ca en A4-sida.

 Detaljer framgår tydligt (eller hur?) av koden så beskrivningen behöver bara vara mer av en översikt.

 Om du hittar svagheter, buggar, utelämnad felhantering eller säkerhet, etc. får du gärna påpeka eller rätta,
 men det ingår inte i laborationen att göra det. (Programmet är säkert inte alls perfekt i dessa avseenden.)

 Samma sak gäller för l-IO-koden, det ingår inte i uppgiften att använda någon annan teknik, men själva
 koden kan och skall göras vackrare.

 Programmet skall vid normal och korrekt användning fungera precis som tidigare.
 Det är dock OK att onormala operationer och feltillstånd ändras.

Frågor
 Det är helt OK att ställa frågor om arbetets omfattning och krav,
 om något i denna beskrivning skulle vara oklart, eller om koden är obegriplig.
 Det är också helt OK att diskutera och få handledning av arbetet under kurstid!

Uppgift för VG
 För att få betyg VG skall allt ovanstående vara utfört plus en extrauppgift:

 Strukturera/utöka programmet så att man kan välja att spela andra liknande spel.

 Exempelvis MasterMind, där de fyra siffrorna bara kan ha sex olika värden (sex färger i originalet) och
 dessutom kan förekomma er än en gång i slumpgruppen. För varje spel krävs en ny resultattabell i databasen,
 men spelartabellen kan delas mellan spelen.

 Implementera minst en extra spelvariant och beskriv vad som behöver göras för att lägga till ytterligare spel.
 Tester för det nya spelet behöver inte implementeras (men bör). Eftersom det handlar om ett utbytbart
 varierande del-beteende luktar det Strategymönstret, men uppgiften kan kanske lösas snyggt även på annat
 sätt.

 Resultatet är ett program där man med minimala ändringar kan lägga till kod för nya spel av ”Moo-karaktär”.

 Du kan också välja att utöka programmet genom att lägga till ett annat typ av spel som går att komma åt
 i en meny där du väljer vilket spel du vill spela.

 Detta spel ska i så fall även det skapas med väl valda design patterns och följa clean-code standarder som ska
 beskrivas skriftligt.

För Väl Godkänt (VG) i laborationen ska er inlämning innehålla:
 Er utbyggda kod i form av ett C#-projekt + relevanta tester även för VG-delarna
 Utöver den skriftliga redovisningen för G, även en extra A4 sida som beskriver hur er-spels-dynamiken
 åstadkommits eller som beskriver designvalen du har gjort i ditt egna spel. Du bör även här tydligt visa på
 hur du refaktoriserat och fått G och VG delarna att passa bra med varandra och hanterat potentiella nya
 code-smells.

 För att uppnå VG kommer ni i och med extrauppgiften få en chans att visa att ni kan:
 Skapa underhållsvänlig kod för att åstadkomma en hög maintainability
 Skapa kod av hög kvalité med hög test coverage