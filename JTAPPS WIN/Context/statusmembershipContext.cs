using DesktopApp;
using JTAPPS_WIN.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTAPPS_WIN.Context
{
    internal class statusmembershipContext
    {
        public List<statusmembership> statuslist = new List<statusmembership>();

        public bool Read()
        {
            bool isSuccess = false;
            string constr = "Server=localhost;Port=5432;Database=JT-Apps;User Id=postgres;Password=timotius";

            using (NpgsqlConnection connection = new NpgsqlConnection(constr))
            {
                string sql = @"SELECT membership_membership_id FROM ""User"" WHERE email = @email";

                connection.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("email", Formlogin.TempEmail);

                    using (NpgsqlDataReader Reader = cmd.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            statusmembership newStatus = new statusmembership();
                            newStatus.status = (int)Reader["membership_membership_id"];
                            statuslist.Add(newStatus);
                        }
                    }
                }
            }

            isSuccess = true;
            return isSuccess;
        }
    }
}

