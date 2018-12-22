using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QuanHe
    {
        public string MaQuanHe { get; set; }
        public string TenQuanHe { get; set; }
        public QuanHe() { }

        public QuanHe(string maQuanHe, string tenQuanHe)
        {
            MaQuanHe = maQuanHe;
            TenQuanHe = tenQuanHe;
        }
    }
}
