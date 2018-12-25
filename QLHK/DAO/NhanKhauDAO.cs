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
            throw new NotImplementedException();
        }
        public override bool insert(NhanKhau nk)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sql = "insert into nhankhau values(@madinhdanh,@manghenghiep, @hoten,@gioitinh,@dantoc,@hochieu,@ngaycap,@ngaysinh,@nguyenquan,@noicap,@noisinh,@quoctich,@sdt,@tongiao);";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@madinhdanh", nk.MaDinhDanh.ToString());
                cmd.Parameters.AddWithValue("@manghenghiep", nk.MaNgheNghiep.ToString());
                cmd.Parameters.AddWithValue("@hoten", nk.HoTen.ToString());
                cmd.Parameters.AddWithValue("@gioitinh", nk.GioiTinh.ToString());
                cmd.Parameters.AddWithValue("@dantoc", nk.DanToc.ToString());
                cmd.Parameters.AddWithValue("@hochieu", nk.HoChieu.ToString());
                cmd.Parameters.AddWithValue("@ngaycap", nk.NgayCap.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@ngaysinh", nk.NgaySinh.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@nguyenquan", nk.NguyenQuan.ToString());
                cmd.Parameters.AddWithValue("@noicap", nk.NoiCap.ToString());
                cmd.Parameters.AddWithValue("@noisinh", nk.NoiSinh.ToString());
                cmd.Parameters.AddWithValue("@quoctich", nk.QuocTich.ToString());
                cmd.Parameters.AddWithValue("@sdt", nk.SDT.ToString());
                cmd.Parameters.AddWithValue("@tongiao", nk.TonGiao.ToString());
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
                string sql = "update nhankhau set manghenghiep=@manghenghiep,hoten=@hoten,gioitinh=@gioitinh,dantoc=@dantoc,hochieu=@hochieu,ngaycap=@ngaycap,ngaysinh=@ngaysinh,nguyenquan=@nguyenquan,noicap=@noicap,noisinh=@noisinh,quoctich=@quoctich,sdt=@sdt,tongiao=@tongiao where madinhdanh=@madinhdanh";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@madinhdanh", nk.MaDinhDanh.ToString());
                cmd.Parameters.AddWithValue("@manghenghiep", nk.MaNgheNghiep.ToString());
                cmd.Parameters.AddWithValue("@hoten", nk.HoTen.ToString());
                cmd.Parameters.AddWithValue("@gioitinh", nk.GioiTinh.ToString());
                cmd.Parameters.AddWithValue("@dantoc", nk.DanToc.ToString());
                cmd.Parameters.AddWithValue("@hochieu", nk.HoChieu.ToString());
                cmd.Parameters.AddWithValue("@ngaycap", nk.NgayCap.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@ngaysinh", nk.NgaySinh.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@nguyenquan", nk.NguyenQuan.ToString());
                cmd.Parameters.AddWithValue("@noicap", nk.NoiCap.ToString());
                cmd.Parameters.AddWithValue("@noisinh", nk.NoiSinh.ToString());
                cmd.Parameters.AddWithValue("@quoctich", nk.QuocTich.ToString());
                cmd.Parameters.AddWithValue("@sdt", nk.SDT.ToString());
                cmd.Parameters.AddWithValue("@tongiao", nk.TonGiao.ToString());
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
    }
}
