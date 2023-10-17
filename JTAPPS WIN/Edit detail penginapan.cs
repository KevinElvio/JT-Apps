using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JTAPPS_WIN.Models;

namespace Inap
{
    public partial class Edit_detail_penginapan : Form
    {
        //private string connectionString = "Server=localhost;Port=5432;Database=JT-Apps;User Id=postgres;Password=timotius";
        //public string queryCommand;
        //private void LoadDataFromDatabase()
        //{
        //    using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
        //    {
        //        conn.Open();

        //        using (NpgsqlCommand comm = new NpgsqlCommand())
        //        {
        //            comm.Connection = conn;
        //            comm.CommandType = CommandType.Text;
        //            comm.CommandText = $"select * from \"Paket_Kamar\" pk join \"Jenis_Kamar\" jk on pk.\"id_jenis_kamar\" = jk.\"id_jenis_kamar\" where jk.\"id_jenis_kamar\" = 'SR01'";
        //            NpgsqlDataReader reader = comm.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                //pictureBox1.Image = reader[""]
        //                textboxjudul.Text += reader["nama_jenis_kamar"].ToString() + Environment.NewLine;
        //                textboxnokamar.Text = reader["nomor_kamar"].ToString() + Environment.NewLine;
        //                textboxfasilitas.Text += reader["deskripsi_paket"].ToString() + Environment.NewLine;
        //                textboxharga.Text += reader["harga_paket"].ToString() + Environment.NewLine;
        //                textboxstatus.Text += reader["status"].ToString() + Environment.NewLine;

        //            }

        //            reader.Close();
        //        }
        //    }
        //}
        Homepage_Admin_Penginapan form1 = new Homepage_Admin_Penginapan();



        PenginapanContext penginapancontext;

        private string selectedImagePath = "";

        byte[] selectedImageBytes;
        string id_jenis_kamar;
        int id_paket_kamar;
        public Edit_detail_penginapan()
        {
            penginapancontext = new PenginapanContext();
            InitializeComponent();
            //LoadDataFromDatabase();

        }

        private void Edit_detail_penginapan_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Kapasitas_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
        }

        private void button8_Click(object sender, EventArgs e)
        {
        }

        private void button10_Click(object sender, EventArgs e)
        {
        }

        private void Keterangan1_Click(object sender, EventArgs e)
        {

        }

        private void Judul_TextChanged(object sender, EventArgs e)
        {

        }

        private void harga1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            selectedImage();
        }

        private void Simpan_Click(object sender, EventArgs e)
        {
            string judul = tbjudul.Text;
            byte[] gambar = selectedImageBytes;
            string no_kamar = tbnokamar.Text;
            string fasilitas = tbfasilitas.Text;
            int status;
            int harga;
            string id_jenis_Kamar = id_jenis_kamar;
            int id_paket_Kamar = id_paket_kamar;

            if (string.IsNullOrEmpty(judul) || string.IsNullOrEmpty(no_kamar) || string.IsNullOrEmpty(fasilitas))
            {
                MessageBox.Show("Harap mengisi semua kolom teks", "Notifikasi");
                return;
            }

            if (!int.TryParse(tbstatus.Text, out status))
            {
                MessageBox.Show("Input status tidak valid. Harap masukkan angka yang benar.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(tbharga.Text, out harga))
            {
                MessageBox.Show("Input harga tidak valid. Harap masukkan angka yang benar.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (gambar == null)
            {
                MessageBox.Show("Masukkan gambar terlebih dahulu");
            }
            else
            {
                penginapan newpenginapan = new penginapan()
                {
                    id_jenis_kamar = id_jenis_Kamar,
                    id_paket_kamar = id_paket_Kamar,
                    nama_jenis_kamar = judul,
                    selectedImagePath = gambar,
                    nomor_kamar = no_kamar,
                    deskripsi_paket = fasilitas,
                    status = status,
                    harga_paket = harga
                };
                bool isSucces = penginapancontext.Update(newpenginapan);
            }



        }
        public void selectedImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "File Gambar|*.jpg;*.png;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
                pbpenginapan.Image = Image.FromFile(selectedImagePath);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    pbpenginapan.Image.Save(memoryStream, ImageFormat.Jpeg);
                    selectedImageBytes = memoryStream.ToArray();
                }
            }
        }
        public void SetInap(Inap inap)
        {
            //Codingan set tiap textbox dan komponen lainnya sesuai objek newsletternya
            //pbpenginapan.Text = inap.;
            tbjudul.Text = inap.NamaJenisKamar;
            tbnokamar.Text = inap.NomorKamar;
            tbfasilitas.Text = inap.DeskripsiPaket;
            tbharga.Text = inap.HargaPaket.ToString();
            tbstatus.Text = inap.Status.ToString();
            pbpenginapan.Image = inap.Image;
            id_jenis_kamar = inap.IdJenisKamar;
            id_paket_kamar = inap.IdPaketKamar;

        }
    }
}
