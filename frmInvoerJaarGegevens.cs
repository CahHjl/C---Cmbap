using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using nsTblVr;
using nsTblSt;
using nsTblJg;
using nsTblSs;
using nsTblJs;

namespace Cmbap
{
    public partial class frmInvoerJaarGegevens : Form
    {
        public int actueelJaarGegevensId = 0;
        bool bNewRecord = false;
        public tblJg pdc = new tblJg();
        private bool bDeleteRecord; // wordt op True gezet als verwijderen wordt aangeklikt
        private bool bValuesChanges; // Wordt true als er waarden veranderen t.o.v. oorspronkelijk
        public tblJg.jgRecord jgOld = new tblJg.jgRecord();

        public frmInvoerJaarGegevens()
        {
            InitializeComponent();
        }

        private void btnSluiten_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInvoerJaarGegevens_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_Cmbap_dataDataSet.Jaargegevens' table. You can move, or remove it, as needed.
            this.jaargegevensTableAdapter.Fill(this._Cmbap_dataDataSet.Jaargegevens);

            ToolTip toolTip1 = new ToolTip();

            //Zorgen dat verandering in datagrid alleen wordt uitgevoerd als er geen record verwijderd wordt
            bDeleteRecord = false;

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 2500;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.msktxtbxBegindatum, "Begindatum van een jaar of periode");
            toolTip1.SetToolTip(this.msktxtbxEinddatum, "Einddatum van een jaar of periode");
            toolTip1.SetToolTip(this.msktxtbxOmschrijving, "Naam/omschrijving van jaar of periode");
            toolTip1.SetToolTip(this.msktxtbxOpmerking, "Opmerking met extra (aanvullende) informatie over jaar of periode");
            //actueelJaarGegevensId = 0;
        }

        private void vulNaMove()
        {
            int rijIndex = dtgrdvwJaarGegevens.CurrentCell.RowIndex;
            actueelJaarGegevensId = int.Parse(dtgrdvwJaarGegevens.Rows[rijIndex].Cells[0].Value.ToString());
            tblJg jg = new tblJg();

            jg.zoekJaarGegevensRecord("Jgeg_Id = " + dtgrdvwJaarGegevens.Rows[rijIndex].Cells[0].Value.ToString());
            if (jg.lstJaarGegevensRecord.Count == 1)
            {
                var jgVan = jg.vanRecord(0);
                if (actueelJaarGegevensId != jgVan.Jgeg_Id)
                {
                    vulVelden(jgVan);
                }
            }
        }

        private void vulVelden(tblJg.jgRecord jgVan)
        {
            actueelJaarGegevensId = jgVan.Jgeg_Id;
            this.msktxtbxOmschrijving.Text = jgVan.Jgeg_Omschrijving;
            this.msktxtbxBegindatum.Text = jgVan.Jgeg_Begindatum.ToString("dd-MM-yyyy");
            this.msktxtbxEinddatum.Text = jgVan.Jgeg_Einddatum.ToString("dd-MM-yyyy");
            this.msktxtbxOpmerking.Text = jgVan.Jgeg_Opmerking;
            if (jgVan.Jgeg_Opmerking == "")
            {
                msktxtbxOpmerking.Visible = false;
                lblOpmerking.Text = "Opm.";
                lblOpmerking.Width = 45;
            }
            else
            {
                msktxtbxOpmerking.Visible = true;
                lblOpmerking.Text = "Opmerking";
                lblOpmerking.Width = 70;
            }
            jgOld.Jgeg_Id = jgVan.Jgeg_Id;
            jgOld.Jgeg_StatusId = jgVan.Jgeg_StatusId;
            jgOld.Jgeg_DispStatus = jgVan.Jgeg_DispStatus;
            jgOld.Jgeg_Omschrijving = jgVan.Jgeg_Omschrijving;
            jgOld.Jgeg_Begindatum = jgVan.Jgeg_Begindatum;
            jgOld.Jgeg_Einddatum = jgVan.Jgeg_Einddatum;
            jgOld.Jgeg_Mutatiedatum = jgVan.Jgeg_Mutatiedatum;
            jgOld.Jgeg_Opmerking = jgVan.Jgeg_Opmerking;
            bValuesChanges = false;
            setSaveButton();
        }

        private void setSaveButton()
        {
            if (bValuesChanges == true) btnOpslaan.Enabled = true;
            else btnOpslaan.Enabled = false;
        }

        private void lblOpmerking_Click(object sender, EventArgs e)
        {
            if (this.msktxtbxOpmerking.Visible == true)
            {
                this.msktxtbxOpmerking.Visible = false;
                this.lblOpmerking.Text = "Opm.";
            }
            else
            {
                this.msktxtbxOpmerking.Visible = true;
                this.lblOpmerking.Text = "Opmerking:";
            }
        }

        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            int rijIndex = dtgrdvwJaarGegevens.CurrentCell.RowIndex;
            actueelJaarGegevensId = int.Parse(dtgrdvwJaarGegevens.Rows[rijIndex].Cells[0].Value.ToString());
            tblJg jg = new tblJg();

            jg.zoekJaarGegevensRecord("Jgeg_Id = " + dtgrdvwJaarGegevens.Rows[rijIndex].Cells[0].Value.ToString());
            if (jg.lstJaarGegevensRecord.Count == 1)
            {
                var jgVan = jg.vanRecord(0);
                vulVelden(jgVan);
            }
            btnToevoegen.Enabled = true;
            btnVerwijderen.Enabled = true;
            dtgrdvwJaarGegevens.Enabled = true;
            dtgrdvwJaarGegevens.Refresh();
        }

        private void btnToevoegen_Click(object sender, EventArgs e)
        {
            tblJg jg = new tblJg();
            /*
                        if (gv.instellingUserMode == 5)
                        {
                            if ((jg.telJaarGegevensRecord("") + 1) > (gv.instellingDemoAantalJaren + gv.instellingDemoExtraAantalJaren + 1)) // +1 voor het initialisatierecord
                            {
                                string sAantal = "In de demo-versie kunnen maximaal \n" + (gv.instellingDemoAantalJaren + gv.instellingDemoExtraAantalJaren).ToString() + " jaren worden ingevoerd.\n Maximaal aantal wordt nu overschreden!";
                                Result resultAantal = MessageBox.Show(sAantal, "Maximaal aantal jaren in demo-versie");
                                return;
                            }
                        }
            */
            int newJgId = jg.newJgRecord();
            actueelJaarGegevensId = newJgId;

            jg.zoekJaarGegevensRecord("Jgeg_Id = " + newJgId.ToString());
            var jgVan = jg.vanRecord(0);
            vulVelden(jgVan);
            bNewRecord = true;
            bValuesChanges = true;
            setSaveButton();

        }

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            tblJg.jgRecord jgr = new tblJg.jgRecord();
            jgr.Jgeg_Id = actueelJaarGegevensId;
            jgr.Jgeg_StatusId = 180002;
            tblSt st = new tblSt();
            st.zoekStatusRecord("Status_Code = 180002");
            jgr.Jgeg_DispStatus = st.lstStatusRecord[0].Status_Lang;
            jgr.Jgeg_Omschrijving = msktxtbxOmschrijving.Text;
            jgr.Jgeg_Begindatum = DateTime.Parse(msktxtbxBegindatum.Text);
            jgr.Jgeg_Einddatum = DateTime.Parse(msktxtbxEinddatum.Text);
            jgr.Jgeg_Mutatiedatum = DateTime.Now;
            jgr.Jgeg_Opmerking = msktxtbxOpmerking.Text;

            // Record saven
            tblJg jg = new tblJg();
            jg.saveRecord(actueelJaarGegevensId, jgr);
            bDeleteRecord = true;
            this.jaargegevensTableAdapter.Fill(this._Cmbap_dataDataSet.Jaargegevens);
            bDeleteRecord = false;
            bNewRecord = false;
            bValuesChanges = false;
            setSaveButton();

        }

        private void dtgrdvwJaarGegevens_SelectionChanged(object sender, EventArgs e)
        {
            if (bDeleteRecord == false)
            {
                int rijIndex = dtgrdvwJaarGegevens.CurrentCell.RowIndex;
                dtgrdvwJaarGegevens.Rows[rijIndex].Selected = true;
                int JaarGegevensId = int.Parse(dtgrdvwJaarGegevens.Rows[rijIndex].Cells[0].Value.ToString());
                tblJg jg = new tblJg();

                jg.zoekJaarGegevensRecord("Jgeg_Id = " + dtgrdvwJaarGegevens.Rows[rijIndex].Cells[0].Value.ToString());
                if (jg.lstJaarGegevensRecord.Count == 1)
                {
                    var jgVan = jg.vanRecord(0);
                    if (actueelJaarGegevensId != jgVan.Jgeg_Id)
                    {
                        vulVelden(jgVan);
                    }
                }
            }
        }

        private void btnEersteRecord_Click(object sender, EventArgs e)
        {
            int recCount = this.dtgrdvwJaarGegevens.RowCount;
            this.dtgrdvwJaarGegevens.CurrentCell = this.dtgrdvwJaarGegevens.Rows[0].Cells[this.dtgrdvwJaarGegevens.CurrentCell.ColumnIndex];
            vulNaMove();
        }

        private void frmInvoerJaarGegevens_Activated(object sender, EventArgs e)
        {
           lblOpmerking.BackColor = Color.FromArgb(255, 255, 192);
        }
        
        private void btnLaatsteRecord_Click(object sender, EventArgs e)
        {
            int recCount = this.dtgrdvwJaarGegevens.RowCount;
            this.dtgrdvwJaarGegevens.CurrentCell = this.dtgrdvwJaarGegevens.Rows[recCount - 1].Cells[this.dtgrdvwJaarGegevens.CurrentCell.ColumnIndex];
            vulNaMove();
        }

        private void msktxtbxOmschrijving_TextChanged(object sender, EventArgs e)
        {
            bValuesChanges = true;
            setSaveButton();
        }

        private void btnVorigRecord_Click(object sender, EventArgs e)
        {
            if (this.dtgrdvwJaarGegevens.CurrentRow != null)
            {
                try
                {
                    this.dtgrdvwJaarGegevens.CurrentCell = this.dtgrdvwJaarGegevens.Rows[this.dtgrdvwJaarGegevens.CurrentRow.Index - 1].Cells[this.dtgrdvwJaarGegevens.CurrentCell.ColumnIndex];
                    vulNaMove();
                }
                catch (Exception ex)
                {
                    return;
                }
            }

        }

        private void btnVolgendRecord_Click(object sender, EventArgs e)
        {
            if (this.dtgrdvwJaarGegevens.CurrentRow != null)
            {
                try
                {
                    this.dtgrdvwJaarGegevens.CurrentCell = this.dtgrdvwJaarGegevens.Rows[this.dtgrdvwJaarGegevens.CurrentRow.Index + 1].Cells[this.dtgrdvwJaarGegevens.CurrentCell.ColumnIndex];
                    vulNaMove();
                }
                catch (Exception ex)
                {
                    return;
                }
            }
        }

        private void btnOpmerking_Click(object sender, EventArgs e)
        {
            if (this.msktxtbxOpmerking.Visible == true)
            {
                this.msktxtbxOpmerking.Visible = false;
                this.lblOpmerking.Text = "Opm.";
            }
            else
            {
                this.msktxtbxOpmerking.Visible = true;
                this.lblOpmerking.Text = "Opmerking:";
            }
        }

        private void msktxtbxOmschrijving_Leave(object sender, EventArgs e)
        {
            tblJg jg = new tblJg();
            int rijIndex = dtgrdvwJaarGegevens.CurrentCell.RowIndex;
            jg.zoekJaarGegevensRecord("Jgeg_Omschrijving = " + msktxtbxOmschrijving.Text);
            if (jg.lstJaarGegevensRecord.Count == 1)
            {
                var jgVan = jg.vanRecord(0);
                if (actueelJaarGegevensId != jgVan.Jgeg_Id)
                {
                    MessageBox.Show("Omschrijving komt al voor!", "Controle invoer");
                    return;
                }
            }
        }

        private void btnVerwijderen_Click(object sender, EventArgs e)
        {
            if (actueelJaarGegevensId != 0)
            {
                tblVr vr = new tblVr();
                int ssAantal;
                int vrAantal;
                int jsAantal;

                // Controle gebruik in voorraad
                vr.bvrNaarList = false;
                vrAantal = vr.telVoorraadRecord("Vrrd_JgegId = " + actueelJaarGegevensId.ToString());

                // Controle gebruik in Jaarsaldo
                tblJs js = new tblJs();
                jsAantal = js.telJaarSaldoRecord("Jsal_JgegId = " + actueelJaarGegevensId.ToString());

                // Controle gebruik in Saldostand
                tblSs ss = new tblSs();
                ssAantal = ss.telSaldoStandRecord("Saldostand_JgegId = " + actueelJaarGegevensId.ToString());

                string sGebruik = "";
                if (vrAantal != 0 && ssAantal != 0 && jsAantal != 0)
                {
                    sGebruik = "Jaargegevens " + msktxtbxOmschrijving.Text + " \nis nog in gebruik bij: \n\n";
                    if (vrAantal!=0) { sGebruik = sGebruik + "- " + vrAantal.ToString() + " voorraadrecords" + "\n"; }
                    if (jsAantal != 0) { sGebruik = sGebruik + "- " + jsAantal.ToString() + " jaarsaldorecords" + "\n"; }
                    if (ssAantal != 0) { sGebruik = sGebruik + "- " + ssAantal.ToString() + " saldostandrecords" + "\n"; }
                    sGebruik=sGebruik+"Verwijderen is niet mogelijk!";
                }

                if (sGebruik != "")
                {
                    DialogResult resultDelete = MessageBox.Show(sGebruik, "Jaargegevens verwijderen?");
                }
                else
                {
                    int iId = actueelJaarGegevensId;
                    string sJaarGegevens = "Wilt u deze jaargegevens (" + msktxtbxOmschrijving.Text + ") verwijderen?";
                    DialogResult resultDelete = MessageBox.Show(sJaarGegevens, "Jaargegevens verwijderen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (resultDelete == DialogResult.Yes)
                    {
                        tblJg jg = new tblJg();
                        if (actueelJaarGegevensId == 0 && iId != 0)
                        {
                            actueelJaarGegevensId = iId;
                            jg.deleteRecord(actueelJaarGegevensId);
                            //DisplayData();
                            bDeleteRecord = true;
                            this.jaargegevensTableAdapter.Fill(this._Cmbap_dataDataSet.Jaargegevens);
                            bDeleteRecord = false;

                            int rijIndex = dtgrdvwJaarGegevens.CurrentCell.RowIndex;
                            int JaarGegevensId = int.Parse(dtgrdvwJaarGegevens.Rows[rijIndex].Cells[0].Value.ToString());

                            jg.zoekJaarGegevensRecord("Jgeg_Id = " + dtgrdvwJaarGegevens.Rows[rijIndex].Cells[0].Value.ToString());
                            if (jg.lstJaarGegevensRecord.Count == 1)
                            {
                                var jgVan = jg.vanRecord(0);
                                if (actueelJaarGegevensId != jgVan.Jgeg_Id)
                                {
                                    vulVelden(jgVan);
                                }
                            }
                        }
                    }
                }
            }

        }
    }
}
