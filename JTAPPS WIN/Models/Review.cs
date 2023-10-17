using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTAPPS_WIN.Models
{
    internal class Review
    {
        public string ulasan { get; set; }
        public int star { get; set; }
        public string id_wisata { get; set; }
        public int user_id { get; set; }
    }
}
