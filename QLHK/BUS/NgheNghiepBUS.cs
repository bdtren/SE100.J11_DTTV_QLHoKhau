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
    public class NgheNghiepBUS : AbstractFormBUS<NgheNghiepDTO>
    {
        NgheNghiepDAO objnghenghiep = new NgheNghiepDAO();

        public override bool Add(NgheNghiepDTO data)
        {
            return objnghenghiep.insert(data);
        }

        public override bool Add_Table(NgheNghiepDTO data)
        {
            return objnghenghiep.insert_table(data);
        }

        public override bool Delete(int r)
        {
            return objnghenghiep.delete(r);
        }

        public override DataSet GetAll()
        {
            return objnghenghiep.getAll();
        }

        public override bool Update(NgheNghiepDTO data, int r)
        {
            return objnghenghiep.update(data, r);
        }
    }
}
