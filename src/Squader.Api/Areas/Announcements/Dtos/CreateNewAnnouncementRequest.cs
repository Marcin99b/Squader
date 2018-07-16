using System;
using System.Collections.Generic;

namespace Squader.Api.Areas.Announcements.Dtos
{

    public class CreateNewAnnouncementRequest : BaseAnnouncementRequest
    {
        public Guid TeamId { get; set; }
    }
}
