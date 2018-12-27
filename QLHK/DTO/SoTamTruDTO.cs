using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SoTamTruDTO
    {
        public string SoSoTamTru { get; set; }
        public string MaChuHoTamTru { get; set; }
        public string ChoOHienNay { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public string LyDo { get; set; }

        public SoTamTruDTO() { }

        public SoTamTruDTO(string SoSoTamTru, string MaChuHoTamTru, string ChoOHienNay, DateTime TuNgay, DateTime DenNgay, string LyDo)
        {
            this.SoSoTamTru = SoSoTamTru;
            this.MaChuHoTamTru = MaChuHoTamTru;
            this.ChoOHienNay = ChoOHienNay;
            this.TuNgay = TuNgay;
            this.DenNgay = DenNgay;
            this.LyDo = LyDo;
        }
    }
}
