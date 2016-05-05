using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SQLite;
using ProcFunc;
using globalVars;

namespace nsTblBs
{
    class tblBs
    {
        public struct bsRecord
        {
            public int Bstl_Id { get; set; }
            public int Bstl_StatusId { get; set; }
            public string Bstl_DispStatus { get; set; }
            public int Bstl_BgnrId { get; set; }
            public string Bstl_DispBgnr { get; set; }
            public int Bstl_KlBgId { get; set; }
            public string Bstl_DispKlBg { get; set; }
            public int Bstl_VerwerkperiodeId { get; set; }
            public DateTime Bstl_valutadatum { get; set; }
            public decimal Bstl_Bestelbedrag { get; set; }
            public decimal Bstl_Diversen { get; set; }
            public int Bstl_DiversenId { get; set; }
            public string Bstl_DispDiversen { get; set; }
            public decimal Bstl_Verschil { get; set; }
            public int Bstl_VerschilId { get; set; }
            public string Bstl_DispVerschil { get; set; }
            public decimal Bstl_Vastekostenperbestelling { get; set; }
            public int Bstl_BonnengevraagdJN { get; set; }
            public DateTime Bstl_Mutatiedatum { get; set; }
            public string Bstl_Opmerking { get; set; }
        }

        public List<bsRecord> lstBestellingRecord = new List<bsRecord>();
        public int bsListCount;
        public int bsListTCount;

        public void zoekBestellingRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Bestellingtabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Bestelling Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Bestelling;";
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

