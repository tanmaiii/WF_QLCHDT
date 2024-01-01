using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_QLCHDT
{
    public partial class Frm_thanhToan : Form
    {

        KetNoiMySql ketNoi = new KetNoiMySql();
        DataTable bangDuLieu = new DataTable();
        int donghh;
        string maHoaDon;


        public Frm_thanhToan()
        {
            InitializeComponent();
        }

        void HienThiLoaiSanPham()
        {
            string mysql = "SELECT * FROM loai";
            DataTable loaiDuLieu = ketNoi.ThucHienTruyVan(mysql);
            if(loaiDuLieu.Rows.Count > 0)
            {
                cbTenLoai.Enabled = true;
                cbTenLoai.DataSource = loaiDuLieu;
                cbTenLoai.DisplayMember = "TenLoai";
                cbTenLoai.ValueMember = "MaLoai";
            }
            else
            {
                MessageBox.Show("Chưa có loại sản phẩm nào ! Vui lòng tạo loại sản phẩm !");
                cbTenLoai.DataSource = null;
                cbTenLoai.Enabled = false;
            }
        }

        void HienThiBangChonSanPham(string maLoai)
        {
            string mysql = $"SELECT MaSP as ChonMaSP, TenSP as ChonTenSP, GiaSP as ChonGiaSP, SoLuongTonKho as ChonSoLuongTonKho  FROM sanpham WHERE MaLoai = '{maLoai}'";

            DataTable loaiDuLieu = ketNoi.ThucHienTruyVan(mysql);
            if (loaiDuLieu.Rows.Count > 0)
            {
                dgvChonSP.DataSource = loaiDuLieu;
                dgvChonSP.Columns["ChonGiaSP"].DefaultCellStyle.Format = "N0";
                dgvChonSP.Columns[0].Width = 100;
                dgvChonSP.Columns[3].Width = 100;
                dgvChonSP.Enabled = true;
                dgvChonSP.ClearSelection();
            }
            else
            {
                // dgvChonSP.DataSource = null;
                 dgvChonSP.DataSource = loaiDuLieu;
                dgvChonSP.Enabled = false;
            }
        }

        //XỬ LÝ MUA

        //Tạo mã KH nếu chưa tồn tại
        private string TaoMaKhachHang()
        {
            // Nếu khách hàng chưa tồn tại, tạo mới mã khách hàng
            //Random random = new Random();
            //return "KH" + random.Next(1000, 9999).ToString();

            //Tạo mã theo datetime để tránh trùng mã 
            long ticks = DateTime.Now.Ticks;
            // Chuyển ticks thành chuỗi hex để tạo mã
            string uniqueCode = ticks.ToString("X");
            return "KH" + uniqueCode;
        }


        // Tạo mã hóa đơn
        private string TaoMaHoaDon()
        {
            /*  // Tạo mới mã hóa đơn
              Random random = new Random();
              return "HD" + random.Next(1000, 9999).ToString();*/

            //Tạo mã theo datetime để tránh trùng mã 
            long ticks = DateTime.Now.Ticks;
            // Chuyển ticks thành chuỗi hex để tạo mã
            string uniqueCode = ticks.ToString("X");
            return "HD" + uniqueCode;
        }


        private void refresh ()
        {
            tbMaHoaDon.Clear();
            tbTenKH.Clear();
            tbDiaChiKH.Clear();
            tbSoDienThoaiKH.Clear();
            tbTimKiem.Clear();
            tbMaSP.Clear();
            tbTenSP.Clear();

            if (cbTenLoai.Items.Count > 0)
            { 
                cbTenLoai.SelectedIndex = 0; // Chọn mặc định hoặc có thể là một giá trị khác tùy thuộc vào yêu cầu
  
                HienThiBangChonSanPham(cbTenLoai.SelectedValue.ToString());
            }

            tbSoLuongTonKho.Clear();
            tbGiaSP.Clear();

            // Làm cho DataGridView mất focus để không còn dòng nào được chọn
            dgvSanPham.ClearSelection();
            dgvChonSP.ClearSelection();

            nuSoLuong.Value = 1;
            HienThiLoaiSanPham();

            gbChonSP.Enabled = true;
            gbThongTin.Enabled = true;
            gbDSSP.Enabled = true;
            btnTaoDonHang.Enabled = true;

        }
        private void Frm_thanhToan_Load(object sender, EventArgs e)
        {

            nuSoLuong.Value = 1;
            HienThiLoaiSanPham();

            if (cbTenLoai.Items.Count > 0) 
            {
                //HienThiSanPhamTheoLoai(cbTenLoai.SelectedValue.ToString());
                //MOI
                HienThiBangChonSanPham(cbTenLoai.SelectedValue.ToString());
            } 
        }

        //Chọn loại sản phẩm
        private void cbTenLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy loại đã chọn (MaLoai)
            string selectedMaLoai = cbTenLoai.SelectedValue.ToString();

            // Điền ComboBox "Sản phẩm" dựa trên loại đã chọn
            HienThiBangChonSanPham(selectedMaLoai);
        }


        //XỬ LÍ KHÁCH HÀNG//
        private void ThemKhachHang()
        {
            // Lấy thông tin từ các TextBox
            string tenKH = tbTenKH.Text;
            string diaChiKH = tbDiaChiKH.Text;
            string soDienThoaiKH = tbSoDienThoaiKH.Text;
            string maKhachHang;

            // Kiểm tra xem có bất kỳ ô TextBox nào trống rỗng hay không
            if (string.IsNullOrEmpty(tenKH) || string.IsNullOrEmpty(diaChiKH) || string.IsNullOrEmpty(soDienThoaiKH))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Kiểm tra mã KH có chưa
            string mysqlCheck = $"SELECT MaKH, TenKH, DiaChiKH, SoDienThoaiKH FROM khachhang WHERE SoDienThoaiKH = '{soDienThoaiKH}'";
            DataTable khachHangCheck = ketNoi.ThucHienTruyVan(mysqlCheck);

            if (khachHangCheck.Rows.Count > 0)
            {
                // Nếu khách hàng đã tồn tại, trả về mã khách hàng hiện tại
                maKhachHang = khachHangCheck.Rows[0]["MaKH"].ToString();

                string thongbao = $"Số điện thoại đã tồn tại. Sử dụng thông tin bên dưới ?" +
                                  $"\n-Mã KH: {khachHangCheck.Rows[0]["MaKH"].ToString()} " +
                                  $"\n-Tên: {khachHangCheck.Rows[0]["TenKH"].ToString()} " +
                                  $"\n-Địa chỉ: {khachHangCheck.Rows[0]["DiaChiKH"].ToString()} " +
                                  $"\n-Số điện thoại: {khachHangCheck.Rows[0]["SoDienThoaiKH"].ToString()} ";

                DialogResult result = MessageBox.Show(thongbao, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if(result == DialogResult.Yes)
                {
                    tbTenKH.Text = khachHangCheck.Rows[0]["TenKH"].ToString();  
                    tbDiaChiKH.Text = khachHangCheck.Rows[0]["DiaChiKH"].ToString();  
                    tbSoDienThoaiKH.Text = khachHangCheck.Rows[0]["SoDienThoaiKH"].ToString();

                    ThemHoaDon(maKhachHang);
                }
            }
            else
            {   // Nếu khách hàng chưa tồn tại, tạo mã và insert
                maKhachHang = TaoMaKhachHang();
                try
                {
                    // Thực hiện câu lệnh SQL INSERT
                    string mysql = $"INSERT INTO khachhang (MaKH, TenKH, DiaChiKH, SoDienThoaiKH) VALUES ('{maKhachHang}', '{tenKH}', '{diaChiKH}', '{soDienThoaiKH}')";
                    ketNoi.ThucHienLenh(mysql);

                    MessageBox.Show("Thông tin khách hàng đã được lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ThemHoaDon(maKhachHang);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

       
        //THÊM SẢN PHẨM VÀO BẢNG DATAGRIDVIEW ở trang thanh toán//
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (tbTenSP.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sản phẩm khác. Hoặc làm mới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Thoát khỏi hàm nếu không có sản phẩm được chọn
            }

            // Lấy thông tin từ ComboBox và NumericUpDown
            string tenLoai = cbTenLoai.Text;
            string maSanPham = tbMaSP.Text.ToString();
            string tenSanPham = tbTenSP.Text.ToString();
            string giaSanPham = tbGiaSP.Text.ToString();
            string soLuongTonKho = tbSoLuongTonKho.Text;
            int soLuongMua = (int)nuSoLuong.Value;

            // Kiểm tra xem sản phẩm đã tồn tại trong DataGridView chưa
            bool daTonTai = false;

            // Kiểm tra xem số lượng mua có vượt quá số lượng tồn không
            if (soLuongMua > Convert.ToInt32(soLuongTonKho))
            {
                MessageBox.Show("Số lượng mua vượt quá số lượng tồn kho.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataGridViewRow row in dgvSanPham.Rows)
            {
                if (row.Cells["MaSP"].Value != null && row.Cells["MaSP"].Value.ToString() == maSanPham)
                {
                    row.Cells["soLuongMua"].Value = soLuongMua;
                    UpdateThanhTien(row);

                    daTonTai = true;
                    break;
                }
            }

            // Nếu sản phẩm chưa tồn tại, thêm hàng mới
            if (!daTonTai)
            {
                int thanhTien = soLuongMua * Convert.ToInt32(giaSanPham);
                string stringThanhTien = thanhTien.ToString("N0");
                dgvSanPham.Rows.Add(maSanPham, tenSanPham, giaSanPham, tenLoai,  soLuongMua, stringThanhTien);
            }
            CapNhatTongTien();
        }

        // Hàm cập nhật giá trị cột mới thành tiền
        private void UpdateThanhTien(DataGridViewRow row)
        {
            int soLuongMua = Convert.ToInt32(row.Cells["soLuongMua"].Value);
            int giaSanPham = Convert.ToInt32(row.Cells["GiaSP"].Value);
            int thanhTien = soLuongMua * giaSanPham;
            row.Cells["ThanhTien"].Value = thanhTien.ToString("N0");

            CapNhatTongTien();
        }

        // Hàm cập nhật tổng tiền
        private void CapNhatTongTien()
        {
            int tongTien = 0;

            foreach (DataGridViewRow row in dgvSanPham.Rows)
            {
                if (row.Cells["ThanhTien"].Value != null)
                {
                    tongTien += int.Parse(row.Cells["ThanhTien"].Value.ToString().Replace(",", ""));
                }
            }

            // Hiển thị tổng tiền trong TextBox
            tbTongTien.Text = tongTien.ToString("N0");
        }

        //HOA DON//
        private void ThemHoaDon(string maKhachHang)
        {
            try
            {
                // Lấy thông tin từ các control
                string MaNV = Const.TaiKhoan.MaNV; ;
                DateTime ngayLapHD = DateTime.Now;
                int TongTien = int.Parse(tbTongTien.Text.ToString().Replace(",", "")); 
                // Tạo mã hóa đơn
                maHoaDon = TaoMaHoaDon();

                // Thực hiện câu lệnh SQL INSERT
                string mysql = $"INSERT INTO hoadon (MaHD, MaKH, MaNV, NgayLapHD, TongTien) VALUES ('{maHoaDon}', '{maKhachHang}', '{MaNV}', '{ngayLapHD.ToString("yyyy-MM-dd HH:mm:ss")}', '{TongTien}')";

                ketNoi.ThucHienLenh(mysql);

                ThemChiTietHoadon(maHoaDon);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }



        //CHI TIẾT HOÁ ĐƠN
        private void ThemChiTietHoadon(string maHoaDon)
        {
            try
            {
                foreach (DataGridViewRow row in dgvSanPham.Rows)
                {
                    // Lấy thông tin từ các cột trong DataGridView
                    string maSanPham = row.Cells["maSP"].Value.ToString();
                    string thanhTien = row.Cells["thanhTien"].Value.ToString().Replace(",", "");
                    int soLuongMua = Convert.ToInt32(row.Cells["soLuongMua"].Value);

                    // Thực hiện câu lệnh SQL INSERT vào bảng hoadonchitiet
                    string mysqlChiTiet = $"INSERT INTO chitiethoadon (MaSP, MaHD, SoLuongMua,ThanhTien) VALUES ('{maSanPham}', '{maHoaDon}', '{soLuongMua}', '{thanhTien}')";

                    ketNoi.ThucHienLenh(mysqlChiTiet);

                    // Cập nhật số lượng tồn kho trong bảng sanpham
                    CapNhatSoLuongTonKho(maSanPham, soLuongMua);
                }

                MessageBox.Show("Thêm chi tiết hóa đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Cập nhật số lượng tồn kho 
        private void CapNhatSoLuongTonKho(string maSanPham, int soLuongMua)
        {
            try
            {
                // Lấy thông tin số lượng tồn kho hiện tại
                string sqlSelect = $"SELECT SoLuongTonKho FROM sanpham WHERE MaSP = '{maSanPham}'";
                DataTable dt = ketNoi.ThucHienTruyVan(sqlSelect);

                if (dt.Rows.Count > 0)
                {
                    int soLuongHienTai = Convert.ToInt32(dt.Rows[0]["SoLuongTonKho"]);
                    int soLuongMoi = soLuongHienTai - soLuongMua;

                    // Cập nhật số lượng tồn kho trong bảng sanpham
                    string sqlUpdate = $"UPDATE sanpham SET SoLuongTonKho = {soLuongMoi} WHERE MaSP = '{maSanPham}'";
                    ketNoi.ThucHienLenh(sqlUpdate);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật số lượng tồn kho: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //TẠO ĐƠN HÀNG//
        private void btnTaoDonHang_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Hãy chọn sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DialogResult result =  MessageBox.Show("Bạn có chắc chắn muốn lưu đơn hàng không ? Khi lưu không thể chỉnh sửa hóa đơn !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    ThemKhachHang();
                    if (!string.IsNullOrEmpty(maHoaDon))
                    {
                        tbMaHoaDon.Text = maHoaDon.ToString();
                        btnInHoaDon.Visible = true;
                        gbChonSP.Enabled = false;
                        gbThongTin.Enabled = false;
                        gbDSSP.Enabled = false;
                        btnTaoDonHang.Enabled = false;
                    }
                }
            }

        }

        //Xóa sản phẩm khỏi đơn hàng
        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int donghh = e.RowIndex;

            if(donghh >= 0)
            {
                dgvSanPham.Rows.RemoveAt(donghh);
            }
        }

        //Chỉ cho nhập số
        private void tbSoDienThoaiKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // In hóa đơn
        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            Print.Frm_inChiTietHoaDon frmPrint = new Print.Frm_inChiTietHoaDon();
            frmPrint.MaHD = maHoaDon.ToString();
            frmPrint.ShowDialog();
        }

        // Làm mới
        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn làm mới đơn hàng không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                refresh();
                dgvSanPham.Rows.Clear();
            }
            else
            {
                return;
            }
        }

        private void dgvChonSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                nuSoLuong.Value = 1;
                tbMaSP.Text = dgvChonSP.Rows[e.RowIndex].Cells["ChonMaSP"].Value.ToString();
                tbTenSP.Text = dgvChonSP.Rows[e.RowIndex].Cells["ChonTenSP"].Value.ToString();
                tbSoLuongTonKho.Text = dgvChonSP.Rows[e.RowIndex].Cells["ChonSoLuongTonKho"].Value.ToString();
                tbGiaSP.Text = Convert.ToInt32(dgvChonSP.Rows[e.RowIndex].Cells["ChonGiaSP"].Value).ToString();
            }
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string mysql = $"SELECT MaSP as ChonMaSP, TenSP as ChonTenSP, GiaSP as ChonGiaSP, SoLuongTonKho as ChonSoLuongTonKho  FROM sanpham WHERE MaLoai = '{cbTenLoai.SelectedValue.ToString()}' " +
                           $" AND TenSP LIKE '%{tbTimKiem.Text.ToString()}%' ";

            DataTable loaiDuLieu = ketNoi.ThucHienTruyVan(mysql);
            if (loaiDuLieu.Rows.Count > 0)
            {
                dgvChonSP.DataSource = loaiDuLieu;
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm ");
                HienThiBangChonSanPham(cbTenLoai.SelectedValue.ToString());
            }
        }
    }
}
