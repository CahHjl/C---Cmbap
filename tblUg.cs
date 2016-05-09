using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using globalVars;
using ProcFunc;

namespace nsTblUg
{
    class tblUg
    {
        public struct ugRecord
        {
            public int Ugv_Id { get; set; }
            public int Ugv_StatusId { get; set; }
            public string Ugv_DispStatus { get; set; }
            public int Ugv_KlBgId { get; set; }
            public string Ugv_DispKlBg { get; set; }
            public int Ugv_HusId { get; set; }
            public string Ugv_DispHus { get; set; }
            public int Ugv_SusId { get; set; }
            public string Ugv_DispSus { get; set; }
            public DateTime Ugv_Datum { get; set; }
            public string Ugv_Kasbewijsnr { get; set; }
            public decimal Ugv_Bedrag { get; set; }
            public DateTime Ugv_Mutatiedatum { get; set; }
            public string Ugv_Opmerking { get; set; }
        }

        public List<ugRecord> lstUitgavenRecord = new List<ugRecord>();
        public int ugListCount;
        public int ugListTCount;

        public void zoekUitgavenRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Uitgaventabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Uitgaven Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Uitgaven;";
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

        public int telUitgavenRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Uitgaventablel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Uitgaven Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Uitgaven";
                }
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    using (SQLiteDataReader sqlRdr = sqlCmd.ExecuteReader())
                    {
                        ugListCount = 0;
                        ugListTCount = 0;
                        while (sqlRdr.Read())
                        {
                            //get rows
                            ugListTCount++;
                            if (sqlRdr.GetInt32(sqlRdr.GetOrdinal("Ugv_StatusId")) != 140009)
                            {
                                ugListCount++;
                            }
                        }
                    }
                }
                dbcDa.Close();
                return ugListCount;
            }
        }

        private void recordsInList(SQLiteDataReader r)
        {
            ugRecord ugr = new ugRecord();

            lstUitgavenRecord.Clear();
            ugListCount = 0;
            ugListTCount = 0;

            while (r.Read())
            {
                //Maak list van geselecteerde rijen

                ugListTCount++;
                ugr.Ugv_Id = r.GetInt32(r.GetOrdinal("Ugv_Id"));
                ugr.Ugv_StatusId = r.GetInt32(r.GetOrdinal("Ugv_StatusId"));
                ugr.Ugv_DispStatus = r.GetString(r.GetOrdinal("Ugv_DispStatus"));
                if (r.GetInt32(r.GetOrdinal("Ugv_StatusId")) != 140009)
                {
                    ugListCount++;
                }
                ugr.Ugv_KlBgId = r.GetInt32(r.GetOrdinal("Ugv_KlBgId"));
                ugr.Ugv_DispKlBg = r.GetString(r.GetOrdinal("Ugv_DispKlBg"));
                ugr.Ugv_HusId = r.GetInt32(r.GetOrdinal("Ugv_HusId"));
                ugr.Ugv_DispHus = r.GetString(r.GetOrdinal("Ugv_DispHus"));
                ugr.Ugv_SusId = r.GetInt32(r.GetOrdinal("Ugv_SusId"));
                ugr.Ugv_DispSus = r.GetString(r.GetOrdinal("Ugv_DispSus"));
                ugr.Ugv_Datum = r.GetDateTime(r.GetOrdinal("Ugv_Datum"));
                ugr.Ugv_Kasbewijsnr = r.GetString(r.GetOrdinal("Ugv_Kasbewijsnr"));
                ugr.Ugv_Bedrag = r.GetDecimal(r.GetOrdinal("Ugv_Bedrag"));
                ugr.Ugv_Mutatiedatum = r.GetDateTime(r.GetOrdinal("Ugv_Mutatiedatum"));
                ugr.Ugv_Opmerking = "";
                try
                {
                    ugr.Ugv_Opmerking = r.GetString(r.GetOrdinal("Ugv_Opmerking"));
                }
                catch (Exception)
                {
                }
                lstUitgavenRecord.Add(ugr);
            }

        }

        public ugRecord vanRecord(int recNr)
        {
            ugRecord ugRec = new ugRecord();
            ugRec.Ugv_Id = lstUitgavenRecord[recNr].Ugv_Id;
            ugRec.Ugv_StatusId = lstUitgavenRecord[recNr].Ugv_StatusId;
            ugRec.Ugv_DispStatus = lstUitgavenRecord[recNr].Ugv_DispStatus;
            ugRec.Ugv_KlBgId = lstUitgavenRecord[recNr].Ugv_KlBgId;
            ugRec.Ugv_DispKlBg = lstUitgavenRecord[recNr].Ugv_DispKlBg;
            ugRec.Ugv_HusId = lstUitgavenRecord[recNr].Ugv_HusId;
            ugRec.Ugv_DispHus = lstUitgavenRecord[recNr].Ugv_DispHus;
            ugRec.Ugv_SusId = lstUitgavenRecord[recNr].Ugv_SusId;
            ugRec.Ugv_DispSus = lstUitgavenRecord[recNr].Ugv_DispSus;
            ugRec.Ugv_Datum = lstUitgavenRecord[recNr].Ugv_Datum;
            ugRec.Ugv_Kasbewijsnr = lstUitgavenRecord[recNr].Ugv_Kasbewijsnr;
            ugRec.Ugv_Bedrag = lstUitgavenRecord[recNr].Ugv_Bedrag;
            ugRec.Ugv_Mutatiedatum = lstUitgavenRecord[recNr].Ugv_Mutatiedatum;
            ugRec.Ugv_Opmerking = lstUitgavenRecord[recNr].Ugv_Opmerking;
            return ugRec;
        }

        public ugRecord vulDefaultUg()
        {
            pf pf = new pf();
            ugRecord ugRec = new ugRecord();
            ugRec.Ugv_StatusId = 140009;
            ugRec.Ugv_DispStatus = "Uitgave-record is leeg / Tabel-initrecord";
            ugRec.Ugv_KlBgId = 1;
            ugRec.Ugv_DispKlBg = "Klant-Begunstigde";
            ugRec.Ugv_HusId = 1;
            ugRec.Ugv_DispHus = "";
            ugRec.Ugv_SusId = 1;
            ugRec.Ugv_DispSus = "";
            ugRec.Ugv_Datum = DateTime.Parse("2000-01-01 00:00:00");
            ugRec.Ugv_Kasbewijsnr = "0";
            ugRec.Ugv_Bedrag = 0;
            ugRec.Ugv_Mutatiedatum = DateTime.Parse("2000-01-01 00:00:00");
            ugRec.Ugv_Opmerking = "";
            return ugRec;
        }

        public int newUgRecord()
        {
            pf pf = new pf();
            ugRecord dUg = new ugRecord();
            dUg = vulDefaultUg();
            int newUgId = new int();
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                string findstring = pf.randomString(6);
                string sqlStr = "Insert Into Uitgaven (Ugv_StatusId, Ugv_DispStatus, Ugv_KlBgId, Ugv_DispKlBg, Ugv_HusId, Ugv_DispHus," +
                                "Ugv_SusId, Ugv_DispSus, Ugv_Datum, Ugv_Kasbewijsnr, Ugv_Bedrag, Ugv_Mutatiedatum, Ugv_Opmerking) Values " +
                                "(@2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14)";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    SQLiteParameter p2 = new SQLiteParameter(); p2.ParameterName = "@2"; p2.Value = 140009; sqlCmd.Parameters.Add(p2);
                    SQLiteParameter p3 = new SQLiteParameter(); p3.ParameterName = "@3"; p3.Value = "Uitgave-record is zijn leeg / Tabelinitrecord"; sqlCmd.Parameters.Add(p3);
                    SQLiteParameter p4 = new SQLiteParameter(); p4.ParameterName = "@4"; p4.Value = 1; sqlCmd.Parameters.Add(p4);
                    SQLiteParameter p5 = new SQLiteParameter(); p5.ParameterName = "@5"; p5.Value = "Klant-begunstigde"; sqlCmd.Parameters.Add(p5);
                    SQLiteParameter p6 = new SQLiteParameter(); p6.ParameterName = "@6"; p6.Value = 1; sqlCmd.Parameters.Add(p6);
                    SQLiteParameter p7 = new SQLiteParameter(); p7.ParameterName = "@7"; p7.Value = ""; sqlCmd.Parameters.Add(p7);
                    SQLiteParameter p8 = new SQLiteParameter(); p8.ParameterName = "@8"; p8.Value = 1; sqlCmd.Parameters.Add(p8);
                    SQLiteParameter p9 = new SQLiteParameter(); p9.ParameterName = "@9"; p9.Value = ""; sqlCmd.Parameters.Add(p9);
                    SQLiteParameter p10 = new SQLiteParameter(); p10.ParameterName = "@10"; p10.Value = DateTime.Parse("2000-01-01 00:00:00"); sqlCmd.Parameters.Add(p10);
                    SQLiteParameter p11 = new SQLiteParameter(); p11.ParameterName = "@11"; p11.Value = "0"; sqlCmd.Parameters.Add(p11);
                    SQLiteParameter p12 = new SQLiteParameter(); p12.ParameterName = "@12"; p12.Value = 0; sqlCmd.Parameters.Add(p12);
                    SQLiteParameter p13 = new SQLiteParameter(); p13.ParameterName = "@13"; p13.Value = DateTime.Parse("2000-01-01 00:00:00"); sqlCmd.Parameters.Add(p13);
                    SQLiteParameter p14 = new SQLiteParameter(); p14.ParameterName = "@14"; p14.Value = findstring; sqlCmd.Parameters.Add(p14);
                    sqlCmd.ExecuteNonQuery();
                    dbcDa.Close();
                }

                // Zoek toegevoegde record
                tblUg ug = new tblUg();
                ug.zoekUitgavenRecord("Ugv_Opmerking = " + "\"" + findstring + "\"");
                newUgId = ug.lstUitgavenRecord[0].Ugv_Id;

                // Verwijder infor uit Opmerking-veld
                dbcDa.Open();
                sqlStr = "Update Uitgaven set Ugv_Opmerking=@8 where Ugv_Id = @1;";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    sqlCmd.Parameters.AddWithValue("@1", newUgId);
                    sqlCmd.Parameters.AddWithValue("@8", "");
                    sqlCmd.ExecuteNonQuery();
                }
                dbcDa.Close();


                return newUgId;
            }
        }

        public void saveRecord(int iUgId, ugRecord ugR)
        {
            string sqlStr = "Update Uitgaven (Ugv_StatusId=@2, Ugv_DispStatus=@3, Ugv_KlBgId=@4, Ugv_DispKlBg=@5, Ugv_HusId=@6, Ugv_DispHus=@7," +
                            "Ugv_SusId=@8, Ugv_DispSus=@9, Ugv_Datum=@10, Ugv_Kasbewijsnr=@11, Ugv_Bedrag=@12, Ugv_Mutatiedatum=@13, Ugv_Opmerking=@14 " +
                            "Where Ugv_Id=@1";

            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", iUgId);
                        sqlCmd.Parameters.AddWithValue("@2", ugR.Ugv_StatusId);
                        sqlCmd.Parameters.AddWithValue("@3", ugR.Ugv_DispStatus);
                        sqlCmd.Parameters.AddWithValue("@4", ugR.Ugv_KlBgId);
                        sqlCmd.Parameters.AddWithValue("@5", ugR.Ugv_DispKlBg);
                        sqlCmd.Parameters.AddWithValue("@6", ugR.Ugv_HusId);
                        sqlCmd.Parameters.AddWithValue("@7", ugR.Ugv_DispHus);
                        sqlCmd.Parameters.AddWithValue("@8", ugR.Ugv_SusId);
                        sqlCmd.Parameters.AddWithValue("@9", ugR.Ugv_DispSus);
                        sqlCmd.Parameters.AddWithValue("@10", ugR.Ugv_Datum);
                        sqlCmd.Parameters.AddWithValue("@11", ugR.Ugv_Kasbewijsnr);
                        sqlCmd.Parameters.AddWithValue("@12", ugR.Ugv_Bedrag);
                        sqlCmd.Parameters.AddWithValue("@13", ugR.Ugv_Mutatiedatum);
                        sqlCmd.Parameters.AddWithValue("@14", ugR.Ugv_Opmerking);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception) { }

                dbcDa.Close();
            }
        }

        public void deleteRecord(int iUgId)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    string sqlStr = "Delete from Uitgaven Where Ugv_Id=@1;";
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", iUgId);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (SystemException ex)
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("Fout bij verwijderen van een uitgave: {0}", ex.Message));
                }
            }
        }
    }
}

