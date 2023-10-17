using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTAPPS_WIN.Models
{
    internal class MytiketContext
    {
        public List<MyTiket> TiketList = new List<MyTiket>();

        public bool Read()
        {
            bool isSuccess = false;
            string constr = "Server=localhost;Port=5432;Database=JT-Apps;User Id=postgres;Password=timotius";
                //"Host=localhost;Port=5432;Database='JT-APPS ';Username=postgres;Password=Memew001";

            using (NpgsqlConnection conn = new NpgsqlConnection(constr))
            {
                string sql =
                    @"SELECT tr.""transaksi_id"",tr.""kuantitas"", w.""nama_wisata"",w.""deskripsi_wisata"", w.""alamat_wisata"", w.""foto_wisata"", t.""harga_tiket"", avg(p.""rating_tempat"") as rating, sum(t.""harga_tiket"" * tr.""kuantitas"") as jumlah FROM penilaian p JOIN wisata w ON (p.""wisata_id_wisata"" = w.""id_wisata"") JOIN tiket t ON (w.""id_wisata"" = t.""wisata_id_wisata"") JOIN Wishlist ws ON (ws.""tiket_tiket_id"" = t.""tiket_id"") JOIN detail_transaksi dt ON (ws.""wishlist_id"" = dt.""wishlist_wishlist_id"") JOIN Transaksi tr ON (tr.""transaksi_id"" = dt.""transaksi_transaksi_id"") group by tr.""transaksi_id"", tr.""kuantitas"", w.""nama_wisata"",w.""deskripsi_wisata"",w.""alamat_wisata"", w.""foto_wisata"",t.""harga_tiket"";";

                conn.Open();
                using NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                {
                    cmd.CommandText = sql;
                    NpgsqlDataReader Reader = cmd.ExecuteReader();
                    TiketList.Clear();
                    while (Reader.Read())
                    {
                        MyTiket newTiket = new MyTiket();

                        newTiket.NamaWisata = (string)Reader["nama_wisata"];
                        newTiket.AlamatWisata = (string)Reader["alamat_wisata"];
                        newTiket.HargaTiket = Decimal.Parse(Reader["jumlah"].ToString());
                        newTiket.Kuantitas = (int)Reader["kuantitas"];
                        newTiket.Deskripsi = (string)Reader["deskripsi_wisata"];
                        newTiket.DetailHarga = Decimal.Parse(Reader["harga_tiket"].ToString());
                        newTiket.Rating = float.Parse(Reader["rating"].ToString());

                        TiketList.Add(newTiket);

                        byte[] imageBytes = (byte[])Reader["foto_wisata"];
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            Image image = Image.FromStream(ms);
                            newTiket.Image = image;
                        }
                    }
                }
            }
            return isSuccess;
        }
    }
}
