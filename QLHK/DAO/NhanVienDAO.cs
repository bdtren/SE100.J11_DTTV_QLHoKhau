using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using MySql.Data.MySqlClient;

namespace DAO
{
    public class NhanVienDAO: DBConnection
    {

        public NhanVienDAO(): base() { }
        public DataTable GetAllNhanVien()
        {
            string query = "SELECT * FROM NHANVIEN";
            return getQuery(query);
        }


    }
}
