using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string GioiTinh { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public DateTime NgayVL { get; set; }

        public NhanVien() { }

        public NhanVien(string maNV, string hoTen, DateTime ngaySinh, string diaChi, string sDT, string gioiTinh, string email, string avatar, DateTime ngayVL)
        {
            MaNV = maNV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            SDT = sDT;
            GioiTinh = gioiTinh;
            Email = email;
            Avatar = avatar;
            NgayVL = ngayVL;
        }
    }
}
