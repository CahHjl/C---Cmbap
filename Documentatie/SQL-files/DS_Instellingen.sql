CREATE TABLE Instellingen (
  Instl_Id INTEGER NOT NULL PRIMARY KEY Autoincrement,
  Instl_StatusId INTEGER DEFAULT 185009,
  Instl_DispStatus VARCHAR(75) DEFAULT 'Instl-record is leeg / Tabel-initrecord',
  Instl_Naam CHAR(25),
  Instl_Gegtype SMALLINT,
  Instl_Actief INTEGER,
  Instl_String CHAR(400),
  Instl_JN INTEGER,
  Instl_Integer BIGINT,
  Instl_Real REAL,
  Instl_Memo VARCHAR(400),
  Instl_Datum DATE,
  Instl_Tijd TIME,
  Instl_Opmerking VARCHAR(250),
  FOREIGN KEY(INSTL_STATUSID) REFERENCES STATUS(STATUS_CODE) ON DELETE CASCADE ON UPDATE CASCADE
  );
CREATE UNIQUE INDEX "IdxInstl_Naam" ON Instellingen (Instl_Naam ASC)