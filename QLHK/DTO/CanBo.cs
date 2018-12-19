using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CanBo
    {
        public string MaCanBo { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }

        public CanBo() { }
        public CanBo(string maCanBo, string tenDangNhap, string matKhau)
        {
            MaCanBo = maCanBo;
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
        }
    }
}
