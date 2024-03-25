using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCVCore.EntityLayer.Concrete
{
    public class Announcement
    {
        public int AnnouncementId { get; set; }
        public string? Title { get; set; }
        public DateTime? Date { get; set; }
        public string? Status { get; set; }
        public string? Content { get; set; }
    }
}
