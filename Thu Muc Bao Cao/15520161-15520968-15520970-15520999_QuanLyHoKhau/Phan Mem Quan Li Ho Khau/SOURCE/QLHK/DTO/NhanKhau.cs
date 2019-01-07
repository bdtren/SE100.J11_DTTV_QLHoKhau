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
        public string TenKhac { get; set; }
        public DateTime NgaySinh { get; set; }
        public string  GioiTinh { get; set; }
        public string NoiSinh { get; set; }
        public string NguyenQuan { get; set; }
        public string DanToc { get; set; }
        public string TonGiao { get; set; }
        public string QuocTich { get; set; }
        public string HoChieu { get; set; }
        public string NoiThuongTru { get; set; }
        public string DiaChiHienNay { get; set; }
        public string SDT { get; set; }
        public string TrinhDoHocVan { get; set; }
        public string TrinhDoChuyenMon { get; set; }
        public string BietTiengDanToc { get; set; }
        public string TrinhDoNgoaiNgu { get; set; }
        public string NgheNghiep { get; set; }

        public NhanKhau() { }

        public NhanKhau(string maDinhDanh, string hoTen, string tenKhac, DateTime ngaySinh, 
            string gioiTinh, string noiSinh, string nguyenQuan, string danToc, string tonGiao, 
            string quocTich, string hoChieu, string noiThuongTru, string diaChiHienNay, 
            string sDT, string trinhDoHocVan, string trinhDoChuyenMon, string bietTiengDanToc, 
            string trinhDoNgoaiNgu, string ngheNghiep)
        {
            MaDinhDanh = maDinhDanh;
            HoTen = hoTen;
            TenKhac = tenKhac;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            NoiSinh = noiSinh;
            NguyenQuan = nguyenQuan;
            DanToc = danToc;
            TonGiao = tonGiao;
            QuocTich = quocTich;
            HoChieu = hoChieu;
            NoiThuongTru = noiThuongTru;
            DiaChiHienNay = diaChiHienNay;
            SDT = sDT;
            TrinhDoHocVan = trinhDoHocVan;
            TrinhDoChuyenMon = trinhDoChuyenMon;
            BietTiengDanToc = bietTiengDanToc;
            TrinhDoNgoaiNgu = trinhDoNgoaiNgu;
            NgheNghiep = ngheNghiep;
        }
    }
}
