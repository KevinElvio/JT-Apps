using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTAPPS_WIN.Models;

namespace JTAPPS_WIN.Context
{
    public class CUser
    {
        public List<User> listUser = new List<User>();

        public bool Read()
        {
            bool isSuccess = false;

            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=JT-Apps;User Id=postgres;Password=timotius"))
            {
                conn.Open();

                string sql = "select u.user_id, u.nama_lengkap, wt.nama_wisata, tr.tgl_transaksi, tr.kuantitas, t.nama_tiket, t.harga_tiket, pk.nomor_kamar, pk.harga_paket, jk.nama_jeniskamar, dt.transaksi_transaksi_id, tr.kuantitas * t.harga_tiket as biaya_tiket from jenis_kamar jk join paket_kamar pk on jk.id_jeniskamar = pk.jenis_kamar_id_jeniskamar join booking_hotel bht on bht.paket_kamar_paket_kamar_id = pk.paket_kamar_id join \"User\" u on u.user_id = bht.user_user_id join transaksi tr on u.user_id = tr.user_user_id join detail_transaksi dt on tr.transaksi_id = dt.transaksi_transaksi_id join wishlist w on w.wishlist_id = dt.wishlist_wishlist_id join tiket t on t.tiket_id = w.tiket_tiket_id join wisata wt on wt.id_wisata = t.wisata_id_wisata WHERE u.user_id = @iduser";
                using NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@iduser", 1);
                using NpgsqlDataReader reader = cmd.ExecuteReader();

                listUser.Clear();

                while (reader.Read())
                {
                    User user = new User();

                    user.IDUser = (int)reader["user_id"];
                    user.Nama = (string)reader["nama_lengkap"];
                    user.Wisata = (string)reader["nama_wisata"];
                    user.NamaTiket = (string)reader["nama_tiket"];
                    user.Kuantitas = (int)reader["kuantitas"];
                    user.HargaTiket = Decimal.Parse(reader["harga_tiket"].ToString());
                    user.NomorKamar = (string)reader["nomor_kamar"];
                    user.Namakamar = (string)reader["nama_jeniskamar"];
                    user.Paketkamar = Decimal.Parse(reader["harga_paket"].ToString());
                    user.TglTransaksi = (DateTime)reader["tgl_transaksi"];
                    user.IDDetTrans = (int)reader["transaksi_transaksi_id"];

                    listUser.Add(user);
                }
            }

            return isSuccess;
        }
    }
}
