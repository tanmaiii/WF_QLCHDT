namespace WF_QLCHDT
{
    partial class Frm_thanhToan
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
            System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_thanhToan));
            this.btnTaoDonHang = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnInHoaDon = new System.Windows.Forms.Button();
            this.tbTenKH = new System.Windows.Forms.TextBox();
            this.tbSoDienThoaiKH = new System.Windows.Forms.TextBox();
            this.tbDiaChiKH = new System.Windows.Forms.TextBox();
            this.tbMaHoaDon = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbTongTien = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soLuongMua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbGiaSP = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbSoLuongTonKho = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nuSoLuong = new System.Windows.Forms.NumericUpDown();
            this.cbTenLoai = new System.Windows.Forms.ComboBox();
            this.btnThemSP = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.dgvChonSP = new System.Windows.Forms.DataGridView();
            this.ChonMaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChonTenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChonGiaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChonSoLuongTonKho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbChonSP = new System.Windows.Forms.GroupBox();
            this.tbMaSP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTenSP = new System.Windows.Forms.TextBox();
            this.btTimKiem = new System.Windows.Forms.Button();
            this.tbTimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.gbDSSP = new System.Windows.Forms.GroupBox();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChonSP)).BeginInit();
            this.gbChonSP.SuspendLayout();
            this.gbThongTin.SuspendLayout();
            this.gbDSSP.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            flowLayoutPanel1.Controls.Add(this.btnTaoDonHang);
            flowLayoutPanel1.Controls.Add(this.btnReset);
            flowLayoutPanel1.Controls.Add(this.btnInHoaDon);
            flowLayoutPanel1.Location = new System.Drawing.Point(12, 795);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(1366, 68);
            flowLayoutPanel1.TabIndex = 32;
            // 
            // btnTaoDonHang
            // 
            this.btnTaoDonHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.btnTaoDonHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoDonHang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoDonHang.ForeColor = System.Drawing.Color.White;
            this.btnTaoDonHang.Image = ((System.Drawing.Image)(resources.GetObject("btnTaoDonHang.Image")));
            this.btnTaoDonHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaoDonHang.Location = new System.Drawing.Point(3, 2);
            this.btnTaoDonHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTaoDonHang.Name = "btnTaoDonHang";
            this.btnTaoDonHang.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnTaoDonHang.Size = new System.Drawing.Size(244, 58);
            this.btnTaoDonHang.TabIndex = 4;
            this.btnTaoDonHang.Text = "      Lưu hóa đơn";
            this.btnTaoDonHang.UseVisualStyleBackColor = false;
            this.btnTaoDonHang.Click += new System.EventHandler(this.btnTaoDonHang_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.Location = new System.Drawing.Point(253, 2);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnReset.Size = new System.Drawing.Size(244, 60);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "      Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnInHoaDon
            // 
            this.btnInHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.btnInHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInHoaDon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnInHoaDon.Image = ((System.Drawing.Image)(resources.GetObject("btnInHoaDon.Image")));
            this.btnInHoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInHoaDon.Location = new System.Drawing.Point(503, 2);
            this.btnInHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInHoaDon.Name = "btnInHoaDon";
            this.btnInHoaDon.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnInHoaDon.Size = new System.Drawing.Size(244, 60);
            this.btnInHoaDon.TabIndex = 6;
            this.btnInHoaDon.Text = "    In hóa đơn";
            this.btnInHoaDon.UseVisualStyleBackColor = false;
            this.btnInHoaDon.Visible = false;
            this.btnInHoaDon.Click += new System.EventHandler(this.btnInHoaDon_Click);
            // 
            // tbTenKH
            // 
            this.tbTenKH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTenKH.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTenKH.Location = new System.Drawing.Point(15, 231);
            this.tbTenKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTenKH.Name = "tbTenKH";
            this.tbTenKH.Size = new System.Drawing.Size(352, 45);
            this.tbTenKH.TabIndex = 22;
            // 
            // tbSoDienThoaiKH
            // 
            this.tbSoDienThoaiKH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSoDienThoaiKH.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSoDienThoaiKH.Location = new System.Drawing.Point(15, 150);
            this.tbSoDienThoaiKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSoDienThoaiKH.Name = "tbSoDienThoaiKH";
            this.tbSoDienThoaiKH.Size = new System.Drawing.Size(351, 45);
            this.tbSoDienThoaiKH.TabIndex = 21;
            this.tbSoDienThoaiKH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSoDienThoaiKH_KeyPress);
            // 
            // tbDiaChiKH
            // 
            this.tbDiaChiKH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDiaChiKH.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDiaChiKH.Location = new System.Drawing.Point(15, 312);
            this.tbDiaChiKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbDiaChiKH.Name = "tbDiaChiKH";
            this.tbDiaChiKH.Size = new System.Drawing.Size(352, 45);
            this.tbDiaChiKH.TabIndex = 19;
            // 
            // tbMaHoaDon
            // 
            this.tbMaHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMaHoaDon.Enabled = false;
            this.tbMaHoaDon.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMaHoaDon.Location = new System.Drawing.Point(13, 66);
            this.tbMaHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbMaHoaDon.Name = "tbMaHoaDon";
            this.tbMaHoaDon.Size = new System.Drawing.Size(352, 45);
            this.tbMaHoaDon.TabIndex = 31;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(7, 32);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(158, 32);
            this.label17.TabIndex = 30;
            this.label17.Text = "Mã đơn hàng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 278);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 32);
            this.label6.TabIndex = 9;
            this.label6.Text = "Địa chỉ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 32);
            this.label3.TabIndex = 3;
            this.label3.Text = "Số điện thoại";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên khách hàng ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(8, 30);
            this.label15.Name = "label15";
            this.label15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label15.Size = new System.Drawing.Size(376, 32);
            this.label15.TabIndex = 31;
            this.label15.Text = "( Nháp đúp vào sản phẩm để xóa)";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(276, 395);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label13.Size = new System.Drawing.Size(75, 38);
            this.label13.TabIndex = 31;
            this.label13.Text = "VND";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbTongTien
            // 
            this.tbTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTongTien.BackColor = System.Drawing.Color.White;
            this.tbTongTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTongTien.Enabled = false;
            this.tbTongTien.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTongTien.ForeColor = System.Drawing.Color.Red;
            this.tbTongTien.Location = new System.Drawing.Point(13, 393);
            this.tbTongTien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTongTien.Name = "tbTongTien";
            this.tbTongTien.Size = new System.Drawing.Size(257, 45);
            this.tbTongTien.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(11, 359);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label11.Size = new System.Drawing.Size(117, 32);
            this.label11.TabIndex = 28;
            this.label11.Text = "Tổng tiền";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AllowUserToAddRows = false;
            this.dgvSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPham.BackgroundColor = System.Drawing.Color.White;
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSP,
            this.tenSanPham,
            this.giaSP,
            this.TenLoai,
            this.soLuongMua,
            this.thanhTien});
            this.dgvSanPham.Location = new System.Drawing.Point(6, 64);
            this.dgvSanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.RowHeadersVisible = false;
            this.dgvSanPham.RowHeadersWidth = 62;
            this.dgvSanPham.RowTemplate.Height = 28;
            this.dgvSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSanPham.Size = new System.Drawing.Size(1348, 264);
            this.dgvSanPham.TabIndex = 0;
            this.dgvSanPham.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_CellDoubleClick);
            // 
            // MaSP
            // 
            this.MaSP.DataPropertyName = "MaSP";
            this.MaSP.HeaderText = "Mã SP";
            this.MaSP.MinimumWidth = 8;
            this.MaSP.Name = "MaSP";
            this.MaSP.ReadOnly = true;
            // 
            // tenSanPham
            // 
            this.tenSanPham.DataPropertyName = "tenSP";
            this.tenSanPham.HeaderText = "Tên sản phẩm";
            this.tenSanPham.MinimumWidth = 6;
            this.tenSanPham.Name = "tenSanPham";
            this.tenSanPham.ReadOnly = true;
            // 
            // giaSP
            // 
            this.giaSP.DataPropertyName = "giaSP";
            this.giaSP.HeaderText = "Giá";
            this.giaSP.MinimumWidth = 6;
            this.giaSP.Name = "giaSP";
            this.giaSP.ReadOnly = true;
            // 
            // TenLoai
            // 
            this.TenLoai.DataPropertyName = "TenLoai";
            this.TenLoai.HeaderText = "Tên loại";
            this.TenLoai.MinimumWidth = 8;
            this.TenLoai.Name = "TenLoai";
            this.TenLoai.ReadOnly = true;
            // 
            // soLuongMua
            // 
            this.soLuongMua.DataPropertyName = "soLuongMua";
            this.soLuongMua.HeaderText = "Số lượng mua";
            this.soLuongMua.MinimumWidth = 6;
            this.soLuongMua.Name = "soLuongMua";
            this.soLuongMua.ReadOnly = true;
            // 
            // thanhTien
            // 
            this.thanhTien.DataPropertyName = "thanhTien";
            this.thanhTien.HeaderText = "Thành Tiền";
            this.thanhTien.MinimumWidth = 6;
            this.thanhTien.Name = "thanhTien";
            this.thanhTien.ReadOnly = true;
            // 
            // tbGiaSP
            // 
            this.tbGiaSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbGiaSP.Enabled = false;
            this.tbGiaSP.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGiaSP.Location = new System.Drawing.Point(557, 96);
            this.tbGiaSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbGiaSP.Name = "tbGiaSP";
            this.tbGiaSP.Size = new System.Drawing.Size(300, 45);
            this.tbGiaSP.TabIndex = 28;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(437, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 32);
            this.label12.TabIndex = 29;
            this.label12.Text = "Đơn giá";
            // 
            // tbSoLuongTonKho
            // 
            this.tbSoLuongTonKho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSoLuongTonKho.Enabled = false;
            this.tbSoLuongTonKho.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSoLuongTonKho.Location = new System.Drawing.Point(123, 96);
            this.tbSoLuongTonKho.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSoLuongTonKho.Name = "tbSoLuongTonKho";
            this.tbSoLuongTonKho.Size = new System.Drawing.Size(304, 45);
            this.tbSoLuongTonKho.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 32);
            this.label10.TabIndex = 24;
            this.label10.Text = "SP Còn";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(437, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 32);
            this.label9.TabIndex = 24;
            this.label9.Text = "Tên SP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 209);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(90, 32);
            this.label5.TabIndex = 24;
            this.label5.Text = "Loại SP";
            // 
            // nuSoLuong
            // 
            this.nuSoLuong.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuSoLuong.Location = new System.Drawing.Point(125, 149);
            this.nuSoLuong.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.nuSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuSoLuong.Name = "nuSoLuong";
            this.nuSoLuong.Size = new System.Drawing.Size(302, 45);
            this.nuSoLuong.TabIndex = 27;
            this.nuSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbTenLoai
            // 
            this.cbTenLoai.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTenLoai.FormattingEnabled = true;
            this.cbTenLoai.Location = new System.Drawing.Point(123, 201);
            this.cbTenLoai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbTenLoai.Name = "cbTenLoai";
            this.cbTenLoai.Size = new System.Drawing.Size(304, 46);
            this.cbTenLoai.TabIndex = 26;
            this.cbTenLoai.SelectedIndexChanged += new System.EventHandler(this.cbTenLoai_SelectedIndexChanged);
            // 
            // btnThemSP
            // 
            this.btnThemSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.btnThemSP.FlatAppearance.BorderSize = 0;
            this.btnThemSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemSP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemSP.ForeColor = System.Drawing.Color.White;
            this.btnThemSP.Image = ((System.Drawing.Image)(resources.GetObject("btnThemSP.Image")));
            this.btnThemSP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemSP.Location = new System.Drawing.Point(557, 147);
            this.btnThemSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemSP.Name = "btnThemSP";
            this.btnThemSP.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnThemSP.Size = new System.Drawing.Size(300, 48);
            this.btnThemSP.TabIndex = 6;
            this.btnThemSP.Text = "      Thêm sản phẩm vào giỏ";
            this.btnThemSP.UseVisualStyleBackColor = false;
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(13, 155);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 32);
            this.label16.TabIndex = 30;
            this.label16.Text = "SL mua";
            // 
            // dgvChonSP
            // 
            this.dgvChonSP.AllowUserToAddRows = false;
            this.dgvChonSP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChonSP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChonSP.BackgroundColor = System.Drawing.Color.White;
            this.dgvChonSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChonSP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChonMaSP,
            this.ChonTenSP,
            this.ChonGiaSP,
            this.ChonSoLuongTonKho});
            this.dgvChonSP.Location = new System.Drawing.Point(19, 278);
            this.dgvChonSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvChonSP.Name = "dgvChonSP";
            this.dgvChonSP.ReadOnly = true;
            this.dgvChonSP.RowHeadersVisible = false;
            this.dgvChonSP.RowHeadersWidth = 62;
            this.dgvChonSP.RowTemplate.Height = 28;
            this.dgvChonSP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChonSP.Size = new System.Drawing.Size(851, 168);
            this.dgvChonSP.TabIndex = 32;
            this.dgvChonSP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChonSP_CellClick);
            // 
            // ChonMaSP
            // 
            this.ChonMaSP.DataPropertyName = "ChonMaSP";
            this.ChonMaSP.HeaderText = "Mã SP";
            this.ChonMaSP.MinimumWidth = 8;
            this.ChonMaSP.Name = "ChonMaSP";
            this.ChonMaSP.ReadOnly = true;
            // 
            // ChonTenSP
            // 
            this.ChonTenSP.DataPropertyName = "ChonTenSP";
            this.ChonTenSP.HeaderText = "Tên SP";
            this.ChonTenSP.MinimumWidth = 6;
            this.ChonTenSP.Name = "ChonTenSP";
            this.ChonTenSP.ReadOnly = true;
            // 
            // ChonGiaSP
            // 
            this.ChonGiaSP.DataPropertyName = "ChonGiaSP";
            this.ChonGiaSP.HeaderText = "Giá";
            this.ChonGiaSP.MinimumWidth = 6;
            this.ChonGiaSP.Name = "ChonGiaSP";
            this.ChonGiaSP.ReadOnly = true;
            // 
            // ChonSoLuongTonKho
            // 
            this.ChonSoLuongTonKho.DataPropertyName = "ChonSoLuongTonKho";
            this.ChonSoLuongTonKho.HeaderText = "Tồn kho";
            this.ChonSoLuongTonKho.MinimumWidth = 8;
            this.ChonSoLuongTonKho.Name = "ChonSoLuongTonKho";
            this.ChonSoLuongTonKho.ReadOnly = true;
            // 
            // gbChonSP
            // 
            this.gbChonSP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbChonSP.Controls.Add(this.tbMaSP);
            this.gbChonSP.Controls.Add(this.label4);
            this.gbChonSP.Controls.Add(this.tbTenSP);
            this.gbChonSP.Controls.Add(this.btTimKiem);
            this.gbChonSP.Controls.Add(this.tbTimKiem);
            this.gbChonSP.Controls.Add(this.dgvChonSP);
            this.gbChonSP.Controls.Add(this.tbGiaSP);
            this.gbChonSP.Controls.Add(this.label12);
            this.gbChonSP.Controls.Add(this.label16);
            this.gbChonSP.Controls.Add(this.tbSoLuongTonKho);
            this.gbChonSP.Controls.Add(this.btnThemSP);
            this.gbChonSP.Controls.Add(this.label10);
            this.gbChonSP.Controls.Add(this.cbTenLoai);
            this.gbChonSP.Controls.Add(this.label9);
            this.gbChonSP.Controls.Add(this.nuSoLuong);
            this.gbChonSP.Controls.Add(this.label5);
            this.gbChonSP.Controls.Add(this.label1);
            this.gbChonSP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbChonSP.Location = new System.Drawing.Point(503, 2);
            this.gbChonSP.Name = "gbChonSP";
            this.gbChonSP.Size = new System.Drawing.Size(876, 451);
            this.gbChonSP.TabIndex = 31;
            this.gbChonSP.TabStop = false;
            this.gbChonSP.Text = "Chọn sản phẩm";
            // 
            // tbMaSP
            // 
            this.tbMaSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMaSP.Enabled = false;
            this.tbMaSP.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMaSP.Location = new System.Drawing.Point(123, 38);
            this.tbMaSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbMaSP.Name = "tbMaSP";
            this.tbMaSP.Size = new System.Drawing.Size(304, 45);
            this.tbMaSP.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 32);
            this.label4.TabIndex = 35;
            this.label4.Text = "Mã SP";
            // 
            // tbTenSP
            // 
            this.tbTenSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTenSP.Enabled = false;
            this.tbTenSP.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTenSP.Location = new System.Drawing.Point(557, 38);
            this.tbTenSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTenSP.Name = "tbTenSP";
            this.tbTenSP.Size = new System.Drawing.Size(300, 45);
            this.tbTenSP.TabIndex = 32;
            // 
            // btTimKiem
            // 
            this.btTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.btTimKiem.FlatAppearance.BorderSize = 0;
            this.btTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTimKiem.ForeColor = System.Drawing.Color.White;
            this.btTimKiem.Image = ((System.Drawing.Image)(resources.GetObject("btTimKiem.Image")));
            this.btTimKiem.Location = new System.Drawing.Point(780, 202);
            this.btTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btTimKiem.Name = "btTimKiem";
            this.btTimKiem.Size = new System.Drawing.Size(80, 47);
            this.btTimKiem.TabIndex = 34;
            this.btTimKiem.UseVisualStyleBackColor = false;
            this.btTimKiem.Click += new System.EventHandler(this.btTimKiem_Click);
            // 
            // tbTimKiem
            // 
            this.tbTimKiem.AccessibleDescription = "";
            this.tbTimKiem.AccessibleName = "";
            this.tbTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTimKiem.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTimKiem.Location = new System.Drawing.Point(440, 203);
            this.tbTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTimKiem.Name = "tbTimKiem";
            this.tbTimKiem.Size = new System.Drawing.Size(334, 45);
            this.tbTimKiem.TabIndex = 33;
            this.tbTimKiem.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 247);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(244, 32);
            this.label1.TabIndex = 32;
            this.label1.Text = "Nhấn vào để chọn SP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbThongTin
            // 
            this.gbThongTin.Controls.Add(this.label13);
            this.gbThongTin.Controls.Add(this.label17);
            this.gbThongTin.Controls.Add(this.tbMaHoaDon);
            this.gbThongTin.Controls.Add(this.tbTenKH);
            this.gbThongTin.Controls.Add(this.tbDiaChiKH);
            this.gbThongTin.Controls.Add(this.tbTongTien);
            this.gbThongTin.Controls.Add(this.tbSoDienThoaiKH);
            this.gbThongTin.Controls.Add(this.label2);
            this.gbThongTin.Controls.Add(this.label3);
            this.gbThongTin.Controls.Add(this.label6);
            this.gbThongTin.Controls.Add(this.label11);
            this.gbThongTin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbThongTin.Location = new System.Drawing.Point(12, 2);
            this.gbThongTin.Name = "gbThongTin";
            this.gbThongTin.Size = new System.Drawing.Size(485, 451);
            this.gbThongTin.TabIndex = 32;
            this.gbThongTin.TabStop = false;
            this.gbThongTin.Text = "Thông tin Hóa đơn";
            // 
            // gbDSSP
            // 
            this.gbDSSP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDSSP.Controls.Add(this.label15);
            this.gbDSSP.Controls.Add(this.dgvSanPham);
            this.gbDSSP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDSSP.Location = new System.Drawing.Point(15, 459);
            this.gbDSSP.Name = "gbDSSP";
            this.gbDSSP.Size = new System.Drawing.Size(1364, 333);
            this.gbDSSP.TabIndex = 34;
            this.gbDSSP.TabStop = false;
            this.gbDSSP.Text = "Sản phẩm đã chọn";
            // 
            // Frm_thanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1409, 889);
            this.Controls.Add(this.gbDSSP);
            this.Controls.Add(this.gbThongTin);
            this.Controls.Add(this.gbChonSP);
            this.Controls.Add(flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Frm_thanhToan";
            this.Text = "Thanh toán";
            this.Load += new System.EventHandler(this.Frm_thanhToan_Load);
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChonSP)).EndInit();
            this.gbChonSP.ResumeLayout(false);
            this.gbChonSP.PerformLayout();
            this.gbThongTin.ResumeLayout(false);
            this.gbThongTin.PerformLayout();
            this.gbDSSP.ResumeLayout(false);
            this.gbDSSP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbTenKH;
        private System.Windows.Forms.TextBox tbSoDienThoaiKH;
        private System.Windows.Forms.TextBox tbDiaChiKH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.Button btnTaoDonHang;
        private System.Windows.Forms.Button btnThemSP;
        private System.Windows.Forms.Button btnInHoaDon;
        private System.Windows.Forms.ComboBox cbTenLoai;
        private System.Windows.Forms.NumericUpDown nuSoLuong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbSoLuongTonKho;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbGiaSP;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbTongTien;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn giaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn soLuongMua;
        private System.Windows.Forms.DataGridViewTextBoxColumn thanhTien;
        private System.Windows.Forms.TextBox tbMaHoaDon;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvChonSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChonMaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChonTenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChonGiaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChonSoLuongTonKho;
        private System.Windows.Forms.GroupBox gbChonSP;
        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.GroupBox gbDSSP;
        private System.Windows.Forms.TextBox tbTimKiem;
        private System.Windows.Forms.Button btTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTenSP;
        private System.Windows.Forms.TextBox tbMaSP;
        private System.Windows.Forms.Label label4;
    }
}