using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using globalVars;
using ProcFunc;
using System.Windows.Forms;
using Error;

namespace nsTblJs
{
    public class tblJs
    {
        public struct jsRecord
        {
            public int Jsal_Id { get; set; }
            public int Jsal_StatusId { get; set; }
            public string Jsal_DispStatus { get; set; }
            public int Jsal_JgegId { get; set; }
            public int Jsal_BgnrId { get; set; }
            public decimal Jsal_Beginsaldo { get; set; }
            public decimal Jsal_Eindsaldo { get; set; }
            public DateTime Jsal_Mutatiedatum { get; set; }
            public string Jsal_Opmerking { get; set; }
        }

        public List<jsRecord> lstJaarSaldoRecord = new List<jsRecord>();
        public int jsListCount;
        public int jsListTCount;

        public void zoekJaarSaldoRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Jaarsaldotabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Jaarsaldo Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Saldostand;";
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

        public int telJaarSaldoRecord(string sZoekarg)
        {
            //pf pf = new pf();
            //pf.melding("Records zoeken", "","Jaardaldo-records doorzoeken. \n Ogenblik geduld a.u.b. ", "", "", "", false, 0);
            //MessageBox.Show("Jaarsaldo doorzoeken \n Ogenblik geduld a.u.b.", "Records zoeken");
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Saldostandtabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Jaarsaldo Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Jaarsaldo;";
                }
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    using (SQLiteDataReader sqlRdr = sqlCmd.ExecuteReader())
                    {
                        jsListCount = 0;
                        jsListTCount = 0;
                        while (sqlRdr.Read())
                        {
                            //get rows
                            jsListTCount++;
                            if (sqlRdr.GetInt32(sqlRdr.GetOrdinal("Jsal_StatusId")) != 181009)
                            {
                                jsListCount++;
                            }
                        }
                    }
                }
                dbcDa.Close();
                //pf.melding("","","","","","",false,0);
                return jsListCount;
            }
        }


        private void recordsInList(SQLiteDataReader r)
        {
            jsRecord jsr = new jsRecord();

            lstJaarSaldoRecord.Clear();

            while (r.Read())
            {
                //Maak list van geselecteerde rijen

                jsr.Jsal_Id = r.GetInt32(r.GetOrdinal("Jsal_Id"));
                jsr.Jsal_StatusId = r.GetInt32(r.GetOrdinal("Jsql_StatusId"));
                jsr.Jsal_DispStatus = r.GetString(r.GetOrdinal("Jsal_DispStatus"));
                jsr.Jsal_JgegId = r.GetInt32(r.GetOrdinal("Jsal_JgegId"));
                jsr.Jsal_BgnrId = r.GetInt32(r.GetOrdinal("Jsal_BgnrId"));
                jsr.Jsal_Beginsaldo = r.GetDecimal(r.GetOrdinal("Jsal_Beginsaldo"));
                jsr.Jsal_Eindsaldo = r.GetDecimal(r.GetOrdinal("Jsal_Eindsaldo"));
                jsr.Jsal_Mutatiedatum = r.GetDateTime(r.GetOrdinal("Jsal_Mutatiedatum"));
                jsr.Jsal_Opmerking = "";
                try
                {
                    jsr.Jsal_Opmerking = r.GetString(r.GetOrdinal("Jsal_Opmerking"));
                }
                catch (Exception)
                {
                }
                lstJaarSaldoRecord.Add(jsr);
            }

        }

        public jsRecord vanRecord(int recNr)
        {
            jsRecord jsRec = new jsRecord();
            jsRec.Jsal_Id = lstJaarSaldoRecord[recNr].Jsal_Id;
            jsRec.Jsal_StatusId = lstJaarSaldoRecord[recNr].Jsal_StatusId;
            jsRec.Jsal_DispStatus = lstJaarSaldoRecord[recNr].Jsal_DispStatus;
            jsRec.Jsal_JgegId = lstJaarSaldoRecord[recNr].Jsal_JgegId;
            jsRec.Jsal_BgnrId = lstJaarSaldoRecord[recNr].Jsal_BgnrId;
            jsRec.Jsal_Beginsaldo = lstJaarSaldoRecord[recNr].Jsal_Beginsaldo;
            jsRec.Jsal_Eindsaldo = lstJaarSaldoRecord[recNr].Jsal_Eindsaldo;
            jsRec.Jsal_Mutatiedatum = lstJaarSaldoRecord[recNr].Jsal_Mutatiedatum;
            jsRec.Jsal_Opmerking = lstJaarSaldoRecord[recNr].Jsal_Opmerking;
            return jsRec;
        }

        public jsRecord vulDefaultSs()
        {
            pf pf = new pf();
            jsRecord jsRec = new jsRecord();
            jsRec.Jsal_StatusId = 181009;
            jsRec.Jsal_DispStatus = "Jaarsaldo-record is leeg / Tabelinitrecord";
            jsRec.Jsal_JgegId = 1;
            jsRec.Jsal_BgnrId = 1;
            jsRec.Jsal_Beginsaldo = 0;
            jsRec.Jsal_Eindsaldo = 0;
            jsRec.Jsal_Mutatiedatum = DateTime.Parse("2000-01-01 00:00:00");
            jsRec.Jsal_Opmerking = "";
            return jsRec;
        }

        public int newjsRecord()
        {
            pf pf = new pf();
            jsRecord djs = new jsRecord();
            djs = vulDefaultSs();
            int newjsId = new int();
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                string findstring = pf.randomString(6);
                string sqlStr = "Insert Into Jaarsaldo (Jsal_StatusId, Jsal_DispStatus, Jsal_JgegId, " +
                                "Jsal_BgnrId, Jsal_Begindatum, Jsal_Einddatum, Jsal_Mutatiedatum, Jsal_Opmerking) Values " +
                                "(@2, @3, @4, @5, @6, @7, @8, @9)";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    SQLiteParameter p2 = new SQLiteParameter(); p2.ParameterName = "@2"; p2.Value = 181009; sqlCmd.Parameters.Add(p2);
                    SQLiteParameter p3 = new SQLiteParameter(); p3.ParameterName = "@3"; p3.Value = "Jaarsaldo-record is leeg / Tabelinitrecord"; sqlCmd.Parameters.Add(p3);
                    SQLiteParameter p4 = new SQLiteParameter(); p4.ParameterName = "@4"; p4.Value = 1; sqlCmd.Parameters.Add(p4);
                    SQLiteParameter p5 = new SQLiteParameter(); p5.ParameterName = "@5"; p5.Value = 1; sqlCmd.Parameters.Add(p5);
                    SQLiteParameter p6 = new SQLiteParameter(); p6.ParameterName = "@6"; p6.Value = 0;
                    SQLiteParameter p7 = new SQLiteParameter(); p7.ParameterName = "@7"; p7.Value = 0;
                    SQLiteParameter p8 = new SQLiteParameter(); p8.ParameterName = "@8"; p8.Value = DateTime.Parse("2000-01-01 00:00:00"); sqlCmd.Parameters.Add(p8);
                    SQLiteParameter p9 = new SQLiteParameter(); p9.ParameterName = "@9"; p9.Value = findstring; sqlCmd.Parameters.Add(p9);
                    sqlCmd.ExecuteNonQuery();
                    dbcDa.Close();
                }

                // Zoek toegevoegde record
                tblJs js = new tblJs();
                js.zoekJaarSaldoRecord("Jsal_Opmerking = " + "\"" + findstring + "\"");
                newjsId = js.lstJaarSaldoRecord[0].Jsal_Id;

                // Verwijder infor uit Opmerking-veld
                dbcDa.Open();
                sqlStr = "Update Jaarsaldo set Jsal_Opmerking=@8 where Jsal_Id = @1;";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    sqlCmd.Parameters.AddWithValue("@1", newjsId);
                    sqlCmd.Parameters.AddWithValue("@8", "");
                    sqlCmd.ExecuteNonQuery();
                }
                dbcDa.Close();


                return newjsId;
            }
        }

        public void saveRecord(int ijsId, jsRecord jsR)
        {
            string sqlStr = "Update Jaarsaldo set Jsal_StatusId=@2, Jsal_DispStatus=@3, Jsal_JgegIdg=@4, Jsal_BgnrId=@5, " +
                            "Jsal_Beginsaldo=@6, Jsal_Eindsaldo=@7, Jsal_Mutatiedatum=@8, Jsal_Opmerking=@9 Where Jsal_Id=@1";

            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", ijsId);
                        sqlCmd.Parameters.AddWithValue("@2", jsR.Jsal_StatusId);
                        sqlCmd.Parameters.AddWithValue("@3", jsR.Jsal_DispStatus);
                        sqlCmd.Parameters.AddWithValue("@4", jsR.Jsal_JgegId);
                        sqlCmd.Parameters.AddWithValue("@5", jsR.Jsal_BgnrId);
                        sqlCmd.Parameters.AddWithValue("@6", jsR.Jsal_Beginsaldo);
                        sqlCmd.Parameters.AddWithValue("@7", jsR.Jsal_Eindsaldo);
                        sqlCmd.Parameters.AddWithValue("@8", jsR.Jsal_Mutatiedatum);
                        sqlCmd.Parameters.AddWithValue("@9", jsR.Jsal_Opmerking);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception) { }

                dbcDa.Close();
            }
        }

        public void deleteRecord(int ijsId)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    string sqlStr = "Delete from Jaarsaldo Where Jsal_Id=@1;";
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", ijsId);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (SystemException ex)
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("Fout bij verwijderen van jaarsaldo: {0}", ex.Message));
                }
            }
        }
    }
}

