using Microsoft.AspNetCore.Identity;

namespace LeaveManagement.Web.Services.UserInfo
{
    public class UserService(IHttpContextAccessor _httpContextAccessor, UserManager<ApplicationUser> _userManager) : IUserService
    {
        public async Task<ApplicationUser> GetLoggedInUser()
        {
            return await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        }

        public async Task<ApplicationUser> GetUserById(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<List<ApplicationUser>> GetEmployees ()
        {
            var employees = await _userManager.GetUsersInRoleAsync(Roles.Employee);
            return employees.ToList();
        }
    }
}
