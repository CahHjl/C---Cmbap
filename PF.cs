using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using globalVars;
using Cmbap;
using System.Windows.Forms;
using System.Data.SQLite;
using tblLi;
using Error;
using tblMo;
using nsTblIl;
using nsTblJg;

namespace ProcFunc
{
    public class pf
    {

        public string randomString(int lengte)
        {
            string uit = "";
            int r;
            Random rnd = new Random();
            for (int i = 0; i < lengte; i++)
            {
                r = 33 + rnd.Next(210);
                uit = uit + r.ToString(); 
            }
            return uit;
        }

        public void Init_vars()
        {
            if (gv.bInit == false)
            {
                gv.sProgPad = Application.StartupPath + "\\";
                gv.sDataPad = gv.sProgPad;
                gv.sDataFilePad = gv.sDataPad + "Cmbap-Data.db";
                gv.sLicentieFilePad = gv.sDataPad + "Cmbap-Licentie.db";

                tblJg jg = new tblJg();
                jg.zoekJaarGegevensRecord("Jgeg_StatusId<>180009");
                if (jg.jgListCount != 0)
                {
                    gv.beginDatumPeriode = jg.lstJaarGegevensRecord[jg.jgListCount - 1].Jgeg_Begindatum;
                    gv.eindDatumPeriode = jg.lstJaarGegevensRecord[jg.jgListCount - 1].Jgeg_Einddatum;
                }
                gv.bInit = true;
            }
            tblIl il = new tblIl();
            tblIl.ilRecord ilr = new tblIl.ilRecord();
            il.zoekInstellingenRecord("Instl_Naam = " + "\"" + "Demo_Product_Aantal"+"\"");
            if (il.lstInstellingenRecord.Count == 0)
            {
                gv.instellingDemoAantalProducten = 8;
                gv.instellingDemoExtraAantalProducten = 2;
                gv.instellingUserMode = 5;
            }
            else
            {
                gv.instellingDemoAantalProducten = (int)ilr.Instl_Integer;
                gv.instellingDemoExtraAantalProducten = (int)ilr.Instl_Integer;
                gv.instellingUserMode = (int)ilr.Instl_Integer;
            }

        }

        public string DTToS(DateTime DT)
        {
            return DT.ToLongDateString();
        }

        // sDb = connectionstring, die pad en naam van Data-sqlitebestand bevat
        public void dbsDa(string sDb)
        {
            string sDbIn;
            sDbIn = sDb;
            string sCs = "Data Source=" + sDbIn + ";Version=3;New=False;";

            gv.dbcDa = new SQLiteConnection(sCs);
            gv.dbcDa.Open();
        }

