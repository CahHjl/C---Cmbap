using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using globalVars;
using System.Data;

namespace tblLi
{ 
    

    class tblLicentie
    {
        public struct liRecord
        {
            public int Id { get; set; }
            public int Actief { get; set; }
            public string Programma { get; set; }
            public int Nr { get; set; }
            public string Code { get; set; }
            public byte Type { get; set; }
            public int Usermode { get; set; }
            public string Naamlh { get; set; }
            public string Displaynaamlh { get; set; }
            public string Contactpersoonlh { get; set; }
            public string Adreslh { get; set; }
            public string Postcodelh { get; set; }
            public string Woonplaatslh { get; set; }
            public string Telefoonnummerlh { get; set; }
            public string Emailadreslh { get; set; }
            public string OudeControleCode { get; set; }
            public string NieuweControleCode { get; set; }
            public int ControleCodeType { get; set; }
            public DateTime Mutatiedatum { get; set; }
            public string Opmerking { get; set; }
        }

        public List<liRecord> lstLicentieRecord = new List<liRecord>();

        public void zoekLicentieRecord()
        {
            string sCs = "Data Source=" + gv.sLicentieFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcLi = new SQLiteConnection(sCs))
            {
                dbcLi.Open();

                // Zoek record in Licentietabel zonder extra zoekargument
                string sqlStr = "Select * From Licentie";
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

        public void zoekLicentieRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sLicentieFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcLi = new SQLiteConnection(sCs))
            {
                dbcLi.Open();

                // Zoek record in Licentietabel met extra zoekargument
                string sqlStr = "Select * from Licentie Where " + sZoekarg;
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcLi))
                {
                    using (SQLiteDataReader sqlrdr = sqlCmd.ExecuteReader())
                    {
                        recordsInList(sqlrdr);
                    }
                }
                dbcLi.Close();
            }
        }

        private void recordsInList(SQLiteDataReader r)
        {
            liRecord lir = new liRecord();
             
            lstLicentieRecord.Clear();

            while (r.Read())
            {
                //Maak list van geselecteerde rijen

                lir.Id = r.GetInt32(r.GetOrdinal("Lic_Id"));
                lir.Actief = r.GetInt16(r.GetOrdinal("Lic_Actief"));
                lir.Programma = r.GetString(r.GetOrdinal("Lic_Programma"));
                lir.Nr = r.GetInt32(r.GetOrdinal("Lic_Nr"));
                lir.Code = r.GetString(r.GetOrdinal("Lic_Code"));
                lir.Type = r.GetByte(r.GetOrdinal("Lic_Type"));
                lir.Usermode = r.GetInt16(r.GetOrdinal("Lic_Usermode"));
                lir.Naamlh = r.GetString(r.GetOrdinal("Lic_Naamlh"));
                lir.Displaynaamlh = r.GetString(r.GetOrdinal("Lic_Displaynaamlh"));
                lir.Contactpersoonlh = r.GetString(r.GetOrdinal("Lic_Contactpersoonlh"));
                lir.Adreslh = r.GetString(r.GetOrdinal("Lic_Adreslh"));
                lir.Postcodelh = r.GetString(r.GetOrdinal("Lic_Postcodelh"));
                lir.Woonplaatslh = r.GetString(r.GetOrdinal("Lic_Woonplaatslh"));
                lir.Telefoonnummerlh = r.GetString(r.GetOrdinal("Lic_Telefoonnummerlh"));
                lir.Emailadreslh = r.GetString(r.GetOrdinal("Lic_Emailadreslh"));
                lir.OudeControleCode = r.GetString(r.GetOrdinal("Lic_OudeControleCode"));
                lir.NieuweControleCode = r.GetString(r.GetOrdinal("Lic_NieuweControlecode"));
                lir.ControleCodeType = r.GetInt32(r.GetOrdinal("Lic_ControleCodetype"));
                lir.Mutatiedatum = r.GetDateTime(r.GetOrdinal("Lic_Mutatiedatum"));
                lir.Opmerking = r.GetString(r.GetOrdinal("Lic_Opmerking"));
                lstLicentieRecord.Add(lir);
            }
            
        }

    }
}
