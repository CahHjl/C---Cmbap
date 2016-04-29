CREATE TABLE Hoofdcategorie (
  Hcat_Id INTEGER NOT NULL PRIMARY KEY Autoincrement,
  Hcat_StatusId INTEGER DEFAULT 195002,
  Hcat_DispStatus VARCHAR(75) DEFAULT 'Ingevoerd hcat-record',
  Hcat_Prefix VARCHAR(3) DEFAULT 'PFX',
  Hcat_Kort VARCHAR(10) DEFAULT 'HCat-Kort' NOT NULL,
  Hcat_Lang VARCHAR(50) DEFAULT 'HCat-Lang' NOT NULL,
  Hcat_Opmerking VARCHAR(250),
  Hcat_Wijzigentoegestaan INTEGER DEFAULT 1 NOT NULL,
  FOREIGN KEY(HCAT_STATUSID) REFERENCES STATUS(STATUS_CODE) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE UNIQUE INDEX "IdxHcat_Kort" ON Hoofdcategorie (Hcat_Kort ASC);
CREATE UNIQUE INDEX "IdxHcat_Prefix" ON Hoofdcategorie (Hcat_Prefix ASC);
