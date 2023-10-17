using Admin__FAQ__V2;
using bagianAB;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fitur_Homepage_admin_penginapan;
using Fitur_Homepage_admin_penginapan.Models;

namespace Fitur_Homepage_admin_penginapan
{
    public partial class Edit_detail_wisata : Form
    {
        Models.WisataContext WisataContext;
        private string connectionString = "Server=localhost; Port=5432; Database=JT-Apps; User Id=postgres; Password=timotius;";
        private string Id;
        private string imagePath;
        byte[] imageData;


        public Edit_detail_wisata()
        {
            InitializeComponent();
            LoadData(Id);
            WisataContext = new Models.WisataContext();
        }

        public void LoadData(string Id)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand($"SELECT t1.nama_wisata, t1.deskripsi_wisata, t1.alamat_wisata, t1.foto_wisata, t3.nama_fasilitas, t4.harga_tiket " +
                        $"FROM wisata AS t1 JOIN detail_wisata AS t2 ON t1.id_wisata = t2.wisata_id_wisata " +
                        $"JOIN fasilitas_wisata AS t3 ON t2.fasilitas_wisata_fasilitas_wisata_id = t3.fasilitas_wisata_id " +
                        $"JOIN tiket AS t4 ON t1.id_wisata = t4.wisata_id_wisata " +
                        $"WHERE t1.id_wisata = '{Id}'", connection);

                    NpgsqlDataReader reader = command.ExecuteReader();
                    List<string> fasilitas = new List<string>();
                    List<string> menupaket = new List<string>();

                    if (reader.Read())
                    {
                        Judul.Text = reader["nama_wisata"].ToString();
                        Keterangan.Text = reader["deskripsi_wisata"].ToString();
                        Kapasitas.Text = reader["harga_tiket"].ToString();
                        Harga.Text = reader["alamat_wisata"].ToString();
                        fasilitas.Add(reader["nama_fasilitas"].ToString());
                    }

                    reader.Close();

                    NpgsqlCommand command1 = new NpgsqlCommand($"SELECT t1.nama_paketmakanan FROM paket_makanan AS t1 " +
                        $"JOIN wisata AS t2 ON t1.wisata_id_wisata = t2.id_wisata " +
                        $"WHERE t2.id_wisata = '{Id}'", connection);

                    NpgsqlDataReader reader1 = command1.ExecuteReader();

                    while (reader1.Read())
                    {
                        menupaket.Add(reader1["nama_paketmakanan"].ToString());
                    }

                    reader1.Close();
                    connection.Close();

