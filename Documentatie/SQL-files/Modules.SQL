DROP TABLE Modules;
CREATE TABLE Modules (
  ModuleId AUTOINC,
  Module_kort VARCHAR(10),
  Module_lang VARCHAR(25),
  Module_actief LOGICAL,
  LicentieId INTEGER, 
  PRIMARY KEY IdxModuleId (ModuleId DESC), 
  INDEX IdxModuleKort (Module_kort DESC NOCASE), 
  INDEX IdxLicentieId (LicentieId DESC), 
  UNIQUE INDEX IdxLicentieKortId (LicentieId DESC NOCASE, Module_kort DESC NOCASE)
);
INSERT INTO Modules (ModuleId, Module_kort, Module_lang, Module_actief, LicentieId) values (1, 'Cbp_basis', 'Cbp_basis', True, 1);

