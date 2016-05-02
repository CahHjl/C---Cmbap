using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using globalVars;

namespace Error
{
    public partial class frmError : Form
    {
        string skopTekst;
        string serrorTekst;
        Boolean bstopProgramma;

        public frmError()
        {
            InitializeComponent();
        }

        public void setParams(string schermTitel, string kopTekst, string errorTekst, string annulerenTekst, string doorgaanTekst, string sluitenTekst, Boolean stopProgramma, int soortMelding)
        {
            // soortMelding: 1=Fatale fout, 2 = fout en doorgaan, 3 = alleen melding, 4 = aanwijzingen, 0 = sluit scherm)

            if (soortMelding == 0)
            {
                this.Close();
                return;
            }
            this.Text = schermTitel;
            skopTekst = "Programma-fout";
            btnAnnuleren.Text = "Annuleren";
            btnDoorgaan.Text = "Doorgaan";
            btnSluiten.Text = "Ok";
            if (kopTekst != "")
            {
                skopTekst = kopTekst;
            }
            serrorTekst = errorTekst;
            bstopProgramma = stopProgramma;

            lblErrorHead.Text = skopTekst;
            lblError.Text = serrorTekst;

            if (sluitenTekst != "")
            {
                btnSluiten.Text = sluitenTekst;
            }
            if (doorgaanTekst != "")
            {
                btnDoorgaan.Text = doorgaanTekst;
                btnDoorgaan.Visible = true;
            }
            if (annulerenTekst != "")
            {
                btnAnnuleren.Text = annulerenTekst;
                btnAnnuleren.Visible = true;
            }

            if (soortMelding == 1)
            {
                var l = lblErrorHead;
                lblErrorHead.Font = new Font(l.Font.FontFamily, 12);
                lblErrorHead.BackColor = Color.Red;
                lblErrorHead.ForeColor = Color.Yellow;
                btnSluiten.Text = "Sluiten";
            }

            if (soortMelding == 2)  // Fout, maar er mag doorgegaan worden
            {
                var l = lblErrorHead;
                lblErrorHead.Font = new Font(l.Font.FontFamily, 12);
                lblErrorHead.BackColor = Color.Tomato;
                lblErrorHead.ForeColor = Color.Yellow;
                btnSluiten.Text = "Ok";
            }

            if (soortMelding == 3)  // Melding, bij foutieve invoer etc.
            {
                var l = lblErrorHead;
                lblErrorHead.Font = new Font(l.Font.FontFamily, 12);
                lblErrorHead.BackColor = Color.Blue;
                lblErrorHead.ForeColor = Color.Yellow;
                btnSluiten.Text = "Ok";
            }

            if (soortMelding == 4)  // Aanwijzingen
            {
                var l = lblErrorHead;
                lblErrorHead.Font = new Font(l.Font.FontFamily, 12);
                lblErrorHead.BackColor = Color.Green;
                lblErrorHead.ForeColor = Color.Yellow;
                btnSluiten.Text = "Ok";
            }
        }

        public void toonError()
        {
            this.Show();
        }

        private void btnSluiten_Click(object sender, EventArgs e)
        {
            if (bstopProgramma == true)
            {
                Application.Exit();
            }
            else
            {
                // errorReturn: 1 = OK/Sluiten; 2 = Annuleren; 3 = Doorgaan
                gv.errorReturn = 1;
                this.Close();
            }            
        }

        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            gv.errorReturn = 2;
            this.Close();
        }

        private void btnDoorgaan_Click(object sender, EventArgs e)
        {
            gv.errorReturn = 3;
            this.Close();
        }
    }
}
