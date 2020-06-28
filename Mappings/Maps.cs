using AutoMapper;
using leave_management.Data;
using leave_management.Models;

namespace leave_management.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationViewModel>().ReverseMap();
            CreateMap<LeaveAllocation, EditLeaveAllocationViewModel>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestViewModel>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeViewModel>().ReverseMap();
        }
    }
}
