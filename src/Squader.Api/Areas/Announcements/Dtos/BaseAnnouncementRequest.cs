using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Squader.Api.Areas.Announcements.Dtos
{
    public class BaseAnnouncementRequest
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Requirements { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}
