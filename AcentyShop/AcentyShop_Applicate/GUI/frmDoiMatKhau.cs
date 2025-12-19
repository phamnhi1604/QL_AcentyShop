using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcentyShop_Applicate.DTO;
using AcentyShop_Applicate.DAL;

namespace AcentyShop_Applicate.GUI
{
    public partial class frmDoiMatKhau : Form
    {
        BDAcentyShopDataContext db = new BDAcentyShopDataContext();
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void btnCF_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOldPW.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cũ!");
            }
            if (string.IsNullOrEmpty(txtRT.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu!");
                this.txtRT.Focus();
                return;
            }
            if (string.IsNullOrEmpty(this.txtNewPW.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!");
                this.txtNewPW.Focus();
                return;
            }
            if ( txtOldPW.Text.Trim() != txtRT.Text.Trim() )
            {
                MessageBox.Show("Xác nhận lại mật khẩu không trùng khớp");
                this.txtRT.Focus();
                return;
            }

            long id = Session.IdNhanVien;
            var nv = db.NguoiDungs.FirstOrDefault(n => n.IdNguoiDung == id);

            if (nv.MatKhau != txtOldPW.Text.Trim())
            {
                MessageBox.Show("Mật khẩu cũ không đúng!");
                txtOldPW.Focus();
                return;
            }
            nv.MatKhau = txtNewPW.Text;
            db.SubmitChanges();
            MessageBox.Show("Đổi mật khẩu thành công!");

            txtOldPW.Clear();
            txtNewPW.Clear();
            txtRT.Clear();



        }

        private void btnVisiOff_Click(object sender, EventArgs e)
        {
            txtNewPW.PasswordChar = '*';   // Ẩn mật khẩu (●●●)
            txtRT.PasswordChar = '*';   // Ẩn mật khẩu (●●●)
            txtOldPW.PasswordChar = '*';   // Ẩn mật khẩu (●●●)

            btnVisiOff.Visible = false;   // Ẩn nút "tắt con mắt"
            btnVisi.Visible = true;       // Hiện nút "mở con mắt"
            btnVisi.BringToFront();
        }
        private bool isHidden = true;
        //private void btnVisi_Click(object sender, EventArgs e)
        //{
        //    //isHidden = !isHidden;  // đảo trạng thái

        //    //txtOldPW.PasswordChar = isHidden ? '*' : '\0';
        //    //txtNewPW.PasswordChar = isHidden ? '*' : '\0';
        //    //txtRT.PasswordChar = isHidden ? '*' : '\0';

        //    //btnVisi.Image = isHidden
        //    //    ? Properties.Resources.eye_close     // icon đóng mắt
        //    //    : Properties.Resources.eye_open;     // icon mở mắt



            


        //}
        private void btnVisi_Click(object sender, EventArgs e)
            {
                txtNewPW.PasswordChar = '\0';  // Hiện mật khẩu
                txtRT.PasswordChar = '\0';  // Hiện mật khẩu
                txtOldPW.PasswordChar = '\0';  // Hiện mật khẩu

                btnVisiOff.Visible = true;   // Hiện nút "tắt con mắt"
                btnVisi.Visible = false;     // Ẩn nút "mở con mắt"
            btnVisiOff.BringToFront();

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
