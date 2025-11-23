using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcentyShop_Applicate.DAL;



namespace AcentyShop_Applicate.GUI.Feature
{
    public partial class frmSanPham : Form
    {
        BDAcentyShopDataContext db = new BDAcentyShopDataContext();

        public frmSanPham()
        {
            InitializeComponent();
            loadDSSP();
        }

        private void loadDSSP()
        {
            var danhSachSP = from sp in db.SanPhams
                             select new
                             {
                                 sp.IdSanPham,
                                 sp.TenSanPham,
                                 sp.GiaBan,
                                 sp.GiamGia,
                                 sp.NoiDungSanPham,
                                 sp.DanhGiaSanPham,
                                 sp.ThanhToanVanChuyen,
                                 sp.IdLoaiSP,
                                 sp.AnhSP,
                                 sp.TonTai
                             };

            dgvSanPham.DataSource = danhSachSP.ToList();
            //dgvSanPham.Columns["AnhSP"].Visible = false;

        }

        private void dgvSanPham_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow != null)
            {
                string imageName = dgvSanPham.CurrentRow.Cells["AnhSP"].Value?.ToString();
                if (!string.IsNullOrEmpty(imageName))
                {
                    string imagePath = Path.Combine(Application.StartupPath, @"..\..\..\AcentyShop\Content\Images\Data", imageName);
                    try
                    {
                        if (File.Exists(imagePath))
                        {
                            using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                            {
                                pictureBoxSP.Image = Image.FromStream(fs);
                            }
                        }
                        else
                        {
                            pictureBoxSP.Image = Properties.Resources.NoImage;
                            //MessageBox.Show("Ảnh không tồn tại: " + imagePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        pictureBoxSP.Image = Properties.Resources.NoImage;
                        //MessageBox.Show("Lỗi khi load ảnh: " + ex.Message);
                    }
                }
            }
        }

        private void uiGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            frmThemSP fadd = new frmThemSP();
            fadd.ShowDialog();
        }


        private void uiButton2_Click(object sender, EventArgs e)
        {

        }

        private void uiButton3_Click(object sender, EventArgs e)
        {

        }

        private void uiButton4_Click(object sender, EventArgs e)
        {

        }

        private void uiTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
