using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using globalVars;
using ProcFunc;

namespace nsTblSs
{
    public class tblSs
    {
        public struct ssRecord
        {
            public int Saldostand_Id { get; set; }
            public int Saldostand_StatusId { get; set; }
            public string Saldostand_DispStatus { get; set; }
            public int Saldostand_JgegId { get; set; }
            public int Saldostand_BgnrId { get; set; }
            public DateTime Saldostand_Datum { get; set; }
            public decimal Saldostand_Saldo { get; set; }
            public DateTime Saldostand_Mutatiedatum { get; set; }
            public string Saldostand_Opmerking { get; set; }
        }

        public List<ssRecord> lstSaldoStandRecord = new List<ssRecord>();
        public int ssListCount;
        public int ssListTCount;

        public void zoekSaldoStandRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Saldostandtabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Saldostand Where " + sZoekarg + ";";
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

        public int telSaldoStandRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Saldostandtabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Saldostand Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Saldostand;";
                }
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    using (SQLiteDataReader sqlRdr = sqlCmd.ExecuteReader())
                    {
                        ssListCount = 0;
                        ssListTCount = 0;
                        while (sqlRdr.Read())
                        {
                            //get rows
                            ssListTCount++;
                            if (sqlRdr.GetInt32(sqlRdr.GetOrdinal("Saldostand_StatusId")) != 165009)
                            {
                                ssListCount++;
                            }
                        }
                    }
                }
                dbcDa.Close();
                return ssListCount;
            }
        }


        private void recordsInList(SQLiteDataReader r)
        {
            ssRecord ssr = new ssRecord();

            lstSaldoStandRecord.Clear();

            while (r.Read())
            {
                //Maak list van geselecteerde rijen

                ssr.Saldostand_Id = r.GetInt32(r.GetOrdinal("Saldostand_Id"));
                ssr.Saldostand_StatusId = r.GetInt32(r.GetOrdinal("Saldostand_StatusId"));
                ssr.Saldostand_DispStatus = r.GetString(r.GetOrdinal("Saldostand_DispStatus"));
                ssr.Saldostand_JgegId = r.GetInt32(r.GetOrdinal("Saldostand_JgegId"));
                ssr.Saldostand_BgnrId = r.GetInt32(r.GetOrdinal("Saldostand_BgnrId"));
                ssr.Saldostand_Datum = r.GetDateTime(r.GetOrdinal("Saldostand_Datum"));
                ssr.Saldostand_Saldo = r.GetDecimal(r.GetOrdinal("Saldostand_Saldo"));
                ssr.Saldostand_Mutatiedatum = r.GetDateTime(r.GetOrdinal("Saldostand_Mutatiedatum"));
                ssr.Saldostand_Opmerking = "";
                try
                {
                    ssr.Saldostand_Opmerking = r.GetString(r.GetOrdinal("Saldostand_Opmerking"));
                }
                catch (Exception)
                {
                }
                lstSaldoStandRecord.Add(ssr);
            }

        }

        public ssRecord vanRecord(int recNr)
        {
            ssRecord ssRec = new ssRecord();
            ssRec.Saldostand_Id = lstSaldoStandRecord[recNr].Saldostand_Id;
            ssRec.Saldostand_StatusId = lstSaldoStandRecord[recNr].Saldostand_StatusId;
            ssRec.Saldostand_DispStatus = lstSaldoStandRecord[recNr].Saldostand_DispStatus;
            ssRec.Saldostand_JgegId = lstSaldoStandRecord[recNr].Saldostand_JgegId;
            ssRec.Saldostand_BgnrId = lstSaldoStandRecord[recNr].Saldostand_BgnrId;
            ssRec.Saldostand_Datum = lstSaldoStandRecord[recNr].Saldostand_Datum;
            ssRec.Saldostand_Saldo = lstSaldoStandRecord[recNr].Saldostand_Saldo;
            ssRec.Saldostand_Mutatiedatum = lstSaldoStandRecord[recNr].Saldostand_Mutatiedatum;
            ssRec.Saldostand_Opmerking = lstSaldoStandRecord[recNr].Saldostand_Opmerking;
            return ssRec;
        }

        public ssRecord vulDefaultSs()
        {
            pf pf = new pf();
            ssRecord ssRec = new ssRecord();
            ssRec.Saldostand_StatusId = 165009;
            ssRec.Saldostand_DispStatus = "Saldostand-record is leeg / Tabelinitrecord";
            ssRec.Saldostand_JgegId = 1;
            ssRec.Saldostand_BgnrId = 1;
            ssRec.Saldostand_Datum = DateTime.Parse("2000-01-01 00:00:00");
            ssRec.Saldostand_Saldo = 0;
            ssRec.Saldostand_Mutatiedatum = DateTime.Parse("2000-01-01 00:00:00");
            ssRec.Saldostand_Opmerking = "";
            return ssRec;
        }

        public int newssRecord()
        {
            pf pf = new pf();
            ssRecord dss = new ssRecord();
            dss = vulDefaultSs();
            int newssId = new int();
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                string findstring = pf.randomString(6);
                string sqlStr = "Insert Into Saldostand (Saldostand_StatusId, Saldostand_DispStatus, Saldostand_JgegId, " +
                                "Saldostand_BgnrId, Saldostand_Datum, Saldostand_Saldo, Saldostand_Mutatiedatum, Saldostand_Opmerking) Values " +
                                "(@2, @3, @4, @5, @6, @7, @8, @9)";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    SQLiteParameter p2 = new SQLiteParameter(); p2.ParameterName = "@2"; p2.Value = 165009; sqlCmd.Parameters.Add(p2);
                    SQLiteParameter p3 = new SQLiteParameter(); p3.ParameterName = "@3"; p3.Value = "Saldostand-record is leeg / Tabelinitrecord"; sqlCmd.Parameters.Add(p3);
                    SQLiteParameter p4 = new SQLiteParameter(); p4.ParameterName = "@4"; p4.Value = 1; sqlCmd.Parameters.Add(p4);
                    SQLiteParameter p5 = new SQLiteParameter(); p5.ParameterName = "@5"; p5.Value = 1;sqlCmd.Parameters.Add(p5);
                    SQLiteParameter p6 = new SQLiteParameter(); p6.ParameterName = "@6"; p6.Value = DateTime.Parse("2000-01-01 00:00:00"); sqlCmd.Parameters.Add(p6);
                    SQLiteParameter p7 = new SQLiteParameter(); p7.ParameterName = "@7"; p7.Value = 0; sqlCmd.Parameters.Add(p7);
                    SQLiteParameter p8 = new SQLiteParameter(); p8.ParameterName = "@8"; p8.Value = DateTime.Parse("2000-01-01 00:00:00"); sqlCmd.Parameters.Add(p8);
                    SQLiteParameter p9 = new SQLiteParameter(); p9.ParameterName = "@9"; p9.Value = findstring; sqlCmd.Parameters.Add(p9);
                    sqlCmd.ExecuteNonQuery();
                    dbcDa.Close();
                }

                // Zoek toegevoegde record
                tblSs ss = new tblSs();
                ss.zoekSaldoStandRecord("Saldostand_Opmerking = " + "\"" + findstring + "\"");
                newssId = ss.lstSaldoStandRecord[0].Saldostand_Id;

                // Verwijder infor uit Opmerking-veld
                dbcDa.Open();
                sqlStr = "Update Saldostand set Saldostand_Opmerking=@8 where Saldostand_Id = @1;";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    sqlCmd.Parameters.AddWithValue("@1", newssId);
                    sqlCmd.Parameters.AddWithValue("@8", "");
                    sqlCmd.ExecuteNonQuery();
                }
                dbcDa.Close();


                return newssId;
            }
        }

        public void saveRecord(int issId, ssRecord ssR)
        {
            string sqlStr = "Update Saldostand set Saldostand_StatusId=@2, Saldostand_DispStatus=@3, Saldostand_JgegIdg=@4, Saldostand_BgnrId=@5, " +
                            "Saldostand_Datum=@6, SaldosStand_Saldo=@7, Saldostand_Mutatiedatum=@8, Saldostand_Opmerking=@9 Where Saldostand_Id=@1";

            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", issId);
                        sqlCmd.Parameters.AddWithValue("@2", ssR.Saldostand_StatusId);
                        sqlCmd.Parameters.AddWithValue("@3", ssR.Saldostand_DispStatus);
                        sqlCmd.Parameters.AddWithValue("@4", ssR.Saldostand_JgegId);
                        sqlCmd.Parameters.AddWithValue("@5", ssR.Saldostand_BgnrId);
                        sqlCmd.Parameters.AddWithValue("@6", ssR.Saldostand_Datum);
                        sqlCmd.Parameters.AddWithValue("@7", ssR.Saldostand_Saldo);
                        sqlCmd.Parameters.AddWithValue("@8", ssR.Saldostand_Mutatiedatum);
                        sqlCmd.Parameters.AddWithValue("@9", ssR.Saldostand_Opmerking);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception) { }

                dbcDa.Close();
            }
        }

        public void deleteRecord(int issId)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    string sqlStr = "Delete from Saldostand Where Saldostand_Id=@1;";
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", issId);
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
