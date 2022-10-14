using System;
using System.Collections.Generic;

namespace ElectionCampaignBackEnd2.Model
{
    public partial class GetAllAttendanceDetail
    {
        public int AttendanceId { get; set; }
        public int? EmployeeId { get; set; }
        public string? Date { get; set; }
        public string? TimeIn { get; set; }
        public string? Location { get; set; }
        public string? TimeOut { get; set; }
        public string? Name { get; set; }
    }
}
