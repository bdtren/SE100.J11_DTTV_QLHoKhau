using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanKhau
    {
        public string MaDinhDanh { get; set; }
        public string HoTen { get; set; }
        public string  GioiTinh { get; set; }
        public string DanToc { get; set; }
        public string HoChieu { get; set; }
        public DateTime NgayCap { get; set; }
        public DateTime NgaySinh { get; set; }
        public string NguyenQuan { get; set; }
        public string NoiCap { get; set; }
        public string NoiSinh { get; set; }
        public string QuocTich { get; set; }
        public string SDT { get; set; }
        public string TonGiao { get; set; }

        public NhanKhau() { }
        public NhanKhau(string maDinhDanh, string hoTen, string gioiTinh, string danToc, string hoChieu, DateTime ngayCap, DateTime ngaySinh, string nguyenQuan, string noiCap, string noiSinh, string quocTich, string sDT, string tonGiao)
        {
            MaDinhDanh = maDinhDanh;
            HoTen = hoTen;
            GioiTinh = gioiTinh;
            DanToc = danToc;
            HoChieu = hoChieu;
            NgayCap = ngayCap;
            NgaySinh = ngaySinh;
            NguyenQuan = nguyenQuan;
            NoiCap = noiCap;
            NoiSinh = noiSinh;
            QuocTich = quocTich;
            SDT = sDT;
            TonGiao = tonGiao;
        }
    }
}
