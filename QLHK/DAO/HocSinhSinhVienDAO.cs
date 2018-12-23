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
    public class HocSinhSinhVienDAO:DBConnection<HocSinhSinhVien>
    {
        public HocSinhSinhVienDAO() : base() { }

        public override DataSet getAll()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM hocsinhsinhvien", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "hocsinhsinhvien");
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

        public override bool insert(HocSinhSinhVien hssv)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                DataRow dr = dataset.Tables["hocsinhsinhvien"].NewRow();
                dr["manhankhau"] = hssv.MaNhanKhau;
                dr["mssv"] = hssv.MSSV;
                dr["truong"] = hssv.Truong;
                dr["diachithuongtru"] = hssv.DiaChiThuongTru;
                dr["thoigianbatdautamtruthuongtru"] = hssv.TGBDTT;
                dr["thoigianketthuctamtruthuongtru"] = hssv.TGKTTT;
                dr["vipham"] = hssv.ViPham;
                dataset.Tables["hocsinhsinhvien"].Rows.Add(dr);
                dataset.Tables["hocsinhsinhvien"].Rows.RemoveAt(dataset.Tables["hocsinhsinhvien"].Rows.Count - 1);
                sqlda.Update(dataset, "hocsinhsinhvien");
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
                dataset.Tables["hocsinhsinhvien"].Rows[row].Delete();
                sqlda.Update(dataset, "hocsinhsinhvien");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;

        }
        public override bool update(HocSinhSinhVien hssv, int r)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();

            }
            try
            {
                string sql = "update hocsinhsinhvien set manhankhau =@manhankhau, truong=@truong, diachithuongtru=@diachithuongtru, thoigianbatdautamtruthuongtru=@tgbdtt, thoigianketthuctamtruthuongtru=@tgkttt,vipham=@vipham where mssv =@mssv";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@manhankhau", hssv.MaNhanKhau.ToString());
                cmd.Parameters.AddWithValue("@truong", hssv.Truong.ToString());
                cmd.Parameters.AddWithValue("@diachithuongtru", hssv.DiaChiThuongTru.ToString());
                cmd.Parameters.AddWithValue("@tgbdtt", hssv.TGBDTT.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@tgkttt", hssv.TGKTTT.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@vipham", hssv.ViPham.ToString());
                cmd.Parameters.AddWithValue("@mssv", hssv.MSSV.ToString());
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
    }
}
