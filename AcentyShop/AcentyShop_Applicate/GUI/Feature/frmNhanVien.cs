using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcentyShop_Applicate.DAL;


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
                       select new
                       {
                           nv.IdNhanVien,
                           nv.TenNhanVien,
                           nv.NgaySinh,
                           nv.GioiTinh,
                           nv.DiaChi
                       };
            dgvDSNV.DataSource = DSNV.ToList();
        }

        private void dgvDSNV_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDSNV.CurrentRow != null)
            {
                txtTenNV.Text = dgvDSNV.CurrentRow.Cells["TenNhanVien"].Value.ToString();
                txtGT.Text = dgvDSNV.CurrentRow.Cells["GioiTinh"].Value.ToString();
                txtSDT.Text = dgvDSNV.CurrentRow.Cells["TenNhanVien"].Value.ToString();
                txtNS.Text = dgvDSNV.CurrentRow.Cells["DiaChi"].Value.ToString();

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
    }
}
