using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitur_Homepage_admin_penginapan.Models
{
    public class WisataContext
    {
        private string connectionString = "Server=localhost;Port=5432;Database=JT-Apps;User Id=postgres;Password=timotius";
        public List<DataWisata> WisataList = new List<DataWisata>();

        public bool UpdateData(DataWisata wisata)
        {
            bool isSucces = false;
            int update1 = 0;
            int update2 = 0;
            int update3 = 0;
            byte[] foto = wisata.Image;

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand("UPDATE wisata SET nama_wisata = @Nama, deskripsi_wisata = @Deskripsi, alamat_wisata = @Alamat, foto_wisata = @Foto WHERE id_wisata = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", wisata.id_wisata);
                    command.Parameters.AddWithValue("@Nama", wisata.nama_wisata);
                    command.Parameters.AddWithValue("@Deskripsi", wisata.deskripsi_wisata);
                    command.Parameters.AddWithValue("@Alamat", wisata.alamat_wisata);
                    command.Parameters.AddWithValue("@Foto", wisata.Image);

                    update1 = command.ExecuteNonQuery();
                }

                using (NpgsqlCommand command2 = new NpgsqlCommand("UPDATE tiket SET harga_tiket = @Harga WHERE wisata_id_wisata = @Id", connection))
                {
                    command2.Parameters.AddWithValue("@Id", wisata.id_wisata);
                    command2.Parameters.AddWithValue("@Harga", wisata.harga_tiket);

                    update2 = command2.ExecuteNonQuery();
                }

                using (NpgsqlCommand command4 = new NpgsqlCommand("UPDATE paket_makanan SET nama_paketmakanan = @Menupaket WHERE wisata_id_wisata = @Id", connection))
                {
                    command4.Parameters.AddWithValue("@Id", wisata.id_wisata);
                    command4.Parameters.AddWithValue("@Menupaket", wisata.menu_paket);

                    update3 = command4.ExecuteNonQuery();
                }
                if (update1 > 0 && update2 > 0 && update3 > 0)
                {
                    MessageBox.Show("Edit data berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Edit data gagal", "Error", MessageBoxButtons.OK);
                }
            }

            return isSucces;
        }

        public bool DeleteData(DataWisata wisata)
        {
            bool isSucces = false;
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                NpgsqlCommand command1 = new NpgsqlCommand("DELETE FROM detail_wisata WHERE wisata_id_wisata = @Id", connection);
                command1.Parameters.AddWithValue("@Id", wisata.id_wisata);
                int jumlahData1 = command1.ExecuteNonQuery();
            }

            return isSucces;
        }
    }
}
