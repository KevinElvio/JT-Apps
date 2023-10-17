using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace JTAPPS_WIN.Models
{
    internal class NewsletterContext
    {
        private readonly string connectionString = "Server=localhost;Port=5432;Database=JT-Apps;User Id=postgres;Password=timotius";

        private readonly List<Newsletter> _newsletters = new();

        public List<Newsletter> Newsletters => _newsletters;

        public bool Insert(Newsletter newsletter)
        {
            bool isSuccess = false;
            byte[] imageBytes;

            using (MemoryStream ms = new MemoryStream())
            {
                Image image = newsletter.Image;
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                imageBytes = ms.ToArray();
            }

            using (NpgsqlConnection connection = new(connectionString))
            {

                string sql = "INSERT INTO newsletter " +
                    "(judul, tanggal, link_berita, homepage_id_homepage, deskripsi, foto) " +
                    "VALUES (@news_title, @news_date, @news_link, @homepage_id, @news_description, @news_image)";

                try
                {
                    using (NpgsqlCommand command = new(sql, connection))
                    {
                        command.Parameters.AddWithValue("news_title", newsletter.Title);
                        command.Parameters.Add("news_date", NpgsqlTypes.NpgsqlDbType.Date).Value = newsletter.Date;
                        command.Parameters.AddWithValue("news_link", newsletter.Link);

                        if (!string.IsNullOrWhiteSpace(newsletter.Description))
                            command.Parameters.AddWithValue("news_description", newsletter.Description);
                        else
                            command.Parameters.AddWithValue("news_description", DBNull.Value);

                        command.Parameters.Add("@homepage_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = 1;
                        command.Parameters.Add("@news_image", NpgsqlTypes.NpgsqlDbType.Bytea).Value = imageBytes;

                        connection.Open();

                        command.Prepare();
                        int rowsAffected = command.ExecuteNonQuery();
                        command.Parameters.Clear();

                        connection.Close();

                        isSuccess = rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                if (isSuccess) _newsletters.Add(newsletter);
            }

            return isSuccess;
        }

        public bool ReadAll()
        {
            bool isSuccess = false;

            try
            {
                using (NpgsqlConnection connection = new(connectionString))
                {
                    string sql = "SELECT * FROM newsletter";

                    using NpgsqlCommand command = new(sql, connection);

                    connection.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    _newsletters.Clear();

                    while (reader.Read())
                    {
                        string description = General.ConvertFromDBVal<string>(reader["deskripsi"]);
                        //Image image;
                        byte[] imageBytes = (byte[])reader["foto"];

                        {
                            //if (imageBytes.Length > 0)
                            //{
                            using MemoryStream ms = new MemoryStream(imageBytes);
                            Image image = Image.FromStream(ms);
                            //}

                            Newsletter newsletter = new
                            (
                                DateOnly.FromDateTime((DateTime)reader["tanggal"]),
                                (string)reader["judul"],
                                description,
                                (string)reader["link_berita"],
                                image,
                                (int)reader["newsletter_id"]
                            );
                            newsletter.Image = image;
                            _newsletters.Add(newsletter);
                        }
                    }

                    isSuccess = reader.HasRows;

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return isSuccess;
        }

        public Newsletter GetById(int id)
        {
            using NpgsqlConnection connection = new(connectionString);

            string sql = "SELECT * FROM newsletter WHERE news_id = @news_id";

            using NpgsqlCommand command = new(sql, connection);
            command.Parameters.Add("news_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;

            connection.Open();

            command.Prepare();
            NpgsqlDataReader reader = command.ExecuteReader();
            command.Parameters.Clear();

            reader.Read();

            string description = General.ConvertFromDBVal<string>(reader["deskripsi"]);
            Image image;
            byte[] imageBytes = (byte[])reader["foto"];

            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                image = Image.FromStream(ms);
            }

            Newsletter newsletter = new
            (
                (DateOnly)reader["tanggal"],
                (string)reader["judul"],
                description,
                (string)reader["link_berita"],
                image,
                (int)reader["newsletter_id"]
            );

            connection.Close();

            return newsletter;
        }

        public void Update(Newsletter newsletter)
        {
            byte[] imageBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                Image image = newsletter.Image;
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                imageBytes = ms.ToArray();
            }
            using (NpgsqlConnection connection = new(connectionString))
            {
                string query = "UPDATE newsletter SET judul=@judul, deskripsi=@deskripsi, link_berita=@link_berita, tanggal=@tanggal, foto=@foto WHERE newsletter_id= @newsletter_id";
                connection.Open();
                using (NpgsqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@judul", newsletter.Title);
                    command.Parameters.AddWithValue("@deskripsi", newsletter.Description);
                    command.Parameters.AddWithValue("@link_berita", newsletter.Link);
                    command.Parameters.AddWithValue("@tanggal", DateTime.Parse(newsletter.Date.ToString()));
                    command.Parameters.AddWithValue("@foto", imageBytes);
                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        {
                            MessageBox.Show("Data berhasil diperbarui!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    connection.Close();
                }
            }
        }

        public bool Delete(Newsletter newsletter)
        {
            bool isSuccess = false;
            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            {
                string sql = "DELETE FROM newsletter WHERE newsletter_id = @news_id";
                connection.Open();
                using (NpgsqlCommand command = new(sql, connection))
                {
                    command.Parameters.Add("news_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = newsletter.Id;
                    command.CommandType = System.Data.CommandType.Text;
                    int jmlDataDiHapus = command.ExecuteNonQuery();
                    if (jmlDataDiHapus > 0) isSuccess = true;
                }
            }
            return isSuccess;
        }
    }
}
