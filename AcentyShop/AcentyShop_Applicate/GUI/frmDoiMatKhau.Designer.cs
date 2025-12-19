
namespace AcentyShop_Applicate.GUI
{
    partial class frmDoiMatKhau
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
            this.txtNewPW = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.txtRT = new Sunny.UI.UITextBox();
            this.txtOldPW = new Sunny.UI.UITextBox();
            this.btnCF = new Sunny.UI.UIButton();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uiPanel2 = new Sunny.UI.UIPanel();
            this.btnVisiOff = new System.Windows.Forms.Button();
            this.btnVisi = new System.Windows.Forms.Button();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.uiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.uiPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNewPW
            // 
            this.txtNewPW.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewPW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtNewPW.Location = new System.Drawing.Point(83, 185);
            this.txtNewPW.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNewPW.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtNewPW.Name = "txtNewPW";
            this.txtNewPW.Padding = new System.Windows.Forms.Padding(5);
            this.txtNewPW.PasswordChar = '*';
            this.txtNewPW.ShowText = false;
            this.txtNewPW.Size = new System.Drawing.Size(235, 29);
            this.txtNewPW.TabIndex = 14;
            this.txtNewPW.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtNewPW.Watermark = "Nhập mật khẩu mới";
            // 
            // uiLabel1
            // 
            this.uiLabel1.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiLabel1.Location = new System.Drawing.Point(110, 50);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(188, 39);
            this.uiLabel1.TabIndex = 15;
            this.uiLabel1.Text = "Đổi mật khẩu";
            // 
            // txtRT
            // 
            this.txtRT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtRT.Location = new System.Drawing.Point(83, 146);
            this.txtRT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRT.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtRT.Name = "txtRT";
            this.txtRT.Padding = new System.Windows.Forms.Padding(5);
            this.txtRT.PasswordChar = '*';
            this.txtRT.ShowText = false;
            this.txtRT.Size = new System.Drawing.Size(235, 29);
            this.txtRT.TabIndex = 2;
            this.txtRT.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtRT.Watermark = "Nhập lại mật khẩu";
            // 
            // txtOldPW
            // 
            this.txtOldPW.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOldPW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtOldPW.Location = new System.Drawing.Point(83, 107);
            this.txtOldPW.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOldPW.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtOldPW.Name = "txtOldPW";
            this.txtOldPW.Padding = new System.Windows.Forms.Padding(5);
            this.txtOldPW.PasswordChar = '*';
            this.txtOldPW.ShowText = false;
            this.txtOldPW.Size = new System.Drawing.Size(235, 29);
            this.txtOldPW.TabIndex = 1;
            this.txtOldPW.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtOldPW.Watermark = "Nhập mật khẩu cũ";
            // 
            // btnCF
            // 
            this.btnCF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCF.Location = new System.Drawing.Point(83, 222);
            this.btnCF.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCF.Name = "btnCF";
            this.btnCF.Size = new System.Drawing.Size(235, 29);
            this.btnCF.TabIndex = 16;
            this.btnCF.Text = "Xác nhận";
            this.btnCF.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnCF.Click += new System.EventHandler(this.btnCF_Click);
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.pictureBox1);
            this.uiPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiPanel1.Location = new System.Drawing.Point(0, 0);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(388, 324);
            this.uiPanel1.TabIndex = 19;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::AcentyShop_Applicate.Properties.Resources.changePWLogo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(388, 324);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // uiPanel2
            // 
            this.uiPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiPanel2.Controls.Add(this.uiButton1);
            this.uiPanel2.Controls.Add(this.btnVisiOff);
            this.uiPanel2.Controls.Add(this.uiLabel1);
            this.uiPanel2.Controls.Add(this.txtRT);
            this.uiPanel2.Controls.Add(this.btnVisi);
            this.uiPanel2.Controls.Add(this.txtOldPW);
            this.uiPanel2.Controls.Add(this.txtNewPW);
            this.uiPanel2.Controls.Add(this.btnCF);
            this.uiPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiPanel2.Location = new System.Drawing.Point(387, 2);
            this.uiPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel2.Name = "uiPanel2";
            this.uiPanel2.Size = new System.Drawing.Size(431, 320);
            this.uiPanel2.TabIndex = 20;
            this.uiPanel2.Text = null;
            this.uiPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnVisiOff
            // 
            this.btnVisiOff.BackColor = System.Drawing.Color.Transparent;
            this.btnVisiOff.FlatAppearance.BorderSize = 0;
            this.btnVisiOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisiOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnVisiOff.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnVisiOff.Image = global::AcentyShop_Applicate.Properties.Resources.visibility_off_24dp_434343_FILL0_wght400_GRAD0_opsz24;
            this.btnVisiOff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVisiOff.Location = new System.Drawing.Point(325, 222);
            this.btnVisiOff.Name = "btnVisiOff";
            this.btnVisiOff.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnVisiOff.Size = new System.Drawing.Size(60, 29);
            this.btnVisiOff.TabIndex = 18;
            this.btnVisiOff.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVisiOff.UseVisualStyleBackColor = false;
            this.btnVisiOff.Click += new System.EventHandler(this.btnVisiOff_Click);
            // 
            // btnVisi
            // 
            this.btnVisi.BackColor = System.Drawing.Color.Transparent;
            this.btnVisi.FlatAppearance.BorderSize = 0;
            this.btnVisi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnVisi.ForeColor = System.Drawing.Color.Transparent;
            this.btnVisi.Image = global::AcentyShop_Applicate.Properties.Resources.visibility_24dp_434343_FILL0_wght400_GRAD0_opsz241;
            this.btnVisi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVisi.Location = new System.Drawing.Point(325, 222);
            this.btnVisi.Name = "btnVisi";
            this.btnVisi.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnVisi.Size = new System.Drawing.Size(60, 29);
            this.btnVisi.TabIndex = 17;
            this.btnVisi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVisi.UseVisualStyleBackColor = false;
            this.btnVisi.Click += new System.EventHandler(this.btnVisi_Click);
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.FillColor = System.Drawing.Color.SteelBlue;
            this.uiButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiButton1.Location = new System.Drawing.Point(355, 275);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(67, 35);
            this.uiButton1.TabIndex = 19;
            this.uiButton1.Text = "Thoát";
            this.uiButton1.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // frmDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(821, 324);
            this.Controls.Add(this.uiPanel2);
            this.Controls.Add(this.uiPanel1);
            this.Name = "frmDoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mật khẩu";
            this.Load += new System.EventHandler(this.frmDoiMatKhau_Load);
            this.uiPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.uiPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITextBox txtNewPW;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox txtRT;
        private Sunny.UI.UITextBox txtOldPW;
        private Sunny.UI.UIButton btnCF;
        private System.Windows.Forms.Button btnVisi;
        private System.Windows.Forms.Button btnVisiOff;
        private Sunny.UI.UIPanel uiPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Sunny.UI.UIPanel uiPanel2;
        private Sunny.UI.UIButton uiButton1;
    }
}