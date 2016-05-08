using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using globalVars;
using ProcFunc;

namespace nsTblKb
{
    class tblKb
    {
        public struct kbRecord
        {
            public int KlBg_Id { get; set; }
            public int KlBg_StatusId { get; set; }
            public string KlBg_DispStatus { get; set; }
            public int KlBg_KlantJN { get; set; }
            public int KlBg_BegunstigdeJN { get; set; }
            public int KlBg_SysteemKlBgJN { get; set; }
            public int KlBg_Scipio_Lokaalnr { get; set; }
            public string KlBg_DebNr { get; set; }
            public string KlBg_CredNr { get; set; }
            public string KlBg_Voorvoegsel { get; set; }
            public string KlBg_Voorletter { get; set; }
            public string KlBg_Tussenvoegsel { get; set; }
            public string KlBg_Achternaam { get; set; }
            public string KlBg_VVTA { get; set; }
            public string KlBg_AVVT { get; set; }
            public string KlBg_Straatnaam { get; set; }
            public string KlBg_Huisnummer { get; set; }
            public string KlBg_Huisnummertoevoeging { get; set; }
            public string KlBg_Adres { get; set; }
            public string KlBg_Postcode { get; set; }
            public string KlBg_Woonplaats { get; set; }
            public string KlBg_Telefoonnummer { get; set; }
            public string KlBg_Emailadres { get; set; }
            public string KlBg_Extra_Informatie { get; set; }
            public string KlBg_SysteemKlBgDispJN { get; set; }
            public string KlBg_KlDispJN { get; set; }
            public string KlBg_BgDispJN { get; set; }
            public DateTime KlBg_Mutatiedatum { get; set; }
            public string KlBg_Opmerking { get; set; }
        }

        public List<kbRecord> lstKlantBegunstigdeRecord = new List<kbRecord>();
        public int kbListCount;
        public int kbListTCount;

        public void zoekKlantBegunstigdeRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Klant_Begunstigdetabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Klant_Begunstigde Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Klant_Begunstigde;";
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

        public int telKlantBegunstigdeRecord(string sZoekarg)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();

