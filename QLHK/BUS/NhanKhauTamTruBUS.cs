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
    public class NhanKhauTamTruBUS: AbstractFormBUS<NhanKhauTamTruDTO>
    {
        NhanKhauTamTruDAO objnktt = new NhanKhauTamTruDAO();
        public override DataSet GetAll()
        {
            return objnktt.getAll();
        }
        public override bool Add(NhanKhauTamTruDTO hssv)
        {
            return objnktt.insert(hssv);
        }

        public bool XoaHSSV(string mssv)
        {
            return objnktt.XoaHHSV(mssv);
        }
        public override bool Delete(int r)
        {
            return objnktt.delete(r);
        }
        public override bool Update(NhanKhauTamTruDTO hssv, int r)
        {
            return objnktt.update(hssv, r);
        }

        public DataSet TimKiem(string mssv)
        {
            return objnktt.TimKiem(mssv);
        }
    }
}
