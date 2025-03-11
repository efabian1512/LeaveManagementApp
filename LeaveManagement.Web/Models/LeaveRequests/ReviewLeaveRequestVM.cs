using LeaveManagement.Web.Models.LeaveAllocations;
using System.ComponentModel;

namespace LeaveManagement.Web.Models.LeaveRequests
{
    public class ReviewLeaveRequestVM : LeaveRequestReadOnlyVM
    {
        public EmployeeListVM Employee { get; set; } = new EmployeeListVM();

        [DisplayName("Additional Information")]
        public string RequestComments { get; set; }
    }
}