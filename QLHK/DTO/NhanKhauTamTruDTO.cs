using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanKhauTamTruDTO : NhanKhau
    {
        public string MaNhanKhauTamTru { get; set; }
        public string MaDinhDanh { get; set; }
        public string DiaChiThuongTru { get; set; }
        public string SoSoTamTru { get; set; }

        public NhanKhauTamTruDTO() : base() { }

        public NhanKhauTamTruDTO(string MaNhanKhauTamTru, string MaDinhDanh, string DiaChiThuongTru, string SoSoTamTru)
        {
            this.MaNhanKhauTamTru = MaNhanKhauTamTru;
            this.MaDinhDanh = MaDinhDanh;
            this.DiaChiThuongTru = DiaChiThuongTru;
            this.SoSoTamTru = SoSoTamTru;
        }
    }
}
