using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class SoTamTruDAO:DBConnection<SoTamTruDTO>
    {
        public SoTamTruDAO() : base() { }

        public override DataSet getAll()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT * FROM sotamtru", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "sotamtru");
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

        public override bool insert(SoTamTruDTO sotamtru)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sql = "insert into sotamtru values(@sosotamtru, @machuhotamtru, @choohiennay, @tungay, @denngay, @lydo)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sosotamtru", sotamtru.SoSoTamTru);
                cmd.Parameters.AddWithValue("@machuhotamtru", sotamtru.MaChuHoTamTru);
                cmd.Parameters.AddWithValue("@choohiennay", sotamtru.ChoOHienNay);
                cmd.Parameters.AddWithValue("@tungay", sotamtru.TuNgay);
                cmd.Parameters.AddWithValue("@denngay", sotamtru.DenNgay);
                cmd.Parameters.AddWithValue("@lydo", sotamtru.LyDo);
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
        public bool XoaSoTamTru(string sosotamtru)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sql = "delete from sotamtru where sosotamtru=@sosotamtru";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sosotamtru", sosotamtru);
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
                dataset.Tables["sotamtru"].Rows[row].Delete();
                sqlda.Update(dataset, "sotamtru");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;

        }

        public override bool update(SoTamTruDTO sotamtru, int r)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {
                string sql = "update sotamtru set choohiennay=@choohiennay, tungay=@tungay, denngay=@denngay, lydo=@lydo where sosotamtru=@sosotamtru";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@choohiennay", sotamtru.ChoOHienNay);
                cmd.Parameters.AddWithValue("@tungay", sotamtru.TuNgay);
                cmd.Parameters.AddWithValue("@denngay", sotamtru.DenNgay);
                cmd.Parameters.AddWithValue("@lydo", sotamtru.LyDo);
                cmd.Parameters.AddWithValue("@sosotamtru", sotamtru.SoSoTamTru);
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
        public DataSet TimKiem(string sosotamtru)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT * FROM sotamtru where sosotamtru='" + sosotamtru + "'", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "sotamtru");
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
    }
    
}
