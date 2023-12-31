using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_QLCHDT
{
    internal class TaiKhoan
    {
        public string TaiKhoanNV { get; set; }
        public string TenNV { get; set; }
        public string MatKhauNV { get; set; }
        public bool LoaiNV { get; set; }

        public TaiKhoan() { }

        public TaiKhoan(string TaiKhoanNV, string MatKhauNV, bool Loai)
        {
            this.LoaiNV = Loai;
            this.TaiKhoanNV = TaiKhoanNV;
            this.MatKhauNV = MatKhauNV;
            this.TenNV = TenNV; 
        }

    }
}
