using System;
using System.Collections;
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
    public partial class Frm_tkSanPham : Form
    {
        KetNoiMySql ketnoi = new KetNoiMySql();
        DataTable bangdulieu = new DataTable();
        int donghh;
        public Frm_tkSanPham()
        {
            InitializeComponent();
        }

        void HienThiDuLieu()
        {
            string query = "SELECT TenSP, sanpham.GiaSP , count(sanpham.MaSP) as SoLanBan, sum(SoLuongMua) as SoLuong, sum(ThanhTien) as TongTien FROM chitiethoadon, sanpham where chitiethoadon.MaSP = sanpham.MaSP GROUP BY sanpham.MaSP ORDER BY TongTien DESC";
            bangdulieu = ketnoi.ThucHienTruyVan(query);//goi ham trong lớp
            dgvDoanhThu.DataSource = bangdulieu;
            dgvDoanhThu.Columns["TongTien"].DefaultCellStyle.Format = "N0";
        }

        public void HienThiTong()
        {
            string query = "SELECT sum(chitiethoadon.ThanhTien) as TongTien, sum(chitiethoadon.SoLuongMua) as SoLuongSP from chitiethoadon;";
            DataTable dt = ketnoi.ThucHienTruyVan(query);

            lbTongTien.Text = dt.Rows[0]["TongTien"].ToString();

            lbSoSP.Text = dt.Rows[0]["SoLuongSP"].ToString();
        }

        public void HienThiBieuDo()
        {
    //        chartDoanhThu.Series.Clear();
/*            Series series = new Series("TongTien");
            Series series2 = new Series("SoLuongBan");*/
  
            foreach (DataGridViewRow row in dgvDoanhThu.Rows)
            {
                chartDoanhThu.Series["TongTien"].Points.AddXY(row.Cells["TenSP"].Value, row.Cells["TongTien"].Value);
            }
        }

        private void LamMoi()
        {
            HienThiDuLieu();
            HienThiTong();
            HienThiBieuDo();
        }


        private void Frm_tkSanPham_Load(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            ExportFile(dgvDoanhThu, "Danh sách", "Thống kê sản phẩm");
        }

        // XUẤT FILE EXCEL
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
