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
    public partial class Frm_dangNhap : Form
    {
        KetNoiMySql ketNoi = new KetNoiMySql();

        public Frm_dangNhap()
        {
            InitializeComponent();
        }

        private bool KiemTraRong()
        {
            if (string.IsNullOrEmpty(tbTaiKhoanNV.Text) || string.IsNullOrEmpty(tbMatKhauNV.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return false;
            }
            return true;
        }

        private bool KiemTraDangNhap(string taikhoan, string matkhau)
        {
            if (KiemTraRong())
            {
                string query = $"SELECT * FROM nhanvien where TaiKhoanNV = '{taikhoan}'";

                DataTable kiemtraTaiKhoan = ketNoi.ThucHienTruyVan(query);

                // Nếu tồn tại tài khoản
                if (kiemtraTaiKhoan.Rows.Count > 0)
                {
                    string query2 = $"SELECT * FROM nhanvien where TaiKhoanNV = '{taikhoan}' and MatKhauNV = '{matkhau}' ";

                    DataTable kiemTraMatKhau = ketNoi.ThucHienTruyVan(query2);

                    // Kiểm tra mật khẩu
                    if (kiemTraMatKhau.Rows.Count > 0)
                    {

                        TaiKhoan tk = new TaiKhoan();
                        tk.TaiKhoanNV = kiemTraMatKhau.Rows[0]["TaiKhoanNV"].ToString();
                        tk.MatKhauNV = kiemTraMatKhau.Rows[0]["MatKhauNV"].ToString();
                        tk.TenNV = kiemTraMatKhau.Rows[0]["TenNV"].ToString();
                        tk.MaNV = kiemTraMatKhau.Rows[0]["MaNV"].ToString();

                        // Nếu loại tk = 1 thì là quản lý , 0 là nhân viên
                        tk.LoaiNV = kiemTraMatKhau.Rows[0]["LoaiNV"].ToString() == "1" ? true : false;
                      
                        // Lưu vào biến chung
                        Const.TaiKhoan = tk;

                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Sai mật khẩu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return false;
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            if (KiemTraDangNhap(tbTaiKhoanNV.Text.ToString(), tbMatKhauNV.Text.ToString()))
            {
                Frm_Main frmMain  = new Frm_Main();
               // Hiện form chính
                frmMain.Show();
               // Ẩn form đăng nhập
                this.Hide();
               //Tạo hàm đăng xuất 
                frmMain.Logout += Frm_dangXuat;
            }
        }

        // Khi hàm Logout từ form chính được chạy
        private void Frm_dangXuat(object sender, EventArgs e)
        {
            // xét isExit = false (Sẽ không đóng hoàn toàn chương trình)
            (sender as Frm_Main).isExit = false;
            // Đóng form chính
            (sender as Frm_Main).Close();
            tbMatKhauNV.Clear();
            tbTaiKhoanNV.Clear();
            //Hiện form đăng nhập
            this.Show();
        }

        private void Frm_dangNhap_Load(object sender, EventArgs e)
        {

        }

        private void checkBoxHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxHienMK.Checked)
            {
                tbMatKhauNV.UseSystemPasswordChar = false;
            }
            else{
                tbMatKhauNV.UseSystemPasswordChar = true;
            }
        }
    }
}
