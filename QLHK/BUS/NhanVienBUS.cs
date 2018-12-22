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
    public class NhanVienBUS
    {
        NhanVienDAO objnvdao = new NhanVienDAO();
        public DataSet GetAllNhanVien()
        {
            return objnvdao.GetAllNhanVien();
        }
        public bool AddNhanVien(NhanVien nv)
        {
            return objnvdao.AddNhanVien(nv);
        }
        public bool XoaNhanVien(int r)
        {
            return objnvdao.XoaNhanVien(r);
        }
        public bool SuaNhanVien(NhanVien nv, int r)
        {
            return objnvdao.SuaNhanVien(nv, r);
        }
    }
}
