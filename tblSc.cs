using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using globalVars;
using ProcFunc;

namespace nsTblSc
{
    class tblSc
    {
        public struct scRecord
        {
            public int Scat_Id { get; set; }
            public int Scat_StatusId { get; set; }
            public string Scat_DispStatus { get; set; }
            public string Scat_Kort { get; set; }
            public string Scat_Lang { get; set; }
            public int Scat_HcatId { get; set; }
            public string Scat_DispHcat { get; set; }
            public string Scat_Code { get; set; }
            public int Scat_WijzigentoegestaanJN { get; set; }
            public DateTime Scat_Mutatiedatum { get; set; }
            public string Scat_Opmerking { get; set; }
        }

        public List<scRecord> lstSubcategorieRecord = new List<scRecord>();
        public int scListCount;
        public int scListTCount;

        public void zoekSubcategorieRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Subcategorietabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Subcategorie Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Subcategorie;";
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

        public int telSubcategorieRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Subcategorietablel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Subcategorie Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Subcategorie;";
                }
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    using (SQLiteDataReader sqlRdr = sqlCmd.ExecuteReader())
                    {
                        scListCount = 0;
                        scListTCount = 0;
                        while (sqlRdr.Read())
                        {
                            //get rows
                            scListTCount++;
                            if (sqlRdr.GetInt32(sqlRdr.GetOrdinal("Scat_StatusId")) != 160009)
                            {
                                scListCount++;
                            }
                        }
                    }
                }
                dbcDa.Close();
                return scListCount;
            }
        }

        private void recordsInList(SQLiteDataReader r)
        {
            scRecord scr = new scRecord();

            lstSubcategorieRecord.Clear();
            scListCount = 0;
            scListTCount = 0;

            while (r.Read())
            {
                //Maak list van geselecteerde rijen

                scListTCount++;
                scr.Scat_Id = r.GetInt32(r.GetOrdinal("Scat_Id"));
                scr.Scat_StatusId = r.GetInt32(r.GetOrdinal("Scat_StatusId"));
                scr.Scat_DispStatus = r.GetString(r.GetOrdinal("Scat_DispStatus"));
                if (r.GetInt32(r.GetOrdinal("Scat_StatusId")) != 160009)
                {
                    scListCount++;
                }
                scr.Scat_Kort = r.GetString(r.GetOrdinal("Scat_Kort"));
                scr.Scat_Lang = r.GetString(r.GetOrdinal("Scat_Lang"));
                scr.Scat_HcatId = r.GetInt32(r.GetOrdinal("Scat_HcatId"));
                scr.Scat_DispHcat = r.GetString(r.GetOrdinal("Scat_DispHcat"));
                scr.Scat_Code = r.GetString(r.GetOrdinal("Scat_Code"));
                scr.Scat_WijzigentoegestaanJN = r.GetInt32(r.GetOrdinal("Scat_WijzigentoegestaanJN"));
                scr.Scat_Mutatiedatum = r.GetDateTime(r.GetOrdinal("Scat_Mutatiedatum"));
                scr.Scat_Opmerking = "";
                try
                {
                    scr.Scat_Opmerking = r.GetString(r.GetOrdinal("Scat_Opmerking"));
                }
                catch (Exception)
                {
                }
                lstSubcategorieRecord.Add(scr);
            }

        }

        public scRecord vanRecord(int recNr)
        {
            scRecord scRec = new scRecord();
            scRec.Scat_Id = lstSubcategorieRecord[recNr].Scat_Id;
            scRec.Scat_StatusId = lstSubcategorieRecord[recNr].Scat_StatusId;
            scRec.Scat_DispStatus = lstSubcategorieRecord[recNr].Scat_DispStatus;
            scRec.Scat_Kort = lstSubcategorieRecord[recNr].Scat_Kort;
            scRec.Scat_Lang = lstSubcategorieRecord[recNr].Scat_Lang;
            scRec.Scat_HcatId = lstSubcategorieRecord[recNr].Scat_HcatId;
            scRec.Scat_DispHcat = lstSubcategorieRecord[recNr].Scat_DispHcat;
            scRec.Scat_Code = lstSubcategorieRecord[recNr].Scat_Code;
            scRec.Scat_WijzigentoegestaanJN = lstSubcategorieRecord[recNr].Scat_WijzigentoegestaanJN;
            scRec.Scat_Mutatiedatum = lstSubcategorieRecord[recNr].Scat_Mutatiedatum;
            scRec.Scat_Opmerking = lstSubcategorieRecord[recNr].Scat_Opmerking;
            return scRec;
        }

        public scRecord vulDefaultSc()
        {
            pf pf = new pf();
            scRecord scRec = new scRecord();
            scRec.Scat_StatusId = 160009;
            scRec.Scat_DispStatus = "Scat-record is leeg / Tabel-initrecord";
            scRec.Scat_Kort = "Scat_kort";
            scRec.Scat_Lang = "Scat_lang";
            scRec.Scat_HcatId = 1;
            scRec.Scat_DispHcat = "";
            scRec.Scat_Code = "";
            scRec.Scat_WijzigentoegestaanJN = 1;
            scRec.Scat_Mutatiedatum = DateTime.Parse("2000-01-01 00:00:00");
            scRec.Scat_Opmerking = "";
            return scRec;
        }

        public int newScRecord()
        {
            pf pf = new pf();
            scRecord dSc = new scRecord();
            dSc = vulDefaultSc();
            int newScId = new int();
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                string findstring = pf.randomString(6);
                string sqlStr = "Insert Into Subcategorie (Scat_StatusId, Scat_DispStatus, Scat_Kort, Scat_Lang, Scat_HcatId, Scat_DispHcat, " +
                                "Scat_Code, Scat_WijzigentoegestaanJN, Scat_Mutatiedatum, Scat_Opmerking) Values " +
                                "(@2, @3, @4, @5, @6, @7, @8, @9, @10, @11)";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    SQLiteParameter p2 = new SQLiteParameter(); p2.ParameterName = "@2"; p2.Value = 160009; sqlCmd.Parameters.Add(p2);
                    SQLiteParameter p3 = new SQLiteParameter(); p3.ParameterName = "@3"; p3.Value = "Scat-record is zijn leeg / Tabelinitrecord"; sqlCmd.Parameters.Add(p3);
                    SQLiteParameter p4 = new SQLiteParameter(); p4.ParameterName = "@4"; p4.Value = "Scat_kort"; sqlCmd.Parameters.Add(p4);
                    SQLiteParameter p5 = new SQLiteParameter(); p5.ParameterName = "@5"; p5.Value = "Scat_lang"; sqlCmd.Parameters.Add(p5);
                    SQLiteParameter p6 = new SQLiteParameter(); p6.ParameterName = "@6"; p6.Value = 1; sqlCmd.Parameters.Add(p6);
                    SQLiteParameter p7 = new SQLiteParameter(); p7.ParameterName = "@7"; p7.Value = ""; sqlCmd.Parameters.Add(p7);
                    SQLiteParameter p8 = new SQLiteParameter(); p8.ParameterName = "@8"; p8.Value = ""; sqlCmd.Parameters.Add(p8);
                    SQLiteParameter p9 = new SQLiteParameter(); p9.ParameterName = "@9"; p9.Value = 1; sqlCmd.Parameters.Add(p9);
                    SQLiteParameter p10 = new SQLiteParameter(); p10.ParameterName = "@10"; p10.Value = DateTime.Parse("2000-01-01 00:00:00"); sqlCmd.Parameters.Add(p10);
                    SQLiteParameter p11 = new SQLiteParameter(); p11.ParameterName = "@11"; p11.Value = findstring; sqlCmd.Parameters.Add(p11);
                    sqlCmd.ExecuteNonQuery();
                    dbcDa.Close();
                }

                // Zoek toegevoegde record
                tblSc sc = new tblSc();
                sc.zoekSubcategorieRecord("Scat_Opmerking = " + "\"" + findstring + "\"");
                newScId = sc.lstSubcategorieRecord[0].Scat_Id;

                // Verwijder infor uit Opmerking-veld
                dbcDa.Open();
                sqlStr = "Update Subcategorie set Scat_Opmerking=@8 where Scat_Id = @1;";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    sqlCmd.Parameters.AddWithValue("@1", newScId);
                    sqlCmd.Parameters.AddWithValue("@8", "");
                    sqlCmd.ExecuteNonQuery();
                }
                dbcDa.Close();


                return newScId;
            }
        }

        public void saveRecord(int iScId, scRecord scR)
        {
            string sqlStr = "Update Subcategorie set Scat_StatusId=@2, Scat_DispStatus=@3, Scat_Kort=@4, Scat_Lang=@5, Scat_HcatId=@6, Scat_DispHcat=@7, " +
                                "Scat_Code=@8, Scat_WijzigentoegestaanJN=@9, Scat_Mutatiedatum=@10, Scat_Opmerking=@11 Where Scat_Id=@1;";


            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", iScId);
                        sqlCmd.Parameters.AddWithValue("@2", scR.Scat_StatusId);
                        sqlCmd.Parameters.AddWithValue("@3", scR.Scat_DispStatus);
                        sqlCmd.Parameters.AddWithValue("@4", scR.Scat_Kort);
                        sqlCmd.Parameters.AddWithValue("@5", scR.Scat_Lang);
                        sqlCmd.Parameters.AddWithValue("@6", scR.Scat_HcatId);
                        sqlCmd.Parameters.AddWithValue("@7", scR.Scat_DispHcat);
                        sqlCmd.Parameters.AddWithValue("@8", scR.Scat_Code);
                        sqlCmd.Parameters.AddWithValue("@9", scR.Scat_WijzigentoegestaanJN);
                        sqlCmd.Parameters.AddWithValue("@10", scR.Scat_Mutatiedatum);
                        sqlCmd.Parameters.AddWithValue("@11", scR.Scat_Opmerking);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception) { }

                dbcDa.Close();
            }
        }

        public void deleteRecord(int iScId)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    string sqlStr = "Delete from Subcategorie Where Scat_Id=@1;";
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", iScId);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (SystemException ex)
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("Fout bij verwijderen van een subcategorie: {0}", ex.Message));
                }
            }
        }
    }
}

