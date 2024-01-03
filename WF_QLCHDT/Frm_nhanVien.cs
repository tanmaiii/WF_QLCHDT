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
            cbLoaiNV.SelectedIndex = 0;
        }
        private void dgvNhanvien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu đang ở cột "loaiNV" và không phải là hàng đầu tiên (header)
            if (e.ColumnIndex == dgvNhanvien.Columns["LoaiNV"].Index && e.RowIndex >= 0)
            {
                // Lấy giá trị từ cell
                object cellValue = e.Value;

                // Kiểm tra giá trị và hiển thị tương ứng
                if (cellValue != null && cellValue.ToString() == "1")
                {
                    e.Value = "Quản lý";
                }
                else if (cellValue != null && cellValue.ToString() == "0")
                {
                    e.Value = "Nhân viên";
                }
            }
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

        private void Reset()
        {
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            tbMaNv.Enabled = true;
            tbMaNv.Clear();
            tbHoTen.Clear();
            TBDiaChi.Clear();
            TbSDT.Clear();
            tbTaiKhoan.Clear();
            tbMatKhau.Clear();
            // Làm cho DataGridView mất focus để không còn dòng nào được chọn
            dgvNhanvien.ClearSelection();
            HienThiDuLieu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraRong()) return;
            // Kiểm tra xem Mã NCC đã tồn tại chưa

            if (tbMatKhau.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải lớn hơn 6 kí tự");
                return;
            }

            string kiemTraTonTai = $"SELECT COUNT(*) FROM nhanvien WHERE MaNV = '{tbMaNv.Text}'";
            int kp = Convert.ToInt32(ketnoi.ThucHienTruyVan(kiemTraTonTai).Rows[0][0]);

            if (kp > 0)
            {
                MessageBox.Show("Mã Nhân viên đã tồn tại. Vui lòng chọn mã khác.");
            }
            else
            {
                string kiemTraTaiKhoan = $"SELECT COUNT(*) FROM nhanvien WHERE TaiKhoanNV = '{tbTaiKhoan.Text}'";
                int kp2 = Convert.ToInt32(ketnoi.ThucHienTruyVan(kiemTraTaiKhoan).Rows[0][0]);

                if (kp2 > 0) {
                    MessageBox.Show("Tài khoản đã tồn tại. Vui lòng chọn tài khoản khác.");
                }
                else
                {
                    string lenhInsert = $"INSERT INTO nhanvien (MaNV, TenNV, DiaChiNV, SoDienThoaiNV, TaiKhoanNV, MatKhauNV , LoaiNV) VALUES ('{tbMaNv.Text}','{tbHoTen.Text}', '{TBDiaChi.Text}','{TbSDT.Text}', '{tbTaiKhoan.Text}', '{tbMatKhau.Text}', '{cbLoaiNV.SelectedIndex}')";
                    ketnoi.ThucHienLenh(lenhInsert);
                    MessageBox.Show("Thêm nhân viên thành công !");
                    Reset();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!KiemTraRong()) return;

            // Cập nhật vào CSDL
            string lenhUpdate = $"UPDATE nhanvien SET TenNV = '{tbHoTen.Text}', SoDienThoaiNV = '{TbSDT.Text}'," +
                                $" DiaChiNV = '{TBDiaChi.Text}', TaiKhoanNV = '{tbTaiKhoan.Text}', MatKhauNV = '{tbMatKhau.Text}' , LoaiNV = '{cbLoaiNV.SelectedIndex}'" +
                                $" WHERE MaNV = '{tbMaNv.Text}' ";

            ketnoi.ThucHienLenh(lenhUpdate);
            MessageBox.Show("Cập nhật thông tin thành công!");
            Reset();
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
                    MessageBox.Show("Xoá nhân viên thành công!");
                    Reset();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
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

            string lenhTimKiem = $"SELECT * FROM nhanvien WHERE MaNV LIKE '%{tuKhoa}%' OR TenNV LIKE '%{tuKhoa}%' OR DiaChiNV LIKE '%{tuKhoa}%' OR SoDienThoaiNV LIKE '%{tuKhoa}%' OR TaiKhoanNV LIKE '%{tuKhoa}%' OR MatKhauNV LIKE '%{tuKhoa}%'";
            DataTable ketQuaTimKiem = ketnoi.ThucHienTruyVan(lenhTimKiem);

            if (ketQuaTimKiem.Rows.Count > 0)
            {
                dgvNhanvien.DataSource = ketQuaTimKiem;
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả nào.");
                Reset(); // Hiển thị lại toàn bộ dữ liệu nếu không tìm thấy kết quả
            }
        }

        private void dgvNhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            donghh = e.RowIndex;
            if (e.RowIndex >= 0 && e.RowIndex < bangdulieu.Rows.Count)
            {
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                tbMaNv.Enabled = false;
                tbMaNv.Text = dgvNhanvien.Rows[donghh].Cells["MaNV"].Value.ToString();
                tbHoTen.Text = dgvNhanvien.Rows[donghh].Cells["TenNV"].Value.ToString();
                TbSDT.Text = dgvNhanvien.Rows[donghh].Cells["SoDienThoaiNV"].Value.ToString();
                TBDiaChi.Text = dgvNhanvien.Rows[donghh].Cells["DiaChiNV"].Value.ToString();
                tbTaiKhoan.Text = dgvNhanvien.Rows[donghh].Cells["TaiKhoanNV"].Value.ToString();
                tbMatKhau.Text = dgvNhanvien.Rows[donghh].Cells["MatKhauNV"].Value.ToString();
                cbLoaiNV.SelectedIndex = int.Parse(dgvNhanvien.Rows[donghh].Cells["LoaiNV"].Value.ToString());
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            ExportFile(dgvNhanvien, "Bảng", "Bảng nhân viên");
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
