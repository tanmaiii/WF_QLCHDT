using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WF_QLCHDT
{
    public partial class Frm_tkDoanhThu : Form
    {
        KetNoiMySql ketnoi = new KetNoiMySql();
        DataTable bangdulieu = new DataTable();
        int donghh;

        string query = "SELECT  COUNT(*) AS SoLuongHD, SUM(TongTien) AS TongTien, YEAR(NgayLapHD) as nam, month(NgayLapHD)as thang , day(NgayLapHD) as Ngay FROM hoadon GROUP BY YEAR(NgayLapHD), month(NgayLapHD), day(NgayLapHD) ORDER BY Nam DESC, Thang DESC, Ngay DESC;";
        
        public Frm_tkDoanhThu()
        {
            InitializeComponent();
        }

        private void LamMoi()
        {
            HienThiDuLieu();
            HienThiTong();
            HienThiBieuDo();
        }

        public void HienThiTong()
        {
            string query = "SELECT sum(TongTien) as TongTien, count(MaHD) as SoLuongHD FROM hoadon";
            DataTable dt = ketnoi.ThucHienTruyVan(query);

            lbTongTien.Text = Convert.ToDecimal(dt.Rows[0]["TongTien"]).ToString("N0") + " VND";

            lbSoHD.Text = dt.Rows[0]["SoLuongHD"].ToString() + " hóa đơn";

        }

        public void HienThiBieuDo()
        {
            chartDoanhThu.Series.Clear();
            Series series = new Series("TongTien");
            chartDoanhThu.Series.Add(series);
            chartDoanhThu.ChartAreas[0].AxisX.Interval = 1;
            chartDoanhThu.ChartAreas[0].AxisX.LabelStyle.Angle = -90;

            foreach (DataGridViewRow row in dgvDoanhThu.Rows)
            {
                string ngayThang = "";

                switch (cbNgayLoc.SelectedIndex.ToString())
                {
                    case "0":
                        ngayThang = row.Cells["Ngay"].Value.ToString() + "-" + row.Cells["Thang"].Value.ToString() + "-" + row.Cells["Nam"].Value.ToString();
                        break;
                    case "1":
                        ngayThang = row.Cells["Thang"].Value.ToString() + "-" + row.Cells["Nam"].Value.ToString();
                        break;
                    case "2":
                        ngayThang = row.Cells["Nam"].Value.ToString();
                        break;
                    default:
                        break;
                }

                chartDoanhThu.Series["TongTien"].Points.AddXY(ngayThang, row.Cells["TongTien"].Value);
            }

        }

        void HienThiDuLieu()
        {
            bangdulieu = ketnoi.ThucHienTruyVan(query);//goi ham trong lớp
            dgvDoanhThu.DataSource = bangdulieu;
            dgvDoanhThu.Columns["TongTien"].DefaultCellStyle.Format = "N0";
        }

        private void Frm_tkDoanhThu_Load(object sender, EventArgs e)
        {
            LamMoi();
            cbNgayLoc.SelectedIndex = 0;

            dgvDoanhThu.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void cbNgayLoc_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (cbNgayLoc.SelectedIndex.ToString())
            {
                case "0":
                    //lọc theo ngày
                    query = "SELECT COUNT(*) AS SoLuongHD, SUM(TongTien) AS TongTien, YEAR(NgayLapHD) as nam,  month(NgayLapHD)as thang , day(NgayLapHD) as Ngay FROM hoadon GROUP BY YEAR(NgayLapHD), month(NgayLapHD), day(NgayLapHD) ORDER BY Nam DESC, Thang DESC, Ngay DESC";
                    // UpdateSqlStatement("Ngày");
                    break;
                case "1":
                    //lọc theo tháng
                    query = "SELECT  COUNT(*) AS SoLuongHD, SUM(TongTien) AS TongTien, YEAR(NgayLapHD) as nam,  month(NgayLapHD)as thang,  0 as Ngay FROM hoadon GROUP BY YEAR(NgayLapHD), month(NgayLapHD) ORDER BY Nam DESC, Thang DESC";
                    DataGridViewTextBoxColumn tenCot = new DataGridViewTextBoxColumn();
                    break;
                case "2":
                    //lọc theo năm
                    query = "SELECT  COUNT(*) AS SoLuongHD, SUM(TongTien) AS TongTien, YEAR(NgayLapHD) as nam , 0 as Thang , 0 as Ngay FROM hoadon GROUP BY YEAR(NgayLapHD) ORDER BY Nam DESC";
                    break;
                default:
                    // Xử lý một trường hợp mặc định nếu cần
                    break;
            }

            LamMoi();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LamMoi();
            cbNgayLoc.SelectedIndex = 0;
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            ExportFile(dgvDoanhThu, "Danh sách", "Doanh thu");
        }

        // XUẤT FILE EXCEL
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

            // Thêm dữ liệu từ DataGridView vào DataTable
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                DataRow dataRow = dataTable.NewRow();

                foreach (DataGridViewCell cell in row.Cells)
                {
                    dataRow[cell.ColumnIndex] = cell.Value;
                }

                dataTable.Rows.Add(dataRow);
            }

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
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "E1");
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
                string columnName = dataTable.Columns[col].ColumnName;
                Microsoft.Office.Interop.Excel.Range cl = oSheet.get_Range(GetExcelColumnName(col + 1) + "3", GetExcelColumnName(col + 1) + "3");
                cl.Value2 = columnName;
                cl.ColumnWidth = 12;
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
