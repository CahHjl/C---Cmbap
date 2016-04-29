CREATE TABLE 'Log' (
  Log_Id INTEGER NOT NULL PRIMARY KEY Autoincrement,
  Log_StatusId INTEGER DEFAULT 130009,
  Log_DispStatus VARCHAR(75) DEFAULT 'Log-regel is leeg / Tabel-inirecord',
  Log_Datum DATETIME DEFAULT '01-01-1900 00:00:00' NOT NULL,
  Log_Bestand CHAR(25) DEFAULT 'Bestandsnaam' NOT NULL,
  Log_Bestandsnr INTEGER DEFAULT 1 NOT NULL,
  Log_RecordId BIGINT DEFAULT 1 NOT NULL,
  Log_Veldnaam CHAR(25) DEFAULT 'Veldnaam' NOT NULL,
  Log_Volgnr INTEGER DEFAULT 1 NOT NULL,
  Log_Oude_tekst CHAR(250),
  Log_Nieuwe_tekst CHAR(250),
  Log_Oude_numeriek INTEGER,
  Log_Nieuwe_numeriek INTEGER,
  Log_Oude_real DECIMAL,
  Log_Nieuwe_real DECIMAL,
  Log_Oude_currency CURRENCY,
  Log_Nieuwe_currency CURRENCY,
  Log_Oude_datum DATETIME,
  Log_Nieuwe_datum DATETIME,
  Log_Oude_JN INTEGER,
  Log_Nieuwe_JN INTEGER,
  Log_Oude_memo TEXT,
  Log_Nieuwe_memo TEXT,
  Log_Oude_record_datum DATETIME,
  Log_Nieuwe_recorddatum DATETIME,
  Log_Oude_user INTEGER,
  Log_Nieuwe_user INTEGER,
  Log_DbFilesId INTEGER,
  FOREIGN KEY(LOG_STATUSID) REFERENCES STATUS(STATUS_CODE) ON DELETE CASCADE ON UPDATE CASCADE,
  FOREIGN KEY(LOG_DBFILESID) REFERENCES DBFILES(DBFILES_ID) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE INDEX "IdxLog_Datum" ON Log (Log_Datum ASC); 
CREATE INDEX "IdxLog_Bestandsnr" ON Log (Log_Bestandsnr ASC); 
CREATE INDEX "IdxLog_RecordId" ON Log (Log_RecordId ASC); 
CREATE INDEX "IdxLog_StatusId" ON Log (Log_StatusId ASC);
CREATE INDEX "IdxLog_DbFilesId" ON Log (Log_DbFilesId ASC); 
CREATE INDEX "IdxLog_BRVV" ON Log (Log_Bestandsnr ASC, Log_RecordId ASC, Log_Veldnaam, Log_Volgnr ASC);
