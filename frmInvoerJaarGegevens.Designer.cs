namespace Cmbap
{
    partial class frmInvoerJaarGegevens
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle52 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSluiten = new System.Windows.Forms.Button();
            this.dtgrdvwJaarGegevens = new System.Windows.Forms.DataGridView();
            this.jaargegevensBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._Cmbap_dataDataSet = new Cmbap._Cmbap_dataDataSet();
            this.jaargegevensTableAdapter = new Cmbap._Cmbap_dataDataSetTableAdapters.JaargegevensTableAdapter();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblJaargegevens = new System.Windows.Forms.Label();
            this.lblOmschrijving = new System.Windows.Forms.Label();
            this.lblEinddatum = new System.Windows.Forms.Label();
            this.lblBegindatum = new System.Windows.Forms.Label();
            this.lblOpmerking = new System.Windows.Forms.Label();
            this.msktxtbxBegindatum = new System.Windows.Forms.MaskedTextBox();
            this.msktxtbxEinddatum = new System.Windows.Forms.MaskedTextBox();
            this.msktxtbxOmschrijving = new System.Windows.Forms.MaskedTextBox();
            this.msktxtbxOpmerking = new System.Windows.Forms.MaskedTextBox();
            this.jgegIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jgegStatusIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jgegDispStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jgegOmschrijvingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jgegBegindatumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jgegEinddatumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jgegMutatiedatumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jgegOpmerkingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpbxCtrls = new System.Windows.Forms.GroupBox();
            this.btnEersteRecord = new System.Windows.Forms.Button();
            this.btnLaatsteRecord = new System.Windows.Forms.Button();
            this.btnVorigRecord = new System.Windows.Forms.Button();
            this.btnVolgendRecord = new System.Windows.Forms.Button();
            this.btnOpslaan = new System.Windows.Forms.Button();
            this.btnToevoegen = new System.Windows.Forms.Button();
            this.btnVerwijderen = new System.Windows.Forms.Button();
            this.btnAnnuleren = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdvwJaarGegevens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jaargegevensBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._Cmbap_dataDataSet)).BeginInit();
            this.grpbxCtrls.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSluiten
            // 
            this.btnSluiten.Location = new System.Drawing.Point(525, 524);
            this.btnSluiten.Name = "btnSluiten";
            this.btnSluiten.Size = new System.Drawing.Size(75, 23);
            this.btnSluiten.TabIndex = 0;
            this.btnSluiten.Text = "Sluiten";
            this.btnSluiten.UseVisualStyleBackColor = true;
            this.btnSluiten.Click += new System.EventHandler(this.btnSluiten_Click);
            // 
            // dtgrdvwJaarGegevens
            // 
            this.dtgrdvwJaarGegevens.AutoGenerateColumns = false;
            this.dtgrdvwJaarGegevens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrdvwJaarGegevens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.jgegIdDataGridViewTextBoxColumn,
            this.jgegStatusIdDataGridViewTextBoxColumn,
            this.jgegDispStatusDataGridViewTextBoxColumn,
            this.jgegOmschrijvingDataGridViewTextBoxColumn,
            this.jgegBegindatumDataGridViewTextBoxColumn,
            this.jgegEinddatumDataGridViewTextBoxColumn,
            this.jgegMutatiedatumDataGridViewTextBoxColumn,
            this.jgegOpmerkingDataGridViewTextBoxColumn});
            this.dtgrdvwJaarGegevens.DataSource = this.jaargegevensBindingSource;
            this.dtgrdvwJaarGegevens.Location = new System.Drawing.Point(28, 50);
            this.dtgrdvwJaarGegevens.Name = "dtgrdvwJaarGegevens";
            this.dtgrdvwJaarGegevens.ReadOnly = true;
            this.dtgrdvwJaarGegevens.RowTemplate.Height = 24;
            this.dtgrdvwJaarGegevens.Size = new System.Drawing.Size(572, 234);
            this.dtgrdvwJaarGegevens.TabIndex = 1;
            this.dtgrdvwJaarGegevens.SelectionChanged += new System.EventHandler(this.dtgrdvwJaarGegevens_SelectionChanged);
            // 
            // jaargegevensBindingSource
            // 
            this.jaargegevensBindingSource.DataMember = "Jaargegevens";
            this.jaargegevensBindingSource.DataSource = this._Cmbap_dataDataSet;
            // 
            // _Cmbap_dataDataSet
            // 
            this._Cmbap_dataDataSet.DataSetName = "_Cmbap_dataDataSet";
            this._Cmbap_dataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // jaargegevensTableAdapter
            // 
            this.jaargegevensTableAdapter.ClearBeforeFill = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(629, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblJaargegevens
            // 
            this.lblJaargegevens.AutoSize = true;
            this.lblJaargegevens.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJaargegevens.Location = new System.Drawing.Point(263, 9);
            this.lblJaargegevens.Name = "lblJaargegevens";
            this.lblJaargegevens.Size = new System.Drawing.Size(149, 25);
            this.lblJaargegevens.TabIndex = 6;
            this.lblJaargegevens.Text = "Jaargegevens";
            this.lblJaargegevens.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblOmschrijving
            // 
            this.lblOmschrijving.AutoSize = true;
            this.lblOmschrijving.Location = new System.Drawing.Point(28, 396);
            this.lblOmschrijving.Name = "lblOmschrijving";
            this.lblOmschrijving.Size = new System.Drawing.Size(93, 17);
            this.lblOmschrijving.TabIndex = 7;
            this.lblOmschrijving.Text = "Omschrijving:";
            // 
            // lblEinddatum
            // 
            this.lblEinddatum.AutoSize = true;
            this.lblEinddatum.Location = new System.Drawing.Point(28, 462);
            this.lblEinddatum.Name = "lblEinddatum";
            this.lblEinddatum.Size = new System.Drawing.Size(79, 17);
            this.lblEinddatum.TabIndex = 8;
            this.lblEinddatum.Text = "Einddatum:";
            // 
            // lblBegindatum
            // 
            this.lblBegindatum.AutoSize = true;
            this.lblBegindatum.Location = new System.Drawing.Point(28, 430);
            this.lblBegindatum.Name = "lblBegindatum";
            this.lblBegindatum.Size = new System.Drawing.Size(87, 17);
            this.lblBegindatum.TabIndex = 9;
            this.lblBegindatum.Text = "Begindatum:";
            // 
            // lblOpmerking
            // 
            this.lblOpmerking.AutoSize = true;
            this.lblOpmerking.Location = new System.Drawing.Point(28, 494);
            this.lblOpmerking.Name = "lblOpmerking";
            this.lblOpmerking.Size = new System.Drawing.Size(42, 17);
            this.lblOpmerking.TabIndex = 10;
            this.lblOpmerking.Text = "Opm.";
            this.lblOpmerking.Click += new System.EventHandler(this.lblOpmerking_Click);
            // 
            // msktxtbxBegindatum
            // 
            this.msktxtbxBegindatum.Location = new System.Drawing.Point(141, 427);
            this.msktxtbxBegindatum.Mask = "00/00/0000";
            this.msktxtbxBegindatum.Name = "msktxtbxBegindatum";
            this.msktxtbxBegindatum.Size = new System.Drawing.Size(81, 22);
            this.msktxtbxBegindatum.TabIndex = 16;
            this.msktxtbxBegindatum.ValidatingType = typeof(System.DateTime);
            this.msktxtbxBegindatum.TextChanged += new System.EventHandler(this.msktxtbxOmschrijving_TextChanged);
            // 
            // msktxtbxEinddatum
            // 
            this.msktxtbxEinddatum.Location = new System.Drawing.Point(141, 459);
            this.msktxtbxEinddatum.Mask = "00/00/0000";
            this.msktxtbxEinddatum.Name = "msktxtbxEinddatum";
            this.msktxtbxEinddatum.Size = new System.Drawing.Size(81, 22);
            this.msktxtbxEinddatum.TabIndex = 17;
            this.msktxtbxEinddatum.ValidatingType = typeof(System.DateTime);
            this.msktxtbxEinddatum.TextChanged += new System.EventHandler(this.msktxtbxOmschrijving_TextChanged);
            // 
            // msktxtbxOmschrijving
            // 
            this.msktxtbxOmschrijving.Location = new System.Drawing.Point(141, 393);
            this.msktxtbxOmschrijving.Mask = "&&&&&&&&&&&&&&&&&&&&&&&&&";
            this.msktxtbxOmschrijving.Name = "msktxtbxOmschrijving";
            this.msktxtbxOmschrijving.Size = new System.Drawing.Size(186, 22);
            this.msktxtbxOmschrijving.TabIndex = 18;
            this.msktxtbxOmschrijving.TextChanged += new System.EventHandler(this.msktxtbxOmschrijving_TextChanged);
            // 
            // msktxtbxOpmerking
            // 
            this.msktxtbxOpmerking.Location = new System.Drawing.Point(141, 491);
            this.msktxtbxOpmerking.Mask = "&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&" +
    "&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&";
            this.msktxtbxOpmerking.Name = "msktxtbxOpmerking";
            this.msktxtbxOpmerking.Size = new System.Drawing.Size(459, 22);
            this.msktxtbxOpmerking.TabIndex = 19;
            this.msktxtbxOpmerking.TextChanged += new System.EventHandler(this.msktxtbxOmschrijving_TextChanged);
            // 
            // jgegIdDataGridViewTextBoxColumn
            // 
            this.jgegIdDataGridViewTextBoxColumn.DataPropertyName = "Jgeg_Id";
            this.jgegIdDataGridViewTextBoxColumn.HeaderText = "Jgeg_Id";
            this.jgegIdDataGridViewTextBoxColumn.Name = "jgegIdDataGridViewTextBoxColumn";
            this.jgegIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.jgegIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // jgegStatusIdDataGridViewTextBoxColumn
            // 
            this.jgegStatusIdDataGridViewTextBoxColumn.DataPropertyName = "Jgeg_StatusId";
            this.jgegStatusIdDataGridViewTextBoxColumn.HeaderText = "Jgeg_StatusId";
            this.jgegStatusIdDataGridViewTextBoxColumn.Name = "jgegStatusIdDataGridViewTextBoxColumn";
            this.jgegStatusIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.jgegStatusIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // jgegDispStatusDataGridViewTextBoxColumn
            // 
            this.jgegDispStatusDataGridViewTextBoxColumn.DataPropertyName = "Jgeg_DispStatus";
            this.jgegDispStatusDataGridViewTextBoxColumn.HeaderText = "Jgeg_DispStatus";
            this.jgegDispStatusDataGridViewTextBoxColumn.Name = "jgegDispStatusDataGridViewTextBoxColumn";
            this.jgegDispStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.jgegDispStatusDataGridViewTextBoxColumn.Visible = false;
            // 
            // jgegOmschrijvingDataGridViewTextBoxColumn
            // 
            this.jgegOmschrijvingDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.jgegOmschrijvingDataGridViewTextBoxColumn.DataPropertyName = "Jgeg_Omschrijving";
            dataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.jgegOmschrijvingDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle49;
            this.jgegOmschrijvingDataGridViewTextBoxColumn.HeaderText = "Omschrijving";
            this.jgegOmschrijvingDataGridViewTextBoxColumn.MaxInputLength = 25;
            this.jgegOmschrijvingDataGridViewTextBoxColumn.Name = "jgegOmschrijvingDataGridViewTextBoxColumn";
            this.jgegOmschrijvingDataGridViewTextBoxColumn.ReadOnly = true;
            this.jgegOmschrijvingDataGridViewTextBoxColumn.ToolTipText = "Geef een omschrijving voor het jaar of periode. Bijv. 2015-2016";
            this.jgegOmschrijvingDataGridViewTextBoxColumn.Width = 135;
            // 
            // jgegBegindatumDataGridViewTextBoxColumn
            // 
            this.jgegBegindatumDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.jgegBegindatumDataGridViewTextBoxColumn.DataPropertyName = "Jgeg_Begindatum";
            dataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle50.Format = "dd-MM-yyyy";
            dataGridViewCellStyle50.NullValue = null;
            this.jgegBegindatumDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle50;
            this.jgegBegindatumDataGridViewTextBoxColumn.HeaderText = "Begindatum";
            this.jgegBegindatumDataGridViewTextBoxColumn.MaxInputLength = 10;
            this.jgegBegindatumDataGridViewTextBoxColumn.Name = "jgegBegindatumDataGridViewTextBoxColumn";
            this.jgegBegindatumDataGridViewTextBoxColumn.ReadOnly = true;
            this.jgegBegindatumDataGridViewTextBoxColumn.ToolTipText = "Begindatum van een jaar of periode";
            this.jgegBegindatumDataGridViewTextBoxColumn.Width = 72;
            // 
            // jgegEinddatumDataGridViewTextBoxColumn
            // 
            this.jgegEinddatumDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.jgegEinddatumDataGridViewTextBoxColumn.DataPropertyName = "Jgeg_Einddatum";
            dataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle51.Format = "dd-MM-yyyy";
            this.jgegEinddatumDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle51;
            this.jgegEinddatumDataGridViewTextBoxColumn.HeaderText = "Einddatum";
            this.jgegEinddatumDataGridViewTextBoxColumn.MaxInputLength = 10;
            this.jgegEinddatumDataGridViewTextBoxColumn.Name = "jgegEinddatumDataGridViewTextBoxColumn";
            this.jgegEinddatumDataGridViewTextBoxColumn.ReadOnly = true;
            this.jgegEinddatumDataGridViewTextBoxColumn.ToolTipText = "Einddatum van een jaar of periode";
            this.jgegEinddatumDataGridViewTextBoxColumn.Width = 72;
            // 
            // jgegMutatiedatumDataGridViewTextBoxColumn
            // 
            this.jgegMutatiedatumDataGridViewTextBoxColumn.DataPropertyName = "Jgeg_Mutatiedatum";
            this.jgegMutatiedatumDataGridViewTextBoxColumn.HeaderText = "Jgeg_Mutatiedatum";
            this.jgegMutatiedatumDataGridViewTextBoxColumn.Name = "jgegMutatiedatumDataGridViewTextBoxColumn";
            this.jgegMutatiedatumDataGridViewTextBoxColumn.ReadOnly = true;
            this.jgegMutatiedatumDataGridViewTextBoxColumn.Visible = false;
            // 
            // jgegOpmerkingDataGridViewTextBoxColumn
            // 
            this.jgegOpmerkingDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.jgegOpmerkingDataGridViewTextBoxColumn.DataPropertyName = "Jgeg_Opmerking";
            dataGridViewCellStyle52.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.jgegOpmerkingDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle52;
            this.jgegOpmerkingDataGridViewTextBoxColumn.HeaderText = "Opmerking";
            this.jgegOpmerkingDataGridViewTextBoxColumn.Name = "jgegOpmerkingDataGridViewTextBoxColumn";
            this.jgegOpmerkingDataGridViewTextBoxColumn.ReadOnly = true;
            this.jgegOpmerkingDataGridViewTextBoxColumn.Width = 250;
            // 
            // grpbxCtrls
            // 
            this.grpbxCtrls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(120)))));
            this.grpbxCtrls.Controls.Add(this.btnEersteRecord);
            this.grpbxCtrls.Controls.Add(this.btnLaatsteRecord);
            this.grpbxCtrls.Controls.Add(this.btnVorigRecord);
            this.grpbxCtrls.Controls.Add(this.btnVolgendRecord);
            this.grpbxCtrls.Controls.Add(this.btnOpslaan);
            this.grpbxCtrls.Controls.Add(this.btnToevoegen);
            this.grpbxCtrls.Controls.Add(this.btnVerwijderen);
            this.grpbxCtrls.Controls.Add(this.btnAnnuleren);
            this.grpbxCtrls.Location = new System.Drawing.Point(28, 290);
            this.grpbxCtrls.Name = "grpbxCtrls";
            this.grpbxCtrls.Size = new System.Drawing.Size(572, 71);
            this.grpbxCtrls.TabIndex = 39;
            this.grpbxCtrls.TabStop = false;
            // 
            // btnEersteRecord
            // 
            this.btnEersteRecord.BackgroundImage = global::Cmbap.Properties.Resources.begin;
            this.btnEersteRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEersteRecord.Location = new System.Drawing.Point(238, 24);
            this.btnEersteRecord.Name = "btnEersteRecord";
            this.btnEersteRecord.Size = new System.Drawing.Size(26, 26);
            this.btnEersteRecord.TabIndex = 3;
            this.btnEersteRecord.UseVisualStyleBackColor = true;
            this.btnEersteRecord.Click += new System.EventHandler(this.btnEersteRecord_Click);
            // 
            // btnLaatsteRecord
            // 
            this.btnLaatsteRecord.BackgroundImage = global::Cmbap.Properties.Resources.eind;
            this.btnLaatsteRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLaatsteRecord.Location = new System.Drawing.Point(334, 24);
            this.btnLaatsteRecord.Name = "btnLaatsteRecord";
            this.btnLaatsteRecord.Size = new System.Drawing.Size(26, 26);
            this.btnLaatsteRecord.TabIndex = 6;
            this.btnLaatsteRecord.UseVisualStyleBackColor = true;
            this.btnLaatsteRecord.Click += new System.EventHandler(this.btnLaatsteRecord_Click);
            // 
            // btnVorigRecord
            // 
            this.btnVorigRecord.BackgroundImage = global::Cmbap.Properties.Resources.pijlVorige;
            this.btnVorigRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVorigRecord.Location = new System.Drawing.Point(270, 24);
            this.btnVorigRecord.Name = "btnVorigRecord";
            this.btnVorigRecord.Size = new System.Drawing.Size(26, 26);
            this.btnVorigRecord.TabIndex = 4;
            this.btnVorigRecord.UseVisualStyleBackColor = true;
            this.btnVorigRecord.Click += new System.EventHandler(this.btnVorigRecord_Click);
            // 
            // btnVolgendRecord
            // 
            this.btnVolgendRecord.BackgroundImage = global::Cmbap.Properties.Resources.pijlVolgende;
            this.btnVolgendRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVolgendRecord.Location = new System.Drawing.Point(302, 24);
            this.btnVolgendRecord.Name = "btnVolgendRecord";
            this.btnVolgendRecord.Size = new System.Drawing.Size(26, 26);
            this.btnVolgendRecord.TabIndex = 5;
            this.btnVolgendRecord.UseVisualStyleBackColor = true;
            this.btnVolgendRecord.Click += new System.EventHandler(this.btnVolgendRecord_Click);
            // 
            // btnOpslaan
            // 
            this.btnOpslaan.Enabled = false;
            this.btnOpslaan.Location = new System.Drawing.Point(142, 21);
            this.btnOpslaan.Name = "btnOpslaan";
            this.btnOpslaan.Size = new System.Drawing.Size(90, 33);
            this.btnOpslaan.TabIndex = 2;
            this.btnOpslaan.Text = "Opslaan";
            this.btnOpslaan.UseVisualStyleBackColor = true;
            this.btnOpslaan.Click += new System.EventHandler(this.btnOpslaan_Click);
            // 
            // btnToevoegen
            // 
            this.btnToevoegen.Location = new System.Drawing.Point(6, 21);
            this.btnToevoegen.Name = "btnToevoegen";
            this.btnToevoegen.Size = new System.Drawing.Size(126, 33);
            this.btnToevoegen.TabIndex = 1;
            this.btnToevoegen.Text = "Nieuw jaar";
            this.btnToevoegen.UseVisualStyleBackColor = true;
            this.btnToevoegen.Click += new System.EventHandler(this.btnToevoegen_Click);
            // 
            // btnVerwijderen
            // 
            this.btnVerwijderen.Location = new System.Drawing.Point(463, 21);
            this.btnVerwijderen.Name = "btnVerwijderen";
            this.btnVerwijderen.Size = new System.Drawing.Size(103, 33);
            this.btnVerwijderen.TabIndex = 8;
            this.btnVerwijderen.Text = "Verwijderen";
            this.btnVerwijderen.UseVisualStyleBackColor = true;
            // 
            // btnAnnuleren
            // 
            this.btnAnnuleren.Enabled = false;
            this.btnAnnuleren.Location = new System.Drawing.Point(366, 21);
            this.btnAnnuleren.Name = "btnAnnuleren";
            this.btnAnnuleren.Size = new System.Drawing.Size(81, 33);
            this.btnAnnuleren.TabIndex = 7;
            this.btnAnnuleren.Text = "Annuleren";
            this.btnAnnuleren.UseVisualStyleBackColor = true;
            this.btnAnnuleren.Click += new System.EventHandler(this.btnAnnuleren_Click);
            // 
            // frmInvoerJaarGegevens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(629, 559);
            this.Controls.Add(this.grpbxCtrls);
            this.Controls.Add(this.msktxtbxOpmerking);
            this.Controls.Add(this.msktxtbxOmschrijving);
            this.Controls.Add(this.msktxtbxEinddatum);
            this.Controls.Add(this.msktxtbxBegindatum);
            this.Controls.Add(this.lblOpmerking);
            this.Controls.Add(this.lblBegindatum);
            this.Controls.Add(this.lblEinddatum);
            this.Controls.Add(this.lblOmschrijving);
            this.Controls.Add(this.lblJaargegevens);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dtgrdvwJaarGegevens);
            this.Controls.Add(this.btnSluiten);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInvoerJaarGegevens";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoer/wijzigen jaargegevens";
            this.Activated += new System.EventHandler(this.frmInvoerJaarGegevens_Activated);
            this.Load += new System.EventHandler(this.frmInvoerJaarGegevens_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdvwJaarGegevens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jaargegevensBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._Cmbap_dataDataSet)).EndInit();
            this.grpbxCtrls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSluiten;
        private System.Windows.Forms.DataGridView dtgrdvwJaarGegevens;
        private _Cmbap_dataDataSet _Cmbap_dataDataSet;
        private System.Windows.Forms.BindingSource jaargegevensBindingSource;
        private _Cmbap_dataDataSetTableAdapters.JaargegevensTableAdapter jaargegevensTableAdapter;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label lblJaargegevens;
        private System.Windows.Forms.Label lblOmschrijving;
        private System.Windows.Forms.Label lblEinddatum;
        private System.Windows.Forms.Label lblBegindatum;
        private System.Windows.Forms.Label lblOpmerking;
        private System.Windows.Forms.MaskedTextBox msktxtbxBegindatum;
        private System.Windows.Forms.MaskedTextBox msktxtbxEinddatum;
        private System.Windows.Forms.MaskedTextBox msktxtbxOmschrijving;
        private System.Windows.Forms.MaskedTextBox msktxtbxOpmerking;
        private System.Windows.Forms.DataGridViewTextBoxColumn jgegIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jgegStatusIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jgegDispStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jgegOmschrijvingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jgegBegindatumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jgegEinddatumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jgegMutatiedatumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jgegOpmerkingDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox grpbxCtrls;
        private System.Windows.Forms.Button btnEersteRecord;
        private System.Windows.Forms.Button btnLaatsteRecord;
        private System.Windows.Forms.Button btnVorigRecord;
        private System.Windows.Forms.Button btnVolgendRecord;
        private System.Windows.Forms.Button btnOpslaan;
        private System.Windows.Forms.Button btnToevoegen;
        private System.Windows.Forms.Button btnVerwijderen;
        private System.Windows.Forms.Button btnAnnuleren;
    }
}