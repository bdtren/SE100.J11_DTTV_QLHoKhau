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
                sqlda = new MySqlDataAdapter("SELECT * FROM sotamtru WHERE sosotamtru="+sosotamtru+"", conn);
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
        public override bool insert_table(SoTamTruDTO data)
        {
            throw new NotImplementedException();
        }


        //Lấy thông tin của Chỗ ở trong bảng thành phố, quận huyện, xã phường thị trấn

        public List<string> GetListTinhThanh()
        {
            DataTable dt = new DataTable();
            List<string> tinhthanh_list = new List<string>();

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            string sql = "SELECT ten FROM tinhthanhpho";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            adapter.SelectCommand.CommandType = CommandType.Text;
            adapter.Fill(dt);

            tinhthanh_list = dt.AsEnumerable()
                      .Select(r => r.Field<string>("ten"))
                      .ToList();
            return tinhthanh_list;
        }


        public string GetID_DiaChi(string table, string value, string nameColumn)
        {
            try
            {
                DataTable dt = new DataTable();
                string find = value;
                string ID;
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sqltemp = "SELECT " + nameColumn + " FROM " + table + " WHERE ten='" + find + "'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sqltemp, conn);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(dt);

                ID = dt.Rows[0][0].ToString();
                return ID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }

        public List<string> GetListQuanHuyen(string tentinhthanhpho)
        {
            DataTable dt = new DataTable();
            List<string> quanhuyen_list = new List<string>();

            string ID_TP = GetID_DiaChi("tinhthanhpho", tentinhthanhpho, "matp");

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            string sql = "SELECT ten FROM quanhuyen WHERE matp='" + ID_TP + "' ";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            adapter.SelectCommand.CommandType = CommandType.Text;
            adapter.Fill(dt);

            quanhuyen_list = dt.AsEnumerable()
                      .Select(r => r.Field<string>("ten"))
                      .ToList();
            return quanhuyen_list;
        }


        public List<string> GetListXaPhuong(string tenquanhuyen)
        {
            DataTable dt = new DataTable();
            List<string> xaphuong_list = new List<string>();

            string ID_QH = GetID_DiaChi("quanhuyen", tenquanhuyen, "maqh");

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            string sql = "SELECT ten FROM xaphuongthitran WHERE maqh='" + ID_QH + "' ";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            adapter.SelectCommand.CommandType = CommandType.Text;
            adapter.Fill(dt);

            xaphuong_list = dt.AsEnumerable()
                      .Select(r => r.Field<string>("ten"))
                      .ToList();
            return xaphuong_list;
        }



    }

}
