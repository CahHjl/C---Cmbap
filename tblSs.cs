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
            public string Saldostand_Omschrijving { get; set; }
            public DateTime Saldostand_Begindatum { get; set; }
            public DateTime Saldostand_Einddatum { get; set; }
            public DateTime Saldostand_Mutatiedatum { get; set; }
            public string Saldostand_Opmerking { get; set; }
        }

        public List<ssRecord> lstJaarGegevensRecord = new List<ssRecord>();
        public int ssListCount;

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
                        ssListCount = 0;
                        while (sqlRdr.Read())
                        {
                            //get rows
                            ssListCount++;
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

            lstJaarGegevensRecord.Clear();

            while (r.Read())
            {
                //Maak list van geselecteerde rijen

                ssr.Saldostand_Id = r.GetInt32(r.GetOrdinal("Saldostand_Id"));
                ssr.Saldostand_StatusId = r.GetInt32(r.GetOrdinal("Saldostand_StatusId"));
                ssr.Saldostand_DispStatus = r.GetString(r.GetOrdinal("Saldostand_DispStatus"));
                ssr.Saldostand_Omschrijving = r.GetString(r.GetOrdinal("Saldostand_Omschrijving"));
                ssr.Saldostand_Begindatum = r.GetDateTime(r.GetOrdinal("Saldostand_Begindatum"));
                ssr.Saldostand_Einddatum = r.GetDateTime(r.GetOrdinal("Saldostand_Einddatum"));
                ssr.Saldostand_Mutatiedatum = r.GetDateTime(r.GetOrdinal("Saldostand_Mutatiedatum"));
                ssr.Saldostand_Opmerking = "";
                try
                {
                    ssr.Saldostand_Opmerking = r.GetString(r.GetOrdinal("Saldostand_Opmerking"));
                }
                catch (Exception)
                {
                }
                lstJaarGegevensRecord.Add(ssr);
            }

        }

        public ssRecord vanRecord(int recNr)
        {
            ssRecord ssRec = new ssRecord();
            ssRec.Saldostand_Id = lstJaarGegevensRecord[recNr].Saldostand_Id;
            ssRec.Saldostand_StatusId = lstJaarGegevensRecord[recNr].Saldostand_StatusId;
            ssRec.Saldostand_DispStatus = lstJaarGegevensRecord[recNr].Saldostand_DispStatus;
            ssRec.Saldostand_Omschrijving = lstJaarGegevensRecord[recNr].Saldostand_Omschrijving;
            ssRec.Saldostand_Begindatum = lstJaarGegevensRecord[recNr].Saldostand_Begindatum;
            ssRec.Saldostand_Einddatum = lstJaarGegevensRecord[recNr].Saldostand_Einddatum;
            ssRec.Saldostand_Mutatiedatum = lstJaarGegevensRecord[recNr].Saldostand_Mutatiedatum;
            ssRec.Saldostand_Opmerking = lstJaarGegevensRecord[recNr].Saldostand_Opmerking;
            return ssRec;
        }

        public ssRecord vulDefaultPd()
        {
            pf pf = new pf();
            ssRecord ssRec = new ssRecord();
            ssRec.Saldostand_StatusId = 180009;
            ssRec.Saldostand_DispStatus = "Jaargegevens-record is leeg / Tabelinitrecord";
            ssRec.Saldostand_Omschrijving = "2000";
            ssRec.Saldostand_Begindatum = DateTime.Parse("2000-01-01 00:00:00");
            ssRec.Saldostand_Einddatum = DateTime.Parse("2000-12-31 00:00:00");
            ssRec.Saldostand_Mutatiedatum = DateTime.Parse("2000-01-01 00:00:00");
            ssRec.Saldostand_Opmerking = pf.randomString(6);
            return ssRec;
        }

        public int newssRecord()
        {
            pf pf = new pf();
            ssRecord dss = new ssRecord();
            dss = vulDefaultPd();
            int newssId = new int();
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                string findstring = pf.randomString(6);
                string sqlStr = "Insert Into Jaargegevens (Saldostand_StatusId, Saldostand_DispStatus, Saldostand_Omschrijving, " +
                                "Saldostand_Begindatum, Saldostand_Einddatum, Saldostand_Mutatiedatum, Saldostand_Opmerking) Values " +
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
                tblSs ss = new tblSs();
                ss.zoekJaarGegevensRecord("Saldostand_Opmerking = " + "\"" + findstring + "\"");
                newssId = ss.lstJaarGegevensRecord[0].Saldostand_Id;

                // Verwijder infor uit Opmerking-veld
                dbcDa.Open();
                sqlStr = "Update Jaargegevens set Saldostand_Opmerking=@8 where Saldostand_Id = @1;";
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
            string sqlStr = "Update Jaargegevens set Saldostand_StatusId=@2, Saldostand_DispStatus=@3, Saldostand_Omschrijving=@4, Saldostand_Beindatum=@5, " +
                            "Saldostand_Einddatum=@6, Saldostand_Mutatiedatum=@7, Saldostand_Opmerking=@18 Where Saldostand_Id=@1";

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
                        sqlCmd.Parameters.AddWithValue("@4", ssR.Saldostand_Omschrijving);
                        sqlCmd.Parameters.AddWithValue("@5", ssR.Saldostand_Begindatum);
                        sqlCmd.Parameters.AddWithValue("@6", ssR.Saldostand_Einddatum);
                        sqlCmd.Parameters.AddWithValue("@15", ssR.Saldostand_Mutatiedatum);
                        sqlCmd.Parameters.AddWithValue("@16", ssR.Saldostand_Opmerking);
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
                    string sqlStr = "Delete from Jaargegevens Where Saldostand_Id=@1;";
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
