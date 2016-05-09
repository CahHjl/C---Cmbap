using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using globalVars;
using ProcFunc;

namespace nsTblHc
{
    class tblHc
    {
        public struct hcRecord
        {
            public int Hcat_Id { get; set; }
            public int Hcat_StatusId { get; set; }
            public string Hcat_DispStatus { get; set; }
            public string Hcat_Prefix { get; set; }
            public string Hcat_Kort { get; set; }
            public string Hcat_Lang { get; set; }
            public int Hcat_WijzigentoegestaanJN { get; set; }
            public DateTime Hcat_Mutatiedatum { get; set; }
            public string Hcat_Opmerking { get; set; }
        }

        public List<hcRecord> lstHoofdcategorieRecord = new List<hcRecord>();
        public int hcListCount;
        public int hcListTCount;

        public void zoekHoofdcategorieRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Hoofdcategorietabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Hoofdcategorie Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Hoofdcategorie;";
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

        public int telHoofdcategorieRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Hoofdcategorietablel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Hoofdcategorie Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Hoofdcategorie;";
                }
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    using (SQLiteDataReader sqlRdr = sqlCmd.ExecuteReader())
                    {
                        hcListCount = 0;
                        hcListTCount = 0;
                        while (sqlRdr.Read())
                        {
                            //get rows
                            hcListTCount++;
                            if (sqlRdr.GetInt32(sqlRdr.GetOrdinal("Hcat_StatusId")) != 195009)
                            {
                                hcListCount++;
                            }
                        }
                    }
                }
                dbcDa.Close();
                return hcListCount;
            }
        }

        private void recordsInList(SQLiteDataReader r)
        {
            hcRecord hcr = new hcRecord();

            lstHoofdcategorieRecord.Clear();
            hcListCount = 0;
            hcListTCount = 0;

            while (r.Read())
            {
                //Maak list van geselecteerde rijen

                hcListTCount++;
                hcr.Hcat_Id = r.GetInt32(r.GetOrdinal("Hcat_Id"));
                hcr.Hcat_StatusId = r.GetInt32(r.GetOrdinal("Hcat_StatusId"));
                hcr.Hcat_DispStatus = r.GetString(r.GetOrdinal("Hcat_DispStatus"));
                if (r.GetInt32(r.GetOrdinal("Hcat_StatusId")) != 195009)
                {
                    hcListCount++;
                }
                hcr.Hcat_Prefix = r.GetString(r.GetOrdinal("Hcat_Prefix"));
                hcr.Hcat_Kort = r.GetString(r.GetOrdinal("Hcat_Kort"));
                hcr.Hcat_Lang = r.GetString(r.GetOrdinal("Hcat_Lang"));
                hcr.Hcat_WijzigentoegestaanJN = r.GetInt32(r.GetOrdinal("Hcat_WijzigentoegestaanJN"));
                hcr.Hcat_Mutatiedatum = r.GetDateTime(r.GetOrdinal("Hcat_Mutatiedatum"));
                hcr.Hcat_Opmerking = "";
                try
                {
                    hcr.Hcat_Opmerking = r.GetString(r.GetOrdinal("Hcat_Opmerking"));
                }
                catch (Exception)
                {
                }
                lstHoofdcategorieRecord.Add(hcr);
            }

        }

        public hcRecord vanRecord(int recNr)
        {
            hcRecord hcRec = new hcRecord();
            hcRec.Hcat_Id = lstHoofdcategorieRecord[recNr].Hcat_Id;
            hcRec.Hcat_StatusId = lstHoofdcategorieRecord[recNr].Hcat_StatusId;
            hcRec.Hcat_DispStatus = lstHoofdcategorieRecord[recNr].Hcat_DispStatus;
            hcRec.Hcat_Prefix = lstHoofdcategorieRecord[recNr].Hcat_Prefix;
            hcRec.Hcat_Kort = lstHoofdcategorieRecord[recNr].Hcat_Kort;
            hcRec.Hcat_Lang = lstHoofdcategorieRecord[recNr].Hcat_Lang;
            hcRec.Hcat_WijzigentoegestaanJN = lstHoofdcategorieRecord[recNr].Hcat_WijzigentoegestaanJN;
            hcRec.Hcat_Mutatiedatum = lstHoofdcategorieRecord[recNr].Hcat_Mutatiedatum;
            hcRec.Hcat_Opmerking = lstHoofdcategorieRecord[recNr].Hcat_Opmerking;
            return hcRec;
        }

        public hcRecord vulDefaultHc()
        {
            pf pf = new pf();
            hcRecord hcRec = new hcRecord();
            hcRec.Hcat_StatusId = 195009;
            hcRec.Hcat_DispStatus = "Hcat-record is leeg / Tabel-initrecord";
            hcRec.Hcat_Prefix = "PFX";
            hcRec.Hcat_Kort = "Hcat_kort";
            hcRec.Hcat_Lang = "Hcat_lang";
            hcRec.Hcat_WijzigentoegestaanJN = 1;
            hcRec.Hcat_Mutatiedatum = DateTime.Parse("2000-01-01 00:00:00");
            hcRec.Hcat_Opmerking = "";
            return hcRec;
        }

        public int newHcRecord()
        {
            pf pf = new pf();
            hcRecord dHc = new hcRecord();
            dHc = vulDefaultHc();
            int newHcId = new int();
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                string findstring = pf.randomString(6);
                string sqlStr = "Insert Into Hoofdcategorie (Hcat_StatusId, Hcat_DispStatus, Hcat_Prefix, Hcat_Kort, Hcat_Lang, " +
                                "Hcat_WijzigentoegestaanJN, Hcat_Mutatiedatum, Hcat_Opmerking) Values " +
                                "(@2, @3, @4, @5, @6, @7, @8, @9)";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    SQLiteParameter p2 = new SQLiteParameter(); p2.ParameterName = "@2"; p2.Value = 195009; sqlCmd.Parameters.Add(p2);
                    SQLiteParameter p3 = new SQLiteParameter(); p3.ParameterName = "@3"; p3.Value = "Hcat-record is zijn leeg / Tabelinitrecord"; sqlCmd.Parameters.Add(p3);
                    SQLiteParameter p4 = new SQLiteParameter(); p4.ParameterName = "@4"; p4.Value = "PFX"; sqlCmd.Parameters.Add(p4);
                    SQLiteParameter p5 = new SQLiteParameter(); p5.ParameterName = "@5"; p5.Value = "Hcat_kort"; sqlCmd.Parameters.Add(p5);
                    SQLiteParameter p6 = new SQLiteParameter(); p6.ParameterName = "@6"; p6.Value = "Hcat_lang"; sqlCmd.Parameters.Add(p6);
                    SQLiteParameter p7 = new SQLiteParameter(); p7.ParameterName = "@7"; p7.Value = 1; sqlCmd.Parameters.Add(p7);
                    SQLiteParameter p8 = new SQLiteParameter(); p8.ParameterName = "@8"; p8.Value = DateTime.Parse("2000-01-01 00:00:00"); sqlCmd.Parameters.Add(p8);
                    SQLiteParameter p9 = new SQLiteParameter(); p9.ParameterName = "@9"; p9.Value = findstring; sqlCmd.Parameters.Add(p9);
                    sqlCmd.ExecuteNonQuery();
                    dbcDa.Close();
                }

                // Zoek toegevoegde record
                tblHc hc = new tblHc();
                hc.zoekHoofdcategorieRecord("Hcat_Opmerking = " + "\"" + findstring + "\"");
                newHcId = hc.lstHoofdcategorieRecord[0].Hcat_Id;

                // Verwijder infor uit Opmerking-veld
                dbcDa.Open();
                sqlStr = "Update Hoofdcategorie set Hcat_Opmerking=@8 where Hcat_Id = @1;";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    sqlCmd.Parameters.AddWithValue("@1", newHcId);
                    sqlCmd.Parameters.AddWithValue("@8", "");
                    sqlCmd.ExecuteNonQuery();
                }
                dbcDa.Close();


                return newHcId;
            }
        }

        public void saveRecord(int iHcId, hcRecord hcR)
        {

            string sqlStr = "Update Hoofdcategorie (Hcat_StatusId=@2, Hcat_DispStatus=@3, Hcat_Prefix=@4, Hcat_Kort=@5, Hcat_Lang=@6, " +
                            "Hcat_WijzigentoegestaanJN=@7, Hcat_Mutatiedatum=@8, Hcat_Opmerking=9 Where Hcat=@1;";
    
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", iHcId);
                        sqlCmd.Parameters.AddWithValue("@2", hcR.Hcat_StatusId);
                        sqlCmd.Parameters.AddWithValue("@3", hcR.Hcat_DispStatus);
                        sqlCmd.Parameters.AddWithValue("@4", hcR.Hcat_Prefix);
                        sqlCmd.Parameters.AddWithValue("@5", hcR.Hcat_Kort);
                        sqlCmd.Parameters.AddWithValue("@6", hcR.Hcat_Lang);
                        sqlCmd.Parameters.AddWithValue("@7", hcR.Hcat_WijzigentoegestaanJN);
                        sqlCmd.Parameters.AddWithValue("@8", hcR.Hcat_Mutatiedatum);
                        sqlCmd.Parameters.AddWithValue("@9", hcR.Hcat_Opmerking);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception) { }

                dbcDa.Close();
            }
        }

        public void deleteRecord(int iHcId)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    string sqlStr = "Delete from Hoofdcategorie Where Hcat_Id=@1;";
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", iHcId);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (SystemException ex)
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("Fout bij verwijderen van een hoofdcategorie: {0}", ex.Message));
                }
            }
        }
    }
}

