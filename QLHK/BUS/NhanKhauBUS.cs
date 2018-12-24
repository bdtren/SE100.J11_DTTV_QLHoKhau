
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
    public class NhanKhauBUS:AbstractFormBUS<NhanKhau>
    {
        NhanKhauDAO objnhankhau = new NhanKhauDAO();
        public override DataSet GetAll()
        {
            return objnhankhau.getAll();
        }
        public override bool Add(NhanKhau nk)
        {
            return objnhankhau.insert(nk);
        }
          public override bool Delete(int madinhdanh)
        {
            return objnhankhau.delete(madinhdanh);
        }
        public override bool Update(NhanKhau nk, int r)
        {
            return objnhankhau.update(nk, r);
        }
        public bool Delete(string madinhdanh)
        {
            return false;
        }
        public bool Update(NhanKhau nk)
        {
            return false;
        }
    }
}
