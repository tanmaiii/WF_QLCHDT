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

        public Frm_thanhToan()
        {
            InitializeComponent();
        }

        void HienThiNhanVien()
        {
            string mysql = "select * from nhanvien";
            DataTable nhanvien = ketNoi.ThucHienTruyVan(mysql);
            cbTenNV.DataSource = nhanvien;
            cbTenNV.DisplayMember = "TenNV";
            cbTenNV.ValueMember = "MaNV";
        }
        void HienThiLoaiSanPham()
        {
            string mysql = "SELECT * FROM loai";
            DataTable loaiDuLieu = ketNoi.ThucHienTruyVan(mysql);
            cbTenLoai.DataSource = loaiDuLieu;
            cbTenLoai.DisplayMember = "TenLoai";
            cbTenLoai.ValueMember = "MaLoai";
        }

        void HienThiSanPhamTheoLoai(string maLoai)
        {
            string mysql = $"SELECT * FROM sanpham WHERE MaLoai = '{maLoai}'";
            DataTable sanPhamDuLieu = ketNoi.ThucHienTruyVan(mysql);
            // Kiểm tra xem DataTable có hàng nào hay không
            if (sanPhamDuLieu.Rows.Count > 0)
            {
                cbTenSP.DataSource = sanPhamDuLieu;
                cbTenSP.DisplayMember = "TenSP";
                cbTenSP.ValueMember = "MaSP";
                cbTenSP.Enabled = true;  // Bật tình trạng sẵn sàng để chọn
            }
            else
            {
                // Nếu không có sản phẩm nào thuộc loại đã chọn, làm rỗng ComboBox "Sản phẩm"
                cbTenSP.DataSource = null;
                cbTenSP.Enabled = false;  // Tắt tình trạng sẵn sàng để chọn
            }
        }


        private void ClearInputs()
        {
            tbTenKH.Clear();
            tbDiaChiKH.Clear();
            tbSoDienThoaiKH.Clear();
            //dateTimePicker1.Clear();
            cbTenNV.SelectedIndex = 0; // Chọn mặc định hoặc có thể là một giá trị khác tùy thuộc vào yêu cầu

            cbTenLoai.SelectedIndex = 0; // Chọn mặc định hoặc có thể là một giá trị khác tùy thuộc vào yêu cầu
            cbTenSP.SelectedIndex = 0; // Chọn mặc định hoặc có thể là một giá trị khác tùy thuộc vào yêu cầu
            tbSoLuongTonKho.Clear();
            tbGiaSP.Clear();
            // Làm cho DataGridView mất focus để không còn dòng nào được chọn
            dgvSanPham.ClearSelection();
        }

        private void refresh ()
        {
            nuSoLuong.Value = 1;
            HienThiNhanVien();
            HienThiLoaiSanPham();
            HienThiSanPhamTheoLoai(cbTenLoai.SelectedValue.ToString());
            // Kết nối sự kiện SelectedIndexChanged của cbTenSP với phương thức cbTenSP_SelectedIndexChanged
            cbTenSP.SelectedIndexChanged += cbTenSP_SelectedIndexChanged;
           
        }
        private void Frm_thanhToan_Load(object sender, EventArgs e)
        {
            nuSoLuong.Value = 1;
            HienThiNhanVien();
            HienThiLoaiSanPham();
            HienThiSanPhamTheoLoai(cbTenLoai.SelectedValue.ToString());
            // Kết nối sự kiện SelectedIndexChanged của cbTenSP với phương thức cbTenSP_SelectedIndexChanged
            cbTenSP.SelectedIndexChanged += cbTenSP_SelectedIndexChanged;
            // Gọi hàm cbTenSP_SelectedIndexChanged để hiển thị thông tin cho sản phẩm đầu tiên
            cbTenSP_SelectedIndexChanged(sender, e);
        }

        //Chọn loại sản phẩm
        private void cbTenLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy loại đã chọn (MaLoai)
            string selectedMaLoai = cbTenLoai.SelectedValue.ToString();

            // Điền ComboBox "Sản phẩm" dựa trên loại đã chọn
            HienThiSanPhamTheoLoai(selectedMaLoai);
        }

        //Hien thị tên và giá sản phẩm
        private void cbTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có một giá trị đã chọn trong ComboBox hay không
            if (cbTenSP.SelectedValue != null)
            {
                // Lấy mã sản phẩm đã chọn (MaSP)
                string selectedMaSP = cbTenSP.SelectedValue.ToString();

                // Truy vấn để lấy sản phẩm dựa trên mã sản phẩm
                string mysql = $"SELECT * FROM sanpham WHERE MaSP = '{selectedMaSP}'";
                DataTable sanPhamChon = ketNoi.ThucHienTruyVan(mysql);

                // Kiểm tra xem DataTable có hàng nào hay không
                if (sanPhamChon.Rows.Count > 0)
                {
                    // Lấy giá từ DataTable và gán vào ô textbox
                    string giaSP = sanPhamChon.Rows[0]["GiaSP"].ToString();
                    string SoLuongTonKho = sanPhamChon.Rows[0]["SoLuongTonKho"].ToString();

                    tbGiaSP.Text = giaSP;
                    tbSoLuongTonKho.Text = SoLuongTonKho;
                }
                else
                {
                    // Nếu không có giá sản phẩm, làm rỗng ô textbox
                    tbGiaSP.Text = string.Empty;
                    tbSoLuongTonKho.Text = string.Empty;
                }
            }
            else
            {
                // Nếu không có giá trị được chọn trong ComboBox, làm rỗng ô textbox
                tbGiaSP.Text = string.Empty;
                tbSoLuongTonKho.Text = string.Empty;
            }
        }

        //XỬ LÝ MUA
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
            string mysqlCheck = $"SELECT MaKH FROM khachhang WHERE TenKH = '{tenKH}' AND DiaChiKH = '{diaChiKH}' AND SoDienThoaiKH = '{soDienThoaiKH}'";
            DataTable khachHangCheck = ketNoi.ThucHienTruyVan(mysqlCheck);

            if (khachHangCheck.Rows.Count > 0)
            {
                // Nếu khách hàng đã tồn tại, trả về mã khách hàng hiện tại
                maKhachHang = khachHangCheck.Rows[0]["MaKH"].ToString();
            }
            else
            {   // Nếu khách hàng chưa tồn tại, tạo mã và insert
                maKhachHang = TaoMaKhachHang();
                try
                {
                    // Thực hiện câu lệnh SQL INSERT
                    string mysql = $"INSERT INTO khachhang (MaKH, TenKH, DiaChiKH, SoDienThoaiKH) VALUES ('{maKhachHang}', '{tenKH}', '{diaChiKH}', '{soDienThoaiKH}')";
                    ketNoi.ThucHienLenh(mysql);
                    // Kiểm tra xem câu lệnh INSERT có thành công hay không
                    //if (ketQua > 0)
                    //{
                    //    MessageBox.Show("Thêm khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Thêm khách hàng thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            ThemHoaDon(maKhachHang);
        }

        //Tạo mã KH nếu chưa tồn tại
        private string TaoMaKhachHang()
        {
            // Nếu khách hàng chưa tồn tại, tạo mới mã khách hàng
            Random random = new Random();
            return "KH" + random.Next(1000, 9999).ToString();
        }

        //THÊM SẢN PHẨM VÀO BẢNG DATAGRIDVIEW ở trang thanh toán//
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (cbTenSP.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm khác. Hoặc làm mới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Thoát khỏi hàm nếu không có sản phẩm được chọn
            }

            // Lấy thông tin từ ComboBox và NumericUpDown
            string tenLoai = cbTenLoai.Text;
            string maSanPham = cbTenSP.SelectedValue.ToString();
            string tenSanPham = cbTenSP.Text;
            string giaSanPham = tbGiaSP.Text;
            string soLuongTonKho = tbSoLuongTonKho.Text;
            int soLuongMua = (int)nuSoLuong.Value;

            // Kiểm tra xem sản phẩm đã tồn tại trong DataGridView chưa
            bool daTonTai = false;
            foreach (DataGridViewRow row in dgvSanPham.Rows)
            {
                if (row.Cells["MaSP"].Value != null && row.Cells["MaSP"].Value.ToString() == maSanPham)
                {
                    // Sản phẩm đã tồn tại, tăng số lượng
                   // int soLuongHienTai = Convert.ToInt32(row.Cells["SoLuongMua"].Value);
                    int tongSoLuongMua = soLuongMua;


                    // Kiểm tra xem số lượng mua có vượt quá số lượng tồn không
                    if (tongSoLuongMua > Convert.ToInt32(soLuongTonKho))
                    {
                        MessageBox.Show("Số lượng mua vượt quá số lượng tồn kho.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    row.Cells["soLuongMua"].Value = tongSoLuongMua;
                    UpdateThanhTien(row);

                    daTonTai = true;
                    break;
                }
            }

            // Nếu sản phẩm chưa tồn tại, thêm hàng mới
            if (!daTonTai)
            {
                int thanhTien = soLuongMua * Convert.ToInt32(giaSanPham);
                dgvSanPham.Rows.Add(maSanPham, tenSanPham, giaSanPham, tenLoai,  soLuongMua, thanhTien);
            }
            CapNhatTongTien();
        }
        // Hàm cập nhật giá trị cột mới thành tiền
        private void UpdateThanhTien(DataGridViewRow row)
        {
            int soLuongMua = Convert.ToInt32(row.Cells["soLuongMua"].Value);
            int giaSanPham = Convert.ToInt32(row.Cells["giaSanPham"].Value);
            int thanhTien = soLuongMua * giaSanPham;
            row.Cells["ThanhTien"].Value = thanhTien;

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
                    tongTien += Convert.ToInt32(row.Cells["ThanhTien"].Value);
                }
            }

            // Hiển thị tổng tiền trong TextBox
            tbTongTien.Text = tongTien.ToString();
        }

        //HOA DON//
        private void ThemHoaDon(string maKhachHang)
        {
            string maHoaDon;

            try
            {
                // Lấy thông tin từ các control
                string maNhanVien = cbTenNV.SelectedValue.ToString();
                DateTime ngayLapHD = dtNgayLap.Value;
                string TongTien = tbTongTien.Text;
                // Tạo mã hóa đơn
                maHoaDon = TaoMaHoaDon();

                // Thực hiện câu lệnh SQL INSERT
                string mysql = $"INSERT INTO hoadon (MaHD, MaKH, MaNV, NgayLapHD, TongTien) VALUES ('{maHoaDon}', '{maKhachHang}', '{maNhanVien}', '{ngayLapHD.ToString("yyyy-MM-dd")}', '{TongTien}')";

                ketNoi.ThucHienLenh(mysql);

                ThemChiTietHoadon(maHoaDon);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private string TaoMaHoaDon()
        {
            /*  // Tạo mới mã hóa đơn
              Random random = new Random();
              return "HD" + random.Next(1000, 9999).ToString();*/

            long ticks = DateTime.Now.Ticks;

            // Chuyển ticks thành chuỗi hex để tạo mã
            string uniqueCode = ticks.ToString("X");

            return "HD" + uniqueCode;
        }

        //CHI TIẾT HOÁ ĐƠN
        private void ThemChiTietHoadon(string maHoaDon)
        {
            try
            {
                foreach (DataGridViewRow row in dgvSanPham.Rows)
                {
                    // Lấy thông tin từ các cột trong DataGridView
                    string maSanPham = row.Cells["maSanPham"].Value.ToString();
                    string thanhTien = row.Cells["thanhTien"].Value.ToString();
                    int soLuongMua = Convert.ToInt32(row.Cells["soLuongMua"].Value);

                    // Thực hiện câu lệnh SQL INSERT vào bảng hoadonchitiet
                    string mysqlChiTiet = $"INSERT INTO chitiethoadon (MaSP, MaHD, SoLuongMua,ThanhTien) VALUES ('{maSanPham}', '{maHoaDon}', '{soLuongMua}', '{thanhTien}')";

                    ketNoi.ThucHienLenh(mysqlChiTiet);

                    // Cập nhật số lượng tồn kho trong bảng sanpham
                    CapNhatSoLuongTonKho(maSanPham, soLuongMua);
                }

                MessageBox.Show("Thêm chi tiết hóa đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbTongTien.Clear();
                dgvSanPham.Rows.Clear();
                refresh();
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
                ThemKhachHang();
            }

        }

        //HUỶ ĐƠN
        private void btnHuyDonHang_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có huỷ đơn hàng không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ClearInputs();
                dgvSanPham.Rows.Clear();
            }
            else
            {
                return;
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
    }
}
