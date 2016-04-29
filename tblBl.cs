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
                        while (sqlrdr.Read())
                        {
                            //get rows
                            blListCount++;
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

            while (r.Read())
            {
                //Maak list van geselecteerde rijen
                blr.Bstlr_Id = r.GetInt32(r.GetOrdinal("Bstlr_Id"));
                blr.Bstlr_BstlId = r.GetInt32(r.GetOrdinal("Bstlr_BstlId"));
                blr.Bstlr_StatusId = r.GetInt32(r.GetOrdinal("Bstlr_StatusId"));
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
    }
}
