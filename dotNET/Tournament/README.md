API.


### TODO:

Lage flere tester for routene

Finne ut hvorfor APIet nekte å samarbeida (kommer opp med feilmelding på hver request. Detta problemet oppsto ette at me flytta logikken ut av controlleren siden David sa me ikkje sko ha all logikken i controlleren. )


# Hvordan bytte database:

1. Hopp inn på mongodb. 
2. Lag bruker. 
3. Opprett cluster. 
4. Opprett database. 
5. Opprett collection kalt "tournaments"
6. Hent connectionstringen til clusteret. 
7. Lim inn connectionstringen i ```appsettings.json``` på _```ConnectionString:```_