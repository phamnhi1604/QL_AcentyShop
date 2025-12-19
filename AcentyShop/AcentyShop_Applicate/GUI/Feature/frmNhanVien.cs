using AcentyShop_Applicate.DAL;
using System;
using System.Linq;
using System.Windows.Forms;


namespace AcentyShop_Applicate.GUI.Feature
{
    public partial class frmNhanVien : Form
    {
        BDAcentyShopDataContext db = new BDAcentyShopDataContext();

        public frmNhanVien()
        {
            InitializeComponent();
            loadThongTinNV();
        }

        private void btnRSPW_Click(object sender, EventArgs e)
        {
            
        }
        private void loadThongTinNV()
        {
            var DSNV = from nv in db.NhanViens 
                       join nd in db.NguoiDungs on nv.IdNguoiDung equals nd.IdNguoiDung
                       select new
                       {
                           nv.IdNhanVien,
                           nv.IdNguoiDung,
                           nv.TenNhanVien,
                           nv.NgaySinh,
                           nv.GioiTinh,
                           nv.DiaChi,
                           nd.Cam
                       };
            dgvDSNV.DataSource = DSNV.ToList();
            dgvDSNV.Columns["IdNguoiDung"].Visible = false;

        }

        private void dgvDSNV_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDSNV.CurrentRow != null)
            {
                txtMNV.Text = "Mã NV: "+(dgvDSNV.CurrentRow.Cells["IdNhanVien"].Value.ToString());
                var value = dgvDSNV.CurrentRow.Cells["Cam"].Value;

                bool a = value != DBNull.Value && Convert.ToBoolean(value);

                txtTrangThai.Text = a ? "Đang hoạt động" : "Ngừng hoạt động";

                txtTenNV.Text = dgvDSNV.CurrentRow.Cells["TenNhanVien"].Value.ToString();
                txtGT.Text = dgvDSNV.CurrentRow.Cells["GioiTinh"].Value.ToString();
                txtSDT.Text = dgvDSNV.CurrentRow.Cells["TenNhanVien"].Value.ToString();
                txtDC.Text = dgvDSNV.CurrentRow.Cells["DiaChi"].Value.ToString().Split(',').Last().Trim();
                //txtNS.Text = dgvDSNV.CurrentRow.Cells["NgaySinh"].Value.ToString("dd/MM/yyyy");
                var ns = dgvDSNV.CurrentRow.Cells["NgaySinh"].Value;

                if (ns != null && DateTime.TryParse(ns.ToString(), out DateTime date))
                {
                    txtNS.Text = date.ToString("dd/MM/yyyy");
                }
                else
                {
                    txtNS.Text = "";
                }
                txtTen.Text = dgvDSNV.CurrentRow.Cells["TenNhanVien"].Value.ToString();
                uiTextBox2.Text = dgvDSNV.CurrentRow.Cells["TenNhanVien"].Value.ToString();
                uiTextBox3.Text = dgvDSNV.CurrentRow.Cells["NgaySinh"].Value.ToString();
                uiTextBox4.Text = dgvDSNV.CurrentRow.Cells["GioiTinh"].Value.ToString();
                uiTextBox5.Text = dgvDSNV.CurrentRow.Cells["DiaChi"].Value.ToString();
                uiTextBox6.Text = dgvDSNV.CurrentRow.Cells["TenNhanVien"].Value.ToString();


                txtTen.Enabled = false;
                uiTextBox2.Enabled = false;
                uiTextBox3.Enabled = false;
                uiTextBox4.Enabled = false;
                uiTextBox5.Enabled = false;
                uiTextBox6.Enabled = false;
                btnSave.Enabled = false;

                //string imageName = dgvDSNV.CurrentRow.Cells["AnhSP"].Value?.ToString();
                //if (!string.IsNullOrEmpty(imageName))
                //{
                //    string imagePath = Path.Combine(Application.StartupPath, @"..\..\..\AcentyShop\Content\Images\Data", imageName);
                //    try
                //    {
                //        if (File.Exists(imagePath))
                //        {
                //            using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                //            {
                //                pictureBoxNV.Image = Image.FromStream(fs);
                //            }
                //        }
                //        else
                //        {
                //            pictureBoxNV.Image = Properties.Resources.NoImage;
                //            //MessageBox.Show("Ảnh không tồn tại: " + imagePath);
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        pictureBoxNV.Image = Properties.Resources.NoImage;
                //        //MessageBox.Show("Lỗi khi load ảnh: " + ex.Message);
                //    }
                //}

            }
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvDSNV.CurrentRow.Cells["IdNhanVien"].Value);


            txtTen.Enabled = true;
            uiTextBox2.Enabled = true;
            uiTextBox3.Enabled = true;
            uiTextBox4.Enabled = true;
            uiTextBox5.Enabled = true;
            uiTextBox6.Enabled = true;
            btnSave.Enabled = true;


            txtTen.Text = dgvDSNV.CurrentRow.Cells["TenNhanVien"].Value.ToString();
            uiTextBox2.Text = dgvDSNV.CurrentRow.Cells["TenNhanVien"].Value.ToString();
            uiTextBox3.Text = dgvDSNV.CurrentRow.Cells["NgaySinh"].Value.ToString();
            uiTextBox4.Text = dgvDSNV.CurrentRow.Cells["GioiTinh"].Value.ToString();
            uiTextBox5.Text = dgvDSNV.CurrentRow.Cells["DiaChi"].Value.ToString();
            uiTextBox6.Text = dgvDSNV.CurrentRow.Cells["TenNhanVien"].Value.ToString();
        }

        private void resetMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDSNV.CurrentRow == null)
                return;

            // Lấy id người dùng từ dòng đang chọn
            int id = Convert.ToInt32(dgvDSNV.CurrentRow.Cells["IdNguoiDung"].Value);

            // Tìm trong database
            var user = db.NguoiDungs.FirstOrDefault(x => x.IdNguoiDung == id);

            if (user != null)
            {
                user.MatKhau = "00000000"; // Mật khẩu mới
                db.SubmitChanges();        // LƯU – vì bạn dùng LINQ to SQL

                MessageBox.Show("Reset mật khẩu thành công!",
                                "Thông báo", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không tìm thấy người dùng!",
                                "Lỗi", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void khóaNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDSNV.CurrentRow == null)
                return;

            // Lấy id người dùng từ dòng đang chọn
            int id = Convert.ToInt32(dgvDSNV.CurrentRow.Cells["IdNguoiDung"].Value);

            // Tìm trong database
            var user = db.NguoiDungs.FirstOrDefault(x => x.IdNguoiDung == id);

            if (user != null)
            {
                user.Cam = true; // Mật khẩu mới
                db.SubmitChanges();        // LƯU – vì bạn dùng LINQ to SQL

                MessageBox.Show("Khóa người dùng thành công!",
                                "Thông báo", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không tìm thấy người dùng!",
                                "Lỗi", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }


        private void mởNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDSNV.CurrentRow == null)
                return;

            // Lấy id người dùng từ dòng đang chọn
            int id = Convert.ToInt32(dgvDSNV.CurrentRow.Cells["IdNguoiDung"].Value);

            // Tìm trong database
            var user = db.NguoiDungs.FirstOrDefault(x => x.IdNguoiDung == id);

            if (user != null)
            {
                user.Cam = false; // Mật khẩu mới
                db.SubmitChanges();        // LƯU – vì bạn dùng LINQ to SQL

                MessageBox.Show("Mở khóa người dùng thành công!",
                                "Thông báo", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không tìm thấy người dùng!",
                                "Lỗi", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            txtTen.Enabled = false;
            uiTextBox2.Enabled = false;
            uiTextBox3.Enabled = false;
            uiTextBox4.Enabled = false;
            uiTextBox5.Enabled = false;
            uiTextBox6.Enabled = false;
            btnSave.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            txtTen.Enabled = false;
            uiTextBox2.Enabled = false;
            uiTextBox3.Enabled = false;
            uiTextBox4.Enabled = false;
            uiTextBox5.Enabled = false;
            uiTextBox6.Enabled = false;
            btnSave.Enabled = false;

            db.SubmitChanges();        // LƯU – vì bạn dùng LINQ to SQL

            MessageBox.Show("Lưu thông tin thành công!",
                            "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadThongTinNV();
            txtTen.Enabled = false;
            uiTextBox2.Enabled = false;
            uiTextBox3.Enabled = false;
            uiTextBox4.Enabled = false;
            uiTextBox5.Enabled = false;
            uiTextBox6.Enabled = false;
            btnSave.Enabled = false;
            btnSave.Enabled = false;
        }

    }
}
 