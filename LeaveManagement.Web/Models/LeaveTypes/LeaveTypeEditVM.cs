﻿using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models.LeaveTypes
{
    public class LeaveTypeEditVM : BaseLeaveTypeVM
    {
        [Required]
        [Length(4, 150, ErrorMessage = "You have violated the length requirements.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(1, 90)]
        [Display(Name = "Maximun Allocation of Days")]
        public int NumberOfDays { get; set; }
    }
}
