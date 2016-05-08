using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using globalVars;
using ProcFunc;

namespace nsTblEa
{
    public class tblEa
    {
        public struct eaRecord
        {
            public int Ea_Id { get; set; }
            public int Ea_StatusId { get; set; }
            public string Ea_DispStatus { get; set; }
            public int Ea_KlBgId { get; set; }
            public string Ea_DispKlBg { get; set; }
            public string Ea_Emailadres { get; set; }
            public DateTime Ea_Mutatiedatum { get; set; }
            public string Ea_Opmerking { get; set; }
        }

        public List<eaRecord> lstEmailadresRecord = new List<eaRecord>();
        public int eaListCount;
        public int eaListTCount;

        public void zoekEmailadresRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Emailadrestabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Emailadres Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Emailadres;";
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

        public int telEmailadresRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Emailadrestabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Emailadres Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Emailadres;";
                }
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    using (SQLiteDataReader sqlRdr = sqlCmd.ExecuteReader())
                    {
                        eaListCount = 0;
                        eaListTCount = 0;
                        while (sqlRdr.Read())
                        {
                            //get rows
                            eaListTCount++;
                            if (sqlRdr.GetInt32(sqlRdr.GetOrdinal("Ea_StatusId")) != 200009)
                            {
                                eaListCount++;
                            }
                        }
                    }
                }
                dbcDa.Close();
                return eaListCount;
            }
        }

        private void recordsInList(SQLiteDataReader r)
        {
            eaRecord ear = new eaRecord();

            lstEmailadresRecord.Clear();
            eaListCount = 0;
            eaListTCount = 0;

            while (r.Read())
            {
                //Maak list van geselecteerde rijen

                eaListTCount++;
                ear.Ea_Id = r.GetInt32(r.GetOrdinal("Ea_Id"));
                ear.Ea_StatusId = r.GetInt32(r.GetOrdinal("Ea_StatusId"));
                ear.Ea_DispStatus = r.GetString(r.GetOrdinal("Ea_DispStatus"));
                if (r.GetInt32(r.GetOrdinal("Ea_StatusId")) != 200009)
                {
                    eaListCount++;
                }
                ear.Ea_KlBgId = r.GetInt32(r.GetOrdinal("Ea_KlBgId"));
                ear.Ea_DispKlBg = r.GetString(r.GetOrdinal("Ea_DispKlBg"));
                ear.Ea_Emailadres = r.GetString(r.GetOrdinal("Ea_Emailadres"));
                ear.Ea_Mutatiedatum = r.GetDateTime(r.GetOrdinal("Ea_Mutatiedatum"));
                ear.Ea_Opmerking = "";
                try
                {
                    ear.Ea_Opmerking = r.GetString(r.GetOrdinal("Ea_Opmerking"));
                }
                catch (Exception)
                {
                }
                lstEmailadresRecord.Add(ear);
            }

        }

        public eaRecord vanRecord(int recNr)
        {
            eaRecord eaRec = new eaRecord();
            eaRec.Ea_Id = lstEmailadresRecord[recNr].Ea_Id;
            eaRec.Ea_StatusId = lstEmailadresRecord[recNr].Ea_StatusId;
            eaRec.Ea_DispStatus = lstEmailadresRecord[recNr].Ea_DispStatus;
            eaRec.Ea_KlBgId = lstEmailadresRecord[recNr].Ea_KlBgId;
            eaRec.Ea_DispKlBg = lstEmailadresRecord[recNr].Ea_DispKlBg;
            eaRec.Ea_Emailadres = lstEmailadresRecord[recNr].Ea_Emailadres;
            eaRec.Ea_Mutatiedatum = lstEmailadresRecord[recNr].Ea_Mutatiedatum;
            eaRec.Ea_Opmerking = lstEmailadresRecord[recNr].Ea_Opmerking;
            return eaRec;
        }

        public eaRecord vulDefaultEa()
        {
            pf pf = new pf();
            eaRecord eaRec = new eaRecord();
            eaRec.Ea_StatusId = 170009;
            eaRec.Ea_DispStatus = "Emailadresgegevens zijn leeg / Tabelinitrecord";
            eaRec.Ea_KlBgId = 1;
            eaRec.Ea_DispKlBg = "Klant-Begunstigde";
            eaRec.Ea_Emailadres = "Emailadrs@Emailadrs.nl";
            eaRec.Ea_Mutatiedatum = DateTime.Parse("2000-01-01 00:00:00");
            eaRec.Ea_Opmerking = "";
            return eaRec;
        }

        public int newEaRecord()
        {
            pf pf = new pf();
            eaRecord dEa = new eaRecord();
            dEa = vulDefaultEa();
            int newEaId = new int();
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                string findstring = pf.randomString(6);
                string sqlStr = "Insert Into Emailadres (Ea_StatusId, Ea_DispStatus, Ea_KlBgId, Ea_DispKlBg, " +
                                "Ea_Emailadres, Ea_Mutatiedatum, Ea_Opmerking) Values (@2, @3, @4, @5, @6, @7, @8)";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    SQLiteParameter p2 = new SQLiteParameter(); p2.ParameterName = "@2"; p2.Value = 200009; sqlCmd.Parameters.Add(p2);
                    SQLiteParameter p3 = new SQLiteParameter(); p3.ParameterName = "@3"; p3.Value = "Emailadrs-record is zijn leeg / Tabelinitrecord"; sqlCmd.Parameters.Add(p3);
                    SQLiteParameter p4 = new SQLiteParameter(); p4.ParameterName = "@4"; p4.Value = 1; sqlCmd.Parameters.Add(p4);
                    SQLiteParameter p5 = new SQLiteParameter(); p5.ParameterName = "@5"; p5.Value = "Klant-Begunstigde"; sqlCmd.Parameters.Add(p5);
                    SQLiteParameter p6 = new SQLiteParameter(); p6.ParameterName = "@6"; p6.Value = "Emailadrs@Emailadrs.nl"; sqlCmd.Parameters.Add(p6);
                    SQLiteParameter p7 = new SQLiteParameter(); p7.ParameterName = "@7"; p7.Value = DateTime.Parse("2000-01-01 00:00:00"); sqlCmd.Parameters.Add(p7);
                    SQLiteParameter p8 = new SQLiteParameter(); p8.ParameterName = "@8"; p8.Value = findstring; sqlCmd.Parameters.Add(p8);
                    sqlCmd.ExecuteNonQuery();
                    dbcDa.Close();
                }

                // Zoek toegevoegde record
                tblEa ea = new tblEa();
                ea.zoekEmailadresRecord("Ea_Opmerking = " + "\"" + findstring + "\"");
                newEaId = ea.lstEmailadresRecord[0].Ea_Id;

                // Verwijder infor uit Opmerking-veld
                dbcDa.Open();
                sqlStr = "Update Emailadres set Ea_Opmerking=@8 where Ea_Id = @1;";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    sqlCmd.Parameters.AddWithValue("@1", newEaId);
                    sqlCmd.Parameters.AddWithValue("@8", "");
                    sqlCmd.ExecuteNonQuery();
                }
                dbcDa.Close();


                return newEaId;
            }
        }

        public void saveRecord(int iEaId, eaRecord eaR)
        {
            string sqlStr = "Update Emailadres set Ea_StatusId=@2, Ea_DispStatus=@3, Ea_KlBgId=@4, Ea_DispKlBg=@5, " +
                            "Ea_Emailadres=@6, Ea_Mutatiedatum=@7, Ea_Opmerking=@8 Where Ea_Id=@1;";


            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", iEaId);
                        sqlCmd.Parameters.AddWithValue("@2", eaR.Ea_StatusId);
                        sqlCmd.Parameters.AddWithValue("@3", eaR.Ea_DispStatus);
                        sqlCmd.Parameters.AddWithValue("@4", eaR.Ea_KlBgId);
                        sqlCmd.Parameters.AddWithValue("@5", eaR.Ea_DispKlBg);
                        sqlCmd.Parameters.AddWithValue("@6", eaR.Ea_Emailadres);
                        sqlCmd.Parameters.AddWithValue("@7", eaR.Ea_Mutatiedatum);
                        sqlCmd.Parameters.AddWithValue("@8", eaR.Ea_Opmerking);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception) { }

                dbcDa.Close();
            }
        }

        public void deleteRecord(int iEaId)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    string sqlStr = "Delete from Emailadres Where Ea_Id=@1;";
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", iEaId);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (SystemException ex)
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("Fout bij verwijderen van emailadressen: {0}", ex.Message));
                }
            }
        }
    }
}
