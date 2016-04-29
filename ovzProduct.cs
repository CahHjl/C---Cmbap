using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using globalVars;

namespace Cmbap
{
    public partial class ovzProduct : Form
    {
        public ovzProduct()
        {
            InitializeComponent();
        }

        private void ovzProduct_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_Cmbap_dataDataSet.Product' table. You can move, or remove it, as needed.
            this.ProductTableAdapter.Fill(this._Cmbap_dataDataSet.Product);

            string licNr = gv.actieveLicentie.Nr.ToString();
            string licDisplayNaam = gv.actieveLicentie.Displaynaamlh;

            List<ReportParameter> rp = new List<ReportParameter>();
            rp.Add(new ReportParameter ("lnr",licNr));
            rp.Add(new ReportParameter ("lnm",licDisplayNaam));

            this.reportViewer1.LocalReport.SetParameters( rp);
            this.reportViewer1.RefreshReport();
        }
    }
}
