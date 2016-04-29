DROP TABLE Licentie;
CREATE TABLE Licentie (
  Lic_Id AUTOINC NOT NULL,
  Lic_Programma VARCHAR(10) NOT NULL,
  Lic_Nr INTEGER NOT NULL,
  Lic_Code VARCHAR(30),
  Lic_Type BYTE DEFAULT 1 NOT NULL,
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
  Lic_WachtwoordJN LOGICAL DEFAULT False, 
  PRIMARY KEY IdxLic_Id (Lic_Id DESC), 
  UNIQUE INDEX IdxLic_NaamLh (Lic_NaamLh DESC NOCASE), 
  UNIQUE INDEX IdxLic_Nr (Lic_Nr DESC)
);
INSERT INTO Licentie (Lic_Id, Lic_Programma, Lic_Nr, Lic_Code, Lic_Type, Lic_Usermode, Lic_NaamLh, Lic_DisplaynaamLh, Lic_ContactpersoonLh, Lic_AdresLh, Lic_PostcodeLh, Lic_WoonplaatsLh, Lic_TelefoonnummerLh, Lic_EmailadresLh, Lic_Wachtwoord, Lic_WachtwoordJN) values (1, 'Cbp', 10001, NULL, 1, 5, 'Kerkgemeente De Dorpskerk', 'KG De Dorpskerk', 'H. Administrateur', 'Dorpsplein 1', '1122 AA', 'Het Dorp', '011-123456789', 'info@KG_De_Dorpskerk.nl', 'Gebruiker', False);

