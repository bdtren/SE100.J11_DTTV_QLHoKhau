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
    public class QuanHuyenBUS: AbstractFormBUS<QuanHuyenDTO>
    {
        QuanHuyenDAO objtp = new QuanHuyenDAO();

        public override DataSet GetAll()
        {
            return objtp.getAll();
        }
        public override bool Add(QuanHuyenDTO data)
        {
            return objtp.insert(data);
        }

        public override bool Delete(int r)
        {
            return objtp.delete(r);
        }

        public override bool Update(QuanHuyenDTO data, int r)
        {
            return objtp.update(data, r);
        }
    }
}
