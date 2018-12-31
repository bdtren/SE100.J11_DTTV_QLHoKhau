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
    public class CanBoBUS:AbstractFormBUS<CanBo>
    {
        CanBoDAO objcb = new CanBoDAO();
        public override DataSet GetAll()
        {
            return objcb.getAll();
        }
        public override bool Add(CanBo cb)
        {
            return objcb.insert(cb);
        }
        public override bool Delete(int row)
        {
            return objcb.delete(row);
        }
        public override bool Update(CanBo cb, int r)
        {
            return objcb.update(cb, r);
        }
        public override bool Add_Table(CanBo data)
        {
            return objcb.insert_table(data);
        }
    }
}
