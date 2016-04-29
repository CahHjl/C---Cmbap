CREATE TABLE Programerror (
  PE_Id INTEGER NOT NULL PRIMARY KEY Autoincrement,
  PE_ProgrammaId INTEGER DEFAULT 1 NOT NULL,
  PE_ErrorcodeId INTEGER DEFAULT 1 NOT NULL,
  PE_PrgErrNr VARCHAR(11)  DEFAULT 'PE-PrgErrNr' NOT NULL,
  PE_Omschrijving VARCHAR(50) DEFAULT 'PE-Omschrijving' NOT NULL,
  PE_Oplossing VARCHAR(50) DEFAULT 'PE-Oplossing' NOT NULL,
  PE_Afhandeling INTEGER
); 
CREATE UNIQUE INDEX "IdxProgramerror" ON Programerror (PE_ProgrammaId DESC, PE_ErrorcodeId DESC);
