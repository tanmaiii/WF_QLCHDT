using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_QLCHDT
{
    public partial class Frm_nhaCungCap : Form
    {
        KetNoiMySql ketNoi = new KetNoiMySql();
        DataTable bangDuLieu = new DataTable();
        int donghh;
        public Frm_nhaCungCap()
        {
            InitializeComponent();
        }

        void HienThiDuLieu()
        {
            string mysql = "select* from nhacungcap";
            bangDuLieu = ketNoi.ThucHienTruyVan(mysql);//goi ham trong lớp
            dtgNhaCungCap.DataSource = bangDuLieu;
        }

        private void Frm_nhaCungCap_Load(object sender, EventArgs e)
        {
            HienThiDuLieu();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            donghh = e.RowIndex;
            if (e.RowIndex >= 0 && e.RowIndex < bangDuLieu.Rows.Count)
            {
                tbMaNCC.Text = dtgNhaCungCap.Rows[donghh].Cells["MaNCC"].Value.ToString();
                tbTenNCC.Text = dtgNhaCungCap.Rows[donghh].Cells["TenNCC"].Value.ToString();
                tbSoDienThoaiNCC.Text = dtgNhaCungCap.Rows[donghh].Cells["SoDienThoaiNCC"].Value.ToString();
                tbDiaChiNCC.Text = dtgNhaCungCap.Rows[donghh].Cells["DiaChiNCC"].Value.ToString();
                tbMaNCC.Enabled = false;
            }
        }

        private bool KiemTraRong()
        {
            if (string.IsNullOrEmpty(tbMaNCC.Text) || string.IsNullOrEmpty(tbTenNCC.Text) ||
                string.IsNullOrEmpty(tbSoDienThoaiNCC.Text) || string.IsNullOrEmpty(tbDiaChiNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraRong()) return;
            // Kiểm tra xem Mã NCC đã tồn tại chưa
            string kiemTraTonTai = $"SELECT COUNT(*) FROM nhacungcap WHERE MaNCC = '{tbMaNCC.Text}'";
            int count = Convert.ToInt32(ketNoi.ThucHienTruyVan(kiemTraTonTai).Rows[0][0]);

            if (count > 0)
            {
                MessageBox.Show("Mã NCC đã tồn tại. Vui lòng chọn mã khác.");
            }
            else
            {
                string lenhInsert = $"INSERT INTO nhacungcap (MaNCC, TenNCC, DiaChiNCC, SoDienThoaiNCC) VALUES ('{tbMaNCC.Text}', '{tbTenNCC.Text}', '{tbDiaChiNCC.Text}', '{tbSoDienThoaiNCC.Text}')";
                ketNoi.ThucHienLenh(lenhInsert);
                HienThiDuLieu();
                MessageBox.Show("Thêm sản phẩm thành công!");
                ClearInputs();
            }
        }

        private void ClearInputs()
        {
            tbMaNCC.Clear();
            tbTenNCC.Clear();
            tbSoDienThoaiNCC.Clear();
            tbDiaChiNCC.Clear();
            // Cho phép nhập liệu cho tbMaNCC sau khi reset
            tbMaNCC.Enabled = true;
            // Làm cho DataGridView mất focus để không còn dòng nào được chọn
            dtgNhaCungCap.ClearSelection();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearInputs();
            HienThiDuLieu();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có sản phẩm liên quan không
            string kiemTraSPLienQuan = $"SELECT COUNT(*) FROM sanpham WHERE MaNCC = '{tbMaNCC.Text}'";
            int countSPLienQuan = Convert.ToInt32(ketNoi.ThucHienTruyVan(kiemTraSPLienQuan).Rows[0][0]);

            if (countSPLienQuan > 0)
            {
                // Có sản phẩm liên quan, hiển thị hộp thoại cảnh báo
                MessageBox.Show("Có sản phẩm liên quan đến nhà cung cấp này. Không thể xoá!");
                return;
            }
            if (!string.IsNullOrEmpty(tbMaNCC.Text)) // Đảm bảo rằng đã chọn một dòng để xóa
            {
                string lenhDelete = $"DELETE FROM nhacungcap WHERE MaNCC = '{tbMaNCC.Text}'";
                ketNoi.ThucHienLenh(lenhDelete);
                HienThiDuLieu();
                MessageBox.Show("Xoá sản phẩm thành công!");
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!KiemTraRong()) return;
                // Cập nhật vào CSDL
                string lenhUpdate = $"UPDATE nhacungcap SET TenNCC = '{tbTenNCC.Text}', DiaChiNCC = '{tbDiaChiNCC.Text}', SoDienThoaiNCC = '{tbSoDienThoaiNCC.Text}' WHERE MaNCC = '{tbMaNCC.Text}'";
                ketNoi.ThucHienLenh(lenhUpdate);

                // Hiển thị thông báo
                MessageBox.Show("Cập nhật thông tin thành công!");
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

            string lenhTimKiem = $"SELECT * FROM nhacungcap WHERE MaNCC LIKE '%{tuKhoa}%' OR TenNCC LIKE '%{tuKhoa}%' OR DiaChiNCC LIKE '%{tuKhoa}%' OR SoDienThoaiNCC LIKE '%{tuKhoa}%'";
            DataTable ketQuaTimKiem = ketNoi.ThucHienTruyVan(lenhTimKiem);

            if (ketQuaTimKiem.Rows.Count > 0)
            {
                dtgNhaCungCap.DataSource = ketQuaTimKiem;
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả nào.");
                HienThiDuLieu(); // Hiển thị lại toàn bộ dữ liệu nếu không tìm thấy kết quả
            }
        }

 
        private void tbSoDienThoaiNCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
