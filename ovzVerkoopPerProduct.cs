using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cmbap
{
    public partial class ovzVerkoopPerProduct : Form
    {
        public ovzVerkoopPerProduct()
        {
            InitializeComponent();
        }

        private void ovzVerkoopPerProduct_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
