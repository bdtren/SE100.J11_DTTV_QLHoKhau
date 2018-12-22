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
    public class QuanHeBUS
    {

        QuanHeDAO objquanhe = new QuanHeDAO();
        public DataSet GetAllQuanHe()
        {
            return objquanhe.GetAllQuanHe();
        }
        public bool AddQuanHe(QuanHe qh)
        {
            return objquanhe.AddQuanHe(qh);
        }
        public bool XoaQuanHe(int r)
        {
            return objquanhe.XoaQuanHe(r);
        }
        public bool SuaQuanHe(QuanHe qh, int r)
        {
            return objquanhe.SuaQuanHe(qh, r);
        }
    }
}
