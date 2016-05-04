using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using globalVars;
using ProcFunc;

namespace nsTblPd
{
    public class tblPd
    {
        public struct pdRecord
        {
            public int Prod_Id { get; set; }
            public int Prod_StatusId { get; set; }
            public string Prod_DispStatus { get; set; }
            public string Prod_Naamkort { get; set; }
            public string Prod_Naamlang { get; set; }
            public string Prod_Kleur { get; set; }
            public string Prod_Code { get; set; }
            public string Prod_Soort { get; set; }
            public int Prod_ActiefJN { get; set; }
            public string Prod_Dispactief { get; set; }
            public decimal Prod_Waarde { get; set; }
            public byte Prod_Aantaleenhedenperproduct { get; set; }
            public string Prod_Verzamelnaam { get; set; }
            public decimal Prod_Waardepereenheid { get; set; }
            public DateTime Prod_Mutatiedatum { get; set; }
            public string Prod_Opmerking { get; set; }
        }

        public List<pdRecord> lstProductRecord = new List<pdRecord>();
        public int pdListCount;
        public int pdListTCount;

        public void zoekProductRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Producttabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Product Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Product;";
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

        public int telProductRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Producttabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Product Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Product;";
                }
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    using (SQLiteDataReader sqlRdr = sqlCmd.ExecuteReader())
                    {
                        pdListCount = 0;
                        pdListTCount = 0;
                        while (sqlRdr.Read())
                        {
                            //get rows
                            pdListTCount++;
                            if (sqlRdr.GetInt32(sqlRdr.GetOrdinal("Prod_StatusId")) != 170009)
                            {
                                pdListCount++;
                            }
                        }
                    }
                }
                dbcDa.Close();
                return pdListCount;
            }
        }


        private void recordsInList(SQLiteDataReader r)
        {
            pdRecord pdr = new pdRecord();

            lstProductRecord.Clear();
            pdListCount = 0;
            pdListTCount = 0;

            while (r.Read())
            {
                //Maak list van geselecteerde rijen

                pdListTCount++;
                pdr.Prod_Id = r.GetInt32(r.GetOrdinal("Prod_Id"));
                pdr.Prod_StatusId = r.GetInt32(r.GetOrdinal("Prod_StatusId"));
                pdr.Prod_DispStatus = r.GetString(r.GetOrdinal("Prod_DispStatus"));
                if (r.GetInt32(r.GetOrdinal("Prod_StatusId")) != 170009)
                {
                    pdListCount++;
                }
                pdr.Prod_Naamkort = r.GetString(r.GetOrdinal("Prod_Naamkort"));
                pdr.Prod_Naamlang = r.GetString(r.GetOrdinal("Prod_Naamlang"));
                pdr.Prod_Kleur = r.GetString(r.GetOrdinal("Prod_Kleur"));
                pdr.Prod_Code = r.GetString(r.GetOrdinal("Prod_Code"));
                pdr.Prod_Soort = r.GetString(r.GetOrdinal("Prod_Soort"));
                pdr.Prod_ActiefJN = r.GetInt16(r.GetOrdinal("Prod_ActiefJN"));
                pdr.Prod_Dispactief = r.GetString(r.GetOrdinal("Prod_Dispactief"));
                pdr.Prod_Waarde = r.GetDecimal(r.GetOrdinal("Prod_Waarde"));
                pdr.Prod_Aantaleenhedenperproduct = r.GetByte(r.GetOrdinal("Prod_Aantaleenhedenperproduct"));
                pdr.Prod_Verzamelnaam = r.GetString(r.GetOrdinal("Prod_Verzamelnaam"));
                pdr.Prod_Waardepereenheid = r.GetDecimal(r.GetOrdinal("Prod_Waardepereenheid"));
                pdr.Prod_Mutatiedatum = r.GetDateTime(r.GetOrdinal("Prod_Mutatiedatum"));
                pdr.Prod_Opmerking = "";
                try
                {
                    pdr.Prod_Opmerking = r.GetString(r.GetOrdinal("Prod_Opmerking"));
                }
                catch (Exception)
                {
                }
                lstProductRecord.Add(pdr);
            }

        }

        public pdRecord vanRecord(int recNr)
        {
            pdRecord pdRec = new pdRecord();
            pdRec.Prod_Id = lstProductRecord[recNr].Prod_Id;
            pdRec.Prod_StatusId = lstProductRecord[recNr].Prod_StatusId;
            pdRec.Prod_DispStatus = lstProductRecord[recNr].Prod_DispStatus;
            pdRec.Prod_Naamkort = lstProductRecord[recNr].Prod_Naamkort;
            pdRec.Prod_Naamlang = lstProductRecord[recNr].Prod_Naamlang;
            pdRec.Prod_Kleur = lstProductRecord[recNr].Prod_Kleur;
            pdRec.Prod_Code = lstProductRecord[recNr].Prod_Code;
            pdRec.Prod_Soort = lstProductRecord[recNr].Prod_Soort;
            pdRec.Prod_ActiefJN = lstProductRecord[recNr].Prod_ActiefJN;
            pdRec.Prod_Dispactief = lstProductRecord[recNr].Prod_Dispactief;
            pdRec.Prod_Waarde = lstProductRecord[recNr].Prod_Waarde;
            pdRec.Prod_Aantaleenhedenperproduct = lstProductRecord[recNr].Prod_Aantaleenhedenperproduct;
            pdRec.Prod_Verzamelnaam = lstProductRecord[recNr].Prod_Verzamelnaam;
            pdRec.Prod_Waardepereenheid = lstProductRecord[recNr].Prod_Waardepereenheid;
            pdRec.Prod_Mutatiedatum = lstProductRecord[recNr].Prod_Mutatiedatum;
            pdRec.Prod_Opmerking = lstProductRecord[recNr].Prod_Opmerking;
            return pdRec;
        }

        public pdRecord vulDefaultPd()
        {
            pf pf = new pf();
            pdRecord pdRec = new pdRecord();
            pdRec.Prod_StatusId = 170009;
            pdRec.Prod_DispStatus = "Product-record is leeg / Tabelinitrecord";
            pdRec.Prod_Naamkort = "Prod_kort";
            pdRec.Prod_Naamlang = "Prod_lang";
            pdRec.Prod_Kleur = "Kleur";
            pdRec.Prod_Code = "Prod_code";
            pdRec.Prod_Soort = "B";
            pdRec.Prod_ActiefJN = 0;
            pdRec.Prod_Dispactief = "Nee";
            pdRec.Prod_Waarde = 0;
            pdRec.Prod_Aantaleenhedenperproduct = 20;
            pdRec.Prod_Verzamelnaam = "vel";
            pdRec.Prod_Waardepereenheid = 0;
            pdRec.Prod_Mutatiedatum = DateTime.Parse("2000-01-01 00:00:00");
            pdRec.Prod_Opmerking = ""; 
            return pdRec;
        }

        public int newPdRecord()
        {
            pf pf = new pf();
            pdRecord dPd = new pdRecord();
            dPd = vulDefaultPd();
            int newPdId = new int();
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                string findstring = pf.randomString(6);
                string sqlStr = "Insert Into Product (Prod_StatusId, Prod_DispStatus, Prod_Naamkort, Prod_Naamlang, " +
                                "Prod_Kleur, Prod_Code, Prod_Soort, Prod_ActiefJN, Prod_Dispactief, Prod_Waarde, " +
                                "Prod_Aantaleenhedenperproduct, Prod_Verzamelnaam, Prod_Waardepereenheid, Prod_Mutatiedatum, " +
                                "Prod_Opmerking) Values (@2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16)";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    SQLiteParameter p2 = new SQLiteParameter(); p2.ParameterName = "@2"; p2.Value = 170009; sqlCmd.Parameters.Add(p2);
                    SQLiteParameter p3 = new SQLiteParameter(); p3.ParameterName = "@3"; p3.Value = "Product-record is leeg / Tabelinitrecord"; sqlCmd.Parameters.Add(p3);
                    SQLiteParameter p4 = new SQLiteParameter(); p4.ParameterName = "@4"; p4.Value = "Prod_kort"; sqlCmd.Parameters.Add(p4);
                    SQLiteParameter p5 = new SQLiteParameter(); p5.ParameterName = "@5"; p5.Value = "Prod_lang"; sqlCmd.Parameters.Add(p5);
                    SQLiteParameter p6 = new SQLiteParameter(); p6.ParameterName = "@6"; p6.Value = "Kleur"; sqlCmd.Parameters.Add(p6);
                    SQLiteParameter p7 = new SQLiteParameter(); p7.ParameterName = "@7"; p7.Value = "Prod_code"; sqlCmd.Parameters.Add(p7);
                    SQLiteParameter p8 = new SQLiteParameter(); p8.ParameterName = "@8"; p8.Value = "B"; sqlCmd.Parameters.Add(p8);
                    SQLiteParameter p9 = new SQLiteParameter(); p9.ParameterName = "@9"; p9.Value = 0; sqlCmd.Parameters.Add(p9);
                    SQLiteParameter p10 = new SQLiteParameter(); p10.ParameterName = "@10"; p10.Value = "Nee"; sqlCmd.Parameters.Add(p10);
                    SQLiteParameter p11 = new SQLiteParameter(); p11.ParameterName = "@11"; p11.Value = 0; sqlCmd.Parameters.Add(p11);
                    SQLiteParameter p12 = new SQLiteParameter(); p12.ParameterName = "@12"; p12.Value = 20; sqlCmd.Parameters.Add(p12);
                    SQLiteParameter p13 = new SQLiteParameter(); p13.ParameterName = "@13"; p13.Value = "vel"; sqlCmd.Parameters.Add(p13);
                    SQLiteParameter p14 = new SQLiteParameter(); p14.ParameterName = "@14"; p14.Value = 0; sqlCmd.Parameters.Add(p14);
                    SQLiteParameter p15 = new SQLiteParameter(); p15.ParameterName = "@15"; p15.Value = DateTime.Parse("2000-01-01 00:00:00"); sqlCmd.Parameters.Add(p15);
                    SQLiteParameter p16 = new SQLiteParameter(); p16.ParameterName = "@16"; p16.Value = findstring; sqlCmd.Parameters.Add(p16);
                    sqlCmd.ExecuteNonQuery();
                    dbcDa.Close();
                }

                // Zoek toegevoegde record
                tblPd pd = new tblPd();
                pd.zoekProductRecord("Prod_Opmerking = " + "\"" + findstring + "\"");
                newPdId = pd.lstProductRecord[0].Prod_Id;

                // Verwijder infor uit Opmerking-veld
                dbcDa.Open();
                sqlStr = "Update Product set Prod_Opmerking=@16 where Prod_Id = @1;";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {  
                    sqlCmd.Parameters.AddWithValue("@1", newPdId);
                    sqlCmd.Parameters.AddWithValue("@16", "");
                    sqlCmd.ExecuteNonQuery();
                }
                dbcDa.Close();


                return newPdId;
            }
        }

        public void saveRecord(int iPdId, pdRecord pdR)
        {
            string sqlStr = "Update Product set Prod_StatusId=@2, Prod_DispStatus=@3, Prod_Naamkort=@4, Prod_Naamlang=@5, " +
                            "Prod_Kleur=@6, Prod_Code=@7, Prod_Soort=@8, Prod_ActiefJN=@9, Prod_Dispactief=@10, Prod_Waarde=@11, " +
                            "Prod_Aantaleenhedenperproduct=@12, Prod_Verzamelnaam=@13, Prod_Waardepereenheid=@14, Prod_Mutatiedatum=@15, " +
                            "Prod_Opmerking=@16 Where Prod_Id=@1";

            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", iPdId);
                        sqlCmd.Parameters.AddWithValue("@2", pdR.Prod_StatusId);
                        sqlCmd.Parameters.AddWithValue("@3", pdR.Prod_DispStatus);
                        sqlCmd.Parameters.AddWithValue("@4", pdR.Prod_Naamkort);
                        sqlCmd.Parameters.AddWithValue("@5", pdR.Prod_Naamlang);
                        sqlCmd.Parameters.AddWithValue("@6", pdR.Prod_Kleur);
                        sqlCmd.Parameters.AddWithValue("@7", pdR.Prod_Code);
                        sqlCmd.Parameters.AddWithValue("@8", pdR.Prod_Soort);
                        sqlCmd.Parameters.AddWithValue("@9", pdR.Prod_ActiefJN);
                        sqlCmd.Parameters.AddWithValue("@10", pdR.Prod_Dispactief);
                        sqlCmd.Parameters.AddWithValue("@11", pdR.Prod_Waarde);
                        sqlCmd.Parameters.AddWithValue("@12", pdR.Prod_Aantaleenhedenperproduct);
                        sqlCmd.Parameters.AddWithValue("@13", pdR.Prod_Verzamelnaam);
                        sqlCmd.Parameters.AddWithValue("@14", pdR.Prod_Waardepereenheid);
                        sqlCmd.Parameters.AddWithValue("@15", pdR.Prod_Mutatiedatum);
                        sqlCmd.Parameters.AddWithValue("@16", pdR.Prod_Opmerking);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception) { }

                dbcDa.Close();
            }
        }

        public void deleteRecord(int iPdId)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    string sqlStr = "Delete from Product Where Prod_Id=@1;";
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", iPdId);
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
