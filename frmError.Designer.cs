namespace Error
{
    partial class frmError
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
            this.grpbxMelding = new System.Windows.Forms.GroupBox();
            this.lblErrorHead = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.btnSluiten = new System.Windows.Forms.Button();
            this.btnDoorgaan = new System.Windows.Forms.Button();
            this.btnAnnuleren = new System.Windows.Forms.Button();
            this.grpbxMelding.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbxMelding
            // 
            this.grpbxMelding.Controls.Add(this.btnAnnuleren);
            this.grpbxMelding.Controls.Add(this.btnDoorgaan);
            this.grpbxMelding.Controls.Add(this.lblErrorHead);
            this.grpbxMelding.Controls.Add(this.lblError);
            this.grpbxMelding.Controls.Add(this.btnSluiten);
            this.grpbxMelding.Location = new System.Drawing.Point(12, 2);
            this.grpbxMelding.Name = "grpbxMelding";
            this.grpbxMelding.Size = new System.Drawing.Size(287, 254);
            this.grpbxMelding.TabIndex = 2;
            this.grpbxMelding.TabStop = false;
            // 
            // lblErrorHead
            // 
            this.lblErrorHead.ForeColor = System.Drawing.Color.Black;
            this.lblErrorHead.Location = new System.Drawing.Point(15, 18);
            this.lblErrorHead.Name = "lblErrorHead";
            this.lblErrorHead.Size = new System.Drawing.Size(257, 25);
            this.lblErrorHead.TabIndex = 3;
            this.lblErrorHead.Text = "label1";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Black;
            this.lblError.Location = new System.Drawing.Point(15, 53);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(46, 18);
            this.lblError.TabIndex = 2;
            this.lblError.Text = "label1";
            // 
            // btnSluiten
            // 
            this.btnSluiten.ForeColor = System.Drawing.Color.Black;
            this.btnSluiten.Location = new System.Drawing.Point(197, 220);
            this.btnSluiten.Name = "btnSluiten";
            this.btnSluiten.Size = new System.Drawing.Size(75, 23);
            this.btnSluiten.TabIndex = 1;
            this.btnSluiten.Text = "Ok";
            this.btnSluiten.UseVisualStyleBackColor = true;
            this.btnSluiten.Click += new System.EventHandler(this.btnSluiten_Click);
            // 
            // btnDoorgaan
            // 
            this.btnDoorgaan.ForeColor = System.Drawing.Color.Black;
            this.btnDoorgaan.Location = new System.Drawing.Point(103, 220);
            this.btnDoorgaan.Name = "btnDoorgaan";
            this.btnDoorgaan.Size = new System.Drawing.Size(75, 23);
            this.btnDoorgaan.TabIndex = 4;
            this.btnDoorgaan.Text = "Ok";
            this.btnDoorgaan.UseVisualStyleBackColor = true;
            this.btnDoorgaan.Visible = false;
            this.btnDoorgaan.Click += new System.EventHandler(this.btnDoorgaan_Click);
            // 
            // btnAnnuleren
            // 
            this.btnAnnuleren.ForeColor = System.Drawing.Color.Black;
            this.btnAnnuleren.Location = new System.Drawing.Point(6, 220);
            this.btnAnnuleren.Name = "btnAnnuleren";
            this.btnAnnuleren.Size = new System.Drawing.Size(75, 23);
            this.btnAnnuleren.TabIndex = 5;
            this.btnAnnuleren.Text = "Ok";
            this.btnAnnuleren.UseVisualStyleBackColor = true;
            this.btnAnnuleren.Visible = false;
            this.btnAnnuleren.Click += new System.EventHandler(this.btnAnnuleren_Click);
            // 
            // frmError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 263);
            this.Controls.Add(this.grpbxMelding);
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmError";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Programma-fout";
            this.grpbxMelding.ResumeLayout(false);
            this.grpbxMelding.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbxMelding;
        private System.Windows.Forms.Label lblErrorHead;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnSluiten;
        private System.Windows.Forms.Button btnAnnuleren;
        private System.Windows.Forms.Button btnDoorgaan;
    }
}