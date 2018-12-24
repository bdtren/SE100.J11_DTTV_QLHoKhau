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
    public class HocSinhSinhVienBUS: AbstractFormBUS<HocSinhSinhVien>
    {
        HocSinhSinhVienDAO objhssv = new HocSinhSinhVienDAO();
        public override DataSet GetAll()
        {
            return objhssv.getAll();
        }
        public override bool Add(HocSinhSinhVien hssv)
        {
            return objhssv.insert(hssv);
        }
        public override bool Delete(int r)
        {
            return objhssv.delete(r);
        }
        public override bool Update(HocSinhSinhVien hssv, int r)
        {
            return objhssv.update(hssv, r);
        }
    }
}
