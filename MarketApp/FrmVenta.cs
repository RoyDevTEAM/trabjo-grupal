using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketApp
{
    public partial class FrmVenta : Form
    {
        public FrmVenta()
        {
            InitializeComponent();
        }

        public static FrmVenta GetInstancia()
        {
            return new FrmVenta();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            cbDescuento.Enabled = Enabled;
        }

        private void rbEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            txtEfectivo.Enabled = Enabled;
        }
    }
}
