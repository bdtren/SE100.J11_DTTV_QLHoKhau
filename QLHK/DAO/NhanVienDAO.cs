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
    public class NhanVienDAO:DBConnection<NhanVien>
    {
        public NhanVienDAO() : base() { }
        public override DataSet getAll()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();

                }
                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM nhanvien", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "nhanvien");
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
        public override bool insert(NhanVien nv)
        {
            try
            {
                DataRow dr = dataset.Tables["nhanvien"].NewRow();
                dr["manv"] = nv.MaNV;
                dr["hoten"] = nv.HoTen;
                dr["ngaysinh"] = nv.NgaySinh;
                dr["diachi"] = nv.DiaChi;
                dr["sdt"] = nv.SDT;
                dr["gioitinh"] = nv.GioiTinh;
                dr["email"] = nv.Email;
                dr["avatar"] = nv.Avatar;
                dr["ngayvl"] = nv.NgayVL;
                dataset.Tables["nhanvien"].Rows.Add(dr);
                dataset.Tables["nhanvien"].Rows.RemoveAt(dataset.Tables["nhanvien"].Rows.Count - 1);
                sqlda.Update(dataset, "nhanvien");
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
                dataset.Tables["nhanvien"].Rows[row].Delete();
                sqlda.Update(dataset, "nhanvien");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;

        }
        public override bool update(NhanVien nv, int r)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();

            }
            try
            {
                string sql = "update nhanvien set hoten =@hoten , ngaysinh=@ngaysinh, diachi=@diachi, sdt=@sdt, gioitinh=@gioitinh, email=@email, avatar=@avatar, ngayvl=@ngayvl where manv =@manv";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@hoten", nv.HoTen);
                cmd.Parameters.AddWithValue("@ngaysinh", nv.NgaySinh);
                cmd.Parameters.AddWithValue("@diachi", nv.DiaChi);
                cmd.Parameters.AddWithValue("@sdt", nv.SDT);
                cmd.Parameters.AddWithValue("@gioitinh",nv.GioiTinh);
                cmd.Parameters.AddWithValue("@email",nv.Email);
                cmd.Parameters.AddWithValue("@avatar",nv.Avatar);
                cmd.Parameters.AddWithValue("@ngayvl",nv.NgayVL.ToString("yyyy/MM/dd"));
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
    }
}
