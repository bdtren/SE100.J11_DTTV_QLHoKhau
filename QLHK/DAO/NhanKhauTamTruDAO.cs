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

        //Lấy tất cả nhân khẩu tạm trú nằm trong 1 sổ tạm trú
        public DataSet getAllNhanKhauTT(string sosotamtru)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                dataset = new DataSet();
                string sql = "SELECT  nhankhau.MaDinhDanh, MaNhanKhauTamTru, HoTen, GioiTinh,NgaySinh,NoiSinh,DiaChiThuongTru,DanToc, QuocTich,NguyenQuan, TonGiao, NgheNghiep,SDT, HoChieu,NgayCap,NoiCap,SoSoTamTru FROM nhankhautamtru inner join nhankhau WHERE nhankhautamtru.madinhdanh=nhankhau.madinhdanh and sosotamtru='"+sosotamtru+"'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql,conn);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(dataset,"nhankhautamtrujoin");
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


        public override DataSet getAll()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                dataset = new DataSet();
                string sql = "SELECT *, 'Delete' as 'Change' FROM nhankhautamtru";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(dataset, "nhankhautamtru");
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
            /*
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sql = "insert into nhankhautamtru values(@manhankhautamtru, @madinhdanh, @diachithuongtru, @sosotamtru);"
                             + "insert into nhankhau values(@madinhdanh, @nghenghiep, @hoten, @gioitinh, @dantoc, @hochieu, @ngaycap, @ngaysinh, @nguyenquan, @noicap, @noisinh,@quoctich, @sdt, @tongiao)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@manhankhautamtru", nktt.MaNhanKhauTamTru);
                cmd.Parameters.AddWithValue("@madinhdanh", nktt.MaDinhDanh);
                cmd.Parameters.AddWithValue("@diachithuongtru", nktt.DiaChiThuongTru);
                cmd.Parameters.AddWithValue("@sosotamtru", nktt.SoSoTamTru);
                cmd.Parameters.AddWithValue("@nghenghiep", nktt.NgheNghiep);
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
            }*/
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
                string sql = "delete from nhankhautamtru where madinhdanh=@madinhdanh; delete from nhankhau where madinhdanh=@madinhdanh;" +
                    "delete from tienantiensu where madinhdanh=@madinhdanh;" +
                    "delete from tieusu where madinhdanh=@madinhdanh;";
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
                dataset.Tables["nhankhautamtru"].Rows[row].Delete();
                sqlda.Update(dataset, "nhankhautamtru");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;

        }

        public bool updateNhanKhauTamTru(NhanKhauTamTruDTO nktt, int r)
        {
            //if (conn.State != ConnectionState.Open)
            //{
            //    conn.Open();
            //}
            //try
            //{

            //    string sql = "update nhankhautamtru set diachithuongtru=@diachithuongtru, sosotamtru=@sosotamtru where madinhdanh=@madinhdanh; update nhankhau set nghenghiep=@nghenghiep,hoten=@hoten,gioitinh=@gioitinh,dantoc=@dantoc,hochieu=@hochieu,ngaycap=@ngaycap,ngaysinh=@ngaysinh,nguyenquan=@nguyenquan,noicap=@noicap,noisinh=@noisinh,quoctich=@quoctich,sdt=@sdt,tongiao=@tongiao where madinhdanh=@madinhdanh;";
            //    MySqlCommand cmd = new MySqlCommand(sql, conn);
            //    cmd.Parameters.AddWithValue("@diachithuongtru", nktt.DiaChiThuongTru);
            //    cmd.Parameters.AddWithValue("@sosotamtru", nktt.SoSoTamTru);

            //    cmd.Parameters.AddWithValue("@madinhdanh", nktt.MaDinhDanh);

            //    cmd.Parameters.AddWithValue("@nghenghiep", nktt.NgheNghiep);
            //    cmd.Parameters.AddWithValue("@hoten", nktt.HoTen);
            //    cmd.Parameters.AddWithValue("@gioitinh", nktt.GioiTinh);
            //    cmd.Parameters.AddWithValue("@dantoc", nktt.DanToc);
            //    cmd.Parameters.AddWithValue("@hochieu", nktt.HoChieu);
            //    cmd.Parameters.AddWithValue("@ngaycap", nktt.NgayCap);
            //    cmd.Parameters.AddWithValue("@ngaysinh", nktt.NgaySinh);
            //    cmd.Parameters.AddWithValue("@nguyenquan", nktt.NguyenQuan);
            //    cmd.Parameters.AddWithValue("@noicap", nktt.NoiCap);
            //    cmd.Parameters.AddWithValue("@noisinh", nktt.NoiSinh);
            //    cmd.Parameters.AddWithValue("@quoctich", nktt.QuocTich);
            //    cmd.Parameters.AddWithValue("@sdt", nktt.SDT);
            //    cmd.Parameters.AddWithValue("@tongiao", nktt.TonGiao);
            //    cmd.ExecuteNonQuery();

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    return false;
            //}
            //finally
            //{
            //    conn.Close();
            //}
            return true;
        }


        public override bool update(NhanKhauTamTruDTO nktt, int r)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {

                string sql = "update nhankhautamtru set madinhdanh=@madinhdanh, noitamtru=@noitamtru, tungay=@tungay, denngay=@denngay, " +
                    "lydo=@lydo, sotamtru=@sotamtru where manhankhautamtru=@manhankhautamtru";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@madinhdanh", nktt.MaDinhDanh);
                cmd.Parameters.AddWithValue("@noitamtru", nktt.NoiTamTru);
                cmd.Parameters.AddWithValue("@tungay", nktt.TuNgay);
                cmd.Parameters.AddWithValue("@denngay", nktt.DenNgay);
                cmd.Parameters.AddWithValue("@lydo", nktt.LyDo);
                cmd.Parameters.AddWithValue("@sotamtru", nktt.SoSoTamTru);
                cmd.Parameters.AddWithValue("@manhankhautamtru", nktt.MaNhanKhauTamTru);

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


        public DataSet TimKiem(string madinhdanh)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                DataSet ds = new DataSet();
                string sql = "SELECT  nhankhau.MaDinhDanh, MaNhanKhauTamTru, HoTen, GioiTinh,NgaySinh,NoiSinh,DiaChiThuongTru,DanToc, QuocTich,NguyenQuan, TonGiao, NgheNghiep,SDT, HoChieu,NgayCap,NoiCap,SoSoTamTru FROM nhankhautamtru inner join nhankhau WHERE nhankhautamtru.madinhdanh=nhankhau.madinhdanh and nhankhau.madinhdanh='" + madinhdanh + "'";
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
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                DataRow dr = dataset.Tables["nhankhautamtru"].NewRow();
                dr["manhankhautamtru"] = data.MaNhanKhauTamTru;
                dr["madinhdanh"] = data.MaDinhDanh;
                dr["noitamtru"] = data.NoiTamTru;
                dr["tungay"] = data.TuNgay;
                dr["denngay"] = data.DenNgay;
                dr["lydo"] = data.LyDo;
                dr["sosotamtru"] = data.SoSoTamTru;


                dataset.Tables["nhankhautamtru"].Rows.Add(dr);
                dataset.Tables["nhankhautamtru"].Rows.RemoveAt(dataset.Tables["nhankhautamtru"].Rows.Count - 1);
                sqlda.Update(dataset, "nhankhautamtru");
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
                string find = value;
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


        //
        //XỬ LÝ VỚI TIỀN ÁN TIỀN SỰ
        //
        //Lấy tiền án tiền sự với mã định danh
        public DataSet getTienAnTienSu(string madinhdanh)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT MaTienAnTienSu,BanAn,ToiDanh,HinhPhat,NgayPhat,GhiChu  FROM tienantiensu WHERE madinhdanh='"+madinhdanh+"'", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "tienantiensu");
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

        //Xóa tiền án với mã tiền án
        public bool DeleteTienAn(string matienan)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sql = "delete from tienantiensu where matienantiensu=@matienan";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@matienan", matienan);
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


        //
        //XỬ LÝ VỚI TIỂU SỬ
        //

            //Lấy tiểu sử với mã định danh
        public DataSet getTieuSu(string madinhdanh)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT MaTieuSu,ThoiGianBatDau,ThoiGianKetThuc,ChoO,MaNgheNghiep,NoiLamViec  FROM tieusu WHERE madinhdanh='" + madinhdanh + "'", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "tienantiensu");
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

        //Xóa tiểu sử với mã tiểu sử
        public bool DeleteTieuSu(string matieusu)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sql = "delete from tieusu where matieusu=@matieusu";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@matieusu", matieusu);
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
