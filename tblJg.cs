using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using globalVars;
using ProcFunc;


namespace nsTblJg
{
    public class tblJg
    {
        public struct jgRecord
        {
            public int Jgeg_Id { get; set; }
            public int Jgeg_StatusId { get; set; }
            public string Jgeg_DispStatus { get; set; }
            public string Jgeg_Omschrijving { get; set; }
            public DateTime Jgeg_Begindatum { get; set; }
            public DateTime Jgeg_Einddatum { get; set; }
            public DateTime Jgeg_Mutatiedatum { get; set; }
            public string Jgeg_Opmerking { get; set; }
        }

        public List<jgRecord> lstJaarGegevensRecord = new List<jgRecord>();
        public int jgListCount;

        public void zoekJaarGegevensRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Jaargegevenstabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Jaargegevens Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Jaargegevens;";
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

        public int telJaarGegevensRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Jaargegevenstabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Jaargegevens Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Jaargegevens;";
                }
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    using (SQLiteDataReader sqlRdr = sqlCmd.ExecuteReader())
                    {
                        jgListCount = 0;
                        while (sqlRdr.Read())
                        {
                            //get rows
                            jgListCount++;
                        }
                    }
                }
                dbcDa.Close();
                return jgListCount;
            }
        }


        private void recordsInList(SQLiteDataReader r)
        {
            jgRecord jgr = new jgRecord();

            lstJaarGegevensRecord.Clear();

            while (r.Read())
            {
                //Maak list van geselecteerde rijen

                jgr.Jgeg_Id = r.GetInt32(r.GetOrdinal("Jgeg_Id"));
                jgr.Jgeg_StatusId = r.GetInt32(r.GetOrdinal("Jgeg_StatusId"));
                jgr.Jgeg_DispStatus = r.GetString(r.GetOrdinal("Jgeg_DispStatus"));
                jgr.Jgeg_Omschrijving = r.GetString(r.GetOrdinal("Jgeg_Omschrijving"));
                jgr.Jgeg_Begindatum = r.GetDateTime(r.GetOrdinal("Jgeg_Begindatum"));
                jgr.Jgeg_Einddatum = r.GetDateTime(r.GetOrdinal("Jgeg_Einddatum"));
                jgr.Jgeg_Mutatiedatum = r.GetDateTime(r.GetOrdinal("Jgeg_Mutatiedatum"));
                jgr.Jgeg_Opmerking = "";
                try
                {
                    jgr.Jgeg_Opmerking = r.GetString(r.GetOrdinal("Jgeg_Opmerking"));
                }
                catch (Exception)
                {
                }
                lstJaarGegevensRecord.Add(jgr);
            }

        }

        public jgRecord vanRecord(int recNr)
        {
            jgRecord jgRec = new jgRecord();
            jgRec.Jgeg_Id = lstJaarGegevensRecord[recNr].Jgeg_Id;
            jgRec.Jgeg_StatusId = lstJaarGegevensRecord[recNr].Jgeg_StatusId;
            jgRec.Jgeg_DispStatus = lstJaarGegevensRecord[recNr].Jgeg_DispStatus;
            jgRec.Jgeg_Omschrijving = lstJaarGegevensRecord[recNr].Jgeg_Omschrijving;
            jgRec.Jgeg_Begindatum = lstJaarGegevensRecord[recNr].Jgeg_Begindatum;
            jgRec.Jgeg_Einddatum = lstJaarGegevensRecord[recNr].Jgeg_Einddatum;
            jgRec.Jgeg_Mutatiedatum = lstJaarGegevensRecord[recNr].Jgeg_Mutatiedatum;
            jgRec.Jgeg_Opmerking = lstJaarGegevensRecord[recNr].Jgeg_Opmerking;
            return jgRec;
        }

        public jgRecord vulDefaultPd()
        {
            pf pf = new pf();
            jgRecord jgRec = new jgRecord();
            jgRec.Jgeg_StatusId = 180009;
            jgRec.Jgeg_DispStatus = "Jaargegevens-record is leeg / Tabelinitrecord";
            jgRec.Jgeg_Omschrijving = "2000";
            jgRec.Jgeg_Begindatum = DateTime.Parse("2000-01-01 00:00:00");
            jgRec.Jgeg_Einddatum = DateTime.Parse("2000-12-31 00:00:00");
            jgRec.Jgeg_Mutatiedatum = DateTime.Parse("2000-01-01 00:00:00");
            jgRec.Jgeg_Opmerking = pf.randomString(6);
            return jgRec;
        }

        public int newJgRecord()
        {
            pf pf = new pf();
            jgRecord dJg = new jgRecord();
            dJg = vulDefaultPd();
            int newJgId = new int();
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                string findstring = pf.randomString(6);
                string sqlStr = "Insert Into Jaargegevens (Jgeg_StatusId, Jgeg_DispStatus, Jgeg_Omschrijving, " +
                                "Jgeg_Begindatum, Jgeg_Einddatum, Jgeg_Mutatiedatum, Jgeg_Opmerking) Values " +
                                "(@2, @3, @4, @5, @6, @7, @8)";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    SQLiteParameter p2 = new SQLiteParameter(); p2.ParameterName = "@2"; p2.Value = 180009; sqlCmd.Parameters.Add(p2);
                    SQLiteParameter p3 = new SQLiteParameter(); p3.ParameterName = "@3"; p3.Value = "Jaargegevens-record is leeg / Tabelinitrecord"; sqlCmd.Parameters.Add(p3);
                    SQLiteParameter p4 = new SQLiteParameter(); p4.ParameterName = "@4"; p4.Value = "2000"; sqlCmd.Parameters.Add(p4);
                    SQLiteParameter p5 = new SQLiteParameter(); p5.ParameterName = "@5"; p5.Value = DateTime.Parse("2000-01-01 00:00:00"); sqlCmd.Parameters.Add(p5);
                    SQLiteParameter p6 = new SQLiteParameter(); p6.ParameterName = "@6"; p6.Value = DateTime.Parse("2000-12-31 00:00:00"); sqlCmd.Parameters.Add(p6);
                    SQLiteParameter p7 = new SQLiteParameter(); p7.ParameterName = "@7"; p7.Value = DateTime.Parse("2000-01-01 00:00:00"); sqlCmd.Parameters.Add(p7);
                    SQLiteParameter p8 = new SQLiteParameter(); p8.ParameterName = "@8"; p8.Value = findstring; sqlCmd.Parameters.Add(p8);
                    sqlCmd.ExecuteNonQuery();
                    dbcDa.Close();
                }

                // Zoek toegevoegde record
                tblJg jg = new tblJg();
                jg.zoekJaarGegevensRecord("Jgeg_Opmerking = " + "\"" + findstring + "\"");
                newJgId = jg.lstJaarGegevensRecord[0].Jgeg_Id;

                // Verwijder infor uit Opmerking-veld
                dbcDa.Open();
                sqlStr = "Update Jaargegevens set Jgeg_Opmerking=@8 where Jgeg_Id = @1;";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    sqlCmd.Parameters.AddWithValue("@1", newJgId);
                    sqlCmd.Parameters.AddWithValue("@8", "");
                    sqlCmd.ExecuteNonQuery();
                }
                dbcDa.Close();


                return newJgId;
            }
        }

        public void saveRecord(int iJgId, jgRecord jgR)
        {
            string sqlStr = "Update Jaargegevens set Jgeg_StatusId=@2, Jgeg_DispStatus=@3, Jgeg_Omschrijving=@4, Jgeg_Beindatum=@5, " +
                            "Jgeg_Einddatum=@6, Jgeg_Mutatiedatum=@7, Jgeg_Opmerking=@18 Where Jgeg_Id=@1";

            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", iJgId);
                        sqlCmd.Parameters.AddWithValue("@2", jgR.Jgeg_StatusId);
                        sqlCmd.Parameters.AddWithValue("@3", jgR.Jgeg_DispStatus);
                        sqlCmd.Parameters.AddWithValue("@4", jgR.Jgeg_Omschrijving);
                        sqlCmd.Parameters.AddWithValue("@5", jgR.Jgeg_Begindatum);
                        sqlCmd.Parameters.AddWithValue("@6", jgR.Jgeg_Einddatum);
                        sqlCmd.Parameters.AddWithValue("@15", jgR.Jgeg_Mutatiedatum);
                        sqlCmd.Parameters.AddWithValue("@16", jgR.Jgeg_Opmerking);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception) { }

                dbcDa.Close();
            }
        }

        public void deleteRecord(int iJgId)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    string sqlStr = "Delete from Jaargegevens Where Jgeg_Id=@1;";
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", iJgId);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (SystemException ex)
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
                }
            }
        }
    }
}
