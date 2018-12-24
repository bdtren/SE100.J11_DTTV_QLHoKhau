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
    public class HocSinhSinhVienBUS:NgheNghiepBUS
    {
        HocSinhSinhVienDAO objHSSV = new HocSinhSinhVienDAO();
        public DataSet GetAllHSSV()
        {
            return objHSSV.GetAllHSSV();
        }
        public bool AddHSSV(HocSinhSinhVienDTO hssv)
        {
            return objHSSV.AddHSSV(hssv);
        }
        public bool XoaHSSV(string mssv)
        {
            return objHSSV.XoaHHSV(mssv);
        }
        public bool SuaHSSV(HocSinhSinhVienDTO hssv)
        {
            return objHSSV.SuaHSSV(hssv);
        }
        public DataSet TimKiem(string mssv)
        {
            return objHSSV.TimKiem(mssv);
        }
    }
}
