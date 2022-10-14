using System;
using System.Collections.Generic;

namespace ElectionCampaignBackEnd2.Model
{
    public partial class GetAllAttendanceDetailsWithWorkingHour
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? Date { get; set; }
        public string? TimeIn { get; set; }
        public string? TimeOut { get; set; }
        public string? WorkingHours { get; set; }
    }
}
