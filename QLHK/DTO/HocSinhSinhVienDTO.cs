using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HocSinhSinhVienDTO : NgheNghiepDTO
    {
        public string MSSV { get; set; }
        public string MaDinhDanh { get; set; }
        public string Truong { get; set; }
        public string DiaChiThuongTru { get; set; }
        public DateTime TGBDTTTT { get; set; }
        public DateTime TGKTTTTT { get; set; }
        public string ViPham { get; set; }

        public HocSinhSinhVienDTO() : base() { }

        public HocSinhSinhVienDTO(string mSSV, string maDinhDanh, string truong, string diaChiThuongTru, DateTime tGBDTTTT, DateTime tGKTTTTT, string viPham)
        {
            MSSV = mSSV;
            MaDinhDanh = maDinhDanh;
            Truong = truong;
            DiaChiThuongTru = diaChiThuongTru;
            TGBDTTTT = tGBDTTTT;
            TGKTTTTT = tGKTTTTT;
            ViPham = viPham;
            MaNgheNghiep = "HSSV001";
            TenNgheNghiep = "Hoc Sinh Sinh Vien";
        }
    }
}