        public int telBestellingRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Bestellingtabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Bestelling Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Bestelling;";
                }

                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    using (SQLiteDataReader sqlrdr = sqlCmd.ExecuteReader())
                    {
                        bsListCount = 0;
                        bsListTCount = 0;
                        while (sqlrdr.Read())
                        {
                            //get rows
                            bsListTCount++;
                            if (sqlrdr.GetInt32(sqlrdr.GetOrdinal("Bstl_StatusId")) != 120009)
                            {
                                bsListCount++;
                            }
                        }

                    }
                }
                dbcDa.Close();
                return bsListCount;
            }
        }

        private void recordsInList(SQLiteDataReader r)
        {
            bsRecord bsr = new bsRecord();

            lstBestellingRecord.Clear();
            bsListCount = 0;
            bsListTCount = 0;

            while (r.Read())
            {
                //Maak list van geselecteerde rijen
                bsListTCount++;
                bsr.Bstl_Id = r.GetInt32(r.GetOrdinal("Bstl_Id"));
                bsr.Bstl_StatusId = r.GetInt32(r.GetOrdinal("Bstl_StatusId"));
                if (r.GetInt32(r.GetOrdinal("Bstl_StatusId")) != 120009)
                {
                    bsListCount++;
                }
                bsr.Bstl_DispStatus = r.GetString(r.GetOrdinal("Bstl_DispStatus"));
                bsr.Bstl_BgnrId = r.GetInt32(r.GetOrdinal("Bstl_BgnrId"));
                bsr.Bstl_DispBgnr = r.GetString(r.GetOrdinal("Bstl_DispBgnr"));
                bsr.Bstl_KlBgId = r.GetInt32(r.GetOrdinal("Bstl_KlBgId"));
                bsr.Bstl_DispKlBg = r.GetString(r.GetOrdinal("Bstl_DispKlBg"));
                bsr.Bstl_VerwerkperiodeId = r.GetInt32(r.GetOrdinal("Bstl_VerwerkperiodeId"));
                bsr.Bstl_valutadatum = r.GetDateTime(r.GetOrdinal("Bstl_Valutadatum"));
                bsr.Bstl_Bestelbedrag = r.GetDecimal(r.GetOrdinal("Bstl_Bestelbedrag"));
                bsr.Bstl_Diversen = r.GetDecimal(r.GetOrdinal("Bstl_Diversen"));
                bsr.Bstl_DiversenId = r.GetInt32(r.GetOrdinal("Bstl_DiversenId"));
                bsr.Bstl_DispDiversen = r.GetString(r.GetOrdinal("Bstl_DispDiversen"));
                bsr.Bstl_Verschil = r.GetDecimal(r.GetOrdinal("Bstl_Verschil"));
                bsr.Bstl_VerschilId = r.GetInt32(r.GetOrdinal("Bstl_VerschilId"));
                bsr.Bstl_DispVerschil = r.GetString(r.GetOrdinal("Bstl_DispVerschil"));
                bsr.Bstl_Vastekostenperbestelling = r.GetDecimal(r.GetOrdinal("Bstl_Vastekostenperbestelling"));
                bsr.Bstl_BonnengevraagdJN = r.GetInt32(r.GetOrdinal("Bstl_BonnengevraagdJN"));
                bsr.Bstl_Mutatiedatum = r.GetDateTime(r.GetOrdinal("Bstl_Mutatiedatum"));
                try
                {
                    bsr.Bstl_Opmerking = r.GetString(r.GetOrdinal("Bstl_Opmerking"));
                }
                catch (Exception)
                {
                }
                lstBestellingRecord.Add(bsr);
            }

        }

        public bsRecord vanRecord(int recNr)
        {
            bsRecord bsRec = new bsRecord();
            bsRec.Bstl_Id = lstBestellingRecord[recNr].Bstl_Id;
            bsRec.Bstl_StatusId = lstBestellingRecord[recNr].Bstl_StatusId;
            bsRec.Bstl_DispStatus = lstBestellingRecord[recNr].Bstl_DispStatus;
            bsRec.Bstl_BgnrId = lstBestellingRecord[recNr].Bstl_BgnrId;
            bsRec.Bstl_DispBgnr = lstBestellingRecord[recNr].Bstl_DispBgnr;
            bsRec.Bstl_KlBgId = lstBestellingRecord[recNr].Bstl_KlBgId;
            bsRec.Bstl_DispKlBg = lstBestellingRecord[recNr].Bstl_DispKlBg;
            bsRec.Bstl_VerwerkperiodeId = lstBestellingRecord[recNr].Bstl_VerwerkperiodeId;
            bsRec.Bstl_valutadatum = lstBestellingRecord[recNr].Bstl_valutadatum;
            bsRec.Bstl_Bestelbedrag = lstBestellingRecord[recNr].Bstl_Bestelbedrag;
            bsRec.Bstl_Diversen = lstBestellingRecord[recNr].Bstl_Diversen;
            bsRec.Bstl_DiversenId = lstBestellingRecord[recNr].Bstl_DiversenId;
            bsRec.Bstl_DispDiversen = lstBestellingRecord[recNr].Bstl_DispDiversen;
            bsRec.Bstl_Verschil = lstBestellingRecord[recNr].Bstl_Verschil;
            bsRec.Bstl_VerschilId = lstBestellingRecord[recNr].Bstl_VerschilId;
            bsRec.Bstl_DispVerschil = lstBestellingRecord[recNr].Bstl_DispVerschil;
            bsRec.Bstl_Vastekostenperbestelling = lstBestellingRecord[recNr].Bstl_Vastekostenperbestelling;
            bsRec.Bstl_BonnengevraagdJN = lstBestellingRecord[recNr].Bstl_BonnengevraagdJN;
            bsRec.Bstl_Mutatiedatum = lstBestellingRecord[recNr].Bstl_Mutatiedatum;
            bsRec.Bstl_Opmerking = lstBestellingRecord[recNr].Bstl_Opmerking;
            return bsRec;
        }

        public bsRecord vulDefaultBs()
        {
            pf pf = new pf();
            bsRecord bsRec = new bsRecord();
            bsRec.Bstl_StatusId = 120009;
            bsRec.Bstl_DispStatus = "Bestelling-record is leeg / Tabelinitrecord";
            bsRec.Bstl_BgnrId = 1;
            bsRec.Bstl_DispBgnr = "NL59ONBB0000000000";
            bsRec.Bstl_KlBgId = 1;
            bsRec.Bstl_DispKlBg = "Klant-Begunstigde";
            bsRec.Bstl_VerwerkperiodeId = 1;
            bsRec.Bstl_valutadatum = DateTime.Parse("2000-01-01 00:00:00");
            bsRec.Bstl_Bestelbedrag = 0;
            bsRec.Bstl_Diversen = 0;
            bsRec.Bstl_DiversenId = 121009;
            bsRec.Bstl_DispDiversen = "Bstl_Div-Leeg";
            bsRec.Bstl_Verschil = 0;
            bsRec.Bstl_VerschilId = 122009;
            bsRec.Bstl_DispVerschil = "Bstl_Vschl-Leeg";
            bsRec.Bstl_Vastekostenperbestelling = 0;
            bsRec.Bstl_BonnengevraagdJN = 1;
            bsRec.Bstl_Mutatiedatum = DateTime.Parse("2000-01-01 00:00:00");
            bsRec.Bstl_Opmerking = "";
            return bsRec;
        }

        public int newbsRecord()
        {
            pf pf = new pf();
            bsRecord dbs = new bsRecord();
            dbs = vulDefaultBs();
            int newBsId = new int();
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                string findstring = pf.randomString(6);
                string sqlStr = "Insert Into Bestelling (Bstl_StatusId, Bstlr_DispStatus, Bstl_BgnrId, Bstl_DispBgnr, Bstl_KlBgId, Bstl_DispKlBg " +
                                "Bstl_Verwerkperiode, Bstl_Valutadatum, Bstl_Bestelbedrag, Bstl_Diversen, Bstl_DiversenId, Bstl_DispDiversen, Bstl_Verschil, " +
                                "Bstl_VerschilId, Bstl_DispVerschil, Bstl_Vastekostenperbestelling, Bstl_BonnengevraagdJN, Bstl_Mutatiedatum, Bstl_Opmerking) Values " +
                                "(@2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16, @17, @18, @19, @20)";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    SQLiteParameter p2 = new SQLiteParameter(); p2.ParameterName = "@2"; p2.Value = 120009; sqlCmd.Parameters.Add(p2);
                    SQLiteParameter p3 = new SQLiteParameter(); p3.ParameterName = "@3"; p3.Value = "Bestelling-record is leeg / Tabelinitrecord"; sqlCmd.Parameters.Add(p3);
                    SQLiteParameter p4 = new SQLiteParameter(); p4.ParameterName = "@4"; p4.Value = 1; sqlCmd.Parameters.Add(p4);
                    SQLiteParameter p5 = new SQLiteParameter(); p5.ParameterName = "@5"; p5.Value = "NL59ONBB0000000000"; sqlCmd.Parameters.Add(p5);
                    SQLiteParameter p6 = new SQLiteParameter(); p6.ParameterName = "@6"; p6.Value = 1; sqlCmd.Parameters.Add(p6);
                    SQLiteParameter p7 = new SQLiteParameter(); p7.ParameterName = "@7"; p7.Value = "Klant-Begunstigde"; sqlCmd.Parameters.Add(p7);
                    SQLiteParameter p8 = new SQLiteParameter(); p8.ParameterName = "@8"; p8.Value = 1; sqlCmd.Parameters.Add(p8);
                    SQLiteParameter p9 = new SQLiteParameter(); p9.ParameterName = "@9"; p9.Value = DateTime.Parse("2000-01-01 00:00:00"); sqlCmd.Parameters.Add(p9);
                    SQLiteParameter p10 = new SQLiteParameter(); p10.ParameterName = "@10"; p10.Value = 0; sqlCmd.Parameters.Add(p10);
                    SQLiteParameter p11 = new SQLiteParameter(); p11.ParameterName = "@11"; p11.Value = 0; sqlCmd.Parameters.Add(p11);
                    SQLiteParameter p12 = new SQLiteParameter(); p12.ParameterName = "@12"; p12.Value = 121009; sqlCmd.Parameters.Add(p12);
                    SQLiteParameter p13 = new SQLiteParameter(); p13.ParameterName = "@13"; p13.Value = "Bstl_Div-Leeg"; sqlCmd.Parameters.Add(p13);
                    SQLiteParameter p14 = new SQLiteParameter(); p14.ParameterName = "@14"; p14.Value = 0; sqlCmd.Parameters.Add(p11);
                    SQLiteParameter p15 = new SQLiteParameter(); p15.ParameterName = "@15"; p15.Value = 122009; sqlCmd.Parameters.Add(p12);
                    SQLiteParameter p16 = new SQLiteParameter(); p16.ParameterName = "@16"; p16.Value = "Bstl_Vschl-Leeg"; sqlCmd.Parameters.Add(p13);
                    SQLiteParameter p17 = new SQLiteParameter(); p17.ParameterName = "@17"; p17.Value = 0; sqlCmd.Parameters.Add(p17);
                    SQLiteParameter p18 = new SQLiteParameter(); p18.ParameterName = "@18"; p18.Value = 1; sqlCmd.Parameters.Add(p18);
                    SQLiteParameter p19 = new SQLiteParameter(); p19.ParameterName = "@19"; p19.Value = DateTime.Parse("2000-01-01 00:00:00"); sqlCmd.Parameters.Add(p19);
                    SQLiteParameter p20 = new SQLiteParameter(); p20.ParameterName = "@20"; p20.Value = findstring; sqlCmd.Parameters.Add(p20);
                    sqlCmd.ExecuteNonQuery();
                    dbcDa.Close();
                }

                // Zoek toegevoegde record
                tblBs bs = new tblBs();
                bs.zoekBestellingRecord("Bstl_Opmerking = " + "\"" + findstring + "\"");
                newBsId = bs.lstBestellingRecord[0].Bstl_Id;

                // Verwijder infor uit Opmerking-veld
                dbcDa.Open();
                sqlStr = "Update Bestelling set Bstl_Opmerking=@20 where Bstl_Id = @1;";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    sqlCmd.Parameters.AddWithValue("@1", newBsId);
                    sqlCmd.Parameters.AddWithValue("@20", "");
                    sqlCmd.ExecuteNonQuery();
                }
                dbcDa.Close();


                return newBsId;
            }
        }

        public void saveRecord(int iBsId, bsRecord bsR)
        {
            string sqlStr = "Update Bestelling (Bstl_StatusId=@2, Bstlr_DispStatus=@3, Bstl_BgnrId=@4, Bstl_DispBgnr=@5, Bstl_KlBgId=@6, " +
                            "Bstl_DispKlBg=@7, Bstl_VerwerkperiodeId=@8, Bstl_Valutadatum=@9, Bstl_Bestelbedrag=@10, Bstl_Diversen=@11, " +
                            "Bstl_DiversenId=@12, Bstl_DispDiversen=@13, Bstl_Verschil=@14, Bstl_VerschilId=@15, Bstl_DispVerschil=@16, " +
                            "Bstl_Vastekostenperbestelling=@17, Bstl_BonnengevraagdJN=@18, Bstl_Mutatiedatum=@19, Bstl_Opmerking=@20 "+
                            "Where Bstl_Id=@1";
            
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", iBsId);
                        sqlCmd.Parameters.AddWithValue("@2", bsR.Bstl_StatusId);
                        sqlCmd.Parameters.AddWithValue("@3", bsR.Bstl_DispStatus);
                        sqlCmd.Parameters.AddWithValue("@4", bsR.Bstl_BgnrId);
                        sqlCmd.Parameters.AddWithValue("@5", bsR.Bstl_DispBgnr);
                        sqlCmd.Parameters.AddWithValue("@6", bsR.Bstl_KlBgId);
                        sqlCmd.Parameters.AddWithValue("@7", bsR.Bstl_DispKlBg);
                        sqlCmd.Parameters.AddWithValue("@8", bsR.Bstl_VerwerkperiodeId);
                        sqlCmd.Parameters.AddWithValue("@9", bsR.Bstl_valutadatum);
                        sqlCmd.Parameters.AddWithValue("@10", bsR.Bstl_Bestelbedrag);
                        sqlCmd.Parameters.AddWithValue("@11", bsR.Bstl_DispDiversen);
                        sqlCmd.Parameters.AddWithValue("@12", bsR.Bstl_DiversenId);
                        sqlCmd.Parameters.AddWithValue("@13", bsR.Bstl_DispDiversen);
                        sqlCmd.Parameters.AddWithValue("@14", bsR.Bstl_Verschil);
                        sqlCmd.Parameters.AddWithValue("@15", bsR.Bstl_VerschilId);
                        sqlCmd.Parameters.AddWithValue("@16", bsR.Bstl_DispVerschil);
                        sqlCmd.Parameters.AddWithValue("@17", bsR.Bstl_Vastekostenperbestelling);
                        sqlCmd.Parameters.AddWithValue("@18", bsR.Bstl_BonnengevraagdJN);
                        sqlCmd.Parameters.AddWithValue("@19", bsR.Bstl_Mutatiedatum);
                        sqlCmd.Parameters.AddWithValue("@20", bsR.Bstl_Opmerking);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception) { }

                dbcDa.Close();
            }
        }

        public void deleteRecord(int iBsId)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    string sqlStr = "Delete from Bestelling Where Bstl_Id=@1;";
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", iBsId);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (SystemException ex)
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("Fout bij verwijderen van bestelling: {0}", ex.Message));
                }
            }
        }


    }
}
