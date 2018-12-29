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
                sqlda = new MySqlDataAdapter("SELECT , 'Delete' as 'Change'* FROM sotamtru", conn);
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


        public  DataSet getAllSoTamTru()
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


        /// <summary>
        /// Lấy mã định danh
        /// </summary>
        /// <param name="sosotamtru"></param>
        /// <returns></returns>
        public List<string> getListMaDinhDanhBySoSoTamTru(string sosotamtru)
        {
            DataTable dt = new DataTable();
            List<string> madinhdanh_list = new List<string>();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            string sql = "SELECT madinhdanh FROM nhankhautamtru WHERE sosotamtru='" + sosotamtru + "' ";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            adapter.SelectCommand.CommandType = CommandType.Text;
            adapter.Fill(dt);

            madinhdanh_list = dt.AsEnumerable()
                      .Select(r => r.Field<string>("madinhdanh"))
                      .ToList();
            return madinhdanh_list;
        }

        public List<string> getListExperiedSoTamTru()
        {
            DataTable dt = new DataTable();
            List<string> sotamtru_list = new List<string>();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            string sql = "SELECT SOSOTAMTRU FROM `sotamtru` WHERE DENNGAY<CURDATE() ";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            adapter.SelectCommand.CommandType = CommandType.Text;
            adapter.Fill(dt);

            sotamtru_list = dt.AsEnumerable()
                      .Select(r => r.Field<string>("SOSOTAMTRU"))
                      .ToList();
            return sotamtru_list;
        }


        public bool XoaSoTamTru(string sosotamtru)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                NhanKhauTamTruDAO nhankhautamtruDao = new NhanKhauTamTruDAO();
                List<string> madinhdanh_list = getListMaDinhDanhBySoSoTamTru(sosotamtru);

                //Xóa nhân khẩu tạm trú trong sổ tạm trú
                for(int i=0; i < madinhdanh_list.Count; i++)
                {
                    nhankhautamtruDao.XoaNKTT(madinhdanh_list[i]);
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



        public bool DeleteExperiedSoTamTru()
        {
                try
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                     //Lấy list số sổ tạm trú quá hạn
                    List<string> sosotamtru_list = getListExperiedSoTamTru();

                    //Xóa list số tạm trú quá hạn
                    for (int i = 0; i < sosotamtru_list.Count; i++)
                    {
                            XoaSoTamTru(sosotamtru_list[i]);
                    }
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
                string sql = "update sotamtru set machuhotamtru=@machuhotamtru, choohiennay=@choohiennay, tungay=@tungay, denngay=@denngay, lydo=@lydo where sosotamtru=@sosotamtru";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@choohiennay", sotamtru.ChoOHienNay);
                cmd.Parameters.AddWithValue("@tungay", sotamtru.TuNgay);
                cmd.Parameters.AddWithValue("@denngay", sotamtru.DenNgay);
                cmd.Parameters.AddWithValue("@lydo", sotamtru.LyDo);
                cmd.Parameters.AddWithValue("@sosotamtru", sotamtru.SoSoTamTru);
                cmd.Parameters.AddWithValue("@machuhotamtru", sotamtru.MaChuHoTamTru);
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



        /// <summary>
        /// Các Hàm tăng mã tự động
        /// </summary>
        /// <param name="sql"></param>
        /// <returns> "" nếu bảng trống và chuỗi string nếu bảng có giá trị</returns>
        public string GetLastValueTable(string sql)
        {
            try
            {
                DataTable dt = new DataTable();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(dt);
                string value = "";
                value = dt.Rows[0][0].ToString();
                return value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }


        public string getLastID_SoSoTamTru()
        {
            string sql = "SELECT sosotamtru FROM sotamtru ORDER BY sosotamtru DESC LIMIT 1;";
            return GetLastValueTable(sql);
        }

        public string getLastID_MaNhanKhauTamTru()
        {
            string sql = "SELECT manhankhautamtru FROM nhankhautamtru ORDER BY manhankhautamtru DESC LIMIT 1;";
            return GetLastValueTable(sql);
        }

        public string getLastID_MaTieuSu()
        {
            string sql = "SELECT matieusu FROM tieusu ORDER BY matieusu DESC LIMIT 1;";
            return GetLastValueTable(sql);
        }

        public string getLastID_MaTienAnTienSu()
        {
            string sql = "SELECT matienantiensu FROM tienantiensu ORDER BY matienantiensu DESC LIMIT 1;";
            return GetLastValueTable(sql);
        }

        public string getLastID_MaDinhDanh()
        {
            string sql = "SELECT madinhdanh FROM nhankhau ORDER BY madinhdanh DESC LIMIT 1;";
            return GetLastValueTable(sql);
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
