using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcentyShop_Applicate.GUI
{
    public partial class frmTrangChu : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public frmTrangChu()
        {
            InitializeComponent();
            random = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(9, 86, 202);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Feature.frmKhachHang(), sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Feature.frmDanhMuc(), sender);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Feature.frmDonHang(), sender);

        }
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }
        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "HOME";
            panelTitleBar.BackColor = Color.FromArgb(4, 40, 94);
            panelLogo.BackColor = Color.FromArgb(6, 61, 141);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        //private void btnMaximize_Click(object sender, EventArgs e)
        //{
        //    if (this.Tag == null || this.Tag.ToString() != "Maximized")
        //    {
        //        // Lưu lại kích thước ban đầu để có thể restore sau
        //        this.Tag = "Maximized";
        //        this.FormBorderStyle = FormBorderStyle.None;

        //        var currentScreen = GetCurrentScreen();
        //        this.StartPosition = FormStartPosition.Manual;

        //        this.Bounds = currentScreen.WorkingArea;  // Resize đúng theo màn hình đang hiển thị
       
        //    }
        //    else
        //    {
        //        // Restore lại trạng thái bình thường
        //        this.Tag = null;
        //        this.FormBorderStyle = FormBorderStyle.Sizable;
        //        this.WindowState = FormWindowState.Normal;
        //    }
        //}

        //private Screen GetCurrentScreen()
        //{
        //    Rectangle formRect = this.Bounds;
        //    Screen maxScreen = Screen.AllScreens[0];
        //    int maxArea = 0;

        //    foreach (Screen screen in Screen.AllScreens)
        //    {
        //        Rectangle area = Rectangle.Intersect(screen.Bounds, formRect);
        //        int areaSize = area.Width * area.Height;

        //        if (areaSize > maxArea)
        //        {
        //            maxArea = areaSize;
        //            maxScreen = screen;
        //        }
        //    }

        //    return maxScreen;
        //}






        private void bntMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Feature.frmSanPham(), sender);

        }

        private void btnKhoHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Feature.frmKho(), sender);

        }
    }
}
