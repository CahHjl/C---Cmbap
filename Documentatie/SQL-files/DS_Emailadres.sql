CREATE TABLE Emailadres (
  Emladrs_Id INTEGER NOT NULL PRIMARY KEY Autoincrement,
  Emladrs_StatusId INTEGER DEFAULT 200009,
  Emladrs_DispStatus VARCHAR(75) DEFAULT 'Emladrs-record is leeg / Tabel-initrecord',
  Emladrs_KlBgId INTEGER DEFAULT 1 NOT NULL,
  Emladrs_DispKlBg VARCHAR(75)  DEFAULT 'Klant-Begunstigde',
  Emladrs_Emailadres VARCHAR(70) DEFAULT 'email@email.nl' NOT NULL,
  Emladrs_Opmerking VARCHAR(250),
  FOREIGN KEY(EMLADRS_KLBGID) REFERENCES KLANT_BEGUNSTIGDE(KLBG_ID) ON DELETE CASCADE ON UPDATE CASCADE,
  FOREIGN KEY(EMLADRS_STATUSID) REFERENCES STATUS(STATUS_CODE) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE INDEX "IdxEmladrs_KlBgId" ON Emailadres (Emladrs_KlBgId ASC); 
CREATE INDEX "IdxEmladrs_Emailadres" ON Emailadres (Emladrs_Emailadres ASC);