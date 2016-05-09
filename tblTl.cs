using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using globalVars;
using ProcFunc;

namespace nsTblTl
{
    public class tblTl
    {
        public struct tlRecord
        {
            public int Tlf_Id { get; set; }
            public int Tlf_StatusId { get; set; }
            public string Tlf_DispStatus { get; set; }
            public int Tlf_KlBgId { get; set; }
            public string Tlf_DispKlBg { get; set; }
            public string Tlf_Telefoonnr { get; set; }
            public DateTime Tlf_Mutatiedatum { get; set; }
            public string Tlf_Opmerking { get; set; }
        }

        public List<tlRecord> lstTelefoonnrRecord = new List<tlRecord>();
        public int tlListCount;
        public int tlListTCount;

        public void zoekTelefoonnrRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Telefoontabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Telefoonnr Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Telefoonnr;";
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

        public int telTelefoonnrRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Telefoonnrtabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Telefoonnr Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Telefoonnr;";
                }
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    using (SQLiteDataReader sqlRdr = sqlCmd.ExecuteReader())
                    {
                        tlListCount = 0;
                        tlListTCount = 0;
                        while (sqlRdr.Read())
                        {
                            //get rows
                            tlListTCount++;
                            if (sqlRdr.GetInt32(sqlRdr.GetOrdinal("Tlf_StatusId")) != 105009)
                            {
                                tlListCount++;
                            }
                        }
                    }
                }
                dbcDa.Close();
                return tlListCount;
            }
        }

        private void recordsInList(SQLiteDataReader r)
        {
            tlRecord tlr = new tlRecord();

            lstTelefoonnrRecord.Clear();
            tlListCount = 0;
            tlListTCount = 0;

            while (r.Read())
            {
                //Maak list van geselecteerde rijen

                tlListTCount++;
                tlr.Tlf_Id = r.GetInt32(r.GetOrdinal("Tlf_Id"));
                tlr.Tlf_StatusId = r.GetInt32(r.GetOrdinal("Tlf_StatusId"));
                tlr.Tlf_DispStatus = r.GetString(r.GetOrdinal("Tlf_DispStatus"));
                if (r.GetInt32(r.GetOrdinal("Tlf_StatusId")) != 105009)
                {
                    tlListCount++;
                }
                tlr.Tlf_KlBgId = r.GetInt32(r.GetOrdinal("Tlf_KlBgId"));
                tlr.Tlf_DispKlBg = r.GetString(r.GetOrdinal("Tlf_DispKlBg"));
                tlr.Tlf_Telefoonnr = r.GetString(r.GetOrdinal("Tlf_Telefoonnr"));
                tlr.Tlf_Mutatiedatum = r.GetDateTime(r.GetOrdinal("Tlf_Mutatiedatum"));
                tlr.Tlf_Opmerking = "";
                try
                {
                    tlr.Tlf_Opmerking = r.GetString(r.GetOrdinal("Tlf_Opmerking"));
                }
                catch (Exception)
                {
                }
                lstTelefoonnrRecord.Add(tlr);
            }

        }

        public tlRecord vanRecord(int recNr)
        {
            tlRecord tlRec = new tlRecord();
            tlRec.Tlf_Id = lstTelefoonnrRecord[recNr].Tlf_Id;
            tlRec.Tlf_StatusId = lstTelefoonnrRecord[recNr].Tlf_StatusId;
            tlRec.Tlf_DispStatus = lstTelefoonnrRecord[recNr].Tlf_DispStatus;
            tlRec.Tlf_KlBgId = lstTelefoonnrRecord[recNr].Tlf_KlBgId;
            tlRec.Tlf_DispKlBg = lstTelefoonnrRecord[recNr].Tlf_DispKlBg;
            tlRec.Tlf_Telefoonnr = lstTelefoonnrRecord[recNr].Tlf_Telefoonnr;
            tlRec.Tlf_Mutatiedatum = lstTelefoonnrRecord[recNr].Tlf_Mutatiedatum;
            tlRec.Tlf_Opmerking = lstTelefoonnrRecord[recNr].Tlf_Opmerking;
            return tlRec;
        }

        public tlRecord vulDefaultTl()
        {
            pf pf = new pf();
            tlRecord tlRec = new tlRecord();
            tlRec.Tlf_StatusId = 105009;
            tlRec.Tlf_DispStatus = "Telefoonnummergegevens zijn leeg / Tabelinitrecord";
            tlRec.Tlf_KlBgId = 1;
            tlRec.Tlf_DispKlBg = "Klant-Begunstigde";
            tlRec.Tlf_Telefoonnr = "000-000000";
            tlRec.Tlf_Mutatiedatum = DateTime.Parse("2000-01-01 00:00:00");
            tlRec.Tlf_Opmerking = "";
            return tlRec;
        }

        public int newTlRecord()
        {
            pf pf = new pf();
            tlRecord dTl = new tlRecord();
            dTl = vulDefaultTl();
            int newTlId = new int();
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                string findstring = pf.randomString(6);
                string sqlStr = "Insert Into Telefoonnr (Tlf_StatusId, Tlf_DispStatus, Tlf_KlBgId, Tlf_DispKlBg, " +
                                "Tlf_Telefoonnr, Tlf_Mutatiedatum, Tlf_Opmerking) Values (@2, @3, @4, @5, @6, @7, @8)";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    SQLiteParameter p2 = new SQLiteParameter(); p2.ParameterName = "@2"; p2.Value = 105009; sqlCmd.Parameters.Add(p2);
                    SQLiteParameter p3 = new SQLiteParameter(); p3.ParameterName = "@3"; p3.Value = "Telefoonnummergegevens zijn leeg / Tabelinitrecord"; sqlCmd.Parameters.Add(p3);
                    SQLiteParameter p4 = new SQLiteParameter(); p4.ParameterName = "@4"; p4.Value = 1; sqlCmd.Parameters.Add(p4);
                    SQLiteParameter p5 = new SQLiteParameter(); p5.ParameterName = "@5"; p5.Value = "Klant-Begunstigde"; sqlCmd.Parameters.Add(p5);
                    SQLiteParameter p6 = new SQLiteParameter(); p6.ParameterName = "@6"; p6.Value = "000-000000"; sqlCmd.Parameters.Add(p6);
                    SQLiteParameter p7 = new SQLiteParameter(); p7.ParameterName = "@7"; p7.Value = DateTime.Parse("2000-01-01 00:00:00"); sqlCmd.Parameters.Add(p7);
                    SQLiteParameter p8 = new SQLiteParameter(); p8.ParameterName = "@8"; p8.Value = findstring; sqlCmd.Parameters.Add(p8);
                    sqlCmd.ExecuteNonQuery();
                    dbcDa.Close();
                }

                // Zoek toegevoegde record
                tblTl tl = new tblTl();
                tl.zoekTelefoonnrRecord("Tlf_Opmerking = " + "\"" + findstring + "\"");
                newTlId = tl.lstTelefoonnrRecord[0].Tlf_Id;

                // Verwijder infor uit Opmerking-veld
                dbcDa.Open();
                sqlStr = "Update Telefoonnr set Tlf_Opmerking=@8 where Tlf_Id = @1;";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    sqlCmd.Parameters.AddWithValue("@1", newTlId);
                    sqlCmd.Parameters.AddWithValue("@8", "");
                    sqlCmd.ExecuteNonQuery();
                }
                dbcDa.Close();


                return newTlId;
            }
        }

        public void saveRecord(int iTlId, tlRecord tlR)
        {
            string sqlStr = "Update Telefoonnr set Tlf_StatusId=@2, Tlf_DispStatus=@3, Tlf_KlBgId=@4, Tlf_DispKlBg=@5, " +
                            "Tlf_Telefoonnr=@6, Tlf_Mutatiedatum=@7, Tlf_Opmerking=@8 Where Tlf_Id=@1;";


            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", iTlId);
                        sqlCmd.Parameters.AddWithValue("@2", tlR.Tlf_StatusId);
                        sqlCmd.Parameters.AddWithValue("@3", tlR.Tlf_DispStatus);
                        sqlCmd.Parameters.AddWithValue("@4", tlR.Tlf_KlBgId);
                        sqlCmd.Parameters.AddWithValue("@5", tlR.Tlf_DispKlBg);
                        sqlCmd.Parameters.AddWithValue("@6", tlR.Tlf_Telefoonnr);
                        sqlCmd.Parameters.AddWithValue("@7", tlR.Tlf_Mutatiedatum);
                        sqlCmd.Parameters.AddWithValue("@8", tlR.Tlf_Opmerking);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception) { }

                dbcDa.Close();
            }
        }

        public void deleteRecord(int iTlId)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    string sqlStr = "Delete from Telefoonnr Where Tlf_Id=@1;";
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", iTlId);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (SystemException ex)
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("Fout bij verwijderen van telefoongegevens: {0}", ex.Message));
                }
            }
        }
    }
}
