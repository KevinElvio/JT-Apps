using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace JTAPPS_WIN.Models
{
    internal class umkmcontext
    {
        public List<umkm> UmkmList = new List<umkm>();
        public bool Read()
        {
            bool isSuccess = false;
            string constr = "Server=localhost;Port=5432;Database=JT-Apps;User Id=postgres;Password=timotius";

            using (NpgsqlConnection conn = new NpgsqlConnection(constr))
            {
                string sql =
                    @"select deskripsi, lokasi from umkm where umkm_id = 1";

                conn.Open();
                using NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                {
                    cmd.CommandText = sql;
                    NpgsqlDataReader Reader = cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        umkm newUmkm = new umkm();

                        newUmkm.deskripsi = (string)Reader["deskripsi"];
                        newUmkm.lokasi = (string)Reader["lokasi"];

                        UmkmList.Add(newUmkm);
                    }
                }
            }
            return isSuccess;
        }
    }
}
