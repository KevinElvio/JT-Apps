using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTAPPS_WIN.Models
{
    internal class umkmcontext2
    {
        public List<umkm> UmkmList = new List<umkm>();
        public bool Read()
        {
            bool isSuccess = false;
            string constr = "host=localhost;port=5432;database=JT-Apps;user id=postgres;password=timotius";

            using (NpgsqlConnection conn = new NpgsqlConnection(constr))
            {
                string sql =
                    @"select deskripsi, lokasi from umkm where umkm_id = 2";

                conn.Open();
                using NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                {
                    cmd.CommandText = sql;
                    NpgsqlDataReader Reader = cmd.ExecuteReader();
                    //UmkmList.Clear();
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
