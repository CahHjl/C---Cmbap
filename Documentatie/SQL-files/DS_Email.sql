CREATE TABLE Email (
  Em_Id INTEGER NOT NULL PRIMARY KEY Autoincrement,
  Em_StatusId INTEGER DEFAULT 115009,
  Em_DispStatus VARCHAR(75) DEFAULT "E-mailgegevens zijn leeg / Tabel-initrecord",
  Em_Afzender VARCHAR(100) DEFAULT 'Afzender@email.nl' NOT NULL,
  Em_EmailAdresId INTEGER DEFAULT 1 NOT NULL,
  Em_Onderwerp VARCHAR(150) DEFAULT 'Onderwerp' NOT NULL,
  Em_Bericht BLOB,
  Em_BestellingId INTEGER DEFAULT 1,
  Em_Opmerking VARCHAR(250),
  FOREIGN KEY(EM_BESTELLINGID) REFERENCES BESTELLING(BSTL_ID) ON DELETE CASCADE ON UPDATE CASCADE,
  FOREIGN KEY(EM_STATUSID) REFERENCES STATUS(STATUS_CODE) ON DELETE CASCADE ON UPDATE CASCADE
  FOREIGN KEY(EM_EMAILADRESID) REFERENCES EMAILADRES(EMLADRS_ID) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE INDEX "IdxEm_Afzender" ON Email (Em_Afzender ASC);