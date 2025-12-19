using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcentyShop_Applicate.DAL;
using System.Windows.Forms;

namespace AcentyShop_Applicate.GUI.Feature
{
    public partial class CTHDNhapKho : Form
    {
        BDAcentyShopDataContext db = new BDAcentyShopDataContext();

        public CTHDNhapKho()
        {
            InitializeComponent();
            loadCboTenSP();

        }

        private void loadCboTenSP()
        {
            var lstSP = from sp in db.SanPhams
                        select new
                        {
                            sp.IdSanPham,
                            sp.TenSanPham
                        };
            cboTenSP.DisplayMember = "TenSanPham";       // Hiện tên
            cboTenSP.ValueMember = "IdSanPham";
            cboTenSP.DataSource = lstSP.ToList();// Lấy ID khi cần
            //cboTenSP.SelectedIndex = -1;            // Không chọn sẵn
        }

        private void cboTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTenSP.SelectedIndex != -1)
            {
                txtIDSP.Text = cboTenSP.SelectedValue.ToString();
                //numericUpDown1.Value.ToString = cboTenSP.SelectedValue.ToString();
            }
        }

    }
}
