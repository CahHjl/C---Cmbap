using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using globalVars;

namespace tblMo
{
    class tblModules
    {
        public moVars moVars = new moVars();
        public List<moVars.moRecord> lstModuleRecord = new List<moVars.moRecord>();

        public void zoekModuleRecord()
        {
            string sCs = "Data Source=" + gv.sLicentieFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcLi = new SQLiteConnection(sCs))
            {
                dbcLi.Open();

                // Zoek record in Moduletabel zonder extra zoekargument
                string sqlStr = "Select * From Modules ";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcLi))
                {
                    using (SQLiteDataReader sqlRdr = sqlCmd.ExecuteReader())
                    {
                        recordsInList(sqlRdr);
                    }
                }
                dbcLi.Close();
            }

        }

        public void zoekModuleRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sLicentieFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcLi = new SQLiteConnection(sCs))
            {
                dbcLi.Open();

                // Zoek record in Moduletabel zonder extra zoekargument
                string sqlStr = "Select * From Modules Where " + sZoekarg;
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcLi))
                {
                    using (SQLiteDataReader sqlRdr = sqlCmd.ExecuteReader())
                    {
                        recordsInList(sqlRdr);
                    }
                }
                dbcLi.Close();
            }

        }

        private void recordsInList(SQLiteDataReader r)
        {
            moVars lv = new moVars();
            moVars.moRecord mir = new moVars.moRecord();

            lstModuleRecord.Clear();

            while (r.Read())
            {
                //Maak list van geselecteerde rijen

                mir.Id = r.GetInt32(r.GetOrdinal("Module_Id"));
                mir.Kort = r.GetString(r.GetOrdinal("Module_Kort"));
                mir.Lang = r.GetString(r.GetOrdinal("Module_Lang"));
                mir.Actief = r.GetInt16(r.GetOrdinal("Module_Actief"));
                mir.licentieId = r.GetInt16(r.GetOrdinal("Module_LicentieId"));
                mir.Mutatiedatum = r.GetDateTime(r.GetOrdinal("Module_Mutatiedatum"));
                mir.Opmerking = r.GetString(r.GetOrdinal("Module_Opmerking"));
                lstModuleRecord.Add(mir);
            }

        }



    }
}
