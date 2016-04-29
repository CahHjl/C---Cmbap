CREATE TABLE Gebruiker (
  Gebr_Id INTEGER NOT NULL PRIMARY KEY Autoincrement,
  Gebr_StatusId INTEGER DEFAULT 1009 NOT NULL,
  Gebr_DispStatus VARCHAR(75) DEFAULT "Demo-gebruiker",
  Gebr_Kort CHAR(6) DEFAULT 'Gebr_kort' NOT NULL,
  Gebr_Lang CHAR(50) DEFAULT 'Gebr_lang' NOT NULL,
  Gebr_Wachtwoord CHAR(10),
  Gebr_Opmerking VARCHAR(250),
  FOREIGN KEY(VWP_STATUSID) REFERENCES STATUS(STATUS_CODE) ON DELETE CASCADE ON UPDATE CASCADE
); 
CREATE UNIQUE INDEX "IdxGebr_Kort" ON Gebruiker (Gebr_Kort ASC); 
CREATE UNIQUE INDEX "IdxGebr_Lang" ON Gebruiker (Gebr_Lang DESC);