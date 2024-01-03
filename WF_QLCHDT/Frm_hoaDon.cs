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
            dgvHoaDon.Columns["NgayLapHD"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss";
            dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0";
        }

        private void Frm_hoaDon_Load(object sender, EventArgs e)
        {
            HienThiDuLieu();

            dgvHoaDon.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvHoaDon.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvHoaDon.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvHoaDon.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvHoaDon.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvHoaDon.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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
                LamMoi(); // Hiển thị lại toàn bộ dữ liệu nếu không tìm thấy kết quả
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
                frmPrint.MaHD = dgvHoaDon.Rows[donghh].Cells["MaHD"].Value.ToString();
                frmPrint.ShowDialog();
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
           ExportFile(dgvHoaDon, "Danh sách hóa đơn", "Danh sách hóa đơn");
        }

        private void dtNgayLap_ValueChanged(object sender, EventArgs e)
        {
           // LocDuLieu();
        }


        //Khi thay đổi trạng thái checkbox
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


        // Chuyển dữ liệu từ dataGridView -> Datatable
        public void ExportFile(DataGridView dataGridView, string sheetName, string title)
        {
            // Tạo DataTable từ dữ liệu DataGridView
            DataTable dataTable = new DataTable();

            // Thêm cột vào DataTable dựa trên tên cột của DataGridView
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                dataTable.Columns.Add(column.HeaderText, column.ValueType);
            }

            // Thêm cột NgayLapFormatted để chứa giá trị NgayLap đã được định dạng
            dataTable.Columns.Add("NgayLap", typeof(string));

            // Thêm dữ liệu từ DataGridView vào DataTable
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                DataRow dataRow = dataTable.NewRow();

                // Định dạng giá trị NgayLap và gán vào cột mới
                dataRow["NgayLap"] = (row.Cells["NgayLapHD"].Value is DateTime ngayLap)
                    ? ngayLap.ToString("dd/MM/yyyy HH:mm:ss")
                    : row.Cells["NgayLapHD"].Value.ToString();

                foreach (DataGridViewCell cell in row.Cells)
                {
                    dataRow[cell.ColumnIndex] = cell.Value;
                }

                dataTable.Rows.Add(dataRow);
            }

            dataTable.Columns.Remove("Ngày Lập HD");
            // Gọi hàm ExportFile với DataTable đã được tạo
            ExportFile(dataTable, sheetName, title);
        }

        // Chuyển dữ liệu từ Datatable -> Excel
        public void ExportFile(DataTable dataTable, string sheetName, string title)
        {
            // Tạo các đối tượng Excel
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            // Tạo mới một Excel WorkBook 
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;
            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = sheetName;

            // Tạo phần Tiêu đề
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", GetExcelColumnName(dataTable.Columns.Count) + "1");
            head.MergeCells = true;
            head.Value2 = title;
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 
            int columnCount = dataTable.Columns.Count;
            for (int col = 0; col < columnCount; col++)
            {
                string columnName = col == columnCount - 1 ? "Ngày Lập" : dataTable.Columns[col].ColumnName;
                Microsoft.Office.Interop.Excel.Range cl = oSheet.get_Range(GetExcelColumnName(col + 1) + "3", GetExcelColumnName(col + 1) + "3");
                cl.Value2 = columnName;
                cl.ColumnWidth = 20;
            }

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", GetExcelColumnName(columnCount) + "3");

            // Kẻ viền
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền
            rowHead.Interior.ColorIndex = 6;
            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo mảng theo DataTable
            object[,] arr = new object[dataTable.Rows.Count, columnCount];

            // Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                DataRow dataRow = dataTable.Rows[row];

                for (int col = 0; col < columnCount; col++)
                {
                    arr[row, col] = dataRow[col];
                }
            }

            // Thiết lập vùng điền dữ liệu
            int rowStart = 4;
            int columnStart = 1;
            int rowEnd = rowStart + dataTable.Rows.Count - 1;
            int columnEnd = columnCount;

            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            // Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;

            // Kẻ viền
            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cả bảng 
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Áp dụng AutoFit cho tất cả các cột
            oSheet.Columns.AutoFit();

            // Tự động xuống hàng nếu nội dung quá dài 
            Microsoft.Office.Interop.Excel.Range dataRange = oSheet.get_Range("A1", GetExcelColumnName(columnCount) + (dataTable.Rows.Count + 3));
            dataRange.WrapText = true;
        }

        // Hàm chuyển đổi số thành chữ cái tương ứng trong Excel
        private string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }
    }
}
