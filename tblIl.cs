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
            public ArrayList Instl_Memo { get; set; }
    	    public DateTime Instl_Datum { get; set; }
            public DateTime Instl_Tijd { get; set; }
            public DateTime Instl_Mutatiedatum { get; set; }
            public string Instl_Opmerking { get; set; }
        }



        public List<ilRecord> lstInstellingRecord = new List<ilRecord>();

        public void zoekInstellingRecord()
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Instellingentabel zonder extra zoekargument
                string sqlStr = "Select * From Instellingen";
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

        public void zoekInstellingRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Instellingentabel met extra zoekargument
                string sqlStr = "Select * from Instellingen Where " + sZoekarg + ";";
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

        private void recordsInList(SQLiteDataReader r)
        {
            ilRecord ilr = new ilRecord();

            lstInstellingRecord.Clear();

            while (r.Read())
            {
                //Maak list van geselecteerde rijen
                ilr.Instl_Id = r.GetInt32(r.GetOrdinal("Instl_Id"));
                ilr.Instl_Systeemsetting = r.GetInt32(r.GetOrdinal("Instl_Systeemsetting"));
                ilr.Instl_StatusId = r.GetInt32(r.GetOrdinal("Instl_StatusId"));
                ilr.Instl_DispStatus = r.GetString(r.GetOrdinal("Instl_DispStatus"));
                ilr.Instl_Naam = r.GetString(r.GetOrdinal("Instl_Naam"));
                ilr.Instl_Gegtype=r.GetByte(r.GetOrdinal("Instl_Gegtype"));
                ilr.Instl_Actief = r.GetInt32(r.GetOrdinal("Instl_Actief"));
                ilr.Instl_String = r.GetString(r.GetOrdinal("Instl_String"));
                ilr.Instl_JN = r.GetInt32(r.GetOrdinal("Instl_JN"));
                ilr.Instl_Integer = r.GetInt64(r.GetOrdinal("Instl_Integer"));
                ilr.Instl_Real = r.GetDecimal(r.GetOrdinal("Instl_Real"));
                //ilr.Instl_Memo=r.G.public ArrayList Instl_Memo { get; set; }
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
                lstInstellingRecord.Add(ilr);
            }

        }
    }
}
