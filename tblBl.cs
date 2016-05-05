using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SQLite;
using ProcFunc;
using globalVars;

namespace nsTblBl
{
    class tblBl
    {
        public struct blRecord
        {
            public int Bstlr_Id { get; set; }
            public int Bstlr_BstlId { get; set; }
            public int Bstlr_StatusId { get; set; }
            public string Bstlr_DispStatus { get; set; }
            public int Bstlr_ProdId { get; set; }
            public string Bstlr_DispProduct { get; set; }
            public byte Bstlr_Aantal { get; set; }
            public long Bstlr_Beginnr { get; set; }
            public long Bstlr_Eindnr { get; set; }
            public long Bstlr_Voorraad { get; set; }
            public long Bstlr_Extranr1 { get; set; }
            public long Bstlr_Extranr2 { get; set; }
            public long Bstlr_Extranr3 { get; set; }
            public DateTime Bstlr_Mutatiedatum { get; set; }
            public string Bstlr_Opmerking { get; set; }
        }



        public List<blRecord> lstBestelregelRecord = new List<blRecord>();
        public int blListCount;
        public int blListTCount;

        public void zoekBestelregelRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Bestelregeltabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Bestelregel Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Bestelregel;";
                }

                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    using (SQLiteDataReader sqlrdr = sqlCmd.ExecuteReader())
                    {
                        recordsInList(sqlrdr);
                    }
                }
                dbcDa.Close();
            }
        }

        public int telBestelregelRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Bestelregeltabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Bestelregel Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Bestelregel;";
                }

                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    using (SQLiteDataReader sqlrdr = sqlCmd.ExecuteReader())
                    {
                        blListCount = 0;
                        blListTCount = 0;
                        while (sqlrdr.Read())
                        {
                            //get rows
                            blListTCount++;
                            if (sqlrdr.GetInt32(sqlrdr.GetOrdinal("Bstlr_StatusId")) != 135009)
                            {
                                blListCount++;
                            }
                        }

                    }
                }
                dbcDa.Close();
                return blListCount;
            }
        }

        private void recordsInList(SQLiteDataReader r)
        {
            blRecord blr = new blRecord();

            lstBestelregelRecord.Clear();
            blListCount = 0;
            blListTCount = 0;

            while (r.Read())
            {
                //Maak list van geselecteerde rijen
                blListTCount++;
                blr.Bstlr_Id = r.GetInt32(r.GetOrdinal("Bstlr_Id"));
                blr.Bstlr_BstlId = r.GetInt32(r.GetOrdinal("Bstlr_BstlId"));
                blr.Bstlr_StatusId = r.GetInt32(r.GetOrdinal("Bstlr_StatusId"));
                if (r.GetInt32(r.GetOrdinal("Bstlr_StatusId")) != 135009)
                {
                    blListCount++;
                }
                blr.Bstlr_DispStatus = r.GetString(r.GetOrdinal("Bstlr_DispStatus"));
                blr.Bstlr_ProdId = r.GetInt32(r.GetOrdinal("Bstlr_ProdId"));
                blr.Bstlr_DispProduct = r.GetString(r.GetOrdinal("Bstlr_DispProduct"));
                blr.Bstlr_Aantal = r.GetByte(r.GetOrdinal("Bstlr_Aantal"));
                blr.Bstlr_Beginnr = r.GetInt64(r.GetOrdinal("Bstlr_Beginnr"));
                blr.Bstlr_Eindnr = r.GetInt64(r.GetOrdinal("Bstlr_Eindnr"));
                blr.Bstlr_Voorraad = r.GetInt64(r.GetOrdinal("Bstlr_Voorraad"));
                blr.Bstlr_Extranr1 = r.GetInt64(r.GetOrdinal("Bstlr_Extranr1"));
                blr.Bstlr_Extranr2 = r.GetInt64(r.GetOrdinal("Bstlr_Extranr2"));
                blr.Bstlr_Extranr3 = r.GetInt64(r.GetOrdinal("Bstlr_Extranr3"));
                blr.Bstlr_Mutatiedatum = r.GetDateTime(r.GetOrdinal("Bstlr_Mutatiedatum"));
                try
                {
                    blr.Bstlr_Opmerking = r.GetString(r.GetOrdinal("Bstlr_Opmerking"));
                }
                catch (Exception)
                {
                }
                lstBestelregelRecord.Add(blr);
            }

        }

        public blRecord vanRecord(int recNr)
        {
            blRecord blRec = new blRecord();
            blRec.Bstlr_Id = lstBestelregelRecord[recNr].Bstlr_Id;
            blRec.Bstlr_BstlId = lstBestelregelRecord[recNr].Bstlr_BstlId;
            blRec.Bstlr_StatusId = lstBestelregelRecord[recNr].Bstlr_StatusId;
            blRec.Bstlr_DispStatus = lstBestelregelRecord[recNr].Bstlr_DispStatus;
            blRec.Bstlr_ProdId = lstBestelregelRecord[recNr].Bstlr_ProdId;
            blRec.Bstlr_DispProduct = lstBestelregelRecord[recNr].Bstlr_DispProduct;
            blRec.Bstlr_Aantal = lstBestelregelRecord[recNr].Bstlr_Aantal;
            blRec.Bstlr_Beginnr = lstBestelregelRecord[recNr].Bstlr_Beginnr;
            blRec.Bstlr_Eindnr = lstBestelregelRecord[recNr].Bstlr_Eindnr;
            blRec.Bstlr_Voorraad = lstBestelregelRecord[recNr].Bstlr_Voorraad;
            blRec.Bstlr_Extranr1 = lstBestelregelRecord[recNr].Bstlr_Extranr1;
            blRec.Bstlr_Extranr2 = lstBestelregelRecord[recNr].Bstlr_Extranr2;
            blRec.Bstlr_Extranr3 = lstBestelregelRecord[recNr].Bstlr_Extranr3;
            blRec.Bstlr_Mutatiedatum = lstBestelregelRecord[recNr].Bstlr_Mutatiedatum;
            blRec.Bstlr_Opmerking = lstBestelregelRecord[recNr].Bstlr_Opmerking;
            return blRec;
        }

        public blRecord vulDefaultBl()
        {
            pf pf = new pf();
            blRecord blRec = new blRecord();
            blRec.Bstlr_BstlId = 1;
            blRec.Bstlr_StatusId = 135009;
            blRec.Bstlr_DispStatus = "Bestelregel-record is leeg / Tabelinitrecord";
            blRec.Bstlr_StatusId = 1;
            blRec.Bstlr_DispStatus = "Productnaam";
            blRec.Bstlr_Aantal = 0;
            blRec.Bstlr_Beginnr = 0;
            blRec.Bstlr_Eindnr = 0;
            blRec.Bstlr_Voorraad = 0;
            blRec.Bstlr_Extranr1 = 0;
            blRec.Bstlr_Extranr2 = 0;
            blRec.Bstlr_Extranr3 = 0;
            blRec.Bstlr_Mutatiedatum = DateTime.Parse("2000-01-01 00:00:00");
            blRec.Bstlr_Opmerking = "";
            return blRec;
        }

        public int newBlRecord()
        {
            pf pf = new pf();
            blRecord dBl = new blRecord();
            dBl = vulDefaultBl();
            int newBlId = new int();
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                string findstring = pf.randomString(6);
                string sqlStr = "Insert Into Bestelregel (Bstlr_BstlId, Bstlr_StatusId, Bstlr_DispStatus, Bstlr_ProdId, Bstlr_DispProduct, " +
                                "Bstlr_Aantal, Bstlr_Beginnr, Bstlr_Eindnr, Bstlr_Voorraad, Bstlr_Extranr1, Bstlr_Extranr2, Bstlr_Extranr3, "+
                                "Bstlr_Mutatiedatum, Bstlr_Opmerking) Values (@2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15)";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    SQLiteParameter p2 = new SQLiteParameter(); p2.ParameterName = "@2"; p2.Value = 1; sqlCmd.Parameters.Add(p2);
                    SQLiteParameter p3 = new SQLiteParameter(); p3.ParameterName = "@3"; p3.Value = 135009; sqlCmd.Parameters.Add(p3);
                    SQLiteParameter p4 = new SQLiteParameter(); p4.ParameterName = "@4"; p4.Value = "Bestelregel-record is leeg / Tabelinitrecord"; sqlCmd.Parameters.Add(p4);
                    SQLiteParameter p5 = new SQLiteParameter(); p5.ParameterName = "@5"; p5.Value = 1; sqlCmd.Parameters.Add(p5);
                    SQLiteParameter p6 = new SQLiteParameter(); p6.ParameterName = "@6"; p6.Value = "Productnaam"; sqlCmd.Parameters.Add(p6);
                    SQLiteParameter p7 = new SQLiteParameter(); p7.ParameterName = "@7"; p7.Value = 0; sqlCmd.Parameters.Add(p7);
                    SQLiteParameter p8 = new SQLiteParameter(); p8.ParameterName = "@8"; p8.Value = 0; sqlCmd.Parameters.Add(p8);
                    SQLiteParameter p9 = new SQLiteParameter(); p9.ParameterName = "@9"; p9.Value = 0; sqlCmd.Parameters.Add(p9);
                    SQLiteParameter p10 = new SQLiteParameter(); p10.ParameterName = "@10"; p10.Value = 0; sqlCmd.Parameters.Add(p10);
                    SQLiteParameter p11 = new SQLiteParameter(); p11.ParameterName = "@11"; p11.Value = 0; sqlCmd.Parameters.Add(p11);
                    SQLiteParameter p12 = new SQLiteParameter(); p12.ParameterName = "@12"; p12.Value = 0; sqlCmd.Parameters.Add(p12);
                    SQLiteParameter p13 = new SQLiteParameter(); p13.ParameterName = "@13"; p13.Value = 0; sqlCmd.Parameters.Add(p13);
                    SQLiteParameter p14 = new SQLiteParameter(); p14.ParameterName = "@14"; p14.Value = DateTime.Parse("2000-01-01 00:00:00"); sqlCmd.Parameters.Add(p14);
                    SQLiteParameter p15 = new SQLiteParameter(); p15.ParameterName = "@15"; p15.Value = findstring; sqlCmd.Parameters.Add(p15);
                    sqlCmd.ExecuteNonQuery();
                    dbcDa.Close();
                }

                // Zoek toegevoegde record
                tblBl bl = new tblBl();
                bl.zoekBestelregelRecord("Bstlr_Opmerking = " + "\"" + findstring + "\"");
                newBlId = bl.lstBestelregelRecord[0].Bstlr_Id;

                // Verwijder infor uit Opmerking-veld
                dbcDa.Open();
                sqlStr = "Update Bestelregel set Bstlr_Opmerking=@16 where Bstlr_Id = @1;";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    sqlCmd.Parameters.AddWithValue("@1", newBlId);
                    sqlCmd.Parameters.AddWithValue("@16", "");
                    sqlCmd.ExecuteNonQuery();
                }
                dbcDa.Close();


                return newBlId;
            }
        }

        public void saveRecord(int iBlId, blRecord blR)
        {
            string sqlStr = "Update Bestelregel  set Bstlr_BstlId=@2, Bstlr_StatusId=@3, Bstlr_DispStatus=@4, Bstlr_ProdId=@5, Bstlr_DispProduct=@6, " +
                            "Bstlr_Aantal=@7, Bstlr_Beginnr=@8, Bstlr_Eindnr=@9, Bstlr_Voorraad=@10, Bstlr_Extranr1=@11, "+
                            "Bstlr_Extranr2=@12, Bstlr_Extranr3=@13, Bstlr_Mutatiedatum=@14, Bstlr_Opmerking=@15 Where Bstlr_Id=@1";

            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", iBlId);
                        sqlCmd.Parameters.AddWithValue("@2", blR.Bstlr_BstlId);
                        sqlCmd.Parameters.AddWithValue("@3", blR.Bstlr_StatusId);
                        sqlCmd.Parameters.AddWithValue("@4", blR.Bstlr_DispStatus);
                        sqlCmd.Parameters.AddWithValue("@5", blR.Bstlr_ProdId);
                        sqlCmd.Parameters.AddWithValue("@6", blR.Bstlr_DispProduct);
                        sqlCmd.Parameters.AddWithValue("@7", blR.Bstlr_Aantal);
                        sqlCmd.Parameters.AddWithValue("@8", blR.Bstlr_Beginnr);
                        sqlCmd.Parameters.AddWithValue("@9", blR.Bstlr_Eindnr);
                        sqlCmd.Parameters.AddWithValue("@10", blR.Bstlr_Voorraad);
                        sqlCmd.Parameters.AddWithValue("@11", blR.Bstlr_Extranr1);
                        sqlCmd.Parameters.AddWithValue("@12", blR.Bstlr_Extranr2);
                        sqlCmd.Parameters.AddWithValue("@13", blR.Bstlr_Extranr3);
                        sqlCmd.Parameters.AddWithValue("@14", blR.Bstlr_Mutatiedatum);
                        sqlCmd.Parameters.AddWithValue("@15", blR.Bstlr_Opmerking);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception) { }

                dbcDa.Close();
            }
        }

        public void deleteRecord(int iBlId)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    string sqlStr = "Delete from Bestelregel Where Bstlr_Id=@1;";
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", iBlId);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (SystemException ex)
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("Fout bij verwijderen van bestelregel: {0}", ex.Message));
                }
            }
        }


    }
}
