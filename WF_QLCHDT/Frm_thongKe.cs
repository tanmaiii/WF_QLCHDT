using Org.BouncyCastle.Asn1.Cmp;
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
    public partial class Frm_thongKe : Form
    {
        public Frm_thongKe()
        {
            InitializeComponent();
        }
        private Form currentFormChill;

        private void OpenChildForm(Form childForm)
        {
            if (currentFormChill != null)
            {
                currentFormChill.Close();
            }
            currentFormChill = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnNoiDung.Controls.Add(childForm);
            pnNoiDung.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void ttDoanhThu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_tkDoanhThu());
        }

        private void ttSanPham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_tkSanPham());
        }

        private void Frm_thongKe_Load(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_tkDoanhThu());
        }
    }
}
