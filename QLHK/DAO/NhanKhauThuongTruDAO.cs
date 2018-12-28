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
    public class NhanKhauThuongTruDAO:DBConnection<NhanKhauThuongTruDTO>
    {
        public NhanKhauThuongTruDAO() : base() { }

        public override DataSet getAll()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT , 'Delete' as 'Change'* FROM nhankhauthuongtru", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "nhankhauthuongtru");
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

        public DataSet getAllJoinNhanKhau()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT Distinct * FROM nhankhau inner join nhankhauthuongtru on nhankhau.madinhdanh=nhankhauthuongtru.madinhdanh", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                //sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                //sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                //sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset);
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
        public override bool insert_table(NhanKhauThuongTruDTO data)
        {
            throw new NotImplementedException();
        }
        public override bool insert(NhanKhauThuongTruDTO nktt)
        {
            try
            {

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string sql = "insert into nhankhauthuongtru values(@manhankhauthuongtru,@madinhdanh,  @sosohokhau, @noithuongtrutamtru, @diachihientai," +
                    " @trinhdohocvan, @trinhdochuyenmon, @biettiengdantoc, @trinhdongoaingu, @noilamviec, @quanhevoichuho)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@manhankhauthuongtru", nktt.MaNhanKhauThuongTru);
                cmd.Parameters.AddWithValue("@madinhdanh", nktt.MaDinhDanh);
                cmd.Parameters.AddWithValue("@sosohokhau", nktt.SoSoHoKhau);
                cmd.Parameters.AddWithValue("@noithuongtrutamtru", nktt.NoiThuongTru);
                cmd.Parameters.AddWithValue("@diachihientai", nktt.DiaChiHienTai);
                cmd.Parameters.AddWithValue("@trinhdohocvan", nktt.TrinhDoHocVan);
                cmd.Parameters.AddWithValue("@trinhdochuyenmon", nktt.TrinhDoChuyenMon);
                cmd.Parameters.AddWithValue("@biettiengdantoc", nktt.BietTiengDanToc);
                cmd.Parameters.AddWithValue("@trinhdongoaingu", nktt.TrinhDoNgoaiNgu);
                cmd.Parameters.AddWithValue("@noilamviec", nktt.NoiLamViec);
                cmd.Parameters.AddWithValue("@quanhevoichuho", nktt.QuanHeVoiChuHo);
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
        public bool XoaNKTT(string maNhanKhauthuongtru)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sql = "delete from nhankhauthuongtru where manhankhauthuongtru=@manhankhauthuongtru";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@manhankhauthuongtru", maNhanKhauthuongtru);
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
                dataset.Tables["nhankhauthuongtru"].Rows[row].Delete();
                sqlda.Update(dataset, "nhankhauthuongtru");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;

        }

        public override bool update(NhanKhauThuongTruDTO nktt, int r)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {

                string sql = "update nhankhauthuongtru set sosohokhau=@sosohokhau, noithuongtrutamtru=@noithuongtrutamtru, " +
                    "diachihientai=@diachihientai, trinhdohocvan=@trinhdohocvan, trinhdochuyenmon=@trinhdochuyenmon, " +
                    "biettiengdantoc=@biettiengdantoc, trinhdongoaingu=@trinhdongoaingu, noilamviec=@noilamviec, " +
                    "quanhevoichuho=@quanhevoichuho where manhankhauthuongtru=@manhankhauthuongtru";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@manhankhauthuongtru", nktt.MaNhanKhauThuongTru);
                cmd.Parameters.AddWithValue("@sosohokhau", nktt.SoSoHoKhau);
                cmd.Parameters.AddWithValue("@noithuongtrutamtru", nktt.NoiThuongTru);
                cmd.Parameters.AddWithValue("@diachihientai", nktt.DiaChiHienTai);
                cmd.Parameters.AddWithValue("@trinhdohocvan", nktt.TrinhDoHocVan);
                cmd.Parameters.AddWithValue("@trinhdochuyenmon", nktt.TrinhDoChuyenMon);
                cmd.Parameters.AddWithValue("@biettiengdantoc", nktt.BietTiengDanToc);
                cmd.Parameters.AddWithValue("@trinhdongoaingu", nktt.TrinhDoNgoaiNgu);
                cmd.Parameters.AddWithValue("@noilamviec", nktt.NoiLamViec);
                cmd.Parameters.AddWithValue("@quanhevoichuho", nktt.QuanHeVoiChuHo);
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
                if (!String.IsNullOrEmpty(query)) query = "where " + query;
                sqlda = new MySqlDataAdapter("SELECT * FROM nhankhauthuongtru " + query, conn); /*where manhankhauthuongtru IS NOT NULL*/
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "nhankhauthuongtru");
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
