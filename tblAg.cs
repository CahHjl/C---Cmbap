using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using ProcFunc;
using globalVars;

namespace nsTblAg
{
    class tblAg
    {
        public struct agRecord
        {
            public int Adrsgeg_Id { get; set; }
            public int Adrsgeg_StatusId { get; set; }
            public string Adrsgeg_DispStatus { get; set; }
            public int Adrsgeg_KlBgId { get; set; }
            public string Adrsgeg_DispKlBg { get; set; }
            public string Adrsgeg_Straatnaam { get; set; }
            public string Adrsgeg_Huisnummer { get; set; }
            public string Adrsgeg_Huisnummertoevoeging { get; set; }
            public string Adrsgeg_Adres { get; set; }
            public string Adrsgeg_Postcode { get; set; }
            public string Adrsgeg_Woonplaats { get; set; }
            public DateTime Adrsgeg_Mutatiedatum { get; set; }
            public string Adrsgeg_Opmerking { get; set; }
        }

        public List<agRecord> lstAdrsgegRecord = new List<agRecord>();
        public int agListCount;
        public int agListTCount;

        public void zoekAdresgegevensRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Adresgegevenstabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Adresgegevens Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Adresgegevens;";
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

        public int telAdresgegevensRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Tel records in Adresgegevenstabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Adresgegevens Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Adresgegevens;";
                }
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    using (SQLiteDataReader sqlRdr = sqlCmd.ExecuteReader())
                    {
                        agListCount = 0;
                        agListTCount = 0;
                        while (sqlRdr.Read())
                        {
                            //get rows
                            agListTCount++;
                            if (sqlRdr.GetInt32(sqlRdr.GetOrdinal("Adrsgeg_StatusId")) != 20009)
                            {
                                agListCount++;
                            }
                        }
                    }
                }
                dbcDa.Close();
                return agListCount;
            }
        }

        private void recordsInList(SQLiteDataReader r)
        {
            agRecord agr = new agRecord();

            lstAdrsgegRecord.Clear();
            agListCount = 0;
            agListTCount = 0;

            while (r.Read())
            {
                //Maak list van geselecteerde rijen

                agListTCount++;
                agr.Adrsgeg_Id = r.GetInt32(r.GetOrdinal("Adrsgeg_Id"));
                agr.Adrsgeg_StatusId = r.GetInt32(r.GetOrdinal("Adrsgeg_StatusId"));
                agr.Adrsgeg_DispStatus = r.GetString(r.GetOrdinal("Adrsgeg_DispStatus"));
                if (r.GetInt32(r.GetOrdinal("Adrsgeg_StatusId")) != 20009)
                {
                    agListCount++;
                }
                agr.Adrsgeg_KlBgId = r.GetInt32(r.GetOrdinal("Adrsgeg_KlBgId"));

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

                agr.Adrsgeg_Mutatiedatum = r.GetDateTime(r.GetOrdinal("Adrsgeg_Mutatiedatum"));
                agr.Adrsgeg_Opmerking = "";
                try
                {
                    agr.Adrsgeg_Opmerking = r.GetString(r.GetOrdinal("Adrsgeg_Opmerking"));
                }
                catch (Exception)
                {
                }
                lstAdrsgegRecord.Add(agr);
            }

        }

    }
}
