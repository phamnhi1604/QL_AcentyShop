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
            
            //int kq = XuLy.Check_Config(); //hàm Check_Config() thuộc Class QL_NguoiDung
            //if (kq == 0)
            //{
            //    ProcessLogin();// Cấu hình phù hợp xử lý đăng nhập
            //}
        }
    }
}
