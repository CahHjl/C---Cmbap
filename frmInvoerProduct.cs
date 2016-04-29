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
using nsTblPd;
using nsTblSt;
using nsTblBl;
using nsTblVr;


namespace InvoerProduct
{
    public partial class frmInvoerProduct : Form
    {
        public int actueelProductId;
        public tblPd pdc = new tblPd();
        private bool bNewRecord; // wordt op True gezet als toevoegen/nieuw wordt aangeklikt
        private bool bDeleteRecord;
        private bool bValuesChanges; // Wordt true als er waarden veranderen t.o.v. oorspronkelijk
        public tblPd.pdRecord pdOld = new tblPd.pdRecord();
        private string sNJ;
        private string sUit;
        private int iUit;
        private double dUit;
        private decimal decUit;
        private byte yUit;

        public frmInvoerProduct()
        {
            InitializeComponent();
        }

        private void btnSluitn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInvoerProduct_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_Cmbap_dataDataSet.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this._Cmbap_dataDataSet.Product);

            // Tooltips
            // Create the ToolTip and associate with the Form container.
            // Overgenomen van https://msdn.microsoft.com/en-us/library/system.windows.forms.tooltip%28v=vs.110%29.aspx
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
            toolTip1.SetToolTip(this.txtbxKorteNaam, "Korte naam van een product (10 tekens)");
            toolTip1.SetToolTip(this.cmbbxActief, "Actief maken van product. \n Inactief product alleen bij wijzigen te gebruiken. \n Waarden: Ja of Nee");
            toolTip1.SetToolTip(this.txtbxLangeNaam, "Lange naam van een product (35 tekens)");
            toolTip1.SetToolTip(this.txtbxKleur, "Kleur van het product (10 tekens)");
            toolTip1.SetToolTip(this.txtbxCode, "Code van het product (10 tekens)");
            toolTip1.SetToolTip(this.cmbbxSoort, "Soort product: B(onnen) of M(unten)");
            toolTip1.SetToolTip(this.txtbxWaarde, "Waarde van het product in hele euro's");
            toolTip1.SetToolTip(this.txtbxEenhedenPerProduct, "Aantal eenheden (bonnen of munten) binnen het product (standaard 20)");
            toolTip1.SetToolTip(this.txtbxWaardePerEenheid, "Waarde per eenheid = Waarde / Aantal eenheden (automatisch berekend)");
            toolTip1.SetToolTip(this.txtbxVerzamelnaam, "Verzamelnaam (10 tekens) van een product (default 'vel')");

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.productTableAdapter.FillBy(this._Cmbap_dataDataSet.Product);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.productTableAdapter.FillBy1(this._Cmbap_dataDataSet.Product);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void vulNaMove()
        {
            int rijIndex = dtgrdvwProducten.CurrentCell.RowIndex;
            actueelProductId = int.Parse(dtgrdvwProducten.Rows[rijIndex].Cells[0].Value.ToString());
            tblPd pd = new tblPd();

            pd.zoekProductRecord("Prod_Id = " + dtgrdvwProducten.Rows[rijIndex].Cells[0].Value.ToString());
            if (pd.lstProductRecord.Count == 1)
            {
                var pdVan = pd.vanRecord(0);
                if (actueelProductId != pdVan.Prod_Id)
                {
                    vulVelden(pdVan);
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (bDeleteRecord == false)
            {
                int rijIndex = dtgrdvwProducten.CurrentCell.RowIndex;
                dtgrdvwProducten.Rows[rijIndex].Selected = true;
                int ProductId = int.Parse(dtgrdvwProducten.Rows[rijIndex].Cells[0].Value.ToString());
                tblPd pd = new tblPd();

                pd.zoekProductRecord("Prod_Id = " + dtgrdvwProducten.Rows[rijIndex].Cells[0].Value.ToString());
                if (pd.lstProductRecord.Count == 1)
                {
                    var pdVan = pd.vanRecord(0);
                    if (actueelProductId != pdVan.Prod_Id)
                    {
                        vulVelden(pdVan);
                    }
                }
            }
            
        }

        private void vulVelden(tblPd.pdRecord pdVan)
        {
            actueelProductId= pdVan.Prod_Id;
            this.txtbxKorteNaam.Text = pdVan.Prod_Naamkort;
            this.txtbxLangeNaam.Text = pdVan.Prod_Naamlang;
            this.txtbxVerzamelnaam.Text = pdVan.Prod_Verzamelnaam;
            this.txtbxKleur.Text = pdVan.Prod_Kleur;
            this.txtbxCode.Text = pdVan.Prod_Code;
            this.cmbbxSoort.SelectedIndex = (pdVan.Prod_Soort=="B") ? 0 : 1;
            this.cmbbxActief.SelectedIndex = (pdVan.Prod_ActiefJN == 0) ? 1 : 0;
            this.txtbxWaarde.Text = pdVan.Prod_Waarde.ToString();
            this.txtbxEenhedenPerProduct.Text = pdVan.Prod_Aantaleenhedenperproduct.ToString();
            this.txtbxWaardePerEenheid.Text = pdVan.Prod_Waardepereenheid.ToString();
            this.txtbxOpmerking.Text = pdVan.Prod_Opmerking;
            if (pdVan.Prod_Opmerking == "")
            {
                txtbxOpmerking.Visible = false;
                btnOpmerking.Text = "Opm.";
                btnOpmerking.Width = 45;
            }
            else
            {
                txtbxOpmerking.Visible = true;
                btnOpmerking.Text = "Opmerking";
                btnOpmerking.Width = 70;
            }
            pdOld.Prod_Id = pdVan.Prod_Id;
            pdOld.Prod_StatusId = pdVan.Prod_StatusId;
            pdOld.Prod_DispStatus = pdVan.Prod_DispStatus;
            pdOld.Prod_Naamkort = pdVan.Prod_Naamkort;
            pdOld.Prod_Naamlang = pdVan.Prod_Naamlang;
            pdOld.Prod_Kleur = pdVan.Prod_Kleur;
            pdOld.Prod_Code = pdVan.Prod_Code;
            pdOld.Prod_Soort = pdVan.Prod_Soort;
            pdOld.Prod_ActiefJN = pdVan.Prod_ActiefJN;
            pdOld.Prod_Dispactief = pdVan.Prod_Dispactief;
            pdOld.Prod_Waarde = pdVan.Prod_Waarde;
            pdOld.Prod_Aantaleenhedenperproduct = pdVan.Prod_Aantaleenhedenperproduct;
            pdOld.Prod_Verzamelnaam = pdVan.Prod_Verzamelnaam;
            pdOld.Prod_Waardepereenheid = pdVan.Prod_Waardepereenheid;
            pdOld.Prod_Mutatiedatum = pdVan.Prod_Mutatiedatum;
            pdOld.Prod_Opmerking = pdVan.Prod_Opmerking;
            bValuesChanges = false;
            setSaveButton();
            setSaveButton();
        }

        private void btnVorigRecord_Click(object sender, EventArgs e)
        {
            if (this.dtgrdvwProducten.CurrentRow != null)
            {
                try
                {
                    this.dtgrdvwProducten.CurrentCell = this.dtgrdvwProducten.Rows[this.dtgrdvwProducten.CurrentRow.Index - 1].Cells[this.dtgrdvwProducten.CurrentCell.ColumnIndex];
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
            if (this.dtgrdvwProducten.CurrentRow != null)
            {
                try
                {
                    this.dtgrdvwProducten.CurrentCell = this.dtgrdvwProducten.Rows[this.dtgrdvwProducten.CurrentRow.Index + 1].Cells[this.dtgrdvwProducten.CurrentCell.ColumnIndex];
                    vulNaMove();
                }
                catch (Exception ex)
                {
                    return;
                }
            }
        }

        private void btnLaatsteRecord_Click(object sender, EventArgs e)
        {
            int recCount = this.dtgrdvwProducten.RowCount;
            this.dtgrdvwProducten.CurrentCell = this.dtgrdvwProducten.Rows[recCount - 1].Cells[this.dtgrdvwProducten.CurrentCell.ColumnIndex]; ;
            vulNaMove();
        }

        private void btnEersteRecord_Click(object sender, EventArgs e)
        {
            int recCount = this.dtgrdvwProducten.RowCount;
            this.dtgrdvwProducten.CurrentCell = this.dtgrdvwProducten.Rows[0].Cells[this.dtgrdvwProducten.CurrentCell.ColumnIndex];
            vulNaMove();
        }

        private void frmInvoerProduct_Activated(object sender, EventArgs e)
        {
            actueelProductId = 0;
            btnOpmerking.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            int rijIndex = dtgrdvwProducten.CurrentCell.RowIndex;
            actueelProductId = int.Parse(dtgrdvwProducten.Rows[rijIndex].Cells[0].Value.ToString());
            tblPd pd = new tblPd();

            pd.zoekProductRecord("Prod_Id = " + dtgrdvwProducten.Rows[rijIndex].Cells[0].Value.ToString());
            if (pd.lstProductRecord.Count == 1)
            {
                var pdVan = pd.vanRecord(0);
                vulVelden(pdVan);
            }
            btnToevoegen.Enabled = true;
            btnVerwijderen.Enabled = true;
            dtgrdvwProducten.Enabled = true;
            dtgrdvwProducten.Refresh();
        }

        private void waardeBerekening()
        {
            float fWaarde = 0;
            int Aantaleenheden = 0;
            try
            {
                string sWaarde = txtbxWaarde.Text;
                sWaarde.Trim();
                fWaarde = float.Parse(sWaarde);
            }
            catch (Exception ex)
            {                
            }

            try
            {
                Aantaleenheden = int.Parse(txtbxEenhedenPerProduct.Text);
            }
            catch (Exception ex)
            {
            }

            if (Aantaleenheden != 0)
            {
                txtbxWaardePerEenheid.Text = (fWaarde / Aantaleenheden).ToString();
            }
        }

        private void txtbxWaarde_TextChanged(object sender, EventArgs e)
        {
            waardeBerekening();
            bValuesChanges = true;
            setSaveButton();
        }

        private void btnOpmerking_Click(object sender, EventArgs e)
        {
            if (txtbxOpmerking.Visible == true)
            {
                txtbxOpmerking.Visible = false;
                btnOpmerking.Text = "Opm.";
                btnOpmerking.Width = 45;
            }
            else
            { 
                txtbxOpmerking.Visible = true;
                btnOpmerking.Text = "Opmerking";
                btnOpmerking.Width = 70;
            }
        }

        private void txtbxEenhedenPerProduct_TextChanged(object sender, EventArgs e)
        {
            waardeBerekening();
            bValuesChanges = true;
            setSaveButton();
        }

        private void btnToevoegen_Click(object sender, EventArgs e)
        {
            tblPd pd = new tblPd();

            if (gv.instellingUserMode == 5)
            {
                if ((pd.telProductRecord("")+1)>(gv.instellingDemoAantalProducten + gv.instellingDemoExtraAantalProducten))
                {
                    string sAantal = "In de demo-versie kunnen maximaal \n" +(gv.instellingDemoAantalProducten + gv.instellingDemoExtraAantalProducten).ToString() + " producten worden ingevoerd.\n Maximaal aantal wordt nu overschreden!";
                    DialogResult resultAantal = MessageBox.Show(sAantal, "Maximaal aantal producten in demo-versie");
                    return;
                }
            }

            bNewRecord = true;
            int newPdId = pd.newPdRecord();
            actueelProductId = newPdId;

            pd.zoekProductRecord("Prod_Id = " + newPdId.ToString());
            var pdVan = pd.vanRecord(0);
            vulVelden(pdVan);
        }

        private void VergelijkString(string s1, string s2)
        {
            if (s1 == s2) { sNJ = "0"; sUit = s1; }
            else { sNJ = "1"; sUit = s2; }
        }


        private void VergelijkInt(int i1, int i2)
        {
            if (i1 == i2) { sNJ = "0"; iUit = i1; }
            else { sNJ = "1"; iUit = i2; }
        }

        private void VergelijkDecimal(decimal dec1, decimal dec2)
        {
            if (dec1 == dec2) { sNJ = "0"; decUit = dec1; }
            else { sNJ = "1"; decUit = dec2; }
        }

        private void VergelijkByte(byte y1, byte y2)
        {
            if (y1 == y2) { sNJ = "0"; yUit = y1; }
            else { sNJ = "1"; yUit = y2; }
        }

        private decimal txtNaarDecimal(string sTxtIn)
        {
            decimal d1 = 0;
            try
            {
                d1 = Convert.ToDecimal(sTxtIn);
            }
            catch (Exception ex)
            { }
            return d1;
        }

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            tblPd.pdRecord pdr = new tblPd.pdRecord();
            pdr.Prod_Id = actueelProductId;
            pdr.Prod_StatusId = 170002;
            tblSt st = new tblSt();
            st.zoekStatusRecord("Status_Code = 170002");
            pdr.Prod_DispStatus = st.lstStatusRecord[0].Status_Lang;
            pdr.Prod_Naamkort = txtbxKorteNaam.Text;
            pdr.Prod_Naamlang = txtbxLangeNaam.Text;
            pdr.Prod_Kleur = txtbxKleur.Text;
            pdr.Prod_Code = txtbxCode.Text;
            pdr.Prod_Soort=cmbbxSoort.SelectedItem.ToString().Substring(0,1);
            pdr.Prod_ActiefJN = (cmbbxActief.SelectedItem.ToString().ToString().Substring(0,1) == "J" ? 1 : 0);
            pdr.Prod_Dispactief = cmbbxActief.SelectedItem.ToString();
            pdr.Prod_Waarde=txtNaarDecimal(txtbxWaarde.Text);
            pdr.Prod_Aantaleenhedenperproduct=byte.Parse(txtbxEenhedenPerProduct.Text);
            pdr.Prod_Verzamelnaam=txtbxVerzamelnaam.Text;
            pdr.Prod_Waardepereenheid=txtNaarDecimal(txtbxWaardePerEenheid.Text);
            pdr.Prod_Mutatiedatum = DateTime.Now;
            pdr.Prod_Opmerking = txtbxOpmerking.Text;

            // Record saven
            tblPd pd = new tblPd();
            pd.saveRecord(actueelProductId, pdr);
            bDeleteRecord = true;
            this.productTableAdapter.Fill(this._Cmbap_dataDataSet.Product);
            bDeleteRecord = false;
        }

        private void setSaveButton()
        {
            if (bValuesChanges == true) btnOpslaan.Enabled = true;
            else btnOpslaan.Enabled = false;
        }
            
        private void cmbbxActief_TextChanged(object sender, EventArgs e)
        {
            bValuesChanges = true;
            setSaveButton();
        }

        private void DisplayData()
        {
            /*con.Open();
            DataTable dt = new DataTable();
            adapt = new SQLiteDataAdapter("select * from tbl_Record", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();*/
        }

        private void btnVerwijderen_Click(object sender, EventArgs e)
        {
            if (actueelProductId != 0)
            {
                tblVr vr = new tblVr();
                int blAantal;
                int vrAantal;

                vr.bvrNaarList = false;
                vrAantal=vr.telVoorraadRecord("Vrrd_ProdId = "+actueelProductId.ToString());

                tblBl bl = new tblBl();
                blAantal=bl.telBestelregelRecord("Bstlr_ProdId = " + actueelProductId.ToString());

                string sGebruik = "";
                if (vrAantal != 0 && blAantal != 0)
                {
                    sGebruik="Product "+txtbxKorteNaam.Text+" \nis nog in gebruik bij: \n\n" +
                             "- "+vrAantal.ToString() + " voorraadrecords" + "\n -" +
                             "- "+blAantal.ToString() + " bestelregelrecords" + "\n \n" +
                             "Verwijderen is niet mogelijk!";
                }
                if (vrAantal == 0 && blAantal != 0)
                {
                    sGebruik = "Product " + txtbxKorteNaam.Text + " \nis nog in gebruik bij: \n\n" +
                               "- "+ blAantal.ToString() + " bestelregelrecords" + "\n \n" +
                               "Verwijderen is niet mogelijk!";
                }

                if (vrAantal != 0 && blAantal == 0)
                {
                    sGebruik = "Product " + txtbxKorteNaam.Text + " \n is nog in gebruik bij: \n\n" +
                               "- "+vrAantal.ToString() + " voorraadrecords" + "\n \n" +
                               "Verwijderen is niet mogelijk!";
                }


                if (sGebruik != "")
                {
                    DialogResult resultDelete = MessageBox.Show(sGebruik, "Product verwijderen?");
                }
                else
                {
                    int iId = actueelProductId;
                    //  <<Zoek of product wordt gebruikt in Voorraad of in Bestelregels en daar reactie op >>
                    string sProduct = "Wilt u dit product (" + txtbxKorteNaam.Text + ") verwijderen?";
                    DialogResult resultDelete = MessageBox.Show(sProduct, "Product verwijderen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (resultDelete == DialogResult.Yes)
                    {
                        tblPd pd = new tblPd();
                        if (actueelProductId == 0 && iId != 0)
                        {
                            actueelProductId = iId;
                            pd.deleteRecord(actueelProductId);
                            //DisplayData();
                            bDeleteRecord = true;
                            this.productTableAdapter.Fill(this._Cmbap_dataDataSet.Product);
                            bDeleteRecord = false;

                            int rijIndex = dtgrdvwProducten.CurrentCell.RowIndex;
                            int ProductId = int.Parse(dtgrdvwProducten.Rows[rijIndex].Cells[0].Value.ToString());
                            
                            pd.zoekProductRecord("Prod_Id = " + dtgrdvwProducten.Rows[rijIndex].Cells[0].Value.ToString());
                            if (pd.lstProductRecord.Count == 1)
                            {
                                var pdVan = pd.vanRecord(0);
                                if (actueelProductId != pdVan.Prod_Id)
                                {
                                    vulVelden(pdVan);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void txtbxKorteNaam_TextChanged(object sender, EventArgs e)
        {
            bValuesChanges = true;
            setSaveButton();
        }

        private void txtbxLangeNaam_TextChanged(object sender, EventArgs e)
        {
            bValuesChanges = true;
            setSaveButton();
        }

        private void txtbxKleur_TextChanged(object sender, EventArgs e)
        {
            bValuesChanges = true;
            setSaveButton();
        }

        private void txtbxCode_TextChanged(object sender, EventArgs e)
        {
            bValuesChanges = true;
            setSaveButton();
        }

        private void cmbbxSoort_TextChanged(object sender, EventArgs e)
        {
            bValuesChanges = true;
            setSaveButton();
        }

        private void txtbxVerzamelnaam_TextChanged(object sender, EventArgs e)
        {
            bValuesChanges = true;
            setSaveButton();
        }

        private void txtbxOpmerking_TextChanged(object sender, EventArgs e)
        {
            bValuesChanges = true;
            setSaveButton();
        }
    }
}
