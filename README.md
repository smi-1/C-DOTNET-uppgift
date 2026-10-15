# C-DOTNET-uppgift


Hur bygger och kör man programmet?

Programmet körs antingen via en meny eller med kommandoradsargumenten som fanns med i kravspecen
Den byggs med dotnet build, även dotnet run bygger programmet innan det körs. 
Starta programmet med menyn:
dotnet run

I första menyn väljer man vilken källa man vill använda och det finns 3 stycken, JSON-fil, hårdkodad JSON sträng eller från ett API
Därefter får man välja hur man vill ha datan listad (1-4) och det går även att söka på personers namn (5)
När man valt en källa så kan man backa med r till huvudmenyn och välja en källa på nytt, och det går även att avsluta programmet var man än befinner sig i menyn med q.

Kommandoradsargument som finns tillgängliga

dotnet run -- list
dotnet run -- list --top5
dotnet run -- list --sort
dotnet run -- list --sort --top5
dotnet run -- list --search skywalker

list visar alla sorterat på ID
--sort visar alla och sorterar på namn
--top5 sorterar alla på ID och visar 5 första
--top5 --sort sorterar alla på namn och visar 5 första
--search <sträng> visar alla namn som inkluderar strängen sorterat på ID

Källan som används för kommandolinjens data är den hårdkodade sample datan, den går att ändra i början av Main i Program.cs.
PersonService service = new PersonService(new JsonSampleSource());
PersonService service = new PersonService(new JsonDataFileSource("PeopleSample.JSON"));
PersonService service = new PersonService(new API());


Hur har du delat upp programmet mellan olika klasser? Beskriv varför du har valt att göra så.

Jag valde att använda en Person klass som tar in tre andra klasser för olika informationsområden, personinfo, adressinfo och companyinfo.
Sedan använde jag ett interface där data källorna får sin struktur med GetPeople() metoden och en service (PersonService) som innehåller metoderna för att sortera och visa datan, den tar in data källklassen som en dependency injection vilket gör att PersonService kan använda GetPeople() som finns i det man injicerade och på det använder PersonService sorteringsfunktionerna.
Detta gjorde det hyfsat enkelt att ha flera olika källor, med bara en klass som innehåller sorteringsfunktionerna.

Vad är C# respektive .NET? Nämn en skillnad mellan C# och ett annat programmeringsspråk (exempelvis
JavaScript) samt ge exempel på vad man kan utveckla med C#/.NET.
C# är ett modernt statiskt typat och objektorienterat programmeringsspråk som används för att utveckla bland annat webbapplikationer, API:er med ASP.NET Core, spel med Unity och används även med ramverk från .NET så att man kan göra gränssnitt till olika operativsystem, till exempel med .NET MAUI. .NET är en kostnadsfri utvecklingsplattform av Microsoft med öppen källkod, där det finns mycket klar funktionalitet, som till exempel funktionalitet för att deserialisera JSON-data och göra API:er.
JavaScript är ett dynamiskt typat språk och används för att skriva kod för hemsidor, det finns många olika ramverk för det här, som React, Next.js, och även Node.js runtime för att göra backend med JavaScript. Med Blazor kan man göra hemsidor med C#. En stor skillnad är att med C# så måste man oftast skriva ut vilken typ en variabel har eller en metod returnerar och i JavaScript behövs inte det, det är ifall man använder TypeScript som det behövs som med C#.

Förklara kort vad Visual Studio, Git och PowerShell används till vid utveckling med C#/.NET.
Visual Studio är en kodeditor med möjligheten för debugging och addons. 
Git är ett versionshanteringssystem för källkod, det finns möjlighet att ha sin kodeditor kopplad till sitt gitrepo och köra kommandon direkt från den. Personligen kör jag Visual Studio Code med gitrepot kopplat och powershell som min shell.
PowerShell är ett kommandoskal och skriptspråk med funktionalitet för att hantera filer, söka information, använda miljövariabler m.m. Det kan också användas för att starta program, till exempel dotnet run och git push och det går att automatisera det här med PowerShell-skript. Powershell går även att integrera i olika kodeditorer.

Förklara commit och branch.
En commit sparar en ögonblicksbild av ändringar i det lokala repot, man skriver även ett meddelande som beskriver vad man ändrat, sedan kan man använda git push för att skicka ändringarna till ett fjärrepo.
En branch är en separat utvecklingsgren i ett git-repo som kan uppdateras och ändras utan att det ändrar något i de andra branches, det går även att använda merge för att sätta ihop kod från flera olika branches. Används ofta för att utveckla ny funktionalitet som sedan slås ihop med main.


Beskriv kort i README hur man byter datakälla och motivera hur din lösning gör detta möjligt utan att
registerfunktionerna behöver ändras.

Man kan byta datakälla i första menyn med knapparna 1, 2 och 3.
Ifall man vill byta det i kommandolinjeversionen så måste man gå till Program.cs och avkommentera en av linjerna i början av Main.

Det fungerar såhär
PersonService service = new PersonService(new JsonSampleSource());
PersonService service = new PersonService(new JsonDataFileSource("PeopleSample.JSON"));
PersonService service = new PersonService(new API());

Valde att göra Interface och Service med dependency injection på det här viset för att det blev enkelt att byta datakällan och ha metoderna som används på datan i PersonService.
Alla källor implementerar IPersonSource interfacet som har metoden GetPeople().
PersonService tar emot IPersonSource i konstruktorn. 
Sorteringsmetoderna och sökmetoden i PersonService arbetar på listan som GetPeople() returnerar.
Därför vet PersonService inte vilken källa datan kommer ifrån, och metoderna behöver inte ändras när man byter eller lägger till en datakälla.