CREATE TABLE Product (
  Prod_Id INTEGER NOT NULL PRIMARY KEY Autoincrement,
  Prod_StatusId INTEGER DEFAULT 170009 NOT NULL,
  Prod_DispStatus VARCHAR(75) DEFAULT 'Product-record is leeg / Tabelinitrecord',
  Prod_Naamkort CHAR(10) DEFAULT 'Prod_kort' NOT NULL,
  Prod_Naamlang CHAR(35) DEFAULT 'Prod_lang' NOT NULL,
  Prod_Kleur CHAR(10) DEFAULT 'Kleur',
  Prod_Code CHAR(10) DEFAULT 'Prod_code',
  Prod_Bon INTEGER DEFAULT 1 NOT NULL,
  Prod_Actief INTEGER DEFAULT 0 NOT NULL,
  Prod_DispActief VARCHAR(3) DEFAULT 'Nee' NOT NULL,
  Prod_Waarde DECIMAL(15,2) DEFAULT 0 NOT NULL,
  Prod_Aantaleenhedenperproduct Tinyint DEFAULT 20 NOT NULL,
  Prod_Eenheidnaam VARCHAR(5) DEFAULT 'vel' NOT NULL,
  Prod_Waardepereenheid DECIMAL(15,2) DEFAULT 0 NOT NULL,
  Prod_Opmerking VARCHAR(250),
  FOREIGN KEY(PROD_STATUSID) REFERENCES STATUS(STATUS_CODE) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE UNIQUE INDEX "IdxProd_Id" on product (Prod_Id ASC);
CREATE UNIQUE INDEX "IdxProd_Naamkort" on product (Prod_Id ASC, Prod_Naamkort ASC);
CREATE UNIQUE INDEX "IdxProd_Code" on product (Prod_Id ASC, Prod_Naamkort ASC, Prod_DispActief ASC);

