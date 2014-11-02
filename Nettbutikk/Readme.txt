



Begrunnelse av valg vi har gjort
================================


	Admin kan ikke opprette bruker
	------------------------------
	Admin skal naturligvis ikke ha tilgang til brukeres passord. Vi har ingen
	epost-tjener som kan sende ut bekreftelsesmelding til brukeren, derfor er brukere
	på dette tidspunktet nødt til å opprette bruker selv. 


	Opprettelse av underkategorier
	------------------------------
	Det er mulig å opprette underkategorier, men de vil ikke vises i nettbutikken. 
	Dette er fordi underkategoriene på dette tidspunktet er hardkodet inn i drop-downlistene
	på adminsiden.


	Sletting fra databasen
	------------------------------
	Sånn det er nå, så kan man ikke slette en kategori før den er tom, samme gjelder
	subkategori og produsent. Dersom det skulle vært gjeldende praksis for hele
	prosjektet, hadde vi aldri fått slettet noe pga. produkter ligger i ordrelinjer 
	osv. Nå går det an å slette produkter og brukere, det resulterer i at dersom man
	sletter et produkt, så vil alle ordrelinjer som inneholder det produktet også bli
	slettet. Det samme samme gjelder for brukere - dersom man sletter en bruker vil
    alle ordre tilhørende den brukeren forsvinne.


	Bilder av nye produkter
	-----------------------------
	Det går ikke an å gi nye produkter bilde fra administratorvertkøyet på dette 
	tidspunktet. Dette fordi bildene må ha riktige proposjoner for å se bra ut i
	nettbutikken. Bildene vil imidlertid få et "defaultbilde". Hvis man vil kan 
	man på dette tidspunktet  legge inn et bilde manuelt i /img/products/ og kalle
	bildet "[varenummer].png" - og det vil synes i nettbutikken. 
