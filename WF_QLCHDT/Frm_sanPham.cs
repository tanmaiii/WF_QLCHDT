using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WF_QLCHDT
{
    public partial class Frm_sanPham : Form
    {

        KetNoiMySql ketNoi = new KetNoiMySql();
        DataTable bangDuLieu = new DataTable();
        int donghh;
        public Frm_sanPham()
        {
            InitializeComponent();
        }

        void HienThiDuLieu()
        {
            string mysql = "select  MaSP, TenSP, GiaSP, HangSP, TenLoai, XuatXuSP, TenNCC, SoLuongTonKho from sanpham, loai, nhacungcap where sanpham.MaLoai = loai.MaLoai and sanpham.MaNCC = nhacungcap.MaNCC;";
            bangDuLieu = ketNoi.ThucHienTruyVan(mysql);//goi ham trong lớp
            dataGridView1.DataSource = bangDuLieu;
        }

        void HienThiNhaCC()
        {
            string mysql = "select* from nhacungcap";
            cbMaNCC.DataSource = ketNoi.ThucHienTruyVan(mysql);//goi ham trong lớp
            cbMaNCC.DisplayMember = "TenNCC";//hien thi ten
            cbMaNCC.ValueMember = "MaNCC";//gia tri
        }

        void HienThiLoai()
        {
            string mysql = "select* from loai";
            cbMaLoai.DataSource = ketNoi.ThucHienTruyVan(mysql);//goi ham trong lớp
            cbMaLoai.DisplayMember = "TenLoai";//hien thi ten
            cbMaLoai.ValueMember = "MaLoai";//gia tri
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            donghh = e.RowIndex;
            if (e.RowIndex >= 0 && e.RowIndex < bangDuLieu.Rows.Count)
            {
                tbMaSP.Text = bangDuLieu.Rows[donghh]["MaSP"].ToString();
                tbTenSP.Text = bangDuLieu.Rows[donghh]["TenSP"].ToString();
                cbMaNCC.Text = bangDuLieu.Rows[donghh]["TenNCC"].ToString();
                tbGiaSP.Text = bangDuLieu.Rows[donghh]["GiaSP"].ToString();
                cbHangSP.Text = bangDuLieu.Rows[donghh]["HangSP"].ToString();
                cbXuatXuSP.Text = bangDuLieu.Rows[donghh]["XuatXuSP"].ToString();
                cbMaLoai.Text = bangDuLieu.Rows[donghh]["TenLoai"].ToString();
                tbSoLuongTonKho.Text = bangDuLieu.Rows[donghh]["SoLuongTonKho"].ToString();
                tbMaSP.Enabled = false;
            }
        }

        private void ClearInputs()
        {
            tbMaSP.Clear();
            tbTenSP.Clear();
            tbGiaSP.Clear();
            cbHangSP.SelectedIndex = 0; // Chọn mặc định hoặc có thể là một giá trị khác tùy thuộc vào yêu cầu
            cbXuatXuSP.SelectedIndex = 0; // Chọn mặc định hoặc có thể là một giá trị khác tùy thuộc vào yêu cầu
            cbMaLoai.SelectedIndex = 0; // Chọn mặc định hoặc có thể là một giá trị khác tùy thuộc vào yêu cầu
            tbSoLuongTonKho.Clear();
            // Cho phép nhập liệu cho tbMaSP sau khi reset
            tbMaSP.Enabled = true;
            // Làm cho DataGridView mất focus để không còn dòng nào được chọn
            dataGridView1.ClearSelection();
        }

        private bool KiemTraRong()
        {
            if (string.IsNullOrEmpty(tbMaSP.Text) || string.IsNullOrEmpty(tbTenSP.Text) ||
                cbMaNCC.SelectedValue == null || string.IsNullOrEmpty(tbGiaSP.Text) ||
                string.IsNullOrEmpty(cbHangSP.Text) || string.IsNullOrEmpty(cbXuatXuSP.Text) ||
                cbMaLoai.SelectedValue == null || string.IsNullOrEmpty(tbSoLuongTonKho.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return false;
            }

            return true;
        }
   
        private void Frm_sanPham_Load(object sender, EventArgs e)
        {
            HienThiLoai();
            HienThiNhaCC();
            cbHangSP.SelectedIndex = 0; // Chọn mặc 
            cbXuatXuSP.SelectedIndex = 0; // Chọn mặc định 
            HienThiDuLieu();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearInputs();
            HienThiDuLieu();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbMaSP.Text)) // Đảm bảo rằng đã chọn một dòng để xóa
            {
                // Kiểm tra xem có sản phẩm liên quan đến mã sản phẩm này không
                string kiemTraSPLienQuan = $"SELECT COUNT(*) FROM chitiethoadon WHERE MaSP = '{tbMaSP.Text}'";
                int countSPLienQuan = Convert.ToInt32(ketNoi.ThucHienTruyVan(kiemTraSPLienQuan).Rows[0][0]);

                if (countSPLienQuan > 0)
                {
                    MessageBox.Show("Cảnh báo: Có đơn hàng chi tiết liên quan đến sản phẩm này!");
                }
                else
                {
                    string lenhDelete = $"DELETE FROM sanpham WHERE MaSP = '{tbMaSP.Text}'";
                    ketNoi.ThucHienLenh(lenhDelete);
                    HienThiDuLieu();
                    MessageBox.Show("Xoá sản phẩm thành công!");
                    ClearInputs();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu các trường thông tin không rỗng
            if (KiemTraRong())
            {
                // Cập nhật vào CSDL
                string lenhUpdate = $"UPDATE sanpham SET TenSP = '{tbTenSP.Text}', MaNCC = '{cbMaNCC.SelectedValue}', " +
                                    $"GiaSP = '{tbGiaSP.Text}', HangSP = '{cbHangSP.Text}', XuatXuSP = '{cbXuatXuSP.Text}', " +
                                    $"MaLoai = '{cbMaLoai.SelectedValue}', SoLuongTonKho = '{tbSoLuongTonKho.Text}' " +
                                    $"WHERE MaSP = '{tbMaSP.Text}'";

                ketNoi.ThucHienLenh(lenhUpdate);
                MessageBox.Show("Cập nhật thông tin thành công!");
                HienThiDuLieu();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin để cập nhật.");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra rỗng các ô input
            if (!KiemTraRong())
            {
                return;
            }
            // Kiểm tra xem Mã NCC đã tồn tại chưa
            string kiemTraTonTai = $"SELECT COUNT(*) FROM sanpham WHERE MaSP = '{tbMaSP.Text}'";
            int count = Convert.ToInt32(ketNoi.ThucHienTruyVan(kiemTraTonTai).Rows[0][0]);
            if (count > 0)
            {
                MessageBox.Show("Mã SP đã tồn tại. Vui lòng chọn mã khác.");
            }
            else
            {
                string lenhInsert = $"INSERT INTO sanpham (MaSP, TenSP, MaNCC, GiaSP, HangSP, XuatXuSP, MaLoai, SoLuongTonKho) VALUES " +
                                    $"('{tbMaSP.Text}', '{tbTenSP.Text}', '{cbMaNCC.SelectedValue}', '{tbGiaSP.Text}', " +
                                    $"'{cbHangSP.Text}', '{cbXuatXuSP.Text}', '{cbMaLoai.SelectedValue}', '{tbSoLuongTonKho.Text}')";

                ketNoi.ThucHienLenh(lenhInsert);
                HienThiDuLieu();
                MessageBox.Show("Thêm sản phẩm thành công!");
                ClearInputs();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = tbTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
                return;
            }

            string lenhTimKiem = $"Select  MaSP, TenSP, GiaSP, HangSP, TenLoai, XuatXuSP, TenNCC, SoLuongTonKho  from sanpham, loai, nhacungcap where sanpham.MaLoai = loai.MaLoai and sanpham.MaNCC = nhacungcap.MaNCC " +
                                 $" and (MaSP LIKE '%{tuKhoa}%' OR TenSP LIKE '%{tuKhoa}%' OR GiaSP LIKE '%{tuKhoa}%' OR HangSP LIKE '%{tuKhoa}%' OR TenNCC LIKE '%{tuKhoa}%' OR  XuatXuSP LIKE '%{tuKhoa}%' OR TenLoai LIKE '%{tuKhoa}%' OR SoLuongTonKho LIKE '%{tuKhoa}%')";
            DataTable ketQuaTimKiem = ketNoi.ThucHienTruyVan(lenhTimKiem);

            if (ketQuaTimKiem.Rows.Count > 0)
            {
                dataGridView1.DataSource = ketQuaTimKiem;
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả nào.");
                HienThiDuLieu(); // Hiển thị lại toàn bộ dữ liệu nếu không tìm thấy kết quả
            }
        }

        private void tbGiaSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)){ 
                  e.Handled = true;
            }
        }

        private void tbSoLuongTonKho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)){
                e.Handled = true;
            }
        }
    }
}
