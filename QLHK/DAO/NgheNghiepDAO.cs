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
    public class NgheNghiepDAO: DBConnection<NgheNghiepDTO>
    {
        public NgheNghiepDAO() : base() { }
        public override DataSet getAll()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();

                }
                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM nghenghiep", conn);
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
        public override bool insert_table(NgheNghiepDTO nn)
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

        public override bool delete(int row)
        {
            try
            {
                dataset.Tables["nghenghiep"].Rows[row].Delete();
                sqlda.Update(dataset, "nghenghiep");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;

        }
        public override bool update(NgheNghiepDTO nn, int r)
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
        public override bool insert(NgheNghiepDTO data)
        {
            try
            {
                DataRow dr = dataset.Tables["nghenghiep"].NewRow();
                dr["manghenghiep"] = data.MaNgheNghiep;
                dr["tennghenghiep"] = data.TenNgheNghiep;
                dataset.Tables["nghenghiep"].Rows.Add(dr);
                dataset.Tables["nghenghiep"].Rows.RemoveAt(dataset.Tables["nghenghiep"].Rows.Count - 1);
                sqlda.Update(dataset, "nghenghiep");
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
    }
}
