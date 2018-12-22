using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;

namespace BUS
{
    public class HocSinhSinhVienBUS
    {
        HocSinhSinhVienDAO objhssv = new HocSinhSinhVienDAO();
        public DataSet GetAllHSSV()
        {
            return objhssv.GetAllHSSV();
        }
        public bool AddHSSV(HocSinhSinhVien hssv)
        {
            return objhssv.AddHSSV(hssv);
        }
        public bool XoaHSSV(int r)
        {
            return objhssv.XoaHSSV(r);
        }
        public bool SuaHSSV(HocSinhSinhVien hssv, int r)
        {
            return objhssv.SuaHSSV(hssv, r);
        }

    }
}
