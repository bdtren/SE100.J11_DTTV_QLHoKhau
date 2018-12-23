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
    public class AdminBUS:AbstractFormBUS<Admin>
    {
        AdminDAO objadmin = new AdminDAO();
        public override DataSet GetAll()
        {
            return objadmin.getAll();
        }
        public override bool Add(Admin ad)
        {
            return objadmin.insert(ad);
        }
        public override bool Delete(int r)
        {
            return objadmin.delete(r);
        }
        public override bool Update(Admin ad, int r)
        {
            return objadmin.update(ad, r);
        }
    }
}
