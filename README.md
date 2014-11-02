<h1>Webapplikasjoner, Høgskolen i Oslo og Akershus</h1>

Vi er en gruppe på fire personer som har jobbet sammen i kurset Web Applikasjoner høsten 2014. Dette er vårt resultat. Under finner du oppgaveteksten for de to innleveringene.

<h2>1. Innlevering</h2>

<h3>Oppgave</h3>
Det skal implementeres en nettbutikk for kjøp av varer på nettet. 
<h3>Grupper</h3>
Oppgaven skal løses i grupper med maks 5 studenter i hver gruppe. 
<h3>Mål</h3>
<ul>
<li>Lage en komplett løsning med mulighet for å bestille på nett.</li>
<li>Løsningen skal lages i .NET MVC.</li>
<li>Sikre enkelte sider med innloggingsfunksjon, håndtere nye/gamle brukere.</li>
<li>Vise forståelse for MVC arkitekturen og Entity Framework.</li>
</ul>
<h3>Funksjonalitet:</h3>

<h4>Løsningen bør blant annet inneholde:</h4>
<ul>
<li>Applikasjonen skal kreve autentisering og autorisering enten via egendefinert sikkerhetsløsning.</li>
<li>Brukere skal kunne være anonym for å se på varene, men være registrert som kunde for å kjøpe.</li>
<li>På slutten av bestillingen bør man ha en mulighet for å betale for bestillingen (ikke fysisk knytning til en betalingsløsning).</li>
<li>En kvittering bør vises for kunden som bekreftelse på bestillingen.</li>
<li>Den enkelte bruker skal kunne logge seg inn og endre på sine egne data i tillegg til å se på ordrehistorikken sin (hva og når de har bestilt før).</li>
<li>Ha dynamisk henting/oppdatering av data via AJAX og Javascript (JQuery).</li>
</ul>
<h4>Ved evaluering av oppgaven vil det bla. bli vektlagt:</h4>
<ul>
<li>Design / layout</li>
<li>Funksjonalitet</li>
<li>Struktur på kode</li>
<li>Databasestruktur bruk av Entity Framework code forst</li>
<li>Validering</li>
<li>Ryddig og forståelig kode (CSHTML og c#)</li>
</ul>
<h3>Hva skal leveres: </h3>
En zip. fil som inneholder hele Visual Studio prosjektet i Fronter. Dersom det er noe spesielt ved løsningen som studentene vil fremheve kan dette gjøres via en kort tekstlig beskrives i løsningen f.eks kalt Readme.txt.
Det skal ikke leveres en komplett administrasjonsløsning for kunder, produkter, kategorier og ordre. Dette er en del av neste oppgave. Den eneste «backend» funksjonalitet som skal lages er at den enkelte bruker kan se på og endre sine egne data i tillegg til å se på sin egen ordrehistorikk.


<h2>2. Innlevering</h2>

<h3>Mål</h3>
Lage er administrasjonsgrensesnitt for prosjektoppgave 1 implementert i MVC.
<ul>
<li>Lagdele applikasjonen i MVC, Model, BLL og DAL</li>
<li>Generere automatiske enhetstester</li>
<li>Bruke versjonskontroll (TFS/Git)</li>
</ul>
<h3>Funksjonalitet:</h3>
<h4>Løsningen bør blant annet inneholde:</h4>
<ul>
<li>Administrasjon av kunder, ordre, varer og andre entiteter.</li>
<li>Innloggingsmekanisme for admin-brukere.</li>
<li>Logging av endringer til database.</li>
<li>Logging av feilsituasjoner til fil. Det betyr bla. de som kan oppstå når databasen aksesseres.</li>
</ul>
<h4>Ved evaluering av oppgaven vil det bla. bli vektlagt:</h4>
<ul>
<li>Design / layout tilsvarende løsningen i tidligere prosjektoppgaver.</li>
<li>Funksjonalitet.</li>
<li>Ryddig og forståelig kode.</li>
<li>Lagdeling.</li>
<li>Kompletthet av enhetstest for denne løsningen (ikke nødvendig å lage det for tidligere deler).</li>
<li>Bruk av versjonskontroll.</li>
</ul>
<h4>Hva skal leveres:</h4>
En zip. fil som inneholder hele MVC-løsningen. Løsningen bør også integreres i den allerede eksiterende løsning fra oppgave 1. Det er ikke nødvendig å endre løsningen fra oppgave 1 på noen måte (det kreves altså ikke at denne lagdeles). Det kan også leveres en kort tekstlig beskrivelse av løsningen dersom det gir en bedre forståelse av denne som en fil i løsningen kalt Readme.txt. Denne skal leveres i samme zip.fil. Husk å oppgi URL for den kjørende versjonen.
