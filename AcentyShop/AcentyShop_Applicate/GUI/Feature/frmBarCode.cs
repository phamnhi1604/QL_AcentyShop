using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace AcentyShop_Applicate.GUI.Feature
{
    public partial class frmBarCode : Form
    {
        public string textcode = "";
        public frmBarCode()
        {
            InitializeComponent();
            //LoadCamera();
        }
        FilterInfoCollection FilterInfoCollection;
        VideoCaptureDevice captureDevice;

        private void frmBarCode_Load(object sender, EventArgs e)
        {
            LoadCamera();
        }
        private void LoadCamera()
        {
            // Lấy danh sách tất cả các thiết bị video (camera)
            FilterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            cbCam.Items.Clear(); // Xóa danh sách cũ nếu có

            foreach (FilterInfo device in FilterInfoCollection)
            {
                cbCam.Items.Add(device.Name); // Thêm tên camera vào combobox
            }

            // Nếu có ít nhất một camera thì chọn camera đầu tiên
            if (cbCam.Items.Count > 0)
                cbCam.SelectedIndex = 0;
            else
                MessageBox.Show("Không tìm thấy camera nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void StartCamera(int camIndex)
        {
            // Nếu đang chạy camera cũ thì dừng lại
            if (captureDevice != null && captureDevice.IsRunning)
            {
                captureDevice.SignalToStop();
                captureDevice.WaitForStop();
            }

            captureDevice = new VideoCaptureDevice(FilterInfoCollection[camIndex].MonikerString);
            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();
        }
        
        private void CaptureDevice_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            try
            {
                if (eventArgs.Frame == null) return;

                Bitmap bm = (Bitmap)eventArgs.Frame.Clone();
                if (bm == null) return;

                // Khởi tạo reader đúng cách
                var reader = new ZXing.BarcodeReader
                {
                    AutoRotate = true,
                    TryInverted = true,
                    Options = new ZXing.Common.DecodingOptions
                    {
                        PossibleFormats = new List<BarcodeFormat>
                        {
                            BarcodeFormat.CODE_128,
                            BarcodeFormat.CODE_39,
                            BarcodeFormat.EAN_13,
                            BarcodeFormat.EAN_8,
                            BarcodeFormat.UPC_A,
                            BarcodeFormat.UPC_E
                            // Nếu cần quét QRCode thì thêm:
                            // BarcodeFormat.QR_CODE
                        }
                    }
                };

                // Decode
                var result = reader.Decode(bm);

                if (result != null && !string.IsNullOrWhiteSpace(result.Text))
                {
                    string decodedText = result.Text.Trim();

                    // Chỉ nhận chuỗi là dãy số từ 5 chữ số trở lên
                    if (System.Text.RegularExpressions.Regex.IsMatch(decodedText, @"^\d{5,}$"))
                    {
                        txtBarCode.Invoke(new MethodInvoker(delegate ()
                        {
                            txtBarCode.Text = decodedText;
                            
                        }));
                    }
                }

                ptbImg.Image = bm;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }




        private void btnStop_Click(object sender, EventArgs e)
        {
            if (captureDevice.IsRunning) { 
                captureDevice.Stop();
                captureDevice=null;
                ptbImg.Image = null;
                txtBarCode.Text = "";
            }
        }

        private void cbCam_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartCamera(cbCam.SelectedIndex);
        }

        private void btnGetCode_Click(object sender, EventArgs e)
        {
            textcode = txtBarCode.Text;
            this.Close();
        }

        private void ptbImg_Click(object sender, EventArgs e)
        {

        }
    }
}
