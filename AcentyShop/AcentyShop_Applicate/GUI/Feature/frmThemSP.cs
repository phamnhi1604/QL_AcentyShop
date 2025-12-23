using AcentyShop_Applicate.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AcentyShop_Applicate.GUI.Feature
{
    public partial class frmThemSP : Form
    {
        BDAcentyShopDataContext db = new BDAcentyShopDataContext();

        public frmThemSP()
        {
            InitializeComponent();
        }

        private void btnBarCode_Click(object sender, EventArgs e)
        {
            frmBarCode frmBarCode = new frmBarCode();
            frmBarCode.ShowDialog();

            if (!string.IsNullOrEmpty(frmBarCode.textcode))
            {
                txtBarCode.Text = frmBarCode.textcode; // txtBarCode ở frmThemSP
            }
        }

        private void loadCboLoaiSPCha()
        {
            var lstSP = from sp in db.LoaiSanPhamChas
                        select new
                        {
                            sp.IdLoaiSPCha,
                            sp.TenLoaiSPCha
                        };
            cboLoaiSPCha.DisplayMember = "TenLoaiSPCha";       // Hiện tên
            cboLoaiSPCha.ValueMember = "IdLoaiSPCha";
            cboLoaiSPCha.DataSource = lstSP.ToList();// Lấy ID khi cần
            //cboTenSP.SelectedIndex = -1;            // Không chọn sẵn
        }
        private void loadCboLoaiSPCon(int idLoaiSPCha)
        {
            var lstSPCon = from sp in db.LoaiSanPhams
                           where sp.IdLoaiSPCha == idLoaiSPCha
                           select new
                           {
                               sp.IdLoaiSP,
                               sp.TenLoaiSP
                           };

            cboLoaiSP.DisplayMember = "TenLoaiSP";
            cboLoaiSP.ValueMember = "IdLoaiSanPham";
            cboLoaiSP.DataSource = lstSPCon.ToList();
            //cboLoaiSP.SelectedIndex = -1;
        }

        private void frmThemSP_Load(object sender, EventArgs e)
        {
            loadCboLoaiSPCha();
        }

        private void cboLoaiSPCha_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboLoaiSPCha.SelectedValue == null)
                return;

            if (int.TryParse(cboLoaiSPCha.SelectedValue.ToString(), out int idLoaiCha))
            {
                loadCboLoaiSPCon(idLoaiCha);
            }
        }

        private void pictureBoxSP_Click(object sender, EventArgs e)
        {
            //frmAnhSanPham frmPic = new frmAnhSanPham();
            //frmPic.ShowDialog();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            ofd.Title = "Chọn ảnh sản phẩm";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string sourcePath = ofd.FileName;
                string fileName = Path.GetFileName(sourcePath);

                string targetFolder = Path.Combine(
                    Application.StartupPath,
                    @"..\..\..\AcentyShop\Data"
                );

                // Tạo folder nếu chưa tồn tại
                if (!Directory.Exists(targetFolder))
                    Directory.CreateDirectory(targetFolder);

                string targetPath = Path.Combine(targetFolder, fileName);

                // Nếu trùng tên → thêm timestamp
                if (File.Exists(targetPath))
                {
                    string name = Path.GetFileNameWithoutExtension(fileName);
                    string ext = Path.GetExtension(fileName);
                    fileName = $"{name}_{DateTime.Now.Ticks}{ext}";
                    targetPath = Path.Combine(targetFolder, fileName);
                }

                File.Copy(sourcePath, targetPath);

                // Hiển thị ảnh
                pictureBoxSP.Image = Image.FromFile(targetPath);
                pictureBoxSP.SizeMode = PictureBoxSizeMode.Zoom;

                // Lưu tên ảnh để insert DB
                //txtTenAnh.Text = fileName; // hoặc biến string anhSP = fileName;
            }
        }
    }
}
