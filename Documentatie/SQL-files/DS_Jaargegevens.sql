CREATE TABLE Jaargegevens (
  Jgeg_Id INTEGER NOT NULL PRIMARY KEY Autoincrement,
  Jgeg_StatusId INTEGER DEFAULT 180009,
  Jgeg_DispStatus VARCHAR(75) DEFAULT 'Jgeg-record is leeg / Tabel-initrecord',
  Jgeg_Omschrijving VARCHAR(15) DEFAULT '1900' NOT NULL,
  Jgeg_Begindatum DATETIME DEFAULT '01-01-1900' NOT NULL,
  Jgeg_Beginsaldo CURRENCY,
  Jgeg_Einddatum DATETIME DEFAULT '31-12-1900' NOT NULL,
  Jgeg_Eindsaldo CURRENCY,
  Jgeg_Opmerking VARCHAR(250),
  FOREIGN KEY(JGEG_STATUSID) REFERENCES STATUS(STATUS_CODE) ON DELETE CASCADE ON UPDATE CASCADE
);  
CREATE UNIQUE INDEX "IdxJgeg_Omschrijving" ON Jaargegevens (Jgeg_Omschrijving ASC);
CREATE INDEX "IdxJgeg_Begindatum" ON Jaargegevens (Jgeg_Begindatum ASC);