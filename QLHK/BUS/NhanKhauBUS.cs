
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
    public class NhanKhauBUS
    {
        NhanKhauDAO objnhankhau = new NhanKhauDAO();
        public DataSet GetAllNhanKhau()
        {
            return objnhankhau.GetAllNhanKhau();
        }
        public bool AddNhanKhau(NhanKhau nk)
        {
            return objnhankhau.AddNhanKhau(nk);
        }
        public bool XoaNhanKhau(string madinhdanh)
        {
            return objnhankhau.XoaNhanKhau(madinhdanh);
        }
        public bool SuaNhanKhau(NhanKhau nk)
        {
            return objnhankhau.SuaNhanKhau(nk);
        }
    }
}
