using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using MySql.Data.MySqlClient;

namespace DAO
{
    public class NgheNghiepDAO: DBConnection
    {
        public NgheNghiepDAO() : base() { }
        public DataSet GetAllNgheNghiep()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();

                }
                sqlda = new MySqlDataAdapter("SELECT * FROM nghenghiep", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "nghenghiep");
                return dataset;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }
        public bool AddNgheNghiep(NgheNghiepDTO nn)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sql = "insert into nghenghiep values(@manghenghiep,@tennghenghiep)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@manghenghiep",nn.MaNgheNghiep);
                cmd.Parameters.AddWithValue("@tennghenghiep",nn.TenNgheNghiep);
                cmd.ExecuteNonQuery();     
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return true;

        }
        public bool XoaNgheNghiep(string manghenghiep)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sql = "delete from nghenghiep where manghenghiep=@manghenghiep";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@manghenghiep", manghenghiep);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;

        }
        public bool SuaNgheNghiep(NgheNghiepDTO nn)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {
                string sql = "update nghenghiep set tennghenghiep=@tennghenghiep where manghenghiep=@manghenghiep";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tennghenghiep", nn.TenNgheNghiep);
                cmd.Parameters.AddWithValue("@manghenghiep", nn.MaNgheNghiep);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
    }
}
