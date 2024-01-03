using Org.BouncyCastle.Crypto.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace WF_QLCHDT
{
    public partial class Frm_nhapHang : Form
    {
        KetNoiMySql ketnoi = new KetNoiMySql();


        public Frm_nhapHang()
        {
            InitializeComponent();
        }


        public void Reset()
        {
            dgvSanPham.Rows.Clear();
            tbTongTien.Clear();
            nuSoLuong.Value = 1;

            pnTTSP.Enabled = true;
            pnDSSP.Enabled = true;
            btnTaoDonHang.Enabled = true;

            HienThiLoaiSanPham();
            HienThiNhaCungCap();
            if (cbLoaiSP.Items.Count > 0)
            {
                cbLoaiSP.SelectedIndex = 0;
                HienThiSanPham(cbLoaiSP.SelectedValue.ToString());
                HienThongTinTheoSanPham();
            }


            dgvSanPham.Columns["GiaSP"].DefaultCellStyle.Format = "N0";
            dgvSanPham.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
        }

        private void Frm_nhapHang_Load(object sender, EventArgs e)
        {
            cbTenSP_SelectedIndexChanged(sender, e);
            Reset();
        }

        void HienThiNhaCungCap()
        {
            string mysql = "select * from nhacungcap";
            DataTable nhacungcap = ketnoi.ThucHienTruyVan(mysql);
            cbNhaCC.DataSource = nhacungcap;
            cbNhaCC.DisplayMember = "TenNCC";
            cbNhaCC.ValueMember = "MaNCC";
        }

        void HienThiLoaiSanPham()
        {
            string mysql = "select * from loai";
            DataTable duieu = ketnoi.ThucHienTruyVan(mysql);
            cbLoaiSP.DataSource = duieu;
            cbLoaiSP.DisplayMember = "TenLoai";
            cbLoaiSP.ValueMember = "MaLoai";
        }

        void HienThiSanPham(String maLoai)
        {
            string mysql = $"SELECT MaSP, TenSP FROM sanpham WHERE MaLoai = '{maLoai}'";

            DataTable dulieu = ketnoi.ThucHienTruyVan(mysql);
            if (dulieu.Rows.Count > 0)
            {
                cbTenSP.Enabled = true;
                cbTenSP.DataSource = dulieu;
                cbTenSP.DisplayMember = "TenSP";
                cbTenSP.ValueMember = "MaSP";

            }
            else
            {
                cbTenSP.DataSource = null;
                cbTenSP.Enabled = false;
            }
        }

        private void cbLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy loại đã chọn (MaLoai)
            string selectedMaLoai = cbLoaiSP.SelectedValue.ToString();

            // Điền ComboBox "Sản phẩm" dựa trên loại đã chọn
            HienThiSanPham(selectedMaLoai);

        }

        void HienThongTinTheoSanPham()
        {
            if (cbTenSP.Items.Count <= 0) return;

            string selectedMaSP = cbTenSP.SelectedValue.ToString();

            string mysql = $"SELECT * FROM sanpham, loai WHERE MaSP = '{selectedMaSP}' and sanpham.MaLoai = loai.MaLoai";
            DataTable sanPhamChon = ketnoi.ThucHienTruyVan(mysql);

            if (sanPhamChon.Rows.Count > 0)
            {
                decimal giaSP = Convert.ToDecimal(sanPhamChon.Rows[0]["GiaSP"]);
                string formattedString = giaSP.ToString("N0");

                tbGiaSP.Text = formattedString;
                cbLoaiSP.Text = sanPhamChon.Rows[0]["TenLoai"].ToString();
                tbSoLuongTon.Text = sanPhamChon.Rows[0]["SoLuongTonKho"].ToString();
            }
            else
            {
                // Nếu không có tên sản phẩm, làm rỗng ô textbox
                tbGiaSP.Text = string.Empty;
                tbSoLuongTon.Text = string.Empty;
            }
        }


        private void cbTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThongTinTheoSanPham();
        }

        private void UpdateThanhTien(DataGridViewRow row)
        {
            int soLuongMua = Convert.ToInt32(row.Cells["SoLuong"].Value);
            int giaSanPham = Convert.ToInt32(row.Cells["GiaSP"].Value);
            int thanhTien = soLuongMua * giaSanPham;
            row.Cells["ThanhTien"].Value = thanhTien;

            CapNhatTongTien();
        }

        private void CapNhatTongTien()
        {
            int tongTien = 0;
            foreach (DataGridViewRow row in dgvSanPham.Rows)
            {
                if (row.Cells["ThanhTien"].Value != null)
                {
                    tongTien += int.Parse(row.Cells["ThanhTien"].Value.ToString().Replace(",", "")); ;
                }
            }

            // Hiển thị tổng tiền trong TextBox
            tbTongTien.Text = tongTien.ToString("N0");
        }

        private void capNhatSoLuongSanPham(string maSanPham, int soLuongNhap)
        {
            try
            {
                // Lấy thông tin số lượng tồn kho hiện tại
                string sqlSelect = $"SELECT SoLuongTonKho FROM sanpham WHERE MaSP = '{maSanPham}'";
                DataTable dt = ketnoi.ThucHienTruyVan(sqlSelect);

                if (dt.Rows.Count > 0)
                {
                    int soLuongHienTai = Convert.ToInt32(dt.Rows[0]["SoLuongTonKho"]);
                    int soLuongMoi = soLuongHienTai + soLuongNhap;
                    // Cập nhật số lượng tồn kho trong bảng sanpham
                    string sqlUpdate = $"UPDATE sanpham SET SoLuongTonKho = {soLuongMoi} WHERE MaSP = '{maSanPham}'";
                    ketnoi.ThucHienLenh(sqlUpdate);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật số lượng tồn kho: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if(nuSoLuong.Value < 1) { return; }

            if (cbTenSP.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm khác. Hoặc làm mới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Thoát khỏi hàm nếu không có sản phẩm được chọn
            }

            // Lấy thông tin từ ComboBox và NumericUpDown
            string maSanPham = cbTenSP.SelectedValue.ToString();
            string tenSanPham = cbTenSP.Text;
            int  giaSanPham = int.Parse( tbGiaSP.Text.ToString().Replace(",",""));
            int soLuong = (int)nuSoLuong.Value;

            // Kiểm tra xem sản phẩm đã tồn tại trong DataGridView chưa
            bool daTonTai = false;
            foreach (DataGridViewRow row in dgvSanPham.Rows)
            {
                if (row.Cells["MaSP"].Value != null && row.Cells["MaSP"].Value.ToString() == maSanPham)
                {
                    // Sản phẩm đã tồn tại, tăng số lượng
                    // int soLuongHienTai = Convert.ToInt32(row.Cells["SoLuongMua"].Value);
                    int tongSoLuongMua = soLuong;

                    row.Cells["SoLuong"].Value = tongSoLuongMua;
                    UpdateThanhTien(row);

                    daTonTai = true;
                    break;
                }
            }

            // Nếu sản phẩm chưa tồn tại, thêm hàng mới
            if (!daTonTai)
            {
                int thanhTien = soLuong * Convert.ToInt32(giaSanPham);
                string stringThanhTien = thanhTien.ToString("N0");
                dgvSanPham.Rows.Add(maSanPham, tenSanPham, giaSanPham, soLuong, stringThanhTien);
            }
            CapNhatTongTien();
        }


        //Xóa sản phẩm
        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int donghh = e.RowIndex;

            if (donghh >= 0)
            {
                dgvSanPham.Rows.RemoveAt(donghh);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn làm mới không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Reset();
                dgvSanPham.Rows.Clear();
            }
            else
            {
                return;
            }
        }

        private void btnTaoDonHang_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Hãy chọn sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn lưu đơn hàng không ? Khi lưu không thể chỉnh sửa hóa đơn !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                        ThemDonNhapHang();
                        pnTTSP.Enabled = false;
                        pnDSSP.Enabled = false;
                        btnTaoDonHang.Enabled = false;
                }
               
            }
        }

        private string TaoMaDonDatHang()
        {
            long ticks = DateTime.Now.Ticks;
            string uniqueCode = ticks.ToString("X");
            return "DDH" + uniqueCode;
        }

        string MaDDH;
        private void ThemDonNhapHang()
        {
            try
            {
                // Lấy thông tin từ các control
                string MaNV = Const.TaiKhoan.MaNV;
                DateTime ngayGioHienTai = DateTime.Now;
                string MaNCC = cbNhaCC.SelectedValue.ToString();
                int TongTien = int.Parse( tbTongTien.Text.ToString().Replace(",", ""));


                // Tạo mã hóa đơn
                MaDDH = TaoMaDonDatHang();

                // Thực hiện câu lệnh SQL INSERT
                string mysql = $"INSERT INTO dondathang (MaDDH, MaNV, MaNCC, NgayLapDDH, TongTien) VALUES ('{MaDDH}', '{MaNV}', '{MaNCC}', '{ngayGioHienTai.ToString("yyyy-MM-dd HH:mm:ss")}', '{TongTien}')";

                ketnoi.ThucHienLenh(mysql);

                ThemChiTietHoadon(MaDDH);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThemChiTietHoadon(string MaDDH)
        {
            try
            {
                foreach (DataGridViewRow row in dgvSanPham.Rows)
                {
                    // Lấy thông tin từ các cột trong DataGridView
                    string MaSP = row.Cells["maSP"].Value.ToString();
                    int SoLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    int GiaSP = Convert.ToInt32(row.Cells["GiaSP"].Value);
                    int ThanhTien = int.Parse(row.Cells["ThanhTien"].Value.ToString().Replace(",",""));

                    // Thực hiện câu lệnh SQL INSERT vào bảng hoadonchitiet
                    string mysqlChiTiet = $"INSERT INTO chitietdondathang (MaSP, MaDDH, SoLuong, ThanhTien, GiaSP) VALUES ('{MaSP}', '{MaDDH}', '{SoLuong}', '{ThanhTien}', '{GiaSP}')";

                    ketnoi.ThucHienLenh(mysqlChiTiet);

                    //Cap nhat so lượng tồn kho 
                    capNhatSoLuongSanPham(MaSP, SoLuong);
                }

                btnInHoaDon.Visible = true;
                MessageBox.Show("Thêm chi tiết hóa đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            Print.Frm_inChiTietDonDatHang FrmChiTietDonHang = new Print.Frm_inChiTietDonDatHang();
            FrmChiTietDonHang.MaDDH = MaDDH;
            FrmChiTietDonHang.ShowDialog();
        }


    }
}
