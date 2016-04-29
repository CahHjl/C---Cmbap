CREATE TABLE Status (
  StatusId INTEGER NOT NULL PRIMARY KEY Autoincrement,
  Status_groep INTEGER NOT NULL,
  Status_hoofdgroepitem INTEGER DEFAULT 0 NOT NULL,
  Status_nr INTEGER NOT NULL,
  Status_kort VARCHAR(20) NOT NULL,
  Status_lang VARCHAR(50) NOT NULL,
  Status_Opmerking VARCHAR(50),
  Status_Code INTEGER
);  
CREATE INDEX "IdxStatus_kort" ON Status (Status_kort DESC); 
CREATE INDEX "IdxStatus_codenr" ON Status (Status_groep, Status_nr);