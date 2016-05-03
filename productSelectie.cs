using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using nsTblPd;
using globalVars;

namespace Cmbap
{
    public partial class productSelectie : Form
    {
        public productSelectie()
        {
            InitializeComponent();
        }

        private void productSelectie_Activated(object sender, EventArgs e)
        {
            lstbxProduct.Items.Clear();
            tblPd pd = new tblPd();
            pd.zoekProductRecord("Prod_StatusId <> 170009");
            if (pd.pdListCount != 0)
            {
                for (int i = 0; i < pd.pdListCount-1; i++)
                {
                    lstbxProduct.Items.Add(pd.lstProductRecord[i].Prod_Code);
                }
            }
            else
            {
                lstbxProduct.Items.Add("Geen producten gevonden!");
            }
        }

        private void lstbxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnProductSelectie.Enabled = true;
        }

        private void btnProductSelectie_Click(object sender, EventArgs e)
        {
            tblPd pd = new tblPd();
            int rij = lstbxProduct.SelectedIndex;
            string pdo = lstbxProduct.Items[rij].ToString();
            pd.zoekProductRecord("Prod_Code = " + "\"" + pdo + "\";");
            if (pd.pdListCount == 1)
            {
                gv.selectedProduct= pd.lstProductRecord[0].Prod_Id;
                Close();
            }
        }
    }
}
