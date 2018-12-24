using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NgheNghiepDTO
    {
        public string MaNgheNghiep { get; set; }
        public string TenNgheNghiep { get; set; }

        public NgheNghiepDTO() { }

        public NgheNghiepDTO(string maNgheNghiep, string tenNgheNghiep)
        {
            MaNgheNghiep = maNgheNghiep;
            TenNgheNghiep = tenNgheNghiep;
        }
    }
}
