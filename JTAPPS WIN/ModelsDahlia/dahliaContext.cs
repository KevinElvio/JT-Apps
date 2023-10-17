using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListPenginapan.ModelsDahlia
{

    internal class dahliaContext
    {
        //public List<dahlia> dahliaList = new List<dahlia>();

        //public bool Read()
        //{
        //    bool isSuccess = false;
        //    string constr = " Host=localhost;Port=5432;Database= JT APPS ;Username=postgres;Password=123";

        //    using (NpgsqlConnection conn = new NpgsqlConnection(constr))
        //    {
        //        string sql =
        //            @"SELECT * FROM ""jenis_kamar""";
        //        //JOIN wisata ON transaksi.id_wisata = wisata.id_wisata
        //        //JOIN tiket ON trasaksi.id_tiket = tiket.id_tiket";

        //        conn.Open();
        //        using NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
        //        {
        //            cmd.CommandText = sql;
        //            NpgsqlDataReader Reader = cmd.ExecuteReader();
        //            dahliaList.Clear();
        //            while (Reader.Read())
        //            {
        //                dahlia newDahlia = new dahlia();

        //                newDahlia.Nama = (string)Reader["nama_jeniskamar"];
        //                // newPenginapan.details = (string)Reader["alamat_wisata"];

        //                dahliaList.Add(newDahlia);
        //            }
        //        }
        //    }
        //    return isSuccess;
        //}
    }
}
