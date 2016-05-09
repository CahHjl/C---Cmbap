using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using globalVars;
using ProcFunc;
namespace nsTblBg
{
    class tblBg
    {
        public struct bgRecord
        {
            public int Bgnr_Id { get; set; }
            public int Bgnr_StatusId { get; set; }
            public string Bgnr_DispStatus { get; set; }
            public int Bgnr_SysteemBgnrJN { get; set; }
            public int Bgnr_KlBgId { get; set; }
            public string Bgnr_DispKlBg { get; set; }
            public string Bgnr_Tnv { get; set; }
            public string Bgnr_Kort { get; set; }
            public string Bgnr_Iban { get; set; }
            public string Bgnr_IbanBankGiroKas { get; set; }
            public DateTime Bgnr_Mutatiedatum { get; set; }
            public string Bgnr_Opmerking { get; set; }
        }

            public List<bgRecord> lstBankgironrRecord = new List<bgRecord>();
            public int bgListCount;
            public int bgListTCount;

            public void zoekBankgironrRecord(string sZoekarg)
            {
                string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

                using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
                {
                    dbcDa.Open();

                    // Zoek record in Bankgironrtabel met extra zoekargument
                    string sqlStr;
                    if (sZoekarg != "")
                    {
                        sqlStr = "Select * from Bankgironr Where " + sZoekarg + ";";
                    }
                    else
                    {
                        sqlStr = "Select * from Bankgironr;";
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

            public int telBankgironrRecord(string sZoekarg)
            {
                string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

                using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
                {
                    dbcDa.Open();

                    // Zoek record in Bankgironrtablel met extra zoekargument
                    string sqlStr;
                    if (sZoekarg != "")
                    {
                        sqlStr = "Select * from Bankgironr Where " + sZoekarg + ";";
                    }
                    else
                    {
                        sqlStr = "Select * from Bankgironr";
                    }
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        using (SQLiteDataReader sqlRdr = sqlCmd.ExecuteReader())
                        {
                            bgListCount = 0;
                            bgListTCount = 0;
                            while (sqlRdr.Read())
                            {
                                //get rows
                                bgListTCount++;
                                if (sqlRdr.GetInt32(sqlRdr.GetOrdinal("Bgnr_StatusId")) != 110009)
                                {
                                    bgListCount++;
                                }
                            }
                        }
                    }
                    dbcDa.Close();
                    return bgListCount;
                }
            }

            private void recordsInList(SQLiteDataReader r)
            {
                bgRecord bgr = new bgRecord();

                lstBankgironrRecord.Clear();
                bgListCount = 0;
                bgListTCount = 0;

                while (r.Read())
                {
                    //Maak list van geselecteerde rijen

                    bgListTCount++;
                    bgr.Bgnr_Id = r.GetInt32(r.GetOrdinal("Bgnr_Id"));
                    bgr.Bgnr_StatusId = r.GetInt32(r.GetOrdinal("Bgnr_StatusId"));
                    bgr.Bgnr_DispStatus = r.GetString(r.GetOrdinal("Bgnr_DispStatus"));
                    if (r.GetInt32(r.GetOrdinal("Bgnr_StatusId")) != 110009)
                    {
                        bgListCount++;
                    }
                    bgr.Bgnr_SysteemBgnrJN = r.GetInt32(r.GetOrdinal("Bgnr_SysteemBgnrJN"));
                    bgr.Bgnr_KlBgId = r.GetInt32(r.GetOrdinal("Bgnr_KlBgId"));
                    bgr.Bgnr_DispKlBg = r.GetString(r.GetOrdinal("Bgnr_DispKlBg"));
                    bgr.Bgnr_Tnv = r.GetString(r.GetOrdinal("Bgnr_Tnv"));
                    bgr.Bgnr_Kort = r.GetString(r.GetOrdinal("Bgnr_Kort"));
                    bgr.Bgnr_Iban = r.GetString(r.GetOrdinal("Bgnr_Iban"));
                    bgr.Bgnr_IbanBankGiroKas = r.GetString(r.GetOrdinal("Bgnr_IbanBankGiroKas"));
                    bgr.Bgnr_Mutatiedatum = r.GetDateTime(r.GetOrdinal("Bgnr_Mutatiedatum"));
                    bgr.Bgnr_Opmerking = "";
                    try
                    {
                        bgr.Bgnr_Opmerking = r.GetString(r.GetOrdinal("Bgnr_Opmerking"));
                    }
                    catch (Exception)
                    {
                    }
                    lstBankgironrRecord.Add(bgr);
                }

            }

            public bgRecord vanRecord(int recNr)
            {
                bgRecord bgRec = new bgRecord();
                bgRec.Bgnr_Id = lstBankgironrRecord[recNr].Bgnr_Id;
                bgRec.Bgnr_StatusId = lstBankgironrRecord[recNr].Bgnr_StatusId;
                bgRec.Bgnr_DispStatus = lstBankgironrRecord[recNr].Bgnr_DispStatus;
                bgRec.Bgnr_SysteemBgnrJN = lstBankgironrRecord[recNr].Bgnr_SysteemBgnrJN;
                bgRec.Bgnr_KlBgId = lstBankgironrRecord[recNr].Bgnr_KlBgId;
                bgRec.Bgnr_DispKlBg = lstBankgironrRecord[recNr].Bgnr_DispKlBg;
                bgRec.Bgnr_Tnv = lstBankgironrRecord[recNr].Bgnr_Tnv;
                bgRec.Bgnr_Kort = lstBankgironrRecord[recNr].Bgnr_Kort;
                bgRec.Bgnr_Iban = lstBankgironrRecord[recNr].Bgnr_Iban;
                bgRec.Bgnr_IbanBankGiroKas = lstBankgironrRecord[recNr].Bgnr_IbanBankGiroKas;
                bgRec.Bgnr_Mutatiedatum = lstBankgironrRecord[recNr].Bgnr_Mutatiedatum;
                bgRec.Bgnr_Opmerking = lstBankgironrRecord[recNr].Bgnr_Opmerking;
                return bgRec;
            }

            public bgRecord vulDefaultBg()
            {
                pf pf = new pf();
                bgRecord bgRec = new bgRecord();
                bgRec.Bgnr_StatusId = 110009;
                bgRec.Bgnr_DispStatus = "Bankgironummer-record is leeg / Tabel-initrecord";
                bgRec.Bgnr_SysteemBgnrJN = 0;
                bgRec.Bgnr_KlBgId = 1;
                bgRec.Bgnr_DispKlBg="Klant-Begunstigde";
                bgRec.Bgnr_Tnv = "";
                bgRec.Bgnr_Kort = "000000000";
                bgRec.Bgnr_Iban = "NL59ONBB0000000000";
                bgRec.Bgnr_IbanBankGiroKas="I";
                bgRec.Bgnr_Mutatiedatum = DateTime.Parse("2000-01-01 00:00:00");
                bgRec.Bgnr_Opmerking = "";
                return bgRec;
            }

            public int newBgRecord()
            {
                pf pf = new pf();
                bgRecord dBg = new bgRecord();
                dBg = vulDefaultBg();
                int newBgId = new int();
                string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

                using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
                {
                    dbcDa.Open();
                    string findstring = pf.randomString(6);
                    string sqlStr = "Insert Into Bankgironr (Bgnr_StatusId, Bgnr_DispStatus, Bgnr_SysteemBgnrJN, Bgnr_KlBgId, Bgnr_DispKlBg, " +
                                    "Bgnr_Tnv, Bgnr_Kort, Bgnr_Iban, Bgnr_IbanBankGiroKas, Bgnr_Mutatiedatum, Bgnr_Opmerking) Values " +
                                    "(@2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12)";
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        SQLiteParameter p2 = new SQLiteParameter(); p2.ParameterName = "@2"; p2.Value = 110009; sqlCmd.Parameters.Add(p2);
                        SQLiteParameter p3 = new SQLiteParameter(); p3.ParameterName = "@3"; p3.Value = "Bankgironr-record is zijn leeg / Tabelinitrecord"; sqlCmd.Parameters.Add(p3);
                        SQLiteParameter p4 = new SQLiteParameter(); p4.ParameterName = "@4"; p4.Value = 0; sqlCmd.Parameters.Add(p4);
                        SQLiteParameter p5 = new SQLiteParameter(); p5.ParameterName = "@5"; p5.Value = 1; sqlCmd.Parameters.Add(p5);
                        SQLiteParameter p6 = new SQLiteParameter(); p6.ParameterName = "@6"; p6.Value = "Klant-Begunstigde"; sqlCmd.Parameters.Add(p6);
                        SQLiteParameter p7 = new SQLiteParameter(); p7.ParameterName = "@7"; p7.Value = ""; sqlCmd.Parameters.Add(p7);
                        SQLiteParameter p8 = new SQLiteParameter(); p8.ParameterName = "@8"; p8.Value = "000000000"; sqlCmd.Parameters.Add(p8);
                        SQLiteParameter p9 = new SQLiteParameter(); p9.ParameterName = "@9"; p9.Value = "NL59ONBB0000000000"; sqlCmd.Parameters.Add(p9);
                        SQLiteParameter p10 = new SQLiteParameter(); p10.ParameterName = "@10"; p10.Value = "I"; sqlCmd.Parameters.Add(p10);
                        SQLiteParameter p11 = new SQLiteParameter(); p11.ParameterName = "@11"; p11.Value = DateTime.Parse("2000-01-01 00:00:00"); sqlCmd.Parameters.Add(p11);
                        SQLiteParameter p12 = new SQLiteParameter(); p12.ParameterName = "@12"; p12.Value = findstring; sqlCmd.Parameters.Add(p12);
                        sqlCmd.ExecuteNonQuery();
                        dbcDa.Close();
                    }

                    // Zoek toegevoegde record
                    tblBg bg = new tblBg();
                    bg.zoekBankgironrRecord("Bgnr_Opmerking = " + "\"" + findstring + "\"");
                    newBgId = bg.lstBankgironrRecord[0].Bgnr_Id;

                    // Verwijder infor uit Opmerking-veld
                    dbcDa.Open();
                    sqlStr = "Update Bankgironr set Bgnr_Opmerking=@8 where Bgnr_Id = @1;";
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", newBgId);
                        sqlCmd.Parameters.AddWithValue("@8", "");
                        sqlCmd.ExecuteNonQuery();
                    }
                    dbcDa.Close();


                    return newBgId;
                }
            }

