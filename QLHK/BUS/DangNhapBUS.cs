﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public static class DangNhapBUS
    {
        static CanBoBUS cbBUS = new CanBoBUS();
        static CanBoDTO cb;
        public static bool TimKiem(string taikhoan, string matkhau)
        {
            DataTable tb = cbBUS.TimKiem("tentaikhoan='" + taikhoan + "' AND matkhau='" + matkhau + "'").Tables[0];
            if (tb.Rows.Count > 0)
            {
                DataRow dt = tb.Rows[0];
                return true;
            }

            return false;
        }
    }
}
