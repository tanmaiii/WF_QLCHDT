﻿namespace WF_QLCHDT
{
    partial class Frm_nhapHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_nhapHang));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnTaoDonHang = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnInHoaDon = new System.Windows.Forms.Button();
            this.tbGiaSP = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnThemSP = new System.Windows.Forms.Button();
            this.pnDSSP = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.tbTongTien = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbNhaCC = new System.Windows.Forms.ComboBox();
            this.pnTTSP = new System.Windows.Forms.Panel();
            this.cbLoaiSP = new System.Windows.Forms.ComboBox();
            this.nuSoLuong = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.tbSoLuongTon = new System.Windows.Forms.TextBox();
            this.cbTenSP = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanel1.SuspendLayout();
            this.pnDSSP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.pnTTSP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            flowLayoutPanel1.Controls.Add(this.btnTaoDonHang);
            flowLayoutPanel1.Controls.Add(this.btnReset);
            flowLayoutPanel1.Controls.Add(this.btnInHoaDon);
            flowLayoutPanel1.Location = new System.Drawing.Point(5, 811);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(1382, 69);
            flowLayoutPanel1.TabIndex = 33;
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
            this.btnInHoaDon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
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
            // tbGiaSP
            // 
            this.tbGiaSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbGiaSP.Enabled = false;
            this.tbGiaSP.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGiaSP.Location = new System.Drawing.Point(453, 87);
            this.tbGiaSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbGiaSP.Name = "tbGiaSP";
            this.tbGiaSP.Size = new System.Drawing.Size(380, 45);
            this.tbGiaSP.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(14, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(162, 38);
            this.label11.TabIndex = 25;
            this.label11.Text = "Nhập hàng";
            // 
            // btnThemSP
            // 
            this.btnThemSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.btnThemSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemSP.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemSP.ForeColor = System.Drawing.Color.White;
            this.btnThemSP.Image = ((System.Drawing.Image)(resources.GetObject("btnThemSP.Image")));
            this.btnThemSP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemSP.Location = new System.Drawing.Point(453, 257);
            this.btnThemSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemSP.Name = "btnThemSP";
            this.btnThemSP.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnThemSP.Size = new System.Drawing.Size(380, 58);
            this.btnThemSP.TabIndex = 4;
            this.btnThemSP.Text = "Thêm";
            this.btnThemSP.UseVisualStyleBackColor = false;
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click);
            // 
            // pnDSSP
            // 
            this.pnDSSP.AccessibleDescription = "";
            this.pnDSSP.AccessibleName = "";
            this.pnDSSP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnDSSP.BackColor = System.Drawing.Color.White;
            this.pnDSSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnDSSP.Controls.Add(this.label9);
            this.pnDSSP.Controls.Add(this.tbTongTien);
            this.pnDSSP.Controls.Add(this.label6);
            this.pnDSSP.Controls.Add(this.label15);
            this.pnDSSP.Controls.Add(this.label10);
            this.pnDSSP.Controls.Add(this.dgvSanPham);
            this.pnDSSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnDSSP.Location = new System.Drawing.Point(5, 350);
            this.pnDSSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnDSSP.Name = "pnDSSP";
            this.pnDSSP.Size = new System.Drawing.Size(1382, 456);
            this.pnDSSP.TabIndex = 32;
            this.pnDSSP.Tag = "";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1302, 406);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 38);
            this.label9.TabIndex = 47;
            this.label9.Text = "VND";
            // 
            // tbTongTien
            // 
            this.tbTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTongTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTongTien.Enabled = false;
            this.tbTongTien.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTongTien.Location = new System.Drawing.Point(1090, 403);
            this.tbTongTien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTongTien.Name = "tbTongTien";
            this.tbTongTien.Size = new System.Drawing.Size(210, 45);
            this.tbTongTien.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(935, 406);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 38);
            this.label6.TabIndex = 42;
            this.label6.Text = "Tổng tiền :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(523, 6);
            this.label15.Name = "label15";
            this.label15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label15.Size = new System.Drawing.Size(376, 32);
            this.label15.TabIndex = 34;
            this.label15.Text = "( Nháp đúp vào sản phẩm để xóa)";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(503, 38);
            this.label10.TabIndex = 24;
            this.label10.Text = "Danh sách sản phẩm trong đơn hàng";
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AllowUserToAddRows = false;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSanPham.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPham.BackgroundColor = System.Drawing.Color.White;
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSP,
            this.TenSP,
            this.GiaSP,
            this.SoLuong,
            this.ThanhTien});
            this.dgvSanPham.Location = new System.Drawing.Point(16, 54);
            this.dgvSanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.RowHeadersVisible = false;
            this.dgvSanPham.RowHeadersWidth = 62;
            this.dgvSanPham.RowTemplate.Height = 28;
            this.dgvSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSanPham.Size = new System.Drawing.Size(1356, 346);
            this.dgvSanPham.TabIndex = 0;
            this.dgvSanPham.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_CellDoubleClick);
            // 
            // MaSP
            // 
            this.MaSP.DataPropertyName = "MaSP";
            this.MaSP.HeaderText = "Mã SP";
            this.MaSP.MinimumWidth = 6;
            this.MaSP.Name = "MaSP";
            this.MaSP.ReadOnly = true;
            // 
            // TenSP
            // 
            this.TenSP.DataPropertyName = "TenSP";
            this.TenSP.HeaderText = "Tên SP";
            this.TenSP.MinimumWidth = 6;
            this.TenSP.Name = "TenSP";
            this.TenSP.ReadOnly = true;
            // 
            // GiaSP
            // 
            this.GiaSP.DataPropertyName = "GiaSP";
            this.GiaSP.HeaderText = "Giá";
            this.GiaSP.MinimumWidth = 6;
            this.GiaSP.Name = "GiaSP";
            this.GiaSP.ReadOnly = true;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "SL nhập";
            this.SoLuong.MinimumWidth = 8;
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            // 
            // ThanhTien
            // 
            this.ThanhTien.DataPropertyName = "ThanhTien";
            this.ThanhTien.HeaderText = "Thành tiền";
            this.ThanhTien.MinimumWidth = 8;
            this.ThanhTien.Name = "ThanhTien";
            this.ThanhTien.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 38);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên SP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(446, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 38);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhà cung cấp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(451, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 38);
            this.label1.TabIndex = 26;
            this.label1.Text = "Giá sản phẩm";
            // 
            // cbNhaCC
            // 
            this.cbNhaCC.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNhaCC.FormattingEnabled = true;
            this.cbNhaCC.Location = new System.Drawing.Point(453, 174);
            this.cbNhaCC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbNhaCC.Name = "cbNhaCC";
            this.cbNhaCC.Size = new System.Drawing.Size(380, 46);
            this.cbNhaCC.TabIndex = 19;
            // 
            // pnTTSP
            // 
            this.pnTTSP.AccessibleDescription = "";
            this.pnTTSP.AccessibleName = "";
            this.pnTTSP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnTTSP.BackColor = System.Drawing.Color.White;
            this.pnTTSP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnTTSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnTTSP.Controls.Add(this.cbLoaiSP);
            this.pnTTSP.Controls.Add(this.nuSoLuong);
            this.pnTTSP.Controls.Add(this.label7);
            this.pnTTSP.Controls.Add(this.tbSoLuongTon);
            this.pnTTSP.Controls.Add(this.cbTenSP);
            this.pnTTSP.Controls.Add(this.tbGiaSP);
            this.pnTTSP.Controls.Add(this.label11);
            this.pnTTSP.Controls.Add(this.btnThemSP);
            this.pnTTSP.Controls.Add(this.cbNhaCC);
            this.pnTTSP.Controls.Add(this.label3);
            this.pnTTSP.Controls.Add(this.label2);
            this.pnTTSP.Controls.Add(this.label1);
            this.pnTTSP.Controls.Add(this.label8);
            this.pnTTSP.Controls.Add(this.label5);
            this.pnTTSP.Location = new System.Drawing.Point(6, 11);
            this.pnTTSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnTTSP.Name = "pnTTSP";
            this.pnTTSP.Size = new System.Drawing.Size(1382, 335);
            this.pnTTSP.TabIndex = 31;
            this.pnTTSP.Tag = "";
            // 
            // cbLoaiSP
            // 
            this.cbLoaiSP.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLoaiSP.FormattingEnabled = true;
            this.cbLoaiSP.Location = new System.Drawing.Point(21, 86);
            this.cbLoaiSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbLoaiSP.Name = "cbLoaiSP";
            this.cbLoaiSP.Size = new System.Drawing.Size(380, 46);
            this.cbLoaiSP.TabIndex = 46;
            this.cbLoaiSP.SelectedIndexChanged += new System.EventHandler(this.cbLoaiSP_SelectedIndexChanged);
            // 
            // nuSoLuong
            // 
            this.nuSoLuong.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuSoLuong.Location = new System.Drawing.Point(21, 270);
            this.nuSoLuong.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nuSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuSoLuong.Name = "nuSoLuong";
            this.nuSoLuong.Size = new System.Drawing.Size(380, 45);
            this.nuSoLuong.TabIndex = 43;
            this.nuSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(270, 38);
            this.label7.TabIndex = 42;
            this.label7.Text = "Số lượng nhập thêm";
            // 
            // tbSoLuongTon
            // 
            this.tbSoLuongTon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSoLuongTon.Enabled = false;
            this.tbSoLuongTon.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSoLuongTon.Location = new System.Drawing.Point(877, 86);
            this.tbSoLuongTon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSoLuongTon.Name = "tbSoLuongTon";
            this.tbSoLuongTon.Size = new System.Drawing.Size(380, 45);
            this.tbSoLuongTon.TabIndex = 41;
            // 
            // cbTenSP
            // 
            this.cbTenSP.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTenSP.FormattingEnabled = true;
            this.cbTenSP.Location = new System.Drawing.Point(21, 174);
            this.cbTenSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbTenSP.Name = "cbTenSP";
            this.cbTenSP.Size = new System.Drawing.Size(380, 46);
            this.cbTenSP.TabIndex = 39;
            this.cbTenSP.SelectedIndexChanged += new System.EventHandler(this.cbTenSP_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 38);
            this.label8.TabIndex = 44;
            this.label8.Text = "Loại SP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(875, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(231, 38);
            this.label5.TabIndex = 40;
            this.label5.Text = "Số lượng tồn kho";
            // 
            // Frm_nhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 888);
            this.Controls.Add(flowLayoutPanel1);
            this.Controls.Add(this.pnDSSP);
            this.Controls.Add(this.pnTTSP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_nhapHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập hàng";
            this.Load += new System.EventHandler(this.Frm_nhapHang_Load);
            flowLayoutPanel1.ResumeLayout(false);
            this.pnDSSP.ResumeLayout(false);
            this.pnDSSP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.pnTTSP.ResumeLayout(false);
            this.pnTTSP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuSoLuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox tbGiaSP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnThemSP;
        private System.Windows.Forms.Panel pnDSSP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbNhaCC;
        private System.Windows.Forms.Panel pnTTSP;
        private System.Windows.Forms.Button btnTaoDonHang;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnInHoaDon;
        private System.Windows.Forms.ComboBox cbTenSP;
        private System.Windows.Forms.TextBox tbSoLuongTon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbTongTien;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nuSoLuong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbLoaiSP;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
    }
}