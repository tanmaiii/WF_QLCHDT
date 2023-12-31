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
    public partial class Frm_Main : Form
    {
        public EventHandler Logout;
        public Frm_Main()
        {
            InitializeComponent();
        }

        private Form currentFormChill;

        private void OpenChildForm(Form childForm)
        {
            if(currentFormChill != null)
            {
                currentFormChill.Close();
            }
            currentFormChill = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pn_body.Controls.Add(childForm);
            pn_body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void PhanQuyen()
        {
            // false là không phải admin
            if (Const.TaiKhoan.LoaiNV == false)
            {
                btn_nhanvien.Visible = false;
                btn_thongke.Visible = false;
            }

            lbTenNV.Text = Const.TaiKhoan.TenNV.ToString();
            lbChucVu.Text = Const.TaiKhoan.LoaiNV == false ? "Nhân viên" : "Quản lý";
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_trangChu());
            lb_tieuDe.Text = "Trang chủ";
            PhanQuyen();
        }

        private void btn_trangchu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_trangChu());
            lb_tieuDe.Text = "Trang chủ";
        }

        private void btn_sanpham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_sanPham());
            lb_tieuDe.Text = "Sản phẩm";
        }

        private void btn_nhacungcap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_nhaCungCap());
            lb_tieuDe.Text = "Nhà cung cấp";
        }

        private void btb_donhang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_thanhToan());
            lb_tieuDe.Text = "Thanh toán";
        }

        private void btn_nhanvien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_nhanVien());
            lb_tieuDe.Text = "Nhân viên";
        }

        private void btn_thongke_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_thongKe());
            lb_tieuDe.Text = "Thống kê";
        }

        private void btn_hoadon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_hoaDon());
            lb_tieuDe.Text = "Hóa đơn";
        }

        private void btn_khohang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_dsNhapHang());
            lb_tieuDe.Text = "Danh sách đơn nhập hàng";
        }


        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Logout(this, new EventArgs());
        }
    }
}
