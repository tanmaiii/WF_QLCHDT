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
            string mysql = "select  MaSP, TenSP, GiaSP, HangSP, TenLoai, XuatXuSP, SoLuongTonKho, MoTaSP from sanpham, loai where sanpham.MaLoai = loai.MaLoai";
            bangDuLieu = ketNoi.ThucHienTruyVan(mysql);//goi ham trong lớp
            dgvSanPham.DataSource = bangDuLieu;
            dgvSanPham.Columns["GiaSP"].DefaultCellStyle.Format = "N0";
            /*   dgvSanPham.Columns[0].Width = 100;
               dgvSanPham.Columns[1].Width = 100;
               dgvSanPham.Columns[2].Width = 100;
               dgvSanPham.Columns[3].Width = 100;
               dgvSanPham.Columns[4].Width = 100;*/

            dgvSanPham.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSanPham.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSanPham.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSanPham.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSanPham.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSanPham.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSanPham.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }


        void HienThiLoai()
        {
            string mysql = "select* from loai";
            DataTable tableLoai = ketNoi.ThucHienTruyVan(mysql);//goi ham trong lớp
            if(tableLoai.Rows.Count > 0)
            {
                cbMaLoai.DataSource = tableLoai;
                cbMaLoai.DisplayMember = "TenLoai";//hien thi ten
                cbMaLoai.ValueMember = "MaLoai";//gia tri
                cbMaLoai.Enabled = true;
            }
            else
            {
                cbMaLoai.DataSource = null;
                cbMaLoai.Enabled = false;
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            donghh = e.RowIndex;
            if (e.RowIndex >= 0 && e.RowIndex < bangDuLieu.Rows.Count)
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                tbMaSP.Text = dgvSanPham.Rows[donghh].Cells["MaSP"].Value.ToString();
                tbTenSP.Text = dgvSanPham.Rows[donghh].Cells["TenSP"].Value.ToString();
                cbHangSP.Text = dgvSanPham.Rows[donghh].Cells["HangSP"].Value.ToString();
                cbXuatXuSP.Text = dgvSanPham.Rows[donghh].Cells["XuatXuSP"].Value.ToString();
                cbMaLoai.Text = dgvSanPham.Rows[donghh].Cells["TenLoai"].Value.ToString();
                tbSoLuongTonKho.Text = dgvSanPham.Rows[donghh].Cells["SoLuongTonKho"].Value.ToString();
                tbMoTaSP.Text = dgvSanPham.Rows[donghh].Cells["MoTaSP"].Value.ToString();

                tbGiaSP.Text = Convert.ToInt32(dgvSanPham.Rows[donghh].Cells["GiaSP"].Value).ToString();
               
                tbMaSP.Enabled = false;
            }
        }

        private void Reset()
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            tbMaSP.Clear();
            tbTenSP.Clear();
            tbGiaSP.Clear();
            tbMoTaSP.Clear();
            cbHangSP.SelectedIndex = 0; // Chọn mặc định hoặc có thể là một giá trị khác tùy thuộc vào yêu cầu
            cbXuatXuSP.SelectedIndex = 0; // Chọn mặc định hoặc có thể là một giá trị khác tùy thuộc vào yêu cầu
            if(cbMaLoai.Items.Count > 0)
            {
               cbMaLoai.SelectedIndex = 0; // Chọn mặc định hoặc có thể là một giá trị khác tùy thuộc vào yêu cầu
            }
            tbSoLuongTonKho.Clear();
            // Cho phép nhập liệu cho tbMaSP sau khi reset
            tbMaSP.Enabled = true;
            // Làm cho DataGridView mất focus để không còn dòng nào được chọn
            dgvSanPham.ClearSelection();

            HienThiLoai();
            HienThiDuLieu();
        }

        private bool KiemTraRong()
        {
            if (string.IsNullOrEmpty(tbMaSP.Text) || string.IsNullOrEmpty(tbTenSP.Text) ||
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
            cbHangSP.SelectedIndex = 0; // Chọn mặc 
            cbXuatXuSP.SelectedIndex = 0; // Chọn mặc định 
            HienThiDuLieu();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
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
                    MessageBox.Show("Xoá sản phẩm thành công!");
                    Reset();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!KiemTraRong()) return;

            if (double.Parse(tbGiaSP?.Text) > 100000000)
            {
                MessageBox.Show("Giá sản phẩm không vượt quá 100,000,000");
                return;
            }


            if (Int32.Parse(tbSoLuongTonKho?.Text) > 999)
            {
                MessageBox.Show("Số lượng tồn kho không vượt quá  999");
                return;
            }

            // Kiểm tra nếu các trường thông tin không rỗng
            if (KiemTraRong())
            {
                // Cập nhật vào CSDL
                string lenhUpdate = $"UPDATE sanpham SET TenSP = '{tbTenSP.Text}' ," +
                                    $"GiaSP = '{tbGiaSP.Text}', HangSP = '{cbHangSP.Text}', XuatXuSP = '{cbXuatXuSP.Text}', " +
                                    $"MaLoai = '{cbMaLoai.SelectedValue}', SoLuongTonKho = '{tbSoLuongTonKho.Text}', MoTaSP = '{tbMoTaSP.Text}' " +
                                    $"WHERE MaSP = '{tbMaSP.Text}'";

                ketNoi.ThucHienLenh(lenhUpdate);
                MessageBox.Show("Cập nhật thông tin thành công!");
                Reset();
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

            if(double.Parse(tbGiaSP.Text) > 1000000000)
            {
                MessageBox.Show("Giá sản phẩm không vượt quá 100,000,000");
                return;
            }


            if (Int32.Parse(tbSoLuongTonKho.Text) > 999)
            {
                MessageBox.Show("Số lượng tồn kho không vượt quá  999");
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
                string lenhInsert = $"INSERT INTO sanpham (MaSP, TenSP, GiaSP, HangSP, XuatXuSP, MaLoai, SoLuongTonKho) VALUES " +
                                    $"('{tbMaSP.Text}', '{tbTenSP.Text}', '{tbGiaSP.Text}', MoTaSP = '{tbMoTaSP.Text}' " +
                                    $"'{cbHangSP.Text}', '{cbXuatXuSP.Text}', '{cbMaLoai.SelectedValue}', '{tbSoLuongTonKho.Text}')";

                ketNoi.ThucHienLenh(lenhInsert);
                MessageBox.Show("Thêm sản phẩm thành công!");
                Reset();
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

            string lenhTimKiem = $"Select  MaSP, TenSP, GiaSP, HangSP, TenLoai, XuatXuSP, SoLuongTonKho, MoTaSP  from sanpham, loai where sanpham.MaLoai = loai.MaLoai " +
                                 $" and (MaSP LIKE '%{tuKhoa}%' OR TenSP LIKE '%{tuKhoa}%' OR GiaSP LIKE '%{tuKhoa}%' OR HangSP LIKE '%{tuKhoa}%' OR  XuatXuSP LIKE '%{tuKhoa}%' OR TenLoai LIKE '%{tuKhoa}%' OR SoLuongTonKho LIKE '%{tuKhoa}%' OR MoTaSP LIKE '%{tuKhoa}%')";
            DataTable ketQuaTimKiem = ketNoi.ThucHienTruyVan(lenhTimKiem);

            if (ketQuaTimKiem.Rows.Count > 0)
            {
                dgvSanPham.DataSource = ketQuaTimKiem;
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

        private void btnThemLoaiSP_Click(object sender, EventArgs e)
        {
            Frm_loaiSP FrmLoaiSP = new Frm_loaiSP();
            FrmLoaiSP.ShowDialog();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            ExportFile(dgvSanPham, "bang", "Danh sách sản phẩm");
        }
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
