
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace LeaveManagement.Web.Services.Periods
{
    public class PeriodsService(ApplicationDbContext _context) : IPeriodsService
    {
        public async Task<Period> GetCurrentPeriod()
        {
            var currentDate = DateTime.Now;
            return await _context.Periods.SingleAsync(q => q.EndDate.Year == currentDate.Year);
        }
    }
}
