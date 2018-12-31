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
    public class TieuSuDAO : DBConnection<TieuSuDTO>
    {
        public TieuSuDAO() : base() { }

        public override bool delete(int row)
        {
            try
            {
                dataset.Tables["tieusu"].Rows[row].Delete();
                sqlda.Update(dataset, "tieusu");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public override DataSet getAll()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM tieusu", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "tieusu");
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

        public override bool insert(TieuSuDTO data)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sql = "insert into tieusu values(@matieusu, @madinhdanh, @thoigianbatdau, @thoigianketthuc, @choo, @nghenghiep, @noilamviec)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@matieusu", data.MaTieuSu);
                cmd.Parameters.AddWithValue("@madinhdanh", data.MaDinhDanh);
                cmd.Parameters.AddWithValue("@thoigianbatdau", data.ThoiGianBatDau.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@thoigianketthuc", data.ThoiGianKetThuc.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@choo", data.ChoO);
                cmd.Parameters.AddWithValue("@nghenghiep", data.NgheNghiep);
                cmd.Parameters.AddWithValue("@noilamviec", data.NoiLamViec);
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

        public override bool insert_table(TieuSuDTO data)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                DataRow dr = dataset.Tables["tieusu"].NewRow();
                dr["matieusu"] = data.MaTieuSu;
                dr["madinhdanh"] = data.MaDinhDanh;
                dr["thoigianbatdau"] = data.ThoiGianBatDau;
                dr["thoigianketthuc"] = data.ThoiGianKetThuc;
                dr["choo"] = data.ChoO;
                dr["nghenghiep"] = data.NgheNghiep;
                dr["noilamviec"] = data.NoiLamViec;
                dataset.Tables["tieusu"].Rows.Add(dr);
                dataset.Tables["tieusu"].Rows.RemoveAt(dataset.Tables["tieusu"].Rows.Count - 1);
                sqlda.Update(dataset, "tieusu");
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

        public override bool update(TieuSuDTO tieusu, int r)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {

                string sql = "update tieusu set madinhdanh=@madinhdanh,thoigianbatdau=@thoigianbatdau, thoigianketthuc=@thoigianketthuc, choo=@choo, nghenghiep=@nghenghiep, noilamviec=@noilamviec where matieusu=@matieusu";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@madinhdanh", tieusu.MaDinhDanh);
                cmd.Parameters.AddWithValue("@thoigianbatdau", tieusu.ThoiGianBatDau.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@thoigianketthuc", tieusu.ThoiGianKetThuc.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@choo", tieusu.ChoO);
                cmd.Parameters.AddWithValue("@nghenghiep", tieusu.NgheNghiep);
                cmd.Parameters.AddWithValue("@noilamviec", tieusu.NoiLamViec);
                cmd.Parameters.AddWithValue("@matieusu", tieusu.MaTieuSu);

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

        public DataSet TimKiem(string query)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM tieusu" + query, conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "tieusu");
                return dataset;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
