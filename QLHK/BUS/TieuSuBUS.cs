﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;

namespace BUS
{
    public class TieuSuBUS : AbstractFormBUS<TieuSuDTO>
    {
        public TieuSuBUS() : base() { }
        TieuSuDAO tieusu = new TieuSuDAO();

        public override DataSet GetAll()
        {
            return tieusu.getAll();
        }

        public override bool Add(TieuSuDTO data)
        {
            return tieusu.insert(data);
        }

        public override bool Add_Table(TieuSuDTO data)
        {
            return tieusu.insert_table(data);
        }

        public override bool Delete(int r)
        {
            return tieusu.delete(r);
        }

        public override bool Update(TieuSuDTO data, int r)
        {
            return tieusu.update(data, r);
        }

        public DataSet TimKiem(string query)
        {
            return tieusu.TimKiem(query);
        }
    }
}
