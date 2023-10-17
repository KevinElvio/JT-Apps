using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTAPPS_WIN.Models
{
    internal class penginapan
    {
        public int id_paket_kamar { get; set; }
        public string id_jenis_kamar { get; set; }

        public string nama_jenis_kamar { get; set; }
        public byte[] selectedImagePath { get; set; }
        public string nomor_kamar { get; set; }
        public int harga_paket { get; set; }
        public string deskripsi_paket { get; set; }
        public int status { get; set; }

        public int paketKamarId { get; set; }
        public string id_jeniskamar { get; set; }
    }
}