        public void zoekLicentie()
        {
            tblLicentie tli = new tblLicentie();

            // Controle licentie
            tli.zoekLicentieRecord();

            gv.actieveLicentieIndex = 0;
            if (tli.lstLicentieRecord.Count == 0)
            {
                //frmError fErr = new frmError("Database-fout", "* Fout in licentiebestand\n* Foutcode: L00\n\n  Programma wordt beëindigd", true);
            }
            else
            {
                if (tli.lstLicentieRecord.Count == 1)
                {
                    if (tli.lstLicentieRecord[0].Actief != 1)
                    {
                        melding("Programma-fout", "Database-fout", "* Fout in licentiebestand\n* Foutcode: L01\n\n  Programma wordt beëindigd", "", "", "", true, 1);
                    }
                }
                else
                {
                    int activeLicenties = 0;
                    for (int i = 0; i < tli.lstLicentieRecord.Count; i++)
                    {
                        if (tli.lstLicentieRecord[i].Actief == 1)
                        {
                            activeLicenties++;
                            gv.actieveLicentieIndex = i;
                        }
                    }
                    if (activeLicenties == 0)
                    {
                        melding("Programma-fout", "Database-fout", "* Fout in licentiebestand\n* Foutcode: L02\n\n  Programma wordt beëindigd", "", "", "", true, 1);
                    }
                    else
                    {
                        if (activeLicenties > 1)
                        {
                            melding("Programma-fout", "Database-fout", "* Fout in licentiebestand\n* Foutcode: L03\n\n  Programma wordt beëindigd", "", "", "", true, 1);
                        }
                    }
                }
            }

            gv.actieveLicentie.Id = tli.lstLicentieRecord[gv.actieveLicentieIndex].Id;
            gv.actieveLicentie.Actief = tli.lstLicentieRecord[gv.actieveLicentieIndex].Actief;
            gv.actieveLicentie.Programma = tli.lstLicentieRecord[gv.actieveLicentieIndex].Programma;
            gv.actieveLicentie.Nr = tli.lstLicentieRecord[gv.actieveLicentieIndex].Nr;
            gv.actieveLicentie.Code = tli.lstLicentieRecord[gv.actieveLicentieIndex].Code;
            gv.actieveLicentie.Type = tli.lstLicentieRecord[gv.actieveLicentieIndex].Type;
            gv.actieveLicentie.Usermode = tli.lstLicentieRecord[gv.actieveLicentieIndex].Usermode;
            gv.actieveLicentie.Naamlh = tli.lstLicentieRecord[gv.actieveLicentieIndex].Naamlh;
            gv.actieveLicentie.Displaynaamlh = tli.lstLicentieRecord[gv.actieveLicentieIndex].Displaynaamlh;
            gv.actieveLicentie.Contactpersoonlh = tli.lstLicentieRecord[gv.actieveLicentieIndex].Contactpersoonlh;
            gv.actieveLicentie.Adreslh = tli.lstLicentieRecord[gv.actieveLicentieIndex].Adreslh;
            gv.actieveLicentie.Postcodelh = tli.lstLicentieRecord[gv.actieveLicentieIndex].Postcodelh;
            gv.actieveLicentie.Woonplaatslh = tli.lstLicentieRecord[gv.actieveLicentieIndex].Woonplaatslh;
            gv.actieveLicentie.Telefoonnummerlh = tli.lstLicentieRecord[gv.actieveLicentieIndex].Telefoonnummerlh;
            gv.actieveLicentie.Emailadreslh = tli.lstLicentieRecord[gv.actieveLicentieIndex].Emailadreslh;
            gv.actieveLicentie.OudeControleCode = tli.lstLicentieRecord[gv.actieveLicentieIndex].OudeControleCode;
            gv.actieveLicentie.NieuweControleCode = tli.lstLicentieRecord[gv.actieveLicentieIndex].NieuweControleCode;
            gv.actieveLicentie.ControleCodeType = tli.lstLicentieRecord[gv.actieveLicentieIndex].ControleCodeType;
            gv.actieveLicentie.Mutatiedatum = tli.lstLicentieRecord[gv.actieveLicentieIndex].Mutatiedatum;
            gv.actieveLicentie.Opmerking = tli.lstLicentieRecord[gv.actieveLicentieIndex].Opmerking;

            tblModules tmo = new tblModules();
            tmo.zoekModuleRecord("Module_LicentieId = " + gv.actieveLicentie.Id.ToString());
            if (tmo.lstModuleRecord.Count != 0)
            {
                gv.bmoduleBasis = false;
                gv.bmoduleExt = false;
                gv.bmoduleIncas = false;
                gv.bmoduleExport = false;
                for (int i = 0; i < tmo.lstModuleRecord.Count; i++)
                {
                    if (tmo.lstModuleRecord[i].Kort == "Cmb-Basis" && tmo.lstModuleRecord[i].Actief == 1)
                    {
                        gv.bmoduleBasis = true;
                    }
                    if (tmo.lstModuleRecord[i].Kort == "Cmb-Ext" && tmo.lstModuleRecord[i].Actief == 1)
                    { 
                        gv.bmoduleExt = true;
                    }
                    if (tmo.lstModuleRecord[i].Kort == "Cmb-Incas" && tmo.lstModuleRecord[i].Actief == 1)
                    {
                        gv.bmoduleIncas = true;
                    }
                    if (tmo.lstModuleRecord[i].Kort == "Cmb-Export" && tmo.lstModuleRecord[i].Actief == 1)
                    {
                        gv.bmoduleExport = true;
                    }
                }
            }
        }

        public void melding(string fmschermTitel, string fmKop, string fmBericht, string fmAnnuleren, string fmDoorgaan, string fmOk, Boolean fmStop, int fmSoortmelding)
        {
            gv.errorReturn = 0;
            frmError fErr = new frmError();
            fErr.setParams(fmschermTitel, fmKop, fmBericht,fmAnnuleren,fmDoorgaan,fmOk, fmStop, fmSoortmelding);
            fErr.toonError();
        }

    }
}
