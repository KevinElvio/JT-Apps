using ListPenginapan;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTAPPS_WIN.Models
{
    internal class PenginapanContext
    {
        public List<PenginapanContext> penginapan = new List<PenginapanContext>();
        public bool Update(penginapan penginapan)
        {
            bool isSucces = false;
            string connectionString = "Server=localhost;Port=5432;Database=JT-Apps;User Id=postgres;Password=timotius";
            byte[] foto = penginapan.selectedImagePath;
            int keterangan1 = 0;
            int keterangan2 = 0;
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string keteranganQuery = "UPDATE paket_kamar SET nomor_kamar = @nomor, harga_paket = @harga, deskripsi_paket = @deskripsi, status = @status WHERE paket_kamar_id = @paketKamarId";
                using (NpgsqlCommand keteranganCommand = new NpgsqlCommand(keteranganQuery, connection))
                {
                    keteranganCommand.Parameters.AddWithValue("@harga", penginapan.harga_paket);
                    keteranganCommand.Parameters.AddWithValue("@nomor", penginapan.nomor_kamar);
                    keteranganCommand.Parameters.AddWithValue("@deskripsi", penginapan.deskripsi_paket);
                    keteranganCommand.Parameters.AddWithValue("@status", penginapan.status);
                    keteranganCommand.Parameters.AddWithValue("@paketKamarId", penginapan.id_paket_kamar);

                    keterangan1 = keteranganCommand.ExecuteNonQuery();

                }

                string judulQuery = "UPDATE jenis_kamar SET nama_jeniskamar = @judul, foto = @foto WHERE id_jeniskamar = @id";
                using (NpgsqlCommand judulCommand = new NpgsqlCommand(judulQuery, connection))
                {
                    judulCommand.Parameters.AddWithValue("@judul", penginapan.nama_jenis_kamar);
                    judulCommand.Parameters.AddWithValue("@foto", penginapan.selectedImagePath);
                    judulCommand.Parameters.AddWithValue("@id", penginapan.id_jenis_kamar);

                    keterangan2 = judulCommand.ExecuteNonQuery();


                }
                if (keterangan1 > 0 && keterangan2 > 0)
                {
                    MessageBox.Show("edit data berhasil.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("edit data gagal.", "Error", MessageBoxButtons.OK);
                }
            }
            return isSucces;
        }
    }
}
