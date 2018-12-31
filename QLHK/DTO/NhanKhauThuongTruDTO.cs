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
        public string BietTiengDanToc { get; set; }
        public string DiaChiHienTai { get; set; }
        public string  maChuHo { get; set; }
        public string NoiLamViec { get; set; }
        public string NoiThuongTru { get; set; }
        public string QuanHeVoiChuHo { get; set; }
        public string TrinhDoChuyenMon { get; set; }
        public string TrinhDoNgoaiNgu { get; set; }
        public string TrinhDoHocVan { get; set; }
        public string SoSoHoKhau { get; set; }

        public NhanKhauThuongTruDTO() { }
        public NhanKhauThuongTruDTO(string maDinhDanh,string ngheNghiep, string hoTen, string gioiTinh, string danToc, string hoChieu, DateTime ngayCap,
            DateTime ngaySinh, string nguyenQuan, string noiCap, string noiSinh, string quocTich, string sDT, string tonGiao,

            string maNKThuongTru, string bietTiengDanToc, string diaChiHienTai, string maChuHo, string noiLamViec,
            string noiThuongTru, string quanHeVoiChuHo, string trinhDoChuyenMon, string trinhDoNgoaiNgu,
            string trinhDoHocVan, string soSoHoKhau): base(maDinhDanh, ngheNghiep, hoTen, gioiTinh, danToc, hoChieu, ngayCap, ngaySinh, nguyenQuan, noiCap, noiSinh, quocTich, sDT, tonGiao)
        {
            this.MaNhanKhauThuongTru = maNKThuongTru;
            this.BietTiengDanToc = bietTiengDanToc;
            this.DiaChiHienTai = diaChiHienTai;
            this.maChuHo = maChuHo;
            this.NoiLamViec = noiLamViec;
            this.NoiThuongTru = noiThuongTru;
            this.QuanHeVoiChuHo = quanHeVoiChuHo;
            this.TrinhDoChuyenMon = trinhDoChuyenMon;
            this.TrinhDoNgoaiNgu = trinhDoNgoaiNgu;
            this.TrinhDoHocVan = trinhDoHocVan;
            this.SoSoHoKhau = soSoHoKhau;
        }
    }
}
