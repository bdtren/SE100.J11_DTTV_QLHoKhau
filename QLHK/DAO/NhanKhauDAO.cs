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
    public class NhanKhauDAO:DBConnection<NhanKhau>
    {
        public NhanKhauDAO() : base() { }
        public override DataSet getAll()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM nhankhau", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "nhankhau");
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
        public override bool insert_table(NhanKhau data)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                DataRow dr = dataset.Tables["nhankhau"].NewRow();
                dr["madinhdanh"] = data.MaDinhDanh;
                dr["hoten"] = data.HoTen;
                dr["tenkhac"] = data.TenKhac;
                dr["ngaysinh"] = data.NgaySinh;
                dr["gioitinh"] = data.GioiTinh;
                dr["nguyenquan"] = data.NguyenQuan;
                dr["dantoc"] = data.DanToc;
                dr["tongiao"] = data.TonGiao;
                dr["quoctich"] = data.QuocTich;
                dr["hochieu"] = data.HoChieu;
                dr["noithuongtru"] = data.NoiThuongTru;
                dr["diachihiennay"] = data.DiaChiHienNay;
                dr["sdt"] = data.SDT;
                dr["trinhdohocvan"] = data.TrinhDoHocVan;
                dr["trinhdochuyenmon"] = data.TrinhDoChuyenMon;
                dr["biettiengdantoc"] = data.BietTiengDanToc;
                dr["trinhdongoaingu"] = data.TrinhDoNgoaiNgu;
                dr["ngheghiep"] = data.NgheNghiep;
                dataset.Tables["hocsinhsinhvien"].Rows.Add(dr);
                dataset.Tables["hocsinhsinhvien"].Rows.RemoveAt(dataset.Tables["hocsinhsinhvien"].Rows.Count - 1);
                sqlda.Update(dataset, "hocsinhsinhvien");
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
        public override bool insert(NhanKhau nk)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sql = "insert into nhankhau values(@madinhdanh, @hoten, @tenkhac, @ngaysinh, @gioitinh, @noisinh, @nguyenquan, @dantoc,@tongiao, @quoctich, @hochieu, @noithuongtru, @diachihiennay, @sdt, @trinhdohocvan, @trinhdochuyenmon, @biettiengdantoc, @trinhdongoaingu, @nghenghiep);";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@madinhdanh", nk.MaDinhDanh.ToString());
                cmd.Parameters.AddWithValue("@hoten", nk.HoTen.ToString());
                cmd.Parameters.AddWithValue("@tenkhac", nk.TenKhac.ToString());
                cmd.Parameters.AddWithValue("@ngaysinh", nk.NgaySinh.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@gioitinh", nk.GioiTinh.ToString());
                cmd.Parameters.AddWithValue("@noisinh", nk.NoiSinh.ToString());
                cmd.Parameters.AddWithValue("@nguyenquan", nk.NguyenQuan.ToString());
                cmd.Parameters.AddWithValue("@dantoc", nk.DanToc.ToString());
                cmd.Parameters.AddWithValue("@tongiao", nk.TonGiao.ToString());
                cmd.Parameters.AddWithValue("@quoctich", nk.QuocTich.ToString());
                cmd.Parameters.AddWithValue("@hochieu", nk.HoChieu.ToString());
                cmd.Parameters.AddWithValue("@noithuongtru", nk.NoiThuongTru.ToString());
                cmd.Parameters.AddWithValue("@diachihiennay", nk.DiaChiHienNay.ToString());
                cmd.Parameters.AddWithValue("@sdt", nk.SDT.ToString());
                cmd.Parameters.AddWithValue("@trinhdohocvan", nk.TrinhDoHocVan.ToString());
                cmd.Parameters.AddWithValue("@trinhdochuyenmon", nk.TrinhDoChuyenMon.ToString());
                cmd.Parameters.AddWithValue("@biettiengdantoc", nk.BietTiengDanToc.ToString());
                cmd.Parameters.AddWithValue("@trinhdongoaingu", nk.TrinhDoNgoaiNgu.ToString());
                cmd.Parameters.AddWithValue("@nghenghiep", nk.NgheNghiep.ToString());

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
        public override bool delete(int row)
        {
            try
            {
                dataset.Tables["nhankhau"].Rows[row].Delete();
                sqlda.Update(dataset, "nhankhau");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;

        }
        public bool delete(string madinhdanh)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sql = "delete from nhankhau where madinhdanh=@madinhdanh";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@madinhdanh", madinhdanh);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;

        }
        public override bool update(NhanKhau nk, int r)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {
                string sql = "update nhankhau set hoten=@hoten,tenkhac=@tenkhac,ngaysinh=@ngaysinh,gioitinh=@gioitinh," +
                    "noisinh=@noisinh,nguyenquan=@nguyenquan,dantoc=@dantoc,tongiao=@tongiao,quoctich=@quoctich," +
                    "hochieu=@hochieu,noithuongtru=@noithuongtru,diachihiennay=@diachihiennay,sdt=@sdt," +
                    "trinhdohocvan=@trinhdohocvan,trinhdochuyenmon=@trinhdochuyenmon, biettiengdantoc=@biettiengdantoc, " +
                    "trinhdongoaingu=@trinhdongoaingu ,nghenghiep=@nghenghiep where madinhdanh=@madinhdanh";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@madinhdanh", nk.MaDinhDanh.ToString());
                cmd.Parameters.AddWithValue("@hoten", nk.HoTen.ToString());
                cmd.Parameters.AddWithValue("@tenkhac", nk.TenKhac.ToString());
                cmd.Parameters.AddWithValue("@ngaysinh", nk.NgaySinh.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@gioitinh", nk.GioiTinh.ToString());
                cmd.Parameters.AddWithValue("@noisinh", nk.NoiSinh.ToString());
                cmd.Parameters.AddWithValue("@nguyenquan", nk.NguyenQuan.ToString());
                cmd.Parameters.AddWithValue("@dantoc", nk.DanToc.ToString());
                cmd.Parameters.AddWithValue("@tongiao", nk.TonGiao.ToString());
                cmd.Parameters.AddWithValue("@quoctich", nk.QuocTich.ToString());
                cmd.Parameters.AddWithValue("@hochieu", nk.HoChieu.ToString());
                cmd.Parameters.AddWithValue("@noithuongtru", nk.NoiThuongTru.ToString());
                cmd.Parameters.AddWithValue("@diachihiennay", nk.DiaChiHienNay.ToString());
                cmd.Parameters.AddWithValue("@sdt", nk.SDT.ToString());
                cmd.Parameters.AddWithValue("@trinhdohocvan", nk.TrinhDoHocVan.ToString());
                cmd.Parameters.AddWithValue("@trinhdochuyenmon", nk.TrinhDoChuyenMon.ToString());
                cmd.Parameters.AddWithValue("@biettiengdantoc", nk.BietTiengDanToc.ToString());
                cmd.Parameters.AddWithValue("@trinhdongoaingu", nk.TrinhDoNgoaiNgu.ToString());
                cmd.Parameters.AddWithValue("@nghenghiep", nk.NgheNghiep.ToString());
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
        public  DataSet TimKiem(string query)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM nhankhau" + query, conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "nhankhau");
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

        public DataSet TimKiemTheoCuTru(string madinhdanh)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM nhankhau, nhankhauthuongtru " +
                    "where nhankhau.madinhdanh=nhankhauthuongtru.madinhdanh and nhankhau.madinhdanh='" + madinhdanh + "'", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                dataset = new DataSet();
                sqlda.Fill(dataset, "thuongtru");

                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM nhankhau, nhankhautamtru " +
                    "where nhankhau.madinhdanh=nhankhautamtru.madinhdanh and nhankhau.madinhdanh='" + madinhdanh + "'", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.Fill(dataset, "tamtru");


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
