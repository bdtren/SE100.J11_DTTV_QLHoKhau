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
    public class NhanVienBUS:AbstractFormBUS<NhanVien>
    {
        NhanVienDAO objnvdao = new NhanVienDAO();
        public override DataSet GetAll()
        {
            return objnvdao.getAll();
        }
        public override bool Add(NhanVien nv)
        {
            return objnvdao.insert(nv);
        }
        public override bool Delete(int r)
        {
            return objnvdao.delete(r);
        }
        public override bool Update(NhanVien nv, int r)
        {
            return objnvdao.update(nv, r);
        }
    }
}
