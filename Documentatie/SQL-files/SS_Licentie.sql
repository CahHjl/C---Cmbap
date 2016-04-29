CREATE TABLE Licentie (
  Lic_Id INTEGER NOT NULL PRIMARY KEY Autoincrement,
  Lic_Programma VARCHAR(10) NOT NULL,
  Lic_Nr INTEGER NOT NULL,
  Lic_Code VARCHAR(30),
  Lic_Type INTEGER DEFAULT 1 NOT NULL,
  Lic_Usermode INTEGER DEFAULT 1 NOT NULL,
  Lic_NaamLh VARCHAR(50) NOT NULL,
  Lic_DisplaynaamLh VARCHAR(35) NOT NULL,
  Lic_ContactpersoonLh VARCHAR(30) NOT NULL,
  Lic_AdresLh VARCHAR(50) NOT NULL,
  Lic_PostcodeLh VARCHAR(7) NOT NULL,
  Lic_WoonplaatsLh VARCHAR(50) NOT NULL,
  Lic_TelefoonnummerLh VARCHAR(20) NOT NULL,
  Lic_EmailadresLh VARCHAR(25) NOT NULL,
  Lic_Wachtwoord VARCHAR(20) DEFAULT 'Gebruiker',
  Lic_WachtwoordJN INTEGER DEFAULT 0
);  
CREATE UNIQUE INDEX "IdxLic_NaamLh" ON Licentie (Lic_NaamLh DESC);
CREATE UNIQUE INDEX "IdxLic_Nr" ON Licentie (Lic_Nr DESC);
