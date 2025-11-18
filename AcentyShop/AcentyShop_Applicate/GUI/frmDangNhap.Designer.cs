namespace AcentyShop_Applicate.GUI
{
    partial class frmDangNhap
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
            this.label1 = new System.Windows.Forms.Label();
            this.uiAvatar1 = new Sunny.UI.UIAvatar();
            this.uiMenuButton1 = new Sunny.UI.UIMenuButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(291, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login System";
            // 
            // uiAvatar1
            // 
            this.uiAvatar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiAvatar1.Location = new System.Drawing.Point(80, 151);
            this.uiAvatar1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiAvatar1.Name = "uiAvatar1";
            this.uiAvatar1.Size = new System.Drawing.Size(140, 139);
            this.uiAvatar1.TabIndex = 1;
            this.uiAvatar1.Text = "uiAvatar1";
            // 
            // uiMenuButton1
            // 
            this.uiMenuButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiMenuButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiMenuButton1.Location = new System.Drawing.Point(299, 198);
            this.uiMenuButton1.Menu = null;
            this.uiMenuButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiMenuButton1.Name = "uiMenuButton1";
            this.uiMenuButton1.Size = new System.Drawing.Size(221, 35);
            this.uiMenuButton1.TabIndex = 2;
            this.uiMenuButton1.Text = "uiMenuButton1";
            this.uiMenuButton1.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uiMenuButton1);
            this.Controls.Add(this.uiAvatar1);
            this.Controls.Add(this.label1);
            this.Name = "frmDangNhap";
            this.Text = "frmDangNhap";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Sunny.UI.UIAvatar uiAvatar1;
        private Sunny.UI.UIMenuButton uiMenuButton1;
    }
}