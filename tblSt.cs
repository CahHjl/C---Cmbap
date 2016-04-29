using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SQLite;
using ProcFunc;
using globalVars;

namespace nsTblSt
{
    class tblSt
    {
        public struct stRecord
        {
            public int StatusId { get; set; }
            public int Status_HoofdgroepitemJN { get; set; }
            public int Status_Groep { get; set; }
            public int Status_Nr { get; set; }
            public int Status_Code { get; set; }
            public string Status_Kort { get; set; }
            public string Status_Lang { get; set; }
            public DateTime Status_Mutatiedatum { get; set; }
            public string Status_Opmerking { get; set; }
        }



        public List<stRecord> lstStatusRecord = new List<stRecord>();

        public void zoekStatusRecord()
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Statustabel zonder extra zoekargument
                string sqlStr = "Select * From Status";
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

        public void zoekStatusRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Statustabel met extra zoekargument
                string sqlStr = "Select * from Status Where " + sZoekarg + ";";
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
            stRecord str = new stRecord();

            lstStatusRecord.Clear();

            while (r.Read())
            {
                //Maak list van geselecteerde rijen
                str.StatusId = r.GetInt32(r.GetOrdinal("StatusId"));
                str.Status_HoofdgroepitemJN = r.GetInt32(r.GetOrdinal("Status_HoofdgroepitemJN"));
                str.Status_Groep = r.GetInt32(r.GetOrdinal("Status_Groep"));
                str.Status_Nr = r.GetInt32(r.GetOrdinal("Status_Nr"));
                str.Status_Code = r.GetInt32(r.GetOrdinal("Status_Code"));
                str.Status_Kort = r.GetString(r.GetOrdinal("Status_Kort"));
                str.Status_Lang = r.GetString(r.GetOrdinal("Status_Lang"));
                str.Status_Mutatiedatum = r.GetDateTime(r.GetOrdinal("Status_Mutatiedatum"));
                try
                {
                    str.Status_Opmerking = r.GetString(r.GetOrdinal("Status_Opmerking"));
                }
                catch (Exception)
                {
                }
                lstStatusRecord.Add(str);
            }

        }
    }
}