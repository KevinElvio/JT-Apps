using JTAPPS_WIN.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTAPPS_WIN.Context
{
    public class CTotalTiket
    {
        public List<TotalTiket> listTotalTiket = new List<TotalTiket>();

        public bool Read()
        {
            bool isSuccess = false;

            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=JT-Apps;User Id=postgres;Password=timotius"))
            {
                conn.Open();
                string sql2 = "select sum(t.harga_tiket * tr.kuantitas) as total_tiket from \"User\" u join transaksi tr on u.user_id = tr.user_user_id join detail_transaksi dt on tr.transaksi_id = dt.transaksi_transaksi_id join wishlist w on w.wishlist_id = dt.wishlist_wishlist_id join tiket t on t.tiket_id = w.tiket_tiket_id join wisata wt on wt.id_wisata = t.wisata_id_wisata where u.user_id = @iduser";
                using NpgsqlCommand cmd2 = new NpgsqlCommand(sql2, conn);
                cmd2.Parameters.AddWithValue("@iduser", 1);
                using NpgsqlDataReader reader2 = cmd2.ExecuteReader();

                listTotalTiket.Clear();


                while (reader2.Read())
                {
                    TotalTiket totalTiket = new TotalTiket();

                    totalTiket.TiketTotal = Decimal.Parse(reader2["total_tiket"].ToString());

                    listTotalTiket.Add(totalTiket);

                }
            }

            return isSuccess;
        }
    }
}
