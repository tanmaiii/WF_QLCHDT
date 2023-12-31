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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnTaoDonHang = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnInHoaDon = new System.Windows.Forms.Button();
            this.tbTenKH = new System.Windows.Forms.TextBox();
            this.tbSoDienThoaiKH = new System.Windows.Forms.TextBox();
            this.tbDiaChiKH = new System.Windows.Forms.TextBox();
            this.pnTTHoaDon = new System.Windows.Forms.Panel();
            this.tbMaHoaDon = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnDsSP = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbTongTien = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soLuongMua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnChonSP = new System.Windows.Forms.Panel();
            this.tbGiaSP = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbSoLuongTonKho = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nuSoLuong = new System.Windows.Forms.NumericUpDown();
            this.cbTenLoai = new System.Windows.Forms.ComboBox();
            this.btnThemSP = new System.Windows.Forms.Button();
            this.cbTenSP = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanel1.SuspendLayout();
            this.pnTTHoaDon.SuspendLayout();
            this.pnDsSP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.pnChonSP.SuspendLayout();
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
            this.tbTenKH.Location = new System.Drawing.Point(487, 83);
            this.tbTenKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTenKH.Name = "tbTenKH";
            this.tbTenKH.Size = new System.Drawing.Size(352, 45);
            this.tbTenKH.TabIndex = 22;
            // 
            // tbSoDienThoaiKH
            // 
            this.tbSoDienThoaiKH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSoDienThoaiKH.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSoDienThoaiKH.Location = new System.Drawing.Point(23, 177);
            this.tbSoDienThoaiKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSoDienThoaiKH.Name = "tbSoDienThoaiKH";
            this.tbSoDienThoaiKH.Size = new System.Drawing.Size(361, 45);
            this.tbSoDienThoaiKH.TabIndex = 21;
            this.tbSoDienThoaiKH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSoDienThoaiKH_KeyPress);
            // 
            // tbDiaChiKH
            // 
            this.tbDiaChiKH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDiaChiKH.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDiaChiKH.Location = new System.Drawing.Point(488, 177);
            this.tbDiaChiKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbDiaChiKH.Name = "tbDiaChiKH";
            this.tbDiaChiKH.Size = new System.Drawing.Size(352, 45);
            this.tbDiaChiKH.TabIndex = 19;
            // 
            // pnTTHoaDon
            // 
            this.pnTTHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnTTHoaDon.BackColor = System.Drawing.Color.White;
            this.pnTTHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnTTHoaDon.Controls.Add(this.tbMaHoaDon);
            this.pnTTHoaDon.Controls.Add(this.label17);
            this.pnTTHoaDon.Controls.Add(this.label7);
            this.pnTTHoaDon.Controls.Add(this.tbTenKH);
            this.pnTTHoaDon.Controls.Add(this.tbSoDienThoaiKH);
            this.pnTTHoaDon.Controls.Add(this.tbDiaChiKH);
            this.pnTTHoaDon.Controls.Add(this.label6);
            this.pnTTHoaDon.Controls.Add(this.label3);
            this.pnTTHoaDon.Controls.Add(this.label2);
            this.pnTTHoaDon.Location = new System.Drawing.Point(12, 12);
            this.pnTTHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnTTHoaDon.Name = "pnTTHoaDon";
            this.pnTTHoaDon.Size = new System.Drawing.Size(1367, 246);
            this.pnTTHoaDon.TabIndex = 4;
            // 
            // tbMaHoaDon
            // 
            this.tbMaHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMaHoaDon.Enabled = false;
            this.tbMaHoaDon.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMaHoaDon.Location = new System.Drawing.Point(22, 83);
            this.tbMaHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbMaHoaDon.Name = "tbMaHoaDon";
            this.tbMaHoaDon.Size = new System.Drawing.Size(352, 45);
            this.tbMaHoaDon.TabIndex = 31;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(16, 40);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(183, 38);
            this.label17.TabIndex = 30;
            this.label17.Text = "Mã đơn hàng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(267, 38);
            this.label7.TabIndex = 23;
            this.label7.Text = "Thông tin Hóa đơn";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(482, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 38);
            this.label6.TabIndex = 9;
            this.label6.Text = "Địa chỉ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 38);
            this.label3.TabIndex = 3;
            this.label3.Text = "Số điện thoại";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(481, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 38);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên khách hàng ";
            // 
            // pnDsSP
            // 
            this.pnDsSP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnDsSP.BackColor = System.Drawing.Color.White;
            this.pnDsSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnDsSP.Controls.Add(this.label15);
            this.pnDsSP.Controls.Add(this.label13);
            this.pnDsSP.Controls.Add(this.tbTongTien);
            this.pnDsSP.Controls.Add(this.label11);
            this.pnDsSP.Controls.Add(this.label4);
            this.pnDsSP.Controls.Add(this.dgvSanPham);
            this.pnDsSP.Location = new System.Drawing.Point(12, 438);
            this.pnDsSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnDsSP.Name = "pnDsSP";
            this.pnDsSP.Size = new System.Drawing.Size(1367, 352);
            this.pnDsSP.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(270, 14);
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
            this.label13.Location = new System.Drawing.Point(1266, 302);
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
            this.tbTongTien.Enabled = false;
            this.tbTongTien.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTongTien.Location = new System.Drawing.Point(1007, 299);
            this.tbTongTien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTongTien.Name = "tbTongTien";
            this.tbTongTien.Size = new System.Drawing.Size(253, 45);
            this.tbTongTien.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(866, 302);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label11.Size = new System.Drawing.Size(135, 38);
            this.label11.TabIndex = 28;
            this.label11.Text = "Tổng tiền";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(261, 38);
            this.label4.TabIndex = 29;
            this.label4.Text = "Sản phẩm đã chọn";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AllowUserToAddRows = false;
            this.dgvSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPham.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSP,
            this.tenSanPham,
            this.giaSP,
            this.TenLoai,
            this.soLuongMua,
            this.thanhTien});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSanPham.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSanPham.Location = new System.Drawing.Point(10, 62);
            this.dgvSanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.RowHeadersVisible = false;
            this.dgvSanPham.RowHeadersWidth = 62;
            this.dgvSanPham.RowTemplate.Height = 28;
            this.dgvSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSanPham.Size = new System.Drawing.Size(1352, 233);
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
            // pnChonSP
            // 
            this.pnChonSP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnChonSP.BackColor = System.Drawing.Color.White;
            this.pnChonSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnChonSP.Controls.Add(this.tbGiaSP);
            this.pnChonSP.Controls.Add(this.label12);
            this.pnChonSP.Controls.Add(this.tbSoLuongTonKho);
            this.pnChonSP.Controls.Add(this.label10);
            this.pnChonSP.Controls.Add(this.label9);
            this.pnChonSP.Controls.Add(this.label5);
            this.pnChonSP.Controls.Add(this.label1);
            this.pnChonSP.Controls.Add(this.nuSoLuong);
            this.pnChonSP.Controls.Add(this.cbTenLoai);
            this.pnChonSP.Controls.Add(this.btnThemSP);
            this.pnChonSP.Controls.Add(this.cbTenSP);
            this.pnChonSP.Controls.Add(this.label16);
            this.pnChonSP.ForeColor = System.Drawing.SystemColors.InfoText;
            this.pnChonSP.Location = new System.Drawing.Point(12, 265);
            this.pnChonSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnChonSP.Name = "pnChonSP";
            this.pnChonSP.Size = new System.Drawing.Size(1367, 168);
            this.pnChonSP.TabIndex = 6;
            // 
            // tbGiaSP
            // 
            this.tbGiaSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbGiaSP.Enabled = false;
            this.tbGiaSP.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGiaSP.Location = new System.Drawing.Point(637, 105);
            this.tbGiaSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbGiaSP.Name = "tbGiaSP";
            this.tbGiaSP.Size = new System.Drawing.Size(300, 45);
            this.tbGiaSP.TabIndex = 28;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(458, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 38);
            this.label12.TabIndex = 29;
            this.label12.Text = "Đơn giá";
            // 
            // tbSoLuongTonKho
            // 
            this.tbSoLuongTonKho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSoLuongTonKho.Enabled = false;
            this.tbSoLuongTonKho.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSoLuongTonKho.Location = new System.Drawing.Point(637, 45);
            this.tbSoLuongTonKho.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSoLuongTonKho.Name = "tbSoLuongTonKho";
            this.tbSoLuongTonKho.Size = new System.Drawing.Size(300, 45);
            this.tbSoLuongTonKho.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(458, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(177, 38);
            this.label10.TabIndex = 24;
            this.label10.Text = "Số lượng tồn";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 38);
            this.label9.TabIndex = 24;
            this.label9.Text = "Tên SP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 48);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(106, 38);
            this.label5.TabIndex = 24;
            this.label5.Text = "Loại SP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 38);
            this.label1.TabIndex = 24;
            this.label1.Text = "Chọn sản phẩm";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nuSoLuong
            // 
            this.nuSoLuong.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuSoLuong.Location = new System.Drawing.Point(1141, 45);
            this.nuSoLuong.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.nuSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuSoLuong.Name = "nuSoLuong";
            this.nuSoLuong.Size = new System.Drawing.Size(212, 45);
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
            this.cbTenLoai.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbTenLoai.Location = new System.Drawing.Point(130, 44);
            this.cbTenLoai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbTenLoai.Name = "cbTenLoai";
            this.cbTenLoai.Size = new System.Drawing.Size(300, 46);
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
            this.btnThemSP.Location = new System.Drawing.Point(1141, 101);
            this.btnThemSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemSP.Name = "btnThemSP";
            this.btnThemSP.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnThemSP.Size = new System.Drawing.Size(212, 55);
            this.btnThemSP.TabIndex = 6;
            this.btnThemSP.Text = "      Thêm SP";
            this.btnThemSP.UseVisualStyleBackColor = false;
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click);
            // 
            // cbTenSP
            // 
            this.cbTenSP.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTenSP.FormattingEnabled = true;
            this.cbTenSP.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbTenSP.Location = new System.Drawing.Point(130, 104);
            this.cbTenSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbTenSP.Name = "cbTenSP";
            this.cbTenSP.Size = new System.Drawing.Size(300, 46);
            this.cbTenSP.TabIndex = 24;
            this.cbTenSP.SelectedIndexChanged += new System.EventHandler(this.cbTenSP_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(950, 48);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(190, 38);
            this.label16.TabIndex = 30;
            this.label16.Text = "Số lượng mua";
            // 
            // Frm_thanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1409, 889);
            this.Controls.Add(flowLayoutPanel1);
            this.Controls.Add(this.pnChonSP);
            this.Controls.Add(this.pnTTHoaDon);
            this.Controls.Add(this.pnDsSP);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Frm_thanhToan";
            this.Text = "Thanh toán";
            this.Load += new System.EventHandler(this.Frm_thanhToan_Load);
            flowLayoutPanel1.ResumeLayout(false);
            this.pnTTHoaDon.ResumeLayout(false);
            this.pnTTHoaDon.PerformLayout();
            this.pnDsSP.ResumeLayout(false);
            this.pnDsSP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.pnChonSP.ResumeLayout(false);
            this.pnChonSP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuSoLuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbTenKH;
        private System.Windows.Forms.TextBox tbSoDienThoaiKH;
        private System.Windows.Forms.TextBox tbDiaChiKH;
        private System.Windows.Forms.Panel pnTTHoaDon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnDsSP;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.Panel pnChonSP;
        private System.Windows.Forms.ComboBox cbTenSP;
        private System.Windows.Forms.Button btnTaoDonHang;
        private System.Windows.Forms.Button btnThemSP;
        private System.Windows.Forms.Button btnInHoaDon;
        private System.Windows.Forms.ComboBox cbTenLoai;
        private System.Windows.Forms.NumericUpDown nuSoLuong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
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
    }
}