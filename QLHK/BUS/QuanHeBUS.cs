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
    public class QuanHeBUS:AbstractFormBUS<QuanHe>
    {

        QuanHeDAO objquanhe = new QuanHeDAO();
        public override DataSet GetAll()
        {
            return objquanhe.getAll();
        }
        public override bool Add(QuanHe qh)
        {
            return objquanhe.insert(qh);
        }
        public override bool Delete(int r)
        {
            return objquanhe.delete(r);
        }
        public override bool Update(QuanHe qh, int r)
        {
            return objquanhe.update(qh, r);
        }
    }
}
