using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanKhauThuongTruDTO
    {
        public string BietTiengDanToc { get; set; }
        public string DiaChiHienTai { get; set; }
        public bool  LaChuHo { get; set; }
        public string NoiLamViec { get; set; }
        public string NoiThuongTru { get; set; }
        public string QuanHeVoiChuHo { get; set; }
        public string TrinhDoChuyenMon { get; set; }
        public string TrinhDoNgoaiNgu { get; set; }
        public string TrinhDoHocVan { get; set; }
        public string SoHoKhau { get; set; }

        public NhanKhauThuongTruDTO() { }
        public NhanKhauThuongTruDTO(string bietTiengDanToc, string diaChiHienTai, bool laChuHo, string noiLamViec,
            string noiThuongTru, string quanHeVoiChuHo, string trinhDoChuyenMon, string trinhDoNgoaiNgu,
            string trinhDoHocVan, string soHoKhau)
        {
            this.BietTiengDanToc = bietTiengDanToc;
            this.DiaChiHienTai = diaChiHienTai;
            this.LaChuHo = laChuHo;
            this.NoiLamViec = noiLamViec;
            this.NoiThuongTru = noiThuongTru;
            this.QuanHeVoiChuHo = quanHeVoiChuHo;
            this.TrinhDoChuyenMon = trinhDoChuyenMon;
            this.TrinhDoNgoaiNgu = trinhDoNgoaiNgu;
            this.TrinhDoHocVan = trinhDoHocVan;
            this.SoHoKhau = soHoKhau;
        }
    }
}
