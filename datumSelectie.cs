using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using nsTblJg;
using globalVars;

namespace Cmbap
{
    public partial class datumSelectie : Form
    {
        public datumSelectie()
        {
            InitializeComponent();
        }

        private void datumSelectie_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_Cmbap_dataDataSet.Jaargegevens' table. You can move, or remove it, as needed.
            this.jaargegevensTableAdapter.Fill(this._Cmbap_dataDataSet.Jaargegevens);

        }

        private void datumSelectie_Activated(object sender, EventArgs e)
        {
            datumSelectie.ActiveForm.Text = gv.datumSelectieHeader;
            lstbxJaargegevens.Items.Clear();

            tblJg jg = new tblJg();
            jg.zoekJaarGegevensRecord("Jgeg_StatusId<>180009");
            if (jg.jgListCount!=0)
            {
                for (int i = 0; i <= jg.jgListTCount-1; i++)
                {
                    lstbxJaargegevens.Items.Add(jg.lstJaarGegevensRecord[i].Jgeg_Omschrijving);
                }
            }
            else
            {
                lstbxJaargegevens.Items.Add("Geen jaren/periodes gevonden!");
            }

            dttmpckrBegindatum.Value = gv.beginDatumPeriode;
            dttmpckrEinddatum.Value = gv.eindDatumPeriode;
            dttmpckrBegindatum.Value = gv.beginDatumPeriode;
            dttmpckrEinddatum.Value = gv.eindDatumPeriode;

        }

        private void lstbxJaargegevens_Click(object sender, EventArgs e)
        {
            tblJg jg = new tblJg();
            int rij = lstbxJaargegevens.SelectedIndex;
            string jgo = lstbxJaargegevens.Items[rij].ToString();
            jg.zoekJaarGegevensRecord("Jgeg_Omschrijving = "+"\""+jgo+"\";");
            if (jg.jgListCount == 1)
            {
                dttmpckrBegindatum.Value=jg.lstJaarGegevensRecord[0].Jgeg_Begindatum;
                dttmpckrEinddatum.Value=jg.lstJaarGegevensRecord[0].Jgeg_Einddatum;
            }
        }

        private void btnSelecteerPeriode_Click(object sender, EventArgs e)
        {
            //gv.beginDatumPeriode = DateTime.Parse(msktxtbxBegindatum.Text);
            //gv.eindDatumPeriode = DateTime.Parse(msktxtbxEinddatum.Text);
            this.Close();
        }

        private void dttmpckrEinddatum_ValueChanged(object sender, EventArgs e)
        {
            gv.eindDatumPeriode = dttmpckrEinddatum.Value;
        }

        private void dttmpckrBegindatum_ValueChanged(object sender, EventArgs e)
        {
            gv.beginDatumPeriode = dttmpckrBegindatum.Value;
        }
    }
}
