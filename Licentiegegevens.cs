using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tblLi;
using tblMo;

namespace Cmbap
{
    public partial class Licentiegegevens : Form
    {
        public Licentiegegevens()
        {
            InitializeComponent();
        }

        private void btnSluiten_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Licentiegegevens_Activated(object sender, EventArgs e)
        {
            tblLicentie tli = new tblLicentie();
            tli.zoekLicentieRecord();

            switch (tli.lstLicentieRecord[0].Usermode)
            {
                case 1:
                {
                    lblLicVersie.Text = "Normale, actieve versie";
                    break;
                }
                case 5:
                {
                        lblLicVersie.Text = "Systeemgebruikers-versie";
                        break;
                    }
                case 9:
                {
                        lblLicVersie.Text = "Demo-versie";
                        break;
                }
            }
            lblLicNaamLh.Text  = tli.lstLicentieRecord[0].Naamlh;
            lblLicDispalynaamLh.Text = tli.lstLicentieRecord[0].Displaynaamlh;
            lblLicContactPersoonLh.Text = tli.lstLicentieRecord[0].Contactpersoonlh;
            lblLicAdresLh.Text = tli.lstLicentieRecord[0].Adreslh;
            lblLicPcWoonplaatsLh.Text = tli.lstLicentieRecord[0].Postcodelh + " " + tli.lstLicentieRecord[0].Woonplaatslh;
            lblLicTelefoonnummerLh.Text=tli.lstLicentieRecord[0].Telefoonnummerlh;

            tblModules tmo = new tblModules();
            tmo.zoekModuleRecord("Module_LicentieId = " + tli.lstLicentieRecord[0].Id.ToString());

            if (tmo.lstModuleRecord.Count == 0)
                {
                    lblLicModules.Text="Geen modules gevonden";
                }
            else
            {
                lblLicModules.Text = "";
                for (int i = 0; i < tmo.lstModuleRecord.Count; i++)
                {
                    lblLicModules.Text = lblLicModules.Text+tmo.lstModuleRecord[i].Lang+"\n";
                }
            }
        }
    }
}
