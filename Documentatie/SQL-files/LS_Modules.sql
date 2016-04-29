CREATE TABLE Modules (
  Module_Id INTEGER NOT NULL PRIMARY KEY Autoincrement,
  Module_kort VARCHAR(10),
  Module_lang VARCHAR(25),
  Module_actief INTEGER,
  Module_licentieId INTEGER,
  FOREIGN KEY(Module_LicentieId) REFERENCES Licentie(Lic_Id) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE INDEX "IdxModuleKort" ON Modules (Module_kort DESC);
CREATE INDEX "IdxLicentieId" ON Modules (LicentieId DESC); 
CREATE UNIQUE INDEX "IdxLicentieKortId" ON Modules (LicentieId DESC, Module_kort DESC);
