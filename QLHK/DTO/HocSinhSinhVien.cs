using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HocSinhSinhVien
    {
        public string MSSV { get; set; }
        public string MaNhanKhau { get; set; }
        public string Truong { get; set; }
        public string DiaChiThuongTru { get; set; }
        public DateTime TGBDTT { get; set; }
        public DateTime TGKTTT { get; set; }
        public string ViPham { get; set; }

        public HocSinhSinhVien() { }

        public HocSinhSinhVien(string maNhanKhau, string mSSV, string truong, string diaChiThuongTru, DateTime tGBDTT, DateTime tGKTTT, string viPham)
        {
            MSSV = mSSV;
            MaNhanKhau = maNhanKhau;
            Truong = truong;
            DiaChiThuongTru = diaChiThuongTru;
            TGBDTT = tGBDTT;
            TGKTTT = tGKTTT;
            ViPham = viPham;
        }
    }
}
