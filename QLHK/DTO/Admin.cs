using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Admin
    {
        public string MaCanBo { get; set; }
        public string MaBaoMat { get; set; }

        public Admin() { }

        public Admin(string maCanBo, string maBaoMat)
        {
            MaCanBo = maCanBo;
            MaBaoMat = maBaoMat;
        }
    }
}
