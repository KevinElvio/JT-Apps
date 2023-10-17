using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTAPPS_WIN.Models
{
    public class MyTiket
    {
        public string NamaWisata { get; set; }
        public string AlamatWisata { get; set; }
        public decimal HargaTiket { get; set; }
        public int Kuantitas { get; set; }
        public string Deskripsi { get; set; }
        public decimal DetailHarga { get; set; }
        public float Rating { get; set; }
        public Image Image { get; set; }
    }
}
