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
    public partial class Frm_hoaDon : Form
    {
        KetNoiMySql ketnoi = new KetNoiMySql();
        DataTable bangdulieu = new DataTable();
        int donghh;

        public Frm_hoaDon()
        {
            InitializeComponent();
        }

        void HienThiDuLieu()
        {
            string mysql = "SELECT MaHD, TenKH, SoDienThoaiKH,TenNV, NgayLapHD, TongTien FROM hoadon, khachhang, nhanvien where hoadon.MaKH = khachhang.MaKH and hoadon.MaNV = nhanvien.MaNV;";
            bangdulieu = ketnoi.ThucHienTruyVan(mysql);//goi ham trong lớp
            dgvHoaDon.DataSource = bangdulieu;
        }


        private void Frm_hoaDon_Load(object sender, EventArgs e)
        {
            HienThiDuLieu();
        }

        //Chuyển chuỗi dd/mm/yyyy thành yyyy-MM-dd;
        static string ConvertDateFormat(string input)
        {
            // Phân tích chuỗi thành đối tượng DateTime
            if (DateTime.TryParseExact(input, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
            {
                // Định dạng lại đối tượng DateTime thành chuỗi mới
                string formattedDate = parsedDate.ToString("yyyy-MM-dd");
                return formattedDate;
            }
            else
            {
                //Console.WriteLine("Chuỗi không hợp lệ");
                return input;
            }
        }

        //Chuyển chuỗi thành chữ số
        static int CovertNumberFromString(string input)
        {
            // Lọc ra chỉ các ký tự số từ chuỗi
            string numericString = new string(input.Where(char.IsDigit).ToArray());

            // Chuyển đổi chuỗi số thành số nguyên
            if (int.TryParse(numericString, out int result))
            {
                return result;
            }
            else
            {
                return 0; 
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

            int so = CovertNumberFromString(tuKhoa);

            string datatime = ConvertDateFormat(tuKhoa);

            string lenhTimKiem = $"SELECT MaHD, TenKH, SoDienThoaiKH, TenNV, NgayLapHD, TongTien FROM hoadon, khachhang, nhanvien where hoadon.MaKH = khachhang.MaKH and hoadon.MaNV = nhanvien.MaNV" +
                                 $" AND (TenKH LIKE '%{tuKhoa}%' OR MaHD LIKE '%{tuKhoa}%' OR SoDienThoaiKH LIKE '%{tuKhoa}%' OR TenNV LIKE '%{tuKhoa}%' OR NgayLapHD LIKE '%{datatime}%' OR TongTien = {so})";

            DataTable ketQuaTimKiem = ketnoi.ThucHienTruyVan(lenhTimKiem);
             
            if (ketQuaTimKiem.Rows.Count > 0)
            {
                dgvHoaDon.DataSource = ketQuaTimKiem;
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả nào.");
                HienThiDuLieu(); // Hiển thị lại toàn bộ dữ liệu nếu không tìm thấy kết quả
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tbTimKiem.Clear();
            HienThiDuLieu();
        }

        //Xem chi tiết đơn hàng
        private void dgvHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int donghh = e.RowIndex;
            if(donghh >= 0)
            {
                Print.Frm_inChiTietHoaDon frmPrint = new Print.Frm_inChiTietHoaDon();
                frmPrint.MaHD = bangdulieu.Rows[donghh]["MaHD"].ToString();
                frmPrint.ShowDialog();
            }
        }
    }
}
