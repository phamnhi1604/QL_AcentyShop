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
    public partial class frmDanhMuc : Form
    {
        BDAcentyShopDataContext db = new BDAcentyShopDataContext();
        public frmDanhMuc()
        {
            InitializeComponent();
            loadDMCha();
        }

        private void frmDanhMuc_Load(object sender, EventArgs e)
        {
            LoadTheme();
            loadDMCha();
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            //label4.ForeColor = ThemeColor.SecondaryColor;
            //label5.ForeColor = ThemeColor.PrimaryColor;
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {

        }
        private void loadDMCha()
        {
            var lstDMC = from i in db.LoaiSanPhamChas
                         select new
                         {
                             i.IdLoaiSPCha,
                             i.TenLoaiSPCha
                         };
            dgvDMCha.DataSource = lstDMC.ToList();
        }

        private void dgvDMCha_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDMCha.CurrentRow != null)
            {
                // Lấy IdLoaiSPCha từ dòng đang chọn
                var id = dgvDMCha.CurrentRow.Cells["IdLoaiSPCha"].Value.ToString();
                int idLoaiSPCha = int.Parse(id);

                // Load các LoaiSanPham tương ứng
                var loaiSPList = db.LoaiSanPhams
                                   .Where(x => x.IdLoaiSPCha == idLoaiSPCha)
                                   .Select(x => new
                                   {
                                       x.IdLoaiSP,
                                       x.TenLoaiSP
                                   })
                                   .ToList();

                dgvDMCon.DataSource = loaiSPList;
            }
        }

        private void uiGroupBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
