CREATE TABLE Programerror (
  PE_Id INTEGER NOT NULL PRIMARY KEY Autoincrement,
  PE_ProgrammaId INTEGER NOT NULL,
  PE_ErrorcodeId INTEGER NOT NULL,
  PE_PrgErrNr VARCHAR(11) NOT NULL,
  PE_Omschrijving VARCHAR(50) NOT NULL,
  PE_Oplossing VARCHAR(50) NOT NULL,
  PE_Afhandeling INTEGER
); 
CREATE UNIQUE INDEX "IdxProgramerror" ON Programerror (PE_ProgrammaId DESC, PE_ErrorcodeId DESC);