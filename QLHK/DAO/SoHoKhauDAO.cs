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
    public class SoHoKhauDAO:DBConnection<SoHoKhauDTO>
    {
        public SoHoKhauDAO() : base() { }

        public override DataSet getAll()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT , 'Delete' as 'Change'* FROM sohokhau", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "sohokhau");
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

        public override bool insert_table(SoHoKhauDTO data)
        {
            throw new NotImplementedException();
        }
        public override bool insert(SoHoKhauDTO sohk)
        {
            try
            {

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string sql = "insert into sohokhau values(@sosohokhau, @machuho,  @diachi, @ngaycap, @sodangky)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sosohokhau", sohk.SoSoHoKhau);
                cmd.Parameters.AddWithValue("@machuho", sohk.MaChuHo);
                cmd.Parameters.AddWithValue("@diachi", sohk.DiaChi);
                cmd.Parameters.AddWithValue("@ngaycap", sohk.NgayCap);
                cmd.Parameters.AddWithValue("@sodangky", sohk.SoDangKy);
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
        public bool XoaSoHK(string soSoHoKhau)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sql = "delete from sohokhau where sosohokhau=@sosohokhau";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sosohokhau", soSoHoKhau);
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
                dataset.Tables["sohokhau"].Rows[row].Delete();
                sqlda.Update(dataset, "sohokhau");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;

        }

        public override bool update(SoHoKhauDTO sohk, int r)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {

                string sql = "update sohokhau set machuho=@machuho, diachi=@diachi, ngaycap=@ngaycap, sodangky=@sodangky" +
                    " where sosohokhau=@sosohokhau";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sosohokhau", sohk.SoSoHoKhau);
                cmd.Parameters.AddWithValue("@machuho", sohk.MaChuHo);
                cmd.Parameters.AddWithValue("@diachi", sohk.DiaChi);
                cmd.Parameters.AddWithValue("@ngaycap", sohk.NgayCap);
                cmd.Parameters.AddWithValue("@sodangky", sohk.SoDangKy);
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
                sqlda = new MySqlDataAdapter("SELECT * FROM sohokhau " + query, conn); /*where sosohokhau IS NOT NULL*/
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "sohokhau");
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



        /// <summary>
        /// Tự động tạo mã 12 ký tự cho mã định danh
        /// </summary>
        /// <param name="gioitinh"></param>
        /// <param name="namsinh"></param>
        /// <returns></returns>
        public string TangMa12Kytu(string gioitinh, string namsinh)
        {
            string str_matinh = "074";
            string str_magioitinh = null;
            string str_manamsinh = null;
            string sausocuoi = null;
            string kq = null;

            MySqlDataAdapter sqlda;
            DataSet dataset = null;
            MySqlCommandBuilder cmdbuilder;
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("select madinhdanh from nhankhau where gioitinh='" + gioitinh + "' and year(ngaysinh)='" + namsinh + "'ORDER BY madinhdanh desc", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "bangmadinhdanh");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            int i_namsinh = Int16.Parse(namsinh);
            if (i_namsinh > 1900 & i_namsinh <= 1999)
            {
                if (String.Compare(gioitinh, "nam", true) == 0)
                {
                    str_magioitinh = "0";
                }
                if (String.Compare(gioitinh, "nu", true) == 0)
                {
                    str_magioitinh = "1";
                }
            }
            if (i_namsinh >= 2000 & i_namsinh <= 2099)
            {
                if (String.Compare(gioitinh, "nam", true) == 0)
                {
                    str_magioitinh = "2";
                }
                if (String.Compare(gioitinh, "nu", true) == 0)
                {
                    str_magioitinh = "3";
                }
            }
            if (i_namsinh >= 2100 & i_namsinh <= 2199)
            {
                if (String.Compare(gioitinh, "nam", true) == 0)
                {
                    str_magioitinh = "4";
                }
                if (String.Compare(gioitinh, "nu", true) == 0)
                {
                    str_magioitinh = "5";
                }
            }
            if (i_namsinh >= 2200 & i_namsinh <= 2299)
            {
                if (String.Compare(gioitinh, "nam", true) == 0)
                {
                    str_magioitinh = "6";
                }
                if (String.Compare(gioitinh, "nu", true) == 0)
                {
                    str_magioitinh = "7";
                }
            }
            if (i_namsinh >= 2300 & i_namsinh <= 2399)
            {
                if (String.Compare(gioitinh, "nam", true) == 0)
                {
                    str_magioitinh = "8";
                }
                if (String.Compare(gioitinh, "nu", true) == 0)
                {
                    str_magioitinh = "9";
                }
            }

            str_manamsinh = namsinh.Substring(2);

            string str_madinhdanh;
            try
            {
                str_madinhdanh = dataset.Tables["bangmadinhdanh"].Rows[0][0].ToString();
            }
            catch (Exception e)
            {
                sausocuoi = "000001";
                kq = str_matinh + str_magioitinh + str_manamsinh + sausocuoi;
                return kq;
            }
            sausocuoi = str_madinhdanh.Substring(6);
            int x = Int32.Parse(sausocuoi) + 1;
            sausocuoi = x.ToString();
            string str = null;
            for (int i = 0; i < 6 - sausocuoi.Length; i++)
            {
                str = str + "0";
            }
            kq = str_matinh + str_magioitinh + str_manamsinh + str + sausocuoi;
            return kq;
        }


    }
    
}
