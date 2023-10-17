using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTAPPS_WIN.Models
{
    public class Newsletter
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Link { get; set; }
        public Image Image { get; set; }

        public Newsletter(DateOnly date, string title, string description, string link, Image image)
        {
            Date = date;
            Title = title;
            Description = description;
            Link = link;
            Image = image;
        }

        public Newsletter(DateOnly date, string title, string description, string link, Image image, int id) : this(date, title, description, link, image)
            => this.Id = id;

    }
}
