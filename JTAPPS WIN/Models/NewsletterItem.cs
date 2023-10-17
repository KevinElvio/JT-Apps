using JTAPPS_WIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JTAPPS_WIN.Models
{
    public class NewsletterItem
    {
        PictureBox newsItem = new();

        public NewsletterItem(Newsletter newsletter)
        {
            newsItem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            newsItem.BackgroundImageLayout = ImageLayout.Stretch;
            newsItem.Margin = new Padding(3, 2, 3, 2);
            newsItem.Name = "pbNewsletter";
            newsItem.Size = new Size(196, 56);
            newsItem.TabIndex = 8;
            newsItem.TabStop = false;
            newsItem.Tag = newsletter;
            newsItem.Image = newsletter.Image;
        }

        public PictureBox CreateItem()
        {
            return newsItem;
        }
    }
}