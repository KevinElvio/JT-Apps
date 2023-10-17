using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTAPPS_WIN.Models
{
    internal class ReviewContext
    {
        public List<Review> reviewList = new List<Review>();
        public bool Read()
        {
            bool isSuccess = false;
            string constr = " Host=localhost;Port=5432;Database= JT-Apps;Username=postgres;Password=123456";

            using (NpgsqlConnection conn = new NpgsqlConnection(constr))
            {
                string sql =
                    @"SELECT * FROM ""penilaian"" ORDER BY penilaian_id DESC;";

                conn.Open();
                using NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                {
                    cmd.CommandText = sql;
                    NpgsqlDataReader Reader = cmd.ExecuteReader();
                    reviewList.Clear();
                    while (Reader.Read())
                    {
                        Review newReview = new Review();

                        newReview.ulasan = (string)Reader["review"];
                        newReview.star = (int)Reader["rating_tempat"];
                        //newReview.user = (string)Reader["id_wisata"];

                        reviewList.Add(newReview);
                    }
                }
            }
            return isSuccess;
        }
        public bool Insert(Review newReview)
        {
            bool isSuccess = false;
            ////string constr = " Host=localhost;Port=5432;Database= JT-Apps;Username=postgres;Password=sppjdyx1";
            string constr = " Host=localhost;Port=5432;Database= JT-Apps;Username=postgres;Password=timotius";
            using (NpgsqlConnection conn = new NpgsqlConnection(constr))
            {
                string sql =
                    @"insert into penilaian (wisata_id_wisata,review,rating_tempat,user_user_id) values(@id_wisata,@review,@rating_tempat,@user_id)";
                conn.Open();
                using NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@review", newReview.ulasan));
                    cmd.Parameters.AddWithValue("@id_wisata", newReview.id_wisata);
                    cmd.Parameters.Add(new NpgsqlParameter("@rating_tempat", newReview.star));
                    cmd.Parameters.AddWithValue("@user_id", newReview.user_id);

                    cmd.CommandType = System.Data.CommandType.Text;
                    int jmlDataBaru = cmd.ExecuteNonQuery();
                    if (jmlDataBaru > 0)
                    {
                        isSuccess = true;
                        reviewList.Add(newReview);
                    }
                }
            }

            return isSuccess;
        }
    }
}
