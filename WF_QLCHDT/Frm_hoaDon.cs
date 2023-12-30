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
            string mysql = "SELECT MaHD, TenKH, SoDienThoaiKH,TenNV, NgayLapHD, TongTien FROM hoadon, khachhang, nhanvien where hoadon.MaKH = khachhang.MaKH and hoadon.MaNV = nhanvien.MaNV ";
            bangdulieu = ketnoi.ThucHienTruyVan(mysql);//goi ham trong lớp
            dgvHoaDon.DataSource = bangdulieu;
            dgvHoaDon.Columns["NgayLapHD"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void Frm_hoaDon_Load(object sender, EventArgs e)
        {
            HienThiDuLieu();
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

        private void LamMoi()
        {
            tbTimKiem.Clear();
            HienThiDuLieu();
            checkboxLoc.Checked = false;
        }

        private void LocDuLieu()
        {
            string tuKhoa = tbTimKiem.Text.Trim();

            /*            if (string.IsNullOrEmpty(tuKhoa))
                        {
                            MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
                            HienThiDuLieu();
                            return;
                        }*/

            int so = CovertNumberFromString(tuKhoa);

            string formattedNgayLap = "";

            if (checkboxLoc.Checked)
            {
                DateTime ngayLapFilter = dtNgayLap.Value;
                formattedNgayLap = ngayLapFilter.ToString("yyyy-MM-dd");
            }


            string lenhTimKiem = $" SELECT MaHD, TenKH, SoDienThoaiKH, TenNV, NgayLapHD, TongTien FROM hoadon, khachhang, nhanvien where hoadon.MaKH = khachhang.MaKH and hoadon.MaNV = nhanvien.MaNV" +
                                 $" AND NgayLapHD LIKE '%{formattedNgayLap}%' AND (TenKH LIKE '%{tuKhoa}%' OR MaHD LIKE '%{tuKhoa}%' OR SoDienThoaiKH LIKE '%{tuKhoa}%' OR TenNV LIKE '%{tuKhoa}%' OR TongTien = {so})";

            bangdulieu = ketnoi.ThucHienTruyVan(lenhTimKiem);

            if (bangdulieu.Rows.Count > 0)
            {
                dgvHoaDon.DataSource = bangdulieu;
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả nào.");
                HienThiDuLieu(); // Hiển thị lại toàn bộ dữ liệu nếu không tìm thấy kết quả
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LamMoi();
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

        private void btnXuat_Click(object sender, EventArgs e)
        {
           ExportFile(bangdulieu, "Danh sách hóa đơn", "Danh sách hóa đơn");
        }


        public void ExportFile(DataTable dataTable, string sheetName, string title)
        {
            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbooks oBooks;

            Microsoft.Office.Interop.Excel.Sheets oSheets;

            Microsoft.Office.Interop.Excel.Workbook oBook;

            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 

            oExcel.Visible = true;

            oExcel.DisplayAlerts = false;

            oExcel.Application.SheetsInNewWorkbook = 1;

            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));

            oSheets = oBook.Worksheets;

            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            oSheet.Name = sheetName;

            // Tạo phần Tiêu đề
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "F1");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Times New Roman";

            head.Font.Size = "20";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

            cl1.Value2 = "Mã hóa đơn";

            cl1.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Họ tên khách hàng";

            cl2.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Số điện thoại";
            cl3.ColumnWidth = 12.0;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

            cl4.Value2 = "Nhân viên lập";

            cl4.ColumnWidth = 25.5;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");

            cl5.Value2 = "Ngày lập hóa đơn";

            cl5.ColumnWidth = 18.5;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");

            cl6.Value2 = "Tổng Tiền";

            cl6.ColumnWidth = 18.5;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "F3");


            // Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền

            rowHead.Interior.ColorIndex = 6;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo mảng theo datatable

            object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng

            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                DataRow dataRow = dataTable.Rows[row];

                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    arr[row, col] = dataRow[col];
                }
            }

            //Thiết lập vùng điền dữ liệu

            int rowStart = 4;

            int columnStart = 1;

            int rowEnd = rowStart + dataTable.Rows.Count - 2;

            int columnEnd = dataTable.Columns.Count;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập

            range.Value2 = arr;

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột mã nhân viên

            //Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            //Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            //Căn giữa cả bảng 
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }

        private void dtNgayLap_ValueChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void checkboxLoc_CheckedChanged(object sender, EventArgs e)
        {
            if(checkboxLoc.Checked) {
                dtNgayLap.Enabled = true;
            }
            else
            {
                dtNgayLap.Enabled = false;
                LamMoi();
            }
        }
    }
}
