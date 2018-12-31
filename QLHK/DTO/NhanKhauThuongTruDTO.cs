using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanKhauThuongTruDTO:NhanKhau
    {
        public string MaNhanKhauThuongTru { get; set; }
        public string DiaChiThuongTru { get; set; }
        public string QuanHeChuHo { get; set; }
        public string SoSoHoKhau { get; set; }


        public NhanKhauThuongTruDTO() { }

        public NhanKhauThuongTruDTO(string maNhanKhauThuongTru, string diaChiThuongTru, 
            string quanHeChuHo, string soSoHoKhau, string maDinhDanh)
        {
            MaNhanKhauThuongTru = maNhanKhauThuongTru;
            DiaChiThuongTru = diaChiThuongTru;
            QuanHeChuHo = quanHeChuHo;
            SoSoHoKhau = soSoHoKhau;
            MaDinhDanh = maDinhDanh;
        }

        public NhanKhauThuongTruDTO(string maNhanKhauThuongTru, string diaChiThuongTru,
            string quanHeChuHo, string soSoHoKhau,
             string maDinhDanh, string hoTen, string tenKhac, DateTime ngaySinh,
             string gioiTinh, string noiSinh, string nguyenQuan, string danToc, string tonGiao,
             string quocTich, string hoChieu, string noiThuongTru, string diaChiHienNay,
             string sDT, string trinhDoHocVan, string trinhDoChuyenMon, string bietTiengDanToc,
             string trinhDoNgoaiNgu, string ngheNghiep) : base(maDinhDanh, hoTen, tenKhac, ngaySinh, gioiTinh,
                 noiSinh, nguyenQuan, danToc, tonGiao, quocTich, hoChieu, noiThuongTru, diaChiHienNay, sDT, trinhDoHocVan,
                 trinhDoChuyenMon, bietTiengDanToc, trinhDoNgoaiNgu, ngheNghiep)
        {
            MaNhanKhauThuongTru = maNhanKhauThuongTru;
            DiaChiThuongTru = diaChiThuongTru;
            QuanHeChuHo = quanHeChuHo;
            SoSoHoKhau = soSoHoKhau;
        }
    }
}
