using LeaveManagement.Web.Models.LeaveTypes;
using LeaveManagement.Web.Models.Periods;

namespace LeaveManagement.Web.Models.LeaveAllocations
{
    public class LeaveAllocationVM
    {
        public int Id { get; set; }

        [Display(Name = "Number of Days")]
        public int Days { get; set; }

        [Display(Name = "Alocation Period")]
        public PeriodVM Period { get; set; } = new PeriodVM();

        public LeaveTypeReadOnlyVM LeaveType { get; set; } = new LeaveTypeReadOnlyVM();
    }
}
