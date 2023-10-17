using JTAPPS_WIN.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTAPPS_WIN.Context
{
    public class CTotalKamar
    {
        public List<TotalKamar> listTotalKamar = new List<TotalKamar>();

        public bool Read()
        {
            bool isSuccess = false;

            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=JT-Apps;User Id=postgres;Password=timotius"))
            {
                conn.Open();
                string sql1 = "select sum(pk.harga_paket) as total_kamar from jenis_kamar jk join paket_kamar pk on jk.id_jeniskamar = pk.jenis_kamar_id_jeniskamar join booking_hotel bht on bht.paket_kamar_paket_kamar_id = pk.paket_kamar_id join \"User\" u on u.user_id = bht.user_user_id where u.user_id = @iduser";
                using NpgsqlCommand cmd1 = new NpgsqlCommand(sql1, conn);
                cmd1.Parameters.AddWithValue("@iduser", 1);
                using NpgsqlDataReader reader1 = cmd1.ExecuteReader();

                listTotalKamar.Clear();


                while (reader1.Read())
                {
                    TotalKamar totalKamar = new TotalKamar();

                    totalKamar.KamarTotal = Decimal.Parse(reader1["total_kamar"].ToString());

                    listTotalKamar.Add(totalKamar);

                }
            }

            return isSuccess;
        }
    }
}
