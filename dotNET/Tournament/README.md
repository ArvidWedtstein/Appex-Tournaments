API.


### TODO:

Lage flere tester for routene

Finne ut hvorfor APIet nekter å samarbeide (kommer opp med feilmelding på hver request)


# Hvordan bytte database:

1. Hopp inn på mongodb. 
2. Lag bruker. 
3. Opprett cluster. 
4. Opprett database. 
5. Opprett collection kalt "tournaments"
6. Hent connectionstringen til clusteret. 
7. Lim inn connectionstringen i ```appsettings.json``` på _```ConnectionString:```_