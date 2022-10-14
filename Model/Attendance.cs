using System;
using System.Collections.Generic;

namespace ElectionCampaignBackEnd2.Model
{
    public partial class Attendance
    {
        public int AttendanceId { get; set; }
        public int? EmployeeId { get; set; }
        public string? Date { get; set; }
        public string? TimeIn { get; set; }
        public string? Location { get; set; }
        public string? TimeOut { get; set; }

        public virtual UserDetail? Employee { get; set; }
    }
}
