using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class AdminBUS
    {
        AdminDAO objadmin = new AdminDAO();
        public DataSet GetAllAdmin()
        {
            return objadmin.GetAllAdmin();
        }
        public bool AddAdmin(Admin ad)
        {
            return objadmin.AddAdmin(ad);
        }
        public bool XoaAdmin(int r)
        {
            return objadmin.XoaAdmin(r);
        }
        public bool SuaAdmin(Admin ad, int r)
        {
            return objadmin.SuaAdmin(ad, r);
        }
    }
}
