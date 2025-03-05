using AutoMapper;
using LeaveManagement.Web.Models.LeaveAllocations;
using LeaveManagement.Web.Models.LeaveTypes;
using LeaveManagement.Web.Models.Periods;

namespace LeaveManagement.Web.MappingProfiles
{
    public class LeaveAllocationAutoMapperProfile : Profile
    {
        public LeaveAllocationAutoMapperProfile()
        {
            CreateMap<LeaveAllocation, LeaveAllocationVM>();
            CreateMap<LeaveAllocation, LeaveAllocationEditVM>();
            CreateMap<ApplicationUser, EmployeeListVM>();
            CreateMap<Period, PeriodVM>();
        }
    }
}
