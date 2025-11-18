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
    }
}
