using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SoHoKhauDTO
    {
        public string SoSoHoKhau { get; set; }
        public string MaChuHoThuongTru { get; set; }
        public string DiaChi { get; set; }
        public DateTime  NgayCap { get; set; }
        public string SoDangKy { get; set; }
        public List<NhanKhauThuongTruDTO> NhanKhau { get; set; }

        public SoHoKhauDTO() {
            NhanKhau = new List<NhanKhauThuongTruDTO>();
        }

        public SoHoKhauDTO(string soSoHoKhau, string maChuHoThuongTru, string diaChi, 
            DateTime ngayCap, string soDangKy, List<NhanKhauThuongTruDTO> nhanKhau)
        {
            SoSoHoKhau = soSoHoKhau;
            MaChuHoThuongTru = maChuHoThuongTru;
            DiaChi = diaChi;
            NgayCap = ngayCap;
            SoDangKy = soDangKy;
            NhanKhau = nhanKhau;
        }
        public SoHoKhauDTO(string soSoHoKhau, string maChuHoThuongTru, string diaChi,
            DateTime ngayCap, string soDangKy)
        {
            SoSoHoKhau = soSoHoKhau;
            MaChuHoThuongTru = maChuHoThuongTru;
            DiaChi = diaChi;
            NgayCap = ngayCap;
            SoDangKy = soDangKy;
            NhanKhau = new List<NhanKhauThuongTruDTO>();
        }

    }
}
