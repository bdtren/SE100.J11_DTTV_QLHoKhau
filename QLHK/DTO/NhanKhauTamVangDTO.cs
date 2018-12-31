using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanKhauTamVangDTO
    {
        public string MaNhanKhauTamVang { get; set; }
        public string MaDinhdDanh { get; set; }
        public DateTime NgayBatDauTamVang { get; set; }
        public DateTime NgayKetThucTamVang { get; set; }
        public string LyDo { get; set; }
        public string NoiDen { get; set; }

        public NhanKhauTamVangDTO() { }

        public NhanKhauTamVangDTO(string maNhanKhauTamVang, string maDinhdDanh, DateTime ngayBatDauTamVang, DateTime ngayKetThucTamVang, 
            string lyDo, string noiDen)
        {
            MaNhanKhauTamVang = maNhanKhauTamVang;
            MaDinhdDanh = maDinhdDanh;
            NgayBatDauTamVang = ngayBatDauTamVang;
            NgayKetThucTamVang = ngayKetThucTamVang;
            LyDo = lyDo;
            NoiDen = noiDen;
        }
    }
}
