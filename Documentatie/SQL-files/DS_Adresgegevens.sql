CREATE TABLE Adresgegevens (
  Adrsgeg_Id INTEGER NOT NULL PRIMARY KEY Autoincrement,
  Adrsgeg_StatusId INTEGER DEFAULT 20009,
  Adrsgeg_DispStatus VARCHAR(75) DEFAULT "Adresgegevens zijn leeg / Tabel-initrecord",
  Adrsgeg_KlBgId INTEGER DEFAULT 1 NOT NULL,
  Adrsgeg_DispKlBg VARCHAR(75),
  Adrsgeg_Straatnaam VARCHAR(50) DEFAULT 'Straatnaam' NOT NULL,
  Adrsgeg_Huisnummer VARCHAR(8) DEFAULT '0' NOT NULL,
  Adrsgeg_Huisnummertoevoeging VARCHAR(5),
  Adrsgeg_Adres VARCHAR(50) DEFAULT 'Straatnaam 0' NOT NULL,
  Adrsgeg_Postcode VARCHAR(7) DEFAULT '0000 AA' NOT NULL,
  Adrsgeg_Woonplaats VARCHAR(50) DEFAULT 'Woonplaats' NOT NULL,
  Adrsgeg_Mutatiedatum DATETIME DEFAULT '01-01-1900' NOT NULL,
  Adrsgeg_Opmerking VARCHAR(250),
  FOREIGN KEY(ADRSGEG_KLBGID) REFERENCES KLANT_BEGUNSTIGDE(KLBG_ID) ON DELETE CASCADE ON UPDATE CASCADE,
  FOREIGN KEY(ADRSGEG_STATUSID) REFERENCES STATUS(STATUS_CODE) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE INDEX "IdxAdrsgeg_KlBgId" ON Adresgegevens (Adrsgeg_KlBgId ASC); 
CREATE INDEX "IdxAdrsgeg_StatusId" ON Adresgegevens (Adrsgeg_StatusId ASC);
CREATE INDEX "IdxAdrsgeg_Straatnaam" ON Adresgegevens (Adrsgeg_Straatnaam ASC);
CREATE INDEX "IdxAdrsgeg_Adres" ON Adresgegevens (Adrsgeg_Adres ASC);
CREATE INDEX "IdxAdrsgeg_PcWoonplaats" ON Adresgegevens (Adrsgeg_Postcode ASC, Adrsgeg_Woonplaats ASC);
