CREATE TABLE Bestelling (
  Bstl_Id INTEGER NOT NULL PRIMARY KEY Autoincrement,
  Bstl_StatusId INTEGER DEFAULT 120009,
  Bstl_Dispstatus VARCHAR(75) DEFAULT 'Bestelling is leeg / Tabel-initrecord',
  Bstl_BgnrId INTEGER DEFAULT 1 NOT NULL,
  Bstl_DispBgnr VARCHAR(18),
  Bstl_KlBgId INTEGER DEFAULT 1 NOT NULL,
  Bstl_DispKlBg VARCHAR(70) DEFAULT 'Klant-Begunstigde',
  Bstl_VerwerkperiodeId INTEGER DEFAULT 1,
  Bstl_Valutadatum DATETIME DEFAULT '1900-01-01' NOT NULL,
  Bstl_Bestelbedrag DECIMAL(15,2) DEFAULT 0 NOT NULL,
  Bstl_Diversen DECIMAL(15,2),
  Bstl_DiversenId INTEGER DEFAULT 121009,
  Bstl_DispDiversen VARCHAR(50) DEFAULT 'Bstl Div-Leeg',
  Bstl_Verschil DECIMAL(15,2),
  Bstl_VerschilId INTEGER DEFAULT 122009,
  Bstl_DispVerschil VARCHAR(50) DEFAULT 'Bstl_Vschl-Leeg',
  Bstl_Vastekostenperbestelling DECIMAL(15,2),
  Bstl_Bonnengevraagd INTEGER DEFAULT 1 NOT NULL,
  Bstl_Opmerking VARCHAR(20),
  FOREIGN KEY(Bstl_VerschilId) REFERENCES Status(Status_Code),
  FOREIGN KEY(Bstl_DiversenId) REFERENCES Status(Status_Code),
  FOREIGN KEY(Bstl_StatusId) REFERENCES Status(Status_Code),
  FOREIGN KEY(Bstl_BgnrId) REFERENCES Bankgironr(Bgnr_Id),
  FOREIGN KEY(Bstl_VerwerkperiodeId) REFERENCES Verwerkperiode(Vwp_Id),
  FOREIGN KEY(Bstl_KlBgId) REFERENCES Klant_Begunstigde(KlBg_Id)
 ); 
 
CREATE INDEX "IdxBstl_BgnrId" ON Bestelling (Bstl_BgnrId ASC); 
CREATE INDEX "IdxBstl_KlBgId" ON Bestelling (Bstl_KlBgId ASC); 
CREATE INDEX "IdxBstl_VerwerkperiodeId" ON Bestelling (Bstl_VerwerkperiodeId ASC); 
CREATE INDEX "IdxBstl_ValutaDatum" ON Bestelling (Bstl_Valutadatum ASC); 
CREATE INDEX "IdxBstl_DispBgnr" ON Bestelling (Bstl_DispBgnr ASC); 
CREATE INDEX "IdxBstl_DispKlBg" ON Bestelling (Bstl_DispKlBg ASC);