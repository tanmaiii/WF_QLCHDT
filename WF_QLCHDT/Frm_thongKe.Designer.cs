namespace WF_QLCHDT
{
    partial class Frm_thongKe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_thongKe));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ttDoanhThu = new System.Windows.Forms.ToolStripMenuItem();
            this.ttSanPham = new System.Windows.Forms.ToolStripMenuItem();
            this.pnNoiDung = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttDoanhThu,
            this.ttSanPham});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1378, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ttDoanhThu
            // 
            this.ttDoanhThu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ttDoanhThu.ForeColor = System.Drawing.Color.White;
            this.ttDoanhThu.Name = "ttDoanhThu";
            this.ttDoanhThu.Size = new System.Drawing.Size(144, 36);
            this.ttDoanhThu.Text = "Doanh thu";
            this.ttDoanhThu.Click += new System.EventHandler(this.ttDoanhThu_Click);
            // 
            // ttSanPham
            // 
            this.ttSanPham.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ttSanPham.ForeColor = System.Drawing.Color.White;
            this.ttSanPham.Name = "ttSanPham";
            this.ttSanPham.Size = new System.Drawing.Size(137, 36);
            this.ttSanPham.Text = "Sản phẩm";
            this.ttSanPham.Click += new System.EventHandler(this.ttSanPham_Click);
            // 
            // pnNoiDung
            // 
            this.pnNoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnNoiDung.BackColor = System.Drawing.Color.White;
            this.pnNoiDung.Location = new System.Drawing.Point(0, 43);
            this.pnNoiDung.Name = "pnNoiDung";
            this.pnNoiDung.Size = new System.Drawing.Size(1366, 819);
            this.pnNoiDung.TabIndex = 1;
            // 
            // Frm_thongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1378, 889);
            this.Controls.Add(this.pnNoiDung);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Frm_thongKe";
            this.Text = "Thống kê";
            this.Load += new System.EventHandler(this.Frm_thongKe_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ttDoanhThu;
        private System.Windows.Forms.ToolStripMenuItem ttSanPham;
        private System.Windows.Forms.Panel pnNoiDung;
    }
}