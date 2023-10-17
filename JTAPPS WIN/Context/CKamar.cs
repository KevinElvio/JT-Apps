using JTAPPS_WIN.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JTAPPS_WIN.Context
{
    public class CKamar
    {
        public List<Kamar> listKamar = new List<Kamar>();

        public bool Read()
        {
            bool isSuccess = false;

            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=JT-Apps;User Id=postgres;Password=timotius"))
            {
                conn.Open();
                string sql = "select u.user_id, u.nama_lengkap, wt.nama_wisata, tr.tgl_transaksi, tr.kuantitas, t.nama_tiket, t.harga_tiket, pk.nomor_kamar, pk.harga_paket, jk.nama_jeniskamar, dt.transaksi_transaksi_id, tr.kuantitas * t.harga_tiket as biaya_tiket from jenis_kamar jk join paket_kamar pk on jk.id_jeniskamar = pk.jenis_kamar_id_jeniskamar join booking_hotel bht on bht.paket_kamar_paket_kamar_id = pk.paket_kamar_id join \"User\" u on u.user_id = bht.user_user_id join transaksi tr on u.user_id = tr.user_user_id join detail_transaksi dt on tr.transaksi_id = dt.transaksi_transaksi_id join wishlist w on w.wishlist_id = dt.wishlist_wishlist_id join tiket t on t.tiket_id = w.tiket_tiket_id join wisata wt on wt.id_wisata = t.wisata_id_wisata";
                using NpgsqlCommand cmd2 = new NpgsqlCommand(sql, conn);
                cmd2.Parameters.AddWithValue("jk.id_jeniskamar", "MT02");
                using NpgsqlDataReader reader2 = cmd2.ExecuteReader();

                listKamar.Clear();


                while (reader2.Read())
                {
                    Kamar kamar = new Kamar();

                    kamar.HargaKamar = Decimal.Parse(reader2["harga_paket"].ToString());
                    kamar.KamarNama = (string)reader2["nama_jeniskamar"];

                    listKamar.Add(kamar);

                }
            }

            return isSuccess;
        }
    }
}
