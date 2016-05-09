using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using globalVars;
using ProcFunc;

namespace nsTblHu
{
    class tblHu
    {
        public struct huRecord
        {
            public int Hus_Id { get; set; }
            public int Hus_StatusId { get; set; }
            public string Hus_DispStatus { get; set; }
            public string Hus_Kort { get; set; }
            public string Hus_Lang { get; set; }
            public int Hus_WijzigentoegestaanJN { get; set; }
            public DateTime Hus_Mutatiedatum { get; set; }
            public string Hus_Opmerking { get; set; }
        }

        public List<huRecord> lstHoofduitgavesoortRecord = new List<huRecord>();
        public int huListCount;
        public int huListTCount;

        public void zoekHoofduitgavesoortRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Hoofduitgavesoortgavetabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Hoofduitgavesoort Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Hoofduitgavesoort;";
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

        public int telHoofduitgavesoortRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Hoofduitgavesoorttabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Hoofduitgavesoort Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Hoofduitgavesoort;";
                }
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    using (SQLiteDataReader sqlRdr = sqlCmd.ExecuteReader())
                    {
                        huListCount = 0;
                        huListTCount = 0;
                        while (sqlRdr.Read())
                        {
                            //get rows
                            huListTCount++;
                            if (sqlRdr.GetInt32(sqlRdr.GetOrdinal("Hus_StatusId")) != 190009)
                            {
                                huListCount++;
                            }
                        }
                    }
                }
                dbcDa.Close();
                return huListCount;
            }
        }

        private void recordsInList(SQLiteDataReader r)
        {
            huRecord hur = new huRecord();

            lstHoofduitgavesoortRecord.Clear();
            huListCount = 0;
            huListTCount = 0;

            while (r.Read())
            {
                //Maak list van geselecteerde rijen

                huListTCount++;
                hur.Hus_Id = r.GetInt32(r.GetOrdinal("Hus_Id"));
                hur.Hus_StatusId = r.GetInt32(r.GetOrdinal("Hus_StatusId"));
                hur.Hus_DispStatus = r.GetString(r.GetOrdinal("Hus_DispStatus"));
                if (r.GetInt32(r.GetOrdinal("Hus_StatusId")) != 190009)
                {
                    huListCount++;
                }
                hur.Hus_Kort = r.GetString(r.GetOrdinal("Hus_Kort"));
                hur.Hus_Lang = r.GetString(r.GetOrdinal("Hus_Lang"));
                hur.Hus_WijzigentoegestaanJN = r.GetInt32(r.GetOrdinal("Hus_WijzigentoegestaanJN"));
                hur.Hus_Mutatiedatum = r.GetDateTime(r.GetOrdinal("Hus_Mutatiedatum"));
                hur.Hus_Opmerking = "";
                try
                {
                    hur.Hus_Opmerking = r.GetString(r.GetOrdinal("Hus_Opmerking"));
                }
                catch (Exception)
                {
                }
                lstHoofduitgavesoortRecord.Add(hur);
            }

        }

        public huRecord vanRecord(int recNr)
        {
            huRecord huRec = new huRecord();
            huRec.Hus_Id = lstHoofduitgavesoortRecord[recNr].Hus_Id;
            huRec.Hus_StatusId = lstHoofduitgavesoortRecord[recNr].Hus_StatusId;
            huRec.Hus_DispStatus = lstHoofduitgavesoortRecord[recNr].Hus_DispStatus;
            huRec.Hus_Kort = lstHoofduitgavesoortRecord[recNr].Hus_Kort;
            huRec.Hus_Lang = lstHoofduitgavesoortRecord[recNr].Hus_Lang;
            huRec.Hus_WijzigentoegestaanJN = lstHoofduitgavesoortRecord[recNr].Hus_WijzigentoegestaanJN;
            huRec.Hus_Mutatiedatum = lstHoofduitgavesoortRecord[recNr].Hus_Mutatiedatum;
            huRec.Hus_Opmerking = lstHoofduitgavesoortRecord[recNr].Hus_Opmerking;
            return huRec;
        }

        public huRecord vulDefaultHu()
        {
            pf pf = new pf();
            huRecord huRec = new huRecord();
            huRec.Hus_StatusId = 190009;
            huRec.Hus_DispStatus = "Hus-record is leeg / Tabel-initrecord";
            huRec.Hus_Kort = "Hus_kort";
            huRec.Hus_Lang = "Hus_lang";
            huRec.Hus_WijzigentoegestaanJN = 1;
            huRec.Hus_Mutatiedatum = DateTime.Parse("2000-01-01 00:00:00");
            huRec.Hus_Opmerking = "";
            return huRec;
        }

        public int newHuRecord()
        {
            pf pf = new pf();
            huRecord dHu = new huRecord();
            dHu = vulDefaultHu();
            int newHuId = new int();
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                string findstring = pf.randomString(6);
                string sqlStr = "Insert Into Hoofduitgavesoort (Hus_StatusId, Hus_DispStatus, Hus_Kort, Hus_Lang, Hus_WijzigentoegestaanJN, " +
                                "Hus_Mutatiedatum, Hus_Opmerking) Values (@2, @3, @4, @5, @6, @7, @8)";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    SQLiteParameter p2 = new SQLiteParameter(); p2.ParameterName = "@2"; p2.Value = 190009; sqlCmd.Parameters.Add(p2);
                    SQLiteParameter p3 = new SQLiteParameter(); p3.ParameterName = "@3"; p3.Value = "Hus-record is zijn leeg / Tabelinitrecord"; sqlCmd.Parameters.Add(p3);
                    SQLiteParameter p4 = new SQLiteParameter(); p4.ParameterName = "@4"; p4.Value = "Hus_kort"; sqlCmd.Parameters.Add(p4);
                    SQLiteParameter p5 = new SQLiteParameter(); p5.ParameterName = "@5"; p5.Value = "Hus_lang"; sqlCmd.Parameters.Add(p5);
                    SQLiteParameter p6 = new SQLiteParameter(); p6.ParameterName = "@6"; p6.Value = 1; sqlCmd.Parameters.Add(p6);
                    SQLiteParameter p7= new SQLiteParameter(); p7.ParameterName = "@7"; p7.Value = DateTime.Parse("2000-01-01 00:00:00"); sqlCmd.Parameters.Add(p7);
                    SQLiteParameter p8 = new SQLiteParameter(); p8.ParameterName = "@8"; p8.Value = findstring; sqlCmd.Parameters.Add(p8);
                    sqlCmd.ExecuteNonQuery();
                    dbcDa.Close();
                }

                // Zoek toegevoegde record
                tblHu hu = new tblHu();
                hu.zoekHoofduitgavesoortRecord("Hus_Opmerking = " + "\"" + findstring + "\"");
                newHuId = hu.lstHoofduitgavesoortRecord[0].Hus_Id;

                // Verwijder infor uit Opmerking-veld
                dbcDa.Open();
                sqlStr = "Update Hoofduitgavesoort set Hus_Opmerking=@8 where Hus_Id = @1;";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    sqlCmd.Parameters.AddWithValue("@1", newHuId);
                    sqlCmd.Parameters.AddWithValue("@8", "");
                    sqlCmd.ExecuteNonQuery();
                }
                dbcDa.Close();


                return newHuId;
            }
        }

        public void saveRecord(int iHuId, huRecord huR)
        {
            string sqlStr = "Update Hoofduitgavesoort set Hus_StatusId=@2, Hus_DispStatus=@3, Hus_Kort=@4, Hus_Lang=@5, Hus_WijzigentoegestaanJN=@6, " +
                            "Hus_Mutatiedatum=@7, Hus_Opmerking=@8 Where Hus_Id=@1;";


            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", iHuId);
                        sqlCmd.Parameters.AddWithValue("@2", huR.Hus_StatusId);
                        sqlCmd.Parameters.AddWithValue("@3", huR.Hus_DispStatus);
                        sqlCmd.Parameters.AddWithValue("@4", huR.Hus_Kort);
                        sqlCmd.Parameters.AddWithValue("@5", huR.Hus_Lang);
                        sqlCmd.Parameters.AddWithValue("@6", huR.Hus_WijzigentoegestaanJN);
                        sqlCmd.Parameters.AddWithValue("@7", huR.Hus_Mutatiedatum);
                        sqlCmd.Parameters.AddWithValue("@8", huR.Hus_Opmerking);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception) { }

                dbcDa.Close();
            }
        }

        public void deleteRecord(int iHuId)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    string sqlStr = "Delete from Hoofduitgavesoort Where Hus_Id=@1;";
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", iHuId);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (SystemException ex)
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("Fout bij verwijderen van een hoofduitgavesoort: {0}", ex.Message));
                }
            }
        }
    }
}

