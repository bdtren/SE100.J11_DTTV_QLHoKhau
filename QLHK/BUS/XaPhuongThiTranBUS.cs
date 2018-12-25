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
    public class XaPhuongThiTranBUS: AbstractFormBUS<XaPhuongThiTranDTO>
    {
        XaPhuongThiTranDAO objtp = new XaPhuongThiTranDAO();

        public override DataSet GetAll()
        {
            return objtp.getAll();
        }
        public override bool Add(XaPhuongThiTranDTO data)
        {
            return objtp.insert(data);
        }

        public override bool Delete(int r)
        {
            return objtp.delete(r);
        }

        public override bool Update(XaPhuongThiTranDTO data, int r)
        {
            return objtp.update(data, r);
        }
    }
}
