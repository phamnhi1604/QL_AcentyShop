using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcentyShop_Applicate.GUI.Feature
{
    public partial class frmThemSP : Form
    {
        public frmThemSP()
        {
            InitializeComponent();
        }

        private void btnBarCode_Click(object sender, EventArgs e)
        {
            frmBarCode frmBarCode = new frmBarCode();
            frmBarCode.ShowDialog();

            if (!string.IsNullOrEmpty(frmBarCode.textcode))
            {
                txtBarCode.Text = frmBarCode.textcode; // txtBarCode ở frmThemSP
            }
        }
    }
}
