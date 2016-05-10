using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SQLite;
using ProcFunc;
using globalVars;

namespace nsTblIl
{
    class tblIl
    {
        public struct ilRecord
        {
            public int Instl_Id { get; set; }
            public int Instl_Systeemsetting { get; set; }
            public int Instl_StatusId { get; set; }
            public string Instl_DispStatus { get; set; }
            public string Instl_Naam { get; set; }
            public byte Instl_Gegtype { get; set; }
            public int Instl_Actief { get; set; }
            public string Instl_String { get; set; }
            public int Instl_JN { get; set; }
            public long Instl_Integer { get; set; }
            public decimal Instl_Real { get; set; }
            public string Instl_Memo { get; set; }
    	    public DateTime Instl_Datum { get; set; }
            public DateTime Instl_Tijd { get; set; }
            public DateTime Instl_Mutatiedatum { get; set; }
            public string Instl_Opmerking { get; set; }
        }



        public List<ilRecord> lstInstellingenRecord = new List<ilRecord>();
        public int ilListCount;
        public int ilListTCount;

        public void zoekInstellingenRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Instellingentabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Instellingen Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Instellingen;";
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

        public int telInstellingenRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Instellingentabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Instellingen Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Instellingen;";
                }
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    using (SQLiteDataReader sqlRdr = sqlCmd.ExecuteReader())
                    {
                        ilListCount = 0;
                        ilListTCount = 0;
                        while (sqlRdr.Read())
                        {
                            //get rows
                            ilListTCount++;
                            if (sqlRdr.GetInt32(sqlRdr.GetOrdinal("Instl_StatusId")) != 185009)
                            {
                                ilListCount++;
                            }
                        }
                    }
                }
                dbcDa.Close();
                return ilListCount;
            }
        }

        private void recordsInList(SQLiteDataReader r)
        {
            ilRecord ilr = new ilRecord();

            lstInstellingenRecord.Clear();

            while (r.Read())
            {
                //Maak list van geselecteerde rijen
                ilListTCount++;
                ilr.Instl_Id = r.GetInt32(r.GetOrdinal("Instl_Id"));
                ilr.Instl_Systeemsetting = r.GetInt32(r.GetOrdinal("Instl_Systeemsetting"));
                ilr.Instl_StatusId = r.GetInt32(r.GetOrdinal("Instl_StatusId"));
                ilr.Instl_DispStatus = r.GetString(r.GetOrdinal("Instl_DispStatus"));
                if (r.GetInt32(r.GetOrdinal("Instl_StatusId")) != 185009)
                {
                    ilListCount++;
                }
                ilr.Instl_Naam = r.GetString(r.GetOrdinal("Instl_Naam"));
                ilr.Instl_Gegtype=r.GetByte(r.GetOrdinal("Instl_Gegtype"));
                ilr.Instl_Actief = r.GetInt32(r.GetOrdinal("Instl_Actief"));
                ilr.Instl_String = r.GetString(r.GetOrdinal("Instl_String"));
                ilr.Instl_JN = r.GetInt32(r.GetOrdinal("Instl_JN"));
                ilr.Instl_Integer = r.GetInt64(r.GetOrdinal("Instl_Integer"));
                ilr.Instl_Real = r.GetDecimal(r.GetOrdinal("Instl_Real"));
                ilr.Instl_Memo = r.GetString(r.GetOrdinal("Instl_Memo"));
                ilr.Instl_Datum = r.GetDateTime(r.GetOrdinal("Instl_Datum"));
                ilr.Instl_Tijd = r.GetDateTime(r.GetOrdinal("Instl_Tijd"));
                ilr.Instl_Mutatiedatum = r.GetDateTime(r.GetOrdinal("Instl_Mutatiedatum"));
                try
                {
                    ilr.Instl_Opmerking=r.GetString(r.GetOrdinal("Instl_Opmerking"));
                }
                catch (Exception)
                {
                }
                lstInstellingenRecord.Add(ilr);
            }

        }

        public ilRecord vanRecord(int recNr)
        {
            ilRecord ilRec = new ilRecord();
            ilRec.Instl_Id = lstInstellingenRecord[recNr].Instl_Id;
            ilRec.Instl_Systeemsetting = lstInstellingenRecord[recNr].Instl_Systeemsetting;
            ilRec.Instl_StatusId = lstInstellingenRecord[recNr].Instl_StatusId;
            ilRec.Instl_DispStatus = lstInstellingenRecord[recNr].Instl_DispStatus;
            ilRec.Instl_Naam = lstInstellingenRecord[recNr].Instl_Naam;
            ilRec.Instl_Gegtype = lstInstellingenRecord[recNr].Instl_Gegtype;
            ilRec.Instl_Actief = lstInstellingenRecord[recNr].Instl_Actief;
            ilRec.Instl_String = lstInstellingenRecord[recNr].Instl_String;
            ilRec.Instl_JN = lstInstellingenRecord[recNr].Instl_JN;
            ilRec.Instl_Integer = lstInstellingenRecord[recNr].Instl_Integer;
            ilRec.Instl_Real = lstInstellingenRecord[recNr].Instl_Real;
            ilRec.Instl_Memo = lstInstellingenRecord[recNr].Instl_Memo;
            ilRec.Instl_Datum = lstInstellingenRecord[recNr].Instl_Datum;
            ilRec.Instl_Tijd = lstInstellingenRecord[recNr].Instl_Tijd;
            ilRec.Instl_Mutatiedatum = lstInstellingenRecord[recNr].Instl_Mutatiedatum;
            return ilRec;
        }

        public ilRecord vulDefaultIl()
        {
            pf pf = new pf();
            ilRecord ilRec = new ilRecord();
            ilRec.Instl_Systeemsetting = 0;
            ilRec.Instl_StatusId = 185009;
            ilRec.Instl_DispStatus = "Instl-record is leeg / Tabl-initrecord";
            ilRec.Instl_Naam = "Instelling";
            ilRec.Instl_Gegtype = 0;
            ilRec.Instl_Actief = 0;
            ilRec.Instl_String = "";
            ilRec.Instl_JN = 0;
            ilRec.Instl_Integer = 0;
            ilRec.Instl_Real = 0;
            ilRec.Instl_Memo = "";
            ilRec.Instl_Datum = DateTime.Parse("2000-01-01 00:00:00");
            ilRec.Instl_Tijd = DateTime.Parse("2000-01-01 00:00:00");
            ilRec.Instl_Mutatiedatum = DateTime.Parse("2000-01-01 00:00:00");
            ilRec.Instl_Opmerking = "";
            return ilRec;
        }

        public int newIlRecord()
        {
            pf pf = new pf();
            ilRecord dIl = new ilRecord();
            dIl = vulDefaultIl();
            int newIlId = new int();
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                string findstring = pf.randomString(6);
                string sqlStr = "Insert Into Instellingen (Instl_Systeemsetting, Instl_StatusId, Instl_DispStatus, Instl_Naam, Instl_Gegtype, " +
                                "Instl_Actief, Instl_String, Instl_JN, Instl_Integer, Instl_Real, Instl_Memo, Instl_Datum, Instl_Tijd" +
                                "Instl_Mutatiedatum, Instl_Opmerking) Values (@2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16)";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    SQLiteParameter p2 = new SQLiteParameter(); p2.ParameterName = "@2"; p2.Value = 0; sqlCmd.Parameters.Add(p2);
                    SQLiteParameter p3 = new SQLiteParameter(); p3.ParameterName = "@3"; p3.Value = 195009; sqlCmd.Parameters.Add(p3);
                    SQLiteParameter p4 = new SQLiteParameter(); p4.ParameterName = "@4"; p4.Value = "Instl-record is zijn leeg / Tabelinitrecord"; sqlCmd.Parameters.Add(p4);
                    SQLiteParameter p5 = new SQLiteParameter(); p5.ParameterName = "@5"; p5.Value = "Instelling"; sqlCmd.Parameters.Add(p5);
                    SQLiteParameter p6 = new SQLiteParameter(); p6.ParameterName = "@6"; p6.Value = 0; sqlCmd.Parameters.Add(p6);
                    SQLiteParameter p7 = new SQLiteParameter(); p7.ParameterName = "@7"; p7.Value = 0; sqlCmd.Parameters.Add(p7);
                    SQLiteParameter p8 = new SQLiteParameter(); p8.ParameterName = "@8"; p8.Value = ""; sqlCmd.Parameters.Add(p8);
                    SQLiteParameter p9 = new SQLiteParameter(); p9.ParameterName = "@9"; p9.Value = 0; sqlCmd.Parameters.Add(p9);
                    SQLiteParameter p10 = new SQLiteParameter(); p10.ParameterName = "@10"; p10.Value = 0; sqlCmd.Parameters.Add(p10);
                    SQLiteParameter p11 = new SQLiteParameter(); p11.ParameterName = "@11"; p5.Value = 0; sqlCmd.Parameters.Add(p11);
                    SQLiteParameter p12 = new SQLiteParameter(); p12.ParameterName = "@12"; p6.Value = ""; sqlCmd.Parameters.Add(p12);
                    SQLiteParameter p13 = new SQLiteParameter(); p13.ParameterName = "@13"; p7.Value = DateTime.Parse("2000-01-01 00:00:00"); ; sqlCmd.Parameters.Add(p13);
                    SQLiteParameter p14 = new SQLiteParameter(); p14.ParameterName = "@14"; p8.Value = DateTime.Parse("2000-01-01 00:00:00"); ; sqlCmd.Parameters.Add(p14);
                    SQLiteParameter p15 = new SQLiteParameter(); p15.ParameterName = "@15"; p9.Value = DateTime.Parse("2000-01-01 00:00:00"); sqlCmd.Parameters.Add(p15);
                    SQLiteParameter p16 = new SQLiteParameter(); p16.ParameterName = "@10"; p10.Value = findstring; sqlCmd.Parameters.Add(p16);
                    sqlCmd.ExecuteNonQuery();
                    dbcDa.Close();
                }

                // Zoek toegevoegde record
                tblIl il = new tblIl();
                il.zoekInstellingenRecord("Instl_Opmerking = " + "\"" + findstring + "\"");
                newIlId = il.lstInstellingenRecord[0].Instl_Id;

                // Verwijder infor uit Opmerking-veld
                dbcDa.Open();
                sqlStr = "Update Instellingen set Instl_Opmerking=@8 where Instl_Id = @1;";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    sqlCmd.Parameters.AddWithValue("@1", newIlId);
                    sqlCmd.Parameters.AddWithValue("@8", "");
                    sqlCmd.ExecuteNonQuery();
                }
                dbcDa.Close();


                return newIlId;
            }
        }
        public void saveRecord(int iIlId, ilRecord ilR)
        {
            string sqlStr = "Update Instellingen (Instl_Systeemsetting=@2, Instl_StatusId=@3, Instl_DispStatus=@4, Instl_Naam=@5, " +
                            "Instl_Gegtype=@6, Instl_Actief=@7, Instl_String=@8, Instl_JN=@9, Instl_Integer=@10, Instl_Real=@11, " +
                            "Instl_Memo=@12, Instl_Datum=@13, Instl_Tijd=@14, Instl_Mutatiedatum=@15, Instl_Opmerking=@15 Where Instl_Id=@1";

            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", iIlId);
                        sqlCmd.Parameters.AddWithValue("@2", ilR.Instl_Systeemsetting);
                        sqlCmd.Parameters.AddWithValue("@3", ilR.Instl_StatusId);
                        sqlCmd.Parameters.AddWithValue("@4", ilR.Instl_DispStatus);
                        sqlCmd.Parameters.AddWithValue("@5", ilR.Instl_Naam);
                        sqlCmd.Parameters.AddWithValue("@6", ilR.Instl_Gegtype);
                        sqlCmd.Parameters.AddWithValue("@7", ilR.Instl_Actief);
                        sqlCmd.Parameters.AddWithValue("@8", ilR.Instl_String);
                        sqlCmd.Parameters.AddWithValue("@9", ilR.Instl_JN);
                        sqlCmd.Parameters.AddWithValue("@10", ilR.Instl_Integer);
                        sqlCmd.Parameters.AddWithValue("@11", ilR.Instl_Real);
                        sqlCmd.Parameters.AddWithValue("@12", ilR.Instl_Memo);
                        sqlCmd.Parameters.AddWithValue("@13", ilR.Instl_Datum);
                        sqlCmd.Parameters.AddWithValue("@14", ilR.Instl_Tijd);
                        sqlCmd.Parameters.AddWithValue("@15", ilR.Instl_Mutatiedatum);
                        sqlCmd.Parameters.AddWithValue("@16", ilR.Instl_Opmerking);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception) { }

                dbcDa.Close();
            }
        }

        public void deleteRecord(int iIlId)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    string sqlStr = "Delete from Instellingen Where Instl_Id=@1;";
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", iIlId);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (SystemException ex)
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("Fout bij verwijderen van een instelling: {0}", ex.Message));
                }
            }
        }
    }
}
