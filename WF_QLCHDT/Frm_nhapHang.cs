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

namespace WF_QLCHDT
{
    public partial class Frm_nhapHang : Form
    {
        KetNoiMySql ketnoi = new KetNoiMySql();
        private string previousSelectedValue;

        public Frm_nhapHang()
        {
            InitializeComponent();
        }

        void HienThiNhanVien()
        {
            string mysql = "select * from nhanvien";
            DataTable nhanvien = ketnoi.ThucHienTruyVan(mysql);
            cbNhanVien.DataSource = nhanvien;
            cbNhanVien.DisplayMember = "TenNV";
            cbNhanVien.ValueMember = "MaNV";
        }

        void HienThiNhaCungCap()
        {
            string mysql = "select * from nhacungcap";
            DataTable nhacungcap = ketnoi.ThucHienTruyVan(mysql);
            cbNhaCC.DataSource = nhacungcap;
            cbNhaCC.DisplayMember = "TenNCC";
            cbNhaCC.ValueMember = "MaNCC";
        }

        void HienThiSanPhamTheoNhaCungCap(string maNCC)
        {
            string mysql = $"SELECT * FROM sanpham WHERE MaNCC = '{maNCC}'";
            DataTable sanPhamDuLieu = ketnoi.ThucHienTruyVan(mysql);
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

        private void Frm_nhapHang_Load(object sender, EventArgs e)
        {
            HienThiNhanVien();
            HienThiNhaCungCap();
            HienThiSanPhamTheoNhaCungCap(cbNhaCC.SelectedValue.ToString());
            cbTenSP_SelectedIndexChanged(sender, e);
            previousSelectedValue = cbNhaCC.SelectedItem?.ToString();
        }

        private void cbNhaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cbNhaCC.SelectedItem?.ToString();

            // Kiểm tra xem giá trị mới có khác với giá trị trước đó không
            if (selectedValue != previousSelectedValue)
            {
                // Thực hiện các hành động khi giá trị mới được chọn
                // Ví dụ: MessageBox.Show("Giá trị mới: " + selectedValue);
                dgvSanPham.Rows.Clear();
                HienThiSanPhamTheoNhaCungCap(cbNhaCC.SelectedValue.ToString());

                MessageBox.Show("Thay doi");

                // Lưu giá trị mới để so sánh trong lần tiếp theo
                previousSelectedValue = selectedValue;
            }
        }

        private void cbTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbTenSP.SelectedValue != null)
            {
                // Lấy mã sản phẩm đã chọn (MaSP)
                string selectedMaSP = cbTenSP.SelectedValue.ToString();

                // Truy vấn để lấy sản phẩm dựa trên mã sản phẩm
                string mysql = $"SELECT * FROM sanpham, loai WHERE MaSP = '{selectedMaSP}' and sanpham.MaLoai = loai.MaLoai";
                DataTable sanPhamChon = ketnoi.ThucHienTruyVan(mysql);

                if (sanPhamChon.Rows.Count > 0)
                {
/*                    // Lấy giá từ DataTable và gán vào ô textbox
                    string giaSP = sanPhamChon.Rows[0]["GiaSP"].ToString();
                    string SoLuongTonKho = sanPhamChon.Rows[0]["SoLuongTonKho"].ToString();
*/
                    tbGiaSP.Text = sanPhamChon.Rows[0]["GiaSP"].ToString();
                    cbLoaiSP.Text = sanPhamChon.Rows[0]["TenLoai"].ToString();
                    tbSoLuongTon.Text = sanPhamChon.Rows[0]["SoLuongTonKho"].ToString();
                }
                else
                {
                    // Nếu không có giá sản phẩm, làm rỗng ô textbox
                    tbGiaSP.Text = string.Empty;
                    tbSoLuongTon.Text = string.Empty;
                }
            }
            else
            {

            }
        }

        private void UpdateThanhTien(DataGridViewRow row)
        {
            int soLuongMua = Convert.ToInt32(row.Cells["soLuongMua"].Value);
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
                    tongTien += Convert.ToInt32(row.Cells["ThanhTien"].Value);
                }
            }

            // Hiển thị tổng tiền trong TextBox
            tbTongTien.Text = tongTien.ToString("N0");
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
            string giaSanPham = tbGiaSP.Text;
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
                dgvSanPham.Rows.Add(maSanPham, tenSanPham, giaSanPham, soLuongMua, thanhTien);
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

        private void cbNhaNCC_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
