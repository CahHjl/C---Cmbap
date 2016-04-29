CREATE TABLE DbFiles (
  DbFilesId INTEGER NOT NULL PRIMARY KEY Autoincrement,
  DbFiles_Naam VARCHAR(30) DEFAULT 'Db-filenaam' NOT NULL,
  DbFiles_Omschrijving VARCHAR(100),
  DbFiles_Nr INTEGER NOT NULL,
  DbFiles_Kort VARCHAR(4) DEFAULT 'Dbfn' NOT NULL
);
  
CREATE UNIQUE INDEX "IdxDbFiles_Naam" ON DbFiles (DbFiles_Naam DESC); 
CREATE UNIQUE INDEX "IdxDbFiles_Nr" ON DbFiles (DbFiles_Nr DESC);