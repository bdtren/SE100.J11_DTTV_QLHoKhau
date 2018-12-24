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
    public class NgheNghiepBUS
    {
        NgheNghiepDAO objnghenghiep = new NgheNghiepDAO();
        public DataSet GetAllNgheNghiep()
        {
            return objnghenghiep.getAll();
        }
        public bool AddNgheNghiep(NgheNghiepDTO nghenghiep)
        {
            return objnghenghiep.insert(nghenghiep);
        }
        public bool XoaNgheNghiep(string manghenghiep)
        {
            return objnghenghiep.XoaNgheNghiep(manghenghiep);
        }
        public bool SuaNgheNghiep(NgheNghiepDTO nghenghiep)
        {
            return objnghenghiep.update(nghenghiep, 1);
        }
    }
}