            public void saveRecord(int iBgId, bgRecord bgR)
            {

                string sqlStr = "Update Bankgironr set Bgnr_StatusId=@2, Bgnr_DispStatus=@3, Bgnr_SysteemBgnrJN=@4, Bgnr_KlBgId=@5, Bgnr_DispKlBg=@6, " +
                                "Bgnr_Tnv=@7, Bgnr_Kort=@8, Bgnr_Iban=@9, Bgnr_IbanBankGiroKas=@10, Bgnr_Mutatiedatum=@11, Bgnr_Opmerking=@12 Where Bgnr_Id=@1";
            
                string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
                using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
                {
                    dbcDa.Open();
                    try
                    {
                        using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                        {
                            sqlCmd.Parameters.AddWithValue("@1", iBgId);
                            sqlCmd.Parameters.AddWithValue("@2", bgR.Bgnr_StatusId);
                            sqlCmd.Parameters.AddWithValue("@3", bgR.Bgnr_DispStatus);
                            sqlCmd.Parameters.AddWithValue("@4", bgR.Bgnr_SysteemBgnrJN);
                            sqlCmd.Parameters.AddWithValue("@5", bgR.Bgnr_KlBgId);
                            sqlCmd.Parameters.AddWithValue("@6", bgR.Bgnr_DispKlBg);
                            sqlCmd.Parameters.AddWithValue("@7", bgR.Bgnr_Tnv);
                            sqlCmd.Parameters.AddWithValue("@8", bgR.Bgnr_Kort);
                            sqlCmd.Parameters.AddWithValue("@9", bgR.Bgnr_Iban);
                            sqlCmd.Parameters.AddWithValue("@10", bgR.Bgnr_IbanBankGiroKas);
                            sqlCmd.Parameters.AddWithValue("@11", bgR.Bgnr_Mutatiedatum);
                            sqlCmd.Parameters.AddWithValue("@12", bgR.Bgnr_Opmerking);
                            sqlCmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception) { }

                    dbcDa.Close();
                }
            }

            public void deleteRecord(int iBgId)
            {
                string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
                using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
                {
                    dbcDa.Open();
                    try
                    {
                        string sqlStr = "Delete from Bankgironr Where Bgnr_Id=@1;";
                        using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                        {
                            sqlCmd.Parameters.AddWithValue("@1", iBgId);
                            sqlCmd.ExecuteNonQuery();
                        }
                    }
                    catch (SystemException ex)
                    {
                        System.Windows.Forms.MessageBox.Show(string.Format("Fout bij verwijderen van een bankgironummer: {0}", ex.Message));
                    }
                }
            }
        }
    }

