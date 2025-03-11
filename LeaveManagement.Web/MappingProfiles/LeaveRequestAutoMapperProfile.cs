using AutoMapper;
using LeaveManagement.Web.Models.LeaveRequests;

namespace LeaveManagement.Web.MappingProfiles
{
    public class LeaveRequestAutoMapperProfile : Profile
    {
        public LeaveRequestAutoMapperProfile()
        {
            CreateMap<LeaveRequestCreateVM, LeaveRequest>();
        }
    }
}
