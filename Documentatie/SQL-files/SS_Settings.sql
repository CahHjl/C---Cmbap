CREATE TABLE Settings (
  SettingsId INTEGER NOT NULL PRIMARY KEY Autoincrement,
  Settingnaam CHAR(25),
  Setting_Gegevenstype INTEGER,
  Setting_actief INTEGER,
  Setting_String CHAR(100),
  Setting_JN INTEGER,
  Setting_Integer INTEGER,
  Setting_Real REAL,
  Setting_Memo TEXT,
  Setting_Datum DATE,
  Setting_Tijd TIME
);
CREATE UNIQUE INDEX "IndxSettingNaam" ON Settings (Settingnaam DESC);