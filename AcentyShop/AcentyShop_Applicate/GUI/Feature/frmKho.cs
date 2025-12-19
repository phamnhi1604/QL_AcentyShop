using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcentyShop_Applicate.DAL;

namespace AcentyShop_Applicate.GUI.Feature
{
    public partial class frmKho : Form
    {
        BDAcentyShopDataContext db = new BDAcentyShopDataContext();
        public frmKho()
        {
            InitializeComponent();
            LoadListKho();
            loadlistSP();
        }
        private void LoadListKho()
        {
            var lstKho = from i in db.HoaDonNhapKhos
                         select new
                         {
                             i.IdHoaDonNhapKho,
                             i.NgayNhap,
                             i.IdNhanVien,
                             i.IdChiNhanh
                         };
            gdvHDKho.DataSource = lstKho.ToList();
        }

        private void loadlistSP()
        {
            var lstSP = from i in db.Khos
                        join sp in db.SanPhams on i.IdSanPham equals sp.IdSanPham
                        join cn in db.ChiNhanhs on i.IdChiNhanh equals cn.IdChiNhanh
                        select new
                        {
                            TenChiNhanh=  cn.IdChiNhanh,
                            i.IdSanPham,
                            TenSp = sp.TenSanPham,
                            i.SoLuongTonKho

                        };
            dgvSP.DataSource = lstSP.ToList();
        }

        private void loadLstHDNK()
        {
            var lsHDNK = from hd in db.HoaDonNhapKhos
                         select new
                         {
                             hd.IdHoaDonNhapKho,
                             hd.NgayNhap
                         };
            dgvHDNK.DataSource = lsHDNK.ToList();
        }
        private void loadCTLstHDNK(int idHD)
        {
            var lsCTHDNK = from cthd in db.ChiTietHoaDonNhapKhos
                           where cthd.IdHoaDonNhapKho == idHD
                           select new
                         {
                             cthd.IdHoaDonNhapKho,
                             cthd.IdSanPham,
                             cthd.SoLuong
                           };
            dgvChiTietHDKho.DataSource = lsCTHDNK.ToList();
        }
        
        private void dgvSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmKho_Load(object sender, EventArgs e)
        {

            LoadListKho();
            loadlistSP();
            loadLstHDNK();
        }

        private void dgvHDNK_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvHDNK.CurrentRow != null)
            {
                int idHD = Convert.ToInt32(dgvHDNK.CurrentRow.Cells["IdHoaDonNhapKho"].Value);
                loadCTLstHDNK(idHD);
            }
        }

        private void cboTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(cboTenSP.SelectedIndex != -1)
            //{
            //    txtIDSP.Text = cboTenSP.SelectedValue.ToString();
            //    //numericUpDown1.Value.ToString = cboTenSP.SelectedValue.ToString();
            //}
        }

        private void btnTaoPN_Click(object sender, EventArgs e)
        {
            //frmThemSP fadd = new frmThemSP();
            //fadd.ShowDialog();
            new CTHDNhapKho().Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddPN_Click(object sender, EventArgs e)
        {

            new CTHDNhapKho().Show();

        }
    }
}
