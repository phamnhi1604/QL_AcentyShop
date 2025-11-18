namespace AcentyShop_Applicate.GUI.Feature
{
    partial class frmBarCode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbCam = new Sunny.UI.UIComboBox();
            this.txtBarCode = new Sunny.UI.UITextBox();
            this.btnStop = new Sunny.UI.UIButton();
            this.ptbImg = new System.Windows.Forms.PictureBox();
            this.btnGetCode = new Sunny.UI.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImg)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCam
            // 
            this.cbCam.DataSource = null;
            this.cbCam.FillColor = System.Drawing.Color.White;
            this.cbCam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbCam.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cbCam.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cbCam.Location = new System.Drawing.Point(467, 26);
            this.cbCam.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCam.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbCam.Name = "cbCam";
            this.cbCam.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbCam.Size = new System.Drawing.Size(263, 29);
            this.cbCam.SymbolSize = 24;
            this.cbCam.TabIndex = 12;
            this.cbCam.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbCam.Watermark = "";
            this.cbCam.SelectedIndexChanged += new System.EventHandler(this.cbCam_SelectedIndexChanged);
            // 
            // txtBarCode
            // 
            this.txtBarCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBarCode.Location = new System.Drawing.Point(479, 229);
            this.txtBarCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBarCode.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Padding = new System.Windows.Forms.Padding(5);
            this.txtBarCode.ShowText = false;
            this.txtBarCode.Size = new System.Drawing.Size(251, 29);
            this.txtBarCode.TabIndex = 13;
            this.txtBarCode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtBarCode.Watermark = "";
            // 
            // btnStop
            // 
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnStop.Location = new System.Drawing.Point(630, 379);
            this.btnStop.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 35);
            this.btnStop.TabIndex = 10;
            this.btnStop.Text = "Dừng";
            this.btnStop.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // ptbImg
            // 
            this.ptbImg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ptbImg.Location = new System.Drawing.Point(28, 26);
            this.ptbImg.Name = "ptbImg";
            this.ptbImg.Size = new System.Drawing.Size(413, 388);
            this.ptbImg.TabIndex = 11;
            this.ptbImg.TabStop = false;
            // 
            // btnGetCode
            // 
            this.btnGetCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnGetCode.Location = new System.Drawing.Point(630, 266);
            this.btnGetCode.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnGetCode.Name = "btnGetCode";
            this.btnGetCode.Size = new System.Drawing.Size(100, 35);
            this.btnGetCode.TabIndex = 10;
            this.btnGetCode.Text = "OK";
            this.btnGetCode.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnGetCode.Click += new System.EventHandler(this.btnGetCode_Click);
            // 
            // frmBarCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.cbCam);
            this.Controls.Add(this.ptbImg);
            this.Controls.Add(this.btnGetCode);
            this.Controls.Add(this.btnStop);
            this.Name = "frmBarCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBarCode";
            this.Load += new System.EventHandler(this.frmBarCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbImg;
        private Sunny.UI.UIComboBox cbCam;
        private Sunny.UI.UITextBox txtBarCode;
        private Sunny.UI.UIButton btnStop;
        private Sunny.UI.UIButton btnGetCode;
    }
}