using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTAPPS_WIN.Models
{
    public class User
    {
        public int IDUser { get; set; }
        public string Nama { get; set; }
        public string Wisata { get; set; }
        public string NamaTiket { get; set; }
        public decimal HargaTiket { get; set; }
        public int Kuantitas { get; set; }
        public DateTime TglTransaksi { get; set; }
        public decimal Paketkamar { get; set; }
        public string NomorKamar { get; set; }
        public string Namakamar { get; set; }
        public int IDDetTrans { get; set; }

    }
}