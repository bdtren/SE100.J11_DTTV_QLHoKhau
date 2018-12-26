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

        public NhanKhauTamTruDTO(string MaNgheNghiep, string HoTen, string GioiTinh, string DanToc, string HoChieu, 
            DateTime NgayCap, DateTime NgaySinh, string NguyenQuan, string NoiCap, string NoiSinh, string QuocTich, 
            string SDT, string TonGiao, string MaNhanKhauTamTru, string MaDinhDanh, string DiaChiThuongTru, 
            string SoSoTamTru)
        {
            this.MaNgheNghiep = MaNgheNghiep;
            this.HoTen = HoTen;
            this.TonGiao = TonGiao;
            this.DanToc = DanToc;
            this.HoChieu = HoChieu;
            this.NgayCap = NgayCap;
            this.NgaySinh = NgaySinh;
            this.NguyenQuan = NguyenQuan;
            this.NoiCap = NoiCap;
            this.NoiSinh = NoiSinh;
            this.NoiSinh = NoiSinh;
            this.QuocTich = QuocTich;
            this.SDT = SDT;
            this.TonGiao = TonGiao;
            this.MaNhanKhauTamTru = MaNhanKhauTamTru;
            this.MaDinhDanh = MaDinhDanh;
            this.DiaChiThuongTru = DiaChiThuongTru;
            this.SoSoTamTru = SoSoTamTru;
        }




    }
}
