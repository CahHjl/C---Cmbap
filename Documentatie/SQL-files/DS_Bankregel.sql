CREATE TABLE Bankregel (
  Bnkrgl_Id INTEGER NOT NULL PRIMARY KEY Autoincrement,
  Bnkrgl_StatusId INTEGER DEFAULT 125009,
  Bnkrgl_DispStatus VARCHAR(75) DEFAULT "Bankregel is leeg / Tabel-initrecord",
  Bnkrgl_VerwerkId INTEGER DEFAULT 1 NOT NULL,
  Bnkrgl_Bankregel TEXT,
  Bnkrgl_BstlId INTEGER DEFAULT 1 NOT NULL,
  Bnkrgl_Opmerking VARCHAR(250)
  FOREIGN KEY(Bnkrgl_StatusId) REFERENCES STATUS(STATUS_CODE) ON DELETE CASCADE ON UPDATE CASCADE
  FOREIGN KEY(Bnkrgl_VerwerkId) REFERENCES Verwerkperiode(Vwp_Id) ON DELETE CASCADE ON UPDATE CASCADE
  FOREIGN KEY(Bnkrgl_BstlId) REFERENCES Bestelling(Bstl_Id) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE INDEX "IdxBnkrgl_VerwerkId" ON Bankregel (Bnkrgl_VerwerkId ASC); 
CREATE INDEX "IdxBnkrgl_StatusId" ON Bankregel (Bnkrgl_StatusId ASC); 
CREATE INDEX "IdxBnkrgl_BstlId" ON Bankregel (Bnkrgl_BstlId ASC);