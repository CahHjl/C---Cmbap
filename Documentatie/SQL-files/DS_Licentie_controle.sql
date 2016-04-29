CREATE TABLE Licentie_controle (
  Licctrl_Id INTEGER NOT NULL PRIMARY KEY Autoincrement,
  Licctrl_StatusId INTEGER DEFAULT 175009,
  Licctrl_DispStatus VARCHAR(75) DEFAULT 'Licctrl-record is leeg / Tabelinitrecord',
  Licctrl_Programma VARCHAR(10) DEFAULT 'Cmbap'NOT NULL,
  Licctrl_Nr INTEGER DEFAULT 0 NOT NULL,
  Licctrl_Code VARCHAR(30),
  Licctrl_Type BYTE DEFAULT 1 NOT NULL,
  Licctrl_Usermode INTEGER DEFAULT 1 NOT NULL,
  Licctrl_ControleCode VARCHAR(30) DEFAULT '12345',
  FOREIGN KEY(LICCTRL_STATUSID) REFERENCES STATUS(STATUS_CODE) ON UPDATE CASCADE ON DELETE CASCADE
);
CREATE UNIQUE INDEX "IdxLicctrl_Nr" ON Licentie_controle (Licctrl_Nr ASC);