CREATE TABLE Verwerkperiode (
  Vwp_Id INTEGER NOT NULL PRIMARY KEY Autoincrement,
  Vwp_StatusId INTEGER DEFAULT 145009,
  Vwp_Dispstatus VARCHAR(75) DEFAULT 'Verwerkperiode-rec is zijn leeg / Tabel-initrecord',
  Vwp_Begindatum DATETIME DEFAULT '01-01-1900 00:00:00' NOT NULL,
  Vwp_Einddatum DATETIME DEFAULT '05-01-1900 00:00:00' NOT NULL,
  Vwp_Beginsaldo CURRENCY DEFAULT 10,
  Vwp_Eindsaldo CURRENCY DEFAULT 20,
  Vwp_Opmerking VARCHAR(250),
  FOREIGN KEY(VWP_STATUSID) REFERENCES STATUS(STATUS_CODE) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE INDEX "IdxVwp_Begindatum" ON Verwerkperiode (Vwp_Begindatum ASC); 
CREATE INDEX "IdxVwp_Einddatum" ON Verwerkperiode (Vwp_Einddatum ASC);
