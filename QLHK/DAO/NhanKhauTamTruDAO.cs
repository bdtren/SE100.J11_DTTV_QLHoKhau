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
    public class NhanKhauTamTruDAO:DBConnection<NhanKhauTamTruDTO>
    {
        public NhanKhauTamTruDAO() : base() { }

        public override DataSet getAll()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM nhankhautamtru", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                string sql = "SELECT  nhankhau.MaDinhDanh, MaNhanKhauTamTru, HoTen, GioiTinh,NgaySinh,NoiSinh,DiaChiThuongTru,DanToc, QuocTich,NguyenQuan, TonGiao, MaNgheNghiep,SDT, HoChieu,NgayCap,NoiCap,SoSoTamTru FROM nhankhautamtru inner join nhankhau WHERE nhankhautamtru.madinhdanh=nhankhau.madinhdanh";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql,conn);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(dataset);
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

        public override bool insert(NhanKhauTamTruDTO nktt)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sql = "insert into nhankhautamtru values(@manhankhautamtru, @madinhdanh, @diachithuongtru, @sosotamtru);"
                             + "insert into nhankhau values(@madinhdanh, @manghenghiep, @hoten, @gioitinh, @dantoc, @hochieu, @ngaycap, @ngaysinh, @nguyenquan, @noicap, @noisinh,@quoctich, @sdt, @tongiao)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@manhankhautamtru", nktt.MaNhanKhauTamTru);
                cmd.Parameters.AddWithValue("@madinhdanh", nktt.MaDinhDanh);
                cmd.Parameters.AddWithValue("@diachithuongtru", nktt.DiaChiThuongTru);
                cmd.Parameters.AddWithValue("@sosotamtru", nktt.SoSoTamTru);

                cmd.Parameters.AddWithValue("@manghenghiep", nktt.MaNgheNghiep);
                cmd.Parameters.AddWithValue("@hoten", nktt.HoTen);
                cmd.Parameters.AddWithValue("@gioitinh", nktt.GioiTinh);
                cmd.Parameters.AddWithValue("@dantoc", nktt.DanToc);
                cmd.Parameters.AddWithValue("@hochieu", nktt.HoChieu);
                cmd.Parameters.AddWithValue("@ngaycap", nktt.NgayCap);
                cmd.Parameters.AddWithValue("@ngaysinh", nktt.NgaySinh);
                cmd.Parameters.AddWithValue("@nguyenquan",nktt.NguyenQuan);
                cmd.Parameters.AddWithValue("@noicap", nktt.NoiCap);
                cmd.Parameters.AddWithValue("@noisinh", nktt.NoiSinh);
                cmd.Parameters.AddWithValue("@quoctich", nktt.QuocTich);
                cmd.Parameters.AddWithValue("@sdt", nktt.SDT);
                cmd.Parameters.AddWithValue("@tongiao", nktt.TonGiao);

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
        public bool XoaNKTT(string madinhdanh)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sql = "delete from nhankhautamtru where madinhdanh=@madinhdanh; delete from nhankhau where madinhdanh=@madinhdanh;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@madinhdanh", madinhdanh);
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

        public override bool update(NhanKhauTamTruDTO nktt, int r)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {

                string sql = "update nhankhautamtru set diachithuongtru=@diachithuongtru, sosotamtru=@sosotamtru where madinhdanh=@madinhdanh; update nhankhau set manghenghiep=@manghenghiep,hoten=@hoten,gioitinh=@gioitinh,dantoc=@dantoc,hochieu=@hochieu,ngaycap=@ngaycap,ngaysinh=@ngaysinh,nguyenquan=@nguyenquan,noicap=@noicap,noisinh=@noisinh,quoctich=@quoctich,sdt=@sdt,tongiao=@tongiao where madinhdanh=@madinhdanh;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@diachithuongtru", nktt.DiaChiThuongTru);
                cmd.Parameters.AddWithValue("@sosotamtru", nktt.SoSoTamTru);

                cmd.Parameters.AddWithValue("@madinhdanh", nktt.MaDinhDanh);

                cmd.Parameters.AddWithValue("@manghenghiep", nktt.MaNgheNghiep);
                cmd.Parameters.AddWithValue("@hoten", nktt.HoTen);
                cmd.Parameters.AddWithValue("@gioitinh", nktt.GioiTinh);
                cmd.Parameters.AddWithValue("@dantoc", nktt.DanToc);
                cmd.Parameters.AddWithValue("@hochieu", nktt.HoChieu);
                cmd.Parameters.AddWithValue("@ngaycap", nktt.NgayCap);
                cmd.Parameters.AddWithValue("@ngaysinh", nktt.NgaySinh);
                cmd.Parameters.AddWithValue("@nguyenquan", nktt.NguyenQuan);
                cmd.Parameters.AddWithValue("@noicap", nktt.NoiCap);
                cmd.Parameters.AddWithValue("@noisinh", nktt.NoiSinh);
                cmd.Parameters.AddWithValue("@quoctich", nktt.QuocTich);
                cmd.Parameters.AddWithValue("@sdt", nktt.SDT);
                cmd.Parameters.AddWithValue("@tongiao", nktt.TonGiao);
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
            return false;
        }
        public DataSet TimKiem(string madinhdanh)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                DataSet ds = new DataSet();
                string sql = "SELECT  nhankhau.MaDinhDanh, MaNhanKhauTamTru, HoTen, GioiTinh,NgaySinh,NoiSinh,DiaChiThuongTru,DanToc, QuocTich,NguyenQuan, TonGiao, MaNgheNghiep,SDT, HoChieu,NgayCap,NoiCap,SoSoTamTru FROM nhankhautamtru inner join nhankhau WHERE nhankhautamtru.madinhdanh=nhankhau.madinhdanh and nhankhau.madinhdanh='" + madinhdanh + "'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(ds);
                return ds;
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
        public override bool insert_table(NhanKhauTamTruDTO data)
        {
            throw new NotImplementedException();
        }



        //Get Data for Tinh Thanh Pho, Quan Huyen, Xa Phuong Thi Tran
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
                string find = RemoveUnicode(value);
                string ID;
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sqltemp = "SELECT "+nameColumn+" FROM "+table+" WHERE ten='" + find + "'";
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
            string sql = "SELECT ten FROM quanhuyen WHERE matp='"+ID_TP+"' ";
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


        //Hàm bỏ dấu tiếng việt
        public static string RemoveUnicode(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
            "đ",
            "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
            "í","ì","ỉ","ĩ","ị",
            "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
            "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
            "ý","ỳ","ỷ","ỹ","ỵ",};
                    string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
            "d",
            "e","e","e","e","e","e","e","e","e","e","e",
            "i","i","i","i","i",
            "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
            "u","u","u","u","u","u","u","u","u","u","u",
            "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }


    }
    
}
