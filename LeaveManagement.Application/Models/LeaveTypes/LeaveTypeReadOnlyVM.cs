﻿namespace LeaveManagement.Application.Models.LeaveTypes
{
    public class LeaveTypeReadOnlyVM : BaseLeaveTypeVM
    {
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Maximun Allocation of Days")]
        public int NumberOfDays { get; set; }
    }
}
