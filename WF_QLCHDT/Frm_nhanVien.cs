using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WF_QLCHDT
{
    public partial class Frm_nhanVien : Form
    {
        KetNoiMySql ketnoi = new KetNoiMySql();
        DataTable bangdulieu = new DataTable();
        int donghh;

        public Frm_nhanVien()
        {
            InitializeComponent();
        }

        void HienThiDuLieu()
        {
            string mysql = "select * from nhanvien";
            bangdulieu = ketnoi.ThucHienTruyVan(mysql);//goi ham trong lớp
            dgvNhanvien.DataSource = bangdulieu;
        }

        private void Frm_nhanVien_Load(object sender, EventArgs e)
        {
            HienThiDuLieu();
        }

        private void TbSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool KiemTraRong()
        {
            if (string.IsNullOrEmpty(tbMaNv.Text) || string.IsNullOrEmpty(tbHoTen.Text) ||
                string.IsNullOrEmpty(tbTaiKhoan.Text) || string.IsNullOrEmpty(tbMatKhau.Text) ||
                string.IsNullOrEmpty(TbSDT.Text) || string.IsNullOrEmpty(TBDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return false;
            }
            return true;
        }

        private void ClearInputs()
        {
            tbMaNv.Enabled = true;
            tbMaNv.Clear();
            tbHoTen.Clear();
            TBDiaChi.Clear();
            TbSDT.Clear();
            tbTaiKhoan.Clear();
            tbMatKhau.Clear();
            // Làm cho DataGridView mất focus để không còn dòng nào được chọn
            dgvNhanvien.ClearSelection();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraRong()) return;
            // Kiểm tra xem Mã NCC đã tồn tại chưa
            string kiemTraTonTai = $"SELECT COUNT(*) FROM nhacungcap WHERE MaNCC = '{tbMaNv.Text}'";
            int count = Convert.ToInt32(ketnoi.ThucHienTruyVan(kiemTraTonTai).Rows[0][0]);

            if (count > 0)
            {
                MessageBox.Show("Mã Nhân viên đã tồn tại. Vui lòng chọn mã khác.");
            }
            else
            {
                if (tbMatKhau.Text.Length < 6)
                {
                    MessageBox.Show("Mật khẩu phải lớn hơn 6 kí tự");
                }
                else
                {
                    string lenhInsert = $"INSERT INTO nhanvien (MaNV, TenNV, DiaChiNV, SoDienThoaiNV, TaiKhoanNV, MatKhauNV) VALUES ('{tbMaNv.Text}','{tbHoTen.Text}', '{TBDiaChi.Text}','{TbSDT.Text}', '{tbTaiKhoan.Text}', '{tbMatKhau.Text}')";
                    ketnoi.ThucHienLenh(lenhInsert);
                    HienThiDuLieu();
                    MessageBox.Show("Thêm nhân viên thành công !");
                    ClearInputs();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!KiemTraRong()) return;

            // Cập nhật vào CSDL
            string lenhUpdate = $"UPDATE nhanvien SET TenNV = '{tbHoTen.Text}', SoDienThoaiNV = '{TbSDT.Text}'," +
                                $" DiaChiNV = '{TBDiaChi.Text}', TaiKhoanNV = '{tbTaiKhoan.Text}', MatKhauNV = '{tbMatKhau.Text}' " +
                                $" WHERE MaNV = '{tbMaNv.Text}' ";

            ketnoi.ThucHienLenh(lenhUpdate);
            MessageBox.Show("Cập nhật thông tin thành công!");
            HienThiDuLieu();
            ClearInputs();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbMaNv.Text)) // Đảm bảo rằng đã chọn một dòng để xóa
            {
                // Kiểm tra xem có sản phẩm liên quan đến mã sản phẩm này không
                string kienTraNhanVien = $"SELECT COUNT(*) FROM hoadon WHERE MaNV = '{tbMaNv.Text}'";
                int countNVLienQuan = Convert.ToInt32(ketnoi.ThucHienTruyVan(kienTraNhanVien).Rows[0][0]);

                if (countNVLienQuan > 0)
                {
                    MessageBox.Show("Cảnh báo: Nhân viên này đã thực hiện thanh toán đơn hàng nên không thể xóa !", "Some title",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string lenhDelete = $"DELETE FROM nhanvien WHERE MaNV = '{tbMaNv.Text}'";
                    ketnoi.ThucHienLenh(lenhDelete);
                    HienThiDuLieu();
                    MessageBox.Show("Xoá nhân viên thành công!");
                    ClearInputs();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearInputs();
            HienThiDuLieu();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = tbTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
                return;
            }

            string lenhTimKiem = $"SELECT * FROM nhanvien WHERE MaNV LIKE '%{tuKhoa}%' OR TenNV LIKE '%{tuKhoa}%' OR DiaChiNV LIKE '%{tuKhoa}%' OR SoDienThoaiNV LIKE '%{tuKhoa}%' OR TaiKhoanNV LIKE '%{tuKhoa}%' OR MatKhauNV LIKE '%{tuKhoa}%'";
            DataTable ketQuaTimKiem = ketnoi.ThucHienTruyVan(lenhTimKiem);

            if (ketQuaTimKiem.Rows.Count > 0)
            {
                dgvNhanvien.DataSource = ketQuaTimKiem;
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả nào.");
                HienThiDuLieu(); // Hiển thị lại toàn bộ dữ liệu nếu không tìm thấy kết quả
            }
        }

        private void dgvNhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            donghh = e.RowIndex;
            if (e.RowIndex >= 0 && e.RowIndex < bangdulieu.Rows.Count)
            {
                tbMaNv.Enabled = false;
                tbMaNv.Text = dgvNhanvien.Rows[donghh].Cells["MaNV"].Value.ToString();
                tbHoTen.Text = dgvNhanvien.Rows[donghh].Cells["TenNV"].Value.ToString();
                TbSDT.Text = dgvNhanvien.Rows[donghh].Cells["SoDienThoaiNV"].Value.ToString();
                TBDiaChi.Text = dgvNhanvien.Rows[donghh].Cells["DiaChiNV"].Value.ToString();
                tbTaiKhoan.Text = dgvNhanvien.Rows[donghh].Cells["TaiKhoanNV"].Value.ToString();
                tbMatKhau.Text = dgvNhanvien.Rows[donghh].Cells["MatKhauNV"].Value.ToString();
            }
        }
    }
}
