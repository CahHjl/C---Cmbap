using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using ProcFunc;
using globalVars;

namespace nsTblAg
{
    class tblAg
    {
        public struct agRecord
        {
            public int Adrsgeg_Id { get; set; }
            public int Adrsgeg_StatusId { get; set; }
            public string Adrsgeg_DispStatus { get; set; }
            public int Adrsgeg_KlBgId { get; set; }
            public string Adrsgeg_DispKlBg { get; set; }
            public string Adrsgeg_Straatnaam { get; set; }
            public string Adrsgeg_Huisnummer { get; set; }
            public string Adrsgeg_Huisnummertoevoeging { get; set; }
            public string Adrsgeg_Adres { get; set; }
            public string Adrsgeg_Postcode { get; set; }
            public string Adrsgeg_Woonplaats { get; set; }
            public DateTime Adrsgeg_Mutatiedatum { get; set; }
            public string Adrsgeg_Opmerking { get; set; }
        }

        public List<agRecord> lstAdrsgegRecord = new List<agRecord>();
        public int agListCount;
        public int agListTCount;

        public void zoekAdresgegevensRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Adresgegevenstabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Adresgegevens Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Adresgegevens;";
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

        public int telAdresgegevensRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Tel records in Adresgegevenstabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Adresgegevens Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Adresgegevens;";
                }
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    using (SQLiteDataReader sqlRdr = sqlCmd.ExecuteReader())
                    {
                        agListCount = 0;
                        agListTCount = 0;
                        while (sqlRdr.Read())
                        {
                            //get rows
                            agListTCount++;
                            if (sqlRdr.GetInt32(sqlRdr.GetOrdinal("Adrsgeg_StatusId")) != 20009)
                            {
                                agListCount++;
                            }
                        }
                    }
                }
                dbcDa.Close();
                return agListCount;
            }
        }

        private void recordsInList(SQLiteDataReader r)
        {
            agRecord agr = new agRecord();

            lstAdrsgegRecord.Clear();
            agListCount = 0;
            agListTCount = 0;

            while (r.Read())
            {
                //Maak list van geselecteerde rijen

                agListTCount++;
                agr.Adrsgeg_Id = r.GetInt32(r.GetOrdinal("Adrsgeg_Id"));
                agr.Adrsgeg_StatusId = r.GetInt32(r.GetOrdinal("Adrsgeg_StatusId"));
                agr.Adrsgeg_DispStatus = r.GetString(r.GetOrdinal("Adrsgeg_DispStatus"));
                if (r.GetInt32(r.GetOrdinal("Adrsgeg_StatusId")) != 20009)
                {
                    agListCount++;
                }
                agr.Adrsgeg_KlBgId = r.GetInt32(r.GetOrdinal("Adrsgeg_KlBgId"));
                agr.Adrsgeg_DispKlBg = r.GetString(r.GetOrdinal("Adrsgeg_DispKlBg"));
                agr.Adrsgeg_Straatnaam = r.GetString(r.GetOrdinal("Adrsgeg_Straatnaam"));
                agr.Adrsgeg_Huisnummer = r.GetString(r.GetOrdinal("Adrsgeg_Huisnummer"));
                agr.Adrsgeg_Huisnummertoevoeging = r.GetString(r.GetOrdinal("Adrsgeg_Huisnummertoevoeging"));
                agr.Adrsgeg_Adres = r.GetString(r.GetOrdinal("Adrsgeg_Adres"));
                agr.Adrsgeg_Postcode = r.GetString(r.GetOrdinal("Adrsgeg_Postcode"));
                agr.Adrsgeg_Woonplaats = r.GetString(r.GetOrdinal("Adrsgeg_Woonplaats"));
                agr.Adrsgeg_Mutatiedatum = r.GetDateTime(r.GetOrdinal("Adrsgeg_Mutatiedatum"));
                agr.Adrsgeg_Opmerking = "";
                try
                {
                    agr.Adrsgeg_Opmerking = r.GetString(r.GetOrdinal("Adrsgeg_Opmerking"));
                }
                catch (Exception)
                {
                }
                lstAdrsgegRecord.Add(agr);
            }
        }

            public agRecord vanRecord(int recNr)
            {
                agRecord agRec = new agRecord();
                agRec.Adrsgeg_Id = lstAdrsgegRecord[recNr].Adrsgeg_Id;
                agRec.Adrsgeg_StatusId = lstAdrsgegRecord[recNr].Adrsgeg_StatusId;
                agRec.Adrsgeg_DispStatus = lstAdrsgegRecord[recNr].Adrsgeg_DispStatus;
                agRec.Adrsgeg_KlBgId = lstAdrsgegRecord[recNr].Adrsgeg_KlBgId;
                agRec.Adrsgeg_DispKlBg = lstAdrsgegRecord[recNr].Adrsgeg_DispKlBg;
                agRec.Adrsgeg_Straatnaam = lstAdrsgegRecord[recNr].Adrsgeg_Straatnaam;
                agRec.Adrsgeg_Huisnummer = lstAdrsgegRecord[recNr].Adrsgeg_Huisnummer;
                agRec.Adrsgeg_Huisnummertoevoeging = lstAdrsgegRecord[recNr].Adrsgeg_Huisnummertoevoeging;
                agRec.Adrsgeg_Adres = lstAdrsgegRecord[recNr].Adrsgeg_Adres;
                agRec.Adrsgeg_Postcode = lstAdrsgegRecord[recNr].Adrsgeg_Postcode;
                agRec.Adrsgeg_Woonplaats = lstAdrsgegRecord[recNr].Adrsgeg_Woonplaats;
                agRec.Adrsgeg_Mutatiedatum = lstAdrsgegRecord[recNr].Adrsgeg_Mutatiedatum;
                agRec.Adrsgeg_Opmerking = lstAdrsgegRecord[recNr].Adrsgeg_Opmerking;
                return agRec;
            }

            public agRecord vulDefaultAg()
            {
                pf pf = new pf();
                agRecord agRec = new agRecord();

                agRec.Adrsgeg_StatusId = 20009;
                agRec.Adrsgeg_DispStatus = "Adresgegevens zijn leeg / Tabel-initrecord";
                agRec.Adrsgeg_KlBgId = 1;
                agRec.Adrsgeg_DispKlBg = "Klant-begunstigde";
                agRec.Adrsgeg_Straatnaam = "Straatnaam";
                agRec.Adrsgeg_Huisnummer = 0;
                agRec.Adrsgeg_Huisnummertoevoeging = "";
                agRec.Adrsgeg_Adres = "Straatnaam 0";
                agRec.Adrsgeg_Postcode = "0000 AA";
                agRec.Adrsgeg_Woonplaats = "Woonplaats";
                agRec.Adrsgeg_Mutatiedatum = DateTime.Parse("2000-01-01 00:00:00");
                agRec.Adrsgeg_Opmerking = "";
                return agRec;
            }

            public int newAgRecord()
            {
                pf pf = new pf();
                agRecord dAg = new agRecord();
                dAg = vulDefaultAg();
                int newAgId = new int();
                string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

                using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
                {
                    dbcDa.Open();
                    string findstring = pf.randomString(6);
                    string sqlStr = "Insert Into Adresgegevens (Adrsgeg_StatusId, Adrsgeg_DispStatus, Adrsgeg_KlBgId, Adrsgeg_DispKlBg, " +
                                    "Adrsgeg_Straatnaam, Adrsgeg_Huisnummer, Adrsgeg_Huisnummertoevoeging, Adrsgeg_Adres, Adrsgeg_Postcode, "+
                                    "Adrsgeg_Woonplaats, Adrsgeg_Mutatiedatum, Adrsgeg_Opmerking) " +
                                    "Values (@2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13)";
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                    SQLiteParameter p2 = new SQLiteParameter(); p2.ParameterName = "@2"; p2.Value = 20009; sqlCmd.Parameters.Add(p2);
                    SQLiteParameter p3 = new SQLiteParameter(); p3.ParameterName = "@3"; p3.Value = "Adresgegevens-record is leeg / Tabelinitrecord"; sqlCmd.Parameters.Add(p3);
                    SQLiteParameter p4 = new SQLiteParameter(); p4.ParameterName = "@4"; p4.Value = 1; sqlCmd.Parameters.Add(p4);
                    SQLiteParameter p5 = new SQLiteParameter(); p5.ParameterName = "@5"; p5.Value = "Klant-begunstigde"; sqlCmd.Parameters.Add(p5);
                    SQLiteParameter p6 = new SQLiteParameter(); p6.ParameterName = "@6"; p6.Value = "Straatnaam"; sqlCmd.Parameters.Add(p6);
                    SQLiteParameter p7 = new SQLiteParameter(); p7.ParameterName = "@7"; p7.Value = 0; sqlCmd.Parameters.Add(p7);
                    SQLiteParameter p8 = new SQLiteParameter(); p8.ParameterName = "@8"; p8.Value = ""; sqlCmd.Parameters.Add(p8);
                    SQLiteParameter p9 = new SQLiteParameter(); p9.ParameterName = "@9"; p9.Value = "Straatnaam 0"; sqlCmd.Parameters.Add(p9);
                    SQLiteParameter p10 = new SQLiteParameter(); p10.ParameterName = "@10"; p10.Value = "0000 AA"; sqlCmd.Parameters.Add(p10);
                    SQLiteParameter p11 = new SQLiteParameter(); p11.ParameterName = "@11"; p11.Value = "Woonplaats"; sqlCmd.Parameters.Add(p11);
                    SQLiteParameter p12 = new SQLiteParameter(); p12.ParameterName = "@12"; p12.Value = DateTime.Parse("2000-01-01 00:00:00"); sqlCmd.Parameters.Add(p12);
                    SQLiteParameter p13 = new SQLiteParameter(); p13.ParameterName = "@13"; p13.Value = findstring; sqlCmd.Parameters.Add(p13);
                    sqlCmd.ExecuteNonQuery();
                    dbcDa.Close();
                  }

                  // Zoek toegevoegde record
                    tblAg ag = new tblAg();
                    ag.zoekAdresgegevensRecord("Adrsgeg_Opmerking = " + "\"" + findstring + "\"");
                    newAgId = ag.lstAdrsgegRecord[0].Adrsgeg_Id;

                    // Verwijder infor uit Opmerking-veld
                    dbcDa.Open();
                    sqlStr = "Update Adresgegevens set Adrsgeg_Opmerking=@16 where Adrsgeg_Id = @1;";
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", newAgId);
                        sqlCmd.Parameters.AddWithValue("@16", "");
                        sqlCmd.ExecuteNonQuery();
                    }
                    dbcDa.Close();


                    return newAgId;
                }
            }

            public void saveRecord(int iAgId, agRecord agR)
            {
                string sqlStr = "Update Adresgegevens set Adrsgeg_StatusId=@2, Adrsgeg_DispStatus=@3, Adrsgeg_KlBgId=@4, Adrsgeg_DispKlBg=@5, " +
                                "Adrsgeg_Straatnaam=@6, Adrsgeg_Huisnummer=@7, Adrsgeg_Huisnummertoevoeging=@8, Adrsgeg_Adres=@9, Adrsgeg_Postcode=@10, " +
                                "Adrsgeg_Woonplaats=@11, Adrsgeg_Mutatiedatum=@12, Adrsgeg_Opmerking=@13 Where Adrsgeg_Id=@1";


                string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
                using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
                {
                    dbcDa.Open();
                    try
                    {
                        using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                        {
                            sqlCmd.Parameters.AddWithValue("@1", iAgId);
                            sqlCmd.Parameters.AddWithValue("@2", agR.Adrsgeg_StatusId);
                            sqlCmd.Parameters.AddWithValue("@3", agR.Adrsgeg_DispStatus);
                            sqlCmd.Parameters.AddWithValue("@4", agR.Adrsgeg_KlBgId);
                            sqlCmd.Parameters.AddWithValue("@5", agR.Adrsgeg_DispKlBg);
                            sqlCmd.Parameters.AddWithValue("@6", agR.Adrsgeg_Straatnaam);
                            sqlCmd.Parameters.AddWithValue("@7", agR.Adrsgeg_Huisnummer);
                            sqlCmd.Parameters.AddWithValue("@8", agR.Adrsgeg_Huisnummertoevoeging);
                            sqlCmd.Parameters.AddWithValue("@9", agR.Adrsgeg_Adres);
                            sqlCmd.Parameters.AddWithValue("@10", agR.Adrsgeg_Postcode);
                            sqlCmd.Parameters.AddWithValue("@11", agR.Adrsgeg_Woonplaats);
                            sqlCmd.Parameters.AddWithValue("@12", agR.Adrsgeg_Mutatiedatum);
                            sqlCmd.Parameters.AddWithValue("@13", agR.Adrsgeg_Opmerking);
                            sqlCmd.ExecuteNonQuery();
                        }
                    }   
                    catch (Exception) { }

                    dbcDa.Close();
                }
            }

            public void deleteRecord(int iAgId)
            {
                string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
                using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
                {
                    dbcDa.Open();
                    try
                    {
                        string sqlStr = "Delete from Adresgegevens Where Adrsgeg_Id=@1;";
                        using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                        {
                            sqlCmd.Parameters.AddWithValue("@1", iAgId);
                            sqlCmd.ExecuteNonQuery();
                        }
                    }
                    catch (SystemException ex)
                    {
                        System.Windows.Forms.MessageBox.Show(string.Format("Fout bij verwijderen van adresgegevens: {0}", ex.Message));
                    }
                }
            }




    }

}

