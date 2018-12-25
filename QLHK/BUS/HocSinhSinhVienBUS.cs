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
    public class HocSinhSinhVienBUS: AbstractFormBUS<HocSinhSinhVienDTO>
    {
        HocSinhSinhVienDAO objhssv = new HocSinhSinhVienDAO();
        public override DataSet GetAll()
        {
            return objhssv.getAll();
        }
        public override bool Add(HocSinhSinhVienDTO hssv)
        {
            return objhssv.insert(hssv);
        }
        public bool XoaHSSV(string mssv)
        {
            return objhssv.XoaHHSV(mssv);
        }
        public override bool Delete(int r)
        {
            return objhssv.delete(r);
        }
        public override bool Update(HocSinhSinhVienDTO hssv, int r)
        {
            return objhssv.update(hssv, r);
        }

        public DataSet TimKiem(string query)
        {
            return objhssv.TimKiem(query);
        }
        public override bool Add_Table(HocSinhSinhVienDTO hssv)
        {
            return objhssv.insert_table(hssv);
        }
    }
}
