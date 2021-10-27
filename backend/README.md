Oppgave 

Appex Tournaments!Her skal dere lage en turneringsapp!
Skal fungere noenlunde som https://challonge.com/
Ønsker at dere benytter Nuxt 3 for frontend https://v3.nuxtjs.org/Deloppgaver:
- Avklare roller i prosjektet
	- Prosjektleder (gir en oppdatering til meg på status hver onsdag)
	- Designer
	- Backend-utvikler
	- Frontend-utvikler
- Avklare hvilke skjermbilder som trengs. F.eks:
	- Registrering av navn på turnering + spillere
	- Forhåndsvisning av turneringsløpet (bracket)
	- Skjermbilde hvor man kan registrere utfall av kamper
	- Skjermbilde som viser turnerlingsløpet + neste kamp/spill
	- Flere?
- Sette opp et design på dette i Fimga. Bør følge Appex sin stil og tone. Minimalistisk og pent. Sender PDF med oppdatert profil.
- Finn ut hvordan dere ønsker å lagre data.
- Finn ut hvilken teknologi som skal benyttes for backend.
- Kan man bruke eksisternede open-source kode for å lette på arbeidet her? Google f.eks: Vue bracket component elns.
- Begynne med et enkelt proof-of-consept.
- Tenk ut en god  datamodell for backend (nødvendige objekter og felter). F.eks trenger man en tabell for tournaments - med Id, tittel, dato, osv.
- Kode CRUD logikken for datamodellen, og sette opp sette opp api endepunkter i backend for dette (hente ut og lagre nye data). F.eks trenger man POST /api/tournaments og GET /api/tournaments/id/ etc.
- Lage frontend pages og komponenter som får på plass de nødvendige skjermbildene
- Sende og hente nødvendig data mellom frontend og backend.
- Teste og justere.
- Kalle inn til første test-turnering "Appex Biljard 2022"  :D


appex

Roller:

<p align="center">Frontend: Aleksnadder</p>
<p align="center">Backend: Arvid</p>

Backend:

Har laget en api med express som tar imot tournament informasjon og så stapper det inn i en mongodb database.

