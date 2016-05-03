namespace Cmbap
{
    partial class productSelectie
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
            this.btnProductSelectie = new System.Windows.Forms.Button();
            this.lstbxProduct = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnProductSelectie
            // 
            this.btnProductSelectie.Enabled = false;
            this.btnProductSelectie.Location = new System.Drawing.Point(19, 251);
            this.btnProductSelectie.Name = "btnProductSelectie";
            this.btnProductSelectie.Size = new System.Drawing.Size(274, 31);
            this.btnProductSelectie.TabIndex = 0;
            this.btnProductSelectie.Text = "Selecteer product en sluit venster";
            this.btnProductSelectie.UseVisualStyleBackColor = true;
            this.btnProductSelectie.Click += new System.EventHandler(this.btnProductSelectie_Click);
            // 
            // lstbxProduct
            // 
            this.lstbxProduct.FormattingEnabled = true;
            this.lstbxProduct.ItemHeight = 16;
            this.lstbxProduct.Location = new System.Drawing.Point(19, 12);
            this.lstbxProduct.Name = "lstbxProduct";
            this.lstbxProduct.Size = new System.Drawing.Size(274, 228);
            this.lstbxProduct.TabIndex = 1;
            this.lstbxProduct.SelectedIndexChanged += new System.EventHandler(this.lstbxProduct_SelectedIndexChanged);
            // 
            // productSelectie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 294);
            this.Controls.Add(this.lstbxProduct);
            this.Controls.Add(this.btnProductSelectie);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "productSelectie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Productselectie";
            this.Activated += new System.EventHandler(this.productSelectie_Activated);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProductSelectie;
        private System.Windows.Forms.ListBox lstbxProduct;
    }
}