using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using globalVars;
using ProcFunc;

namespace nsTblSu
{
    public class tblSu
    {
        public struct suRecord
        {
            public int Sus_Id { get; set; }
            public int Sus_StatusId { get; set; }
            public string Sus_DispStatus { get; set; }
            public string Sus_Kort { get; set; }
            public string Sus_Lang { get; set; }
            public int Sus_WijzigentoegestaanJN { get; set; }
            public int Sus_HusId { get; set; }
            public string Sus_DispHus { get; set; }
            public DateTime Sus_Mutatiedatum { get; set; }
            public string Sus_Opmerking { get; set; }
        }

        public List<suRecord> lstSubuitgavesoortRecord = new List<suRecord>();
        public int suListCount;
        public int suListTCount;

        public void zoekSubuitgavesoortRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Subuitgavesoortgavetabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Subuitgavesoort Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Subuitgavesoort;";
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

        public int telSubuitgavesoortRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Subuitgavesoorttabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Subuitgavesoort Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Subuitgavesoort;";
                }
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    using (SQLiteDataReader sqlRdr = sqlCmd.ExecuteReader())
                    {
                        suListCount = 0;
                        suListTCount = 0;
                        while (sqlRdr.Read())
                        {
                            //get rows
                            suListTCount++;
                            if (sqlRdr.GetInt32(sqlRdr.GetOrdinal("Sus_StatusId")) != 155009)
                            {
                                suListCount++;
                            }
                        }
                    }
                }
                dbcDa.Close();
                return suListCount;
            }
        }

        private void recordsInList(SQLiteDataReader r)
        {
            suRecord sur = new suRecord();

            lstSubuitgavesoortRecord.Clear();
            suListCount = 0;
            suListTCount = 0;

            while (r.Read())
            {
                //Maak list van geselecteerde rijen

                suListTCount++;
                sur.Sus_Id = r.GetInt32(r.GetOrdinal("Sus_Id"));
                sur.Sus_StatusId = r.GetInt32(r.GetOrdinal("Sus_StatusId"));
                sur.Sus_DispStatus = r.GetString(r.GetOrdinal("Sus_DispStatus"));
                if (r.GetInt32(r.GetOrdinal("Sus_StatusId")) != 155009)
                {
                    suListCount++;
                }
                sur.Sus_Kort = r.GetString(r.GetOrdinal("Sus_Kort"));
                sur.Sus_Lang = r.GetString(r.GetOrdinal("Sus_Lang"));
                sur.Sus_WijzigentoegestaanJN = r.GetInt32(r.GetOrdinal("Sus_WijzigentoegestaanJN"));
                sur.Sus_HusId = r.GetInt32(r.GetOrdinal("Sus_HusId"));
                sur.Sus_DispHus = r.GetString(r.GetOrdinal("Sus_DispHus"));
                sur.Sus_Mutatiedatum = r.GetDateTime(r.GetOrdinal("Sus_Mutatiedatum"));
                sur.Sus_Opmerking = "";
                try
                {
                    sur.Sus_Opmerking = r.GetString(r.GetOrdinal("Sus_Opmerking"));
                }
                catch (Exception)
                {
                }
                lstSubuitgavesoortRecord.Add(sur);
            }

        }

        public suRecord vanRecord(int recNr)
        {
            suRecord suRec = new suRecord();
            suRec.Sus_Id = lstSubuitgavesoortRecord[recNr].Sus_Id;
            suRec.Sus_StatusId = lstSubuitgavesoortRecord[recNr].Sus_StatusId;
            suRec.Sus_DispStatus = lstSubuitgavesoortRecord[recNr].Sus_DispStatus;
            suRec.Sus_Kort = lstSubuitgavesoortRecord[recNr].Sus_Kort;
            suRec.Sus_Lang = lstSubuitgavesoortRecord[recNr].Sus_Lang;
            suRec.Sus_WijzigentoegestaanJN = lstSubuitgavesoortRecord[recNr].Sus_WijzigentoegestaanJN;
            suRec.Sus_HusId = lstSubuitgavesoortRecord[recNr].Sus_HusId;
            suRec.Sus_DispHus = lstSubuitgavesoortRecord[recNr].Sus_DispHus;
            suRec.Sus_Mutatiedatum = lstSubuitgavesoortRecord[recNr].Sus_Mutatiedatum;
            suRec.Sus_Opmerking = lstSubuitgavesoortRecord[recNr].Sus_Opmerking;
            return suRec;
        }

        public suRecord vulDefaultSu()
        {
            pf pf = new pf();
            suRecord suRec = new suRecord();
            suRec.Sus_StatusId = 155009;
            suRec.Sus_DispStatus = "Sus-record is leeg / Tabel-initrecord";
            suRec.Sus_Kort = "Sus_kort;
            suRec.Sus_Lang = "Sus_lang";
            suRec.Sus_WijzigentoegestaanJN = 1;
            suRec.Sus_HusId = 1;
            suRec.Sus_DispHus = "";
            suRec.Sus_Mutatiedatum = DateTime.Parse("2000-01-01 00:00:00");
            suRec.Sus_Opmerking = "";
            return suRec;
        }

        public int newSuRecord()
        {
            pf pf = new pf();
            suRecord dSu = new suRecord();
            dSu = vulDefaultSu();
            int newSuId = new int();
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                string findstring = pf.randomString(6);
                string sqlStr = "Insert Into Subuitgavesoort (Sus_StatusId, Sus_DispStatus, Sus_Kort, Sus_Lang, Sus_WijzigentoegestaanJN, " +
                                "Sus_HusId, Sus_DispHus, Sus_Mutatiedatum, Sus_Opmerking) Values (@2, @3, @4, @5, @6, @7, @8, @9, @10)";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    SQLiteParameter p2 = new SQLiteParameter(); p2.ParameterName = "@2"; p2.Value = 155009; sqlCmd.Parameters.Add(p2);
                    SQLiteParameter p3 = new SQLiteParameter(); p3.ParameterName = "@3"; p3.Value = "Sus-record is zijn leeg / Tabelinitrecord"; sqlCmd.Parameters.Add(p3);
                    SQLiteParameter p4 = new SQLiteParameter(); p4.ParameterName = "@4"; p4.Value = "Sus_kort"; sqlCmd.Parameters.Add(p4);
                    SQLiteParameter p5 = new SQLiteParameter(); p5.ParameterName = "@5"; p5.Value = "Sus_lang"; sqlCmd.Parameters.Add(p5);
                    SQLiteParameter p6 = new SQLiteParameter(); p6.ParameterName = "@6"; p6.Value = 1; sqlCmd.Parameters.Add(p6);
                    SQLiteParameter p7 = new SQLiteParameter(); p7.ParameterName = "@7"; p7.Value = 1; sqlCmd.Parameters.Add(p7);
                    SQLiteParameter p8 = new SQLiteParameter(); p8.ParameterName = "@8"; p8.Value = ""; sqlCmd.Parameters.Add(p8);
                    SQLiteParameter p9 = new SQLiteParameter(); p9.ParameterName = "@9"; p9.Value = DateTime.Parse("2000-01-01 00:00:00"); sqlCmd.Parameters.Add(p9);
                    SQLiteParameter p10 = new SQLiteParameter(); p10.ParameterName = "@10"; p10.Value = findstring; sqlCmd.Parameters.Add(p10);
                    sqlCmd.ExecuteNonQuery();
                    dbcDa.Close();
                }

                // Zoek toegevoegde record
                tblSu su = new tblSu();
                su.zoekSubuitgavesoortRecord("Sus_Opmerking = " + "\"" + findstring + "\"");
                newSuId = su.lstSubuitgavesoortRecord[0].Sus_Id;

                // Verwijder infor uit Opmerking-veld
                dbcDa.Open();
                sqlStr = "Update Subuitgavesoort set Sus_Opmerking=@8 where Sus_Id = @1;";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    sqlCmd.Parameters.AddWithValue("@1", newSuId);
                    sqlCmd.Parameters.AddWithValue("@8", "");
                    sqlCmd.ExecuteNonQuery();
                }
                dbcDa.Close();


                return newSuId;
            }
        }

        public void saveRecord(int iSuId, suRecord suR)
        {
            string sqlStr = "Update Subuitgavesoort (Sus_StatusId=@2, Sus_DispStatus=@3, Sus_Kort=@4, Sus_Lang=@5, Sus_WijzigentoegestaanJN=@6, " +
                            "Sus_HusId=@7, Sus_DispHus=@8, Sus_Mutatiedatum=@9, Sus_Opmerking=@10 Where Sus_Id=@1;";


            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", iSuId);
                        sqlCmd.Parameters.AddWithValue("@2", suR.Sus_StatusId);
                        sqlCmd.Parameters.AddWithValue("@3", suR.Sus_DispStatus);
                        sqlCmd.Parameters.AddWithValue("@4", suR.Sus_Kort);
                        sqlCmd.Parameters.AddWithValue("@5", suR.Sus_Lang);
                        sqlCmd.Parameters.AddWithValue("@6", suR.Sus_WijzigentoegestaanJN);
                        sqlCmd.Parameters.AddWithValue("@7", suR.Sus_HusId);
                        sqlCmd.Parameters.AddWithValue("@8", suR.Sus_DispHus);
                        sqlCmd.Parameters.AddWithValue("@9", suR.Sus_Mutatiedatum);
                        sqlCmd.Parameters.AddWithValue("@10", suR.Sus_Opmerking);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception) { }

                dbcDa.Close();
            }
        }

        public void deleteRecord(int iSuId)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    string sqlStr = "Delete from Subuitgavesoort Where Sus_Id=@1;";
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", iSuId);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (SystemException ex)
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("Fout bij verwijderen van een subuitgavesoort: {0}", ex.Message));
                }
            }
        }
    }
}

