﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Squader.Api.Areas.Announcements.Dtos
{
    public class UpdateAnnouncementRequest : BaseAnnouncementRequest
    {
        public Guid AnnouncementId { get; set; }
    }
}
