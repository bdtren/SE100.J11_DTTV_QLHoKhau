using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DanToc
    {
        public string MaDanToc { get; set; }
        public string TenDanToc { get; set; }
        public DanToc() { }

        public DanToc(string maDanToc, string tenDanToc)
        {
            MaDanToc = maDanToc;
            TenDanToc = tenDanToc;
        }
    }
}
