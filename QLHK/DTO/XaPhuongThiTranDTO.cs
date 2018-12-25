﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class XaPhuongThiTranDTO
    {
        public string MaXa { get; set; }
        public string Ten { get; set; }
        public string Kieu { get; set; }
        public string MaQH { get; set; }


        public XaPhuongThiTranDTO() { }
        public XaPhuongThiTranDTO(string maxa, string ten, string kieu, string maqh)
        {
            this.MaXa = maxa;
            this.Ten = ten;
            this.Kieu = kieu;
            this.MaQH = maqh;
        }
    }
}
