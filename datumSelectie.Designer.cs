namespace Cmbap
{
    partial class datumSelectie
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
            this._Cmbap_dataDataSet = new Cmbap._Cmbap_dataDataSet();
            this.jaargegevensBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.jaargegevensTableAdapter = new Cmbap._Cmbap_dataDataSetTableAdapters.JaargegevensTableAdapter();
            this.jaargegevensBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.lstbxJaargegevens = new System.Windows.Forms.ListBox();
            this.LblBegindatum = new System.Windows.Forms.Label();
            this.lblEinddatum = new System.Windows.Forms.Label();
            this.lblIngevoerdeJarenPeriodes = new System.Windows.Forms.Label();
            this.lblPeriode = new System.Windows.Forms.Label();
            this.btnSelecteerPeriode = new System.Windows.Forms.Button();
            this.dttmpckrBegindatum = new System.Windows.Forms.DateTimePicker();
            this.dttmpckrEinddatum = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this._Cmbap_dataDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jaargegevensBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jaargegevensBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // _Cmbap_dataDataSet
            // 
            this._Cmbap_dataDataSet.DataSetName = "_Cmbap_dataDataSet";
            this._Cmbap_dataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // jaargegevensBindingSource
            // 
            this.jaargegevensBindingSource.DataMember = "Jaargegevens";
            this.jaargegevensBindingSource.DataSource = this._Cmbap_dataDataSet;
            // 
            // jaargegevensTableAdapter
            // 
            this.jaargegevensTableAdapter.ClearBeforeFill = true;
            // 
            // jaargegevensBindingSource1
            // 
            this.jaargegevensBindingSource1.DataMember = "Jaargegevens";
            this.jaargegevensBindingSource1.DataSource = this._Cmbap_dataDataSet;
            // 
            // lstbxJaargegevens
            // 
            this.lstbxJaargegevens.FormattingEnabled = true;
            this.lstbxJaargegevens.ItemHeight = 16;
            this.lstbxJaargegevens.Location = new System.Drawing.Point(262, 44);
            this.lstbxJaargegevens.Name = "lstbxJaargegevens";
            this.lstbxJaargegevens.Size = new System.Drawing.Size(183, 180);
            this.lstbxJaargegevens.TabIndex = 0;
            this.lstbxJaargegevens.Click += new System.EventHandler(this.lstbxJaargegevens_Click);
            // 
            // LblBegindatum
            // 
            this.LblBegindatum.AutoSize = true;
            this.LblBegindatum.Location = new System.Drawing.Point(13, 93);
            this.LblBegindatum.Name = "LblBegindatum";
            this.LblBegindatum.Size = new System.Drawing.Size(87, 17);
            this.LblBegindatum.TabIndex = 1;
            this.LblBegindatum.Text = "Begindatum:";
            // 
            // lblEinddatum
            // 
            this.lblEinddatum.AutoSize = true;
            this.lblEinddatum.Location = new System.Drawing.Point(13, 137);
            this.lblEinddatum.Name = "lblEinddatum";
            this.lblEinddatum.Size = new System.Drawing.Size(79, 17);
            this.lblEinddatum.TabIndex = 2;
            this.lblEinddatum.Text = "Einddatum:";
            // 
            // lblIngevoerdeJarenPeriodes
            // 
            this.lblIngevoerdeJarenPeriodes.AutoSize = true;
            this.lblIngevoerdeJarenPeriodes.Location = new System.Drawing.Point(259, 24);
            this.lblIngevoerdeJarenPeriodes.Name = "lblIngevoerdeJarenPeriodes";
            this.lblIngevoerdeJarenPeriodes.Size = new System.Drawing.Size(178, 17);
            this.lblIngevoerdeJarenPeriodes.TabIndex = 5;
            this.lblIngevoerdeJarenPeriodes.Text = "Ingevoerde jaren/periodes:";
            // 
            // lblPeriode
            // 
            this.lblPeriode.AutoSize = true;
            this.lblPeriode.Location = new System.Drawing.Point(13, 56);
            this.lblPeriode.Name = "lblPeriode";
            this.lblPeriode.Size = new System.Drawing.Size(61, 17);
            this.lblPeriode.TabIndex = 6;
            this.lblPeriode.Text = "Periode:";
            // 
            // btnSelecteerPeriode
            // 
            this.btnSelecteerPeriode.Location = new System.Drawing.Point(107, 192);
            this.btnSelecteerPeriode.Name = "btnSelecteerPeriode";
            this.btnSelecteerPeriode.Size = new System.Drawing.Size(84, 23);
            this.btnSelecteerPeriode.TabIndex = 3;
            this.btnSelecteerPeriode.Text = "Selecteer";
            this.btnSelecteerPeriode.UseVisualStyleBackColor = true;
            this.btnSelecteerPeriode.Click += new System.EventHandler(this.btnSelecteerPeriode_Click);
            // 
            // dttmpckrBegindatum
            // 
            this.dttmpckrBegindatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dttmpckrBegindatum.Location = new System.Drawing.Point(106, 88);
            this.dttmpckrBegindatum.Name = "dttmpckrBegindatum";
            this.dttmpckrBegindatum.Size = new System.Drawing.Size(106, 22);
            this.dttmpckrBegindatum.TabIndex = 1;
            this.dttmpckrBegindatum.ValueChanged += new System.EventHandler(this.dttmpckrBegindatum_ValueChanged);
            // 
            // dttmpckrEinddatum
            // 
            this.dttmpckrEinddatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dttmpckrEinddatum.Location = new System.Drawing.Point(107, 132);
            this.dttmpckrEinddatum.Name = "dttmpckrEinddatum";
            this.dttmpckrEinddatum.Size = new System.Drawing.Size(105, 22);
            this.dttmpckrEinddatum.TabIndex = 2;
            this.dttmpckrEinddatum.ValueChanged += new System.EventHandler(this.dttmpckrEinddatum_ValueChanged);
            // 
            // datumSelectie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 235);
            this.Controls.Add(this.dttmpckrEinddatum);
            this.Controls.Add(this.dttmpckrBegindatum);
            this.Controls.Add(this.btnSelecteerPeriode);
            this.Controls.Add(this.lblPeriode);
            this.Controls.Add(this.lblIngevoerdeJarenPeriodes);
            this.Controls.Add(this.lblEinddatum);
            this.Controls.Add(this.LblBegindatum);
            this.Controls.Add(this.lstbxJaargegevens);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "datumSelectie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Periodeselectie";
            this.Activated += new System.EventHandler(this.datumSelectie_Activated);
            this.Load += new System.EventHandler(this.datumSelectie_Load);
            ((System.ComponentModel.ISupportInitialize)(this._Cmbap_dataDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jaargegevensBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jaargegevensBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private _Cmbap_dataDataSet _Cmbap_dataDataSet;
        private System.Windows.Forms.BindingSource jaargegevensBindingSource;
        private _Cmbap_dataDataSetTableAdapters.JaargegevensTableAdapter jaargegevensTableAdapter;
        private System.Windows.Forms.BindingSource jaargegevensBindingSource1;
        private System.Windows.Forms.ListBox lstbxJaargegevens;
        private System.Windows.Forms.Label LblBegindatum;
        private System.Windows.Forms.Label lblEinddatum;
        private System.Windows.Forms.Label lblIngevoerdeJarenPeriodes;
        private System.Windows.Forms.Label lblPeriode;
        private System.Windows.Forms.Button btnSelecteerPeriode;
        private System.Windows.Forms.DateTimePicker dttmpckrBegindatum;
        private System.Windows.Forms.DateTimePicker dttmpckrEinddatum;
    }
}