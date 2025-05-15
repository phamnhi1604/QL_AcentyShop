using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcentyShop_Winform.DAL;

namespace AcentyShop_Winform.GUI
{
    public partial class frmKhachHang : Form
    {
        DAL.DBAcentyShopDataContext db = new DBAcentyShopDataContext();
        public frmKhachHang()
        {
            InitializeComponent();
        }


        private void LoadKhachHang()
        {
            var dsKhachHang = db.KhachHangs.Select(kh => new
            {
                kh.IdKhachHang,
                kh.TenKhachHang,
                kh.NgaySinh,
                kh.GioiTinh,
                kh.DiaChi,
                kh.SoDienThoai,
                kh.Email
            }).ToList();

            dataGridView1.DataSource = dsKhachHang;
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
        }
    }
}
