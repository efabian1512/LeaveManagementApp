
using AutoMapper;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models.LeaveAllocations;
using LeaveManagement.Web.Services.Periods;
using LeaveManagement.Web.Services.UserInfo;
using Microsoft.EntityFrameworkCore;


namespace LeaveManagement.Web.Services.LeaveAllocations;

public class LeaveAllocationsService(
    ApplicationDbContext _context, 
    IMapper _mapper, 
    IUserService _userService, 
     IPeriodsService _periodsService
    ) : ILeaveAllocationsService 
{
    public async Task AllocateLeave(string employeeId)
    {
        // get all the leave types

        var leaveTypes = await _context.LeaveTypes
            .Where(q => !q.LeaveAllocations.Any(x => x.EmployeeId == employeeId))
            .ToListAsync();

        var periods = await _context.Periods.ToListAsync();
        var per = periods[0];
        var year = per.EndDate.Year;

        // get the current period based on the year

        var currentDate = DateTime.Now;
        var period = await _context.Periods.SingleAsync(q => q.EndDate.Year == currentDate.Year);
        var monthsRemaining = period.EndDate.Month - currentDate.Month;

        // calculate leave based on number of months left in the period

        //foreach leave type, create an allocation entry

        foreach(var leaveType in leaveTypes)
        {
            //Works, but not best practice
            //var allocationExists = await AllocationExists(employeeId, period.Id, leaveType.Id);

            //if(allocationExists)
            //{
            //    continue;
            //}
            var accuralRate = decimal.Divide(leaveType.NumberOfDays, 12);
            var leaveAllocation = new LeaveAllocation
            {
                EmployeeId = employeeId,
                LeaveTypeId = leaveType.Id,
                PeriodId = period.Id,
                Days = (int)Math.Ceiling(accuralRate * monthsRemaining)
            };

            _context.Add(leaveAllocation);
        }
        await _context.SaveChangesAsync();
    }

    public async Task<EmployeeAllocationVM>  GetEmployeeAllocations(string? userId)
    {
        var user = string.IsNullOrEmpty(userId) 
            ? await _userService.GetLoggedInUser() 
            : await _userService.GetUserById(userId);
         
        var allocations = await GetAllocations(user.Id);
        var allocationVmList = _mapper.Map<List<LeaveAllocation>, List<LeaveAllocationVM>>(allocations);
        var leaveTypesCount = await _context.LeaveTypes.CountAsync();
      
        return new EmployeeAllocationVM
        {
            DateOfBirth = user.DateOfBirth,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Id = user.Id,
            LeaveAllocations = allocationVmList,
            IsCompletedAllocation = leaveTypesCount == allocations.Count
        };
    }

    public async Task<List<EmployeeListVM>> GetEmployees()
    {
        var users = await _userService.GetEmployees();
        return _mapper.Map<List<ApplicationUser>, List<EmployeeListVM>>(users.ToList());
    }

    public async Task<LeaveAllocationEditVM> GetEmployeeAllocation(int allocationId)
    {
        var allocation = await _context.LeaveAllocations
            .Include(q => q.LeaveType)
            .Include(q => q.Employee)
            .FirstOrDefaultAsync(q => q.Id == allocationId);

        return _mapper.Map<LeaveAllocationEditVM>(allocation);
    }

    public async Task EditAllocation(LeaveAllocationEditVM allocationEditVm)
    {
        //var leaveAllocation = await GetEmployeeAllocation(allocationEditVm.Id);
        //if (leaveAllocation == null)
        //{
        //    throw new Exception("Leave allocation record does not exist.");
        //}
        //leaveAllocation.Days = allocationEditVm.Days;
        // option 1 _context.Update(leaveAllocation);
        // option 2 _context.Entry(leaveAllocation).State = EntityState.Modified;
        // _context.SaveChangesAsync();

        await _context.LeaveAllocations
            .Where(q => q.Id == allocationEditVm.Id)
            .ExecuteUpdateAsync(s => s.SetProperty(e => e.Days, allocationEditVm.Days));
    }

    public async Task<LeaveAllocation> GetCurrentAllocation(int leaveTypeId, string employeeId)
    {
        var period = await _periodsService.GetCurrentPeriod();
        return await _context.LeaveAllocations.
                    FirstAsync(q => q.LeaveTypeId == leaveTypeId
                    && q.EmployeeId == employeeId
                    && q.PeriodId == period.Id);
    }
    private async Task<List<LeaveAllocation>> GetAllocations(string? userId)
    {
        var currentDate = DateTime.Now;
        //var period = await _context.Periods.SingleAsync(q => q.EndDate.Year == currentDate.Year);

        //return await _context.LeaveAllocations
        //    .Include(q => q.LeaveType)
        //    .Include(q => q.Period)
        //    .Where(q => q.EmployeeId == user.Id && q.PeriodId == period.Id)
        //    .ToListAsync();
        return await _context.LeaveAllocations
            .Include(q => q.LeaveType)
            .Include(q => q.Period)
            .Where(q => q.EmployeeId == userId && q.Period.EndDate.Year == currentDate.Year)
            .ToListAsync();
    }

    private async Task<bool> AllocationExists(string? userId, int periodId, int leaveTypeId)
    {
        return await _context.LeaveAllocations.AnyAsync(q =>
            q.EmployeeId == userId
            && q.LeaveTypeId == leaveTypeId
            && q.PeriodId == periodId
          );
    }
}
