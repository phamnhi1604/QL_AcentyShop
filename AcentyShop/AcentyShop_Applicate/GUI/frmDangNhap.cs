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
using AcentyShop_Applicate.DTO;

namespace AcentyShop_Applicate.GUI
{
    public partial class frmDangNhap : Form
    {
        BDAcentyShopDataContext db = new BDAcentyShopDataContext();

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống tên tài khoản");
                this.txtUsername.Focus();
                return;
            }
            if (string.IsNullOrEmpty(this.txtPass.Text))
            {
                MessageBox.Show("Không được bỏ trống mật khẩu");
                this.txtPass.Focus();
                return;
            }
            string username = txtUsername.Text.Trim();
            string password = txtPass.Text.Trim();
            var user = db.NguoiDungs
                 .FirstOrDefault(u => u.TenTaiKhoan == username
                                   && u.MatKhau == password);
            if (user != null )
            {
                Session.IdNhanVien = user.IdNguoiDung;
                if (user.IdNguoiDung == 0)
                    user.IdNguoiDung = 1;
                MessageBox.Show("Đăng nhập thành công!");
                MessageBox.Show("ID nhan vien:" + Session.IdNhanVien.ToString());

                new frmTrangChu().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không hợp lệ!");

            }


            //int kq = XuLy.Check_Config(); //hàm Check_Config() thuộc Class QL_NguoiDung
            //if (kq == 0)
            //{
            //    ProcessLogin();// Cấu hình phù hợp xử lý đăng nhập
            //}
        }
    }
}
