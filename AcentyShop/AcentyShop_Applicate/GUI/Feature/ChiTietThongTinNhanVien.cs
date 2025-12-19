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
using AcentyShop_Applicate.DTO;


namespace AcentyShop_Applicate.GUI.Feature
{
    public partial class ChiTietThongTinNhanVien : Form
    {
        BDAcentyShopDataContext db = new BDAcentyShopDataContext();
        public ChiTietThongTinNhanVien()
        {
            InitializeComponent();
        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }

        private void ChiTietThongTinNhanVien_Load(object sender, EventArgs e)
        {
            txtIDNV.Text = "Mã NV: " + Session.IdNhanVien.ToString();

            txtTenNV.Enabled = false;
            txtSDT.Enabled = false;
            txtNS.Enabled = false;
            txtEmail.Enabled = false;
            txtGT.Enabled = false;
            txtDC.Enabled = false;
            btnSave.Enabled = false;

            long idNV = Session.IdNhanVien;

            // Nếu không có nhân viên đăng nhập → mặc định = 1
            if (idNV == 0)
                idNV = 1;
            var nv = db.NhanViens.FirstOrDefault(n => n.IdNhanVien == idNV);
            if (nv != null)
            {
                txtTenNV.Text = nv.TenNhanVien;
                txtSDT.Text = nv.SoDienThoai;
                txtNS.Text = nv.NgaySinh.ToString();
                txtGT.Text = nv.GioiTinh;
                txtEmail.Text = nv.Email;
                txtDC.Text = nv.DiaChi;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            long idNV = Session.IdNhanVien;

            // Nếu chưa đăng nhập → mặc định id = 1
            if (idNV == 0)
                idNV = 1;

            // Lấy nhân viên từ DB
            var nv = db.NhanViens.FirstOrDefault(n => n.IdNhanVien == idNV);
            nv.TenNhanVien = txtTenNV.Text.Trim();
            nv.SoDienThoai = txtSDT.Text.Trim();
            DateTime ngaySinh;
            if (DateTime.TryParse(txtNS.Text.Trim(), out ngaySinh))
            {
                nv.NgaySinh = ngaySinh;
            }
            else
            {
                MessageBox.Show("Ngày sinh không hợp lệ! Vui lòng nhập đúng định dạng (vd: 2003-05-12 hoặc 12/05/2003).",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            nv.GioiTinh = txtGT.Text.Trim();
            nv.DiaChi = txtDC.Text.Trim();
            nv.Email = txtEmail.Text.Trim();
            db.SubmitChanges();       
            MessageBox.Show("Lưu thông tin thành công!",
                            "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            txtIDNV.Text = Session.IdNhanVien.ToString();
            txtTenNV.Enabled = false;
            txtSDT.Enabled = false;
            txtNS.Enabled = false;
            txtEmail.Enabled = false;
            txtGT.Enabled = false;
            txtDC.Enabled = false;
            btnSave.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            txtDC.Enabled = true;
            txtTenNV.Enabled = true;
            txtSDT.Enabled = true;
            txtNS.Enabled = true;
            txtEmail.Enabled = true;
            txtGT.Enabled = true;
            btnSave.Enabled = true;
        }

        private void btnDMK_Click(object sender, EventArgs e)
        {
            long id = Session.IdNhanVien;
            var nv = db.NguoiDungs.FirstOrDefault(n => n.IdNguoiDung == id);
            frmDoiMatKhau fadd = new frmDoiMatKhau();
            fadd.ShowDialog();


        }
    }
}
