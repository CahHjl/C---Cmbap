using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using globalVars;
using ProcFunc;

namespace nsTblKb
{
    class tblKb
    {
        public struct kbRecord
        {
            public int KlBg_Id { get; set; }
            public int KlBg_StatusId { get; set; }
            public string KlBg_DispStatus { get; set; }
            public int KlBg_KlantJN { get; set; }
            public int KlBg_BegunstigdeJN { get; set; }
            public int KlBg_SysteemKlBgJN { get; set; }
            public int KlBg_Scipio_Lokaalnr { get; set; }
            public string KlBg_DebNr { get; set; }
            public string KlBg_CredNr { get; set; }
            public string KlBg_Voorvoegsel { get; set; }
            public string KlBg_Voorletter { get; set; }
            public string KlBg_Tussenvoegsel { get; set; }
            public string KlBg_Achternaam { get; set; }
            public string KlBg_VVTA { get; set; }
            public string KlBg_AVVT { get; set; }
            public string KlBg_Straatnaam { get; set; }
            public string KlBg_Huisnummer { get; set; }
            public string KlBg_Huisnummertoevoeging { get; set; }
            public string KlBg_Adres { get; set; }
            public string KlBg_Postcode { get; set; }
            public string KlBg_Woonplaats { get; set; }
            public string KlBg_Telefoonnummer { get; set; }
            public string KlBg_Emailadres { get; set; }
            public string KlBg_Extra_Informatie { get; set; }
            public string KlBg_SysteemKlBgDispJN { get; set; }
            public string KlBg_KlDispJN { get; set; }
            public string KlBg_BgDispJN { get; set; }
            public DateTime KlBg_Mutatiedatum { get; set; }
            public string KlBg_Opmerking { get; set; }
        }

        public List<kbRecord> lstKlantBegunstigdeRecord = new List<kbRecord>();
        public int kbListCount;
        public int kbListTCount;

        public void zoekKlantBegunstigdeRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Klant_Begunstigdetabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Klant_Begunstigde Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Klant_Begunstigde;";
                }
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    using (SQLiteDataReader sqlRdr = sqlCmd.ExecuteReader())
                    {
                        recordsInList(sqlRdr);
                    }
                }
                dbcDa.Close();
            }
        }

        public int telKlantBegunstigdeRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Klant_Begunstigdetabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Klant_Begunstigde Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Klant_Begunstigde;";
                }
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    using (SQLiteDataReader sqlRdr = sqlCmd.ExecuteReader())
                    {
                        kbListCount = 0;
                        kbListTCount = 0;
                        while (sqlRdr.Read())
                        {
                            //get rows
                            kbListTCount++;
                            if (sqlRdr.GetInt32(sqlRdr.GetOrdinal("Klbg_StatusId")) != 10009)
                            {
                                kbListCount++;
                            }
                        }
                    }
                }
                dbcDa.Close();
                return kbListCount;
            }
        }

        private void recordsInList(SQLiteDataReader r)
        {
            kbRecord kbr = new kbRecord();

            lstKlantBegunstigdeRecord.Clear();
            kbListCount = 0;
            kbListTCount = 0;

            while (r.Read())
            {
                //Maak list van geselecteerde rijen

                kbListTCount++;
                kbr.KlBg_Id = r.GetInt32(r.GetOrdinal("KlBg_Id"));
                kbr.KlBg_StatusId = r.GetInt32(r.GetOrdinal("KlBg_StatusId"));
                kbr.KlBg_DispStatus = r.GetString(r.GetOrdinal("KlBg_DispStatus"));
                if (r.GetInt32(r.GetOrdinal("KlBg_StatusId")) != 10009)
                {
                    kbListCount++;
                }
                 kbr.KlBg_KlantJN = r.GetInt32(r.GetOrdinal("KlBg_KlantJN"));
                 kbr.KlBg_BegunstigdeJN= r.GetInt32(r.GetOrdinal("KlBg_BegunstigdeJN"));
                 kbr.KlBg_SysteemKlBgJN= r.GetInt32(r.GetOrdinal("KlBg_SysteemKlBgJN"));
                 kbr.KlBg_Scipio_Lokaalnr = r.GetInt32(r.GetOrdinal("KlBg_Scipio_Lokaalnr"));
                 kbr.KlBg_DebNr = r.GetString(r.GetOrdinal("KlBg_Debnr"));
                 kbr.KlBg_CredNr = r.GetString(r.GetOrdinal("KlBg_Crednr"));
                 kbr.KlBg_Voorvoegsel = r.GetString(r.GetOrdinal("KlBg_Voorvoegsel"));
                 kbr.KlBg_Voorletter = r.GetString(r.GetOrdinal("KlBg_Voorletter"));
                 kbr.KlBg_Tussenvoegsel = r.GetString(r.GetOrdinal("KlBg_Tussenvoegsel"));
                 kbr.KlBg_Achternaam = r.GetString(r.GetOrdinal("KlBg_Achternaam"));
                 kbr.KlBg_VVTA = r.GetString(r.GetOrdinal("KlBg_VVTA"));
                kbr.KlBg_AVVT = r.GetString(r.GetOrdinal("KlBg_AVVT"));
                 kbr.KlBg_Straatnaam = r.GetString(r.GetOrdinal("KlBg_Straatnaam"));
                 kbr.KlBg_Huisnummer = r.GetString(r.GetOrdinal("KlBg_Huisnummer"));
                 kbr.KlBg_Huisnummertoevoeging = r.GetString(r.GetOrdinal("KlBg_Huisnummertoevoeging"));
                 kbr.KlBg_Adres = r.GetString(r.GetOrdinal("KlBg_Adres"));
                 kbr.KlBg_Postcode = r.GetString(r.GetOrdinal("KlBg_Postcode"));
                 kbr.KlBg_Woonplaats = r.GetString(r.GetOrdinal("KlBg_Woonplaats"));
                 kbr.KlBg_Telefoonnummer = r.GetString(r.GetOrdinal("KlBg_Telefoonnummer"));
                 kbr.KlBg_Emailadres = r.GetString(r.GetOrdinal("KlBg_Emailadres"));
                 kbr.KlBg_Extra_Informatie = r.GetString(r.GetOrdinal("KlBg_Extra_Informatie"));
                 kbr.KlBg_SysteemKlBgDispJN = r.GetString(r.GetOrdinal("KlBg_SysteemKlBgDispJN"));
                 kbr.KlBg_KlDispJN = r.GetString(r.GetOrdinal("KlBg_KlDispJN"));
                 kbr.KlBg_BgDispJN = r.GetString(r.GetOrdinal("KlBg_BgDispJN"));
                 kbr.KlBg_Mutatiedatum = r.GetDateTime(r.GetOrdinal("KlBg_Mutatiedatum"));
                 kbr.KlBg_Opmerking = "";
                 try
                 {
                     kbr.KlBg_Opmerking = r.GetString(r.GetOrdinal("KlBg_Opmerking"));
                 }
                 catch (Exception)
                 {
                 }
                 lstKlantBegunstigdeRecord.Add(kbr);
            }

        }

        public kbRecord vanRecord(int recNr)
        {
            kbRecord kbRec = new kbRecord();
            kbRec.Prod_Id = lstProductRecord[recNr].Prod_Id;
            kbRec.Prod_StatusId = lstProductRecord[recNr].Prod_StatusId;
            kbRec.Prod_DispStatus = lstProductRecord[recNr].Prod_DispStatus;
            kbRec.Prod_Naamkort = lstProductRecord[recNr].Prod_Naamkort;
            kbRec.Prod_Naamlang = lstProductRecord[recNr].Prod_Naamlang;
            kbRec.Prod_Kleur = lstProductRecord[recNr].Prod_Kleur;
            kbRec.Prod_Code = lstProductRecord[recNr].Prod_Code;
            kbRec.Prod_Soort = lstProductRecord[recNr].Prod_Soort;
            kbRec.Prod_ActiefJN = lstProductRecord[recNr].Prod_ActiefJN;
            kbRec.Prod_Dispactief = lstProductRecord[recNr].Prod_Dispactief;
            kbRec.Prod_Waarde = lstProductRecord[recNr].Prod_Waarde;
            kbRec.Prod_Aantaleenhedenperproduct = lstProductRecord[recNr].Prod_Aantaleenhedenperproduct;
            kbRec.Prod_Verzamelnaam = lstProductRecord[recNr].Prod_Verzamelnaam;
            kbRec.Prod_Waardepereenheid = lstProductRecord[recNr].Prod_Waardepereenheid;
            kbRec.Prod_Mutatiedatum = lstProductRecord[recNr].Prod_Mutatiedatum;
            kbRec.Prod_Opmerking = lstProductRecord[recNr].Prod_Opmerking;
            return kbRec;
        }

        public kbRecord vulDefaultKb()
        {
            pf pf = new pf();
            kbRecord kbRec = new kbRecord();
            kbRec.Prod_StatusId = 170009;
            kbRec.Prod_DispStatus = "Product-record is leeg / Tabelinitrecord";
            kbRec.Prod_Naamkort = "Prod_kort";
            kbRec.Prod_Naamlang = "Prod_lang";
            kbRec.Prod_Kleur = "Kleur";
            kbRec.Prod_Code = "Prod_code";
            kbRec.Prod_Soort = "B";
            kbRec.Prod_ActiefJN = 0;
            kbRec.Prod_Dispactief = "Nee";
            kbRec.Prod_Waarde = 0;
            kbRec.Prod_Aantaleenhedenperproduct = 20;
            kbRec.Prod_Verzamelnaam = "vel";
            kbRec.Prod_Waardepereenheid = 0;
            kbRec.Prod_Mutatiedatum = DateTime.Parse("2000-01-01 00:00:00");
            kbRec.Prod_Opmerking = "";
            return kbRec;
        }

        kbr.newKbRecord()
        {
            pf pf = new pf();
            kbRecord dKb = new kbRecord();
            dKb = vulDefaultKb();
            int newKbId = new int();
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                string findstring = pf.randomString(6);
                string sqlStr = "Insert Into Product (Prod_StatusId, Prod_DispStatus, Prod_Naamkort, Prod_Naamlang, " +
                                "Prod_Kleur, Prod_Code, Prod_Soort, Prod_ActiefJN, Prod_Dispactief, Prod_Waarde, " +
                                "Prod_Aantaleenhedenperproduct, Prod_Verzamelnaam, Prod_Waardepereenheid, Prod_Mutatiedatum, " +
                                "Prod_Opmerking) Values (@2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16)";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    SQLiteParameter p2 = new SQLiteParameter(); p2.ParameterName = "@2"; p2.Value = 170009; sqlCmd.Parameters.Add(p2);
                    SQLiteParameter p3 = new SQLiteParameter(); p3.ParameterName = "@3"; p3.Value = "Product-record is leeg / Tabelinitrecord"; sqlCmd.Parameters.Add(p3);
                    SQLiteParameter p4 = new SQLiteParameter(); p4.ParameterName = "@4"; p4.Value = "Prod_kort"; sqlCmd.Parameters.Add(p4);
                    SQLiteParameter p5 = new SQLiteParameter(); p5.ParameterName = "@5"; p5.Value = "Prod_lang"; sqlCmd.Parameters.Add(p5);
                    SQLiteParameter p6 = new SQLiteParameter(); p6.ParameterName = "@6"; p6.Value = "Kleur"; sqlCmd.Parameters.Add(p6);
                    SQLiteParameter p7 = new SQLiteParameter(); p7.ParameterName = "@7"; p7.Value = "Prod_code"; sqlCmd.Parameters.Add(p7);
                    SQLiteParameter p8 = new SQLiteParameter(); p8.ParameterName = "@8"; p8.Value = "B"; sqlCmd.Parameters.Add(p8);
                    SQLiteParameter p9 = new SQLiteParameter(); p9.ParameterName = "@9"; p9.Value = 0; sqlCmd.Parameters.Add(p9);
                    SQLiteParameter p10 = new SQLiteParameter(); p10.ParameterName = "@10"; p10.Value = "Nee"; sqlCmd.Parameters.Add(p10);
                    SQLiteParameter p11 = new SQLiteParameter(); p11.ParameterName = "@11"; p11.Value = 0; sqlCmd.Parameters.Add(p11);
                    SQLiteParameter p12 = new SQLiteParameter(); p12.ParameterName = "@12"; p12.Value = 20; sqlCmd.Parameters.Add(p12);
                    SQLiteParameter p13 = new SQLiteParameter(); p13.ParameterName = "@13"; p13.Value = "vel"; sqlCmd.Parameters.Add(p13);
                    SQLiteParameter p14 = new SQLiteParameter(); p14.ParameterName = "@14"; p14.Value = 0; sqlCmd.Parameters.Add(p14);
                    SQLiteParameter p15 = new SQLiteParameter(); p15.ParameterName = "@15"; p15.Value = DateTime.Parse("2000-01-01 00:00:00"); sqlCmd.Parameters.Add(p15);
                    SQLiteParameter p16 = new SQLiteParameter(); p16.ParameterName = "@16"; p16.Value = findstring; sqlCmd.Parameters.Add(p16);
                    sqlCmd.ExecuteNonQuery();
                    dbcDa.Close();
                }

                // Zoek toegevoegde record
                tblKb kb = new tblKb();
                kb.zoekProductRecord("Prod_Opmerking = " + "\"" + findstring + "\"");
                newKbId = kb.lstProductRecord[0].Prod_Id;

                // Verwijder infor uit Opmerking-veld
                dbcDa.Open();
                sqlStr = "Update Product set KlBg_Opmerking=@16 where KlBg_Id = @1;";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    sqlCmd.Parameters.AddWithValue("@1", newKbId);
                    sqlCmd.Parameters.AddWithValue("@16", "");
                    sqlCmd.ExecuteNonQuery();
                }
                dbcDa.Close();


                return newKbId;
            }
        }

        public void saveRecord(int iKbId, kbRecord kbR)
        {
            string sqlStr = "Update Product set Prod_StatusId=@2, Prod_DispStatus=@3, Prod_Naamkort=@4, Prod_Naamlang=@5, " +
                            "Prod_Kleur=@6, Prod_Code=@7, Prod_Soort=@8, Prod_ActiefJN=@9, Prod_Dispactief=@10, Prod_Waarde=@11, " +
                            "Prod_Aantaleenhedenperproduct=@12, Prod_Verzamelnaam=@13, Prod_Waardepereenheid=@14, Prod_Mutatiedatum=@15, " +
                            "Prod_Opmerking=@16 Where Prod_Id=@1";

            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", iKbId);
                        sqlCmd.Parameters.AddWithValue("@2", kbR.Prod_StatusId);
                        sqlCmd.Parameters.AddWithValue("@3", kbR.Prod_DispStatus);
                        sqlCmd.Parameters.AddWithValue("@4", kbR.Prod_Naamkort);
                        sqlCmd.Parameters.AddWithValue("@5", kbR.Prod_Naamlang);
                        sqlCmd.Parameters.AddWithValue("@6", kbR.Prod_Kleur);
                        sqlCmd.Parameters.AddWithValue("@7", kbR.Prod_Code);
                        sqlCmd.Parameters.AddWithValue("@8", kbR.Prod_Soort);
                        sqlCmd.Parameters.AddWithValue("@9", kbR.Prod_ActiefJN);
                        sqlCmd.Parameters.AddWithValue("@10", kbR.Prod_Dispactief);
                        sqlCmd.Parameters.AddWithValue("@11", kbR.Prod_Waarde);
                        sqlCmd.Parameters.AddWithValue("@12", kbR.Prod_Aantaleenhedenperproduct);
                        sqlCmd.Parameters.AddWithValue("@13", kbR.Prod_Verzamelnaam);
                        sqlCmd.Parameters.AddWithValue("@14", kbR.Prod_Waardepereenheid);
                        sqlCmd.Parameters.AddWithValue("@15", kbR.Prod_Mutatiedatum);
                        sqlCmd.Parameters.AddWithValue("@16", kbR.Prod_Opmerking);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception) { }

                dbcDa.Close();
            }
        }

        public void deleteRecord(int iKbId)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    string sqlStr = "Delete from Klant_Begunstigde Where KlBg_Id=@1;";
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", iKbId);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (SystemException ex)
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("Fout bij verwijderen van Klant-Begunstigde-gegevens: {0}", ex.Message));
                }
            }
        }
    }
}

