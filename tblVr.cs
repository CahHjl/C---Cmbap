using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SQLite;
using ProcFunc;
using globalVars;

namespace nsTblVr
{
    class tblVr
    {
        public struct vrRecord
        {
            public int Vrrd_Id { get; set; }
            public int Vrrd_JgegId { get; set; }
            public string Vrrd_DispJgeg { get; set; }
            public int Vrrd_StatusId { get; set; }
            public string Vrrd_DispStatus { get; set; }
            public int Vrrd_ProdId { get; set; }
            public string Vrrd_DispProduct { get; set; }
            public DateTime Vrrd_Inventarisatiedatum { get; set; }
            public long Vrrd_Aantal { get; set; }
            public long Vrrd_Laagste_Productnr { get; set; }
            public long Vrrd_Hoogste_Productnr { get; set; }
            public DateTime Vrrd_Mutatiedatum { get; set; }
            public string Vrrd_Opmerking { get; set; }
        }


        public List<vrRecord> lstVoorraadRecord = new List<vrRecord>();
        public int vrListCount;
        public bool bvrNaarList;

        public void zoekVoorraadRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Voorraad Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Voorraad;";
                }
                
                // Zoek record in Voorraadtabel zonder extra zoekargument
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

        public int telVoorraadRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Voorraad Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Voorraad;";
                }

                // Zoek record in Voorraadtabel zonder extra zoekargument
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    using (SQLiteDataReader sqlrdr = sqlCmd.ExecuteReader())
                    {
                        vrListCount = 0;
                        while (sqlrdr.Read())
                        {
                            //get rows
                            vrListCount++;
                        }
                    }
                }
                dbcDa.Close();
                return vrListCount;
            }
        }

        private void recordsInList(SQLiteDataReader r)
        {
            vrRecord vrr = new vrRecord();

            lstVoorraadRecord.Clear();

            while (r.Read())
            {
                //Maak list van geselecteerde rijen
                vrr.Vrrd_Id = r.GetInt32(r.GetOrdinal("Vrrd_Id"));
                vrr.Vrrd_JgegId = r.GetInt32(r.GetOrdinal("Vrrd_JgegId"));
                vrr.Vrrd_DispJgeg = r.GetString(r.GetOrdinal("Vrrd_DispJgeg"));
                vrr.Vrrd_StatusId = r.GetInt32(r.GetOrdinal("Vrrd_StatusId"));
                vrr.Vrrd_DispStatus = r.GetString(r.GetOrdinal("Vrrd_DispStatus"));
                vrr.Vrrd_ProdId=r.GetInt32(r.GetOrdinal("Vrrd_ProdId"));
                vrr.Vrrd_DispProduct=r.GetString(r.GetOrdinal("Vrrd_DispProduct"));
                vrr.Vrrd_Inventarisatiedatum=r.GetDateTime(r.GetOrdinal("Vrrd_Inventarisatiedatum"));
                vrr.Vrrd_Aantal=r.GetInt64(r.GetOrdinal("Vrrd_Aantal"));
                vrr.Vrrd_Laagste_Productnr=r.GetInt64(r.GetOrdinal("Vrrd_Laagste_Productnr"));
                vrr.Vrrd_Hoogste_Productnr=r.GetInt64(r.GetOrdinal("Vrrd_Hoogste_Productnr"));
                vrr.Vrrd_Mutatiedatum = r.GetDateTime(r.GetOrdinal("Vrrd_Mutatiedatum"));
                try
                {
                    vrr.Vrrd_Opmerking = r.GetString(r.GetOrdinal("Vrrd_Opmerking"));
                }
                catch (Exception)
                {
                }
                lstVoorraadRecord.Add(vrr);
            }

        }
    }
}
