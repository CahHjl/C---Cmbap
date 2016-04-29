CREATE TABLE Klant_Begunstigde (
  KlBg_Id INTEGER NOT NULL PRIMARY KEY Autoincrement,
  KlBg_StatusId INTEGER DEFAULT 10009 NOT NULL,
  KlBg_DispStatus VARCHAR(75) DEFAULT 'KlBg-Onbekend',
  KlBg_KlantJN INTEGER DEFAULT 1 NOT NULL,
  KlBg_BegunstigdeJN INTEGER DEFAULT 0 NOT NULL,
  KlBg_Scipio_Lokaalnr INTEGER,
  KlBg_DebNr VARCHAR(20),
  KlBg_CredNr VARCHAR(20),
  KlBg_Voorvoegsel VARCHAR(10),
  KlBg_Voorletters VARCHAR(10),
  KlBg_Tussenvoegsel VARCHAR(10),
  KlBg_Achternaam VARCHAR(50),
  KlBg_VVTA VARCHAR(75) DEFAULT 'VVTA' NOT NULL,
  KlBg_AVVT VARCHAR(75) DEFAULT 'AVVT' NOT NULL,
  KlBg_Straatnaam VARCHAR(25),
  KlBg_Huisnummer VARCHAR(8),
  KlBg_Huisnummertoevoeging CHAR(3),
  KlBg_Adres VARCHAR(30),
  KlBg_Postcode VARCHAR(7),
  KlBg_Woonplaats VARCHAR(30),
  KlBg_Telefoonnummer VARCHAR(25),
  KlBg_Emailadres VARCHAR(45),
  KlBg_Extra_informatie VARCHAR(250),
  KLBG_SYSTEEMKLBGDISP VARCHAR(1) DEFAULT 'N',
  KlBg_KlDisp VARCHAR(1) DEFAULT 'J',
  KlBg_BgDisp VARCHAR(1) DEFAULT 'N',
  FOREIGN KEY(KLBG_STATUSID) REFERENCES STATUS(STATUS_CODE) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE INDEX "IdxKlBg_StatusId" ON Klant_Begunstigde (KlBg_StatusId);
CREATE INDEX "IdxKlBg_Scipio_lokaalnr" ON Klant_Begunstigde (KlBg_Scipio_Lokaalnr);
CREATE INDEX "IdxKlBg_VVTA" ON Klant_Begunstigde (KlBg_VVTA);
CREATE INDEX "IdxKlBg_AVVT" ON Klant_Begunstigde (KlBg_AVVT);
CREATE INDEX "IdxKlBg_Adres" ON Klant_Begunstigde (KlBg_Adres);
