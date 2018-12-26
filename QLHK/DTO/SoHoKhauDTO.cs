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
        public string MaChuHo { get; set; }
        public string DiaChi { get; set; }
        public DateTime  NgayCap { get; set; }
        public string SoDangKy { get; set; }

        public List<NhanKhauThuongTruDTO> NhanKhau { get; set; }

        public SoHoKhauDTO() {
            NhanKhau = new List<NhanKhauThuongTruDTO>();

        }
        public SoHoKhauDTO(string sosohokhau,string machuho, string diachi, DateTime ngaycap, string sodangky)
        {
            this.SoSoHoKhau = sosohokhau;
            this.MaChuHo = machuho;
            this.DiaChi = diachi;
            this.NgayCap = ngaycap;
            this.SoDangKy = sodangky;
            NhanKhau = new List<NhanKhauThuongTruDTO>();
        }
        public SoHoKhauDTO(string sosohokhau, string diachi, DateTime ngaycap, string sodangky, List<NhanKhauThuongTruDTO> nhankhau)
        {
            this.SoSoHoKhau = sosohokhau;
            this.MaChuHo = nhankhau[0].MaDinhDanh;
            this.DiaChi = diachi;
            this.NgayCap = ngaycap;
            this.SoDangKy = sodangky;

            this.NhanKhau = nhankhau;
        }
    }
}
