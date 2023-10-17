using JTAPPS_WIN.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTAPPS_WIN.Context
{
    internal class KritikSaranContext
    {
        public List<KritikSaran> kritikSaranlist = new List<KritikSaran>();
        public bool Insert(KritikSaran newkritik)
        {
            bool isSuccess = false;
            string constr = "host=localhost;port=5432;database=JT-Apps;user id=postgres;password=Adriano12!";
            using (NpgsqlConnection conn = new NpgsqlConnection(constr))
            {
                string sql =
                    @"insert into ""kritik_saran"" (kritik_saran, user_user_id) values(@kritiksaran,@user_id)";
                conn.Open();
                using NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                {
                    //cmd.Parameters.Add(new NpgsqlParameter("@nama", newkritik.nama));
                    //cmd.Parameters.Add(new NpgsqlParameter("@email", newkritik.email));
                    cmd.Parameters.Add(new NpgsqlParameter("@kritiksaran", newkritik.kritiksaran));
                    cmd.Parameters.AddWithValue("@user_id", newkritik.user_id);

                    cmd.CommandType = System.Data.CommandType.Text;
                    int jmlDataBaru = cmd.ExecuteNonQuery();
                    if (jmlDataBaru > 0)
                    {
                        isSuccess = true;
                        kritikSaranlist.Add(newkritik);
                    }
                }
            }
            return isSuccess;
        }
    }
}