                    NomorKamar.Text = string.Join(", ", fasilitas);
                    Fasilitas.Text = string.Join(", ", menupaket);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif)|*.jpg;*.jpeg;*.png;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    imagePath = openFileDialog.FileName;
                    pictureBox1.Image = Image.FromFile(imagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void Simpan_Click(object sender, EventArgs e)
        {
            string judul = Judul.Text;
            string deskripsi = Keterangan.Text;
            string hargaTiket = Kapasitas.Text;
            string fasilitas = NomorKamar.Text;
            string menupaket = Fasilitas.Text;
            string lokasi = Harga.Text;

            if (string.IsNullOrEmpty(imagePath))
            {
                MessageBox.Show("Pilih gambar terlebih dahulu.");
                return;
            }

            byte[] gambar = File.ReadAllBytes(imagePath);

            string wisataId = GenerateNextWisataId(); // Generate ID baru untuk tabel wisata
            InsertDataWisata(wisataId, judul, deskripsi, lokasi, gambar);

            int fasilitasId = GenerateNextFasilitasId(); // Generate ID baru untuk tabel fasilitas_wisata
            InsertDataFasilitas(fasilitasId, wisataId, fasilitas);

            string tiketNama = judul; // Generate nama tiket berdasarkan judul
            InsertDataTiket(wisataId, tiketNama, hargaTiket); // Menggunakan wisataId sebagai parameter

            this.Close();
            DestinasiWisataAdmin wisata = new DestinasiWisataAdmin();
            wisata.Show();
            this.Hide();
        }

        private void InsertDataWisata(string wisataId, string judul, string keterangan, string lokasi, byte[] gambar)
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    using (NpgsqlCommand comm = new NpgsqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandType = CommandType.Text;
                        comm.CommandText = "INSERT INTO wisata (id_wisata, nama_wisata, deskripsi_wisata, alamat_wisata, foto_wisata) " +
                            "VALUES (@wisataId, @judul, @keterangan, @lokasi, @gambar)";
                        comm.Parameters.AddWithValue("@wisataId", wisataId);
                        comm.Parameters.AddWithValue("@judul", judul);
                        comm.Parameters.AddWithValue("@keterangan", keterangan);
                        comm.Parameters.AddWithValue("@lokasi", lokasi);
                        comm.Parameters.AddWithValue("@gambar", gambar);
                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void InsertDataFasilitas(int fasilitasId, string wisataId, string fasilitas)
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    using (NpgsqlCommand comm = new NpgsqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandType = CommandType.Text;
                        comm.CommandText = "INSERT INTO fasilitas_wisata (fasilitas_wisata_id, nama_fasilitas) " +
                            "VALUES (@fasilitasId, @fasilitas)";
                        comm.Parameters.AddWithValue("@fasilitasId", fasilitasId);
                        comm.Parameters.AddWithValue("@fasilitas", fasilitas);
                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void InsertDataTiket(string wisataId, string namaTiket, string hargaTiket)
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    using (NpgsqlCommand comm = new NpgsqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandType = CommandType.Text;
                        comm.CommandText = "INSERT INTO tiket (wisata_id_wisata, nama_tiket, harga_tiket) " +
                            "VALUES (@wisataId, @namaTiket, @hargaTiket)";
                        comm.Parameters.AddWithValue("@wisataId", wisataId);
                        comm.Parameters.AddWithValue("@namaTiket", namaTiket);
                        int hargaTiketInt;
                        if (int.TryParse(hargaTiket, out hargaTiketInt))
                            comm.Parameters.AddWithValue("@hargaTiket", hargaTiketInt);
                        else
                            comm.Parameters.AddWithValue("@hargaTiket", DBNull.Value);
                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private string GenerateNextWisataId()
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    using (NpgsqlCommand comm = new NpgsqlCommand("SELECT id_wisata FROM wisata ORDER BY id_wisata DESC LIMIT 1", conn))
                    {
                        object lastIdObj = comm.ExecuteScalar();
                        string lastId = lastIdObj != null ? lastIdObj.ToString() : "A00"; // ID default jika tabel kosong
                        string newId = GenerateNextId(lastId);
                        return newId;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return null;
        }

        private int GenerateNextFasilitasId()
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    using (NpgsqlCommand comm = new NpgsqlCommand("SELECT MAX(fasilitas_wisata_id) FROM fasilitas_wisata", conn))
                    {
                        object lastIdObj = comm.ExecuteScalar();
                        int lastId;
                        if (lastIdObj != null && int.TryParse(lastIdObj.ToString(), out lastId))
                        {
                            int newId = lastId + 1;
                            return newId;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return 1; // Jika tidak ada data sebelumnya, kembalikan nilai awal 1
        }

        private int GenerateNextTiketId()
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    using (NpgsqlCommand comm = new NpgsqlCommand("SELECT MAX(tiket_id) FROM tiket", conn))
                    {
                        object lastIdObj = comm.ExecuteScalar();
                        int lastId;
                        if (lastIdObj != null && int.TryParse(lastIdObj.ToString(), out lastId))
                        {
                            int newId = lastId + 1;
                            return newId;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return 1; // Jika tidak ada data sebelumnya, kembalikan nilai awal 1
        }

        // Generate ID baru berdasarkan ID terakhir
        private string GenerateNextId(string lastId)
        {
            string prefix = lastId.Substring(0, 1);
            int number = int.Parse(lastId.Substring(1));
            string newId = prefix + (number + 1).ToString("D2"); // Format nomor 2 digit dengan leading zero (misal: A01, A02)
            return newId;
        }

        private void Simpan_Click_1(object sender, EventArgs e)
        {
            string id_wisata = Id;
            string nama_wisata = Judul.Text;
            string deskripsi_wisata = Keterangan.Text;
            string alamat_wisata = Harga.Text;
            decimal harga_tiket = decimal.Parse(Kapasitas.Text);
            string fasilitas = NomorKamar.Text;
            string menu_paket = Fasilitas.Text;
            byte[] Image = imageData;

            if (string.IsNullOrEmpty(Judul.Text) || string.IsNullOrEmpty(Keterangan.Text) || string.IsNullOrEmpty(Fasilitas.Text) || string.IsNullOrEmpty(Fasilitas.Text) || string.IsNullOrEmpty(Harga.Text))
            {
                MessageBox.Show("Ada kolom yang kosong. Harap masukkan nilai yang di inginkan.", "Pemberitahuan");
                return;
            }
            if (!long.TryParse(Kapasitas.Text, out long harga))
            {
                MessageBox.Show("Harap mengisi kolom harga yang tersedia", "Pemberitahuan");
                return;
            }
            DataWisata wisata = new DataWisata()
            {
                id_wisata = id_wisata,
                nama_wisata = nama_wisata,
                deskripsi_wisata = deskripsi_wisata,
                alamat_wisata = alamat_wisata,
                harga_tiket = harga_tiket,
                fasilitas = fasilitas,
                menu_paket = menu_paket,
                Image = Image,
            };
            WisataContext.UpdateData(wisata);
        }

        private void Hapus_Click(object sender, EventArgs e)
        {
            string id_wisata = Id;
            DataWisata dataWisata = new DataWisata
            {
                id_wisata = id_wisata
            };
            DialogResult dr = MessageBox.Show("Apa anda yakin ingin menghapus?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                WisataContext.DeleteData(dataWisata);
                MessageBox.Show("Data berhasil dihapus", "Konfirmasi");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form destinasi_admin = new DestinasiWisataAdmin();
            destinasi_admin.Show();
            this.Hide();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form persetujuan_booking = new PersetujuanBookingAdmin();
            persetujuan_booking.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form FAQ_admin = new AdminFAQ();
            FAQ_admin.Show();
            this.Hide();
        }
    }
}