                // Zoek record in Klant_Begunstigdetabel met extra zoekargument
                string sqlStr;
                if (sZoekarg != "")
                {
                    sqlStr = "Select * from Klant_Begunstigde Where " + sZoekarg + ";";
                }
                else
                {
                    sqlStr = "Select * from Klant_Begunstigde;";
                }
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    using (SQLiteDataReader sqlRdr = sqlCmd.ExecuteReader())
                    {
                        kbListCount = 0;
                        kbListTCount = 0;
                        while (sqlRdr.Read())
                        {
                            //get rows
                            kbListTCount++;
                            if (sqlRdr.GetInt32(sqlRdr.GetOrdinal("Klbg_StatusId")) != 10009)
                            {
                                kbListCount++;
                            }
                        }
                    }
                }
                dbcDa.Close();
                return kbListCount;
            }
        }

        private void recordsInList(SQLiteDataReader r)
        {
            kbRecord kbr = new kbRecord();

            lstKlantBegunstigdeRecord.Clear();
            kbListCount = 0;
            kbListTCount = 0;

            while (r.Read())
            {
                //Maak list van geselecteerde rijen

                kbListTCount++;
                kbr.KlBg_Id = r.GetInt32(r.GetOrdinal("KlBg_Id"));
                kbr.KlBg_StatusId = r.GetInt32(r.GetOrdinal("KlBg_StatusId"));
                kbr.KlBg_DispStatus = r.GetString(r.GetOrdinal("KlBg_DispStatus"));
                if (r.GetInt32(r.GetOrdinal("KlBg_StatusId")) != 10009)
                {
                    kbListCount++;
                }
                 kbr.KlBg_KlantJN = r.GetInt32(r.GetOrdinal("KlBg_KlantJN"));
                 kbr.KlBg_BegunstigdeJN= r.GetInt32(r.GetOrdinal("KlBg_BegunstigdeJN"));
                 kbr.KlBg_SysteemKlBgJN= r.GetInt32(r.GetOrdinal("KlBg_SysteemKlBgJN"));
                 kbr.KlBg_Scipio_Lokaalnr = r.GetInt32(r.GetOrdinal("KlBg_Scipio_Lokaalnr"));
                 kbr.KlBg_DebNr = r.GetString(r.GetOrdinal("KlBg_Debnr"));
                 kbr.KlBg_CredNr = r.GetString(r.GetOrdinal("KlBg_Crednr"));
                 kbr.KlBg_Voorvoegsel = r.GetString(r.GetOrdinal("KlBg_Voorvoegsel"));
                 kbr.KlBg_Voorletter = r.GetString(r.GetOrdinal("KlBg_Voorletter"));
                 kbr.KlBg_Tussenvoegsel = r.GetString(r.GetOrdinal("KlBg_Tussenvoegsel"));
                 kbr.KlBg_Achternaam = r.GetString(r.GetOrdinal("KlBg_Achternaam"));
                 kbr.KlBg_VVTA = r.GetString(r.GetOrdinal("KlBg_VVTA"));
                kbr.KlBg_AVVT = r.GetString(r.GetOrdinal("KlBg_AVVT"));
                 kbr.KlBg_Straatnaam = r.GetString(r.GetOrdinal("KlBg_Straatnaam"));
                 kbr.KlBg_Huisnummer = r.GetString(r.GetOrdinal("KlBg_Huisnummer"));
                 kbr.KlBg_Huisnummertoevoeging = r.GetString(r.GetOrdinal("KlBg_Huisnummertoevoeging"));
                 kbr.KlBg_Adres = r.GetString(r.GetOrdinal("KlBg_Adres"));
                 kbr.KlBg_Postcode = r.GetString(r.GetOrdinal("KlBg_Postcode"));
                 kbr.KlBg_Woonplaats = r.GetString(r.GetOrdinal("KlBg_Woonplaats"));
                 kbr.KlBg_Telefoonnummer = r.GetString(r.GetOrdinal("KlBg_Telefoonnummer"));
                 kbr.KlBg_Emailadres = r.GetString(r.GetOrdinal("KlBg_Emailadres"));
                 kbr.KlBg_Extra_Informatie = r.GetString(r.GetOrdinal("KlBg_Extra_Informatie"));
                 kbr.KlBg_SysteemKlBgDispJN = r.GetString(r.GetOrdinal("KlBg_SysteemKlBgDispJN"));
                 kbr.KlBg_KlDispJN = r.GetString(r.GetOrdinal("KlBg_KlDispJN"));
                 kbr.KlBg_BgDispJN = r.GetString(r.GetOrdinal("KlBg_BgDispJN"));
                 kbr.KlBg_Mutatiedatum = r.GetDateTime(r.GetOrdinal("KlBg_Mutatiedatum"));
                 kbr.KlBg_Opmerking = "";
                 try
                 {
                     kbr.KlBg_Opmerking = r.GetString(r.GetOrdinal("KlBg_Opmerking"));
                 }
                 catch (Exception)
                 {
                 }
                 lstKlantBegunstigdeRecord.Add(kbr);
            }

        }

        public kbRecord vanRecord(int recNr)
        {
            kbRecord kbRec = new kbRecord();
            kbRec.KlBg_Id = lstKlantBegunstigdeRecord[recNr].KlBg_Id;
            kbRec.KlBg_StatusId = lstKlantBegunstigdeRecord[recNr].KlBg_StatusId;
            kbRec.KlBg_DispStatus = lstKlantBegunstigdeRecord[recNr].KlBg_DispStatus;
            kbRec.KlBg_KlantJN = lstKlantBegunstigdeRecord[recNr].KlBg_KlantJN;
            kbRec.KlBg_BegunstigdeJN = lstKlantBegunstigdeRecord[recNr].KlBg_BegunstigdeJN;
            kbRec.KlBg_SysteemKlBgJN = lstKlantBegunstigdeRecord[recNr].KlBg_SysteemKlBgJN;
            kbRec.KlBg_Scipio_Lokaalnr = lstKlantBegunstigdeRecord[recNr].KlBg_Scipio_Lokaalnr;
            kbRec.KlBg_DebNr = lstKlantBegunstigdeRecord[recNr].KlBg_DebNr;
            kbRec.KlBg_CredNr = lstKlantBegunstigdeRecord[recNr].KlBg_CredNr;
            kbRec.KlBg_Voorvoegsel = lstKlantBegunstigdeRecord[recNr].KlBg_Voorvoegsel;
            kbRec.KlBg_Voorletter = lstKlantBegunstigdeRecord[recNr].KlBg_Voorletter;
            kbRec.KlBg_Tussenvoegsel = lstKlantBegunstigdeRecord[recNr].KlBg_Tussenvoegsel;
            kbRec.KlBg_Achternaam = lstKlantBegunstigdeRecord[recNr].KlBg_Achternaam;
            kbRec.KlBg_VVTA = lstKlantBegunstigdeRecord[recNr].KlBg_VVTA;
            kbRec.KlBg_AVVT = lstKlantBegunstigdeRecord[recNr].KlBg_AVVT;
            kbRec.KlBg_Straatnaam = lstKlantBegunstigdeRecord[recNr].KlBg_Straatnaam;
            kbRec.KlBg_Huisnummer = lstKlantBegunstigdeRecord[recNr].KlBg_Huisnummer;
            kbRec.KlBg_Huisnummertoevoeging = lstKlantBegunstigdeRecord[recNr].KlBg_Huisnummertoevoeging;
            kbRec.KlBg_Adres = lstKlantBegunstigdeRecord[recNr].KlBg_Adres;
            kbRec.KlBg_Postcode = lstKlantBegunstigdeRecord[recNr].KlBg_Postcode;
            kbRec.KlBg_Woonplaats = lstKlantBegunstigdeRecord[recNr].KlBg_Woonplaats;
            kbRec.KlBg_Telefoonnummer = lstKlantBegunstigdeRecord[recNr].KlBg_Telefoonnummer;
            kbRec.KlBg_Emailadres = lstKlantBegunstigdeRecord[recNr].KlBg_Extra_Informatie;
            kbRec.KlBg_Extra_Informatie = lstKlantBegunstigdeRecord[recNr].KlBg_Extra_Informatie;
            kbRec.KlBg_SysteemKlBgDispJN = lstKlantBegunstigdeRecord[recNr].KlBg_SysteemKlBgDispJN;
            kbRec.KlBg_KlDispJN = lstKlantBegunstigdeRecord[recNr].KlBg_KlDispJN;
            kbRec.KlBg_BgDispJN = lstKlantBegunstigdeRecord[recNr].KlBg_BgDispJN;
            kbRec.KlBg_Mutatiedatum = lstKlantBegunstigdeRecord[recNr].KlBg_Mutatiedatum;
            kbRec.KlBg_Opmerking = lstKlantBegunstigdeRecord[recNr].KlBg_Opmerking;
            return kbRec;
        }

        public kbRecord vulDefaultKb()
        {
            pf pf = new pf();
            kbRecord kbRec = new kbRecord();
            kbRec.KlBg_StatusId = 10009;
            kbRec.KlBg_DispStatus = "KlBgId - Onbekend";
            kbRec.KlBg_KlantJN = 1;
            kbRec.KlBg_BegunstigdeJN = 0;
            kbRec.KlBg_SysteemKlBgJN = 0;
            kbRec.KlBg_Scipio_Lokaalnr = 0;
            kbRec.KlBg_DebNr = "";
            kbRec.KlBg_CredNr = "";
            kbRec.KlBg_Voorvoegsel = "";
            kbRec.KlBg_Voorletter = "";
            kbRec.KlBg_Tussenvoegsel = "";
            kbRec.KlBg_Achternaam = "";
            kbRec.KlBg_VVTA = "VVTA";
            kbRec.KlBg_AVVT = "AVVT";
            kbRec.KlBg_Straatnaam = "";
            kbRec.KlBg_Huisnummer = "";
            kbRec.KlBg_Huisnummertoevoeging = "";
            kbRec.KlBg_Adres = "";
            kbRec.KlBg_Postcode = "";
            kbRec.KlBg_Woonplaats = "";
            kbRec.KlBg_Telefoonnummer = "";
            kbRec.KlBg_Emailadres = "";
            kbRec.KlBg_Extra_Informatie = "";
            kbRec.KlBg_SysteemKlBgDispJN = "N";
            kbRec.KlBg_KlDispJN = "J";
            kbRec.KlBg_BgDispJN = "N";
            kbRec.KlBg_Mutatiedatum = DateTime.Parse("2000-01-01 00:00:00");
            kbRec.KlBg_Opmerking = "";
            return kbRec;
        }

        public int newKbRecord()
        {
            pf pf = new pf();
            kbRecord dKb = new kbRecord();
            dKb = vulDefaultKb();
            int newKbId = new int();
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";

            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                string findstring = pf.randomString(6);
                string sqlStr = "Insert Into Klant_Begunstigde (KlBg_StatusId, KlBg_DispStatus, KlBg_KlantJN, KlBg_BegunstigdeJN, " +
                                "KlBg_SysteemKlBgJN, KlBg_Scipio_Lokaalnr, KlBg_DebNr, KlBg_CredNr, KlBg_Voorvoegsel, KlBg_Voorletter, " +
                                "KlBg_Tussenvoegsel, KlBg_Achternaam, KlBg_VVTA, KlBg_AVVT, KlBg_Straatnaam, KlBg_Huisnummer, " +
                                "KlBg_Huisnummertoevoeging, KlBg_Adres, KlBg_Postcode, KlBg_Woonplaats, KlBg_Telefoonnummer, KlBg_Emailadres, "  +
                                "KlBg_Extra_Informatie, KlBg_SysteemKlBgDispJN, KlBg_KlDispJN, kbRec.KlBg_BgDispJN, kbRec.KlBg_Mutatiedatum, " +
                                "KlBg_Opmerking) Values (@2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16, @17, @18, @19, @20, " +
                                "@21, @22, @23, @24, @25, @26, @27, @28)";

                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    SQLiteParameter p2 = new SQLiteParameter(); p2.ParameterName = "@2"; p2.Value = 10009; sqlCmd.Parameters.Add(p2);
                    SQLiteParameter p3 = new SQLiteParameter(); p3.ParameterName = "@3"; p3.Value = "KlBgId-Onbekend"; sqlCmd.Parameters.Add(p3);
                    SQLiteParameter p4 = new SQLiteParameter(); p4.ParameterName = "@4"; p4.Value = 1; sqlCmd.Parameters.Add(p4);
                    SQLiteParameter p5 = new SQLiteParameter(); p5.ParameterName = "@5"; p5.Value = 0; sqlCmd.Parameters.Add(p5);
                    SQLiteParameter p6 = new SQLiteParameter(); p6.ParameterName = "@6"; p6.Value = 0; sqlCmd.Parameters.Add(p6);
                    SQLiteParameter p7 = new SQLiteParameter(); p7.ParameterName = "@7"; p7.Value = 0; sqlCmd.Parameters.Add(p7);
                    SQLiteParameter p8 = new SQLiteParameter(); p8.ParameterName = "@8"; p8.Value = ""; sqlCmd.Parameters.Add(p8);
                    SQLiteParameter p9 = new SQLiteParameter(); p9.ParameterName = "@9"; p9.Value = ""; sqlCmd.Parameters.Add(p9);
                    SQLiteParameter p10 = new SQLiteParameter(); p10.ParameterName = "@10"; p10.Value = ""; sqlCmd.Parameters.Add(p10);
                    SQLiteParameter p11 = new SQLiteParameter(); p11.ParameterName = "@11"; p11.Value = ""; sqlCmd.Parameters.Add(p11);
                    SQLiteParameter p12 = new SQLiteParameter(); p12.ParameterName = "@12"; p12.Value = ""; sqlCmd.Parameters.Add(p12);
                    SQLiteParameter p13 = new SQLiteParameter(); p13.ParameterName = "@13"; p13.Value = ""; sqlCmd.Parameters.Add(p13);
                    SQLiteParameter p14 = new SQLiteParameter(); p14.ParameterName = "@14"; p14.Value = "VVTA"; sqlCmd.Parameters.Add(p14);
                    SQLiteParameter p15 = new SQLiteParameter(); p2.ParameterName = "@15"; p15.Value = "AVVT"; sqlCmd.Parameters.Add(p15);
                    SQLiteParameter p16 = new SQLiteParameter(); p3.ParameterName = "@16"; p16.Value = ""; sqlCmd.Parameters.Add(p16);
                    SQLiteParameter p17 = new SQLiteParameter(); p4.ParameterName = "@17"; p17.Value = ""; sqlCmd.Parameters.Add(p17);
                    SQLiteParameter p18 = new SQLiteParameter(); p5.ParameterName = "@18"; p18.Value = ""; sqlCmd.Parameters.Add(p18);
                    SQLiteParameter p19 = new SQLiteParameter(); p6.ParameterName = "@19"; p19.Value = ""; sqlCmd.Parameters.Add(p19);
                    SQLiteParameter p20 = new SQLiteParameter(); p7.ParameterName = "@20"; p20.Value = ""; sqlCmd.Parameters.Add(p20);
                    SQLiteParameter p21 = new SQLiteParameter(); p8.ParameterName = "@21"; p21.Value = ""; sqlCmd.Parameters.Add(p21);
                    SQLiteParameter p22 = new SQLiteParameter(); p9.ParameterName = "@22"; p22.Value = ""; sqlCmd.Parameters.Add(p22);
                    SQLiteParameter p23 = new SQLiteParameter(); p10.ParameterName = "@23"; p23.Value = ""; sqlCmd.Parameters.Add(p23);
                    SQLiteParameter p24 = new SQLiteParameter(); p11.ParameterName = "@24"; p24.Value = "N"; sqlCmd.Parameters.Add(p24);
                    SQLiteParameter p25 = new SQLiteParameter(); p12.ParameterName = "@25"; p25.Value = "J"; sqlCmd.Parameters.Add(p25);
                    SQLiteParameter p26 = new SQLiteParameter(); p13.ParameterName = "@26"; p26.Value = "N"; sqlCmd.Parameters.Add(p26);
                    SQLiteParameter p27 = new SQLiteParameter(); p27.ParameterName = "@27"; p27.Value = DateTime.Parse("2000-01-01 00:00:00"); sqlCmd.Parameters.Add(p27);
                    SQLiteParameter p28 = new SQLiteParameter(); p28.ParameterName = "@28"; p28.Value = findstring; sqlCmd.Parameters.Add(p28);
                    sqlCmd.ExecuteNonQuery();
                    dbcDa.Close();
                }

                // Zoek toegevoegde record
                tblKb kb = new tblKb();
                kb.zoekKlantBegunstigdeRecord("KlBg_Opmerking = " + "\"" + findstring + "\"");
                newKbId = kb.lstKlantBegunstigdeRecord[0].KlBg_Id;

                // Verwijder infor uit Opmerking-veld
                dbcDa.Open();
                sqlStr = "Update Klant_Begunstigde set KlBg_Opmerking=@28 where KlBg_Id = @1;";
                using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                {
                    sqlCmd.Parameters.AddWithValue("@1", newKbId);
                    sqlCmd.Parameters.AddWithValue("@28", "");
                    sqlCmd.ExecuteNonQuery();
                }
                dbcDa.Close();


                return newKbId;
            }
        }

        public void saveRecord(int iKbId, kbRecord kbR)
        {
            string sqlStr = "Update Klant_Begunstigde set KlBg_StatusId=@2, KlBg_DispStatus=@3, KlBg_KlantJN=@4, KlBg_BegunstigdeJN=@5, " +
                            "KlBg_SysteemKlBgJN=@6, KlBg_Scipio_Lokaalnr=@7, KlBg_DebNr=@8, KlBg_CredNr=@9, KlBg_Voorvoegsel=@10, " +
                            "KlBg_Voorletter=@11, KlBg_Tussenvoegsel=@12, KlBg_Achternaam=@13, KlBg_VVTA=@14, KlBg_AVVT=@15, " +
                            "KlBg_Straatnaam=@16, KlBg_Huisnummer=@17, KlBg_Huisnummertoevoeging=@18, KlBg_Adres=@19, KlBg_Postcode=@20, " +
                            "KlBg_Woonplaats=@21, KlBg_Telefoonnummer=@22, KlBg_Emailadres=@23, KlBg_Extra_Informatie=@24, " +
                            "KlBg_SysteemKlBgDispJN=@25, KlBg_KlDispJN=@26, kbRec.KlBg_BgDispJN=@27, kbRec.KlBg_Mutatiedatum=@28, " +
                            "KlBg_Opmerking=@29 Where KlBg_Id=@1";

            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", iKbId);
                        sqlCmd.Parameters.AddWithValue("@2", kbR.KlBg_StatusId);
                        sqlCmd.Parameters.AddWithValue("@3", kbR.KlBg_DispStatus);
                        sqlCmd.Parameters.AddWithValue("@4", kbR.KlBg_KlantJN);
                        sqlCmd.Parameters.AddWithValue("@5", kbR.KlBg_BegunstigdeJN);
                        sqlCmd.Parameters.AddWithValue("@6", kbR.KlBg_SysteemKlBgJN);
                        sqlCmd.Parameters.AddWithValue("@7", kbR.KlBg_Scipio_Lokaalnr);
                        sqlCmd.Parameters.AddWithValue("@8", kbR.KlBg_DebNr);
                        sqlCmd.Parameters.AddWithValue("@9", kbR.KlBg_CredNr);
                        sqlCmd.Parameters.AddWithValue("@10", kbR.KlBg_Voorvoegsel);
                        sqlCmd.Parameters.AddWithValue("@11", kbR.KlBg_Voorletter);
                        sqlCmd.Parameters.AddWithValue("@12", kbR.KlBg_Tussenvoegsel);
                        sqlCmd.Parameters.AddWithValue("@13", kbR.KlBg_Achternaam);
                        sqlCmd.Parameters.AddWithValue("@14", kbR.KlBg_VVTA);
                        sqlCmd.Parameters.AddWithValue("@15", kbR.KlBg_AVVT);
                        sqlCmd.Parameters.AddWithValue("@16", kbR.KlBg_Straatnaam);
                        sqlCmd.Parameters.AddWithValue("@17", kbR.KlBg_Huisnummer);
                        sqlCmd.Parameters.AddWithValue("@18", kbR.KlBg_Huisnummertoevoeging);
                        sqlCmd.Parameters.AddWithValue("@19", kbR.KlBg_Adres);
                        sqlCmd.Parameters.AddWithValue("@20", kbR.KlBg_Postcode);
                        sqlCmd.Parameters.AddWithValue("@21", kbR.KlBg_Woonplaats);
                        sqlCmd.Parameters.AddWithValue("@22", kbR.KlBg_Telefoonnummer);
                        sqlCmd.Parameters.AddWithValue("@23", kbR.KlBg_Emailadres);
                        sqlCmd.Parameters.AddWithValue("@24", kbR.KlBg_Extra_Informatie);
                        sqlCmd.Parameters.AddWithValue("@25", kbR.KlBg_SysteemKlBgDispJN);
                        sqlCmd.Parameters.AddWithValue("@26", kbR.KlBg_KlDispJN);
                        sqlCmd.Parameters.AddWithValue("@27", kbR.KlBg_BgDispJN);
                        sqlCmd.Parameters.AddWithValue("@28", kbR.KlBg_Mutatiedatum);
                        sqlCmd.Parameters.AddWithValue("@29", kbR.KlBg_Opmerking);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception) { }

                dbcDa.Close();
            }
        }

        public void deleteRecord(int iKbId)
        {
            string sCs = "Data Source=" + gv.sDataFilePad + ";Version=3;New=False;";
            using (SQLiteConnection dbcDa = new SQLiteConnection(sCs))
            {
                dbcDa.Open();
                try
                {
                    string sqlStr = "Delete from Klant_Begunstigde Where KlBg_Id=@1;";
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlStr, dbcDa))
                    {
                        sqlCmd.Parameters.AddWithValue("@1", iKbId);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (SystemException ex)
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("Fout bij verwijderen van Klant-Begunstigde-gegevens: {0}", ex.Message));
                }
            }
        }
    }
}

