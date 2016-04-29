using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcFunc;
using globalVars;
using tblLi;
using System.Data.SQLite;
using Error;
using InvoerProduct;

namespace Cmbap
{
    public partial class frmCmbap : Form
    {
        public frmCmbap()
        {
            InitializeComponent();
        }

        private void zetMenu()
        {
            if (gv.bmoduleExt == true)
            {
                this.uitgavenToolStripMenuItem1.Visible = true;         // Bij invoer - uitgaven
                this.begunstigdenToolStripMenuItem1.Visible = true;
                this.uitgavenToolStripMenuItem.Visible = true;          // Bij opvragen - uitgaven
                this.jaarverslagToolStripMenuItem.Visible = true;
                this.begunstigdenkaartToolStripMenuItem.Visible = true;
                this.uitgavesoortenToolStripMenuItem.Visible = true;
                this.kBGrekeninggegevensToolStripMenuItem.Visible = true;
                this.kBGsaldogegevensToolStripMenuItem.Visible = true;

            }

            if (gv.bmoduleIncas == true)
            {
                this.incassobestandAanmakenToolStripMenuItem.Visible = true;
                this.incassogegevensToolStripMenuItem.Visible = true;
            }
        }

        private void frmCmbap_Activated(object sender, EventArgs e)
        {
            pf pf = new pf();
            pf.Init_vars();
            // Variabelen initialiseren
            // globalVars.Variabelen Vars = new globalVars.Variabelen();
            // ProcFunc.PF PF = new ProcFunc.PF();
            
            // Startscherm op maximaal zetten
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            this.lblProgrammakeuze.Text = "Hoofdmenu";
            // Systeemdatum invullen op middelste veld van systeembalk
            this.lblSysteemdatum.Text =  DateTime.Now.ToLongDateString();

            // Breedte van lblLicentie aanpassen
            this.lblLicentie.Width = 460;

            // Databases openen
            // dbsLi = Licentiebestand met licentie- en modulegegevens van een gebruiker
            // dbsDa = Databestand met gebruikers- en programmagegevens
            //pF.dbsLi(gV.sDatapad + "Cmbap-Licentie.db");
            //pF.dbsDa(gV.sDatapad + "Cmbap-Data.db");

            // Controleren of licentiebestand goed is (1 actief record).
            pf.zoekLicentie();
            this.lblLicentie.Text = gv.actieveLicentie.Nr + " / " + gv.actieveLicentie.Displaynaamlh;
            zetMenu();

            // Menubalk volle breedte zetten
            this.pnlMenu.Width = this.pnlSysteembalk.Width;
        }

        private void afsluitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Programma sluiten via menukeuze Afsluiten
            this.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void overCmbapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOverCmbap fOC = new frmOverCmbap();
            fOC.Show();
        }

        private void licentiegegevensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Licentiegegevens frmLicentieGegevens = new Licentiegegevens();
            frmLicentieGegevens.Show();
        }

        private void productgegevensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvoerProduct frmInvoerProduct = new frmInvoerProduct();
            frmInvoerProduct.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grpbxMelding.Visible = false;
 
        }

        private void overzichtProductenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ovzProduct rptProduct = new ovzProduct();
            rptProduct.Show();
        }

        private void algemeneGegevensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvoerJaarGegevens frmInvoerJaarGegevens = new frmInvoerJaarGegevens();
            frmInvoerJaarGegevens.Show();
        }
    }
}
