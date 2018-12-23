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
