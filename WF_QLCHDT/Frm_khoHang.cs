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
    public partial class Frm_khoHang : Form
    {
        KetNoiMySql ketnoi = new KetNoiMySql();
        DataTable bangDuLieu = new DataTable();
        int donghh;

        public Frm_khoHang()
        {
            InitializeComponent();
        }
        
        void HienThiDuLieu()
        {
            string mysql = "select MaSP, TenSP,HangSP, GiaSP, TenNCC, SoLuongTonKho from sanpham, loai, nhacungcap where sanpham.MaLoai = loai.MaLoai and sanpham.MaNCC = nhacungcap.MaNCC;";
            bangDuLieu = ketnoi.ThucHienTruyVan(mysql);//goi ham trong lớp
            dgvKhoHang.DataSource = bangDuLieu;
        }
        
        private void Frm_khoHang_Load(object sender, EventArgs e)
        {
            HienThiDuLieu();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = tbTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
                HienThiDuLieu();
                return;
            }

            string lenhTimKiem = $"Select  MaSP, TenSP, HangSP,GiaSP, TenNCC, SoLuongTonKho  from sanpham, loai, nhacungcap where sanpham.MaLoai = loai.MaLoai and sanpham.MaNCC = nhacungcap.MaNCC " +
                                 $" and (MaSP LIKE '%{tuKhoa}%' OR TenSP LIKE '%{tuKhoa}%' OR GiaSP LIKE '%{tuKhoa}%' OR HangSP LIKE '%{tuKhoa}%' OR TenNCC LIKE '%{tuKhoa}%'  OR SoLuongTonKho LIKE '%{tuKhoa}%')";


            DataTable ketQuaTimKiem = ketnoi.ThucHienTruyVan(lenhTimKiem);

            if (ketQuaTimKiem.Rows.Count > 0)
            {
                dgvKhoHang.DataSource = ketQuaTimKiem;
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả nào.");
                HienThiDuLieu(); // Hiển thị lại toàn bộ dữ liệu nếu không tìm thấy kết quả
            }
        }


        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            Frm_nhapHang frm_NhapHang = new Frm_nhapHang();
            frm_NhapHang.ShowDialog();
        }
    }
}
