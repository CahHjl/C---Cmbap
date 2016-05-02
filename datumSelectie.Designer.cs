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
            this.msktxtbxBegindatum = new System.Windows.Forms.MaskedTextBox();
            this.msktxtbxEinddatum = new System.Windows.Forms.MaskedTextBox();
            this.lblIngevoerdeJarenPeriodes = new System.Windows.Forms.Label();
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
            this.lstbxJaargegevens.Location = new System.Drawing.Point(217, 44);
            this.lstbxJaargegevens.Name = "lstbxJaargegevens";
            this.lstbxJaargegevens.Size = new System.Drawing.Size(183, 180);
            this.lstbxJaargegevens.TabIndex = 0;
            this.lstbxJaargegevens.Click += new System.EventHandler(this.lstbxJaargegevens_Click);
            // 
            // LblBegindatum
            // 
            this.LblBegindatum.AutoSize = true;
            this.LblBegindatum.Location = new System.Drawing.Point(13, 53);
            this.LblBegindatum.Name = "LblBegindatum";
            this.LblBegindatum.Size = new System.Drawing.Size(87, 17);
            this.LblBegindatum.TabIndex = 1;
            this.LblBegindatum.Text = "Begindatum:";
            // 
            // lblEinddatum
            // 
            this.lblEinddatum.AutoSize = true;
            this.lblEinddatum.Location = new System.Drawing.Point(13, 97);
            this.lblEinddatum.Name = "lblEinddatum";
            this.lblEinddatum.Size = new System.Drawing.Size(79, 17);
            this.lblEinddatum.TabIndex = 2;
            this.lblEinddatum.Text = "Einddatum:";
            // 
            // msktxtbxBegindatum
            // 
            this.msktxtbxBegindatum.Location = new System.Drawing.Point(107, 47);
            this.msktxtbxBegindatum.Mask = "00/00/0000";
            this.msktxtbxBegindatum.Name = "msktxtbxBegindatum";
            this.msktxtbxBegindatum.Size = new System.Drawing.Size(91, 22);
            this.msktxtbxBegindatum.TabIndex = 3;
            this.msktxtbxBegindatum.ValidatingType = typeof(System.DateTime);
            // 
            // msktxtbxEinddatum
            // 
            this.msktxtbxEinddatum.Location = new System.Drawing.Point(107, 94);
            this.msktxtbxEinddatum.Mask = "00/00/0000";
            this.msktxtbxEinddatum.Name = "msktxtbxEinddatum";
            this.msktxtbxEinddatum.Size = new System.Drawing.Size(91, 22);
            this.msktxtbxEinddatum.TabIndex = 4;
            this.msktxtbxEinddatum.ValidatingType = typeof(System.DateTime);
            // 
            // lblIngevoerdeJarenPeriodes
            // 
            this.lblIngevoerdeJarenPeriodes.AutoSize = true;
            this.lblIngevoerdeJarenPeriodes.Location = new System.Drawing.Point(219, 24);
            this.lblIngevoerdeJarenPeriodes.Name = "lblIngevoerdeJarenPeriodes";
            this.lblIngevoerdeJarenPeriodes.Size = new System.Drawing.Size(178, 17);
            this.lblIngevoerdeJarenPeriodes.TabIndex = 5;
            this.lblIngevoerdeJarenPeriodes.Text = "Ingevoerde jaren/periodes:";
            // 
            // datumSelectie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 235);
            this.Controls.Add(this.lblIngevoerdeJarenPeriodes);
            this.Controls.Add(this.msktxtbxEinddatum);
            this.Controls.Add(this.msktxtbxBegindatum);
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
        private System.Windows.Forms.MaskedTextBox msktxtbxBegindatum;
        private System.Windows.Forms.MaskedTextBox msktxtbxEinddatum;
        private System.Windows.Forms.Label lblIngevoerdeJarenPeriodes;
    }
}