using Microsoft.Reporting.Map.WebForms.BingMaps;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WF_QLCHDT
{
    public partial class Frm_dsNhapHang : Form
    {
        KetNoiMySql ketnoi = new KetNoiMySql();
        DataTable bangDuLieu = new DataTable();
        int donghh;


        public Frm_dsNhapHang()
        {
            InitializeComponent();
        }

        void HienThiDuLieu()
        {
            string mysql = "SELECT count(chitietdondathang.MaSP) as SoLuongSP , dondathang.MaDDH ,TenNV, TenNCC , NgayLapDDH, TongTien FROM dondathang, nhanvien, nhacungcap, chitietdondathang " +
                           " where dondathang.MaNCC = nhacungcap.MaNCC and dondathang.MaNV = nhanvien.MaNV and dondathang.MaDDH = chitietdondathang.MaDDH GROUP BY dondathang.MaDDH ";
         
            bangDuLieu = ketnoi.ThucHienTruyVan(mysql);
            dgvDDH.DataSource = bangDuLieu;
           
        }


        private void Frm_dsNhapHang_Load(object sender, EventArgs e)
        {
            HienThiDuLieu();

            dgvDDH.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            dgvDDH.Columns["NgayLapDDH"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss";
            dgvDDH.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDDH.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDDH.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDDH.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDDH.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDDH.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }


        private void LamMoi()
        {
            HienThiDuLieu();
            tbTimKiem.Clear();
            checkboxLoc.Checked = false;
        }

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


            string lenhTimKiem = $"SELECT count(ctdh.MaSP) as SoLuongSP , ddh.MaDDH , TenNV, TenNCC , NgayLapDDH, TongTien FROM dondathang as ddh, nhanvien as nv, nhacungcap as ncc, chitietdondathang as ctdh " +
                                   $" where ddh.MaNCC = ncc.MaNCC and ddh.MaNV = nv.MaNV and ddh.MaDDH = ctdh.MaDDH " +
                                   $" AND NgayLapDDH LIKE '%{formattedNgayLap}%' AND (ddh.MaDDH Like '%{tuKhoa}%' or TenNV Like '%{tuKhoa}%' or TenNCC Like '%{tuKhoa}%' or TongTien = '{so}') " +
                                   $" GROUP BY ddh.MaDDH ";
            bangDuLieu = ketnoi.ThucHienTruyVan(lenhTimKiem);

            if (bangDuLieu.Rows.Count > 0)
            {
                dgvDDH.DataSource = bangDuLieu;
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả nào.");
                LamMoi();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            Frm_nhapHang frm_NhapHang = new Frm_nhapHang();
            frm_NhapHang.ShowDialog();  
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            ExportFile(bangDuLieu, "Danh sách", "Danh sách nhập hàng");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void checkboxLoc_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxLoc.Checked)
            {
                dtNgayLap.Enabled = true;
            }
            else
            {
                dtNgayLap.Enabled = false;
                LamMoi();
            }
        }

        private void dtNgayLap_ValueChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void dgvDDH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            donghh = e.RowIndex;
            if (donghh >= 0)
            {
                Print.Frm_inChiTietDonDatHang FrmDDH = new Print.Frm_inChiTietDonDatHang();
                FrmDDH.MaDDH = dgvDDH.Rows[donghh].Cells["MaDDH"].Value.ToString();
                FrmDDH.ShowDialog();
            }
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

            cl1.Value2 = "Mã đơn nhập hàng";

            cl1.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Số sản phẩm";

            cl2.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Nhà cung cấp";
            cl3.ColumnWidth = 12.0;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

            cl4.Value2 = "Nhân viên";

            cl4.ColumnWidth = 25.5;

            // Ngày lập
            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");

            cl5.Value2 = "Thời gian lập";

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

            //định dạng cột ngày lập
            Microsoft.Office.Interop.Excel.Range dateColumn = oSheet.get_Range("E4", $"E{rowEnd}");
            dateColumn.NumberFormat = "dd/MM/yyyy hh:mm:ss";

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

    }
}
