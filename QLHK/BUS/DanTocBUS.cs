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
    public class DanTocBUS:AbstractFormBUS<DanToc>
    {
        DanTocDAO objDantoc = new DanTocDAO();
        public DanTocBUS() { }
        public override DataSet GetAll()
        {
            return objDantoc.getAll();
        }
        public override bool Add(DanToc dt)
        {
            return objDantoc.insert(dt);
        }
        public override bool Delete(int r)
        {
            return objDantoc.delete(r);
        }
        public override bool Update(DanToc dt, int r)
        {
            return objDantoc.update(dt, r);
        }
    }
}
