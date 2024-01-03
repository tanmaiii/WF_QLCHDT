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
            dgvNhaCungCap.DataSource = bangDuLieu;
        }

        private void Frm_nhaCungCap_Load(object sender, EventArgs e)
        {
            HienThiDuLieu();
        }

        private void Reset()
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            tbMaNCC.Clear();
            tbTenNCC.Clear();
            tbSoDienThoaiNCC.Clear();
            tbDiaChiNCC.Clear();
            // Cho phép nhập liệu cho tbMaNCC sau khi reset
            tbMaNCC.Enabled = true;
            // Làm cho DataGridView mất focus để không còn dòng nào được chọn
            dgvNhaCungCap.ClearSelection();
            HienThiDuLieu();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            donghh = e.RowIndex;
            if (e.RowIndex >= 0 && e.RowIndex < bangDuLieu.Rows.Count)
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                tbMaNCC.Text = dgvNhaCungCap.Rows[donghh].Cells["MaNCC"].Value.ToString();
                tbTenNCC.Text = dgvNhaCungCap.Rows[donghh].Cells["TenNCC"].Value.ToString();
                tbSoDienThoaiNCC.Text = dgvNhaCungCap.Rows[donghh].Cells["SoDienThoaiNCC"].Value.ToString();
                tbDiaChiNCC.Text = dgvNhaCungCap.Rows[donghh].Cells["DiaChiNCC"].Value.ToString();
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
                MessageBox.Show("Thêm sản phẩm thành công!");
                Reset();
            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
           Reset();
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
                MessageBox.Show("Xoá sản phẩm thành công!");
                Reset();
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
                Reset();
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
                dgvNhaCungCap.DataSource = ketQuaTimKiem;
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả nào.");
                Reset(); // Hiển thị lại toàn bộ dữ liệu nếu không tìm thấy kết quả
            }
        }

 
        private void tbSoDienThoaiNCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            ExportFile(dgvNhaCungCap, "bang", "Danh sách nhà cung cấp");
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
