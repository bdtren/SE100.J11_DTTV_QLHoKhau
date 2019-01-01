using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS;
using DTO;

namespace MyTest
{
    [TestFixture]
    class Test_TamTru
    {
        private SoTamTruBUS SoTamTru_BUS;

        private static DateTime Today = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
        private static DateTime DiffDay = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day + 12);


        //Giá trị cho Thêm sổ tạm trú
        static object[] Array_SoTamTru_Insert =
        {
            new SoTamTruDTO("ST0000001","TT0000001","Tân Lập, Đông Hòa, Dĩ An, Bình Dương", Today, DiffDay),
            new SoTamTruDTO("ST0000002","TT0000002","Khu Phố 6, Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", Today, DiffDay),
        };


        //Giá trị cho Sửa sổ tạm trú
        static object[] Array_SoTamTru_Update=
        {
            new SoTamTruDTO("ST0000001","TT0000003","Tân Lập, Đông Hòa, Dĩ An, Bình Dương", Today, DiffDay),
            new SoTamTruDTO("ST0000002","TT0000004","Khu Phố 6, Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", Today, DiffDay),
            new SoTamTruDTO("ST0000005","TT0000004","Khu Phố 6, Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", Today, DiffDay),
        };


        //Giá trị cho Xóa sổ tạm trú
        static String[] Array_SoTamTru_Delete =
        {
          "ST0000001", "ST0000002"
        };


        //THiết lập các giá trị ban đầu
        [SetUp]
        public void Init()
        {
            SoTamTru_BUS = new SoTamTruBUS();
        }


        //Test hàm thêm sổ tạm trú
        [Test, Order(1), TestCaseSource("Array_SoTamTru_Insert")]
        public void ThemSoTamTru(SoTamTruDTO SoTamTru)
        {
            Assert.AreEqual(true, SoTamTru_BUS.Add(SoTamTru));
        }

        //Test hàm sửa sổ tạm trú
        [Test, Order(2), TestCaseSource("Array_SoTamTru_Update")]
        public void SuaSoTamTru(SoTamTruDTO SoTamTru)
        {
            Assert.AreEqual(true, SoTamTru_BUS.Update(SoTamTru, 0));
        }


        //Test hàm xóa sổ tạm trú
        [Test, Order(3), TestCaseSource("Array_SoTamTru_Delete")]
        public void XoaSoTamTru(string SoSoTamTru)
        {
            Assert.AreEqual(true, SoTamTru_BUS.XoaSoTamTru(SoSoTamTru));
        }












    }
}
