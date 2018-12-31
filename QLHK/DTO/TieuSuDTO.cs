using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TieuSuDTO
    {
        public string MaTieuSu { get; set; }
        public string MaDinhDanh { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public string ChoO { get; set; }
        public string NgheNghiep { get; set; }
        public string NoiLamViec { get; set; }

        public TieuSuDTO() { }

        public TieuSuDTO(string maTieuSu, string maDinhDanh, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, string choO, string ngheNghiep, string noiLamViec)
        {
            MaTieuSu = maTieuSu;
            MaDinhDanh = maDinhDanh;
            ThoiGianBatDau = thoiGianBatDau;
            ThoiGianKetThuc = thoiGianKetThuc;
            ChoO = choO;
            NgheNghiep = ngheNghiep;
            NoiLamViec = noiLamViec;
        }
    }
}
