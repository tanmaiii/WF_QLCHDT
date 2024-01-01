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
    public partial class Frm_loaiSP : Form
    {
        KetNoiMySql ketNoi = new KetNoiMySql();
        DataTable bangDuLieu = new DataTable();
        int donghh;

        public Frm_loaiSP()
        {
            InitializeComponent();
        }

        void HienThiDuLieu()
        {
            string mysql = "select* from loai";
            bangDuLieu = ketNoi.ThucHienTruyVan(mysql);//goi ham trong lớp
            dgvLoai.DataSource = bangDuLieu;
        }


        private void Reset()
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            tbMaLoai.Enabled = true;
            HienThiDuLieu();
            tbTenLoai.Clear();
            tbMaLoai.Clear();
        }


        private void Frm_loaiSP_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private bool KiemTraRong()
        {
            if (string.IsNullOrEmpty(tbMaLoai.Text) || string.IsNullOrEmpty(tbTenLoai.Text))
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
            string kiemTraTonTai = $"SELECT COUNT(*) FROM loai WHERE MaLoai = '{tbMaLoai.Text}'";
            int count = Convert.ToInt32(ketNoi.ThucHienTruyVan(kiemTraTonTai).Rows[0][0]);

            if (count > 0)
            {
                MessageBox.Show("Mã loại đã tồn tại. Vui lòng chọn mã khác.");
            }
            else
            {
                string lenhInsert = $"INSERT INTO loai (MaLoai, TenLoai) VALUES ('{tbMaLoai.Text}', '{tbTenLoai.Text}')";
                ketNoi.ThucHienLenh(lenhInsert);
                HienThiDuLieu();
                MessageBox.Show("Thêm loại sp thành công!");
                Reset();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!KiemTraRong()) return;

            // Cập nhật vào CSDL
            string lenhUpdate = $"UPDATE loai SET TenLoai = '{tbTenLoai.Text}' WHERE MaLoai = '{tbMaLoai.Text}'";
            ketNoi.ThucHienLenh(lenhUpdate);

            // Hiển thị thông báo
            MessageBox.Show("Cập nhật thông tin thành công!");
            Reset();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có sản phẩm liên quan không
            string kiemTraSPLienQuan = $"SELECT COUNT(*) FROM sanpham WHERE MaLoai = '{tbMaLoai.Text}'";
            int countSPLienQuan = Convert.ToInt32(ketNoi.ThucHienTruyVan(kiemTraSPLienQuan).Rows[0][0]);

            if (countSPLienQuan > 0)
            {
                // Có sản phẩm liên quan, hiển thị hộp thoại cảnh báo
                MessageBox.Show("Có sản phẩm liên quan đến loại này. Không thể xoá!");
                return;
            }
            if (KiemTraRong()) // Đảm bảo rằng đã chọn một dòng để xóa
            {
                string lenhDelete = $"DELETE FROM loai WHERE MaLoai = '{tbMaLoai.Text}'";
                ketNoi.ThucHienLenh(lenhDelete);
                HienThiDuLieu();
                MessageBox.Show("Xoá loại sp thành công!");
                Reset();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }

        private void dgvLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            donghh = e.RowIndex;
            if(donghh >= 0) {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                tbMaLoai.Enabled = false;
                tbMaLoai.Text = dgvLoai.Rows[donghh].Cells["MaLoai"].Value.ToString();
                tbTenLoai.Text = dgvLoai.Rows[donghh].Cells["TenLoai"].Value.ToString();
            }
        }
    }
}
