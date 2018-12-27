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
    public class TinhThanhPhoBUS: AbstractFormBUS<TinhThanhPhoDTO>
    {
        TinhThanhPhoDAO objtp = new TinhThanhPhoDAO();

        public override DataSet GetAll()
        {
            return objtp.getAll();
        }
        public override bool Add(TinhThanhPhoDTO data)
        {
            return objtp.insert(data);
        }

        public override bool Delete(int r)
        {
            return objtp.delete(r);
        }

        public override bool Update(TinhThanhPhoDTO data, int r)
        {
            return objtp.update(data, r);
        }
        public override bool Add_Table(TinhThanhPhoDTO data)
        {
            throw new NotImplementedException();

        }

    }
}
