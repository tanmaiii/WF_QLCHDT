using Microsoft.ReportingServices.Diagnostics.Internal;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WF_QLCHDT.Print
{
    public partial class Frm_inChiTietHoaDon : Form
    {
        public string MaHD ;

        KetNoiMySql ketnoi = new KetNoiMySql(); 
        DataTable bangdulieu = new DataTable();

        private Panel panelToPrint;
        public Frm_inChiTietHoaDon()
        {
            InitializeComponent();
            panelToPrint = panelPrint;
            this.WindowState = FormWindowState.Maximized;
        }

        private string ChuoiTien(string chuoiSo)
        {
            if (double.TryParse(chuoiSo, out double soTien))
            {
                // Chuyển đổi số thành chuỗi tiền tệ với dấu phẩy phân tách hàng nghìn
                string tienChuoi = soTien.ToString("N0"); // "N0" là định dạng cho số nguyên, dấu phẩy phân tách hàng nghìn
                return tienChuoi;
            }
            else
            {
                return chuoiSo;
            }
        }

        private void HienThongTin()
        {
            try
            {
                // Thực hiện truy vấn SELECT để lấy dữ liệu từ cơ sở dữ liệu
                string query = $"SELECT khachhang.MaKH ,TenKH, DiaChiKH, SoDienThoaiKH, MaHD ,NgayLapHD , hoadon.TongTien , nhanvien.TenNV FROM hoadon, khachhang, nhanvien where hoadon.MaNV = nhanvien.MaNV and  hoadon.MaKH = khachhang.MaKH AND hoadon.MaHD = '{MaHD}'";

                // Gọi hàm ThucHienTruyVan để lấy giá trị từ cơ sở dữ liệu
                DataTable dataTable = ketnoi.ThucHienTruyVan(query);

                // Kiểm tra xem có dữ liệu hay không
                if (dataTable != null)
                {

                    // Đặt giá trị lên Label
                    lbMaHD.Text = dataTable.Rows[0]["MaHD"].ToString();
                    lbNgayLap.Text = dataTable.Rows[0]["NgayLapHD"].ToString();
                    lbTenKH.Text = dataTable.Rows[0]["TenKH"].ToString();
                    lbDiaChiKH.Text = dataTable.Rows[0]["DiaChiKH"].ToString();
                    lbMaKH.Text = dataTable.Rows[0]["MaKH"].ToString();
                    lbSoDienThoaiKH.Text = dataTable.Rows[0]["SoDienThoaiKH"].ToString();
                    lbTenNV.Text = dataTable.Rows[0]["TenNV"].ToString();

                    lbTongTien.Text = ChuoiTien(dataTable.Rows[0]["TongTien"].ToString()) + " VND ";
                    lbBangChu.Text = NumberToText(double.Parse(dataTable.Rows[0]["TongTien"].ToString()));
                }
                else
                {
                    // Không tìm thấy dữ liệu
                    MessageBox.Show("Không có dữ liệu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void HienChiTietSanPham()
        {
            // Thực hiện truy vấn SELECT để lấy dữ liệu từ cơ sở dữ liệu
            string truyVan = $"SELECT ROW_NUMBER() OVER (ORDER BY MaSP) AS STT, sanpham.MaSP, sanpham.TenSP, chitiethoadon.GiaSP,chitiethoadon.SoLuongMua, chitiethoadon.ThanhTien FROM hoadon, chitiethoadon, sanpham,nhanvien where hoadon.MaHD = chitiethoadon.MaHD and chitiethoadon.MaSP = sanpham.MaSP and hoadon.MaHD = '{MaHD}' and hoadon.MaNV = nhanvien.MaNV";

            // Gọi hàm ThucHienTruyVan để lấy dữ liệu từ cơ sở dữ liệu và hiển thị trong DataGridView
            DataTable dataTable = ketnoi.ThucHienTruyVan(truyVan);
            dgvChiTietDonHang.DataSource = dataTable;
            dgvChiTietDonHang.ClearSelection();
        }

        private void Frm_inChiTietHoaDon_Load(object sender, EventArgs e)
        {
            dgvChiTietDonHang.ClearSelection();
            dgvChiTietDonHang.Columns["GiaSP"].DefaultCellStyle.Format = "N0";
            dgvChiTietDonHang.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            dgvChiTietDonHang.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChiTietDonHang.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChiTietDonHang.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvChiTietDonHang.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChiTietDonHang.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChiTietDonHang.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            HienChiTietSanPham();
            HienThongTin();
        }

        private void pictureBoxPrint_MouseHover(object sender, EventArgs e)
        {
            toolTipPrint.SetToolTip(pictureBoxPrint, "In hóa đơn");
        }

        private void pictureBoxPrint_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintPage;
            printDocument.DefaultPageSettings.Landscape = false; // Đặt ngang hay dọc tùy thuộc vào yêu cầu

            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;

            printPreviewDialog.ShowDialog();
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            // Vẽ nội dung Panel lên trang in
            Bitmap bmp = new Bitmap(panelToPrint.Width, panelToPrint.Height);
            panelToPrint.DrawToBitmap(bmp, new Rectangle(0, 0, panelToPrint.Width, panelToPrint.Height));

            // Đặt kích thước trang in
            e.Graphics.DrawImage(bmp, e.PageBounds);
        }


        // chuyển tổng tiền thành chữ 
        public static string NumberToText(double inputNumber, bool suffix = false)
        {
            string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };
            bool isNegative = false;

            if (inputNumber == 0)
            {
                return "Không đồng";
            }

            // -12345678.3445435 => "-12345678"
            string sNumber = inputNumber.ToString("#");
            double number = Convert.ToDouble(sNumber);
            if (number < 0)
            {
                number = -number;
                sNumber = number.ToString();
                isNegative = true;
            }


            int ones, tens, hundreds;

            int positionDigit = sNumber.Length;   // last -> first

            string result = " ";


            if (positionDigit == 0)
                result = unitNumbers[0] + result;
            else
            {
                // 0:       ###
                // 1: nghìn ###,###
                // 2: triệu ###,###,###
                // 3: tỷ    ###,###,###,###
                int placeValue = 0;

                while (positionDigit > 0)
                {
                    // Check last 3 digits remain ### (hundreds tens ones)
                    tens = hundreds = -1;
                    ones = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                    positionDigit--;
                    if (positionDigit > 0)
                    {
                        tens = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                        positionDigit--;
                        if (positionDigit > 0)
                        {
                            hundreds = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                    }

                    if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
                        result = placeValues[placeValue] + result;

                    placeValue++;
                    if (placeValue > 3) placeValue = 1;

                    if ((ones == 1) && (tens > 1))
                        result = "một " + result;
                    else
                    {
                        if ((ones == 5) && (tens > 0))
                            result = "lăm " + result;
                        else if (ones > 0)
                            result = unitNumbers[ones] + " " + result;
                    }
                    if (tens < 0)
                        break;
                    else
                    {
                        if ((tens == 0) && (ones > 0)) result = "lẻ " + result;
                        if (tens == 1) result = "mười " + result;
                        if (tens > 1) result = unitNumbers[tens] + " mươi " + result;
                    }
                    if (hundreds < 0) break;
                    else
                    {
                        if ((hundreds > 0) || (tens > 0) || (ones > 0))
                            result = unitNumbers[hundreds] + " trăm " + result;
                    }
                    result = " " + result;
                }
            }
            result = result.Trim();
            if (isNegative) result = "Âm " + result;

            result = result.Length > 0 ? char.ToUpper(result[0]) + result.Substring(1) : result;
            //  return result + (suffix ? " đồng chẵn" : "");
            return result + " đồng ";
        }
    }
}
