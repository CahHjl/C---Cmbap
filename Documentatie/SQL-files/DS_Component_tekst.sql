CREATE TABLE Component_tekst (
  ComponenttekstId INTEGER NOT NULL PRIMARY KEY Autoincrement,
  CT_Taal VARCHAR(5),
  CT_Type VARCHAR (20) NOT NULL,
  CT_Componentnaam VARCHAR(20) NOT NULL,
  CT_Componenttekst VARCHAR(20) NOT NULL 
);
CREATE UNIQUE INDEX "IdxTaalNaam" ON Component_tekst (CT_Taal ASC, CT_Componentnaam ASC);