using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CanBo: NhanKhauThuongTruDTO
    {
        public string MaCanBo { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string LoaiCanBo { get; set; }

        public CanBo() : base() { }

        public CanBo(string maCanBo, string tenTaiKhoan, string matKhau, string loaiCanBo, string str_manhankhauthuongtru)
        {
            MaCanBo = maCanBo;
            TenTaiKhoan = tenTaiKhoan;
            MatKhau = matKhau;
            LoaiCanBo = loaiCanBo;
            MaNhanKhauThuongTru = str_manhankhauthuongtru;
        }
    }
}
