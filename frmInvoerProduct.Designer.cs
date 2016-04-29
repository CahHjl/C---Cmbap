namespace InvoerProduct
{
    partial class frmInvoerProduct
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSluitn = new System.Windows.Forms.Button();
            this.dtgrdvwProducten = new System.Windows.Forms.DataGridView();
            this.prodIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prod_DispActief = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodStatusIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodDispStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodNaamkortDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodNaamlangDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodKleurDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodSoortDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodVerzamelnaamDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodWaardeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodAantaleenhedenperproductDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodWaardePerEenheidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodMutatiedatumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodOpmerkingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._Cmbap_dataDataSet = new Cmbap._Cmbap_dataDataSet();
            this.fillBy1ToolStrip = new System.Windows.Forms.ToolStrip();
            this.productTableAdapter = new Cmbap._Cmbap_dataDataSetTableAdapters.ProductTableAdapter();
            this.lblKorteNaam = new System.Windows.Forms.Label();
            this.lblProducten = new System.Windows.Forms.Label();
            this.lblWaardePerEeenheid = new System.Windows.Forms.Label();
            this.txtbxWaardePerEenheid = new System.Windows.Forms.TextBox();
            this.lblEenhedenPerProduct = new System.Windows.Forms.Label();
            this.lblWaarde = new System.Windows.Forms.Label();
            this.lblActief = new System.Windows.Forms.Label();
            this.lblSoort = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblKleur = new System.Windows.Forms.Label();
            this.lblLangeNaam = new System.Windows.Forms.Label();
            this.grpbxCtrls = new System.Windows.Forms.GroupBox();
            this.btnEersteRecord = new System.Windows.Forms.Button();
            this.btnLaatsteRecord = new System.Windows.Forms.Button();
            this.btnVorigRecord = new System.Windows.Forms.Button();
            this.btnVolgendRecord = new System.Windows.Forms.Button();
            this.btnOpslaan = new System.Windows.Forms.Button();
            this.btnToevoegen = new System.Windows.Forms.Button();
            this.btnVerwijderen = new System.Windows.Forms.Button();
            this.btnAnnuleren = new System.Windows.Forms.Button();
            this.cmbbxActief = new System.Windows.Forms.ComboBox();
            this.cmbbxSoort = new System.Windows.Forms.ComboBox();
            this.btnOpmerking = new System.Windows.Forms.Button();
            this.txtbxOpmerking = new System.Windows.Forms.TextBox();
            this.lblVerzamelnaam = new System.Windows.Forms.Label();
            this.txtbxWaarde = new System.Windows.Forms.MaskedTextBox();
            this.txtbxEenhedenPerProduct = new System.Windows.Forms.MaskedTextBox();
            this.txtbxKleur = new System.Windows.Forms.MaskedTextBox();
            this.txtbxKorteNaam = new System.Windows.Forms.MaskedTextBox();
            this.txtbxCode = new System.Windows.Forms.MaskedTextBox();
            this.txtbxVerzamelnaam = new System.Windows.Forms.MaskedTextBox();
            this.txtbxLangeNaam = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdvwProducten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._Cmbap_dataDataSet)).BeginInit();
            this.grpbxCtrls.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSluitn
            // 
            this.btnSluitn.Location = new System.Drawing.Point(1024, 504);
            this.btnSluitn.Name = "btnSluitn";
            this.btnSluitn.Size = new System.Drawing.Size(75, 33);
            this.btnSluitn.TabIndex = 20;
            this.btnSluitn.Text = "Sluiten";
            this.btnSluitn.UseVisualStyleBackColor = true;
            this.btnSluitn.Click += new System.EventHandler(this.btnSluitn_Click);
            // 
            // dtgrdvwProducten
            // 
            this.dtgrdvwProducten.AllowUserToAddRows = false;
            this.dtgrdvwProducten.AllowUserToDeleteRows = false;
            this.dtgrdvwProducten.AutoGenerateColumns = false;
            this.dtgrdvwProducten.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgrdvwProducten.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgrdvwProducten.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dtgrdvwProducten.ColumnHeadersHeight = 45;
            this.dtgrdvwProducten.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prodIdDataGridViewTextBoxColumn,
            this.Prod_DispActief,
            this.prodStatusIdDataGridViewTextBoxColumn,
            this.prodDispStatusDataGridViewTextBoxColumn,
            this.prodNaamkortDataGridViewTextBoxColumn,
            this.prodNaamlangDataGridViewTextBoxColumn,
            this.prodKleurDataGridViewTextBoxColumn,
            this.prodCodeDataGridViewTextBoxColumn,
            this.prodSoortDataGridViewTextBoxColumn,
            this.prodVerzamelnaamDataGridViewTextBoxColumn,
            this.prodWaardeDataGridViewTextBoxColumn,
            this.prodAantaleenhedenperproductDataGridViewTextBoxColumn,
            this.prodWaardePerEenheidDataGridViewTextBoxColumn,
            this.prodMutatiedatumDataGridViewTextBoxColumn,
            this.prodOpmerkingDataGridViewTextBoxColumn});
            this.dtgrdvwProducten.DataSource = this.productBindingSource;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgrdvwProducten.DefaultCellStyle = dataGridViewCellStyle27;
            this.dtgrdvwProducten.Location = new System.Drawing.Point(28, 41);
            this.dtgrdvwProducten.Name = "dtgrdvwProducten";
            this.dtgrdvwProducten.ReadOnly = true;
            this.dtgrdvwProducten.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dtgrdvwProducten.RowTemplate.Height = 24;
            this.dtgrdvwProducten.Size = new System.Drawing.Size(1122, 231);
            this.dtgrdvwProducten.TabIndex = 0;
            this.dtgrdvwProducten.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // prodIdDataGridViewTextBoxColumn
            // 
            this.prodIdDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.prodIdDataGridViewTextBoxColumn.DataPropertyName = "Prod_Id";
            this.prodIdDataGridViewTextBoxColumn.HeaderText = "Prod_Id";
            this.prodIdDataGridViewTextBoxColumn.Name = "prodIdDataGridViewTextBoxColumn";
            this.prodIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.prodIdDataGridViewTextBoxColumn.Visible = false;
            this.prodIdDataGridViewTextBoxColumn.Width = 70;
            // 
            // Prod_DispActief
            // 
            this.Prod_DispActief.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Prod_DispActief.DataPropertyName = "Prod_DispActief";
            this.Prod_DispActief.HeaderText = "Actief";
            this.Prod_DispActief.Name = "Prod_DispActief";
            this.Prod_DispActief.ReadOnly = true;
            this.Prod_DispActief.Width = 40;
            // 
            // prodStatusIdDataGridViewTextBoxColumn
            // 
            this.prodStatusIdDataGridViewTextBoxColumn.DataPropertyName = "Prod_StatusId";
            this.prodStatusIdDataGridViewTextBoxColumn.HeaderText = "Prod_StatusId";
            this.prodStatusIdDataGridViewTextBoxColumn.Name = "prodStatusIdDataGridViewTextBoxColumn";
            this.prodStatusIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.prodStatusIdDataGridViewTextBoxColumn.Visible = false;
            this.prodStatusIdDataGridViewTextBoxColumn.Width = 126;
            // 
            // prodDispStatusDataGridViewTextBoxColumn
            // 
            this.prodDispStatusDataGridViewTextBoxColumn.DataPropertyName = "Prod_DispStatus";
            this.prodDispStatusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.prodDispStatusDataGridViewTextBoxColumn.Name = "prodDispStatusDataGridViewTextBoxColumn";
            this.prodDispStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.prodDispStatusDataGridViewTextBoxColumn.Visible = false;
            this.prodDispStatusDataGridViewTextBoxColumn.Width = 77;
            // 
            // prodNaamkortDataGridViewTextBoxColumn
            // 
            this.prodNaamkortDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.prodNaamkortDataGridViewTextBoxColumn.DataPropertyName = "Prod_Naamkort";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.prodNaamkortDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle19;
            this.prodNaamkortDataGridViewTextBoxColumn.HeaderText = "Korte naam";
            this.prodNaamkortDataGridViewTextBoxColumn.Name = "prodNaamkortDataGridViewTextBoxColumn";
            this.prodNaamkortDataGridViewTextBoxColumn.ReadOnly = true;
            this.prodNaamkortDataGridViewTextBoxColumn.Width = 65;
            // 
            // prodNaamlangDataGridViewTextBoxColumn
            // 
            this.prodNaamlangDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.prodNaamlangDataGridViewTextBoxColumn.DataPropertyName = "Prod_Naamlang";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.prodNaamlangDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle20;
            this.prodNaamlangDataGridViewTextBoxColumn.HeaderText = "Lange naam";
            this.prodNaamlangDataGridViewTextBoxColumn.Name = "prodNaamlangDataGridViewTextBoxColumn";
            this.prodNaamlangDataGridViewTextBoxColumn.ReadOnly = true;
            this.prodNaamlangDataGridViewTextBoxColumn.Width = 220;
            // 
            // prodKleurDataGridViewTextBoxColumn
            // 
            this.prodKleurDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.prodKleurDataGridViewTextBoxColumn.DataPropertyName = "Prod_Kleur";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.prodKleurDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle21;
            this.prodKleurDataGridViewTextBoxColumn.HeaderText = "Kleur";
            this.prodKleurDataGridViewTextBoxColumn.Name = "prodKleurDataGridViewTextBoxColumn";
            this.prodKleurDataGridViewTextBoxColumn.ReadOnly = true;
            this.prodKleurDataGridViewTextBoxColumn.Width = 50;
            // 
            // prodCodeDataGridViewTextBoxColumn
            // 
            this.prodCodeDataGridViewTextBoxColumn.DataPropertyName = "Prod_Code";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.prodCodeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle22;
            this.prodCodeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.prodCodeDataGridViewTextBoxColumn.Name = "prodCodeDataGridViewTextBoxColumn";
            this.prodCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.prodCodeDataGridViewTextBoxColumn.Width = 70;
            // 
            // prodSoortDataGridViewTextBoxColumn
            // 
            this.prodSoortDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.prodSoortDataGridViewTextBoxColumn.DataPropertyName = "Prod_Soort";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.prodSoortDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle23;
            this.prodSoortDataGridViewTextBoxColumn.HeaderText = "Soort";
            this.prodSoortDataGridViewTextBoxColumn.Name = "prodSoortDataGridViewTextBoxColumn";
            this.prodSoortDataGridViewTextBoxColumn.ReadOnly = true;
            this.prodSoortDataGridViewTextBoxColumn.Width = 40;
            // 
            // prodVerzamelnaamDataGridViewTextBoxColumn
            // 
            this.prodVerzamelnaamDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.prodVerzamelnaamDataGridViewTextBoxColumn.DataPropertyName = "Prod_Verzamelnaam";
            this.prodVerzamelnaamDataGridViewTextBoxColumn.HeaderText = "Verzamel- naam";
            this.prodVerzamelnaamDataGridViewTextBoxColumn.Name = "prodVerzamelnaamDataGridViewTextBoxColumn";
            this.prodVerzamelnaamDataGridViewTextBoxColumn.ReadOnly = true;
            this.prodVerzamelnaamDataGridViewTextBoxColumn.Width = 60;
            // 
            // prodWaardeDataGridViewTextBoxColumn
            // 
            this.prodWaardeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.prodWaardeDataGridViewTextBoxColumn.DataPropertyName = "Prod_Waarde";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.Format = "C2";
            dataGridViewCellStyle24.NullValue = null;
            this.prodWaardeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle24;
            this.prodWaardeDataGridViewTextBoxColumn.HeaderText = "Waarde";
            this.prodWaardeDataGridViewTextBoxColumn.Name = "prodWaardeDataGridViewTextBoxColumn";
            this.prodWaardeDataGridViewTextBoxColumn.ReadOnly = true;
            this.prodWaardeDataGridViewTextBoxColumn.Width = 50;
            // 
            // prodAantaleenhedenperproductDataGridViewTextBoxColumn
            // 
            this.prodAantaleenhedenperproductDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.prodAantaleenhedenperproductDataGridViewTextBoxColumn.DataPropertyName = "Prod_Aantaleenhedenperproduct";
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.prodAantaleenhedenperproductDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle25;
            this.prodAantaleenhedenperproductDataGridViewTextBoxColumn.HeaderText = "Eenheden/ product";
            this.prodAantaleenhedenperproductDataGridViewTextBoxColumn.MaxInputLength = 100;
            this.prodAantaleenhedenperproductDataGridViewTextBoxColumn.Name = "prodAantaleenhedenperproductDataGridViewTextBoxColumn";
            this.prodAantaleenhedenperproductDataGridViewTextBoxColumn.ReadOnly = true;
            this.prodAantaleenhedenperproductDataGridViewTextBoxColumn.Width = 65;
            // 
            // prodWaardePerEenheidDataGridViewTextBoxColumn
            // 
            this.prodWaardePerEenheidDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.prodWaardePerEenheidDataGridViewTextBoxColumn.DataPropertyName = "Prod_WaardePerEenheid";
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.Format = "C2";
            dataGridViewCellStyle26.NullValue = "0";
            this.prodWaardePerEenheidDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle26;
            this.prodWaardePerEenheidDataGridViewTextBoxColumn.HeaderText = "Waarde/ eenheid";
            this.prodWaardePerEenheidDataGridViewTextBoxColumn.Name = "prodWaardePerEenheidDataGridViewTextBoxColumn";
            this.prodWaardePerEenheidDataGridViewTextBoxColumn.ReadOnly = true;
            this.prodWaardePerEenheidDataGridViewTextBoxColumn.Width = 50;
            // 
            // prodMutatiedatumDataGridViewTextBoxColumn
            // 
            this.prodMutatiedatumDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.prodMutatiedatumDataGridViewTextBoxColumn.DataPropertyName = "Prod_Mutatiedatum";
            this.prodMutatiedatumDataGridViewTextBoxColumn.HeaderText = "Mutatie- datum";
            this.prodMutatiedatumDataGridViewTextBoxColumn.Name = "prodMutatiedatumDataGridViewTextBoxColumn";
            this.prodMutatiedatumDataGridViewTextBoxColumn.ReadOnly = true;
            this.prodMutatiedatumDataGridViewTextBoxColumn.Visible = false;
            this.prodMutatiedatumDataGridViewTextBoxColumn.Width = 95;
            // 
            // prodOpmerkingDataGridViewTextBoxColumn
            // 
            this.prodOpmerkingDataGridViewTextBoxColumn.DataPropertyName = "Prod_Opmerking";
            this.prodOpmerkingDataGridViewTextBoxColumn.HeaderText = "Opmerking";
            this.prodOpmerkingDataGridViewTextBoxColumn.Name = "prodOpmerkingDataGridViewTextBoxColumn";
            this.prodOpmerkingDataGridViewTextBoxColumn.ReadOnly = true;
            this.prodOpmerkingDataGridViewTextBoxColumn.Width = 106;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            this.productBindingSource.DataSource = this._Cmbap_dataDataSet;
            // 
            // _Cmbap_dataDataSet
            // 
            this._Cmbap_dataDataSet.DataSetName = "_Cmbap_dataDataSet";
            this._Cmbap_dataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fillBy1ToolStrip
            // 
            this.fillBy1ToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.fillBy1ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillBy1ToolStrip.Name = "fillBy1ToolStrip";
            this.fillBy1ToolStrip.Size = new System.Drawing.Size(1175, 25);
            this.fillBy1ToolStrip.TabIndex = 2;
            this.fillBy1ToolStrip.Text = "fillBy1ToolStrip";
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // lblKorteNaam
            // 
            this.lblKorteNaam.AutoSize = true;
            this.lblKorteNaam.Location = new System.Drawing.Point(153, 407);
            this.lblKorteNaam.Name = "lblKorteNaam";
            this.lblKorteNaam.Size = new System.Drawing.Size(85, 17);
            this.lblKorteNaam.TabIndex = 4;
            this.lblKorteNaam.Text = "Korte naam:";
            // 
            // lblProducten
            // 
            this.lblProducten.AutoSize = true;
            this.lblProducten.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducten.Location = new System.Drawing.Point(507, 9);
            this.lblProducten.Name = "lblProducten";
            this.lblProducten.Size = new System.Drawing.Size(110, 25);
            this.lblProducten.TabIndex = 5;
            this.lblProducten.Text = "Producten";
            this.lblProducten.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblWaardePerEeenheid
            // 
            this.lblWaardePerEeenheid.AutoSize = true;
            this.lblWaardePerEeenheid.Location = new System.Drawing.Point(817, 440);
            this.lblWaardePerEeenheid.Name = "lblWaardePerEeenheid";
            this.lblWaardePerEeenheid.Size = new System.Drawing.Size(142, 17);
            this.lblWaardePerEeenheid.TabIndex = 16;
            this.lblWaardePerEeenheid.Text = "Waarde per eenheid:";
            // 
            // txtbxWaardePerEenheid
            // 
            this.txtbxWaardePerEenheid.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._Cmbap_dataDataSet, "Product.Prod_Naamkort", true));
            this.txtbxWaardePerEenheid.Enabled = false;
            this.txtbxWaardePerEenheid.Location = new System.Drawing.Point(972, 437);
            this.txtbxWaardePerEenheid.Name = "txtbxWaardePerEenheid";
            this.txtbxWaardePerEenheid.Size = new System.Drawing.Size(53, 22);
            this.txtbxWaardePerEenheid.TabIndex = 18;
            this.txtbxWaardePerEenheid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblEenhedenPerProduct
            // 
            this.lblEenhedenPerProduct.AutoSize = true;
            this.lblEenhedenPerProduct.Location = new System.Drawing.Point(817, 410);
            this.lblEenhedenPerProduct.Name = "lblEenhedenPerProduct";
            this.lblEenhedenPerProduct.Size = new System.Drawing.Size(129, 17);
            this.lblEenhedenPerProduct.TabIndex = 24;
            this.lblEenhedenPerProduct.Text = "Eenheden/product:";
            // 
            // lblWaarde
            // 
            this.lblWaarde.AutoSize = true;
            this.lblWaarde.Location = new System.Drawing.Point(817, 380);
            this.lblWaarde.Name = "lblWaarde";
            this.lblWaarde.Size = new System.Drawing.Size(62, 17);
            this.lblWaarde.TabIndex = 26;
            this.lblWaarde.Text = "Waarde:";
            // 
            // lblActief
            // 
            this.lblActief.AccessibleDescription = "";
            this.lblActief.AutoSize = true;
            this.lblActief.Location = new System.Drawing.Point(153, 377);
            this.lblActief.Name = "lblActief";
            this.lblActief.Size = new System.Drawing.Size(82, 17);
            this.lblActief.TabIndex = 28;
            this.lblActief.Text = "Actief (J/N):";
            // 
            // lblSoort
            // 
            this.lblSoort.AutoSize = true;
            this.lblSoort.Location = new System.Drawing.Point(552, 412);
            this.lblSoort.Name = "lblSoort";
            this.lblSoort.Size = new System.Drawing.Size(46, 17);
            this.lblSoort.TabIndex = 30;
            this.lblSoort.Text = "Soort:";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(552, 382);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(45, 17);
            this.lblCode.TabIndex = 32;
            this.lblCode.Text = "Code:";
            // 
            // lblKleur
            // 
            this.lblKleur.AutoSize = true;
            this.lblKleur.Location = new System.Drawing.Point(153, 467);
            this.lblKleur.Name = "lblKleur";
            this.lblKleur.Size = new System.Drawing.Size(45, 17);
            this.lblKleur.TabIndex = 34;
            this.lblKleur.Text = "Kleur:";
            // 
            // lblLangeNaam
            // 
            this.lblLangeNaam.AutoSize = true;
            this.lblLangeNaam.Location = new System.Drawing.Point(153, 437);
            this.lblLangeNaam.Name = "lblLangeNaam";
            this.lblLangeNaam.Size = new System.Drawing.Size(91, 17);
            this.lblLangeNaam.TabIndex = 36;
            this.lblLangeNaam.Text = "Lange naam:";
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
            this.grpbxCtrls.Location = new System.Drawing.Point(216, 286);
            this.grpbxCtrls.Name = "grpbxCtrls";
            this.grpbxCtrls.Size = new System.Drawing.Size(711, 71);
            this.grpbxCtrls.TabIndex = 38;
            this.grpbxCtrls.TabStop = false;
            // 
            // btnEersteRecord
            // 
            this.btnEersteRecord.BackgroundImage = global::Cmbap.Properties.Resources.begin;
            this.btnEersteRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEersteRecord.Location = new System.Drawing.Point(281, 24);
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
            this.btnLaatsteRecord.Location = new System.Drawing.Point(416, 24);
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
            this.btnVorigRecord.Location = new System.Drawing.Point(323, 24);
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
            this.btnVolgendRecord.Location = new System.Drawing.Point(365, 24);
            this.btnVolgendRecord.Name = "btnVolgendRecord";
            this.btnVolgendRecord.Size = new System.Drawing.Size(26, 26);
            this.btnVolgendRecord.TabIndex = 5;
            this.btnVolgendRecord.UseVisualStyleBackColor = true;
            this.btnVolgendRecord.Click += new System.EventHandler(this.btnVolgendRecord_Click);
            // 
            // btnOpslaan
            // 
            this.btnOpslaan.Enabled = false;
            this.btnOpslaan.Location = new System.Drawing.Point(169, 21);
            this.btnOpslaan.Name = "btnOpslaan";
            this.btnOpslaan.Size = new System.Drawing.Size(90, 33);
            this.btnOpslaan.TabIndex = 2;
            this.btnOpslaan.Text = "Opslaan";
            this.btnOpslaan.UseVisualStyleBackColor = true;
            this.btnOpslaan.Click += new System.EventHandler(this.btnOpslaan_Click);
            // 
            // btnToevoegen
            // 
            this.btnToevoegen.Location = new System.Drawing.Point(21, 21);
            this.btnToevoegen.Name = "btnToevoegen";
            this.btnToevoegen.Size = new System.Drawing.Size(126, 33);
            this.btnToevoegen.TabIndex = 1;
            this.btnToevoegen.Text = "Nieuw product";
            this.btnToevoegen.UseVisualStyleBackColor = true;
            this.btnToevoegen.Click += new System.EventHandler(this.btnToevoegen_Click);
            // 
            // btnVerwijderen
            // 
            this.btnVerwijderen.Location = new System.Drawing.Point(586, 21);
            this.btnVerwijderen.Name = "btnVerwijderen";
            this.btnVerwijderen.Size = new System.Drawing.Size(102, 33);
            this.btnVerwijderen.TabIndex = 8;
            this.btnVerwijderen.Text = "Verwijderen";
            this.btnVerwijderen.UseVisualStyleBackColor = true;
            this.btnVerwijderen.Click += new System.EventHandler(this.btnVerwijderen_Click);
            // 
            // btnAnnuleren
            // 
            this.btnAnnuleren.Enabled = false;
            this.btnAnnuleren.Location = new System.Drawing.Point(468, 21);
            this.btnAnnuleren.Name = "btnAnnuleren";
            this.btnAnnuleren.Size = new System.Drawing.Size(90, 33);
            this.btnAnnuleren.TabIndex = 7;
            this.btnAnnuleren.Text = "Annuleren";
            this.btnAnnuleren.UseVisualStyleBackColor = true;
            this.btnAnnuleren.Click += new System.EventHandler(this.btnAnnuleren_Click);
            // 
            // cmbbxActief
            // 
            this.cmbbxActief.FormattingEnabled = true;
            this.cmbbxActief.Items.AddRange(new object[] {
            "Ja",
            "Nee"});
            this.cmbbxActief.Location = new System.Drawing.Point(263, 374);
            this.cmbbxActief.Name = "cmbbxActief";
            this.cmbbxActief.Size = new System.Drawing.Size(54, 24);
            this.cmbbxActief.TabIndex = 9;
            this.cmbbxActief.TextChanged += new System.EventHandler(this.cmbbxActief_TextChanged);
            // 
            // cmbbxSoort
            // 
            this.cmbbxSoort.FormattingEnabled = true;
            this.cmbbxSoort.Items.AddRange(new object[] {
            "B(onnen)",
            "M(unten)"});
            this.cmbbxSoort.Location = new System.Drawing.Point(669, 407);
            this.cmbbxSoort.Name = "cmbbxSoort";
            this.cmbbxSoort.Size = new System.Drawing.Size(91, 24);
            this.cmbbxSoort.TabIndex = 14;
            this.cmbbxSoort.TextChanged += new System.EventHandler(this.cmbbxSoort_TextChanged);
            // 
            // btnOpmerking
            // 
            this.btnOpmerking.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnOpmerking.Location = new System.Drawing.Point(555, 465);
            this.btnOpmerking.Name = "btnOpmerking";
            this.btnOpmerking.Size = new System.Drawing.Size(88, 27);
            this.btnOpmerking.TabIndex = 18;
            this.btnOpmerking.Text = "Opmerking:";
            this.btnOpmerking.UseVisualStyleBackColor = true;
            this.btnOpmerking.Click += new System.EventHandler(this.btnOpmerking_Click);
            // 
            // txtbxOpmerking
            // 
            this.txtbxOpmerking.Location = new System.Drawing.Point(669, 468);
            this.txtbxOpmerking.Name = "txtbxOpmerking";
            this.txtbxOpmerking.Size = new System.Drawing.Size(357, 22);
            this.txtbxOpmerking.TabIndex = 19;
            this.txtbxOpmerking.TextChanged += new System.EventHandler(this.txtbxOpmerking_TextChanged);
            // 
            // lblVerzamelnaam
            // 
            this.lblVerzamelnaam.AutoSize = true;
            this.lblVerzamelnaam.Location = new System.Drawing.Point(552, 440);
            this.lblVerzamelnaam.Name = "lblVerzamelnaam";
            this.lblVerzamelnaam.Size = new System.Drawing.Size(106, 17);
            this.lblVerzamelnaam.TabIndex = 42;
            this.lblVerzamelnaam.Text = "Verzamelnaam:";
            // 
            // txtbxWaarde
            // 
            this.txtbxWaarde.Location = new System.Drawing.Point(986, 374);
            this.txtbxWaarde.Mask = "###";
            this.txtbxWaarde.Name = "txtbxWaarde";
            this.txtbxWaarde.PromptChar = ' ';
            this.txtbxWaarde.Size = new System.Drawing.Size(39, 22);
            this.txtbxWaarde.TabIndex = 16;
            this.txtbxWaarde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtbxWaarde.TextChanged += new System.EventHandler(this.txtbxWaarde_TextChanged);
            // 
            // txtbxEenhedenPerProduct
            // 
            this.txtbxEenhedenPerProduct.Location = new System.Drawing.Point(1004, 407);
            this.txtbxEenhedenPerProduct.Mask = "##";
            this.txtbxEenhedenPerProduct.Name = "txtbxEenhedenPerProduct";
            this.txtbxEenhedenPerProduct.PromptChar = ' ';
            this.txtbxEenhedenPerProduct.Size = new System.Drawing.Size(21, 22);
            this.txtbxEenhedenPerProduct.TabIndex = 17;
            this.txtbxEenhedenPerProduct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtbxEenhedenPerProduct.TextChanged += new System.EventHandler(this.txtbxEenhedenPerProduct_TextChanged);
            // 
            // txtbxKleur
            // 
            this.txtbxKleur.Location = new System.Drawing.Point(262, 464);
            this.txtbxKleur.Mask = "&&&&&&&&&&";
            this.txtbxKleur.Name = "txtbxKleur";
            this.txtbxKleur.Size = new System.Drawing.Size(72, 22);
            this.txtbxKleur.TabIndex = 12;
            this.txtbxKleur.TextChanged += new System.EventHandler(this.txtbxKleur_TextChanged);
            // 
            // txtbxKorteNaam
            // 
            this.txtbxKorteNaam.Location = new System.Drawing.Point(262, 404);
            this.txtbxKorteNaam.Mask = "&&&&&&&&&&";
            this.txtbxKorteNaam.Name = "txtbxKorteNaam";
            this.txtbxKorteNaam.Size = new System.Drawing.Size(72, 22);
            this.txtbxKorteNaam.TabIndex = 10;
            this.txtbxKorteNaam.TextChanged += new System.EventHandler(this.txtbxKorteNaam_TextChanged);
            // 
            // txtbxCode
            // 
            this.txtbxCode.Location = new System.Drawing.Point(669, 376);
            this.txtbxCode.Mask = "&&&&&&&&&&";
            this.txtbxCode.Name = "txtbxCode";
            this.txtbxCode.Size = new System.Drawing.Size(72, 22);
            this.txtbxCode.TabIndex = 13;
            this.txtbxCode.TextChanged += new System.EventHandler(this.txtbxCode_TextChanged);
            // 
            // txtbxVerzamelnaam
            // 
            this.txtbxVerzamelnaam.Location = new System.Drawing.Point(669, 437);
            this.txtbxVerzamelnaam.Mask = "&&&&&&&&&&";
            this.txtbxVerzamelnaam.Name = "txtbxVerzamelnaam";
            this.txtbxVerzamelnaam.Size = new System.Drawing.Size(72, 22);
            this.txtbxVerzamelnaam.TabIndex = 15;
            this.txtbxVerzamelnaam.Text = "vel";
            this.txtbxVerzamelnaam.TextChanged += new System.EventHandler(this.txtbxVerzamelnaam_TextChanged);
            // 
            // txtbxLangeNaam
            // 
            this.txtbxLangeNaam.Location = new System.Drawing.Point(262, 434);
            this.txtbxLangeNaam.Mask = "&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&";
            this.txtbxLangeNaam.Name = "txtbxLangeNaam";
            this.txtbxLangeNaam.Size = new System.Drawing.Size(252, 22);
            this.txtbxLangeNaam.TabIndex = 11;
            this.txtbxLangeNaam.TextChanged += new System.EventHandler(this.txtbxLangeNaam_TextChanged);
            // 
            // frmInvoerProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1175, 549);
            this.Controls.Add(this.txtbxLangeNaam);
            this.Controls.Add(this.txtbxVerzamelnaam);
            this.Controls.Add(this.txtbxCode);
            this.Controls.Add(this.txtbxKorteNaam);
            this.Controls.Add(this.txtbxKleur);
            this.Controls.Add(this.txtbxEenhedenPerProduct);
            this.Controls.Add(this.txtbxWaarde);
            this.Controls.Add(this.lblVerzamelnaam);
            this.Controls.Add(this.txtbxOpmerking);
            this.Controls.Add(this.btnOpmerking);
            this.Controls.Add(this.cmbbxSoort);
            this.Controls.Add(this.cmbbxActief);
            this.Controls.Add(this.grpbxCtrls);
            this.Controls.Add(this.lblLangeNaam);
            this.Controls.Add(this.lblKleur);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.lblSoort);
            this.Controls.Add(this.lblActief);
            this.Controls.Add(this.lblWaarde);
            this.Controls.Add(this.lblEenhedenPerProduct);
            this.Controls.Add(this.lblWaardePerEeenheid);
            this.Controls.Add(this.txtbxWaardePerEenheid);
            this.Controls.Add(this.lblProducten);
            this.Controls.Add(this.lblKorteNaam);
            this.Controls.Add(this.fillBy1ToolStrip);
            this.Controls.Add(this.dtgrdvwProducten);
            this.Controls.Add(this.btnSluitn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInvoerProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoer/wijzigen producten";
            this.Activated += new System.EventHandler(this.frmInvoerProduct_Activated);
            this.Load += new System.EventHandler(this.frmInvoerProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdvwProducten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._Cmbap_dataDataSet)).EndInit();
            this.grpbxCtrls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSluitn;
        private System.Windows.Forms.DataGridView dtgrdvwProducten;
        private Cmbap._Cmbap_dataDataSet _Cmbap_dataDataSet;
        private System.Windows.Forms.BindingSource productBindingSource;
        private Cmbap._Cmbap_dataDataSetTableAdapters.ProductTableAdapter productTableAdapter;
        private System.Windows.Forms.ToolStrip fillBy1ToolStrip;
        private System.Windows.Forms.Label lblKorteNaam;
        private System.Windows.Forms.Label lblProducten;
        private System.Windows.Forms.Label lblWaardePerEeenheid;
        private System.Windows.Forms.TextBox txtbxWaardePerEenheid;
        private System.Windows.Forms.Label lblEenhedenPerProduct;
        private System.Windows.Forms.Label lblWaarde;
        private System.Windows.Forms.Label lblActief;
        private System.Windows.Forms.Label lblSoort;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblKleur;
        private System.Windows.Forms.Label lblLangeNaam;
        private System.Windows.Forms.GroupBox grpbxCtrls;
        private System.Windows.Forms.Button btnToevoegen;
        private System.Windows.Forms.Button btnVolgendRecord;
        private System.Windows.Forms.Button btnLaatsteRecord;
        private System.Windows.Forms.Button btnEersteRecord;
        private System.Windows.Forms.Button btnVorigRecord;
        private System.Windows.Forms.Button btnVerwijderen;
        private System.Windows.Forms.Button btnAnnuleren;
        private System.Windows.Forms.Button btnOpslaan;
        private System.Windows.Forms.ComboBox cmbbxActief;
        private System.Windows.Forms.ComboBox cmbbxSoort;
        private System.Windows.Forms.Button btnOpmerking;
        private System.Windows.Forms.TextBox txtbxOpmerking;
        private System.Windows.Forms.Label lblVerzamelnaam;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prod_DispActief;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodStatusIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodDispStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodNaamkortDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodNaamlangDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodKleurDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodSoortDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodVerzamelnaamDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodWaardeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodAantaleenhedenperproductDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodWaardePerEenheidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodMutatiedatumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodOpmerkingDataGridViewTextBoxColumn;
        private System.Windows.Forms.MaskedTextBox txtbxWaarde;
        private System.Windows.Forms.MaskedTextBox txtbxEenhedenPerProduct;
        private System.Windows.Forms.MaskedTextBox txtbxKleur;
        private System.Windows.Forms.MaskedTextBox txtbxKorteNaam;
        private System.Windows.Forms.MaskedTextBox txtbxCode;
        private System.Windows.Forms.MaskedTextBox txtbxVerzamelnaam;
        private System.Windows.Forms.MaskedTextBox txtbxLangeNaam;
    }
}